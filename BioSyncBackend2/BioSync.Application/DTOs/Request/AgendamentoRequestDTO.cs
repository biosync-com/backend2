using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSync.Application.DTOs.Request
{
    public class AgendamentoRequestDTO
    {

        [Required (ErrorMessage ="A data é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida.")]
        [Display(Name = "Data do Agendamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "Informe uma data válida no formato dd/MM/yyyy.")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "A hora é obrigatória")]
        [DataType(DataType.Time, ErrorMessage = "Informe uma hora válida.")]
        [Display(Name = "Hora do Agendamento")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^([01]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "Informe uma hora válida no formato HH:mm.")]
        public TimeOnly Hora { get; set; }

        [Required(ErrorMessage = "O coletor é obrigatório.")]
        [Display(Name = "Coletor")]
        [MaxLength(100, ErrorMessage = "O nome do coletor deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O nome do coletor deve conter apenas letras, números e espaços.")]
        public TimeOnly Time { get; set; }

        [Required(ErrorMessage = "O coletor é obrigatório.")]
        [Display(Name = "Coletor")]
        [MaxLength(100, ErrorMessage = "O nome do coletor deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O nome do coletor deve conter apenas letras, números e espaços.")]
        public int ColetorId { get; set; }

        [Required(ErrorMessage = "O material é obrigatório.")]
        [Display(Name = "Material")]
        [MaxLength(100, ErrorMessage = "O nome do material deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O nome do material deve conter apenas letras, números e espaços.")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        [MaxLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "O nome do usuário deve conter apenas letras, números e espaços.")]
        public int UsuarioId { get; set; }
    }
}
