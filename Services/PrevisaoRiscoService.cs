using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio da entidade PrevisaoRisco.
    /// </summary>
    public class PrevisaoRiscoService
    {
        private readonly ApplicationDbContext _context;

        public PrevisaoRiscoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // POST: Criar nova previsão de risco
        // =====================================================
        public async Task<PrevisaoRiscoResponseDTO> CriarAsync(PrevisaoRiscoRequestDTO dto)
        {
            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada.");

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
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // GET: Listar todas as previsões de risco
        // =====================================================
        public async Task<List<PrevisaoRiscoResponseDTO>> ListarAsync()
        {
            return await _context.PrevisoesRisco
                .Include(p => p.Regiao)
                .Select(p => new PrevisaoRiscoResponseDTO
                {
                    Id = p.Id,
                    CriadoEm = p.CriadoEm,
                    GeradoEm = p.GeradoEm,
                    Fonte = p.Fonte,
                    NivelPrevisto = p.NivelPrevisto,
                    NomeRegiao = p.Regiao.NomeRegiao
                }).ToListAsync();
        }

        // =====================================================
        // GET: Buscar previsão de risco por ID
        // =====================================================
        public async Task<PrevisaoRiscoResponseDTO?> BuscarPorIdAsync(long id)
        {
            var previsao = await _context.PrevisoesRisco
                .Include(p => p.Regiao)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (previsao == null)
                return null;

            return new PrevisaoRiscoResponseDTO
            {
                Id = previsao.Id,
                CriadoEm = previsao.CriadoEm,
                GeradoEm = previsao.GeradoEm,
                Fonte = previsao.Fonte,
                NivelPrevisto = previsao.NivelPrevisto,
                NomeRegiao = previsao.Regiao.NomeRegiao
            };
        }

        // =====================================================
        // PUT: Atualizar previsão de risco existente
        // =====================================================
        public async Task<PrevisaoRiscoResponseDTO> AtualizarAsync(long id, PrevisaoRiscoRequestDTO dto)
        {
            var previsao = await _context.PrevisoesRisco.FindAsync(id)
                ?? throw new Exception("Previsão de risco não encontrada.");

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada.");

            previsao.GeradoEm = dto.GeradoEm;
            previsao.Fonte = dto.Fonte;
            previsao.NivelPrevisto = dto.NivelPrevisto;
            previsao.IdRegiao = regiao.Id;

            _context.PrevisoesRisco.Update(previsao);
            await _context.SaveChangesAsync();

            return new PrevisaoRiscoResponseDTO
            {
                Id = previsao.Id,
                CriadoEm = previsao.CriadoEm,
                GeradoEm = previsao.GeradoEm,
                Fonte = previsao.Fonte,
                NivelPrevisto = previsao.NivelPrevisto,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // DELETE: Remover previsão de risco por ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var previsao = await _context.PrevisoesRisco.FindAsync(id)
                ?? throw new Exception("Previsão de risco não encontrada.");

            _context.PrevisoesRisco.Remove(previsao);
            await _context.SaveChangesAsync();
        }
    }
}
