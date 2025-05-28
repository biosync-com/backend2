using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(Usuario usuario);
    }
}
