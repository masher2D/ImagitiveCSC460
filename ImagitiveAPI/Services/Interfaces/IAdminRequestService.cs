using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IAdminRequestService
    {
        Task<AdminRequestModel> CreateRequestAsync(int reporterId, PostAdminPromoteCreateRequest request);

        Task<List<AdminRequestModel>> GetAllRequestsAsync();

        Task<AdminRequestModel?> GetRequestByIdAsync(int requestId);

        Task<bool> UpdateRequestStatusAsync(int requestId, string status);

        Task<List<AdminRequestModel>> GetRequestsByStatusAsync(string status);

        Task<List<AdminRequestModel>> GetRequestsByRequesterIdAsync(int requesterId);

        Task<PagedResponse<AdminRequestModel>> GetAllRequestsAsync(int pageNumber, int pageSize, string filter, string sort);

        Task<bool> ResolvePromoteRequestAsync(int resolverId, PostAdminPromoteDecisionRequest decisionRequest);

    }
}
