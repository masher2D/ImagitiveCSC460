using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IRatingService
    {
        Task<PostRatingResponse> PostRatingAsync(int userId, PostRatingRequest request);

        Task<double> GetAverageRatingAsync(int artworkId);

        Task<RatingModel?> GetUserRatingAsync(int userId, int artworkId);

        Task<PostRatingResponse> UpdateRatingAsync(int userId, PostRatingRequest request);
    }
}
