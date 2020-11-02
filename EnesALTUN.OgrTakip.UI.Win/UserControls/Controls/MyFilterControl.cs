using DevExpress.XtraEditors;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true; // Gruplama açıldı
        }
        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";
    }
}
