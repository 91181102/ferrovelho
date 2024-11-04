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
    public partial class TelaFrenteLojaOperacao : Form
    {
        private Label lb_opcao;
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        public TelaFrenteLojaOperacao() {
            InitializeComponent();
            this.SetEvents();
            this.btnVenda.Focus();
        }

        public void SetLabelOpcao(Label lb_opcao) {
            this.lb_opcao = lb_opcao;
        }

        private void SetEvents() {
            this.btns.Add(new Dados.MButton(btnCompra, btnCompra_Click));
            this.btns.Add(new Dados.MButton(btnVenda, btnVenda_Click));
        }

        private void btnVenda_Click() {
            this.lb_opcao.Text = "VENDA";
            this.Close();
        }

        private void btnCompra_Click() {
            this.lb_opcao.Text = "COMPRA";
            this.Close();
        }

        
    }
}
