using EnesALTUN.OgrTakip.Model.Entities.Base;

namespace EnesALTUN.OgrTakip.Model.Entities
{
    // Database e tablo olarak kaydolurken hangi isimde kaydolmasını istiyorsak şu şekilde ayarlayabiliyoruz.
    // [Table("Il1")]
    public class Il:BaseEntityDurum
    {
        public string IlAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
