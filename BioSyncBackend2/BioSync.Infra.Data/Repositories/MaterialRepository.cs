using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Material> Create(Material material)
        {
            _context.Materiais.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<Material> Delete(Material material)
        {
            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materiais.ToListAsync();
        }

        public async Task<Material> GetById(int id)
        {
            return await _context.Materiais.FindAsync(id);
        }

        public async Task<Material> Update(Material material)
        {
            _context.Entry(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return material;
        }
    }
}