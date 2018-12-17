using System.Data.Entity.Migrations;

namespace Xpto.Persistencia.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
