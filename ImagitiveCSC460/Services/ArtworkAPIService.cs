using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
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

        public async Task<bool> RemoveArtworkAsync(int artworkId, int? reasonId)
        {
            var response = await ApiClient.Client.DeleteAsync($"api/artworks/{artworkId}?reasonId={reasonId}");

            return response.IsSuccessStatusCode;

        }

        public async Task<ArtworkModel?> GetArtworkByIdAsync(int artworkId)
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

        public async Task<List<ArtworkModel>?> GetArtworksByUserAsync(int userId)
        {
            var response = await ApiClient.Client.GetAsync($"api/artworks/user/{userId}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<List<ArtworkModel>>();
        }

        public async Task<PagedResponse<ArtworkModel>?> GetArtworksByUserAsync(int userId, int page, int pageSize)
        {
            var response = await ApiClient.Client.GetAsync($"api/artworks/user/{userId}/paged?page={page}&pageSize={pageSize}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<PagedResponse<ArtworkModel>>();
        }

        public async Task<double?> GetArtistAverageRatingAsync(int userId)
        {
            var response = await ApiClient.Client.GetAsync($"api/artworks/user/{userId}/average-rating");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<double>();
        }

        public async Task<int?> GetTodaysViewsAsync(int artworkId)
        {
            var response = await ApiClient.Client.GetAsync($"api/artworks/{artworkId}/todays-views");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<PagedResponse<ArtworkModel>?> GetFeedAsync(int page, int pageSize, string? tagFilter = null)
        {
            var endpoint = $"api/artworks/feed?page={page}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(tagFilter))
            {
                endpoint += $"&tagFilter={Uri.EscapeDataString(tagFilter)}";
            }

            var response = await ApiClient.Client.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<PagedResponse<ArtworkModel>>();
        }

        public async Task<Stream?> GetImageStreamAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return null;
            }

            var response = await ApiClient.Client.GetAsync(imageUrl, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
            {
                response.Dispose();
                return null;
            }

            return await response.Content.ReadAsStreamAsync();
        }
    }
}
