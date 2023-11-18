using System.Security.Claims;

namespace TrashTrack.Application
{
    public interface ICurrentPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}
