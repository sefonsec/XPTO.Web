using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Xpto.Modelo;

namespace Xpto.Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("XPTO")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ClienteProduto> ClientesProdutos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
