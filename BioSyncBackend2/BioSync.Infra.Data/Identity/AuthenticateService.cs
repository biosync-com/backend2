using BioSync.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticateService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                var roles = await _userManager.GetRolesAsync(user);

                return _tokenService.GenerateToken(user.Id, user.Email, roles);
            }

            return null;
        }

        public async Task<IdentityResult> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Senha = password
               
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                // Por padrão, adiciona o novo usuário ao papel "User".
                // Garanta que este papel exista no seu banco de dados.
                await _userManager.AddToRoleAsync(applicationUser, "User");
            }

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        Task<bool> IAuthenticate.RegisterUser(string email, string password)
        {
            this.RegisterUser(email, password);

            return Task.FromResult(true);
        }
    }
}