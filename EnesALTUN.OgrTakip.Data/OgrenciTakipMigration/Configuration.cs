using EnesALTUN.OgrTakip.Data.Contexts;
using System.Data.Entity.Migrations;

namespace EnesALTUN.OgrTakip.Data.OgrenciTakipMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;  // Otomatik olarak yap
            AutomaticMigrationDataLossAllowed = true;   // Migration işlemi sırasında veri kaybı olsun mu?
            // Örneğin long tipindeki bi değişkeni int e dönüştürürken veri kaybı yaşanabilir. Buna izin verdik
        }
    }
}
