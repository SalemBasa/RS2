using System.Security.Claims;

using TrashTrack.Application;

namespace TrashTrack.Api
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(CustomClaimTypes.UserId);

            if (int.TryParse(claim?.Value, out var id))
                return id;

            return null;
        }
    }
}
