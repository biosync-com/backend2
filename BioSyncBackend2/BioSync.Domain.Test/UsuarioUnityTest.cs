using System;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Test
{
    public class UsuarioUnityTest // Removi uma classe aninhada desnecessária
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar Usuario com dados válidos")]
        public void CriarUsuario_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Maria",
                CPF = "123.456.789-01",
                Email = "maria@email.com",
                Senha = "senha1234"
            };
            var validator = new UsuarioValidaton();

            // Act
            Action action = () => validator.Validate(usuario);

            // Assert
            action.Should().NotThrow();
        }

        /*
            Os testes abaixo foram removidos porque as funcionalidades
            'EmailVerificado' e 'VerificarEmail()' não existem mais na entidade Usuario.

            [Fact(DisplayName = "Criar Usuario deve definir email como não verificado")]
            public void CriarUsuario_EmailVerificado_DeveSerFalso() { }

            [Fact(DisplayName = "Verificar email deve mudar status")]
            public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue() { }
        */

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Validar Usuario com nome nulo deve lançar exceção")]
        public void ValidarUsuario_ComNomeNulo_DeveLancarExcecao()
        {
            // Arrange
            var usuario = new Usuario { Nome = null, CPF = "12345678901", Email = "email@email.com", Senha = "senha1234" };
            var validator = new UsuarioValidaton();

            // Act
            Action action = () => validator.Validate(usuario);

            // Assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage("Nome do usuário não pode ser vazio. (Parameter 'Nome')");
        }

        [Fact(DisplayName = "Validar Usuario com nome vazio deve lançar exceção")]
        public void ValidarUsuario_ComNomeVazio_DeveLancarExcecao()
        {
            // Arrange
            var usuario = new Usuario { Nome = "", CPF = "12345678901", Email = "email@email.com", Senha = "senha1234" };
            var validator = new UsuarioValidaton();

            // Act
            Action action = () => validator.Validate(usuario);

            // Assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage("Nome do usuário não pode ser vazio. (Parameter 'Nome')");
        }


        [Fact(DisplayName = "Validar Usuario com email nulo deve lançar exceção")]
        public void ValidarUsuario_ComEmailNulo_DeveLancarExcecao()
        {
            // Arrange
            var usuario = new Usuario { Nome = "Fernanda", CPF = "12345678901", Email = null, Senha = "senha1234" };
            var validator = new UsuarioValidaton();

            // Act
            Action action = () => validator.Validate(usuario);

            // Assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage("Email do usuário não pode ser vazio. (Parameter 'Email')");
        }

        [Fact(DisplayName = "Validar Usuario com senha muito curta deve lançar exceção")]
        public void ValidarUsuario_ComSenhaCurta_DeveLancarExcecao()
        {
            // Arrange
            var usuario = new Usuario { Nome = "João", CPF = "12345678901", Email = "joao@email.com", Senha = "123" };
            var validator = new UsuarioValidaton();

            // Act
            Action action = () => validator.Validate(usuario);

            // Assert
            action.Should().Throw<ArgumentException>()
                  .WithMessage("Senha do usuário deve ter pelo menos 6 caracteres. (Parameter 'Senha')");
        }

        #endregion
    }
}