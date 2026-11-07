using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces;

public interface IArtworkService
{
    Task<List<ArtworkModel>> GetAllArtworksAsync();

    Task<ArtworkModel?> GetArtworkByIdAsync(int artworkId);

    Task<ArtworkModel> CreateArtworkAsync(PostArtworkRequest request, IFormFile file);

    Task<bool> RemoveArtworkAsync(int artworkId, int reasonId);

    Task<bool> RecordViewAsync(int artworkId, int userId);

}
