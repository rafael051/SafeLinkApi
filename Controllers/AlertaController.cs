using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações CRUD da entidade Alerta.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _service;

        public AlertaController(AlertaService service)
        {
            _service = service;
        }

        // =====================================================
        // GET /api/alerta
        // Retorna todos os alertas cadastrados.
        // =====================================================
        [HttpGet]
        public async Task<ActionResult<List<AlertaResponseDTO>>> GetAll()
        {
            var alertas = await _service.ListarAsync();
            return Ok(alertas);
        }

        // =====================================================
        // GET /api/alerta/{id}
        // Retorna um alerta específico pelo ID.
        // =====================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertaResponseDTO>> GetById(long id)
        {
            var alerta = await _service.BuscarPorIdAsync(id);
            return alerta is null ? NotFound("Alerta não encontrado.") : Ok(alerta);
        }

        // =====================================================
        // POST /api/alerta
        // Cadastra um novo alerta no sistema.
        // =====================================================
        [HttpPost]
        public async Task<ActionResult<AlertaResponseDTO>> Post([FromBody] AlertaRequestDTO dto)
        {
            var result = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // =====================================================
        // PUT /api/alerta/{id}
        // Atualiza os dados de um alerta existente.
        // =====================================================
        [HttpPut("{id}")]
        public async Task<ActionResult<AlertaResponseDTO>> Put(long id, [FromBody] AlertaRequestDTO dto)
        {
            var result = await _service.AtualizarAsync(id, dto);
            return Ok(result);
        }

        // =====================================================
        // DELETE /api/alerta/{id}
        // Remove um alerta do sistema.
        // =====================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
