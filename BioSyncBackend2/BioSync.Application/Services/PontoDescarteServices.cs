using AutoMapper;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities; // Supondo que a entidade PontoDescarte exista
using BioSync.Domain.Interfaces; // Supondo que IPontoDescarteRepository exista
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Services
{
    public class PontoDescarteService : IPontoDescarteService
    {
        private readonly IPontoDescarteRepository _pontoDescarteRepository;
        private readonly IMapper _mapper;

        public PontoDescarteService(IPontoDescarteRepository pontoDescarteRepository, IMapper mapper)
        {
            _pontoDescarteRepository = pontoDescarteRepository;
            _mapper = mapper;
        }

        public async Task<PontoDescarteResponseDTO> CreateAsync(PontoDescarteRequestDTO pontoDescarteDto)
        {
            var pontoDescarte = _mapper.Map<PontoDescarte>(pontoDescarteDto);
            var createdPontoDescarte = await _pontoDescarteRepository.Create(pontoDescarte);
            return _mapper.Map<PontoDescarteResponseDTO>(createdPontoDescarte);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pontoDescarte = await _pontoDescarteRepository.GetById(id);
            if (pontoDescarte == null) return false;

            await _pontoDescarteRepository.Delete(pontoDescarte);
            return true;
        }

        public async Task<IEnumerable<PontoDescarteResponseDTO>> GetAllAsync()
        {
            var pontosDescarte = await _pontoDescarteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PontoDescarteResponseDTO>>(pontosDescarte);
        }

        public async Task<PontoDescarteResponseDTO> GetByIdAsync(int id)
        {
            var pontoDescarte = await _pontoDescarteRepository.GetById(id);
            return _mapper.Map<PontoDescarteResponseDTO>(pontoDescarte);
        }

        public async Task<bool> UpdateAsync(int id, PontoDescarteRequestDTO pontoDescarteDto)
        {
            var pontoDescarte = await _pontoDescarteRepository.GetById(id);
            if (pontoDescarte == null) return false;

            _mapper.Map(pontoDescarteDto, pontoDescarte);
            await _pontoDescarteRepository.Update(pontoDescarte);
            return true;
        }
    }
}