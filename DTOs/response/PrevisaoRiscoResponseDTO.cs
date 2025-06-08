namespace SafeLinkApi.DTOs.Response
{
    public class PrevisaoRiscoResponseDTO
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime GeradoEm { get; set; }
        public string? Fonte { get; set; }
        public string NivelPrevisto { get; set; }
        public long IdRegiao { get; set; }
    }
}
