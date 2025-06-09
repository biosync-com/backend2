using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using AutoMapper;
using BioSync.Application.DTOs.Response;

namespace BioSync.Application.Mappings
{
    internal class DomainToDTOMappingProfile
    {
        public DomainToDTOMappingProfile() { }
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Agendamento, AgendamentoResponseDTO.AgendamentoResponseDTOs>()
                .ForMember(dest => dest.NomeColetor, opt => opt.MapFrom(src => src.Coletor.Nome))
                .ForMember(dest => dest.NomeMaterial, opt => opt.MapFrom(src => src.Material.Nome))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome));
        }
    }
}
