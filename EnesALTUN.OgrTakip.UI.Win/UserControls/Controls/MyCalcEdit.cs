using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Drawing;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCalcEdit : CalcEdit, IStatusBarKisaYol
    {
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;   // Boş geçilemez olması
            Properties.EditMask = "n2"; // Maskeleme yapılıyor. Virgülden sonra 2 basamak olması sağlandı
        }
        public override bool EnterMoveNextControl { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesi";
        public string StatusBarAciklama { get; set; }
    }
}
