using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.DTOs.Request;
using SafeLinkApi.DTOs.Response;
using SafeLinkApi.Models;

namespace SafeLinkApi.Services
{
    /// <summary>
    /// Classe responsável pelas regras de negócio relacionadas à entidade EventoNatural.
    /// </summary>
    public class EventoNaturalService
    {
        private readonly ApplicationDbContext _context;

        public EventoNaturalService(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // POST: Criar um novo evento natural
        // =====================================================
        public async Task<EventoNaturalResponseDTO> CriarAsync(EventoNaturalRequestDTO dto)
        {
            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada.");

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
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // GET: Listar todos os eventos naturais
        // =====================================================
        public async Task<List<EventoNaturalResponseDTO>> ListarAsync()
        {
            return await _context.EventosNaturais
                .Include(e => e.Regiao)
                .Select(e => new EventoNaturalResponseDTO
                {
                    Id = e.Id,
                    CriadoEm = e.CriadoEm,
                    Ocorrencia = e.Ocorrencia,
                    Tipo = e.Tipo,
                    Descricao = e.Descricao,
                    NomeRegiao = e.Regiao.NomeRegiao
                })
                .ToListAsync();
        }

        // =====================================================
        // GET: Buscar evento por ID
        // =====================================================
        public async Task<EventoNaturalResponseDTO?> BuscarPorIdAsync(long id)
        {
            var evento = await _context.EventosNaturais
                .Include(e => e.Regiao)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
                return null;

            return new EventoNaturalResponseDTO
            {
                Id = evento.Id,
                CriadoEm = evento.CriadoEm,
                Ocorrencia = evento.Ocorrencia,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                NomeRegiao = evento.Regiao.NomeRegiao
            };
        }

        // =====================================================
        // PUT: Atualizar um evento natural existente
        // =====================================================
        public async Task<EventoNaturalResponseDTO> AtualizarAsync(long id, EventoNaturalRequestDTO dto)
        {
            var evento = await _context.EventosNaturais.FindAsync(id)
                ?? throw new Exception("Evento não encontrado.");

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(r => r.NomeRegiao == dto.NomeRegiao)
                ?? throw new Exception("Região não encontrada.");

            evento.Ocorrencia = dto.Ocorrencia;
            evento.Tipo = dto.Tipo;
            evento.Descricao = dto.Descricao;
            evento.IdRegiao = regiao.Id;

            _context.EventosNaturais.Update(evento);
            await _context.SaveChangesAsync();

            return new EventoNaturalResponseDTO
            {
                Id = evento.Id,
                CriadoEm = evento.CriadoEm,
                Ocorrencia = evento.Ocorrencia,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                NomeRegiao = regiao.NomeRegiao
            };
        }

        // =====================================================
        // DELETE: Remover evento natural por ID
        // =====================================================
        public async Task RemoverAsync(long id)
        {
            var evento = await _context.EventosNaturais.FindAsync(id)
                ?? throw new Exception("Evento não encontrado.");

            _context.EventosNaturais.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
