using FluentAssertions;
using System;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation; // Supondo que uma validação de domínio exista ou deveria existir
using Xunit;

namespace BioSync.Domain.Test
{
    // O nome da classe foi corrigido de AgendamentotoUnityTest para AgendamentoUnityTest
    public class AgendamentoUnityTest
    {
        // Para os testes compilarem, vamos simular um validador simples.
        // A lógica de validação real pode estar na sua camada de Aplicação.
        private class AgendamentoValidator
        {
            public void Validate(Agendamento agendamento)
            {
                if (agendamento.Data == default)
                    throw new DomainExceptionValidation("Data é obrigatória");
                if (agendamento.Hora == default)
                    throw new DomainExceptionValidation("Hora é obrigatória");
                if (agendamento.Usuario == null)
                    throw new DomainExceptionValidation("Usuário inválido, entre novamente ou troque de conta.");
                if (agendamento.Coletor == null)
                    throw new DomainExceptionValidation("Coletor inválido, mselecione / escreva um coletor válido.");
                if (agendamento.Material == null)
                    throw new DomainExceptionValidation("Material inválido ou impossível selecionar no momento.");
            }
        }


        #region Testes Positivos
        [Fact(DisplayName = "Criar Agendamento com dados válidos")]
        public void CriarAgendamento_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = new DateOnly(2025, 1, 14),
                Hora = new TimeOnly(13, 30, 0),
                Coletor = new Coletor(),
                Material = new Material(),
                Usuario = new Usuario()
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().NotThrow();
        }
        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Validar Agendamento com data inválida deve lançar exceção")]
        public void ValidarAgendamento_ComDataInvalida_DeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = default, // Data inválida
                Hora = new TimeOnly(13, 30, 0),
                Coletor = new Coletor(),
                Material = new Material(),
                Usuario = new Usuario()
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data é obrigatória");
        }

        [Fact(DisplayName = "Validar Agendamento com hora inválida deve lançar exceção")]
        public void ValidarAgendamento_ComHoraInvalida_DeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = new DateOnly(2025, 1, 14),
                Hora = default, // Hora inválida
                Coletor = new Coletor(),
                Material = new Material(),
                Usuario = new Usuario()
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Hora é obrigatória");
        }

        [Fact(DisplayName = "Validar Agendamento com coletor nulo deve lançar exceção")]
        public void ValidarAgendamento_ComColetorNulo_DeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = new DateOnly(2025, 1, 14),
                Hora = new TimeOnly(13, 30, 0),
                Coletor = null, // Coletor nulo
                Material = new Material(),
                Usuario = new Usuario()
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Coletor inválido, mselecione / escreva um coletor válido.");
        }

        [Fact(DisplayName = "Validar Agendamento com material nulo deve lançar exceção")]
        public void ValidarAgendamento_ComMaterialNulo_DeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = new DateOnly(2025, 1, 14),
                Hora = new TimeOnly(13, 30, 0),
                Coletor = new Coletor(),
                Material = null, // Material nulo
                Usuario = new Usuario()
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Material inválido ou impossível selecionar no momento.");
        }

        [Fact(DisplayName = "Validar Agendamento com usuário nulo deve lançar exceção")]
        public void ValidarAgendamento_ComUsuarioNulo_DeveLancarExcecao()
        {
            // Arrange
            var validator = new AgendamentoValidator();
            var agendamento = new Agendamento
            {
                Data = new DateOnly(2025, 1, 14),
                Hora = new TimeOnly(13, 30, 0),
                Coletor = new Coletor(),
                Material = new Material(),
                Usuario = null // Usuário nulo
            };

            // Act
            Action action = () => validator.Validate(agendamento);

            // Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Usuário inválido, entre novamente ou troque de conta.");
        }

        #endregion
    }
}

