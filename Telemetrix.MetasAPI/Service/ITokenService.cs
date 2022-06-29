using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace Telemetrix.API.Service
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claim);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
