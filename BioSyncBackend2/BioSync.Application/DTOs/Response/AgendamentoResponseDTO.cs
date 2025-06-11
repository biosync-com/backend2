using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Response
{
    public class AgendamentoResponseDTO
    {
        public class AgendamentoResponseDTOs
        {
            public int Id { get; set; }
            public DateOnly Data { get; set; }
            public TimeOnly Hora { get; set; }
            public int ColetorId { get; set; }
            public string NomeColetor { get; set; } // Informação adicional para apresentação
            public int MaterialId { get; set; }
            public string NomeMaterial { get; set; } // Informação adicional para apresentação
            public int UsuarioId { get; set; }
            public string NomeUsuario { get; set; } // Informação adicional para apresentação
                                                    // Outras informações relevantes do agendamento
        }
    }
}
