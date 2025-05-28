using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class AgendamentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data do agendamento � obrigat�ria")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A hora de in�cio da disponibilidade � obrigat�ria")]
        public TimeSpan HoraInicioDisponivel { get; set; }

        [Required(ErrorMessage = "A hora de fim da disponibilidade � obrigat�ria")]
        public TimeSpan HoraFimDisponivel { get; set; }

        [Required(ErrorMessage = "O status do agendamento � obrigat�rio")]
        [MaxLength(20, ErrorMessage = "O status n�o pode ter mais que 20 caracteres")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O peso estimado � obrigat�rio")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O peso estimado deve ser maior que zero")]
        public decimal PesoEstimadoKg { get; set; }

        [Required(ErrorMessage = "A foto dos res�duos � obrigat�ria")]
        [MaxLength(250, ErrorMessage = "A URL da foto n�o pode ter mais que 250 caracteres")]
        public string FotoResiduos { get; set; }

        [MaxLength(500, ErrorMessage = "As observa��es n�o podem exceder 500 caracteres")]
        public string? Observacoes { get; set; }

        [Required(ErrorMessage = "O ID do usu�rio � obrigat�rio")]
        public int UsuarioId { get; set; }

        public int? ColetorId { get; set; }

        public ICollection<int>? MateriaisIds { get; set; }

        public AgendamentoDTO(DateTime data, TimeSpan horaInicioDisponivel, TimeSpan horaFimDisponivel,
                              decimal pesoEstimadoKg, string fotoResiduos, string observacoes)
        {
            Data = data;
            HoraInicioDisponivel = horaInicioDisponivel;
            HoraFimDisponivel = horaFimDisponivel;
            PesoEstimadoKg = pesoEstimadoKg;
            FotoResiduos = fotoResiduos;
            Observacoes = observacoes;
            Status = "Pendente";
        }
    }
}