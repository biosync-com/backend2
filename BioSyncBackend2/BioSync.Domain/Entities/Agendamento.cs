using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Domain.Entities
{
    public class Agendamento
    {
        public DateOnly Data { get; set; }

        public TimeOnly Hora { get; set; }


    }
}
