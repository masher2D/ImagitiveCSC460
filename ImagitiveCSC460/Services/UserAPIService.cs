using ImagitiveAPI.Session;
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

        
    }
}
