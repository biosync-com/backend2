using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Domain.Entities
{
    public class PontoDescarte
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Endereco { get; set; }

        public string Material { get; set;  }
    }
}
