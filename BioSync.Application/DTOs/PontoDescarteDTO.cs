using BioSync.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class PontoDescarteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome deve ter no m�nimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF ou CNPJ � obrigat�rio")]
        [MinLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [MinLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio")]
        [MinLength(10, ErrorMessage = "O telefone deve ter no m�nimo 10 caracteres")]
        [MaxLength(15, ErrorMessage = "O telefone deve ter no m�ximo 15 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail ou site � obrigat�rio")]
        public string EmailOuSite { get; set; }

        [Required(ErrorMessage = "O nome do respons�vel � obrigat�rio")]
        public string NomeResponsavel { get; set; }

        public int EnderecoId { get; set; }
        public List<int> DiasFuncionamentoIds { get; set; }

        public PontoDescarteDTO() { }

        public PontoDescarteDTO(int id, string nome, string cpf, string cnpj, string telefone, string emailOuSite, string nomeResponsavel, int enderecoId, List<int> diasFuncionamentoIds)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Telefone = telefone;
            EmailOuSite = emailOuSite;
            NomeResponsavel = nomeResponsavel;
            EnderecoId = enderecoId;
            DiasFuncionamentoIds = diasFuncionamentoIds;
        }
    }
}