using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Constants;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/ratings")]
public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;
    private readonly IUserService _userService;

    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public RatingsController(IRatingService ratingService, IUserService userService)
    {
        _ratingService = ratingService;
        _userService = userService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateRating([FromBody] PostRatingRequest request)
    {

        var status = await _userService.GetUserAccountStatusAsync(CurrentUserId);

        if (status == AccountStatuses.Restricted)
        {
            return Forbid("Your account is restricted. You cannot create new artworks.");
        }

        var response = await _ratingService.PostRatingAsync(CurrentUserId, request);
        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    [HttpGet("average/{artworkId}")]
    public async Task<IActionResult> GetAverageRating(int artworkId)
    {
        double averageRating = await _ratingService.GetAverageRatingAsync(artworkId);
        return Ok(averageRating);
    }

    [Authorize]
    [HttpPatch("{artworkId}")]
    public async Task<IActionResult> UpdateRating(int artworkId, [FromBody] PostRatingRequest request)
    {
        var response = await _ratingService.UpdateRatingAsync(CurrentUserId, request);
        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return NotFound();
        }
    }

    [Authorize]
    [HttpGet("user/{artworkId}")]
    public async Task<IActionResult> GetUserRating(int artworkId)
    {
        var rating = await _ratingService.GetUserRatingAsync(CurrentUserId, artworkId);
        if (rating == null)
        {
            return NotFound();
        }
        return Ok(rating);
    }
}

