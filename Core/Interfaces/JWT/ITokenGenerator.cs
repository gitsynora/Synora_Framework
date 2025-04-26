using System.Security.Claims;

namespace UltraNet.Core.Interfaces.JWT
{
    public interface ITokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
