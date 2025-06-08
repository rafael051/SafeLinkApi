namespace SafeLinkApi.DTOs.Response
{
    /// <summary>
    /// DTO de resposta para os relatos enviados por usuários.
    /// Contém informações da data, mensagem, email do usuário e nome da região.
    /// </summary>
    public class RelatoUsuarioResponseDTO
    {
        /// <summary>
        /// Identificador único do relato.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Data e hora em que o relato foi cadastrado no sistema.
        /// </summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>
        /// Data e hora em que o usuário registrou o relato.
        /// </summary>
        public DateTime DataRelato { get; set; }

        /// <summary>
        /// Conteúdo descritivo informado pelo usuário no relato.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// E-mail do usuário que realizou o relato.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nome da região associada ao relato.
        /// </summary>
        public string NomeRegiao { get; set; }
    }
}
