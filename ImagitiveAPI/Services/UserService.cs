using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImagitiveAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<UserDBModel> CreateUserAsync(UserDBModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

            
        }

        public async Task<bool> DeactivateUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null) 
                return false;
            int rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SetUserStatus {id}, 'Deactivated'");
            return rowsAffected > 0;
        }

        public async Task<List<UserDBModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserDBModel?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserDBModel?> UpdateUserAsync(UserDBModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

