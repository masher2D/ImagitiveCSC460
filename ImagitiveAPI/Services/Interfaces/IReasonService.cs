using ImagitiveLibrary.Core.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IReasonService
    {
        Task<List<ReasonModel>?> GetAllReasonsAsync();
        Task<ReasonModel?> GetReasonByIdAsync(int reasonId);
    }
}
