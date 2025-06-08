namespace SafeLinkApi.DTOs.Response
{
    /// <summary>
    /// DTO de resposta para previsões de risco.
    /// Retorna os dados processados e armazenados no sistema.
    /// </summary>
    public class PrevisaoRiscoResponseDTO
    {
        /// <summary>
        /// Identificador único da previsão.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Data e hora em que a previsão foi registrada no sistema.
        /// </summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>
        /// Data e hora em que a previsão foi originalmente gerada.
        /// </summary>
        public DateTime GeradoEm { get; set; }

        /// <summary>
        /// Grau de risco previsto (BAIXO, MÉDIO ou ALTO).
        /// </summary>
        public string NivelPrevisto { get; set; }

        /// <summary>
        /// Fonte da previsão (ex: modelo climático, IA, satélite).
        /// </summary>
        public string? Fonte { get; set; }

        /// <summary>
        /// Nome da região associada à previsão.
        /// </summary>
        public string NomeRegiao { get; set; }
    }
}
