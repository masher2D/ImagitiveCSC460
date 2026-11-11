using ImagitiveAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImagitiveAPI.Controllers
{
    
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }
    }
}
