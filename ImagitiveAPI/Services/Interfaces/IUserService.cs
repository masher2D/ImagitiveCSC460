using ImagitiveAPI.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDBModel> CreateUserAsync(UserDBModel user);
        public Task<UserDBModel?> GetUserByIdAsync(int id);
        public Task<List<UserDBModel>> GetAllUsersAsync();
        public Task<UserDBModel?> UpdateUserAsync(UserDBModel user);
        public Task<bool> DeactivateUserAsync(int id);
    }
}
