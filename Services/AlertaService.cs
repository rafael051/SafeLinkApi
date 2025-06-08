using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;
using SafeLinkApi.Services;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Serviço responsável pela lógica de negócios relacionada à entidade Alerta.
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
        // POST: Cadastrar um novo alerta
        // =====================================================
        public async Task<AlertaResponseDTO> CriarAsync(AlertaRequestDTO dto)
        {
            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

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

            return MapearParaResponse(alerta);
        }

        // =====================================================
        // GET: Listar todos os alertas
        // =====================================================
        public async Task<List<AlertaResponseDTO>> ListarAsync()
        {
            return await _context.Alertas
                .Select(a => MapearParaResponse(a))
                .ToListAsync();
        }

        // =====================================================
        // GET: Buscar um alerta por ID
        // =====================================================
        public async Task<AlertaResponseDTO?> BuscarPorIdAsync(long id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            return alerta is null ? null : MapearParaResponse(alerta);
        }

        // =====================================================
        // PUT: Atualizar um alerta existente
        // =====================================================
        public async Task<AlertaResponseDTO> AtualizarAsync(long id, AlertaRequestDTO dto)
        {
            var alerta = await _context.Alertas.FindAsync(id)
                ?? throw new Exception("Alerta não encontrado.");

            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

            alerta.EmitidoEm = dto.EmitidoEm;
            alerta.Mensagem = dto.Mensagem;
            alerta.NivelRisco = dto.NivelRisco;
            alerta.IdRegiao = regiao.Id;

            _context.Alertas.Update(alerta);
            await _context.SaveChangesAsync();

            return MapearParaResponse(alerta);
        }

        // =====================================================
        // DELETE: Remover um alerta pelo ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var alerta = await _context.Alertas.FindAsync(id)
                ?? throw new Exception("Alerta não encontrado.");

            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }

        // =====================================================
        // Método auxiliar para mapear a entidade para o DTO de resposta
        // =====================================================
        private AlertaResponseDTO MapearParaResponse(Alerta alerta)
        {
            return new AlertaResponseDTO
            {
                Id = alerta.Id,
                CriadoEm = alerta.CriadoEm,
                EmitidoEm = alerta.EmitidoEm,
                Mensagem = alerta.Mensagem,
                NivelRisco = alerta.NivelRisco,
                IdRegiao = alerta.IdRegiao
            };
        }
    }
}
