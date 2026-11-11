using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IRatingService
    {
        Task<bool> PostRatingAsync(int userId, PostRatingRequest request);

        Task<double> GetAverageRatingAsync(int artworkId);

        Task<RatingModel?> GetUserRatingAsync(int userId, int artworkId);

        Task<bool> UpdateRatingAsync(int userId, PostRatingRequest request);
    }
}
