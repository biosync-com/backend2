using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace BioSync.Domain.Test
{
    public class ColetorUnityTest
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar Coletor com dados válidos não deve lançar exceção")]
        public void CriarColetor_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            // Arrange
            var coletor = new Coletor
            {
                Nome = "Maria",
                CPF = "123.456.789-01",
                Email = "maria@email.com",
                Senha = "senhaValida123",
                Material = "Papel"
            };

            // Act
            Action action = () => new ColetorValidation(coletor);

            // Assert
            action.Should().NotThrow();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Coletor com nome vazio deve lançar exceção")]
        public void CriarColetor_ComNomeVazio_DeveLancarExcecao()
        {
            // Arrange
            var coletor = new Coletor { Nome = "", CPF = "123.456.789-01", Email = "email@email.com", Senha = "senha1234", Material = "Papel" };

            // Act
            Action action = () => new ColetorValidation(coletor);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact(DisplayName = "Criar Coletor com senha curta deve lançar exceção")]
        public void CriarColetor_ComSenhaCurta_DeveLancarExcecao()
        {
            // Arrange
            var coletor = new Coletor { Nome = "João", CPF = "12345678901", Email = "joao@email.com", Senha = "123", Material = "Papel" };

            // Act
            Action action = () => new ColetorValidation(coletor);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}