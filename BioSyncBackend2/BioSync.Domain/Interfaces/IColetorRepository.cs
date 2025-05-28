using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IColetorRepository
    {
        Task<IEnumerable<Coletor>> GetAllAsync();
        Task<Usuario> GetByEmailAsync(string email);
        Task<Coletor> GetById(int id);
        Task<Coletor> Create(Coletor coletor);
        Task<Coletor> Update(Coletor coletor);
        Task<Coletor> Delete(Coletor coletor);
    }
}
