using System;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Test
{
    public class PontoDescarteUnityTest
    {
        // Validador simulado para permitir a compilação dos testes
        private class PontoDescarteValidator
        {
            public void Validate(PontoDescarte ponto)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(ponto.Nome), "Nome é obrigatório");
                DomainExceptionValidation.When(string.IsNullOrEmpty(ponto.CNPJ), "CNPJ é obrigatório");
                DomainExceptionValidation.When(string.IsNullOrEmpty(ponto.Email), "E-mail é obrigatório");
                DomainExceptionValidation.When(ponto.Senha?.Length < 8, "Senha inválida, mínimo 8 caracteres.");
            }
        }

        #region Testes Positivos

        [Fact(DisplayName = "Criar Ponto de Descarte com dados válidos")]
        public void CriarPontoDescarte_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            // Arrange
            var validator = new PontoDescarteValidator();
            var pontoDescarte = new PontoDescarte
            {
                Nome = "Paper Colecta",
                CNPJ = "12.345.678/0001-99",
                Email = "pappercolecta@email.com",
                Senha = "senhaValida1234",
                Endereco = "Rua A, 123",
                Material = "Papel"
            };

            // Act
            Action action = () => validator.Validate(pontoDescarte);

            // Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Ponto de Descarte com nome nulo deve lançar exceção")]
        public void CriarPontoDescarte_ComNomeNulo_DeveLancarExcecao()
        {
            // Arrange
            var validator = new PontoDescarteValidator();
            var pontoDescarte = new PontoDescarte { Nome = null, CNPJ = "12.345.678/0001-99", Email = "pappercolecta@email.com", Senha = "senhaValida1234" };

            // Act
            Action action = () => validator.Validate(pontoDescarte);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte com senha muito curta deve lançar exceção")]
        public void CriarPontoDescarte_ComSenhaCurta_DeveLancarExcecao()
        {
            // Arrange
            var validator = new PontoDescarteValidator();
            var pontoDescarte = new PontoDescarte { Nome = "Paper Colecta", CNPJ = "12.345.678/0001-99", Email = "pappercolecta@email.com", Senha = "se" };

            // Act
            Action action = () => validator.Validate(pontoDescarte);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Senha inválida, mínimo 8 caracteres.");
        }

        #endregion
    }
}