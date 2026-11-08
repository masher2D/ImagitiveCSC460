using System.Net.Http.Headers;

namespace ImagitiveUI.Services;

public static class ApiClient
{
    public static HttpClient Client { get; } =
        new HttpClient
        {
            BaseAddress =
                new Uri("https://localhost:7108/")
        };

    public static void SetToken(string token)
    {
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                token);
    }
}
