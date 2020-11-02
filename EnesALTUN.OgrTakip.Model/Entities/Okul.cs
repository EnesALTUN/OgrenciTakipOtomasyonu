using EnesALTUN.OgrTakip.Model.Entities.Base;

namespace EnesALTUN.OgrTakip.Model.Entities
{
    public class Okul : BaseEntity
    {
        public string OkulAdi { get; set; }
        public long IlId { get; set; }
        public long IlceId { get; set; }
        public string Aciklama { get; set; }
        public Il Il { get; set; }
        public Ilce Ilce { get; set; }
    }
}
