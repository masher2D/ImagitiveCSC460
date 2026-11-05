using ImagitiveAPI.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IArtworkService
    {
        public Task<ArtworkDBModel> CreateArtworkAsync(ArtworkDBModel artwork);
        public Task<ArtworkDBModel> GetArtworkByIdAsync(int id);
        public Task<List<ArtworkDBModel>> GetAllArtworksAsync();
        public Task<ArtworkDBModel> UpdateArtworkAsync(ArtworkDBModel artwork);
        public Task<bool> DeleteArtworkAsync(int id);
    }
}
