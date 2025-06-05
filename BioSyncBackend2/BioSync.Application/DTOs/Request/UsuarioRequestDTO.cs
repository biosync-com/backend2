using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Request
{
    public class UsuarioRequestDTO
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "O Nome deve conter apenas letras e espaços.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um Nome válido.")]
        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe um CPF válido.")]
        [MaxLength(14, ErrorMessage = "O CPF deve ter no máximo 14 caracteres.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um CPF válido.")]
        [Display(Name = "CPF do Usuário")]
        public string CPF { get; set; } 

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um Email válido.")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um Email válido.")]
        [Display(Name = "Email do Usuário")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Informe um Email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(30, ErrorMessage = "A Senha deve ter no máximo 100 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "Informe uma senha válida.")]
        [Display(Name = "Senha do Usuário")]
        public string Senha { get; set; }
    }
}
