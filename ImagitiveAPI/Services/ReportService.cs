using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using Microsoft.EntityFrameworkCore;
using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services;

namespace ImagitiveAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDBContext _context;
        private readonly ArtworkService _artworkService;

        private static readonly HashSet<string> ValidStatuses = [
            "Unresolved",
            "UnderReview",
            "Resolved",
            "Dismissed"
        ];

        public ReportService(AppDBContext context)
        {
            _context = context;
            _artworkService = _artworkService;
        }

        private ReportModel MapToReportModel(ReportDBModel report)
        {
            return new ReportModel
            {
                ReportID = report.ReportId,
                ArtworkId = report.ArtworkId,
                ReportedUserId = report.ReportedUserId,
                Status = report.Status,
                ReasonID = report.ReasonID,
                Description = report.Description,
                ReporterId = report.ReporterId,
                ReportedAt = report.ReportedAt
            };
        }

        public async Task<ReportModel> CreateReportAsync(PostReportRequest request)
        {
            bool reportingArtwork = request.ArtworkId.HasValue;

            bool reportingUser = request.ReportedUserId.HasValue;

            if (reportingArtwork == reportingUser)
            {
                throw new Exception("A report must target exactly one item.");
            }

            if (reportingUser)
            {
                if (request.ReportedUserId == request.ReporterId)
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
            }

            if (reportingArtwork)
            {
                bool artworkExists = await _context.Artworks
                    .AnyAsync(a => a.ArtworkId == request.ArtworkId);

                if (!artworkExists)
                {
                    throw new Exception(
                        "Artwork not found.");
                }

                var artwork = await _context.Artworks
                    .FirstOrDefaultAsync(a => a.ArtworkId == request.ArtworkId);

                if(artwork.UserId == request.ReporterId)
                {
                    throw new Exception(
                        "Users cannot report their own posts.");
                }

            }

            if (request.ReportedUserId == request.ReporterId)
            {
                throw new Exception(
                    "Users cannot report themselves.");
            }

            bool reasonExists = await _context.Reasons
                .AnyAsync(r => r.ReasonId == request.ReasonID);

            bool reporterExists = await _context.Users
                .AnyAsync(u => u.UserId == request.ReporterId);

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


            bool alreadyReported = await _context.Reports
                .AnyAsync(r => 
                    r.ReporterId == request.ReporterId &&
                    r.ArtworkId == request.ArtworkId &&
                    r.Status == "Unresolved");

            var report = new ReportDBModel
            {
                ArtworkId = request.ArtworkId,
                ReportedUserId = request.ReportedUserId,
                ReporterId = request.ReporterId,
                ReasonID = request.ReasonID,
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
                throw new Exception(
                    "Invalid status.");
            }

            var report = await _context.Reports.FindAsync(reportId);
            if (report == null) return false;

            report.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
