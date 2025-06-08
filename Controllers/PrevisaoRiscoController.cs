using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrevisaoRiscoController : ControllerBase
    {
        private readonly PrevisaoRiscoService _service;

        public PrevisaoRiscoController(PrevisaoRiscoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria uma nova previsão de risco.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PrevisaoRiscoResponseDTO>> Post([FromBody] PrevisaoRiscoRequestDTO dto)
        {
            var result = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Lista todas as previsões de risco.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<PrevisaoRiscoResponseDTO>>> Get()
        {
            return Ok(await _service.ListarAsync());
        }

        /// <summary>
        /// Busca uma previsão de risco por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PrevisaoRiscoResponseDTO>> GetById(long id)
        {
            var previsao = await _service.BuscarPorIdAsync(id);
            if (previsao == null)
                return NotFound("Previsão não encontrada.");

            return Ok(previsao);
        }

        /// <summary>
        /// Atualiza uma previsão de risco existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<PrevisaoRiscoResponseDTO>> Put(long id, [FromBody] PrevisaoRiscoRequestDTO dto)
        {
            try
            {
                var atualizado = await _service.AtualizarAsync(id, dto);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma previsão de risco pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _service.RemoverAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
