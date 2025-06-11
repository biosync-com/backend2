using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Commands
{
    public class MaterialCommandDTO
    {
        public MaterialCommandDTO()
        {
            Id = new List<Guid>();
            Id.Add(Guid.NewGuid());
            Materiais = new List<string>();
        }

        public List<string> Materiais { get; set; } = new List<string>();

        public List<Guid> Id { get; set; }
    }
    
}
