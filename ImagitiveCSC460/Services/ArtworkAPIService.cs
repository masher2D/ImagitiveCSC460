using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class ArtworkAPIService
    {
        public async Task<ArtworkModel?> CreateArtworkAsync(string filePath, PostArtworkRequest request)
        {
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(request.Title), "Title");

            content.Add(new StringContent(request.Description ?? string.Empty), "Description");

            foreach (var tag in request.Tags)
            {
                content.Add(new StringContent(tag), "Tags");
            }

            content.Add(new StreamContent(File.OpenRead(filePath)), "ImageFile", Path.GetFileName(filePath));

            var response = await ApiClient.Client.PostAsync("api/artworks", content);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ArtworkModel>();
        }

        public async Task<bool> RemoveArtworkAsync(int artworkId, int reasonId)
        {
            var response = await ApiClient.Client.DeleteAsync($"api/artworks/{artworkId}?reasonId ={reasonId}");

            return response.IsSuccessStatusCode;

        }

        public async Task<ArtworkModel?> GetArtworkById(int artworkId)
        {
            var response = await ApiClient.Client.GetAsync($"api/artworks/{artworkId}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ArtworkModel>();


        }

        public async Task<List<ArtworkModel>?> GetAllArtworksAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/artworks");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<ArtworkModel>>();
        }

        public async Task<bool> RecordViewAsync(int artworkId)
        {
            var response = await ApiClient.Client.PostAsync($"api/artworks/{artworkId}/view", null);

            return response.IsSuccessStatusCode;

        }

    }
}
