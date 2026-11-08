using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;

    

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

        private async Task<UserModel> MapToUserModel(UserDBModel user)
        {
            List<string> roles = await GetUserRolesAsync(user.UserId);
            return new UserModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                RegionID = user.RegionID,
                AccountStatus = user.AccountStatus,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Roles = roles
            };
        }

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            return await MapToUserModel(user);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            var mappedUsers = new List<UserModel>();

            foreach (var user in users)
            {
                mappedUsers.Add(
                    await MapToUserModel(user));
            }

            return mappedUsers;
        }

        public async Task<UserModel?> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
                return null;

            existingUser.Username = request.Username;
            existingUser.Email = request.Email;
            existingUser.RegionID = request.RegionId;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await MapToUserModel(existingUser);
        }
        
        public async Task<bool> SetUserStatusAsync(int updateeId, string status)
        {

            var existingUser = await _context.Users.FindAsync(updateeId);
            if (existingUser == null)
                return false;

            existingUser.AccountStatus = status;
            existingUser.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

