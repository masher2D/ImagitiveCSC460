using ImagitiveAPI.Data;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class ReasonService : IReasonService
    {
        private readonly AppDBContext _context;
        public ReasonService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<ReasonModel>?> GetAllReasonsAsync()
        {
            return await _context.Reasons
                .Select(r => new ReasonModel
                {
                    ReasonId = r.ReasonId,
                    Name = r.Name
                })
                .ToListAsync();
        }
        public async Task<ReasonModel?> GetReasonByIdAsync(int reasonId)
        {
            var reason = await _context.Reasons
                .FirstOrDefaultAsync(r => r.ReasonId == reasonId);
            if (reason == null)
            {
                return null;
            }
            return new ReasonModel
            {
                ReasonId = reason.ReasonId,
                Name = reason.Name
            };
        }
    }
}
