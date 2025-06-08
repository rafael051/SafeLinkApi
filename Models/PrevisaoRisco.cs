using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_PREVISAO_RISCO")]
    public class PrevisaoRisco
    {
        [Key]
        [Column("ID_PREVISAO_RISCO")]
        public long Id { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("DT_GERADO_EM")]
        public DateTime GeradoEm { get; set; }

        [Column("DS_FONTE")]
        [MaxLength(255)]
        public string? Fonte { get; set; }

        [Required]
        [Column("DS_NIVEL_PREVISTO")]
        [MaxLength(50)]
        public string NivelPrevisto { get; set; } // ALTO, MÉDIO, BAIXO

        [Required]
        [Column("ID_REGIAO")]
        public long IdRegiao { get; set; }

        [ForeignKey("IdRegiao")]
        public Regiao Regiao { get; set; }
    }
}
