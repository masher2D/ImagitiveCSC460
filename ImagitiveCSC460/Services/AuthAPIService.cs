using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using System.Net.Http.Json;


namespace ImagitiveUI.Services;

public class AuthApiService
{
    public async Task<LogInResponse?> LoginAsync(
        LogInRequest request)
    {
        var response =
            await ApiClient.Client.PostAsJsonAsync(
                "api/auth/login",
                request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content
            .ReadFromJsonAsync<LogInResponse>();
    }

    public async Task<(UserModel? User, string? Error)> SignupAsync(
        SignupRequest request)
    {
        var response =
            await ApiClient.Client.PostAsJsonAsync(
                "api/auth/signup",
                request);

        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content
                    .ReadFromJsonAsync<ErrorResponse>();

            return (null, error?.Message);
        }

            return (await response.Content
            .ReadFromJsonAsync<UserModel>(), null);
    }

    public async Task<bool> UpdatePasswordAsync(
        UpdatePasswordRequest request)
    {
        var response =
            await ApiClient.Client.PatchAsJsonAsync(
                "api/auth/update-password",
                request);

        return response.IsSuccessStatusCode;
    }
}