using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace BioSync.Domain.Test
{
    internal class AgendamentotoUnityTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Criar Agendamento com dados válidos")]
        public void CriarUsuario_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Agenamento(
                data: 14/01/2025,
                hora: 13,30 ,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Agendamento deve definir nome como não verificado")]
        public void CriarUsuario_EmailVerificado_DeveSerFalso()
        {
            var agendamento = new Agendamento(
               data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //TipoUsuario.Comum);

            agendamento.NomelVerificado.Should().BeFalse();
        }

        [Fact(DisplayName = "Verificar nome deve mudar status")]
        public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
        {
            var agendamento = new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //TipoUsuario.Comum

            agendamento.VerificarNome();
            agendamento.NomeVerificado.Should().BeTrue();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Agendamento com data nulo deve lançar exceção")]
        public void CriarAgendamento_ComDataNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: null,
                hora: 13,30 ,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data é obrigatória");
        }

        [Fact(DisplayName = "Criar Agendamento com hora nulo deve lançar exceção")]
        public void CrarAgendamentoo_ComDataNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: null,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Hora é obrigatória");
        }

        [Fact(DisplayName = "Criar Agendamento com coletor nulo deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13,30 ,
                coletor: null,
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Coletor inválido, mselecione / escreva um coletor válido.");
        }

        [Fact(DisplayName = "Criar Agendamento com material nulo deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "joão Silva",
                material: null,
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Material inválido ou impossível selecionar no momento.");
        }

        [Fact(DisplayName = "Criar Agendamento com usuário nulo deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "joão Silva",
                material: "Papel",
                usuario: null
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Usuário inválido, entre novamente ou troque de conta.");
        }

        [Fact(DisplayName = "Criar Agendamento com data vazia deve lançar exceção")]
        public void CriarAgendamento_ComDataNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data:"",
                hora: 13, 30,
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data é obrigatória");
        }

        [Fact(DisplayName = "Criar Agendamento com hora vazia deve lançar exceção")]
        public void CrarAgendamentoo_ComDataNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: "",
                coletor: "João Silva",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Hora é obrigatória");
        }

        [Fact(DisplayName = "Criar Agendamento com coletor vazio deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "",
                material: "Papel",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Coletor inválido, mselecione / escreva um coletor válido.");
        }

        [Fact(DisplayName = "Criar Agendamento com com material nulo deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "joão Silva",
                material: "",
                usuario: "Maria Souza"
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Material inválido ou impossível selecionar no momento.");
        }

        [Fact(DisplayName = "Criar Agendamento com usuário vazio deve lançar exceção")]
        public void CriarUsuario_ComColetorNulo_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                data: 14 / 01 / 2025,
                hora: 13, 30,
                coletor: "joão Silva",
                material: "Papel",
                usuario: ""
                );
            //tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Usuário inválido, entre novamente ou troque de conta.");
        }

        #endregion
    }
}
}
