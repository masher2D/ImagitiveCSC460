using ImagitiveLibrary.Core.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<TagModel>?> GetAllTagsAsync();
    }
}
