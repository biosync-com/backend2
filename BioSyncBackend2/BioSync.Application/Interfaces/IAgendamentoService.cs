using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoResponseDTO>> GetAllAsync();
        Task<AgendamentoResponseDTO> GetByIdAsync(int id);
        Task<AgendamentoResponseDTO> CreateAsync(AgendamentoRequestDTO agendamentoDto);
        Task<bool> UpdateAsync(int id, AgendamentoRequestDTO agendamentoDto);
        Task<bool> DeleteAsync(int id);
    }
}
