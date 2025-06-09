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
    public class MaterialRepository
    {
        private ApplicationDbContext _context;
        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Material> GetMaterialByIdAsync(int id)
        {
            return await _context.Materiais.FindAsync(id);
        }
        public async Task<List<Material>> GetAllMateriaisAsync()
        {
            return await _context.Materiais.ToListAsync();
        }
        public async Task AddMaterialAsync(Material material)
        {
            await _context.Materiais.AddAsync(material);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMaterialAsync(Material material)
        {
            _context.Materiais.Update(material);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMaterialAsync(int id)
        {
            var material = await _context.Materiais.FindAsync(id);
            if (material != null)
            {
                _context.Materiais.Remove(material);
                await _context.SaveChangesAsync();
            }
        }
    }
}
