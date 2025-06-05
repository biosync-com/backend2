using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IColetor
    {
        string Nome { get; }
        string CPF { get; }
        string Email { get; }
        string Material { get; }

        void Activate();
        void Deactivate();
        void UpdateInformation(ColetorUpdateDTO updateDto);

        void ChangePassword(string newPassword);
        bool ValidatePassword(string password);

    }
}
