using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using Microsoft.EntityFrameworkCore;
using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services
{
    public class AdminRequestService : IAdminRequestService
    {
        private readonly AppDBContext _context;

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            "Unresolved",
            "Resolved",
            "UnderReview"
        };

        public AdminRequestService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<AdminRequestModel> CreateRequestAsync(int reporterId, PostAdminPromoteRequest request)
        {
            bool isValidRequest = request.RequesteeId > 0 && !string.IsNullOrWhiteSpace(request.Description);
            if(!isValidRequest)
            {
                throw new ArgumentException("Invalid request data.");
            }
            bool isSelfRequest = reporterId == request.RequesteeId;
            if (isSelfRequest)
            {
                throw new InvalidOperationException("You cannot request to promote yourself.");
            }
            bool requesteeExists = _context.Users.Any(u => u.UserId == request.RequesteeId);
            if (!requesteeExists)
            {
                throw new InvalidOperationException("The user you are trying to promote does not exist.");
            }

            var roles = getUserRoleIds(request.RequesteeId);
            if (roles.Contains(3))
            {
                throw new InvalidOperationException("The requestee is already an admin.");
            }

            bool requestAlreadyExists = _context.AdminRequests.Any(r => r.RequesterId == reporterId && r.RequesteeId == request.RequesteeId && r.Status == "Pending");
            if (requestAlreadyExists)
            {
                throw new InvalidOperationException("A pending request for this user already exists.");
            }

            var adminRequest = new ImagitiveAPI.Models.AdminRequestDBModel
            {
                RequesterId = reporterId,
                RequesteeId = request.RequesteeId,
                Description = request.Description,
                Status = "Unresolved",
                RequestedAt = DateTime.UtcNow,
                
            };

            _context.AdminRequests.Add(adminRequest);
            await _context.SaveChangesAsync();
            return MapToAdminRequestModel(adminRequest);
        }

        public async Task<List<AdminRequestModel>> GetAllRequestsAsync()
        {
            var adminRequests = await _context.AdminRequests.ToListAsync();
            return adminRequests.Select(MapToAdminRequestModel).ToList();
        }

        public async Task<PagedResponse<AdminRequestModel>> GetAllRequestsAsync(int pageNumber, int pageSize, string filter, string sort)
        {
            var query = _context.AdminRequests.AsQueryable().AsNoTracking();

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
                        query = query.Where(r => r.RequestedAt >= sevenDaysAgo);
                        break;
                    case "date: last month":
                        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
                        query = query.Where(r => r.RequestedAt >= thirtyDaysAgo);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid filter value.");
                }
            }

            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort.ToLower())
                {
                    case "newest to oldest":
                        query = query.OrderByDescending(r => r.RequestedAt);
                        break;
                    case "oldest to newest":
                        query = query.OrderBy(r => r.RequestedAt);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid sort value.");
                }
            }

            var adminRequests = await query
                .OrderBy(r => r.RequestedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var mappedRequests = new List<AdminRequestModel>();
            foreach (var request in adminRequests)
            {
                mappedRequests.Add(MapToAdminRequestModel(request));
            }
            return new PagedResponse<AdminRequestModel>
            {
                Items = mappedRequests,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = await _context.AdminRequests.CountAsync()
            };
        }

        public async Task<AdminRequestModel?> GetRequestByIdAsync(int requestId)
        {
            var adminRequest = await _context.AdminRequests.FirstOrDefaultAsync(r => r.RequestId == requestId);
            return adminRequest != null ? MapToAdminRequestModel(adminRequest) : null;
        }

        public async Task<List<AdminRequestModel>> GetRequestsByRequesterIdAsync(int requesterId)
        {
            var requests = await _context.AdminRequests
                .Where(r => r.RequesterId == requesterId)
                .ToListAsync();
            var mappedRequests = new List<AdminRequestModel>();
            foreach (var request in requests)
            {
                mappedRequests.Add(MapToAdminRequestModel(request));
            }
            return mappedRequests;
        }

        public async Task<List<AdminRequestModel>> GetRequestsByStatusAsync(string status)
        {
            var requests = await _context.AdminRequests
                .Where(r => r.Status == status)
                .ToListAsync();
            var mappedRequests = new List<AdminRequestModel>();
            foreach (var request in requests)
            {
                mappedRequests.Add(MapToAdminRequestModel(request));
            }
            return mappedRequests;
        }

        public async Task<bool> UpdateRequestStatusAsync(int requestId, string status)
        {
            if(!ValidStatuses.Contains(status))
            {
                throw new InvalidOperationException("Invalid status value.");
            }
            var request = await _context.AdminRequests.FindAsync(requestId);
            if (request == null)
            {
                return false;
            }
            request.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        private List<int> getUserRoleIds(int userId)
        {
            return _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId)
                .ToList();
        }

        private AdminRequestModel MapToAdminRequestModel(ImagitiveAPI.Models.AdminRequestDBModel dbModel)
        {
            return new AdminRequestModel
            {
                RequestId = dbModel.RequestId,
                RequesterId = dbModel.RequesterId,
                RequesteeId = dbModel.RequesteeId,
                Status = dbModel.Status,
                Description = dbModel.Description,
                RequestedAt = dbModel.RequestedAt,
                ResolvedAt = dbModel.ResolvedAt
            };
        }
    }
}
