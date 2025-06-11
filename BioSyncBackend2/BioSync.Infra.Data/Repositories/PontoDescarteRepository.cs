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
    public class PontoDescarteRepository
    {
        private ApplicationDbContext _context;
        public PontoDescarteRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<PontoDescarte> GetPontoDescarteByIdAsync(int id)
        {
            return await _context.PontosDescarte.FindAsync(id);
        }
        public async Task<List<PontoDescarte>> GetAllPontosDescarteAsync()
        {
            return await _context.PontosDescarte.ToListAsync();
        }
        public async Task AddPontoDescarteAsync(PontoDescarte pontoDescarte)
        {
            await _context.PontosDescarte.AddAsync(pontoDescarte);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePontoDescarteAsync(PontoDescarte pontoDescarte)
        {
            _context.PontosDescarte.Update(pontoDescarte);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePontoDescarteAsync(int id)
        {
            var pontoDescarte = await _context.PontosDescarte.FindAsync(id);
            if (pontoDescarte != null)
            {
                _context.PontosDescarte.Remove(pontoDescarte);
                await _context.SaveChangesAsync();
            }
        }
    }
}
