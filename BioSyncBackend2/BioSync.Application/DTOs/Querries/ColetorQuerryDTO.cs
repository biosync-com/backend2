using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Querries
{
    public class ColetorQuerryDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email{ get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo {get; set; }

        public ColetorQuerryDTO()
        {
            Id = 0;
            Nome = string.Empty;
            Email = string.Empty;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        
    }
}
