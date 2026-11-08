using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportModel> CreateReportAsync(int reporterId, PostReportRequest request);

        Task<List<ReportModel>> GetAllReportsAsync();

        Task<ReportModel?> GetReportByIdAsync(int reportId);

        Task<bool> UpdateReportStatusAsync(int reportId, string status);
    }
}
