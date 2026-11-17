using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ImagitiveAPI.Helpers
{
    public static class ActiveRoleAuthorizationHelper
    {
        public const string ActiveRoleHeaderName = "X-Active-Role";

        public static bool TryResolveActiveRole(
            HttpRequest request,
            ClaimsPrincipal user,
            out string? activeRole,
            out IActionResult? errorResult,
            string? requiredRole = null)
        {
            activeRole = null;
            errorResult = null;

            if (!request.Headers.TryGetValue(ActiveRoleHeaderName, out var activeRoleHeaderValues))
            {
                errorResult = new BadRequestObjectResult("Missing active role.");
                return false;
            }

            var headerRole = activeRoleHeaderValues.ToString().Trim();
            if (string.IsNullOrWhiteSpace(headerRole))
            {
                errorResult = new BadRequestObjectResult("Missing active role.");
                return false;
            }

            if (!user.IsInRole(headerRole))
            {
                errorResult = new ForbidResult();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(requiredRole) && !string.Equals(headerRole, requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                errorResult = new ForbidResult();
                return false;
            }

            activeRole = headerRole;
            return true;
        }
    }
}