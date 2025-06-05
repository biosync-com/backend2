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
    internal class PontoDescarteUnityTest
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar ponto de Descarte com dados válidos")]
        public void CriarPontoDescatre_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Pontodescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Ponto de Descarte deve definir email como não verificado")]
        public void CriarUsuario_EmailVerificado_DeveSerFalso()
        {
            var pontoDescarte = new PontoDescarte(
                nome: "Paper Colecta",
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //TipoUsuario.Comum);

            pontoDescarte.EmailVerificado.Should().BeFalse();
        }

        [Fact(DisplayName = "Verificar email deve mudar status")]
        public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
        {
            var pontoDescarte = new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //TipoUsuario.Comum);

            pontoDescarte.VerificarEmail();
            pontoDescarte.EmailVerificado.Should().BeTrue();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Ponto de Descarte com nome nulo deve lançar exceção")]
        public void CriarPontodescarte_ComNomeNulo_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: null,
                cnpj: "12345678901",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com CNPJ nulo deve lançar exceção")]
        public void CriarUsuario_ComCNPJNulo_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: null,
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("CNPJ é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com e-mail nulo deve lançar exceção")]
        public void CriarPontoDescarte_ComEmailNulo_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: null,
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("E-mail é obrigatório");
        }

        public void CriarPontoDescarte_ComSenhaNula_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: null,
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Senha é obrigatória");
        }

        public void CriarPontoDescarte_EnderecoNulo_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: "senha1234",
                endereco: null,
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Endereço é obrigatório");
        }

        public void CriarPontoDescarte_MaterialNulo_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: null
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Material é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com nome nulo deve lançar exceção")]
        public void CriarPontodescarte_ComNomeVazio_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "",
                cnpj: "12345678901",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com CNPJ nulo deve lançar exceção")]
        public void CriarUsuario_ComCNPJVazio_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "",
                email: "pappercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("CNPJ é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com e-mail nulo deve lançar exceção")]
        public void CriarPontoDescarte_ComEmailVazio_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("E-mail é obrigatório");
        }

        public void CriarPontoDescarte_ComSenhaVazia_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: "",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Senha é obrigatório");
        }

        public void CriarPontoDescarte_EnderecoVazio_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: "senha1234",
                endereco: "",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Endereço é obrigatório");
        }

        public void CriarPontoDescarte_MaterialVazio_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "Paper Colecta",
                cnpj: "12345678000199",
                email: "papercolecta@email.com",
                senha: "senha1234",
                endereco: "Rua A, 123",
                material: ""
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Material é obrigatório");
        }

        [Fact(DisplayName = "Criar Usuario com senha muito curta deve lançar exceção")]
        public void CriarUsuario_ComSenhaCurta_DeveLancarExcecao()
        {
            Action action = () => new Usuario(
                nome: "Paper Colecta",
                cnpj: "12345678901",
                email: "pappercolecta@email.com",
                senha: "se",
                endereco: "Rua A, 123",
                material: "Papel"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Senha inválida, mínimo 8 caracteres.");
        }

        #endregion
    }
}
}
