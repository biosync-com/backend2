using System;
using System.Collections.Generic;
using System.Linq;
using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Domain.Test
{
    class MaeterialUnityTest
	{
		#region Testes Positivos

		[Fact(DisplayName = "Criar Material com dados válidos")]
		public void CriarUsuario_ComParametrosValidos_NaoDeveLancarExcecao()
		{
			Action action = () => new Material(
				nome: "Papeel",
				descricao: "Derivado de folhas sulfite entre outros",
				);
			//tipo: TipoUsuario.Comum);

			action.Should().NotThrow<DomainExceptionValidation>();
		}

		[Fact(DisplayName = "Criar Material deve definir nome como não verificado")]
		public void CriarMaterial_EmaNomeVerificado_DeveSerFalso()
		{
			var material = new Material(
				nome: "Papel",
				descricao: "Derivado de folhas sulfite entre outros",
				);
			//TipoUsuario.Comum);

			material.NomelVerificado.Should().BeFalse();
		}

		[Fact(DisplayName = "Verificar nome deve mudar status")]
		public void VerificarNome_DeveAlterarEmailVerificadoParaTrue()
		{
			var material = new Material(
				nome: "Papel",
				descricao: "Derivado de folhas sulfite entre outros",
				);
			//TipoUsuario.Comum

			material.VerificarNome();
			material.NomeVerificado.Should().BeTrue();
		}

		#endregion

		#region Testes Negativos

		[Fact(DisplayName = "Criar material com nome nulo deve lançar exceção")]
		public void CriarMaterial_ComNomeNulo_DeveLancarExcecao()
		{
			Action action = () => new Coletor(
				nome: null,
				descricao: "Derivado de folhas sulfite entre outros",
				);
			//tipo: TipoUsuario.Comum);

			action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
		}

		[Fact(DisplayName = "Criar material com descrição muito curta deve lançar exceção")]
		public void CriarMaterial_ComdescricaoNula_DeveLancarExcecao()
		{
			Action action = () => new Coletor(
				nome: "Papel",
				descricao: null,
				);
			//tipo: TipoUsuario.Comum);

			action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, preencha a descrição.");
		}

		[Fact(DisplayName = "Criar material com nome nulo deve lançar exceção")]
		public void CriarMaterial_ComNomeVazio_DeveLancarExcecao()
		{
			Action action = () => new Coletor(
				nome: "",
				descricao: "Derivado de folhas sulfite entre outros",
				);
			//tipo: TipoUsuario.Comum);

			action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
		}

		[Fact(DisplayName = "Criar material com descrição muito curta deve lançar exceção")]
		public void CriarMaterial_ComdescricaoVazia_DeveLancarExcecao()
		{
			Action action = () => new Coletor(
				nome: "Papel",
				descricao: "",
				);
			//tipo: TipoUsuario.Comum);

			action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, preenha a descrição.");
		}

		#endregion
	}
}
}
