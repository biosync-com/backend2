using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Domain.Entities
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
