using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Querries
{
    public class MaterialQuerryDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
    public MaterialQuerryDTO()
        {
            Id = 0;
            Nome = string.Empty;
            Descricao = string.Empty;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }
    }
}
