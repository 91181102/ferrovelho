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
    public partial class TelaFrenteCaixaAlterarPreco : Form
    {
        #region: Construtor
        private List<MButton> btns = new List<MButton>();
        public bool IsChanged = false;
        private Models.MovimentoMaterial mov;
        #endregion

        #region: Construtor

        public TelaFrenteCaixaAlterarPreco() {
            InitializeComponent();
            this.SetEvents();
            this.txt_vl_unit_novo.Focus();
        }

        private void TelaFrenteCaixaAlterarPreco_Load(object sender, EventArgs e) {
            this.txt_vl_unit_anterior.Text = mov.vl_unit.ToString("n3");
            //this.txt_vl_unit_novo.Focus();
            //this.txt_vl_unit_novo.SelectAll();
            //_MsgBox.Sucess("");
        }

        private void SetEvents() {
            this.btns.Add(new MButton(btnConfirmar, this.btnConfirmar_Click));
            this.btns.Add(new MButton(btnCancelar, this.btnCancelar_Click));
            this.Load += new EventHandler(this.TelaFrenteCaixaAlterarPreco_Load);
            this.txt_vl_unit_novo.KeyDown += new KeyEventHandler(this.txt_vl_unit_novo_KeyDown);
        }

        public void SetMaterial(Models.MovimentoMaterial mov) {
            this.mov = mov;
        }
        #endregion

        #region: Evento de botões
        private void btnConfirmar_Click() {
            if (!IsValid()) return;
            this.IsChanged = true;
            this.mov.vl_unit = Convert.ToDecimal(this.txt_vl_unit_novo.Text);
            this.Close();
        }

        private void btnCancelar_Click() {
            this.Close();
        }
        #endregion

        #region: Operações

        private void txt_vl_unit_novo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnConfirmar_Click(); }
        }

        private bool IsValid() {
            if (string.IsNullOrEmpty(this.txt_vl_unit_novo.Text.Trim())) {
                _MsgBox.Error("Valor inválido.");
                return false;
            }

            if (Convert.ToDecimal(this.txt_vl_unit_novo.Text) < 0) {
                _MsgBox.Error("Valor não pode ser zerado.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
