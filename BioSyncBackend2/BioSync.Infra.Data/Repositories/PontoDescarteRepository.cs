using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Repositories
{
    public class PontoDescarteRepository : IPontoDescarteRepository
    {
        private readonly ApplicationDbContext _context;

        public PontoDescarteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PontoDescarte> Create(PontoDescarte pontoDescarte)
        {
            _context.PontosDescarte.Add(pontoDescarte);
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }

        public async Task<PontoDescarte> Delete(PontoDescarte pontoDescarte)
        {
            _context.PontosDescarte.Remove(pontoDescarte);
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }

        public async Task<IEnumerable<PontoDescarte>> GetAllAsync()
        {
            return await _context.PontosDescarte.ToListAsync();
        }

        public async Task<PontoDescarte> GetById(int id)
        {
            return await _context.PontosDescarte.FindAsync(id);
        }

        public async Task<PontoDescarte> Update(PontoDescarte pontoDescarte)
        {
            _context.Entry(pontoDescarte).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }
    }
}