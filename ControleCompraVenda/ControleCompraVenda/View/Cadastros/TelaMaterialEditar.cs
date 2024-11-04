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
using ControleCompraVenda.Models;

namespace ControleCompraVenda.View
{
    public partial class TelaMaterialEditar : Form
    {
        #region: Membros da classe
        private Material c;
        private List<MButton> btns = new List<MButton>();
        public bool isChanged = false;
        #endregion

        #region: Construtor
        public TelaMaterialEditar() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaMaterialEditar_Click(object sender, EventArgs e) {
            this.SetcomboBox();
            this.FillForm();
            this.txt_nome.Focus();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaMaterialEditar_Click);
            this.btns.Add(new MButton(btnCancelar, btnCancelar_Click));
            this.btns.Add(new MButton(btnExcluir, btnExcluir_Click));
            this.btns.Add(new MButton(btnSalvar, btnSalvar_Click));
            MTextBox.SetDecimal(this.txt_preco_compra);
            MTextBox.SetDecimal(this.txt_preco_venda);
        }

        public void SetId(int id, Material c) {
            c.id = id;
            this.c = c;
        }

        private void SetcomboBox() {
            var i = Rotas.material_tipo.GetIntent();
            MComboBox.SetComboBox(cbo_tipo_material, i);
        }
        #endregion

        #region: Evento de botões
        private void btnSalvar_Click() {
            this.SetObject();
            if (!c.IsValid()) {
                _MsgBox.Error(c.GetErro());
                return; }

            var result = new ResultRequest<object>();

            if (c.id < 1)
                result = c.Request.material.Insert();
            else
                result = c.Request.material.Update();

            if (!result.status) {
                _MsgBox.Error(result.message);
                return; }

            isChanged = true;
            btnCancelar_Click();
        }

        private void btnExcluir_Click() {
            if (!_MsgBox.Confirm("Deseja excluir este cadastro ?"))
                return;

            var result = new ResultRequest<object>();
            result = c.Request.material.Delete(c.id);
            if (!result.status) {
                _MsgBox.Error(result.message);
                return; }
            isChanged = true;
            btnCancelar_Click();
        }

        private void btnCancelar_Click() {
            this.btns = null;
            c.SetDefaultValues();
            this.Close();
        }
        #endregion

        private void FillForm() {
            if (c.id < 1) {
                this.btnExcluir.Enabled = false;
                return; };

            var result = c.Request.material.Find(c.id);
            if (result.status) {
                this.c = result.data; }

            this.txt_id.Text = c.id.ToString();
            this.txt_nome.Text = c.nome;
            this.txt_preco_compra.Text = c.preco_compra.ToString("n3");
            this.txt_preco_venda.Text = c.preco_venda.ToString("n3");
            this.chk_ativo.Checked = c.ativo;
            MComboBox.setIndexById(cbo_tipo_material, c.tipo_material_id.ToString());
        }

        private void SetObject() {
            c.ativo = this.chk_ativo.Checked;
            c.nome = this.txt_nome.Text;
            c.preco_compra = MTextBox.GetDecimal(txt_preco_compra);
            c.preco_venda = MTextBox.GetDecimal(txt_preco_venda);
            c.tipo_material_id = MComboBox.GetIdByIndex(cbo_tipo_material);
        }
    }
}
