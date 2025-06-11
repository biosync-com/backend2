using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using FluentAssertions;
using BioSync.Domain.Validation;
using FluentValidation;

namespace BioSync.Application.Validators
{
    public class ColetorValidations
    {
        public ColetorValidations(Coletor coletor)
        {
            if (coletor == null)
            {
                throw new ArgumentNullException(nameof(coletor), "O coletor não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(coletor.CPF))
            {
                throw new ArgumentException("O CPF do coletor não pode ser vazio.");
            }
            if (coletor.Email != null && coletor.Email.Length > 100)
            {
                throw new ArgumentException("O email do coletor não pode ter mais de 100 caracteres.");
            }
            if (string.IsNullOrWhiteSpace(coletor.Email))
            {
                throw new ArgumentException("O email do coletor não pode ser vazio ou conter apenas espaços em branco.");
            }
            if (string.IsNullOrEmpty(coletor.Email))
            {
                throw new ArgumentException("O email do coletor não pode ser vazio.");
            }
            if (coletor.Email.Contains("!") || coletor.Email.Contains("#") || coletor.Email.Contains("*") || coletor.Email.Contains("@"))
            {
                throw new ArgumentException("O email do coletor não pode conter caracteres especiais como: !, #, *, @.");
            }
            if (string.IsNullOrEmpty(coletor.Senha))
            {
                throw new ArgumentException("A senha do coletor não pode ser vazia.");
            }
            if (string.IsNullOrEmpty(coletor.Nome))
            {
                throw new ArgumentException("O nome do coletor não pode ser vazio.");
            }
            if (coletor.Material == null || coletor.Material.Length > 100)
            {
                throw new ArgumentException("O material do coletor não pode ser nulo ou ter mais de 100 caracteres.");
            }
            if (coletor.Material != null && coletor.Material.Length > 100)
            {
                throw new ArgumentException("O material do coletor não pode ter mais de 100 caracteres.");
            }
            if (string.IsNullOrEmpty(coletor.Material))
            {
                throw new ArgumentException("O material do coletor não pode ser vazio.");
            }
            if (coletor.Material.Contains("!") || coletor.Material.Contains("#") || coletor.Material.Contains("*") || coletor.Material.Contains("@"))
            {
                throw new ArgumentException("O material do coletor não pode conter caracteres especiais como: !, #, *, @.");
            }
            if (coletor.Material.Contains(" ") || coletor.Material.Contains("\t") || coletor.Material.Contains("\n"))
            {
                throw new ArgumentException("O material do coletor não pode conter espaços em branco, tabulações ou quebras de linha.");
            }
            if (coletor.Material.Length < 3)
            {
                throw new ArgumentException("O material do coletor deve ter pelo menos 3 caracteres.");
            }

        }
    }
}
