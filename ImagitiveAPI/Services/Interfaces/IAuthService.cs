using Microsoft.AspNetCore.Identity.Data;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using ImagitiveLibrary.Core.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<UserModel> SignupUserAsync(SignupRequest request);
        public Task<LogInResponse> LoginAsync(LogInRequest request);
        public Task UpdatePasswordAsync(int userId, UpdatePasswordRequest request);
    }
}
