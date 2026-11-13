using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using Microsoft.EntityFrameworkCore;
using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services;
using ImagitiveLibrary.Core.Responses;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace ImagitiveAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDBContext _context;

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            "Unresolved",
            "Resolved",
            "UnderReview"
        };

        public ReportService(AppDBContext context)
        {
            _context = context;
        }

        private ReportModel MapToReportModel(ReportDBModel report)
        {
            return new ReportModel
            {
                ReportId = report.ReportId,
                ArtworkId = report.ArtworkId,
                ReportedUserId = report.ReportedUserId,
                Status = report.Status,
                ReasonId = report.ReasonId,
                Description = report.Description,
                ReporterId = report.ReporterId,
                ReportedAt = report.ReportedAt
            };
        }

        public async Task<ReportModel> CreateReportAsync(int reporterId, PostReportRequest request)
        {
            bool reportingArtwork = request.ArtworkId.HasValue;

            bool reportingUser = request.ReportedUserId.HasValue;

            if (reportingArtwork == reportingUser)
            {
                throw new Exception("A report must target exactly one item.");
            }

            if (reportingUser)
            {
                if (request.ReportedUserId == reporterId)
                {
                    throw new Exception(
                        "You cannot report yourself.");
                }

                bool userExists = await _context.Users
                    .AnyAsync(u =>
                        u.UserId == request.ReportedUserId);

                if (!userExists)
                {
                    throw new Exception(
                        "Reported user not found.");
                }

                bool alreadyReported = await _context.Reports
                    .AnyAsync(r =>
                    r.ReporterId == reporterId &&
                    r.ReportedUserId ==
                    request.ReportedUserId &&
                    r.Status == "Unresolved");

                if (alreadyReported)
                {
                    throw new Exception(
                        "You already have an unresolved report for this user.");

                }
            }

            if (reportingArtwork)
            {
                var artwork = await _context.Artworks
                    .FirstOrDefaultAsync(a => a.ArtworkId == request.ArtworkId);

                if (artwork == null)
                {
                    throw new Exception(
                        "Artwork not found.");
                }

                

                if(artwork.UserId == reporterId)
                {
                    throw new Exception(
                        "Users cannot report their own posts.");
                }

                bool alreadyReported = await _context.Reports
                    .AnyAsync(r =>
                    r.ReporterId == reporterId &&
                    r.ArtworkId == request.ArtworkId &&
                    r.Status == "Unresolved");

                if (alreadyReported)
                {
                    throw new Exception(
                       "You have already reported this artwork and it is still unresolved.");
                }

            }

            bool reasonExists = await _context.Reasons
                .AnyAsync(r => r.ReasonId == request.ReasonId);

            bool reporterExists = await _context.Users
                .AnyAsync(u => u.UserId == reporterId);

            if (!reasonExists)
            {
                throw new Exception(
                    "Invalid reason.");
            }

            if (!reporterExists)
            {
                throw new Exception(
                    "Reporting user not found.");
            }


            

            var report = new ReportDBModel
            {
                ArtworkId = request.ArtworkId,
                ReportedUserId = request.ReportedUserId,
                ReporterId = reporterId,
                ReasonId = request.ReasonId,
                Description = request.Description,
                Status = "Unresolved",
                ReportedAt = DateTime.UtcNow
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return MapToReportModel(report);

        }

        public async Task<ReportModel?> GetReportByIdAsync(int reportId)
        {
            var report = await _context.Reports.FindAsync(reportId);
            return report != null ? MapToReportModel(report) : null;
        }

        public async Task<List<ReportModel>> GetAllReportsAsync()
        {
            var reports = await _context.Reports.ToListAsync();
            return reports.Select(MapToReportModel).ToList();
        }

        public async Task<bool> UpdateReportStatusAsync(int reportId, string status)
        {
            if (!ValidStatuses.Contains(status))
            {
                throw new InvalidOperationException(
                    "Invalid status.");
            }

            var report = await _context.Reports.FindAsync(reportId);
            if (report == null) return false;

            report.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReportModel>> GetReportsByUserIdAsync(int userId)
        {
            var reports = await _context.Reports
                .Where(r => r.ReportedUserId == userId)
                .ToListAsync();
            var mappedReports = new List<ReportModel>();
            foreach (var report in reports)
            {
                mappedReports.Add(MapToReportModel(report));
            }
            return mappedReports;
        }

        public async Task<List<ReportModel>> GetReportsByArtworkIdAsync(int artworkId)
        {
            var reports = await _context.Reports
                .Where(r => r.ArtworkId == artworkId)
                .ToListAsync();
            var mappedReports = new List<ReportModel>();
            foreach (var report in reports)
            {
                mappedReports.Add(MapToReportModel(report));
            }
            return mappedReports;
        }

        public async Task<List<ReportModel>> GetReportsByStatusAsync(string status)
        {
            var reports = await _context.Reports
                .Where(r => r.Status == status)
                .ToListAsync();
            var mappedReports = new List<ReportModel>();
            foreach (var report in reports)
            {
                mappedReports.Add(MapToReportModel(report));
            }
            return mappedReports;
        }

        public async Task<List<ReportModel>> GetReportsByReporterIdAsync(int reporterId)
        {
            var reports = await _context.Reports
                .Where(r => r.ReporterId == reporterId)
                .ToListAsync();
            var mappedReports = new List<ReportModel>();
            foreach (var report in reports)
            {
                mappedReports.Add(MapToReportModel(report));
            }
            return mappedReports;
        }

        public async Task<PagedResponse<ReportModel>> GetAllReportsAsync(int pageNumber, int pageSize, string filter, string sort)
        {
            var query = _context.Reports.AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(filter))
            {
                switch(filter.ToLower())
                {
                    case "status: unresolved":
                        query = query.Where(r => r.Status == "Unresolved");
                        break;
                    case "status: resolved":
                        query = query.Where(r => r.Status == "Resolved");
                        break;
                    case "date: last 7 days":
                        var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);
                        query = query.Where(r => r.ReportedAt >= sevenDaysAgo);
                        break;
                    case "date: last month":
                        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
                        query = query.Where(r => r.ReportedAt >= thirtyDaysAgo);
                        break;
                    default:
                        throw new ArgumentException("Invalid filter value. Valid values are: status: unresolved, status: resolved, date: last 7 days, date: last month.");
                }
            }

            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort.ToLower())
                {
                    case "newest to oldest":
                        query = query.OrderByDescending(r => r.ReportedAt);
                        break;
                    case "oldest to newest":
                        query = query.OrderBy(r => r.ReportedAt);
                        break;
                    case "reason: a-z":
                        query = query.OrderBy(r => r.ReasonId);
                        break;
                    case "reason: z-a":
                        query = query.OrderByDescending(r => r.ReasonId);
                        break;
                    default:
                        throw new ArgumentException("Invalid sort value. Valid values are: newest to oldest, oldest to newest, reason: a-z, reason: z-a.");
                }
            }

            var reports = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var mappedReports = reports.Select(MapToReportModel).ToList();
            return new PagedResponse<ReportModel>
            {
                Items = mappedReports,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = await _context.Reports.CountAsync()
            };
        }
    }
}
