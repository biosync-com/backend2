using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Commands
{
    public class PontoDescarteCommandDTO
    {
        public PontoDescarteCommandDTO()
        {
            Materiais = new List<string>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public List<string> Materiais = new List<string>();
    }
}
