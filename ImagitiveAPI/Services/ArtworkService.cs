using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Requests;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ImageMagick;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using ImageMagick.Drawing;

namespace ImagitiveAPI.Services
{
    public class ArtworkService : IArtworkService
    {

        private AppDBContext _context;

        private readonly IRatingService _ratingService;

        private readonly bool _skipGifOptimizePasses;

        private readonly ILogger<ArtworkService> _logger;

        public ArtworkService(
            AppDBContext context,
            IRatingService ratingService,
            IConfiguration? configuration = null,
            ILogger<ArtworkService>? logger = null)
        {
            _context = context;
            _ratingService = ratingService;
            _skipGifOptimizePasses = configuration?.GetValue<bool>("ImageProcessing:SkipGifOptimizePasses") ?? false;
            _logger = logger ?? NullLogger<ArtworkService>.Instance;
        }

        private void QueueDerivedImagesProcessing(string filePath, string fileName, string uploadsFolder, string username)
        {
            _ = Task.Run(() =>
            {
                try
                {
                    ProcessDerivedImages(filePath, fileName, uploadsFolder, username);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to generate derived images for file {FileName}.", fileName);
                }
            });
        }

        private void ProcessDerivedImages(string filePath, string fileName, string uploadsFolder, string username)
        {
            bool isAnimatedGif = string.Equals(Path.GetExtension(fileName), ".gif", StringComparison.OrdinalIgnoreCase);
            const int maxAnimatedGifFrames = 200;

            if (isAnimatedGif)
            {
                using (var sourceCollection = new MagickImageCollection(filePath))
                {
                    if (sourceCollection.Count > maxAnimatedGifFrames)
                    {
                        throw new Exception("Animated GIF has too many frames to watermark. Maximum supported is 200 frames.");
                    }

                    sourceCollection.Coalesce();

                    using (var compressedCollection = sourceCollection.Clone())
                    {
                        foreach (var frame in compressedCollection)
                        {
                            frame.Resize(new MagickGeometry(800, 800) { IgnoreAspectRatio = false });
                        }

                        if (!_skipGifOptimizePasses)
                        {
                            compressedCollection.OptimizeTransparency();
                            compressedCollection.Optimize();
                        }

                        string compressedFilePath = Path.Combine(uploadsFolder, $"compressed_{fileName}");
                        compressedCollection.Write(compressedFilePath);
                    }

                    using (var watermarkCollection = sourceCollection.Clone())
                    {
                        var watermarkText = $"Property of {username}";
                        var watermarkLayers = new Dictionary<(uint Width, uint Height), MagickImage>();

                        foreach (var frame in watermarkCollection)
                        {
                            var key = (frame.Width, frame.Height);
                            if (!watermarkLayers.TryGetValue(key, out var watermarkLayer))
                            {
                                watermarkLayer = new MagickImage(MagickColors.Transparent, frame.Width, frame.Height);
                                var watermarkDrawables = new Drawables()
                                    .Font("Arial")
                                    .FontPointSize(26)
                                    .FillColor(new MagickColor("#FFFFFF55"))
                                    .StrokeColor(new MagickColor("#00000033"))
                                    .StrokeWidth(1);

                                const int tileWidth = 280;
                                const int tileHeight = 180;
                                for (int y = -tileHeight; y < frame.Height + tileHeight; y += tileHeight)
                                {
                                    for (int x = -tileWidth; x < frame.Width + tileWidth; x += tileWidth)
                                    {
                                        watermarkDrawables
                                            .PushGraphicContext()
                                            .Translation(x, y)
                                            .Rotation(-30)
                                            .Text(0, 0, watermarkText)
                                            .PopGraphicContext();
                                    }
                                }

                                watermarkDrawables.Draw(watermarkLayer);
                                watermarkLayers[key] = watermarkLayer;
                            }

                            frame.Composite(watermarkLayer, CompositeOperator.Over);
                        }

                        foreach (var watermarkLayer in watermarkLayers.Values)
                        {
                            watermarkLayer.Dispose();
                        }

                        if (!_skipGifOptimizePasses)
                        {
                            watermarkCollection.OptimizeTransparency();
                            watermarkCollection.Optimize();
                        }

                        string watermarkFilePath = Path.Combine(uploadsFolder, $"watermark_{fileName}");
                        watermarkCollection.Write(watermarkFilePath);
                    }
                }
            }
            else
            {
                using (var image = new MagickImage(filePath))
                {
                    using var compressedImage = image.Clone();
                    compressedImage.Resize(new MagickGeometry(800, 800) { IgnoreAspectRatio = false });
                    string compressedFilePath = Path.Combine(uploadsFolder, $"compressed_{fileName}");
                    compressedImage.Write(compressedFilePath);

                    var watermarkText = $"Property of {username}";
                    using var watermarkLayer = new MagickImage(MagickColors.Transparent, image.Width, image.Height);
                    var watermarkDrawables = new Drawables()
                        .Font("Arial")
                        .FontPointSize(26)
                        .FillColor(new MagickColor("#FFFFFF55"))
                        .StrokeColor(new MagickColor("#00000033"))
                        .StrokeWidth(1);

                    const int tileWidth = 280;
                    const int tileHeight = 180;
                    for (int y = -tileHeight; y < image.Height + tileHeight; y += tileHeight)
                    {
                        for (int x = -tileWidth; x < image.Width + tileWidth; x += tileWidth)
                        {
                            watermarkDrawables
                                .PushGraphicContext()
                                .Translation(x, y)
                                .Rotation(-30)
                                .Text(0, 0, watermarkText)
                                .PopGraphicContext();
                        }
                    }

                    watermarkDrawables.Draw(watermarkLayer);
                    image.Composite(watermarkLayer, CompositeOperator.Over);

                    string watermarkFilePath = Path.Combine(uploadsFolder, $"watermark_{fileName}");
                    image.Write(watermarkFilePath);
                }
            }
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
                CompressedUrl = artwork.CompressedURL,
                WatermarkedUrl = artwork.WatermarkedURL,
                UploadDate = artwork.UploadDate,
                ViewCount = artwork.ViewCount,
                UserId = artwork.UserId,
                AverageRateValue = avgRating,
                Tags = tags
            };
        }

