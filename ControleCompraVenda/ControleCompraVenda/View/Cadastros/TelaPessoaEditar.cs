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
    public partial class TelaPessoaEditar : Form
    {
        #region: Membros da classe
        private Pessoa c;
        private PessoaContato contato = new PessoaContato();
        private List<MButton> btns = new List<MButton>();
        public bool isChanged = false;
        private MDataGridView dg;
        #endregion

        public TelaPessoaEditar() {
            InitializeComponent();
            this.SetEvents();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaPessoaEditar_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new MButton(btnCancelar, btnCancelar_Click));
            this.btns.Add(new MButton(btnExcluir, btnExcluir_Click));
            this.btns.Add(new MButton(btnSalvar, btnSalvar_Click));
            this.btns.Add(new MButton(btnCancelarContato, btnCancelarContato_Click));
            this.btns.Add(new MButton(btnExcluirContato, btnExcluirContato_Click));
            this.btns.Add(new MButton(btnSalvarContato, btnSalvarContato_Click));
            this.btns.Add(new MButton(btnNovoContato, btnNovoContato_Click));
            MTextBox.SetNumeric(this.txt_cnpj_cpf);
        }

        private void TelaPessoaEditar_Load(object sender, EventArgs e) {
            this.chk_ativo.Checked = true;
            this.SetcomboBox();
            this.FillForm();
            this.txt_nome.Focus();
            this.pn_controls.Enabled = false;
            this.SetGrid();
        }

        public void SetId(int id, Pessoa c) {
            c.id = id;
            this.c = c;
        }

        private void SetcomboBox() {
            var i = contato.GetIntent();
            MComboBox.SetComboBox(cbo_tipo, i);
        }

        private void SetGrid() {
            dg = new MDataGridView(this.dgDados);
            dg.setVisibleFalse("id,request,pessoa_id,ativo");
            dg.setColumn("tipo", "T", 20, Align.Center);
            dg.setColumn("contato", "CONTATO", 150);
            dg.setColumn("obs", "OBS", 230);
            dg.RenderizeStyle(GridTheme.Green, false);
        }

        #region: Evento de botões
        private void btnCancelar_Click() {
            this.btns = null;
            c.SetDefaultValues();
            this.Close();
        }

        private void btnSalvar_Click() {
            if (this.Salvar()) {
                isChanged = true;
                btnCancelar_Click();
            }
        }

        private void btnExcluir_Click() {
            this.SetObject();

            if (c.id == 1) {
                _MsgBox.Error("Este contato é exclusivo do sistema." +
                    Environment.NewLine + "Não pode ser editado.");
                return; }

            if (!_MsgBox.Confirm("Deseja excluir este cadastro ?"))
                return;

            this.ExcluirContatos();

            var result = new ResultRequest<object>();
            result = c.Request.pessoa.Delete(c.id);
            if (!result.status) {
                _MsgBox.Error(result.message);
                return; }
            isChanged = true;
            btnCancelar_Click();
        }
        #endregion  
        
        /// <summary>
        /// Salva as alterações.
        /// </summary>
        private bool Salvar() {
            this.SetObject();

            if (c.id == 1) {
                _MsgBox.Error("Este contato é exclusivo do sistema." + 
                    Environment.NewLine + "Não pode ser editado.");
                return false; }

            if (!c.IsValid()) {
                _MsgBox.Error(c.GetErro());
                return false; }

            var result = new ResultRequest<object>();

            if (c.id < 1)
                result = c.Request.pessoa.Insert();
            else
                result = c.Request.pessoa.Update();

            if (!result.status) {
                _MsgBox.Error(result.message);
                return false; }
            return true;
        }      

        private void FillForm() {
            if (c.id < 1) {
                this.btnExcluir.Enabled = false;
                return; };

            var result = c.Request.pessoa.Find(c.id);
            if (result.status) {
                this.c = result.data;
                LoadContatos(); }

            this.txt_id.Text = c.id.ToString();
            this.txt_nome.Text = c.nome;
            this.txt_cnpj_cpf.Text = c.cnpj_cpf;
            this.txt_endereco.Text = c.endereco;
            this.txt_obs.Text = c.obs;
            this.chk_ativo.Checked = c.ativo;
        }
        
        private void SetObject() {
            c.ativo = this.chk_ativo.Checked;
            c.nome = this.txt_nome.Text;
            c.cnpj_cpf = this.txt_cnpj_cpf.Text;
            c.endereco = this.txt_endereco.Text;
            c.obs = this.txt_obs.Text;
        }

        #region: Operações com contatos 
        private void LoadContatos() {
            var result = contato.Request.FindAll(c.id);
            if (result.status) {
                c.contatos = result.data;
                this.contato.SetDefaultValues();
                this.dgDados.DataSource = c.contatos; }
        }

        /// <summary>
        /// Habilita campos de contatos.
        /// </summary>
        private void btnNovoContato_Click() {
            // Verifica se o contato atual já está salvo.
            if (c.id < 1) {
                // Se não conseguir salvar, encerra a rotina.
                if (!Salvar()) {
                    return; }
                var result = c.Request.pessoa.crud.GetLastID();
                if (result.status) {
                    c.id = (int)result.data;
                    this.txt_id.Text = c.id.ToString();
                    this.isChanged = true; } }

            this.EnableContatos();
            this.btnExcluirContato.Enabled = false;
        }

        private void btnSalvarContato_Click() {
            this.SetObjectContato();
            if (!contato.IsValid()) {
                _MsgBox.Error(contato.GetErro());
                this.txt_contato.Focus();
                return; }

            var result = new ResultRequest<object>();
            if (contato.id < 1)
                result = contato.Request.pessoa_contato.Insert();
            else
                result = contato.Request.pessoa_contato.Update();

            if (result.status) {
                this.LoadContatos();
                this.DisableContatos(); }
        }

        private void btnExcluirContato_Click() {
            if (!_MsgBox.Confirm("Deseja excluir este contato?"))
                return;

            var result = contato.Request.pessoa_contato.Delete(contato.id);
            if (!result.status) {
                _MsgBox.Error(result.message);
                return;
            }
            this.DisableContatos();
            this.LoadContatos();
        }

        private void btnCancelarContato_Click() {
            this.pn_controls.Enabled = false;
        }

        /// <summary>
        /// Exclui os contatos antes de excluir o cadastro da pessoa,
        /// </summary>
        private void ExcluirContatos() {
            if (c.contatos.Count() == 0)
                return;
            foreach (PessoaContato item in c.contatos)
                item.Request.pessoa_contato.Delete(item.id);
        }

        private void SetObjectContato() {
            this.contato.pessoa_id = c.id;
            this.contato.contato = this.txt_contato.Text.Trim();
            this.contato.obs = this.txt_contato_obs.Text.Trim();
            this.contato.tipo = MComboBox.GetIdStringByIndex(cbo_tipo);
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            contato.id = (int)dg.getValue("id");
            var result = contato.Request.pessoa_contato.Find(contato.id);
            if (result.status) {
                contato = result.data;
                this.EnableContatos();
                this.txt_contato.Text = contato.contato;
                this.txt_contato_obs.Text = contato.obs;
                MComboBox.setIndexById(cbo_tipo, contato.tipo);
                this.btnExcluirContato.Enabled = true; }
        }

        private void DisableContatos() {
            this.pn_controls.Enabled = false;
            this.txt_contato.Clear();
            this.txt_contato_obs.Clear();
        }

        private void EnableContatos() {
            this.txt_contato.Clear();
            this.txt_contato_obs.Clear();
            this.pn_controls.Enabled = true;
            this.txt_contato.Focus();
        }
        #endregion
    }
}
