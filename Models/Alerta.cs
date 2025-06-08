using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_ALERTA")]
    public class Alerta
    {
        [Key]
        [Column("ID_ALERTA")]
        public long Id { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("DT_EMITIDO_EM")]
        public DateTime EmitidoEm { get; set; }

        [Required]
        [Column("DS_MENSAGEM")]
        [MaxLength(255)]
        public string Mensagem { get; set; }

        [Required]
        [Column("DS_NIVEL_RISCO")]
        [MaxLength(50)]
        public string NivelRisco { get; set; } // ALTO, MÉDIO, BAIXO

        [Required]
        [Column("ID_REGIAO")]
        public long IdRegiao { get; set; }

        // 🔗 Relação com Regiao (1:N)
        [ForeignKey("IdRegiao")]
        public Regiao Regiao { get; set; }
    }
}
