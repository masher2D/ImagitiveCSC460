using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Mvc;


namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/artworks")]
public class ArtworksController : ControllerBase
{
    private readonly IArtworkService _artworkService;

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

    [HttpPost]
    public async Task<IActionResult> Create( [FromForm] PostArtworkRequest request, IFormFile imageFile)
    {
        var artwork = await _artworkService.CreateArtworkAsync(request,imageFile);

        return Ok(artwork);
    }

    [HttpPost("{id}/view")]
    public async Task<IActionResult> RecordView(
    int id,
    int viewerId)
    {
        bool success = await _artworkService.RecordViewAsync(id, viewerId);

        if (!success) return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id, int reasonId)
    {
        bool success = await _artworkService.RemoveArtworkAsync(id, reasonId);
        if (!success) return NotFound();
        return Ok();
    }
}