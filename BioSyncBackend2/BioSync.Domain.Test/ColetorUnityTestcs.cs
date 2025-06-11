using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BioSync.Domain.Test
{
    internal class ColetorUnityTest
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar Usuario com dados válidos")]
        public void CriarColetor_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Maria",
                cpf: "12345678901",
                email: "maria@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Coletor deve definir email como não verificado")]
        public void CriarColetor_EmailVerificado_DeveSerFalso()
        {
            var coletor = new Coletor(
                "Fernanda",
                "12345678901",
                "fernanda@email.com",
                "senha12345"
                );
            //TipoUsuario.Comum);

            coletor.EmailVerificado.Should().BeFalse();
        }

        [Fact(DisplayName = "Verificar email deve mudar status")]
        public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
        {
            var coletor = new Coletor(
                "Fernanda",
                "12345678901",
                "fernanda@email.com",
                "senha12345"
                );
            //TipoUsuario.Comum

            coletor.VerificarEmail();
            coletor.EmailVerificado.Should().BeTrue();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComNomeNulo_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: null,
                cpf: "12345678901",
                email: "email@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com CPF nulo deve lançar exceção")]
        public void CriarColetor_ComCPFNulo_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: null,
                email: "email@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComEmailNulo_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: null,
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("E-mail é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComSenhaNulo_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: "email@email.com",
                senha: null,
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Senha é obrigatória");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComSenhaNulo_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: "email@email.com",
                senha: "senha1234",
                material: null
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Material é obrigatório");

        }

        [Fact(DisplayName = "Criar Usuario com dados válidos")]
        public void CriarColetor_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Maria",
                cpf: "12345678901",
                email: "maria@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Coletor deve definir email como não verificado")]
        public void CriarColetor_EmailVerificado_DeveSerFalso()
        {
            var coletor = new Coletor(
                "Fernanda",
                "12345678901",
                "fernanda@email.com",
                "senha12345"
                );
            //TipoUsuario.Comum);

            coletor.EmailVerificado.Should().BeFalse();
        }

        [Fact(DisplayName = "Verificar email deve mudar status")]
        public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
        {
            var coletor = new Coletor(
                "Fernanda",
                "12345678901",
                "fernanda@email.com",
                "senha12345"
                );
            //TipoUsuario.Comum

            coletor.VerificarEmail();
            coletor.EmailVerificado.Should().BeTrue();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComNomeVazio_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: null,
                cpf: "12345678901",
                email: "email@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com CPF nulo deve lançar exceção")]
        public void CriarColetor_ComCPFVazio_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "",
                email: "email@email.com",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComEmailVazio_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: "",
                senha: "senha1234",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("E-mail é obrigatório");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComSenhaVazia_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: "email@email.com",
                senha: "",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Senha é obrigatória");
        }

        [Fact(DisplayName = "Criar Coletor com nome nulo deve lançar exceção")]
        public void CriarColetor_ComSenhaVazio_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "Fernanda",
                cpf: "1234567890",
                email: "email@email.com",
                senha: "senha1234",
                material: ""
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Material é obrigatório");

        }

        [Fact(DisplayName = "Criar Coletor com senha muito curta deve lançar exceção")]
        public void CriarColetor_ComSenhaCurta_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                nome: "João",
                cpf: "12345678901",
                email: "joao@email.com",
                senha: "123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Senha inválida, mínimo 8 caracteres.");
        }

        #endregion
    }
}
}
