using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.View
{
    public partial class TelaFrenteCaixaFechar: Form
    {
        private List<MButton> btns = new List<MButton>();
        public bool IsConfirmed = false;
        private Models.Movimento movimento;
        private Models.Pagamento p;

        #region: Construtor
        public TelaFrenteCaixaFechar() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaFrenteCaixaFechar_Load(object sender, EventArgs e) {
            this.SetcomboBox();
            this.FillForm();
        }

        private void SetEvents() {
            this.Load += new EventHandler(TelaFrenteCaixaFechar_Load);
            this.btns.Add(new MButton(btnCancelar, btnCancelar_Click));
            this.btns.Add(new MButton(btnConfirmar, btnConfirmar_Click));
            this.txt_desconto.Leave += new EventHandler(this.txt_desconto_Leave);
            this.txt_desconto.KeyDown += new KeyEventHandler(this.txt_desconto_KeyDown);
            this.txt_valor_pago.Leave += new EventHandler(this.txt_valor_pago_Leave);
            this.txt_valor_pago.KeyDown += new KeyEventHandler(this.txt_valor_pago_KeyDown);
            this.txt_vl_pedido.KeyDown += new KeyEventHandler(this.txt_vl_pedido_KeyDown);
            this.txt_acrescimo.KeyDown += new KeyEventHandler(this.txt_acrescimo_KeyDown);
            this.txt_acrescimo.Leave += new EventHandler(this.txt_acrescimo_Leave);
            MTextBox.SetDecimal(txt_desconto);
            MTextBox.SetDecimal(txt_valor_pago);
            MTextBox.SetDecimal(txt_acrescimo);
        }

        public void SetMovimento(Models.Movimento movimento) {
            this.movimento = movimento;
        }

        private void SetcomboBox() {
            var i = Rotas.pagamento_tipo.GetIntent();
            MComboBox.SetComboBox(cbo_forma_pagamento, i);
        }

        private void FillForm() {
            if (movimento == null) return;
            this.txt_vl_pedido.Text = movimento.valor_total.ToString("n3");
            this.txt_total_pagar.Text = movimento.GetTotalAPagar().ToString("n3");
            if (movimento.tipo == "E") {
                this.txt_valor_pago.Text = this.txt_vl_pedido.Text;
            }
        }
        #endregion

        #region: Eventos de TextBox
        private void txt_acrescimo_Leave(object sender, EventArgs e) {
            this.CheckValues();
        }
        private void txt_desconto_Leave(object sender, EventArgs e) {
            //this.CheckDesconto();
            this.CheckValues();
        }

        private void txt_valor_pago_Leave(object sender, EventArgs e) {
            //this.CheckValorPago();
            this.CheckValues();
        }

        public void txt_acrescimo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.CheckValues();
                //this.txt_desconto.Focus();
                this.txt_valor_pago.Focus();
            }
        }

        public void txt_desconto_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                //this.CheckDesconto();
                this.CheckValues();
                txt_acrescimo.Focus(); }
        }

        public void txt_valor_pago_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                //this.CheckValorPago();
                this.CheckValues();
                btnConfirmar.Focus(); }
        }

        public void txt_vl_pedido_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txt_desconto.Focus();
            }
        }
        #endregion

        #region: Eventos de botões
        private void btnConfirmar_Click() {
            if (IsValid()) {
                movimento.desconto = MTextBox.GetDecimal(this.txt_desconto);
                movimento.troco = MTextBox.GetDecimal(this.txt_acrescimo);
                movimento.pagamentos.Add(p.Copy());
                movimento.IsValid();
                FecharPedido(); }
            else {
                _MsgBox.Error(p.GetErro());
                txt_valor_pago.Focus(); }
        }

        private void btnCancelar_Click() {
            movimento.pagamentos.Clear();
            this.Close();
        }
        #endregion

        #region: Operações
        public bool IsValid() {
            p = new Models.Pagamento();
            p.movimento_id = movimento.id;
            p.pagamento_tipo_id = MComboBox.GetIdByIndex(cbo_forma_pagamento);
            p.pagamento_tipo = cbo_forma_pagamento.Text;
            p.valor_pago = MTextBox.GetDecimal(this.txt_valor_pago) - MTextBox.GetDecimal(this.txt_troco);
            p.usuario_id = Rotas.user.id;
            p.usuario = Rotas.user.nome;
            return p.IsValid();
        }

        public void FecharPedido() {
            if (MTextBox.GetDecimal(txt_total_pagar) == 0) {
                this.IsConfirmed = true;
                movimento.situacao = "P";
                this.lb_status.Text = "Registrando operação. Aguarde...";
                //this.RegistrarOperacao();
                this.Close();
            } else {
                txt_vl_pedido.Text = txt_total_pagar.Text;
                txt_troco.Text = "0,000";
                txt_desconto.Text = "0,000";
                txt_acrescimo.Text = "0,000";
                txt_desconto.Enabled = false;
                txt_valor_pago.Clear();
                txt_valor_pago.Focus();
            }
        }
        
        public void CheckDesconto() {
            //var desconto = MTextBox.GetDecimal(this.txt_desconto);
            //txt_total_pagar.Text = Convert.ToString(MTextBox.GetDecimal(txt_vl_pedido) - desconto);
        }

        public void CheckValorPago() {
            //var valor_pago = MTextBox.GetDecimal(this.txt_valor_pago);
            //var desconto = MTextBox.GetDecimal(this.txt_desconto);
            //var total_pagar = MTextBox.GetDecimal(txt_vl_pedido) - desconto - valor_pago;
            //txt_total_pagar.Text = total_pagar.ToString("n3");
        }

        public void CheckValues() {
            var valor_pago = MTextBox.GetDecimal(this.txt_valor_pago);
            var desconto = MTextBox.GetDecimal(this.txt_desconto);
            var acrescimo = MTextBox.GetDecimal(this.txt_acrescimo);
            var total_pagar = MTextBox.GetDecimal(txt_vl_pedido) - desconto - valor_pago + acrescimo;
            decimal troco = 0;
            if (total_pagar < 0) {
                troco = total_pagar * -1;
                total_pagar = 0; }
            txt_total_pagar.Text = total_pagar.ToString("n3");
            txt_troco.Text = troco.ToString("n3");
        }
        
        private void RegistrarOperacao() {
            

        }
        #endregion
    }
}

