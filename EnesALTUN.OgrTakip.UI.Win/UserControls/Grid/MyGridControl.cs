using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Mask;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Registrator;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Grid
{
    [ToolboxItem(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridView");
            view.Appearance.ViewCaption.ForeColor = Color.Maroon;   // GridControl başlık rengi
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;   // Column başlık renkleri
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;  // Column başlıkları ortalı
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);   // 8.25f deki f nin anlamı float a çevirme

            // Menülerin üzerine sağ tıklayınca açılan menüyü kapattık.
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;  // Enter a bastıkça sıradaki column a geç

            view.OptionsPrint.AutoWidth = false;    // Yazıcıya gönderirken genişlikleri biz nasıl ayarladıysak öyle göndersin
            view.OptionsPrint.PrintFooter = false;  // Footer bölümünü yazıcıya gönderme
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;  // filtre alanı açık gelsin
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;   // Column lar sabit genişlikte kalsın
            view.OptionsView.RowAutoHeight = true;  // Birden fazla satırlı birşey yazılırsa hepsini göster
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;  // Column başlığının üzerine gelince filtrenin buton olarak çıkması
            
            // GridView oluşturulurken otomatik olarak 2 sütun ekledik
            var idColumn = new GridColumn
            {
                Caption = "Id",
                FieldName = "Id"  // Buraya databaseden gönderilen verinin kolon adı
            };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false; // Id sütunu CustomizationForm da görünmesin
            view.Columns.Add(idColumn);

            var kodColumn = new GridColumn
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.AppearanceCell.Options.UseTextOptions = true; // Text üzerinde yapılan ayarlamaları aktifleştirmek için
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            view.Columns.Add(kodColumn);

            return view;
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)   // Kendi oluşturduğumuz GridView i kullanmak için ekledik
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }
        private class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView";    // Ad ver
            public override BaseView CreateView(GridControl grid)  => new MyGridView(grid);
        }
    }
    public class MyGridView : GridView, IStatusBarKisaYol
    {
        #region Properties
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion
        public MyGridView() {   }   // GridView i sürükleyip forma bıraktığımızda oluşturması için
        public MyGridView(GridControl ownerGrid) : base(ownerGrid) { }   // Üstte return edilen MyGridView in parametresini eklemek için
        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))  // GridControl' e Column ekleyip ColumnEdit'ten RepositoryItem' ı Date seçtiğimizde
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;    // Yazıyı Ortala
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;    // Günü yazınca otomatik olarak aya, ayı yazıncada otomatik olarak yıla geçmesi / ColumnEdit' in tipini değiştirdik
            }
        }
        protected override GridColumnCollection CreateColumnCollection() => new MyGridColumnCollection(this);  // Column eklenmesi durumunda müdahale etmek için oluşturduk.
        private class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) {   }

            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false; // Oluşturulan Column ların AllowEdit' ini varsayılan olarak false ayarladık.
                return column;
            }
        }
    }
    public class MyGridColumn : GridColumn, IStatusBarKisaYol
    {
        #region Properties
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; } 
        #endregion
    }
}
