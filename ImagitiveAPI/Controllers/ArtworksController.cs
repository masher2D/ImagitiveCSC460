using ImagitiveAPI.Requests;
using ImagitiveAPI.Helpers;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Constants;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/artworks")]
public class ArtworksController : ControllerBase
{
    private readonly IArtworkService _artworkService;
    private readonly IUserService _userService;

    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public ArtworksController(IArtworkService artworkService, IUserService userService)
    {
        _artworkService = artworkService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var artworks = await _artworkService.GetAllArtworksAsync();

        return Ok(artworks);
    }

    [HttpGet("{artworkId}")]
    public async Task<IActionResult> GetById(int artworkId)
    {
        var artwork = await _artworkService.GetArtworkByIdAsync(artworkId);
        if (artwork == null)
        {
            return NotFound();
        }
        return Ok(artwork);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create( [FromForm] PostArtworkFormRequest request)
    {
        var status = await _userService.GetUserAccountStatusAsync(CurrentUserId);

        if(status == AccountStatuses.Restricted)
        {
            return Forbid("Your account is restricted. You cannot create new artworks.");
        }

        var artwork = await _artworkService.CreateArtworkAsync(CurrentUserId, request);

        return Ok(artwork);
    }

    [Authorize]
    [HttpPost("{artworkId}/view")]
    public async Task<IActionResult> RecordView(int artworkId)
    {


        bool success = await _artworkService.RecordViewAsync(artworkId, CurrentUserId);

        if (!success) return NotFound();

        return Ok();
    }

    [Authorize]
    [HttpDelete("{artworkId}")]
    public async Task<IActionResult> Remove(int artworkId, int? reasonId, [FromHeader(Name = "X-Active-Role")] string? activeRole) 
    {
        if (string.IsNullOrWhiteSpace(activeRole))
            return BadRequest("Missing active role.");

        // security: active role must be one of roles in JWT
        if (!User.IsInRole(activeRole))
            return Forbid();

        bool currentlyAdmin = string.Equals("Admin", activeRole, StringComparison.OrdinalIgnoreCase);

        if (reasonId.HasValue && reasonId.Value <= 0)
        {
            return BadRequest("Invalid reason ID.");
        }

        if (currentlyAdmin && !reasonId.HasValue)
            return BadRequest("Admin must provide a reason for removal.");

        int success = await _artworkService.RemoveArtworkAsync(CurrentUserId, currentlyAdmin, artworkId, new RemoveArtworkRequest { ReasonId = reasonId });
        if (success == 0) return NotFound();
        if (success == 2) return Forbid();
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetArtworksByUser(int userId)
    {
        var artworks = await _artworkService.GetArtworksByUserAsync(userId);
        return Ok(artworks);
    }

    [HttpGet("user/{userId}/paged")]
    public async Task<IActionResult> GetArtworksByUserPaged(int userId, int page, int pageSize)
    {
        return Ok(await _artworkService.GetArtworksByUserAsync(userId, page, pageSize));
    }

    [HttpGet("user/{userId}/average-rating")]
    public async Task<IActionResult> GetArtistAverageRating(int userId)
    {
        var averageRating = await _artworkService.GetArtistAverageRatingAsync(userId);
        return Ok(averageRating);
    }

    [HttpGet("{artworkId}/todays-views")]
    public async Task<IActionResult> GetTodaysViews(int artworkId)
    {
        var views = await _artworkService.GetTodaysViewsAsync(artworkId);
        return Ok(views);
    }

    [HttpGet("feed")]
    public async Task<IActionResult> GetFeed(int page = 1, int pageSize = 10, string? tagFilter = null)
    {
        var feed = await _artworkService.GetFeedAsync(CurrentUserId, page, pageSize, tagFilter);
        return Ok(feed);
    }
}