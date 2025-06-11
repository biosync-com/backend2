
using BioSync.Application.DTOs;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;

namespace BioSync.Application.Interfaces
{
    public interface IUsuarioService
    {
       
            Task<UsuarioResponseDTO> GetByIdAsync(int id);
            Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO usuarioDto);
       
    }
}
