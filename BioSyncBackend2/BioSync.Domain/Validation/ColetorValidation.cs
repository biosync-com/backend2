using BioSync.Domain.Entities;

namespace BioSync.Domain.Validation
{
    public class ColetorValidation
    { 
        public ColetorValidation(Coletor coletor) 
        {
            if(coletor == null)
            {
                throw new ArgumentNullException(nameof(coletor), "Coletor não pode ser nulo.");
            }
            if(string.IsNullOrEmpty(coletor.Nome))
            {
                throw new ArgumentException(nameof(coletor), "Coletor não pode ficar com nome em branco ou vazio");
            }
            if (string.IsNullOrEmpty(coletor.Email))
            {
                throw new ArgumentException(nameof(coletor), "Coletor não pode ficar com e-mail em branco ou vazio");
            }
            if (!coletor.Email.Contains("*") || !coletor.Email.Contains("#") || coletor.Email.Contains("!") || coletor.Email.Contains("@")
            {
                throw new ArgumentException("Email do usuário deve ser válido.", nameof(coletor));
            }
            if (string.IsNullOrEmpty(coletor.Senha) || coletor.Senha.Length < 6)
            {
                throw new ArgumentException(nameof(coletor), "Coletor não pode ficar com senha em branco ou vazio");
            }
            if (string.IsNullOrEmpty(coletor.Material))
            {
                throw new ArgumentException(nameof(coletor), "Coletor não pode ficar com material em branco ou vazio");
            }
        }


    }
}
