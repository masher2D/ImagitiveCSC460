using ImagitiveLibrary.Core.Models;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ImagitiveCSC460UI.Services
{
    public class ReasonAPIService
    {
        public async Task<List<ReasonModel>?> GetAllReasonsAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/reasons");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<ReasonModel>>();
        }
        public async Task<ReasonModel?> GetReasonByIdAsync(int reasonId)
        {
            var response = await ApiClient.Client.GetAsync($"api/reasons/{reasonId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<ReasonModel>();
        }
    }
}
