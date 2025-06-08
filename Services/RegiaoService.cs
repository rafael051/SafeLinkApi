using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio relacionadas à entidade Região.
    /// </summary>
    public class RegiaoService
    {
        private readonly ApplicationDbContext _context;

        public RegiaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todas as regiões cadastradas.
        /// </summary>
        public async Task<List<RegiaoResponseDTO>> ListarAsync()
        {
            return await _context.Regioes
                .Select(r => new RegiaoResponseDTO
                {
                    Id = r.Id,
                    Cidade = r.Cidade,
                    Estado = r.Estado,
                    Latitude = r.Latitude,
                    Longitude = r.Longitude,
                    NomeRegiao = r.NomeRegiao
                })
                .ToListAsync(); // <- aqui precisa do using Microsoft.EntityFrameworkCore
        }

        /// <summary>
        /// Busca uma região pelo ID. Retorna a entidade Regiao (uso interno).
        /// </summary>
        public async Task<Regiao> BuscarPorIdAsync(long id)
        {
            return await _context.Regioes.FindAsync(id)
                ?? throw new Exception("Região não encontrada.");
        }

        /// <summary>
        /// Busca uma região pelo ID e retorna DTO (uso em controller).
        /// </summary>
        public async Task<RegiaoResponseDTO?> BuscarDTOAsync(long id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null) return null;

            return new RegiaoResponseDTO
            {
                Id = regiao.Id,
                Cidade = regiao.Cidade,
                Estado = regiao.Estado,
                Latitude = regiao.Latitude,
                Longitude = regiao.Longitude,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        /// <summary>
        /// Cria uma nova região.
        /// </summary>
        public async Task<RegiaoResponseDTO> CriarAsync(RegiaoRequestDTO dto)
        {
            var regiao = new Regiao
            {
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                NomeRegiao = dto.NomeRegiao
            };

            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();

            return new RegiaoResponseDTO
            {
                Id = regiao.Id,
                Cidade = regiao.Cidade,
                Estado = regiao.Estado,
                Latitude = regiao.Latitude,
                Longitude = regiao.Longitude,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        /// <summary>
        /// Atualiza os dados de uma região existente.
        /// </summary>
        public async Task<RegiaoResponseDTO> AtualizarAsync(long id, RegiaoRequestDTO dto)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
                throw new Exception("Região não encontrada.");

            regiao.Cidade = dto.Cidade;
            regiao.Estado = dto.Estado;
            regiao.Latitude = dto.Latitude;
            regiao.Longitude = dto.Longitude;
            regiao.NomeRegiao = dto.NomeRegiao;

            await _context.SaveChangesAsync();

            return new RegiaoResponseDTO
            {
                Id = regiao.Id,
                Cidade = regiao.Cidade,
                Estado = regiao.Estado,
                Latitude = regiao.Latitude,
                Longitude = regiao.Longitude,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        /// <summary>
        /// Remove uma região do banco de dados.
        /// </summary>
        public async Task RemoverAsync(long id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
                throw new Exception("Região não encontrada.");

            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
        }
    }
}
