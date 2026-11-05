namespace ImagitiveAPI.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<List<string>> GetRolesForUserAsync(int userId);
        public Task<List<string>> GetAllRolesAsync();
        public Task<bool> AssignRoleToUserAsync(int userId, string roleName);
        public Task<bool> RemoveRoleFromUserAsync(int userId, string roleName);
    }
}
