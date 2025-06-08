using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_REGIAO")]
    public class Regiao
    {
        [Key]
        [Column("ID_REGIAO")]
        public long Id { get; set; }

        [Required]
        [Column("NM_CIDADE")]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [Required]
        [Column("SG_ESTADO")]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [Column("VL_LATITUDE")]
        public double Latitude { get; set; }

        [Required]
        [Column("VL_LONGITUDE")]
        public double Longitude { get; set; }

        [Required]
        [Column("NM_REGIAO")]
        [MaxLength(255)]
        public string NomeRegiao { get; set; }

        // 🔗 Relacionamentos 1:N
        public ICollection<Alerta>? Alertas { get; set; }
        public ICollection<EventoNatural>? EventosNaturais { get; set; }
        public ICollection<PrevisaoRisco>? PrevisoesRisco { get; set; }
        public ICollection<RelatoUsuario>? RelatosUsuario { get; set; }
    }
}
