using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Requests;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;

namespace ImagitiveAPI.Services
{
    public class ArtworkService : IArtworkService
    {

        private AppDBContext _context;

        private readonly IRatingService _ratingService;

        public ArtworkService(AppDBContext context, IRatingService ratingService)
        {
            _context = context;
            _ratingService = ratingService;
        }

        private async Task ResolveTagsAsync(int artworkId, List<string> tags)
        {
            foreach (var tagName in tags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);

                if (tag == null)
                {
                    tag = new TagDBModel
                    {
                        Name = tagName
                    };

                    _context.Tags.Add(tag);

                    await _context.SaveChangesAsync();
                }

                _context.ArtworkTags.Add(
                    new ArtworkTagDBModel
                    {
                        ArtworkId = artworkId,
                        TagId = tag.TagId
                    });
            }

            await _context.SaveChangesAsync();
        }

        private async Task<List<string>> GetArtworkTagsAsync(int artworkId)
        {
            return await _context.ArtworkTags
                .Where(at => at.ArtworkId == artworkId)
                .Join(
                    _context.Tags,
                    at => at.TagId,
                    t => t.TagId,
                    (at, t) => t.Name)
                .ToListAsync();
        }


        private async Task<ArtworkModel> MapToArtworkModel(ArtworkDBModel artwork)
        {
            List<string> tags = await GetArtworkTagsAsync(artwork.ArtworkId);
            double avgRating = await _ratingService.GetAverageRatingAsync(artwork.ArtworkId);
            return new ArtworkModel
            {
                ArtworkId = artwork.ArtworkId,
                Title = artwork.Title,
                Description = artwork.Description,
                ImageUrl = artwork.ImageURL,
                UploadDate = artwork.UploadDate,
                ViewCount = artwork.ViewCount,
                UserId = artwork.UserId,
                AverageRateValue = avgRating,
                Tags = tags
            };
        }

        public async Task<ArtworkModel> CreateArtworkAsync(int userId, PostArtworkFormRequest request)
        {


            var uniqueTags = request.Tags.Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            if (uniqueTags.Count > 3) 
            { 
                throw new Exception("Maximum of 3 tags allowed.");
            }

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
            if(Directory.Exists(uploadsFolder) == false)
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string fileName = $"{Guid.NewGuid():N}" + Path.GetExtension(request.ImageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);

            await request.ImageFile.CopyToAsync(stream);

            var artwork = new ArtworkDBModel
            {
                UserId = userId,
                Title = request.Title,
                Description = request.Description,

                ImageURL = $"/uploads/{fileName}",

                UploadDate = DateTime.UtcNow,

                ViewCount = 0,
                // Make sure to update this later
                BoostViewsRemaining = 0
            };

            _context.Artworks.Add(artwork);
            await _context.SaveChangesAsync();
            await ResolveTagsAsync(artwork.ArtworkId, request.Tags);
            return await MapToArtworkModel(artwork);




        }

        public async Task<List<ArtworkModel>> GetAllArtworksAsync()
        {
 
            var artworks = _context.Artworks.ToListAsync();

            var mappedArtworks = new List<ArtworkModel>();

            foreach (var artwork in await artworks)
            {
                mappedArtworks.Add(
                    await MapToArtworkModel(artwork));
            }

            return mappedArtworks;
        }

        public async Task<ArtworkModel?> GetArtworkByIdAsync(int artworkId)
        {
            var artwork = await _context.Artworks.FindAsync(artworkId);
            return artwork != null ? await MapToArtworkModel(artwork) : null;
        }

        public async Task<bool> RecordViewAsync(int artworkId, int userId)
        {
            var artwork = await _context.Artworks.FindAsync(artworkId);
            if (artwork == null) return false;

            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC RecordArtworkView {artworkId}, {userId}");
            return true;
        }

        public async Task<int> RemoveArtworkAsync(int requesterId, bool isAdmin, int artworkId, RemoveArtworkRequest request)
        {

            var artwork = await _context.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == artworkId);
            if (artwork == null) return 0;
            if(isAdmin)
                if(request.ReasonId == null)
                    throw new Exception("Admin must provide a reason for removal.");
            if (!isAdmin && artwork.UserId != requesterId) return 2;

