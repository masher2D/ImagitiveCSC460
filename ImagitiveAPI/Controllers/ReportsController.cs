using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
    int id,
    UpdateReportStatusRequest request)
    {
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

    [HttpPost]
    public async Task<IActionResult> Create(PostReportRequest request)
    {
        var report = await _reportService.CreateReportAsync(request);
        return Ok(report);
    }

}
