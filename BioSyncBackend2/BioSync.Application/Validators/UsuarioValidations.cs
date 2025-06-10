using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;

namespace BioSync.Application.Validators
{
    public class UsuarioValidations
    {
        public static void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(usuario.CPF))
            {
                throw new ArgumentException("O CPF do usuário não pode ser vazio.");
            }
            if(usuario.Email != null && usuario.Email.Length > 100)
            {
                throw new ArgumentException("O email do usuário não pode ter mais de 100 caracteres.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Email ))
            {
                throw new ArgumentException("O email do usuário não pode ser vazio ou conter apenas espaços em branco.");
            }
            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new ArgumentException("O email do usuário não pode ser vazio.");
            }
            if (usuario.Email.Contains ("!") || usuario.Email.Contains ("#") || usuario.Email.Contains ("*") || usuario.Email.Contains ("@") )
            {
                throw new ArgumentException("O email do usuário não pode conter caracteres especiais como: !, #, *, @.");
            }
            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new ArgumentException("A senha do usuário não pode ser vazia.");
            }
            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }
        }
    }
}
