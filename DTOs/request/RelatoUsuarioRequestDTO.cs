using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para cadastrar um novo relato feito por um usuário do sistema.
    /// Usa o email e o nome da região como identificadores externos.
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
        /// E-mail do usuário que realizou o relato.
        /// Usado para buscar o usuário no backend.
        /// </summary>
        [Required]
        [DefaultValue("usuario@email.com")]
        [JsonPropertyName("emailUsuario")]
        public string Email { get; set; }

        /// <summary>
        /// Nome da região associada ao relato.
        /// Usado para buscar a região no backend.
        /// </summary>
        [Required]
        [DefaultValue("Centro")]
        [JsonPropertyName("nomeRegiao")]
        public string NomeRegiao { get; set; }
    }
}
