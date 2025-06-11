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
    public class PontosDescarteController : ControllerBase
    {
        private readonly IPontoDescarteService _pontoDescarteService;

        public PontosDescarteController(IPontoDescarteService pontoDescarteService)
        {
            _pontoDescarteService = pontoDescarteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pontosDescarte = await _pontoDescarteService.GetAllAsync();
            return Ok(pontosDescarte);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pontoDescarte = await _pontoDescarteService.GetByIdAsync(id);
            if (pontoDescarte == null)
            {
                return NotFound("Ponto de descarte não encontrado.");
            }
            return Ok(pontoDescarte);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PontoDescarteRequestDTO pontoDescarteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPontoDescarte = await _pontoDescarteService.CreateAsync(pontoDescarteDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPontoDescarte.Id }, createdPontoDescarte);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PontoDescarteRequestDTO pontoDescarteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _pontoDescarteService.UpdateAsync(id, pontoDescarteDto);
            if (!result)
            {
                return NotFound("Ponto de descarte não encontrado para atualização.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pontoDescarteService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Ponto de descarte não encontrado para exclusão.");
            }
            return NoContent();
        }
    }
}