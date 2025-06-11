using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioSync.Domain.Account
{
    public interface IAuthenticate
    {
        // Alterado de Task<bool> para Task<string>
        Task<string> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
