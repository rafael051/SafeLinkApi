using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_RELATO_USUARIO")]
    public class RelatoUsuario
    {
        [Key]
        [Column("ID_RELATO_USUARIO")]
        public long Id { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("DT_RELATO")]
        public DateTime DataRelato { get; set; }

        [Required]
        [Column("DS_MENSAGEM")]
        [MaxLength(255)]
        public string Mensagem { get; set; }

        [Required]
        [Column("ID_USUARIO")]
        public long IdUsuario { get; set; }

        [Required]
        [Column("ID_REGIAO")]
        public long IdRegiao { get; set; }

        // 🔗 Relacionamentos
        [ForeignKey("IdUsuario")]
        public User Usuario { get; set; }

        [ForeignKey("IdRegiao")]
        public Regiao Regiao { get; set; }
    }
}
