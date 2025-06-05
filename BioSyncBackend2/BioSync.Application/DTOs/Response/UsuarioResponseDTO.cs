using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Response
{
    public class UsuarioResponseDTO
    {
        public class UsuarioResponseDTOs
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Email { get; set; }
            public DateTime DataCadastro { get; set; }
            public bool Ativo { get; set; }
        }
    }
}
