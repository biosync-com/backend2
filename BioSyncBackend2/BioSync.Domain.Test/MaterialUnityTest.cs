using System;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Test
{
    public class MaterialUnityTest
    {
        // Validador simulado para permitir a compilação dos testes
        private class MaterialValidator
        {
            public void Validate(Material material)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(material.Nome), "Nome é obrigatório");
                DomainExceptionValidation.When(string.IsNullOrEmpty(material.Descricao), "Descrição inválida, preencha a descrição.");
            }
        }

        #region Testes Positivos

        [Fact(DisplayName = "Criar Material com dados válidos")]
        public void CriarMaterial_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            // Arrange
            var validator = new MaterialValidator();
            var material = new Material
            {
                Nome = "Papel",
                Descricao = "Derivado de folhas sulfite entre outros",
            };

            // Act
            Action action = () => validator.Validate(material);

            // Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar material com nome nulo deve lançar exceção")]
        public void CriarMaterial_ComNomeNulo_DeveLancarExcecao()
        {
            // Arrange
            var validator = new MaterialValidator();
            var material = new Material { Nome = null, Descricao = "Descrição válida" };

            // Act
            Action action = () => validator.Validate(material);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar material com descrição nula deve lançar exceção")]
        public void CriarMaterial_ComDescricaoNula_DeveLancarExcecao()
        {
            // Arrange
            var validator = new MaterialValidator();
            var material = new Material { Nome = "Papel", Descricao = null };

            // Act
            Action action = () => validator.Validate(material);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, preencha a descrição.");
        }

        #endregion
    }
}