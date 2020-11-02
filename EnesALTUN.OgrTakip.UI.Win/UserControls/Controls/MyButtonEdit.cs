using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EnesALTUN.OgrTakip.UI.Win.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace EnesALTUN.OgrTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)] // Toolbox menüsüne ekle
    public class MyButtonEdit : ButtonEdit, IStatusBarKisaYol
    {
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor; // Yazı yazamayı engelledik
            Properties.AppearanceFocused.BackColor = Color.LightCyan; // Arka plan rengi
        }
        public override bool EnterMoveNextControl { get; set; } = true; // Enter basınca z-index e göre bir sonraki componente geçme
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }

        #region Events
        private long? _id; // long? nin anlamı Nullable<long> ' un kısaltılmışı
        [Browsable(false)] // Properties menüsünde gizle
        public long? Id
        {
            get => _id; // => ' ün anlamı return
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return; // Aynı seçim yapılırsa yeniden seçim yapma olduğu gibi geri gönder
                _id = value;

                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
                //IdChanged?.Invoke(this, new IdChangedEventArgs(oldValue, newValue)); // if(IdChanged != null) yerine basit kullanım. Invoke çağırma/tetikleme
            }
        } 
        #endregion


        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { }; //delegate e eşitlemenin anlamı null olmasını engelleme yani boş bir delege atanıyor. Hafızada çok küçük bir yer kullanacağından önemi yok
    }

    public class IdChangedEventArgs : EventArgs 
    {
        public IdChangedEventArgs(long? oldValue, long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public long? OldValue { get; set; }
        public long? NewValue { get; set; }
    }
}
