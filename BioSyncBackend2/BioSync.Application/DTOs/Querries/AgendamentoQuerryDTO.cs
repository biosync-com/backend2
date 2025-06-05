using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Querries
{
    public class AgendamentoQuerryDTO
    {
        public int Id { get; set; }
        public List<string> ColetorNome { get; set; }
        public string Email { get; set; }
        public DateTime DataHora { get; set; }
        public List<string> Material { get; set; }
        public string UsuarioNome { get; set; }
        public bool Ativo { get; set; }

        public AgendamentoQuerryDTO()
        {
            Id = 0;
            ColetorNome = new List<string>();
            Email = string.Empty;
            DataHora = DateTime.Now;
            Material = new List<string>();
            UsuarioNome = string.Empty;
            Ativo = true;
        }
    }
}
