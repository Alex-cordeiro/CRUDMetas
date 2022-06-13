using CRUDMetasAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CRUDMetasAPI.Context
{
    public class MetasContext : DbContext
    {
        public MetasContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true)
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Filial> Filial { get; set; }
        public DbSet<PecasEServicos> PecasEServicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
