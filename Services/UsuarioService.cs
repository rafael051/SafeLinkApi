using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Classe responsável pelas regras de negócio relacionadas à entidade User.
    /// </summary>
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // POST: Criar um novo usuário
        // =====================================================
        public async Task<UsuarioResponseDTO> CriarAsync(UsuarioRequestDTO dto)
        {
            var usuario = new User
            {
                Email = dto.Email,
                Senha = dto.Senha,
                Role = dto.Role
            };

            _context.Users.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        // =====================================================
        // GET: Listar todos os usuários
        // =====================================================
        public async Task<List<UsuarioResponseDTO>> ListarAsync()
        {
            return await _context.Users
                .Select(u => new UsuarioResponseDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    Role = u.Role
                }).ToListAsync();
        }

        // =====================================================
        // GET: Buscar usuário por ID
        // =====================================================
        public async Task<UsuarioResponseDTO?> BuscarPorIdAsync(long id)
        {
            var usuario = await _context.Users.FindAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        // =====================================================
        // PUT: Atualizar dados de um usuário
        // =====================================================
        public async Task<UsuarioResponseDTO> AtualizarAsync(long id, UsuarioRequestDTO dto)
        {
            var usuario = await _context.Users.FindAsync(id)
                ?? throw new Exception("Usuário não encontrado.");

            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;
            usuario.Role = dto.Role;

            _context.Users.Update(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        // =====================================================
        // DELETE: Remover um usuário pelo ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var usuario = await _context.Users.FindAsync(id)
                ?? throw new Exception("Usuário não encontrado.");

            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