        public async Task<ArtworkModel> CreateArtworkAsync(int userId, PostArtworkFormRequest request)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if(user == null)
            {
                throw new Exception("User not found.");
            }
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

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            const long maxAnimatedGifBytes = 20 * 1024 * 1024;

            if (string.Equals(Path.GetExtension(fileName), ".gif", StringComparison.OrdinalIgnoreCase)
                && request.ImageFile.Length > maxAnimatedGifBytes)
            {
                throw new Exception("Animated GIF is too large to watermark. Please upload a GIF smaller than 20 MB.");
            }
            QueueDerivedImagesProcessing(filePath, fileName, uploadsFolder, user.Username);


            var artwork = new ArtworkDBModel
            {
                UserId = userId,
                Title = request.Title,
                Description = request.Description,

                ImageURL = $"/uploads/{fileName}",
                CompressedURL = $"/uploads/compressed_{fileName}",
                WatermarkedURL = $"/uploads/watermark_{fileName}",

                UploadDate = DateTime.UtcNow,
                ViewCount = 0,
                BoostViewsRemaining = 50
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

        public async Task<PagedResponse<ArtworkModel>> GetFeedAsync(int viewerId, int page, int pageSize, string? tagFilter = null)
        {
            var viewer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == viewerId);
            var region = viewer?.RegionID;

            var feedQuery = _context.Artworks
                .Where(a => !a.IsRemoved && a.UserId != viewerId);

            if (!string.IsNullOrWhiteSpace(tagFilter))
            {
                var normalizedFilter = tagFilter.Trim();
                feedQuery = feedQuery.Where(a =>
                    _context.ArtworkTags
                        .Where(at => at.ArtworkId == a.ArtworkId)
                        .Join(
                            _context.Tags,
                            at => at.TagId,
                            t => t.TagId,
                            (at, t) => t.Name)
                        .Any(tagName => tagName == normalizedFilter));
            }

            var artworks = await feedQuery.ToListAsync();
            if (artworks.Count == 0)
            {
                return new PagedResponse<ArtworkModel>
                {
                    Items = new List<ArtworkModel>(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalCount = 0
                };
            }

            var artworkIds = artworks.Select(a => a.ArtworkId).ToList();
            var artworkOwnerIds = artworks.Select(a => a.UserId).Distinct().ToList();

            var ownerRegions = await _context.Users
                .Where(u => artworkOwnerIds.Contains(u.UserId))
                .Select(u => new { u.UserId, u.RegionID })
                .ToDictionaryAsync(x => x.UserId, x => x.RegionID);

            var averageRatings = await _context.Ratings
                .Where(r => artworkIds.Contains(r.ArtworkId))
                .GroupBy(r => r.ArtworkId)
                .Select(g => new { ArtworkId = g.Key, Average = g.Average(x => (double)x.RateValue) })
                .ToDictionaryAsync(x => x.ArtworkId, x => x.Average);

            var artworkTags = await _context.ArtworkTags
                .Where(at => artworkIds.Contains(at.ArtworkId))
                .GroupBy(at => at.ArtworkId)
                .Select(g => new { ArtworkId = g.Key, TagIds = g.Select(x => x.TagId).ToList() })
                .ToDictionaryAsync(x => x.ArtworkId, x => x.TagIds);

            var viewerTagPreference = await BuildViewerTagPreferenceAsync(viewerId);

            var boostPool = new List<(ArtworkDBModel Artwork, double Score)>();
            var regularPool = new List<(ArtworkDBModel Artwork, double Score)>();

            foreach (var artwork in artworks)
            {
                var ownerRegion = ownerRegions.TryGetValue(artwork.UserId, out var value) ? value : null;
                var avgRating = averageRatings.TryGetValue(artwork.ArtworkId, out var rating) ? rating : 0;
                var tags = artworkTags.TryGetValue(artwork.ArtworkId, out var tagIds) ? tagIds : new List<int>();

                var score = CalculateRelevanceScore(artwork, region, ownerRegion, avgRating, tags, viewerTagPreference);

                if (artwork.BoostViewsRemaining > 0)
                {
                    boostPool.Add((artwork, score));
                }
                else
                {
                    regularPool.Add((artwork, score));
                }
            }

            var orderedBoost = boostPool
                .OrderByDescending(x => x.Score)
                .Select(x => x.Artwork)
                .ToList();

            var orderedRegular = regularPool
                .OrderByDescending(x => x.Score)
                .Select(x => x.Artwork)
                .ToList();

            var orderedFeed = BuildBalancedFeedOrder(orderedBoost, orderedRegular, pageSize);
            var pagedArtworks = orderedFeed.Skip((page - 1) * pageSize).Take(pageSize).ToList();
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
                TotalCount = orderedFeed.Count
            };
        }

