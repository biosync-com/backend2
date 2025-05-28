using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IPontoDescarteRepository
    {
        Task<IEnumerable<PontoDescarte>> GetAllAsync();
        Task<PontoDescarte> GetById(int id);
        Task<PontoDescarte> Create(PontoDescarte pontoDescarte);
        Task<PontoDescarte> Update(PontoDescarte pontoDescarte);
        Task<PontoDescarte> Delete(PontoDescarte pontoDescarte);
    }
}
