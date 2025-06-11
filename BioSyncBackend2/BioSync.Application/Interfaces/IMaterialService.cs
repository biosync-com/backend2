using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IMaterialService
    {
       
            Task<IEnumerable<MaterialResponseDTO>> GetAllAsync();
            Task<MaterialResponseDTO> GetByIdAsync(int id);
            Task<MaterialResponseDTO> CreateAsync(MaterialRequestDTO materialDto);
            Task<bool> UpdateAsync(int id, MaterialRequestDTO materialDto);
            Task<bool> DeleteAsync(int id);
        
    }
}
