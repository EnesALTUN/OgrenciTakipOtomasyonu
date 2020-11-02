using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace EnesALTUN.OgrTakip.Data.Contexts
{
    public class BaseDbContext<TContext, TConfiguration> : DbContext where TContext : DbContext where TConfiguration : DbMigrationsConfiguration<TContext>, new()
        // TContext' e OgrenciTakipContextlerden birini, TConfiguration a ise Migrationdaki configuration işlemlerini takip edicez
        // where komutlarıyla bu parametrelerin hangi tipte olduğunu belirledik
    {
        private static string _nameOrConnectionString = typeof(TContext).Name;
        public BaseDbContext():base(_nameOrConnectionString) {   }
        public BaseDbContext(string connectionString):base(connectionString)
        {
            // Entity lerde bir değişiklik varsa alttaki kod ile bunu günceller.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TConfiguration>());
            _nameOrConnectionString = connectionString;
        }
    }
}
