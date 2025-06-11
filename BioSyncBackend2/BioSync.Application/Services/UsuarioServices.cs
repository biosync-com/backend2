using AutoMapper;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Application.DTOs;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class UsuarioServices : IUsuarioService, IUsuarioServices
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioServices(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CPF { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataCadastro { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Ativo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Ativar(bool Ativo)
        {
            Ativo = true;
            // Aqui você pode adicionar lógica para ativar o usuário no repositório
        }

        public void Ativar()
        {
            throw new NotImplementedException();
        }

        public void AtualizarInformacoes(string nome, string email)
        {
            throw new NotImplementedException();
        }

        public void Desativar(bool Ativo)
        {
            Ativo = false;
            // Aqui você pode adicionar lógica para desativar o usuário no repositório
        }

        public void Desativar()
        {
            throw new NotImplementedException();
        }
    }
