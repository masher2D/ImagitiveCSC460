using ImagitiveAPI.Services.Interfaces;
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

    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public ArtworksController(IArtworkService artworkService)
    {
        _artworkService = artworkService;
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
    public async Task<IActionResult> Create( [FromForm] PostArtworkRequest request, [FromForm] IFormFile imageFile)
    {

        var artwork = await _artworkService.CreateArtworkAsync(CurrentUserId, request, imageFile);

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
    public async Task<IActionResult> Remove(int artworkId, int reasonId)
    {

        bool isAdmin = User.IsInRole("Admin");
        int success = await _artworkService.RemoveArtworkAsync(CurrentUserId, isAdmin, artworkId, new RemoveArtworkRequest { ReasonId = reasonId });
        if (success == 0) return NotFound();
        if (success == 2) return Forbid();
        return Ok();
    }
}