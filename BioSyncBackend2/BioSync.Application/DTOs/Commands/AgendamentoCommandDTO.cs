using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Commands
{
    public class AgendamentoCommandDTO
    {
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Guid> Id { get; set; }
        public ColetorCommandDTO Coletor { get; set; }
        public List<string> Materiais { get; set; }
        public PontoDescarteCommandDTO PontoDescarte { get; set; }
        public UsuarioCommandDTO Usuario { get; set; }

        public AgendamentoCommandDTO()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
            Id = new List<Guid> { Guid.NewGuid() };
            Coletor = new ColetorCommandDTO();
            Materiais = new List<string>();
            PontoDescarte = new PontoDescarteCommandDTO();
            Usuario = new UsuarioCommandDTO();
        }
    }
            
}
