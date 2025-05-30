﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento> GetById(int id);
        Task<Agendamento> Create(Agendamento agendamento);
        Task<Agendamento> Update(Agendamento agendamento);
        Task<Agendamento> Delete(Agendamento agendamento);
    }
}
