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
    public class AgendamentoRepository
    {
        private ApplicationDbContext _context;
        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Agendamento> GetAgendamentoByIdAsync(int id)
        {
            return await _context.Agendamentos.FindAsync(id);
        }
        public async Task<List<Agendamento>> GetAllAgendamentosAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }
        public async Task AddAgendamentoAsync(Agendamento agendamento)
        {
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAgendamentoAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAgendamentoAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
