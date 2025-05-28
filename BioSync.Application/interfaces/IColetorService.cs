using BioSync.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IColetorService
    {
        Task<IEnumerable<ColetorDTO>> GetAll();
        Task<ColetorDTO> GetById(int? id);
        Task Add(ColetorDTO coletorDto);
        Task Update(ColetorDTO coletorDto);
        Task Remove(int? id);
    }
}