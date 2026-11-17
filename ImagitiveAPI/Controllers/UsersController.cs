using ImagitiveAPI.Data;
using ImagitiveAPI.Helpers;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ImagitiveAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserRequest request)
        {
   
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId == null)
                return Unauthorized();

            int authenticatedUserId = int.Parse(currentUserId);

            if (!ActiveRoleAuthorizationHelper.TryResolveActiveRole(Request, User, out var activeRole, out var errorResult))
            {
                return errorResult!;
            }

            bool isAdmin = string.Equals(activeRole, "Admin", StringComparison.OrdinalIgnoreCase);

            if (!isAdmin && authenticatedUserId != id)
                return Forbid();

            bool success = await _userService.UpdateUserAsync(id, request);
            if (!success)
                return NotFound();

            return Ok();
        }

        [Authorize]
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [Authorize]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> SetUserStatus(int id, [FromBody] SetUserStatusRequest request)
        {
            if (!ActiveRoleAuthorizationHelper.TryResolveActiveRole(Request, User, out _, out var errorResult, "Admin") && request.Status != "Deactivated")
            {
                return errorResult!;
            }

            var result = await _userService.SetUserStatusAsync(id, request.Status);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [Authorize]
        [HttpPost("{userId}/roles")]
        public async Task<IActionResult> AddUserRole(int userId, [FromBody] PostAddRoleRequest request)
        {
           
            var result = await _userService.AddUserRole(userId,request.Role);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
