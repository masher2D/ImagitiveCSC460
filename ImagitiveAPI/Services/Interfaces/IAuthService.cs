using Microsoft.AspNetCore.Identity.Data;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LogInResponse> LoginAsync(LogInRequest request);

        public Task SignupAsync(SignupRequest request);

        public Task ChangePasswordAsync(UpdatePasswordRequest request);
    }
}
