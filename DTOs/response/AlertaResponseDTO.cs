namespace SafeLinkApi.DTOs.Response
{
    /// <summary>
    /// DTO de resposta para dados de Alerta.
    /// </summary>
    public class AlertaResponseDTO
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime EmitidoEm { get; set; }
        public string Mensagem { get; set; }
        public string NivelRisco { get; set; }

        /// <summary>
        /// Nome da região associada ao alerta.
        /// </summary>
        public string NomeRegiao { get; set; }
    }
}
