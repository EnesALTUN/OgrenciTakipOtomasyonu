using DevExpress.XtraEditors;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckEdit : CheckEdit, IStatusBarAciklama
    {
        public MyCheckEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.Transparent;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
    }
}
