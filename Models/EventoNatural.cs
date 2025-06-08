using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_EVENTO_NATURAL")]
    public class EventoNatural
    {
        [Key]
        [Column("ID_EVENTO_NATURAL")]
        public long Id { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("DT_OCORRENCIA")]
        public DateTime Ocorrencia { get; set; }

        [Column("DS_DESCRICAO")]
        [MaxLength(255)]
        public string? Descricao { get; set; }

        [Required]
        [Column("DS_TIPO")]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [Column("ID_REGIAO")]
        public long IdRegiao { get; set; }

        [ForeignKey("IdRegiao")]
        public Regiao Regiao { get; set; }
    }
}
