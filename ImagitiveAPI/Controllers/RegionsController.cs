using ImagitiveAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImagitiveAPI.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _regionService.GetAllRegionsAsync());
        }

        [HttpGet("{regionId}")]
        public async Task<IActionResult> GetById(int regionId)
        {
            var region = await _regionService.GetRegionByIdAsync(regionId);
            if (region == null)
                return NotFound();
            return Ok(region);
        }
    }
}

