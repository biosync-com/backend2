using BioSync.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService; // Adicionado

        // Construtor atualizado
        public AuthenticateService(UserManager<ApplicationUser> userManager,
                                     SignInManager<ApplicationUser> signInManager,
                                     ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    // Você pode adicionar outras claims aqui, como roles ou IDs
                };

                return _tokenService.GenerateToken(email, claims);
            }

            return null; // Retorna null se a autenticação falhar
        }

        // Os outros métodos (RegisterUserAsync, Logout) permanecem os mesmos
        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            var applicationUser = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(applicationUser, password);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