        private async Task<Dictionary<int, double>> BuildViewerTagPreferenceAsync(int viewerId)
        {
            var positiveRatedArtworkIds = await _context.Ratings
                .Where(r => r.UserId == viewerId && r.RateValue >= 3)
                .Select(r => r.ArtworkId)
                .ToListAsync();

            if (positiveRatedArtworkIds.Count == 0)
            {
                return new Dictionary<int, double>();
            }

            var tagWeights = await _context.ArtworkTags
                .Where(at => positiveRatedArtworkIds.Contains(at.ArtworkId))
                .GroupBy(at => at.TagId)
                .Select(g => new { TagId = g.Key, Weight = g.Count() })
                .ToDictionaryAsync(x => x.TagId, x => (double)x.Weight);

            return tagWeights;
        }

        private static double CalculateRelevanceScore(
            ArtworkDBModel artwork,
            int? viewerRegion,
            int? ownerRegion,
            double averageRating,
            List<int> artworkTagIds,
            Dictionary<int, double> viewerTagPreference)
        {
            double score = 0;

            if (ownerRegion == viewerRegion)
            {
                score += 100;
            }

            if (artwork.BoostViewsRemaining > 0)
            {
                score += 80 + Math.Min(artwork.BoostViewsRemaining, 50);
            }

            score += averageRating * 8;

            var preferenceScore = artworkTagIds
                .Where(viewerTagPreference.ContainsKey)
                .Sum(tagId => viewerTagPreference[tagId]);
            score += Math.Min(preferenceScore * 5, 100);

            score -= artwork.ViewCount / 100.0;

            var hoursSinceUpload = (DateTime.UtcNow - artwork.UploadDate).TotalHours;
            score += Math.Max(0, 24 - hoursSinceUpload) * 0.5;

            return score;
        }

        private static List<ArtworkDBModel> BuildBalancedFeedOrder(
            List<ArtworkDBModel> boostArtworks,
            List<ArtworkDBModel> regularArtworks,
            int pageSize)
        {
            var orderedFeed = new List<ArtworkDBModel>(boostArtworks.Count + regularArtworks.Count);
            var boostIndex = 0;
            var regularIndex = 0;

            var boostSlotsPerPage = Math.Clamp((int)Math.Ceiling(pageSize * 0.6), 1, pageSize);
            var regularSlotsPerPage = pageSize - boostSlotsPerPage;

            while (boostIndex < boostArtworks.Count || regularIndex < regularArtworks.Count)
            {
                for (int i = 0; i < boostSlotsPerPage && boostIndex < boostArtworks.Count; i++)
                {
                    orderedFeed.Add(boostArtworks[boostIndex]);
                    boostIndex++;
                }

                for (int i = 0; i < regularSlotsPerPage && regularIndex < regularArtworks.Count; i++)
                {
                    orderedFeed.Add(regularArtworks[regularIndex]);
                    regularIndex++;
                }

                if (regularSlotsPerPage == 0 && boostIndex < boostArtworks.Count && regularIndex < regularArtworks.Count)
                {
                    orderedFeed.Add(regularArtworks[regularIndex]);
                    regularIndex++;
                }
            }

            return orderedFeed;
        }
    }
}
