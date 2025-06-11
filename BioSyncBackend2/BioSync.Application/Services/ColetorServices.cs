using AutoMapper;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities; // Supondo que a entidade Coletor exista
using BioSync.Domain.Interfaces; // Supondo que IColetorRepository exista
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Services
{
    public class ColetorService : IColetorService
    {
        private readonly IColetorRepository _coletorRepository;
        private readonly IMapper _mapper;

        public ColetorService(IColetorRepository coletorRepository, IMapper mapper)
        {
            _coletorRepository = coletorRepository;
            _mapper = mapper;
        }

        public async Task<ColetorResponseDTO> CreateAsync(ColetorRequestDTO coletorDto)
        {
            var coletor = _mapper.Map<Coletor>(coletorDto);
            var createdColetor = await _coletorRepository.Create(coletor);
            return _mapper.Map<ColetorResponseDTO>(createdColetor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var coletor = await _coletorRepository.GetById(id);
            if (coletor == null) return false;

            await _coletorRepository.Delete(coletor);
            return true;
        }

        public async Task<IEnumerable<ColetorResponseDTO>> GetAllAsync()
        {
            var coletores = await _coletorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ColetorResponseDTO>>(coletores);
        }

        public async Task<ColetorResponseDTO> GetByIdAsync(int id)
        {
            var coletor = await _coletorRepository.GetById(id);
            return _mapper.Map<ColetorResponseDTO>(coletor);
        }

        public async Task<bool> UpdateAsync(int id, ColetorRequestDTO coletorDto)
        {
            var coletor = await _coletorRepository.GetById(id);
            if (coletor == null) return false;

            _mapper.Map(coletorDto, coletor);
            await _coletorRepository.Update(coletor);
            return true;
        }
    }
}