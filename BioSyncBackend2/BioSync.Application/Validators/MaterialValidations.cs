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
    public class MaterialValidations
    {
        public MaterialValidations(Material material)
        {
            if (material == null || material.Descricao.Length > 100)
            {
                throw new ArgumentException("O material do coletor não pode ser nulo ou ter mais de 100 caracteres.");
            }
            if (string.IsNullOrEmpty(material.Nome))
            {
                throw new ArgumentException("O nome do material não pode ser vazio.");
            }
            if (material.Descricao != null && material.Descricao.Length > 500)
            {
                throw new ArgumentException("A descrição do material não pode ter mais de 500 caracteres.");
            }
            if (string.IsNullOrWhiteSpace(material.Descricao))
            {
                throw new ArgumentException("A descrição do material não pode ser vazia ou conter apenas espaços em branco.");
            }
            if (string.IsNullOrEmpty(material.Descricao))
            {
                throw new ArgumentException("A descrição do material não pode ser vazia.");
            }
            if (material.Descricao.Contains("!") || material.Descricao.Contains("#") || material.Descricao.Contains("*") || material.Descricao.Contains("@"))
            {
                throw new ArgumentException("A descrição do material não pode conter caracteres especiais como: !, #, *, @.");
            }
            if (string.IsNullOrEmpty(material.Nome))
            {
                throw new ArgumentException("O nome do material não pode ser vazio.");
            }
            if (material.Nome.Contains("!") || material.Nome.Contains("#") || material.Nome.Contains("*") || material.Nome.Contains("@"))
            {
                throw new ArgumentException("O nome do material não pode conter caracteres especiais como: !, #, *, @.");
            }
            if (material.Nome.Length > 100)
            {
                throw new ArgumentException("O nome do material não pode ter mais de 100 caracteres.");
            }
        }
    }
}
