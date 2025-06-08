namespace SafeLinkApi.DTOs.Response
{
    public class RelatoUsuarioResponseDTO
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime DataRelato { get; set; }
        public string Mensagem { get; set; }
        public long IdUsuario { get; set; }
        public long IdRegiao { get; set; }
    }
}
