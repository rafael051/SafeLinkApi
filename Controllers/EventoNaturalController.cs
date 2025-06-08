using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoNaturalController : ControllerBase
    {
        private readonly EventoNaturalService _service;

        public EventoNaturalController(EventoNaturalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria um novo evento natural.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EventoNaturalResponseDTO>> Post([FromBody] EventoNaturalRequestDTO dto)
        {
            var result = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Lista todos os eventos naturais cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<EventoNaturalResponseDTO>>> Get()
        {
            return Ok(await _service.ListarAsync());
        }

        /// <summary>
        /// Retorna um evento natural por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoNaturalResponseDTO>> GetById(long id)
        {
            var evento = await _service.BuscarPorIdAsync(id);
            if (evento == null)
                return NotFound("Evento não encontrado.");

            return Ok(evento);
        }

        /// <summary>
        /// Atualiza um evento natural existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<EventoNaturalResponseDTO>> Put(long id, [FromBody] EventoNaturalRequestDTO dto)
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
        /// Remove um evento natural pelo ID.
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
