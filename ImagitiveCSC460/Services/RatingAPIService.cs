using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using ImagitiveUI.Services;
using System.Net.Http.Json;

public class RatingAPIService
{
    public async Task<PostRatingResponse> PostRatingAsync(
        PostRatingRequest request)
    {
        var response = await ApiClient.Client.PostAsJsonAsync("api/ratings", request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to post rating.");
        }

        var payload = await response.Content.ReadFromJsonAsync<PostRatingResponse>();
        return payload ?? new PostRatingResponse { Success = false, ErrorMessage = "Failed to parse rating response." };
    }

    public async Task<double?> GetAverageRatingAsync(
        int artworkId)
    {
        var response = await ApiClient.Client.GetAsync($"api/ratings/average/{artworkId}");

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

    public async Task<PostRatingResponse> UpdateRatingAsync(PostRatingRequest request)
    {
        var response = await ApiClient.Client.PatchAsJsonAsync($"api/ratings/{request.ArtworkId}", request);
        if (!response.IsSuccessStatusCode)
        {
            return new PostRatingResponse
            {
                Success = false,
                ErrorMessage = "Failed to update rating."
            };
        }

        var payload = await response.Content.ReadFromJsonAsync<PostRatingResponse>();
        return payload ?? new PostRatingResponse { Success = false, ErrorMessage = "Failed to parse rating response." };
    }
}
