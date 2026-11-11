using ImagitiveLibrary.Core.Models;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class TagAPIService
    {
        public async Task<List<TagModel>?> GetAllTagsAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/tags");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<TagModel>>();
        }
    }
}
