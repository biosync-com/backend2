using Microsoft.AspNetCore.Identity;

namespace BioSync.Infra.Data.Identity

{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }

        public string Senha {  get; set; }
    }
}