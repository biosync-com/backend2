using BioSync.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoDTO>> GetAll();
        Task<AgendamentoDTO> GetById(int? id);
        Task Add(AgendamentoDTO agendamentoDto);
        Task Update(AgendamentoDTO agendamentoDto);
        Task Remove(int? id);
    }
}