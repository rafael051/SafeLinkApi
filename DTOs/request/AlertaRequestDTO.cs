using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para cadastrar um novo alerta no sistema.
    /// Representa alertas automáticos emitidos com base em dados de risco.
    /// </summary>
    public class AlertaRequestDTO
    {
        /// <summary>
        /// Data e hora da emissão do alerta.
        /// </summary>
        [Required]
        [DefaultValue("05/06/2025 14:00:00")]
        [JsonPropertyName("emitidoEm")]
        public DateTime EmitidoEm { get; set; }

        /// <summary>
        /// Texto explicativo do alerta.
        /// </summary>
        [Required]
        [DefaultValue("Risco de deslizamento em região montanhosa.")]
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        /// <summary>
        /// Grau de risco associado ao alerta: ALTO, MÉDIO ou BAIXO.
        /// </summary>
        [Required]
        [DefaultValue("ALTO")]
        [JsonPropertyName("nivelRisco")]
        public string NivelRisco { get; set; }

        /// <summary>
        /// Nome da região que está recebendo o alerta.
        /// </summary>
        [Required]
        [DefaultValue("Centro")]
        [JsonPropertyName("nomeRegiao")]
        public string NomeRegiao { get; set; }
    }
}
