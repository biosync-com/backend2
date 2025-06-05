using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IMaterial
    {
        string Name { get; }
        string Description { get; }
        DateTime RegistrationDate { get; }
        bool IsActive { get; }
        
        void Ativar();
        void Desativar();
        void AtualizarInformacoes(string nome, string descricao);
    }
}
