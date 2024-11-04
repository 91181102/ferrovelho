using ControleCompraVenda.Dados;
using ControleCompraVenda.Models;
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
    public partial class TelaMaterial : Form
    {
        #region: Membros da classe
        private Material c = new Material();
        private List<MButton> btns = new List<MButton>();
        private MDataGridView dg;
        #endregion

        #region: Construtor
        public TelaMaterial() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaMaterial_Load(object sender, EventArgs e) {
            this.SetGrid();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaMaterial_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new MButton(btnNovo, this.btnNovo_Click));
            this.btns.Add(new MButton(btnAtualizar, this.btnAtualizar_Click));
            this.btns.Add(new MButton(btnTipos, this.btnTipos_Click));
            this.btns.Add(new MButton(btnCopiar, this.btnCopiar_Click));
            this.btns.Add(new MButton(btnExcel, this.btnExcel_Click));
        }

        private void SetGrid() {
            dgDados.DataSource = new List<Material>();
            dg = new MDataGridView(this.dgDados);
            dg.setColumn("id", "ID", 40);
            dg.setColumn("nome", "DESCRICAO", 240);
            dg.setColumn("tipo_material", "TIPO", 100);
            dg.setColumn("preco_compra", "VL COMPRA R$", 120, Align.Right);
            dg.setColumn("preco_venda", "VL VENDA R$", 120, Align.Right);
            dg.setColumn("ativo", "A", 40, Align.Center);
            dg.setNumberFormat("preco_compra", "n3");
            dg.setNumberFormat("preco_venda", "n3");
            dg.setVisibleFalse("request,tipo_material_id");
            dg.RenderizeStyle(GridTheme.Green, false);
        }
        #endregion

        #region: Evento de botões
        private void btnSair_Click() {
            ControleCompraVenda.Controllers.ModuloGeral.MATERIAL.EnableMenu();
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
                return; }
            if (!OutToExcel.Send(dgDados, pb_exportar)) {
                _MsgBox.Error("Erro ao exportar.");
            }
        }
        #endregion

        private void RefreshGrid() {
            var result = c.Request.material.FindAll();

            if (!result.status) {
                Request.GetError(result.message);
                this.lb_result_message.Text = result.message;
                return; }
            this.dgDados.DataSource = result.data;
            this.lb_result_message.Text = result.message;
        }

        private void btnTipos_Click() {
            var form = new TelaTipoMaterial();
            form.ShowDialog();
            form.Dispose();
        }

        private void OpenForm(int id) {
            Cursor.Current = Cursors.WaitCursor;
            var form = new TelaMaterialEditar();
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
            //this.LoadObject();
            //this.EnableControls();
        }
    }
}
