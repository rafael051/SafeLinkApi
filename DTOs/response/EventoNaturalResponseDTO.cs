namespace SafeLinkApi.DTOs.Response
{
    /// <summary>
    /// DTO de resposta com os dados de um evento natural cadastrado.
    /// Agora retorna o nome da região em vez do ID numérico.
    /// </summary>
    public class EventoNaturalResponseDTO
    {
        public long Id { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime Ocorrencia { get; set; }

        public string Tipo { get; set; }

        public string? Descricao { get; set; }

        /// <summary>
        /// Nome da região onde o evento ocorreu.
        /// </summary>
        public string NomeRegiao { get; set; }
    }
}
