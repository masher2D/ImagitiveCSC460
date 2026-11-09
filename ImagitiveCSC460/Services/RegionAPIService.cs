using ImagitiveLibrary.Core.Models;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class RegionAPIService
    {
        public async Task<List<RegionModel>?>GetRegionsAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/regions");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<List<RegionModel>>();
        }

        public async Task<RegionModel?> GetRegionByIdAsync(int regionId)
        {
            var response = await ApiClient.Client.GetAsync($"api/regions/{regionId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<RegionModel>();
        }
    }
}
