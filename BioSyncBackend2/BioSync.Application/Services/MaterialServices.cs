using AutoMapper;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities; // Supondo que a entidade Material exista
using BioSync.Domain.Interfaces; // Supondo que IMaterialRepository exista
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<MaterialResponseDTO> CreateAsync(MaterialRequestDTO materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);
            var createdMaterial = await _materialRepository.Create(material);
            return _mapper.Map<MaterialResponseDTO>(createdMaterial);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var material = await _materialRepository.GetById(id);
            if (material == null) return false;

            await _materialRepository.Delete(material);
            return true;
        }

        public async Task<IEnumerable<MaterialResponseDTO>> GetAllAsync()
        {
            var materiais = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialResponseDTO>>(materiais);
        }

        public async Task<MaterialResponseDTO> GetByIdAsync(int id)
        {
            var material = await _materialRepository.GetById(id);
            return _mapper.Map<MaterialResponseDTO>(material);
        }

        public async Task<bool> UpdateAsync(int id, MaterialRequestDTO materialDto)
        {
            var material = await _materialRepository.GetById(id);
            if (material == null) return false;

            _mapper.Map(materialDto, material); // Atualiza o objeto existente com os dados do DTO
            await _materialRepository.Update(material);
            return true;
        }
    }
}