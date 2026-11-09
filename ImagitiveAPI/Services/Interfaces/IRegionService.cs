using ImagitiveAPI.Models;
using ImagitiveLibrary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IRegionService
    {
        Task<List<RegionModel>> GetAllRegionsAsync();
        Task<RegionModel?> GetRegionByIdAsync(int regionId);
    }
}
