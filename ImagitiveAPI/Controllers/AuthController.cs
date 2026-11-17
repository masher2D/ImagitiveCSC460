using Microsoft.AspNetCore.Mvc;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Requests;
using Microsoft.AspNetCore.Authorization;

namespace ImagitiveAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            try
            {
                var user = await _authService.SignupUserAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInRequest request)
        {
            var response = await _authService.LoginAsync(request);
            if (!response.Success)
            {
                return Unauthorized(new { Message = response.Message });
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPatch("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            try
            {
                int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
                await _authService.UpdatePasswordAsync(userId, request);
                return Ok(new { Message = "Password updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
