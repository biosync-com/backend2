using AutoMapper;
using BioSync.Application.DTOs.Request;
using BioSync.Application.DTOs.Response;
using BioSync.Application.Interfaces;
using BioSync.Domain.Account;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{    
        public class UsuarioService : IUsuarioService
        {
            private readonly IUsuarioRepository _usuarioRepository;
            private readonly IAuthenticate _authentication;
            private readonly IMapper _mapper;

            public UsuarioService(IUsuarioRepository usuarioRepository, IAuthenticate authentication, IMapper mapper)
            {
                _usuarioRepository = usuarioRepository;
                _authentication = authentication;
                _mapper = mapper;
            }

            public async Task<UsuarioResponseDTO> CreateAsync(UsuarioRequestDTO usuarioDto)
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                // 1. Criar o usuário no sistema de autenticação (Identity)
                var result = await _authentication.RegisterUser(usuario.Email, usuarioDto.Senha);
                if (!result)
                {
                    throw new System.Exception("Não foi possível registrar o usuário de autenticação.");
                }

                // 2. Criar o usuário na tabela de domínio
                var createdUsuario = await _usuarioRepository.Create(usuario);
                return _mapper.Map<UsuarioResponseDTO>(createdUsuario);
            }

            public async Task<UsuarioResponseDTO> GetByIdAsync(int id)
            {
                var usuario = await _usuarioRepository.GetById(id);
                return _mapper.Map<UsuarioResponseDTO>(usuario);
            }
        }
    }