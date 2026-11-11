using ImagitiveAPI.Requests;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services.Interfaces;

public interface IArtworkService
{
    Task<List<ArtworkModel>> GetAllArtworksAsync();

    Task<ArtworkModel?> GetArtworkByIdAsync(int artworkId);

    Task<List<ArtworkModel>>GetArtworksByUserAsync(int userId);

    Task<PagedResponse<ArtworkModel>> GetArtworksByUserAsync(int userId, int page, int pageSize);

    Task<ArtworkModel> CreateArtworkAsync(int userId, PostArtworkFormRequest request);

    Task<int> RemoveArtworkAsync(int requesterId, bool isAdmin, int artworkId, RemoveArtworkRequest request);

    Task<bool> RecordViewAsync(int artworkId, int userId);

    Task<double> GetArtistAverageRatingAsync(int userId);

    Task<int> GetTodaysViewsAsync(int artworkId);

    Task<List<ArtworkModel>>  GetFeedAsync(int viewerId, int page, int pageSize);

}
