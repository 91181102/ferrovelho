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
    public partial class TelaSelecionarCliente : Form
    {
        #region: Membros da classe
        private Dados.MDataGridView dg;
        public bool IsSelected = false;
        public Models.Pessoa cliente;
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        #endregion

        #region: Construtor
        public TelaSelecionarCliente() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaSelecionarCliente_Load(object sender, EventArgs e) {
            Dados.Rotas.pessoa.LoadLista();
            this.RefreshGrid();
            this.SetGrid();
        }

        private void SetGrid() {
            this.dg = new Dados.MDataGridView(dgDados);
            dg.setCellFont("calibri", 8, FontStyle.Regular);
            dg.setColumn("id", "ID", 40);
            dg.setColumn("NOME", "NOME", 200);
            dg.setVisibleFalse("cnpj_cpf,endereco,obs,ativo,Request");
            this.dg.RenderizeStyle(Dados.GridTheme.Blue, false);
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaSelecionarCliente_Load);
            this.btns.Add(new Dados.MButton(btnOk, btnOK_Click));
            this.btns.Add(new Dados.MButton(btnCancel, btnCancel_Click));
            this.btns.Add(new Dados.MButton(btnLimpar, btnLimpar_Click));
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.txt_find.TextChanged += new EventHandler(this.txtFind_TextChanged);
        }
        #endregion

        #region: Evento de botões
        private void btnOK_Click() {
            if (dgDados.RowCount == 0) return;
            this.GetSelected();
            this.IsSelected = true;
            this.btns = null;
            this.Close();
        }

        private void btnCancel_Click() {
            this.Close();
        }

        private void btnLimpar_Click() {
            this.txt_find.Clear();
            this.txt_find.Focus();
        }
        #endregion

        #region: Operações com TextBox
        private void txtFind_TextChanged(object sender, EventArgs e) {
            this.RefreshGrid();
        }
        #endregion

        #region: Operações com DataGrid
        private void RefreshGrid() {
            this.dgDados.DataSource = Dados.Rotas.pessoa.FindAll(this.txt_find.Text.Trim());
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            this.btnOK_Click();
        }

        /// <summary>
        /// Define o clinte pela linha selecionada.
        /// </summary>
        private void GetSelected() {
            int id = (int)dg.getValue("id");
            this.cliente = Dados.Rotas.pessoa.Select(id);
        }
        #endregion
    }
}
