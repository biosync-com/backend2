using BioSync.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAll();
        Task<MaterialDTO> GetById(int? id);
        Task Add(MaterialDTO materialDto);
        Task Update(MaterialDTO materialDto);
        Task Remove(int? id);
    }
}