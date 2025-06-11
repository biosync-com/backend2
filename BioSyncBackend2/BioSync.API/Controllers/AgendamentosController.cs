using BioSync.Application.DTOs.Request;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoService.GetAllAsync();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _agendamentoService.GetByIdAsync(id);
            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado.");
            }
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgendamentoRequestDTO agendamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdAgendamento = await _agendamentoService.CreateAsync(agendamentoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdAgendamento.Id }, createdAgendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AgendamentoRequestDTO agendamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _agendamentoService.UpdateAsync(id, agendamentoDto);
            if (!result)
            {
                return NotFound("Agendamento não encontrado para atualização.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _agendamentoService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Agendamento não encontrado para exclusão.");
            }
            return NoContent();
        }
    }
}