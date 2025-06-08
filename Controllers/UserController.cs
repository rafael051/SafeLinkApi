using Microsoft.AspNetCore.Mvc;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Services;

namespace SafeLinkApi.Controllers
{
    /// <summary>
    /// Controller responsável por operações CRUD para a entidade User.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UserController(UsuarioService service)
        {
            _service = service;
        }

        // =====================================================
        // GET /api/user
        // Retorna todos os usuários cadastrados no sistema.
        // =====================================================
        [HttpGet]
        public async Task<ActionResult<List<UsuarioResponseDTO>>> GetAll()
        {
            var usuarios = await _service.ListarAsync();
            return Ok(usuarios);
        }

        // =====================================================
        // GET /api/user/{id}
        // Retorna os dados de um usuário específico pelo ID.
        // =====================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDTO>> GetById(long id)
        {
            var usuario = await _service.BuscarPorIdAsync(id);
            return usuario is null ? NotFound("Usuário não encontrado.") : Ok(usuario);
        }

        // =====================================================
        // POST /api/user
        // Cadastra um novo usuário com os dados fornecidos.
        // =====================================================
        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> Post([FromBody] UsuarioRequestDTO dto)
        {
            var result = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // =====================================================
        // PUT /api/user/{id}
        // Atualiza os dados de um usuário existente.
        // =====================================================
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioResponseDTO>> Put(long id, [FromBody] UsuarioRequestDTO dto)
        {
            var result = await _service.AtualizarAsync(id, dto);
            return Ok(result);
        }

        // =====================================================
        // DELETE /api/user/{id}
        // Remove um usuário existente do sistema.
        // =====================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
