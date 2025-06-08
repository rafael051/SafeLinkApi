using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Models;

namespace SafeLinkApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Representa os usuários do sistema
        public DbSet<User> Users { get; set; }

        // Representa as regiões geográficas monitoradas
        public DbSet<Regiao> Regioes { get; set; }

        // Representa os alertas automáticos emitidos pelo sistema
        public DbSet<Alerta> Alertas { get; set; }

        // Representa os eventos naturais registrados
        public DbSet<EventoNatural> EventosNaturais { get; set; }

        // Representa as previsões de risco de eventos
        public DbSet<PrevisaoRisco> PrevisoesRisco { get; set; }

        // Representa os relatos enviados por usuários
        public DbSet<RelatoUsuario> RelatosUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define os nomes exatos das tabelas no banco (evita nomes pluralizados)
            modelBuilder.Entity<User>().ToTable("TB_USER");
            modelBuilder.Entity<Regiao>().ToTable("TB_REGIAO");
            modelBuilder.Entity<Alerta>().ToTable("TB_ALERTA");
            modelBuilder.Entity<EventoNatural>().ToTable("TB_EVENTO_NATURAL");
            modelBuilder.Entity<PrevisaoRisco>().ToTable("TB_PREVISAO_RISCO");
            modelBuilder.Entity<RelatoUsuario>().ToTable("TB_RELATO_USUARIO");
        }
    }
}
