using EnesALTUN.OgrTakip.Data.OgrenciTakipMigration;
using EnesALTUN.OgrTakip.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EnesALTUN.OgrTakip.Data.Contexts
{
    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext,Configuration>
    {
        public OgrenciTakipContext()
        {
            // Eklememizin sebebi bir entity den verileri okurken o entity ile iliþkili olan tüm entitylerdeki verileride getirir.
            Configuration.LazyLoadingEnabled = false;
        }

        public OgrenciTakipContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Eklememizin sebebi Entity ler database de oluþturulurken sonuna çoðul eki getiriliyor. Bu ayarý kapattýk. Okul > Okuls gibi
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Bire çok iliþkili tablolarda herhangi bir veri silindiðin baðlý olan diðer verilerde silinsin mi? Bu ayarý kapattýk. Çünkü burasý genel ayarlarlamalarýn yapýldýðý bölüm
            // Örneðin il tablosunda istanbul'u sildiðimizde ilçe tablosunda istanbul' a baðlý tüm veriler silinsin mi? iþlemi. Ancak bu ayarý özel olarak ayarlayacaðýz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Üsttekinin aynýsý tek farký çoktan çoða iliþkili tablolar için geçerli
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
    }
}