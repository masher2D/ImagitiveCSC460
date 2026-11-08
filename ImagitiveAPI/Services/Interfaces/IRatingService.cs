using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IRatingService
    {
        Task<bool> PostRatingAsync(int userId, PostRatingRequest request);

        Task<double> GetAverageRatingAsync(int artworkId);
    }
}
