using ImagitiveAPI.Models;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> GetUserByIdAsync(int id);
        public Task<List<UserModel>> GetAllUsersAsync();
        public Task<UserModel?> UpdateUserAsync(int id, UpdateUserRequest request);
        public Task<bool> SetUserStatusAsync(int id, string status);
    }
}
