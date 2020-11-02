using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    public class MyPictureEdit : PictureEdit, IStatusBarKisaYol
    {
        [ToolboxItem(true)]
        public MyPictureEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.Appearance.ForeColor = Color.Maroon;
            Properties.NullText = "Resim Yok";
            Properties.SizeMode = PictureSizeMode.Stretch;  // Resmi Yay
            Properties.ShowMenu = false;    // Resmin üzerine gelindiğinde yakınlaştır, uzaklaştır vs. gibi menünün açılmaması
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
