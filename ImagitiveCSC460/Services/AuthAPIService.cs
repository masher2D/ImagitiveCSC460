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

    public async Task<UserModel?> SignupAsync(
        SignupRequest request)
    {
        var response =
            await ApiClient.Client.PostAsJsonAsync(
                "api/auth/signup",
                request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content
            .ReadFromJsonAsync<UserModel>();
    }

    public async Task<bool> UpdatePasswordAsync(
        UpdatePasswordRequest request)
    {
        var response =
            await ApiClient.Client.PostAsJsonAsync(
                "api/auth/update-password",
                request);

        return response.IsSuccessStatusCode;
    }
}