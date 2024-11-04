using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    public class MToolTips<T>
    {
        private ToolTip Dicas { get; set; } = new ToolTip();
        private string Tips { get; set; } = "";

        public MToolTips(T obj, string tips) {
            this.Tips = tips;
            this.setDicas();
            this.setToolTip(obj);
        }

        private void setDicas() {
            Dicas.AutoPopDelay = 5000;
            Dicas.InitialDelay = 1000;
            Dicas.ReshowDelay = 500;
            Dicas.ShowAlways = true;
            Dicas.IsBalloon = true;
        }

        private void setToolTip(object sender) {
            try {
                Dicas.SetToolTip((Control)sender, Tips); }
            catch (Exception ex) { }
        }

        public static implicit operator MToolTips<T>(MToolTips<CheckBox> v) {
            throw new NotImplementedException();
        }
    }
}
