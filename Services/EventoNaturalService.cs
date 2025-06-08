using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio relacionada aos eventos naturais.
    /// </summary>
    public class EventoNaturalService
    {
        private readonly ApplicationDbContext _context;
        private readonly RegiaoService _regiaoService;

        public EventoNaturalService(ApplicationDbContext context, RegiaoService regiaoService)
        {
            _context = context;
            _regiaoService = regiaoService;
        }

        /// <summary>
        /// Cria um novo evento natural.
        /// </summary>
        public async Task<EventoNaturalResponseDTO> CriarAsync(EventoNaturalRequestDTO dto)
        {
            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

            var evento = new EventoNatural
            {
                CriadoEm = DateTime.UtcNow,
                Ocorrencia = dto.Ocorrencia,
                Tipo = dto.Tipo,
                Descricao = dto.Descricao,
                IdRegiao = regiao.Id
            };

            _context.EventosNaturais.Add(evento);
            await _context.SaveChangesAsync();

            return new EventoNaturalResponseDTO
            {
                Id = evento.Id,
                CriadoEm = evento.CriadoEm,
                Ocorrencia = evento.Ocorrencia,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                IdRegiao = evento.IdRegiao
            };
        }

        /// <summary>
        /// Lista todos os eventos naturais cadastrados.
        /// </summary>
        public async Task<List<EventoNaturalResponseDTO>> ListarAsync()
        {
            return await _context.EventosNaturais
                .Select(e => new EventoNaturalResponseDTO
                {
                    Id = e.Id,
                    CriadoEm = e.CriadoEm,
                    Ocorrencia = e.Ocorrencia,
                    Tipo = e.Tipo,
                    Descricao = e.Descricao,
                    IdRegiao = e.IdRegiao
                }).ToListAsync();
        }

        /// <summary>
        /// Busca um evento natural por ID.
        /// </summary>
        public async Task<EventoNaturalResponseDTO?> BuscarPorIdAsync(long id)
        {
            var evento = await _context.EventosNaturais.FindAsync(id);
            if (evento == null) return null;

            return new EventoNaturalResponseDTO
            {
                Id = evento.Id,
                CriadoEm = evento.CriadoEm,
                Ocorrencia = evento.Ocorrencia,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                IdRegiao = evento.IdRegiao
            };
        }

        /// <summary>
        /// Atualiza um evento natural existente.
        /// </summary>
        public async Task<EventoNaturalResponseDTO> AtualizarAsync(long id, EventoNaturalRequestDTO dto)
        {
            var evento = await _context.EventosNaturais.FindAsync(id);
            if (evento == null)
                throw new Exception("Evento não encontrado.");

            var regiao = await _regiaoService.BuscarPorIdAsync(dto.IdRegiao);

            evento.Ocorrencia = dto.Ocorrencia;
            evento.Tipo = dto.Tipo;
            evento.Descricao = dto.Descricao;
            evento.IdRegiao = regiao.Id;

            await _context.SaveChangesAsync();

            return new EventoNaturalResponseDTO
            {
                Id = evento.Id,
                CriadoEm = evento.CriadoEm,
                Ocorrencia = evento.Ocorrencia,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                IdRegiao = evento.IdRegiao
            };
        }

        /// <summary>
        /// Remove um evento natural do sistema.
        /// </summary>
        public async Task RemoverAsync(long id)
        {
            var evento = await _context.EventosNaturais.FindAsync(id);
            if (evento == null)
                throw new Exception("Evento não encontrado.");

            _context.EventosNaturais.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