            artwork.IsRemoved = true;
            artwork.RemovedReason = request.ReasonId;

            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<List<ArtworkModel>> GetArtworksByUserAsync(int userId)
        {
            var artworks = await _context.Artworks
                .Where(a => a.UserId == userId && !a.IsRemoved)
                .ToListAsync();
            var mappedArtworks = new List<ArtworkModel>();
            foreach (var artwork in artworks)
            {
                mappedArtworks.Add(
                    await MapToArtworkModel(artwork));
            }
            return mappedArtworks;
        }

        public async Task<PagedResponse<ArtworkModel>> GetArtworksByUserAsync(int userId, int page, int pageSize)
        {
            
            var artworks = await _context.Artworks
                .Where(a => a.UserId == userId && !a.IsRemoved)
                .OrderByDescending(a => a.UploadDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mappedArtworks = new List<ArtworkModel>();
            foreach (var artwork in artworks)
            {
                mappedArtworks.Add(await MapToArtworkModel(artwork));
            }
            return new PagedResponse<ArtworkModel>
            {
                Items = mappedArtworks,
                TotalCount = await _context.Artworks.CountAsync(a => a.UserId == userId && !a.IsRemoved),
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public async Task<double> GetArtistAverageRatingAsync(int userId)
        {
            var artworks = await _context.Artworks
                .Where(a => a.UserId == userId && !a.IsRemoved)
                .ToListAsync();
            if (artworks.Count == 0) return 0.0;
            double totalRating = 0.0;
            int ratedArtworksCount = 0;
            foreach (var artwork in artworks)
            {
                var averageRating = await _ratingService.GetAverageRatingAsync(artwork.ArtworkId);
                if (averageRating > 0)
                {
                    totalRating += averageRating;
                    ratedArtworksCount++;
                }
            }
            return ratedArtworksCount > 0 ? totalRating / ratedArtworksCount : 0.0;
        }

        public async Task<int> GetTodaysViewsAsync(int artworkId)
        {
            var today = DateTime.UtcNow.Date;
            var end = today.AddDays(1).AddTicks(-1);
            return await _context.ArtworkViews
                .CountAsync(v => v.ArtworkId == artworkId && v.ViewedAt >= today && v.ViewedAt <= end);
        }

        public async Task<PagedResponse<ArtworkModel>> GetFeedAsync(int viewerId, int page, int pageSize)
        {
            var viewer = await _context.Users.FirstAsync(u => u.UserId == viewerId);
            var region = viewer.RegionID;

            var artworks = await _context.Artworks
                .Where(a => !a.IsRemoved && a.UserId != viewerId)
                .ToListAsync();

            var filteredArtworks = artworks.OrderByDescending(a => CalculateRelevanceScore(a, viewerId, region)).ToList();
            var pagedArtworks = filteredArtworks.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var mappedArtworks = new List<ArtworkModel>();
            foreach(var artwork in pagedArtworks)
            {
                mappedArtworks.Add(await MapToArtworkModel(artwork));
            }

            return new PagedResponse<ArtworkModel>
            {
                Items = mappedArtworks,
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = filteredArtworks.Count
            };
        }

        private int CalculateRelevanceScore(ArtworkDBModel artwork, int viewerId, int? region)
        {
            int score = 0;
            // Increase score for artworks from the same region
            var artworkOwner = _context.Users.FirstOrDefault(u => u.UserId == artwork.UserId);
            if (artworkOwner != null && artworkOwner.RegionID == region)
            {
                score += 100;
            }
            if (artwork.BoostViewsRemaining > 0)
            {
                score += artwork.BoostViewsRemaining; 
            }
            // Increase score based on average rating
            var averageRating = _ratingService.GetAverageRatingAsync(artwork.ArtworkId).Result;
            score += (int)(averageRating * 2); // Each star adds 2 points
            // Increase score based on view count
            score += artwork.ViewCount / 50; // Every 50 views adds 1 point
            return score;
        }
    }
}
