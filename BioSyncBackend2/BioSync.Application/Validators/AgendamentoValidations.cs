using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using FluentAssertions; 
using BioSync.Domain.Validation;
using FluentValidation;

namespace BioSync.Application.Validators
{
    public class AgendamentoValidations
    {
        public AgendamentoValidations(Agendamento agendamento, Coletor coletor, Usuario usuario, PontoDescarte pontoDescarte)
        {
           if (agendamento == null)
            {
                throw new ArgumentNullException(nameof(agendamento), "O agendamento não pode ser nulo.");
            }
            if (agendamento.Data.Day == default) 
            {
                throw new ArgumentException("O dia do agendamento não pode ser inválido.");
            }
            if (agendamento.Data.Month == default) 
            {
                throw new ArgumentException("O mês do agendamento não pode ser inválido.");
            }
            if (agendamento.Data.Year == default) 
            {
                throw new ArgumentException("O ano do agendamento não pode ser inválido.");
            }
            if (agendamento.Data == default || agendamento.Data < DateOnly.FromDateTime(DateTime.Now)) // Verifica se a data é inválida ou no passado
            {
                throw new ArgumentException("A data do agendamento não pode ser inválida.");
            }
            if (agendamento.Hora == default)
            {
                throw new ArgumentException("A hora do agendamento não pode ser inválida.");
            }
            //if (agendamento.Hora < TimeOnly.FromDateTime(DateTime.Now.TimeOfDay)) // Verifica se a hora é inválida ou no passado
            //{
            //    throw new ArgumentException("A hora do agendamento não pode ser inválida.");
            //}
            if (agendamento.Coletor == null)
            {
                throw new ArgumentException("O coletor do agendamento não pode ser nulo.");
            }
            if (agendamento.Material == null)
            {
                throw new ArgumentException("O material do agendamento não pode ser nulo.");
            }
            if (agendamento.Usuario == null)
            {
                throw new ArgumentException("O usuário do agendamento não pode ser nulo.");
            }
        }
    }
}
