using EnesALTUN.OgrTakip.Model.Entities.Base;

namespace EnesALTUN.OgrTakip.Model.Entities
{
    public class Ilce : BaseEntityDurum
    {
        public string IlceAdi { get; set; }
        public long IlId { get; set; }
        public string Aciklama { get; set; }
        public Il Il { get; set; }  // Il Entity' sine bağlandı. İlişkiyi kurarken kendisi otomatik olarak sonuna "Id" yazısını ekleyip Ilce tablosunda bu alanı arıyor. +
                                    //Bulursa bağlıyor, bulamazsa Il_Id şeklinde alan oluşturup bağlantıyı yapıyor.

        /* Farklı isimlere sahip alan adlarını birbirine bağlamak için kullanılacak yapı ise şu şekildedir.
        
        public long IllerId { get; set; }

        [ForeignKey("IllerId")]
        public Il Il { get; set; }

        */
    }
}
