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
            // Eklememizin sebebi bir entity den verileri okurken o entity ile ili�kili olan t�m entitylerdeki verileride getirir.
            Configuration.LazyLoadingEnabled = false;
        }

        public OgrenciTakipContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Eklememizin sebebi Entity ler database de olu�turulurken sonuna �o�ul eki getiriliyor. Bu ayar� kapatt�k. Okul > Okuls gibi
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Bire �ok ili�kili tablolarda herhangi bir veri silindi�in ba�l� olan di�er verilerde silinsin mi? Bu ayar� kapatt�k. ��nk� buras� genel ayarlarlamalar�n yap�ld��� b�l�m
            // �rne�in il tablosunda istanbul'u sildi�imizde il�e tablosunda istanbul' a ba�l� t�m veriler silinsin mi? i�lemi. Ancak bu ayar� �zel olarak ayarlayaca��z.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // �sttekinin ayn�s� tek fark� �oktan �o�a ili�kili tablolar i�in ge�erli
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
    }
}