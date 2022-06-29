using Telemetrix.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Telemetrix.API.Context
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
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoEntradaMeta> TiposEntradasMetas { get; set; }

    }
}
