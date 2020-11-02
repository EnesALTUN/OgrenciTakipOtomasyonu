using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarKisaYol
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;    // Yazı girişi engellendi
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
