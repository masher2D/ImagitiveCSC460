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
}
