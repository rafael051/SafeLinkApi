using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeLinkApi.Models
{
    [Table("TB_USER")]
    public class User
    {
        [Key]
        [Column("ID_USER")]
        public long Id { get; set; }

        [Required]
        [Column("DS_EMAIL")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Column("DS_SENHA")]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required]
        [Column("TP_ROLE")]
        [MaxLength(50)]
        public string Role { get; set; } // ADMIN ou USER

        // 🔗 Relacionamento 1:N com RelatoUsuario
        public ICollection<RelatoUsuario>? RelatosUsuario { get; set; }
    }
}
