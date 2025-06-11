using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IPontoDescarteService
    {
        Task<IEnumerable<PontoDescarteResponseDTO>> GetAllAsync();
        Task<PontoDescarteResponseDTO> GetByIdAsync(int id);
        Task<PontoDescarteResponseDTO> CreateAsync(PontoDescarteRequestDTO pontoDescarteDto);
        Task<bool> UpdateAsync(int id, PontoDescarteRequestDTO pontoDescarteDto);
        Task<bool> DeleteAsync(int id);
    }
}
