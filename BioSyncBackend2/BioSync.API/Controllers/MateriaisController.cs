using BioSync.Application.DTOs.Request;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os endpoints neste controller
    public class MateriaisController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MateriaisController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var materiais = await _materialService.GetAllAsync();
            return Ok(materiais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var material = await _materialService.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound("Material não encontrado.");
            }
            return Ok(material);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaterialRequestDTO materialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdMaterial = await _materialService.CreateAsync(materialDto);
            return CreatedAtAction(nameof(GetById), new { id = createdMaterial.Materiais}, createdMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaterialRequestDTO materialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _materialService.UpdateAsync(id, materialDto);
            if (!result)
            {
                return NotFound("Material não encontrado para atualização.");
            }
            return NoContent(); // Sucesso, sem conteúdo para retornar
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _materialService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Material não encontrado para exclusão.");
            }
            return NoContent(); // Sucesso, sem conteúdo para retornar
        }
    }
}