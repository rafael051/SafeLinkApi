using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Classe responsável pelas regras de negócio relacionadas ao Relato de Usuário.
    /// </summary>
    public class RelatoUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public RelatoUsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // POST: Criar um novo relato
        // =====================================================
        public async Task<RelatoUsuarioResponseDTO> CriarAsync(RelatoUsuarioRequestDTO dto)
        {
            // 🔍 Busca o usuário e a região com base nos identificadores textuais
            var usuario = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email)
                ?? throw new Exception("Usuário não encontrado com o e-mail informado.");

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada com o nome informado.");

            var relato = new RelatoUsuario
            {
                CriadoEm = DateTime.UtcNow,
                DataRelato = dto.DataRelato,
                Mensagem = dto.Mensagem,
                IdUsuario = usuario.Id,
                IdRegiao = regiao.Id
            };

            _context.RelatosUsuario.Add(relato);
            await _context.SaveChangesAsync();

            return new RelatoUsuarioResponseDTO
            {
                Id = relato.Id,
                CriadoEm = relato.CriadoEm,
                DataRelato = relato.DataRelato,
                Mensagem = relato.Mensagem,
                Email = usuario.Email,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // GET: Listar todos os relatos
        // =====================================================
        public async Task<List<RelatoUsuarioResponseDTO>> ListarAsync()
        {
            return await _context.RelatosUsuario
                .Include(r => r.Usuario)
                .Include(r => r.Regiao)
                .Select(r => new RelatoUsuarioResponseDTO
                {
                    Id = r.Id,
                    CriadoEm = r.CriadoEm,
                    DataRelato = r.DataRelato,
                    Mensagem = r.Mensagem,
                    Email = r.Usuario.Email,
                    NomeRegiao = r.Regiao.NomeRegiao
                })
                .ToListAsync();
        }

        // =====================================================
        // GET: Buscar por ID
        // =====================================================
        public async Task<RelatoUsuarioResponseDTO?> BuscarPorIdAsync(long id)
        {
            var relato = await _context.RelatosUsuario
                .Include(r => r.Usuario)
                .Include(r => r.Regiao)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (relato == null) return null;

            return new RelatoUsuarioResponseDTO
            {
                Id = relato.Id,
                CriadoEm = relato.CriadoEm,
                DataRelato = relato.DataRelato,
                Mensagem = relato.Mensagem,
                Email = relato.Usuario.Email,
                NomeRegiao = relato.Regiao.NomeRegiao
            };
        }

        // =====================================================
        // PUT: Atualizar um relato existente
        // =====================================================
        public async Task<RelatoUsuarioResponseDTO> AtualizarAsync(long id, RelatoUsuarioRequestDTO dto)
        {
            var relato = await _context.RelatosUsuario.FindAsync(id)
                ?? throw new Exception("Relato não encontrado.");

            var usuario = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email)
                ?? throw new Exception("Usuário não encontrado com o e-mail informado.");

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada com o nome informado.");

            relato.DataRelato = dto.DataRelato;
            relato.Mensagem = dto.Mensagem;
            relato.IdUsuario = usuario.Id;
            relato.IdRegiao = regiao.Id;

            _context.RelatosUsuario.Update(relato);
            await _context.SaveChangesAsync();

            return new RelatoUsuarioResponseDTO
            {
                Id = relato.Id,
                CriadoEm = relato.CriadoEm,
                DataRelato = relato.DataRelato,
                Mensagem = relato.Mensagem,
                Email = usuario.Email,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // DELETE: Remover relato por ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var relato = await _context.RelatosUsuario.FindAsync(id)
                ?? throw new Exception("Relato não encontrado.");

            _context.RelatosUsuario.Remove(relato);
            await _context.SaveChangesAsync();
        }
    }
}
