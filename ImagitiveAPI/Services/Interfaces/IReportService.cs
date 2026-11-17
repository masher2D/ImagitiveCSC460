using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportModel> CreateReportAsync(int reporterId, PostReportRequest request);

        Task<List<ReportModel>> GetAllReportsAsync();

        Task<ReportModel?> GetReportByIdAsync(int reportId);

        Task<bool> UpdateReportStatusAsync(int reportId, string status);

        Task<List<ReportModel>> GetReportsByUserIdAsync(int userId);

        Task<List<ReportModel>> GetReportsByArtworkIdAsync(int artworkId);

        Task<List<ReportModel>> GetReportsByStatusAsync(string status);

        Task<List<ReportModel>> GetReportsByReporterIdAsync(int reporterId);

        Task<PagedResponse<ReportModel>> GetAllReportsAsync(int pageNumber, int pageSize, string filter, string sort);

        Task<bool> ResolveReportAsync(int resolverId, PostAdminReportDecisionRequest request);
    }
}
