using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegiaoController : ControllerBase
    {
        private readonly RegiaoService _service;

        public RegiaoController(RegiaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as regiões cadastradas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<RegiaoResponseDTO>>> GetAll()
        {
            var regioes = await _service.ListarAsync();
            return Ok(regioes);
        }

        /// <summary>
        /// Busca uma região pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<RegiaoResponseDTO>> GetById(long id)
        {
            var regiao = await _service.BuscarPorIdAsync(id);
            if (regiao == null)
                return NotFound("Região não encontrada.");

            return Ok(regiao);
        }

        /// <summary>
        /// Cadastra uma nova região.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<RegiaoResponseDTO>> Post([FromBody] RegiaoRequestDTO dto)
        {
            var novaRegiao = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novaRegiao.Id }, novaRegiao);
        }

        /// <summary>
        /// Atualiza os dados de uma região existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<RegiaoResponseDTO>> Put(long id, [FromBody] RegiaoRequestDTO dto)
        {
            try
            {
                var regiaoAtualizada = await _service.AtualizarAsync(id, dto);
                return Ok(regiaoAtualizada);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma região do sistema.
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
