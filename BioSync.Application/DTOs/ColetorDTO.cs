using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class ColetorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do coletor � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome n�o pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do coletor � obrigat�rio")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O telefone do coletor � obrigat�rio")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no m�ximo 15 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail do coletor � obrigat�rio")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido � inv�lido")]
        [MaxLength(250, ErrorMessage = "O e-mail n�o pode ter mais de 250 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O endere�o do coletor � obrigat�rio")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "A senha do coletor � obrigat�ria")]
        [MinLength(8, ErrorMessage = "A senha deve ter no m�nimo 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A data de cadastro � obrigat�ria")]
        public DateTime DataCadastro { get; set; }

        public List<AgendamentoDTO> AgendamentosAceitos { get; set; }
        //public List<MaterialDTO> MateriaisColetados { get; set; }

        public ColetorDTO(int id, string nome, string cpf, string telefone, string email, int enderecoId,
                          string senha, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
            Senha = senha;
            DataCadastro = dataCadastro;
            AgendamentosAceitos = new List<AgendamentoDTO>();
            //MateriaisColetados = new List<MaterialDTO>();
        }
    }
}