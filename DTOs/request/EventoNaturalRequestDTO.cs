using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para registrar manualmente eventos naturais extremos no sistema.
    /// Ex: enchentes, deslizamentos, secas, entre outros.
    /// </summary>
    public class EventoNaturalRequestDTO
    {
        /// <summary>
        /// Data e hora da ocorrência do evento natural.
        /// </summary>
        [Required]
        [DefaultValue("04/06/2025 23:15:00")]
        [JsonPropertyName("ocorrencia")]
        public DateTime Ocorrencia { get; set; }

        /// <summary>
        /// Tipo do evento (ex: ENCHENTE, DESLIZAMENTO, SECA, OUTRO).
        /// </summary>
        [Required]
        [DefaultValue("ENCHENTE")]
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        /// <summary>
        /// Descrição adicional com detalhes do evento (opcional).
        /// </summary>
        [DefaultValue("Rio transbordou após fortes chuvas.")]
        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Identificador da região onde o evento foi registrado.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        [JsonPropertyName("idRegiao")]
        public long IdRegiao { get; set; }
    }
}
