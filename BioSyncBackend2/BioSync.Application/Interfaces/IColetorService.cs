using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IColetorService
    {
        Task<IEnumerable<ColetorResponseDTO>> GetAllAsync();
        Task<ColetorResponseDTO> GetByIdAsync(int id);
        Task<ColetorResponseDTO> CreateAsync(ColetorRequestDTO coletorDto);
        Task<bool> UpdateAsync(int id, ColetorRequestDTO coletorDto);
        Task<bool> DeleteAsync(int id);
    }
}
