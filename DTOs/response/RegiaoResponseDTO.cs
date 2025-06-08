namespace SafeLinkApi.DTOs.Response
{
    public class RegiaoResponseDTO
    {
        public long Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string NomeRegiao { get; set; }
    }
}
