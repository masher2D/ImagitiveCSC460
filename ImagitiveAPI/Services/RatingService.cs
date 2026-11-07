using ImagitiveLibrary.Core.Requests;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveAPI.Models;
using ImagitiveAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly AppDBContext _context;
        public RatingService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> PostRatingAsync(PostRatingRequest request)
        {

            bool userExists = await _context.Users.AnyAsync(u => u.UserId == request.UserId);

            if (!userExists)
            {
                throw new Exception("User not found.");
            }

            if (request.RateValue < 1 || request.RateValue > 5)
            {
                throw new Exception("Rating must be between 1 and 5.");
            }

            var artwork = await _context.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == request.ArtworkId);

            if (artwork == null)
            {
                throw new Exception("Artwork not found.");
            }

            if (artwork.IsRemoved)
            {
                throw new Exception("Cannot rate removed artwork.");
            }

            var existingRating = await _context.Ratings.FirstOrDefaultAsync(r => r.ArtworkId == request.ArtworkId && r.UserId == request.UserId);
            if (existingRating != null)
            {
                existingRating.RateValue = request.RateValue;
            }
            else
            {
                var newRating = new RatingDBModel
                {
                    ArtworkId = request.ArtworkId,
                    UserId = request.UserId,
                    RateValue = request.RateValue
                };
                _context.Ratings.Add(newRating);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<double> GetAverageRatingAsync(int artworkId)
        {
            return await _context.Ratings
                .Where(r => r.ArtworkId == artworkId)
                .AverageAsync(r => (double?)r.RateValue) ?? 0.0;
        }
    }
}
