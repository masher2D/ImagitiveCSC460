using System.Net.Http.Headers;

namespace ImagitiveUI.Services;

public static class ApiClient
{
    private const string ActiveRoleHeaderName = "X-Active-Role";

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

    public static void SetActiveRole(string? activeRole)
    {
        Client.DefaultRequestHeaders.Remove(ActiveRoleHeaderName);
        if (!string.IsNullOrWhiteSpace(activeRole))
        {
            Client.DefaultRequestHeaders.Add(ActiveRoleHeaderName, activeRole);
        }
    }

    public static void ClearAuthContext()
    {
        Client.DefaultRequestHeaders.Authorization = null;
        Client.DefaultRequestHeaders.Remove(ActiveRoleHeaderName);
    }
}
