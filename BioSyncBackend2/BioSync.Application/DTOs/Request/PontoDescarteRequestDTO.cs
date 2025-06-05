using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Request
{
    internal class PontoDescarteRequestDTO
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O Nome deve conter apenas letras, números e espaços.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um Nome válido.")]
        [Display(Name = "Nome do Ponto de Descarte")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "Informe um CNPJ válido.")]
        [MaxLength(18, ErrorMessage = "O CNPJ deve ter no máximo 18 caracteres.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um CNPJ válido.")]
        [Display(Name = "CNPJ do Ponto de Descarte")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "Informe um CNPJ válido.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um Email válido.")]
        [MaxLength(255, ErrorMessage = "O Email deve ter no máximo 255 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um Email válido.")]
        [Display(Name = "Email do Ponto de Descarte")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Informe um Email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(30, ErrorMessage = "A Senha deve ter no máximo 100 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "Informe uma senha válida.")]
        [Display(Name = "Senha do Ponto de Descarte")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "A Senha deve conter pelo menos uma letra maiúscula, uma letra minúscula e um número.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O Endereço deve ter no máximo 255 caracteres.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um Endereço válido.")]
        [Display(Name = "Endereço do Ponto de Descarte")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "O Endereço deve conter apenas letras, números, espaços e caracteres especiais (, . -).")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Material é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Material deve ter no máximo 100 caracteres.")]
        [DataType(DataType.Text, ErrorMessage = "Informe um Material válido.")]
        [Display(Name = "Material do Ponto de Descarte")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O Material deve conter apenas letras, números e espaços.")]
        public string Material { get; set; }
    }
}
