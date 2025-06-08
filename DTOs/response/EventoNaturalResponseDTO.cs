namespace SafeLinkApi.DTOs.Response
{
    public class EventoNaturalResponseDTO
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime Ocorrencia { get; set; }
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public long IdRegiao { get; set; }
    }
}
