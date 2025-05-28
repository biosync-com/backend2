using BioSync.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IPontoDescarteService
    {
        Task<IEnumerable<PontoDescarteDTO>> GetAll();
        Task<PontoDescarteDTO> GetById(int? id);
        Task Add(PontoDescarteDTO pontoDescarteDto);
        Task Update(PontoDescarteDTO pontoDescarteDto);
        Task Remove(int? id);
    }
}