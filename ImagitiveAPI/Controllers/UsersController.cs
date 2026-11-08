using ImagitiveAPI.Data;
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
        public async Task<IActionResult> Update(int updateeId, UpdateUserRequest request)
        {


            var roles =
                User.FindAll(ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

            if (!roles.Contains("Admin"))
            {
                return Forbid();
            }

            var user = await _userService.UpdateUserAsync(updateeId, request);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        


    }
}
