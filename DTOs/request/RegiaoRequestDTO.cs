using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para cadastrar uma nova região monitorada no sistema.
    /// </summary>
    public class RegiaoRequestDTO
    {
        /// <summary>
        /// Nome da cidade onde a região está localizada.
        /// </summary>
        [Required]
        [DefaultValue("São Paulo")]
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Sigla do estado (UF) correspondente à cidade.
        /// </summary>
        [Required]
        [DefaultValue("SP")]
        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Coordenada de latitude da região.
        /// </summary>
        [Required]
        [DefaultValue(-23.5505)]
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Coordenada de longitude da região.
        /// </summary>
        [Required]
        [DefaultValue(-46.6333)]
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Nome da subdivisão ou bairro específico dentro da cidade.
        /// </summary>
        [Required]
        [DefaultValue("Centro")]
        [JsonPropertyName("nomeRegiao")]
        public string NomeRegiao { get; set; }
    }
}
