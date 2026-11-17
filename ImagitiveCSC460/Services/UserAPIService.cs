using ImagitiveCSC460UI.Session;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class UserAPIService
    {
        public async Task<List<UserModel>?> GetAllUsersAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/users");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<UserModel>>();
        }

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {

            var response = await ApiClient.Client.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UserModel>();

        }
        public async Task<bool> UpdateUserAsync(UpdateUserRequest request)
        {
            var response = await ApiClient.Client.PutAsJsonAsync($"api/users/{UserSession.UserId}", request);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> SetUserStatusAsync(int updateeId, string status)
        {
            var response = await ApiClient.Client.PatchAsJsonAsync($"api/users/{updateeId}/status", new { Status = status });
            return response.IsSuccessStatusCode;
        }
        
        public async Task<UserModel?> GetUserByUsername(string username)
        {
            var response = await ApiClient.Client.GetAsync($"api/users/username/{username}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<UserModel>();
        }

        public async Task<bool> AddUserRole(string role)
        {
            var response = await ApiClient.Client.PostAsJsonAsync($"api/users/{UserSession.UserId}/roles", new PostAddRoleRequest { Role = role });
            if (!response.IsSuccessStatusCode)
                return false;

            return true;

        }
    }
}
