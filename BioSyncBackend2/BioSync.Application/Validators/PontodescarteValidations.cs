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
    public class PontodescarteValidations
    {
        public PontodescarteValidations(PontoDescarte pontodescarte)
        {
            if (pontodescarte == null)
            {
                throw new ArgumentNullException(nameof(pontodescarte), "O ponto de descarte não pode ser nulo.");
            }
            if (string.IsNullOrEmpty(pontodescarte.Nome))
            {
                throw new ArgumentException("O nome do ponto de descarte não pode ser vazio.");
            }
            if (pontodescarte.Nome.Length > 100)
            {
                throw new ArgumentException("O nome do ponto de descarte não pode ter mais de 100 caracteres.");
            }
            if (string.IsNullOrEmpty(pontodescarte.CNPJ) || pontodescarte.CNPJ.Length > 14)
            {
                throw new ArgumentException("O CNPJ do ponto de descarte não pode ser nulo ou ter mais de 14 caracteres.");
            }
            if (string.IsNullOrEmpty(pontodescarte.Email))
            {
                throw new ArgumentException("O email do ponto de descarte não pode ser vazio.");
            }
            if (pontodescarte.Email.Length > 100)
            {
                throw new ArgumentException("O email do ponto de descarte não pode ter mais de 100 caracteres.");
            }
            if (string.IsNullOrEmpty(pontodescarte.Senha) || pontodescarte.Senha.Length < 6 || pontodescarte.Senha.Length > 20)
            {
                throw new ArgumentException("A senha do ponto de descarte deve ter entre 6 e 20 caracteres.");
            }
            if (string.IsNullOrEmpty(pontodescarte.Endereco))
            {
                throw new ArgumentException("O endereço do ponto de descarte não pode ser vazio.");
            }
            if (pontodescarte.Endereco.Length > 200)
            {
                throw new ArgumentException("O endereço do ponto de descarte não pode ter mais de 200 caracteres.");
            }
            if (string.IsNullOrEmpty(pontodescarte.Material))
            {
                throw new ArgumentException("O material do ponto de descarte não pode ser vazio.");
            }
            if (pontodescarte.Material.Length > 100)
            {
                throw new ArgumentException("O material do ponto de descarte não pode ter mais de 100 caracteres.");
            }
            if (pontodescarte.Material.Contains("!") || pontodescarte.Material.Contains("#") || pontodescarte.Material.Contains("*") || pontodescarte.Material.Contains("@"))
            {
                throw new ArgumentException("O material do ponto de descarte não pode conter caracteres especiais como: !, #, *, @.");
            }
        }
    }
}
