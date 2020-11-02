using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCardEdit : MyTextEdit
    {
        public MyCardEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;    // Yazı ortalama
            Properties.Mask.MaskType = MaskType.Regular;    // Kendimize özgü maske tanımlayacağımızı belirttik
            Properties.Mask.EditMask = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?";  // d? in anlamı rakam girişi olabileceği ve null olacabileceği
            Properties.Mask.AutoComplete = AutoCompleteType.None;   // Boş bırakılan rakamları 0 olarak tamamlamaması için kullandık.
            StatusBarAciklama = "Kart No Giriniz.";
        }
    }
}
