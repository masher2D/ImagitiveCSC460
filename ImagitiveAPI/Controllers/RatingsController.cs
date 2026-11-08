using ImagitiveAPI.Data;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/ratings")]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public RatingsController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateRating([FromBody] PostRatingRequest request)
    {
        await _ratingService.PostRatingAsync(CurrentUserId, request);
        return Ok();
    }

    [HttpGet("average/{artworkId}")]
    public async Task<IActionResult> GetAverageRating(int artworkId)
    {
        double averageRating = await _ratingService.GetAverageRatingAsync(artworkId);
        return Ok(averageRating);
    }
}

