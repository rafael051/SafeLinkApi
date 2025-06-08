using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    public class RelatoUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public RelatoUsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Cria um novo relato de usuário
        public async Task<RelatoUsuarioResponseDTO> CriarAsync(RelatoUsuarioRequestDTO dto)
        {
            var relato = new RelatoUsuario
            {
                CriadoEm = DateTime.UtcNow,
                DataRelato = dto.DataRelato,
                Mensagem = dto.Mensagem,
                IdUsuario = dto.IdUsuario,
                IdRegiao = dto.IdRegiao
            };

            _context.RelatosUsuario.Add(relato);
            await _context.SaveChangesAsync();

            return MapToDTO(relato);
        }

        // Lista todos os relatos de usuário
        public async Task<List<RelatoUsuarioResponseDTO>> ListarAsync()
        {
            return await _context.RelatosUsuario
                .Select(r => MapToDTO(r))
                .ToListAsync();
        }

        // Busca um relato específico pelo ID
        public async Task<RelatoUsuarioResponseDTO?> BuscarPorIdAsync(long id)
        {
            var relato = await _context.RelatosUsuario.FindAsync(id);
            return relato == null ? null : MapToDTO(relato);
        }

        // Atualiza um relato existente
        public async Task<RelatoUsuarioResponseDTO> AtualizarAsync(long id, RelatoUsuarioRequestDTO dto)
        {
            var relato = await _context.RelatosUsuario.FindAsync(id)
                ?? throw new Exception("Relato não encontrado.");

            relato.DataRelato = dto.DataRelato;
            relato.Mensagem = dto.Mensagem;
            relato.IdUsuario = dto.IdUsuario;
            relato.IdRegiao = dto.IdRegiao;

            await _context.SaveChangesAsync();
            return MapToDTO(relato);
        }

        // Remove um relato do sistema
        public async Task RemoverAsync(long id)
        {
            var relato = await _context.RelatosUsuario.FindAsync(id)
                ?? throw new Exception("Relato não encontrado.");

            _context.RelatosUsuario.Remove(relato);
            await _context.SaveChangesAsync();
        }

        // Conversor de entidade para DTO de resposta
        private RelatoUsuarioResponseDTO MapToDTO(RelatoUsuario r)
        {
            return new RelatoUsuarioResponseDTO
            {
                Id = r.Id,
                CriadoEm = r.CriadoEm,
                DataRelato = r.DataRelato,
                Mensagem = r.Mensagem,
                IdUsuario = r.IdUsuario,
                IdRegiao = r.IdRegiao
            };
        }
    }
}
