using BioSync.Application.DTOs.Response;

namespace BioSync.Application.Interfaces
{
    public interface IAgendamento
    {
        int Id { get; }
        string ColetorNome { get; }
        string PontoDescarteNome { get; }
        DateTime DataHora { get; }
        string Material { get; }
        bool IsActive { get; }
        void Activate();
        void Deactivate();
        void UpdateInformation(AgendamentoUpdateDTO updateDto);
        void ChangeDataHora(DateTime newDataHora);
        bool ValidateDataHora(DateTime dataHora);
    }

    public class AgendamentoUpdateDTO
    {
    }
}
