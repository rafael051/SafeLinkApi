using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoUsuarioController : ControllerBase
    {
        private readonly RelatoUsuarioService _service;

        public RelatoUsuarioController(RelatoUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cadastra um novo relato feito por um usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<RelatoUsuarioResponseDTO>> Post([FromBody] RelatoUsuarioRequestDTO dto)
        {
            var result = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Lista todos os relatos feitos por usuários.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<RelatoUsuarioResponseDTO>>> GetAll()
        {
            var lista = await _service.ListarAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Retorna um relato específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<RelatoUsuarioResponseDTO>> GetById(long id)
        {
            var relato = await _service.BuscarPorIdAsync(id);
            if (relato == null)
                return NotFound("Relato não encontrado.");

            return Ok(relato);
        }

        /// <summary>
        /// Atualiza um relato existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<RelatoUsuarioResponseDTO>> Put(long id, [FromBody] RelatoUsuarioRequestDTO dto)
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
        /// Remove um relato do sistema.
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
