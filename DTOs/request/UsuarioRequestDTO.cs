using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SafeLinkApi.DTOs.Request
{
    /// <summary>
    /// DTO utilizado para criar um novo usuário no sistema.
    /// Contém os dados essenciais para autenticação e definição de permissões.
    /// </summary>
    public class UsuarioRequestDTO
    {
        /// <summary>
        /// Endereço de e-mail do usuário. Usado para login e comunicação.
        /// </summary>
        [Required]
        [EmailAddress]
        [DefaultValue("usuario@email.com")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Senha de acesso do usuário. Será armazenada de forma segura (criptografada).
        /// </summary>
        [Required]
        [DefaultValue("123456")]
        [JsonPropertyName("senha")]
        public string Senha { get; set; }

        /// <summary>
        /// Tipo de papel do usuário no sistema: "ADMIN" ou "USER".
        /// </summary>
        [Required]
        [DefaultValue("USER")]
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
