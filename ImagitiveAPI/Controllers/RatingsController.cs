using ImagitiveAPI.Data;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/ratings")]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingsController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRating([FromBody] PostRatingRequest request)
    {
        await _ratingService.PostRatingAsync(request);
        return Ok();
    }

    [HttpGet("average/{artworkId}")]
    public async Task<IActionResult> GetAverageRating(int artworkId)
    {
        double averageRating = await _ratingService.GetAverageRatingAsync(artworkId);
        return Ok(averageRating);
    }
}

