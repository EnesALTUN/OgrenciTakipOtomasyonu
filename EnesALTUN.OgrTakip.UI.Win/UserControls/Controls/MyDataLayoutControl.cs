using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false;    // DataLayout' un kendi düzenindeki TabIndex' i iptal ettik.
        }
        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);    // Bizim layoutumuzu döndürsün ve parametre olarak bu sınıfı baz alsın
        }
    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor    
    {
        public MyLayoutControlImplementor(ILayoutControlOwner controlOwner) : base(controlOwner)
        {
            
        }
        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent) // Layout itemlerimizi oluşturmak için
        {
            var item = base.CreateLayoutItem(parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;    // Form'a eklediğimizde renk ayarı
            return item;
        }
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)   // Layout gruplarımızı oluşturmak için
        {
            var grp = base.CreateLayoutGroup(parent);
            grp.LayoutMode = LayoutMode.Table;  // Varsayılan olarak table modu seçildi

            #region Sütun
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;

            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent;   // Yüzdeli olarak vericez
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;

            grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 80 });   // Yeni sütun ekleme
            grp.OptionsTableLayoutGroup.ColumnDefinitions[2].SizeType = SizeType.Percent;   // Yüzdeli olarak vericez
            grp.OptionsTableLayoutGroup.ColumnDefinitions[2].Width = 100;
            #endregion

            #region Satır
            grp.OptionsTableLayoutGroup.RowDefinitions.Clear(); // Oluşturulan satırları sil

            for (int i = 0; i < 9; i++) // 10 Satırdan oluşsun ve son satır yüksekliği yüzdeli olsun
            {
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Absolute,
                    Height = 24
                });

                if (i + 1 != 9) continue;  // Son satıra gelene kadar alttaki kodları çalıştırma

                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = SizeType.Percent,
                    Height = 100
                });
            }
            #endregion

            return grp;
        }
    }
}
