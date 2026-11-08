using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces;

public interface IArtworkService
{
    Task<List<ArtworkModel>> GetAllArtworksAsync();

    Task<ArtworkModel?> GetArtworkByIdAsync(int artworkId);

    Task<ArtworkModel> CreateArtworkAsync(int userId, PostArtworkRequest request, IFormFile file);

    Task<int> RemoveArtworkAsync(int requesterId, bool isAdmin, int artworkId, RemoveArtworkRequest request);

    Task<bool> RecordViewAsync(int artworkId, int userId);

}
