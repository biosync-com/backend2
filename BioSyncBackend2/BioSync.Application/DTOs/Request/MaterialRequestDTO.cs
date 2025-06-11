using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Request
{
    public class MaterialRequestDTO
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O Nome deve conter apenas letras, números e espaços.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um Nome válido.")]
        [Display(Name = "Nome do Material")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "A descrição deve conter apenas letras, números e espaços.")]
        [DataType(DataType.Text, ErrorMessage = "Informe uma descrição válida.")]
        [Display(Name = "Descrição do Material")]
        public string Descricao { get; set; }

    }
}
