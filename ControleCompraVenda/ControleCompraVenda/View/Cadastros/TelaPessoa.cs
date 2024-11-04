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
    public partial class TelaPessoa : Form
    {
        #region: Membros da classe
        private Pessoa c = new Pessoa();
        private List<MButton> btns = new List<MButton>();
        private MDataGridView dg;
        #endregion

        #region: Construtor
        public TelaPessoa() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaPessoa_Load(object sender, EventArgs e) {
            // this.RefreshGrid();
            this.SetGrid();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaPessoa_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new MButton(btnNovo, this.btnNovo_Click));
            this.btns.Add(new MButton(btnAtualizar, this.btnAtualizar_Click));
            this.btns.Add(new MButton(btnCopiar, this.btnCopiar_Click));
            this.btns.Add(new MButton(btnExcel, this.btnExcel_Click));
        }

        private void SetGrid() {
            dgDados.DataSource = new List<Pessoa>();
            dg = new MDataGridView(this.dgDados);
            dg.setVisibleFalse("contatos,request");
            dg.setColumn("id", "ID", 40);
            dg.setColumn("nome", "NOME", 240);
            dg.setColumn("cnpj_cpf", "CNPJ/CPF", 100);
            dg.setColumn("endereco", "ENDERECO", 240);
            dg.setColumn("obs", "OBS", 280);
            dg.setColumn("ativo", "A", 30, Align.Center);
            dg.RenderizeStyle(GridTheme.Green, false);
        }
        #endregion

        #region: Evento de botões
        private void btnSair_Click() {
            ControleCompraVenda.Controllers.ModuloGeral.PESSOA.EnableMenu();
            this.btns = null;
            this.dg = null;
            this.Close();
        }

        private void btnNovo_Click() {
            this.OpenForm(-1);
        }

        private void btnAtualizar_Click() {
            this.RefreshGrid();
        }

        private void btnCopiar_Click() {
            Dados.Parse.CopyToClipboard(this.dgDados, true);
        }

        private void btnExcel_Click() {
            if (dgDados.RowCount == 0) {
                _MsgBox.Error("Não há dados para exportar.");
                return;
            }
            if (!OutToExcel.Send(dgDados, pb_exportar)) {
                _MsgBox.Error("Erro ao exportar.");
            }
        }
        #endregion

        private void RefreshGrid() {
            var result = c.Request.pessoa.FindAll();

            if (!result.status) {
                Request.GetError(result.message);
                this.lb_result_message.Text = result.message;
                return; }
            this.dgDados.DataSource = result.data;
            this.lb_result_message.Text = result.message;
        }

        private void OpenForm(int id) {
            Cursor.Current = Cursors.WaitCursor;
            var form = new TelaPessoaEditar();
            form.SetId(id, this.c);
            form.ShowDialog();
            if (form.isChanged) {
                dg.saveCurrentPositionScroll();
                this.btnAtualizar_Click();
                dg.restoreCurrentPositionScroll(); }
            form.Dispose();
            GC.Collect();
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            c.id = (int)dg.getValue("id");
            this.OpenForm(c.id);
        }
    }
}
