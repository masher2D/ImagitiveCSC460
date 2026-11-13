using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ImagitiveAPI.Controllers;

[ApiController]
[Route("api/adminrequests")]
public class AdminRequestsController : ControllerBase
{
    private readonly IAdminRequestService _adminRequestService;
    private int CurrentUserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    public AdminRequestsController(IAdminRequestService adminRequestService)
    {
        _adminRequestService = adminRequestService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateAdminRequest([FromBody] PostAdminPromoteRequest request)
    {
        var response = await _adminRequestService.CreateRequestAsync(CurrentUserId, request);
        if (response == null)
        {
            return BadRequest("Failed to create admin request.");
        }
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateAdminRequestStatus(int id, [FromBody] string status)
    {
        var result = await _adminRequestService.UpdateRequestStatusAsync(id, status);
        if (!result)
        {
            return BadRequest("Failed to update admin request status.");
        }
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("paged")]
    public async Task<IActionResult> GetAllAdminRequests([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "", [FromQuery] string sort = "")
    {
        var pagedResponse = await _adminRequestService.GetAllRequestsAsync(pageNumber, pageSize, filter, sort);
        return Ok(pagedResponse);
    }

}
