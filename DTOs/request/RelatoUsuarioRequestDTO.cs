using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para cadastrar um novo relato feito por um usuário do sistema.
    /// </summary>
    public class RelatoUsuarioRequestDTO
    {
        /// <summary>
        /// Data e hora em que o relato foi feito pelo usuário (formato: dd/MM/yyyy HH:mm:ss).
        /// </summary>
        [Required]
        [DefaultValue("05/06/2025 15:00:00")]
        [JsonPropertyName("dataRelato")]
        public DateTime DataRelato { get; set; }

        /// <summary>
        /// Mensagem ou descrição do relato feito pelo usuário.
        /// </summary>
        [Required]
        [DefaultValue("Ocorrência de alagamento próximo à ponte.")]
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        /// <summary>
        /// ID do usuário que realizou o relato.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        [JsonPropertyName("idUsuario")]
        public long IdUsuario { get; set; }

        /// <summary>
        /// ID da região associada ao relato.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        [JsonPropertyName("idRegiao")]
        public long IdRegiao { get; set; }
    }
}
