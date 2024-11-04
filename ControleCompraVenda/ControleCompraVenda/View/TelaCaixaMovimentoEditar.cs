using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.View
{
    public partial class TelaCaixaMovimentoEditar : Form
    {
        private List<Dados.MButton> btns = new List<Dados.MButton>();

        #region: Construtor
        public TelaCaixaMovimentoEditar() {
            InitializeComponent();
            this.SetEvents();
        }

        public void TelaCaixaMovimentoEditar_Load(object sender, EventArgs e) {

        }
           
        private void SetEvents() {
            this.Load += new EventHandler(this.TelaCaixaMovimentoEditar_Load);
            this.btns.Add(new Dados.MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new Dados.MButton(btnSalvar, this.btnSalvar_Click));
            this.btns.Add(new Dados.MButton(btnExcluir, btnExcluir_Click));
        } 
        #endregion

        #region: Evento de botões
        private void btnSalvar_Click() {

        }

        private void btnExcluir_Click() {

        }

        private void btnSair_Click() {

        }
        #endregion

        #region: Operações

        #endregion
    }
}
