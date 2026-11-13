using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [Authorize]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateReportStatusRequest request)
    {
        bool isAdmin = User.IsInRole("Admin");
        if (!isAdmin)
        {
            return Forbid();
        }
        bool updated =
            await _reportService
                .UpdateReportStatusAsync(
                    id,
                    request.NewStatus);

        if (!updated)
            return NotFound();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _reportService.GetAllReportsAsync();
        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var report = await _reportService.GetReportByIdAsync(id);
        if (report == null)
            return NotFound();

        return Ok(report);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(PostReportRequest request)
    {
        var report = await _reportService.CreateReportAsync(CurrentUserId, request);
        return Ok(report);
    }

    [Authorize]
    [HttpGet("artwork/{artworkId}")]
    public async Task<IActionResult> GetReportsByArtworkId(int artworkId)
    {
        var reports = await _reportService.GetReportsByArtworkIdAsync(artworkId);
        return Ok(reports);
    }

    [Authorize]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetReportsByUserId(int userId)
    {
        var reports = await _reportService.GetReportsByUserIdAsync(userId);
        return Ok(reports);
    }

    [Authorize]
    [HttpGet("my-reports")]
    public async Task<IActionResult> GetMyReports()
    {
        var reports = await _reportService.GetReportsByReporterIdAsync(CurrentUserId);
        return Ok(reports);
    }

    [Authorize]
    [HttpGet("paged")]
    public async Task<IActionResult> GetAllReports([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "", [FromQuery] string sort = "")
    {
        var pagedReports = await _reportService.GetAllReportsAsync(pageNumber, pageSize, filter, sort);
        return Ok(pagedReports);
    }
}
