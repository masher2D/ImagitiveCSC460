using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using System.Net.Http.Json;

public class RatingAPIService
{
    public async Task<bool> PostRatingAsync(
        PostRatingRequest request)
    {
        var response =
            await ApiClient.Client.PostAsJsonAsync("api/ratings", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<double?> GetAverageRatingAsync(
        int artworkId)
    {
        var response =
            await ApiClient.Client.GetAsync($"api/ratings/{artworkId}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<double>();
    }

    public async Task<RatingModel?> GetUserRatingAsync(int artworkId)
    {
        var response =
            await ApiClient.Client.GetAsync($"api/ratings/user/{artworkId}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<RatingModel>();
    }

    public async Task<bool> UpdateRatingAsync(PostRatingRequest request)
    {
        var response =
            await ApiClient.Client.PatchAsJsonAsync($"api/ratings/{request.ArtworkId}", request);
        return response.IsSuccessStatusCode;
    }
}
