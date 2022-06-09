using CRUDMetasAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDMetasAPI.Context
{
    public class MetasContext : DbContext
    {
        public MetasContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaFilial> EmpresasFiliais { get; set; }
        public DbSet<Filial> Filial { get; set; }
        public DbSet<PecasEServicos> PecasEServicos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
