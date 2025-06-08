using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio relacionada à Previsão de Risco.
    /// </summary>
    public class PrevisaoRiscoService
    {
        private readonly ApplicationDbContext _context;
        private readonly RegiaoService _regiaoService;

        public PrevisaoRiscoService(ApplicationDbContext context, RegiaoService regiaoService)
        {
            _context = context;
            _regiaoService = regiaoService;
        }

        /// <summary>
        /// Cria uma nova previsão de risco.
        /// </summary>
        public async Task<PrevisaoRiscoResponseDTO> CriarAsync(PrevisaoRiscoRequestDTO dto)
        {
            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

            var previsao = new PrevisaoRisco
            {
                CriadoEm = DateTime.UtcNow,
                GeradoEm = dto.GeradoEm,
                Fonte = dto.Fonte,
                NivelPrevisto = dto.NivelPrevisto,
                IdRegiao = regiao.Id
            };

            _context.PrevisoesRisco.Add(previsao);
            await _context.SaveChangesAsync();

            return new PrevisaoRiscoResponseDTO
            {
                Id = previsao.Id,
                CriadoEm = previsao.CriadoEm,
                GeradoEm = previsao.GeradoEm,
                Fonte = previsao.Fonte,
                NivelPrevisto = previsao.NivelPrevisto,
                IdRegiao = previsao.IdRegiao
            };
        }

        /// <summary>
        /// Lista todas as previsões de risco cadastradas.
        /// </summary>
        public async Task<List<PrevisaoRiscoResponseDTO>> ListarAsync()
        {
            return await _context.PrevisoesRisco
                .Select(p => new PrevisaoRiscoResponseDTO
                {
                    Id = p.Id,
                    CriadoEm = p.CriadoEm,
                    GeradoEm = p.GeradoEm,
                    Fonte = p.Fonte,
                    NivelPrevisto = p.NivelPrevisto,
                    IdRegiao = p.IdRegiao
                }).ToListAsync();
        }

        /// <summary>
        /// Busca uma previsão de risco pelo ID.
        /// </summary>
        public async Task<PrevisaoRiscoResponseDTO?> BuscarPorIdAsync(long id)
        {
            var previsao = await _context.PrevisoesRisco.FindAsync(id);
            if (previsao == null) return null;

            return new PrevisaoRiscoResponseDTO
            {
                Id = previsao.Id,
                CriadoEm = previsao.CriadoEm,
                GeradoEm = previsao.GeradoEm,
                Fonte = previsao.Fonte,
                NivelPrevisto = previsao.NivelPrevisto,
                IdRegiao = previsao.IdRegiao
            };
        }

        /// <summary>
        /// Atualiza uma previsão de risco existente.
        /// </summary>
        public async Task<PrevisaoRiscoResponseDTO> AtualizarAsync(long id, PrevisaoRiscoRequestDTO dto)
        {
            var previsao = await _context.PrevisoesRisco.FindAsync(id);
            if (previsao == null)
                throw new Exception("Previsão de risco não encontrada.");

            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

            previsao.GeradoEm = dto.GeradoEm;
            previsao.Fonte = dto.Fonte;
            previsao.NivelPrevisto = dto.NivelPrevisto;
            previsao.IdRegiao = regiao.Id;

            await _context.SaveChangesAsync();

            return new PrevisaoRiscoResponseDTO
            {
                Id = previsao.Id,
                CriadoEm = previsao.CriadoEm,
                GeradoEm = previsao.GeradoEm,
                Fonte = previsao.Fonte,
                NivelPrevisto = previsao.NivelPrevisto,
                IdRegiao = previsao.IdRegiao
            };
        }

        /// <summary>
        /// Remove uma previsão de risco pelo ID.
        /// </summary>
        public async Task RemoverAsync(long id)
        {
            var previsao = await _context.PrevisoesRisco.FindAsync(id);
            if (previsao == null)
                throw new Exception("Previsão de risco não encontrada.");

            _context.PrevisoesRisco.Remove(previsao);
            await _context.SaveChangesAsync();
        }
    }
}
