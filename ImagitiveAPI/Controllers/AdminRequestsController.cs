using ImagitiveAPI.Helpers;
using ImagitiveAPI.Services;
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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAdminRequest([FromBody] PostAdminPromoteCreateRequest request)
    {
        if (!ActiveRoleAuthorizationHelper.TryResolveActiveRole(Request, User, out _, out var errorResult, "Admin"))
        {
            return errorResult!;
        }

        var response = await _adminRequestService.CreateRequestAsync(CurrentUserId, request);
        if (response == null)
        {
            return BadRequest("Failed to create admin request.");
        }
        return Ok(response);
    }

    [Authorize]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateAdminRequestStatus(int id, [FromBody] string status)
    {
        if (!ActiveRoleAuthorizationHelper.TryResolveActiveRole(Request, User, out _, out var errorResult, "Admin"))
        {
            return errorResult!;
        }

        var result = await _adminRequestService.UpdateRequestStatusAsync(id, status);
        if (!result)
        {
            return BadRequest("Failed to update admin request status.");
        }
        return Ok();
    }

    [Authorize]
    [HttpGet("paged")]
    public async Task<IActionResult> GetAllAdminRequests([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "", [FromQuery] string sort = "")
    {
        if (!ActiveRoleAuthorizationHelper.TryResolveActiveRole(Request, User, out _, out var errorResult, "Admin"))
        {
            return errorResult!;
        }

        var pagedResponse = await _adminRequestService.GetAllRequestsAsync(pageNumber, pageSize, filter, sort);
        return Ok(pagedResponse);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{id}/resolve")]
    public async Task<IActionResult> PostResolve(int id, PostAdminPromoteDecisionRequest request)
    {
        request.RequestId = id;
        bool resolved = await _adminRequestService.ResolvePromoteRequestAsync(CurrentUserId, request);
        if (!resolved)
            return NotFound();

        return Ok();
    }



}
