using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Password { get; set; }
    }
}