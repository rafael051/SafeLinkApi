namespace SafeLinkApi.DTOs.Response
{
    public class AlertaResponseDTO
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime EmitidoEm { get; set; }
        public string Mensagem { get; set; }
        public string NivelRisco { get; set; }
        public long IdRegiao { get; set; }
    }
}
