using DevExpress.XtraEditors;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MySimpleButton : SimpleButton, IStatusBarAciklama
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;
        }

        public string StatusBarAciklama { get; set; }
    }
}
