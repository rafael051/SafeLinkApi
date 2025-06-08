using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para registrar uma nova previsão de risco.
    /// Representa previsões emitidas por IA, modelos climáticos ou sensores.
    /// </summary>
    public class PrevisaoRiscoRequestDTO
    {
        /// <summary>
        /// Data e hora em que a previsão foi gerada.
        /// </summary>
        [Required]
        [DefaultValue("06/06/2025 08:30:00")]
        [JsonPropertyName("geradoEm")]
        public DateTime GeradoEm { get; set; }

        /// <summary>
        /// Fonte da previsão (modelo climático, IA, satélite, etc.).
        /// </summary>
        [DefaultValue("IA-Meteorologia V2")]
        [JsonPropertyName("fonte")]
        public string? Fonte { get; set; }

        /// <summary>
        /// Grau de risco previsto: ALTO, MÉDIO ou BAIXO.
        /// </summary>
        [Required]
        [DefaultValue("MÉDIO")]
        [JsonPropertyName("nivelPrevisto")]
        public string NivelPrevisto { get; set; }

        /// <summary>
        /// Identificador da região associada à previsão.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        [JsonPropertyName("idRegiao")]
        public long IdRegiao { get; set; }
    }
}
