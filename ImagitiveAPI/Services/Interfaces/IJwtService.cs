using ImagitiveAPI.Models;

namespace ImagitiveAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserDBModel user, List<string> roles);
    }
}
