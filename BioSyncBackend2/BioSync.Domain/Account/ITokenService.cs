using System.Collections.Generic;

namespace BioSync.Domain.Account
{
    public interface ITokenService
    {
        /// <summary>
        /// Gera um token JWT com base nas informações do usuário.
        /// </summary>
        /// <param name="userId">O ID do usuário.</param>
        /// <param name="email">O e-mail do usuário.</param>
        /// <param name="roles">A lista de papéis (roles) do usuário.</param>
        /// <returns>Uma string representando o token JWT.</returns>
        string GenerateToken(string userId, string email, IList<string> roles);
    }
}