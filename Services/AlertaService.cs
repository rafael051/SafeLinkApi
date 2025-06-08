using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Classe responsável pelas regras de negócio relacionadas à entidade Alerta.
    /// </summary>
    public class AlertaService
    {
        private readonly ApplicationDbContext _context;
        private readonly RegiaoService _regiaoService;

        public AlertaService(ApplicationDbContext context, RegiaoService regiaoService)
        {
            _context = context;
            _regiaoService = regiaoService;
        }

        // =====================================================
        // POST: Criar um novo alerta
        // =====================================================
        public async Task<AlertaResponseDTO> CriarAsync(AlertaRequestDTO dto)
        {
            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada.");

            var alerta = new Alerta
            {
                CriadoEm = DateTime.UtcNow,
                EmitidoEm = dto.EmitidoEm,
                Mensagem = dto.Mensagem,
                NivelRisco = dto.NivelRisco,
                IdRegiao = regiao.Id
            };

            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            return new AlertaResponseDTO
            {
                Id = alerta.Id,
                CriadoEm = alerta.CriadoEm,
                EmitidoEm = alerta.EmitidoEm,
                Mensagem = alerta.Mensagem,
                NivelRisco = alerta.NivelRisco,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // GET: Listar todos os alertas
        // =====================================================
        public async Task<List<AlertaResponseDTO>> ListarAsync()
        {
            return await _context.Alertas
                .Include(a => a.Regiao)
                .Select(a => new AlertaResponseDTO
                {
                    Id = a.Id,
                    CriadoEm = a.CriadoEm,
                    EmitidoEm = a.EmitidoEm,
                    Mensagem = a.Mensagem,
                    NivelRisco = a.NivelRisco,
                    NomeRegiao = a.Regiao.NomeRegiao
                })
                .ToListAsync();
        }

        // =====================================================
        // GET: Buscar alerta por ID
        // =====================================================
        public async Task<AlertaResponseDTO?> BuscarPorIdAsync(long id)
        {
            var alerta = await _context.Alertas
                .Include(a => a.Regiao)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (alerta == null)
                return null;

            return new AlertaResponseDTO
            {
                Id = alerta.Id,
                CriadoEm = alerta.CriadoEm,
                EmitidoEm = alerta.EmitidoEm,
                Mensagem = alerta.Mensagem,
                NivelRisco = alerta.NivelRisco,
                NomeRegiao = alerta.Regiao.NomeRegiao
            };
        }

        // =====================================================
        // PUT: Atualizar um alerta existente
        // =====================================================
        public async Task<AlertaResponseDTO> AtualizarAsync(long id, AlertaRequestDTO dto)
        {
            var alerta = await _context.Alertas.FindAsync(id)
                ?? throw new Exception("Alerta não encontrado.");

            var regiao = await _context.Regioes
            .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
            ?? throw new Exception("Região não encontrada.");


            alerta.EmitidoEm = dto.EmitidoEm;
            alerta.Mensagem = dto.Mensagem;
            alerta.NivelRisco = dto.NivelRisco;
            alerta.IdRegiao = regiao.Id;

            _context.Alertas.Update(alerta);
            await _context.SaveChangesAsync();

            return new AlertaResponseDTO
            {
                Id = alerta.Id,
                CriadoEm = alerta.CriadoEm,
                EmitidoEm = alerta.EmitidoEm,
                Mensagem = alerta.Mensagem,
                NivelRisco = alerta.NivelRisco,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // DELETE: Remover alerta por ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var alerta = await _context.Alertas.FindAsync(id)
                ?? throw new Exception("Alerta não encontrado.");

            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }
    }
}
