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
    public class ColetoresController : ControllerBase
    {
        private readonly IColetorService _coletorService;

        public ColetoresController(IColetorService coletorService)
        {
            _coletorService = coletorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coletores = await _coletorService.GetAllAsync();
            return Ok(coletores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coletor = await _coletorService.GetByIdAsync(id);
            if (coletor == null)
            {
                return NotFound("Coletor não encontrado.");
            }
            return Ok(coletor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColetorRequestDTO coletorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdColetor = await _coletorService.CreateAsync(coletorDto);
            return CreatedAtAction(nameof(GetById), new { id = createdColetor.Id }, createdColetor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ColetorRequestDTO coletorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _coletorService.UpdateAsync(id, coletorDto);
            if (!result)
            {
                return NotFound("Coletor não encontrado para atualização.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _coletorService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Coletor não encontrado para exclusão.");
            }
            return NoContent();
        }
    }
}