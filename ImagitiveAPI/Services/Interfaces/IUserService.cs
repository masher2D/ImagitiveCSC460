using ImagitiveAPI.Models;
using ImagitiveLibrary.Core.Constants;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> GetUserByIdAsync(int id);
        public Task<List<UserModel>> GetAllUsersAsync();
        public Task<bool> UpdateUserAsync(int id, UpdateUserRequest request);
        public Task<bool> SetUserStatusAsync(int updateeId, string status);
        public Task<string?> GetUserAccountStatusAsync(int userId);
        public Task<UserModel?> GetUserByUsername(string username);
        public Task<bool> AddUserRole(int userId, string role);
    }
}
