using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllAsync();
        Task<Material> GetById(int id);
        Task<Material> Create(Material material);
        Task<Material> Update(Material material);
        Task<Material> Delete(Material material);
    }
}
