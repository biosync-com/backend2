using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IUsuario
    {
        int Id { get; set; }
        string Nome { get; set; }
        string CPF { get; set; }
        string Email { get; set; }
        DateTime DataCadastro { get; set; }
        bool Ativo { get; set; }
      
        void Ativar();
        void Desativar();
        void AtualizarInformacoes(string nome, string email);
    }
}
