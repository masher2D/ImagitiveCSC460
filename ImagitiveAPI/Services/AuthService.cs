using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using ImagitiveAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class AuthService : IAuthService
    {
        private AppDBContext _context;
        private IJwtService _jwtService;

        public AuthService(AppDBContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        private async Task<List<string>> GetUserRolesAsync(int userId)
        {
            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(
                    _context.Roles,
                    ur => ur.RoleId,
                    r => r.RoleId,
                    (ur, r) => r.RoleName)
                .ToListAsync();
            return roles;
        }

        public async Task UpdatePasswordAsync(int userId, UpdatePasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
            {
                throw new Exception("Current password is incorrect.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            int rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC UpdateUserPassword {userId}, {hashedPassword}");
            if(rowsAffected == 0)
            {
                throw new Exception("Password update failed.");
            }
        }


        public async Task<LogInResponse> LoginAsync(LogInRequest request)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new LogInResponse
                {
                    Success = false,
                    Message = "Invalid username or password."
                };
            }

            var roles = await GetUserRolesAsync(user.UserId);

            string token = _jwtService.GenerateToken(user, roles);

            return new LogInResponse
            {
                Success = true,
                Message = "Login successful.",
                UserId = user.UserId,
                Username = user.Username,
                Roles = roles,
                Token = token
            };
        }

        public async Task<UserModel> SignupUserAsync(SignupRequest request)
        {

            
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new UserDBModel
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            bool userExists = await _context.Users.AnyAsync(u => u.Username == request.Username || u.Email == request.Email);
            if (userExists)
            {
                throw new Exception("User with the same username or email already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            int newUserId = user.UserId;

            foreach (var roleId in request.RoleIds)
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC AddUserRole {newUserId}, {roleId}");
            }

            var roles = await _context.Roles
                .Where(r => request.RoleIds.Contains(r.RoleId))
                .Select(r => r.RoleName)
                .ToListAsync();

            return new UserModel
            {
                UserId = newUserId,
                Username = user.Username,
                Email = user.Email,
                Roles = roles
            };
            
        }
    }
}
