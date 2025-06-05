using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Querries
{
    public class PontoDescarteQuerryDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Material { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public PontoDescarteQuerryDTO()
        {
            Id = 0;
            Nome = string.Empty;
            Endereco = string.Empty;
            Email = string.Empty;
            Material = string.Empty;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }
    }
}
