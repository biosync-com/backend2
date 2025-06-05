using System;
using System.Collections.Generic;
using System.Linq;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;


namespace BioSync.Domain.Test
{
    public class UsuarioTest
    {
        public class UsuarioUnityTest
        {

            #region Testes Positivos

            [Fact(DisplayName = "Criar Usuario com dados válidos")]
            public void CriarUsuario_ComParametrosValidos_NaoDeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "Maria",
                    cpf: "12345678901",
                    email: "maria@email.com",
                    senha: "senha1234",
                    //tipo: TipoUsuario.Comum);

                action.Should().NotThrow<DomainExceptionValidation>();
            }

            [Fact(DisplayName = "Criar Usuario deve definir email como não verificado")]
            public void CriarUsuario_EmailVerificado_DeveSerFalso()
            {
                var usuario = new Usuario(
                    "Carlos",
                    "12345678901",
                    "carlos@email.com",
                    "senha12345",
                    //TipoUsuario.Comum);

                usuario.EmailVerificado.Should().BeFalse();
            }

            [Fact(DisplayName = "Verificar email deve mudar status")]
            public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
            {
                var usuario = new Usuario(
                    "Fernanda",
                    "12345678901",
                    "fernanda@email.com",
                    "senha12345",
                    //TipoUsuario.Comum);

                usuario.VerificarEmail();
                usuario.EmailVerificado.Should().BeTrue();
            }

            #endregion

            #region Testes Negativos

            [Fact(DisplayName = "Criar Usuario com nome nulo deve lançar exceção")]
            public void CriarUsuario_ComNomeNulo_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: null,
                    cpf: "12345678901",
                    email: "email@email.com",
                    senha: "senha1234",
                    //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("Nome é obrigatório");
            }

            public void CriarUsuario_ComCPFNulo_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "Fernanda",
                    cpf: null,
                    email: "email@email.com",
                    senha: "senha1234",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("CPF é obrigatório");
            }

            public void CriarUsuario_ComEmailNulo_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "Fernanda",
                    cpf: "12345678901",
                    email: null,
                    senha: "senha1234",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("E-mail é obrigatório");
            }

            [Fact(DisplayName = "Criar Usuario com senha muito curta deve lançar exceção")]
            public void CriarUsuario_ComSenhaNula_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "João",
                    cpf: "12345678901",
                    email: "joao@email.com",
                    senha: null,
                    //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("Senha inválida, digite a senha.");
            }

            [Fact(DisplayName = "Criar Usuario com nome nulo deve lançar exceção")]
            public void CriarUsuario_ComNomeVazio_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: null,
                    cpf: "12345678901",
                    email: "email@email.com",
                    senha: "senha1234",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("Nome é obrigatório");
            }

            public void CriarUsuario_ComCPFvazio_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "Fernanda",
                    cpf: null,
                    email: "email@email.com",
                    senha: "senha1234",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("CPF é obrigatório");
            }

            public void CriarUsuario_ComEmailVazio_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "Fernanda",
                    cpf: "12345678901",
                    email: "",
                    senha: "senha1234",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("E-mail é obrigatório");
            }

            [Fact(DisplayName = "Criar Usuario com senha muito curta deve lançar exceção")]
            public void CriarUsuario_ComSenhaVazia_DeveLancarExcecao()
            {
                Action action = () => new Usuario(
                    nome: "João",
                    cpf: "12345678901",
                    email: "joao@email.com",
                    senha: "",
                //tipo: TipoUsuario.Comum);

                action.Should().Throw<DomainExceptionValidation>()
                    .WithMessage("Senha inválida, digite a senha.");
            }

            #endregion
        }
    }
}
