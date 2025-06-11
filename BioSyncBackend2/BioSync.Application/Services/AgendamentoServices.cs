using AutoMapper;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities; // Supondo que a entidade Agendamento exista
using BioSync.Domain.Interfaces; // Supondo que IAgendamentoRepository exista
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        public async Task<AgendamentoResponseDTO> CreateAsync(AgendamentoRequestDTO agendamentoDto)
        {
            var agendamento = _mapper.Map<Agendamento>(agendamentoDto);
            var createdAgendamento = await _agendamentoRepository.Create(agendamento);
            return _mapper.Map<AgendamentoResponseDTO>(createdAgendamento);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetById(id);
            if (agendamento == null) return false;

            await _agendamentoRepository.Delete(agendamento);
            return true;
        }

        public async Task<IEnumerable<AgendamentoResponseDTO>> GetAllAsync()
        {
            var agendamentos = await _agendamentoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AgendamentoResponseDTO>>(agendamentos);
        }

        public async Task<AgendamentoResponseDTO> GetByIdAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetById(id);
            return _mapper.Map<AgendamentoResponseDTO>(agendamento);
        }

        public async Task<bool> UpdateAsync(int id, AgendamentoRequestDTO agendamentoDto)
        {
            var agendamento = await _agendamentoRepository.GetById(id);
            if (agendamento == null) return false;

            _mapper.Map(agendamentoDto, agendamento);
            await _agendamentoRepository.Update(agendamento);
            return true;
        }
    }
}