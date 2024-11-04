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
    public partial class TelaEmpresa : Form
    {
        private Empresa c = new Empresa();
        private List<MButton> btns = new List<MButton>();
        private MDataGridView dg;

        #region: Construtor
        public TelaEmpresa() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaUsuario_Load(object sender, EventArgs e) {
            this.RefreshGrid();
            //this.SetComboBox();
            this.SetGrid();
            this.DisableControls();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaUsuario_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new MButton(btnCancelar, this.btnCancelar_Click));
            this.btns.Add(new MButton(btnExcluir, this.btnExcluir_Click));
            this.btns.Add(new MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new MButton(btnNovo, this.btnNovo_Click));
            this.btns.Add(new MButton(btnSalvar, this.btnSalvar_Click));
        }

        //private void SetComboBox()
        //{
        //    var i = new Intent();
        //    i.PutExtra("ids", new string[] { "0", "1" });
        //    i.PutExtra("nomes", new string[] { "Usuário", "Administrador" });
        //    MComboBox.SetComboBox(cboTipo, i);
        //}

        private void SetGrid() {
            dg = new MDataGridView(this.dgDados);
            dg.setColumn("id", "ID", 40);
            dg.setColumn("nome", "NOME", 240);
            dg.setColumn("email", "E-MAIL", 100);
            dg.setColumn("cnpj", "CNPJ", 70);
            dg.setColumn("endereco", "ENDEREÇO", 170);
            dg.setColumn("telefone", "TEL.", 70);
            dg.setColumn("ativo", "A", 40, Align.Center);
            dg.setVisibleFalse("request");
            dg.RenderizeStyle(GridTheme.Green, false);
        }
        #endregion

        #region: Eventos de botões
        private void btnCancelar_Click() {
            this.DisableControls();
        }

        private void btnSair_Click() {
            this.Close();
        }

        private void btnSalvar_Click() {
            this.SetObject();
            if (!c.IsValid()) {
                Request.ShowError(c.GetErro());
                return; }
            this.Salvar();
        }

        private void btnExcluir_Click() {
            this.SetObject();
            this.Excluir();
        }

        private void btnNovo_Click() {
            this.EnableControls();
        }
        #endregion

        #region: Operações
        private void Salvar()
        {
            var result = new ResultRequest<object>();

            if (c.id < 1)
                result = c.Request.empresa.Insert();
            else
                result = c.Request.empresa.Update();

            if (!result.status)
            {
                Request.GetError(result.message);
                return;
            }
            this.DisableControls();
            this.RefreshGrid();
        }

        private void Excluir()
        {
            if (!Request.GetConfirm("Deseja excluir este cadastro ?"))
                return;
            var result = new ResultRequest<object>();
            result = c.Request.empresa.Delete(c.id);
            if (!result.status)
            {
                Request.GetError(result.message);
                return;
            }
            this.DisableControls();
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            var result = c.Request.empresa.FindAll();

            if (!result.status)
            {
                Request.GetError(result.message);
                return;
            }
            this.dgDados.DataSource = result.data;
        }

        private void LoadObject()
        {
            var result = c.Request.empresa.Find(c.id);

            if (!result.status)
            {
                Request.GetError(result.message);
                return;
            }
            c = result.data;
            this.FillForm();
        }

        private void FillForm()
        {
            this.txt_id.Text = c.id.ToString();
            this.txt_nome.Text = c.nome;
            this.txt_cnpj.Text = c.cnpj;
            this.txt_email.Text = c.email;
            this.txt_endereco.Text = c.endereco;
            this.txt_telefone.Text = c.telefone;
            this.chk_ativo.Checked = c.ativo;
            //MComboBox.setIndexById(cboTipo, c.tipo.ToString());
        }

        private void SetObject()
        {
            c.nome = this.txt_nome.Text;
            c.email = this.txt_email.Text;
            c.cnpj = this.txt_cnpj.Text;
            c.endereco = this.txt_endereco.Text;
            c.telefone = this.txt_telefone.Text;
            c.ativo = this.chk_ativo.Checked;
            //c.tipo = MComboBox.GetIdByIndex(cboTipo);
        }

        private void DisableControls()
        {
            this.txt_id.Clear();
            this.txt_email.Clear();
            this.txt_nome.Clear();
            this.txt_cnpj.Clear();
            this.txt_endereco.Clear();
            this.txt_telefone.Clear();
            this.chk_ativo.Checked = true;
            this.pn_top.Enabled = false;
            this.btnExcluir.Enabled = false;
            c.SetDefaultValues();
        }

        private void EnableControls()
        {
            this.pn_top.Enabled = true;
            this.txt_nome.Focus();
            if (c.id > 0) btnExcluir.Enabled = true;
        }
        #endregion

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            //dg.CurrentRow = e.RowIndex;
            c.id = (int)dg.getValue("id");
            this.LoadObject();
            this.EnableControls();
        }
    }
}
