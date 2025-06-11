using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IMaterialService
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
