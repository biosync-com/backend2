using BioSync.Domain.Entities;
using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }

        public TimeOnly Hora { get; set; }

        public Coletor Coletor { get; set; }

        public Material Material { get; set; }

        public Usuario Usuario { get; set; }
    }
}
