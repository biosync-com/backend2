using System.Collections.Generic;
using System.Security.Claims;

namespace BioSync.Domain.Account
{
    public interface ITokenService
    {
        string GenerateToken(string email, IEnumerable<Claim> claims);
    }
}