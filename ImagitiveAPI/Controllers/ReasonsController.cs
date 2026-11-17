using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImagitiveAPI.Controllers
{
    [Route("api/reasons")]
    [ApiController]
    public class ReasonsController : ControllerBase
    {
        private readonly IReasonService _reasonService;
        public ReasonsController(IReasonService reasonService)
        {
            _reasonService = reasonService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ReasonModel>?>> GetAllReasonsAsync()
        {
            var reasons = await _reasonService.GetAllReasonsAsync();
            if (reasons == null)
            {
                return NotFound();
            }
            return Ok(reasons);
        }

        [HttpGet("{reasonId}")]
        public async Task<ActionResult<ReasonModel?>> GetReasonByIdAsync(int reasonId)
        {
            var reason = await _reasonService.GetReasonByIdAsync(reasonId);
            if (reason == null)
            {
                return NotFound();
            }
            return Ok(reason);
        }
    }
}
