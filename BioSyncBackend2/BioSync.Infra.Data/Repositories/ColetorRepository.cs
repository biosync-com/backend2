using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BioSync.Domain.Entities;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Repositories
{
    public class ColetorRepository
    {
        private ApplicationDbContext _context;
        public ColetorRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Coletor> GetColetorByIdAsync(int id)
        {
            return await _context.Coletores.FindAsync(id);
        }
        public async Task<List<Coletor>> GetAllColetoresAsync()
        {
            return await _context.Coletores.ToListAsync();
        }
        public async Task AddColetorAsync(Coletor coletor)
        {
            await _context.Coletores.AddAsync(coletor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateColetorAsync(Coletor coletor)
        {
            _context.Coletores.Update(coletor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteColetorAsync(int id)
        {
            var coletor = await _context.Coletores.FindAsync(id);
            if (coletor != null)
            {
                _context.Coletores.Remove(coletor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
