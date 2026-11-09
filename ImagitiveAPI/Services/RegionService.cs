using ImagitiveAPI.Data;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    
    public class RegionService : IRegionService
    {
        private readonly AppDBContext _context;

        public RegionService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<RegionModel>> GetAllRegionsAsync()
        {
            return await _context.Regions
                .Select(r => new RegionModel
                {
                    RegionId = r.RegionId,
                    Name = r.Name
                })
                .ToListAsync();
        }

        public Task<RegionModel?> GetRegionByIdAsync(int regionId)
        {
            return _context.Regions
                .Where(r => r.RegionId == regionId)
                .Select(r => new RegionModel
                {
                    RegionId = r.RegionId,
                    Name = r.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
