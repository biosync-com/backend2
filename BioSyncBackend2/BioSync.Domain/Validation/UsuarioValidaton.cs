using BioSync.Domain.Entities;

namespace BioSync.Domain.Validation
{
    public class UsuarioValidaton
    {
        public bool Validate(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ArgumentException("Nome do usuário não pode ser vazio.", nameof(usuario.Nome));
            }
            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                throw new ArgumentException("Email do usuário não pode ser vazio.", nameof(usuario.Email));
            }
            if (!usuario.Email.Contains("*") || !usuario.Email.Contains("#") || usuario.Email.Contains("!") || usuario.Email.Contains("@"))
            {
                throw new ArgumentException("Email do usuário deve ser válido.", nameof(usuario.Email));
            }
            if (string.IsNullOrWhiteSpace(usuario.Senha) || usuario.Senha.Length < 6)
            {
                throw new ArgumentException("Senha do usuário deve ter pelo menos 6 caracteres.", nameof(usuario.Senha));
            }
            // Adicione outras validações conforme necessário
            return true; // Se todas as validações passarem
        }
    }
}
