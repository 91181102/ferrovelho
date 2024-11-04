﻿using System;
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
    public partial class TelaRelatorioMovimentos : Form
    {
        #region: Membros da classe
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private Models.MovimentoMaterial c = new Models.MovimentoMaterial();
        private Dados.MDataGridView dg;
        private Models.FiltroMovimentoMaterial f;
        private List<Models.MovimentoMaterial> produtos = new List<Models.MovimentoMaterial>();
        #endregion 

        #region: Construtor
        public TelaRelatorioMovimentos() {
            InitializeComponent();
            f = new Models.FiltroMovimentoMaterial(c.GetTable());
            this.SetEvents();
        }

        private void TelaEstoque_Load(object sender, EventArgs e) {
            this.btnSelecionarProduto.Enabled = false;
            this.txt_produto_nome.Enabled = false;
            this.cbo_f_tipo_material.Enabled = false;
            this.cbo_f_empresa.Enabled = false;
            this.btnSelecionarCliente.Enabled = false;
            this.txt_f_cliente_nome.Enabled = false;
            this.cbo_f_tp_oper.Enabled = false;
            this.txt_f_data_de.Enabled = false;
            this.txt_f_data_ate.Enabled = false;
            this.SetcomboBox();
            this.SetGrid();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaEstoque_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new Dados.MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new Dados.MButton(btnAtualizar, this.btnAtualizar_Click));
            this.btns.Add(new MButton(btnImprimir, btnImprimir_Click));
            this.btns.Add(new MButton(btnSelecionarProduto, btnSelecionarProduto_Click));
            this.btns.Add(new MButton(btnSelecionarCliente, btnSelecionarCliente_Click));
            this.chk_f_cod_material.CheckedChanged += new EventHandler(chk_f_cod_material_CheckedChanged);
            this.chk_f_tipo_material.CheckedChanged += new EventHandler(chk_f_tipo_material_CheckedChanged);
            this.chk_f_empresa.CheckedChanged += new EventHandler(chk_f_empresa_CheckedChanged);
            this.chk_f_periodo.CheckedChanged += new EventHandler(chk_f_periodo_CheckedChanged);
            this.chk_tp_oper.CheckedChanged += new EventHandler(chk_tp_oper_CheckedChanged);
            this.chk_f_cliente.CheckedChanged += new EventHandler(chk_f_cliente_CheckedChanged);
            this.btns.Add(new MButton(btnCopiar, this.btnCopiar_Click));
            this.btns.Add(new MButton(btnExcel, this.btnExcel_Click));
        }

        private void SetGrid() {
            this.dgDados.DataSource = new List<Models.MovimentoMaterial>();
            dg = new Dados.MDataGridView(this.dgDados);
            dg.setVisibleFalse("ativo,request,id,ordem,usuario,usuario_id, movimento_id");
            dg.setColumn("material_id", "ID", 40);
            //dg.setColumn("empresa_id", "LOJA", 40);
            //dg.setColumn("tipo", "E/S", 40, Align.Center);
            //dg.setColumn("situacao", "SIT", 40, Align.Center);
            dg.setColumn("qtd", "QTD (KG)", 100, Align.Right);
            dg.setColumn("volumes", "VOLUMES", 100, Align.Right);
            dg.setColumn("vl_unit", "VL UNIT R$", 100, Align.Right);
            dg.setColumn("vl_total", "TOTAL R$", 100, Align.Right);
            //dg.setColumn("data_mov", "DATA", 100);
            dg.setColumn("material", "DESCRICAO", 220);
            //dg.setColumn("empresa", "EMPRESA", 160);
            //dg.setColumn("usuario", "USUARIO", 120);
            dg.setNumberFormat("qtd", "n3");
            dg.setNumberFormat("volumes", "n0");
            dg.setNumberFormat("vl_unit", "n2");
            dg.setNumberFormat("vl_total", "n2");
            dg.RenderizeStyle(Dados.GridTheme.Green, false);
        }

        /// <summary>
        /// Popula e altera a aparência do combobox.
        /// </summary>
        private void SetcomboBox() {
            var i = Rotas.material_tipo.GetIntent();
            MComboBox.SetComboBox(cbo_f_tipo_material, i);
            i = Rotas.empresa.GetIntent();
            MComboBox.SetComboBox(cbo_f_empresa, i);
            i = Rotas.movimento.GetIntent_TpOper();
            MComboBox.SetComboBox(cbo_f_tp_oper, i);
        }
        #endregion

        #region: Eventos CheckBox
        private void chk_f_cod_material_CheckedChanged(object sender, EventArgs e) {
            this.btnSelecionarProduto.Enabled = chk_f_cod_material.Checked;
            this.txt_produto_nome.Enabled = chk_f_cod_material.Checked;
        }

        private void chk_f_tipo_material_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_tipo_material.Enabled = this.chk_f_tipo_material.Checked;
        }

        private void chk_f_empresa_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_empresa.Enabled = this.chk_f_empresa.Checked;
        }

        private void chk_f_periodo_CheckedChanged(object sender, EventArgs e) {
            this.txt_f_data_ate.Enabled = chk_f_periodo.Checked;
            this.txt_f_data_de.Enabled = chk_f_periodo.Checked;
        }

        private void chk_tp_oper_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_tp_oper.Enabled = this.chk_tp_oper.Checked;
        }

        private void chk_f_cliente_CheckedChanged(object sender, EventArgs e) {
            this.btnSelecionarCliente.Enabled = chk_f_cliente.Checked;
            this.txt_f_cliente_nome.Enabled = chk_f_cliente.Checked;
        }
        #endregion

        #region: Evento de botões
        private void btnSair_Click() {
            ControleCompraVenda.Controllers.ModuloGeral.MOVMATERIAIS.EnableMenu();
            this.btns = null;
            this.dg = null;
            this.Close();
        }

        private void btnAtualizar_Click() {
            this.RefreshGrid();
        }

        private void btnImprimir_Click() {
            var form = new TelaRelatorio();
            form.SetRelatorio(
                new Models.Relatorios.RelMovimentoMateriais(produtos).GetHtml(),
                "Relatório de Movimento de Materiais");
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
        }

        private void btnSelecionarProduto_Click() {
            var form = new View.TelaSelecionarMaterial();
            form.ShowDialog();
            if (form.IsSelected) {
                this.txt_produto_nome.Text = form.material.nome;
                this.txt_produto_nome.AccessibleDescription = form.material.id.ToString(); }
            form.Dispose();
            GC.Collect();
        }

        private void btnSelecionarCliente_Click() {
            var form = new View.TelaSelecionarCliente();
            form.ShowDialog();
            if (form.IsSelected) {
                this.txt_f_cliente_nome.Text = form.cliente.nome;
                this.txt_f_cliente_nome.AccessibleDescription = form.cliente.id.ToString(); }
            form.Dispose();
            GC.Collect();
        }

        private void btnCopiar_Click() {
            Dados.Parse.CopyToClipboard(this.dgDados, true);
        }

        private void btnExcel_Click() {
            if (dgDados.RowCount == 0) {
                _MsgBox.Error("Não há dados para exportar.");
                return; }
            if (!OutToExcel.Send(dgDados, pb_exportar)) {
                _MsgBox.Error("Erro ao exportar."); }
        }
        #endregion

        #region: Operações
        private void RefreshGrid() {
            this.SetFiltro();
            var result = new ResultRequest<List<Models.MovimentoMaterial>>();

            if (!chk_agrupar.Checked) {
                result = c.Request.movimento_material.FindAll(f.GetSql()); }
            else {
                result = c.Request.GroupResult(f.GetSql()); }

            if (!result.status) {
                Dados._MsgBox.Error(result.message);
                this.lb_result_message.Text = result.message;
                return; }

            this.dgDados.DataSource = result.data;
            this.lb_result_message.Text = result.message;
            this.produtos = result.data;
            this.SetResumo(result.data);
        }

        /// <summary>
        /// Preenche o quadro de totalização.
        /// </summary>
        /// <param name="pedidos"></param>
        private void SetResumo(List<Models.MovimentoMaterial> pedidos)
        {
            //var r = new Models.Relatorios.RelEstoque(pedidos);

            //this.txt_compras_qtd.Text = r.compras.GetQtd().ToString("n0");
            //this.txt_compras_vl_total.Text = r.compras.GetValorTotal().ToString("n2");
            //this.txt_compras_desconto.Text = r.compras.GetDesconto().ToString("n2");
            //this.txt_compras_vl_pago.Text = r.compras.GetValorPago().ToString("n2");
            //this.txt_compras_vl_aberto.Text = r.compras.GetValorDevendo().ToString("n2");
            //this.txt_vendas_qtd.Text = r.vendas.GetQtd().ToString("n0");
            //this.txt_vendas_vl_total.Text = r.vendas.GetValorTotal().ToString("n2");
            //this.txt_vendas_desconto.Text = r.vendas.GetDesconto().ToString("n2");
            //this.txt_vendas_vl_pago.Text = r.vendas.GetValorPago().ToString("n2");
            //this.txt_vendas_vl_aberto.Text = r.vendas.GetValorDevendo().ToString("n2");
        }

        /// <summary>
        /// Define os filtros.
        /// </summary>
        private void SetFiltro() {
            f.chk_f_cod_material.Checked = this.chk_f_cod_material.Checked;
            if (!string.IsNullOrEmpty(txt_produto_nome.AccessibleDescription))
                f.chk_f_cod_material.SetValue(Convert.ToInt32(txt_produto_nome.AccessibleDescription));
            else
                f.chk_f_cod_material.SetValue(0);

            f.chk_f_cliente.Checked = this.chk_f_cliente.Checked;
            if (!string.IsNullOrEmpty(txt_f_cliente_nome.AccessibleDescription))
                f.chk_f_cliente.SetValue(Convert.ToInt32(txt_f_cliente_nome.AccessibleDescription));
            else
                f.chk_f_cliente.SetValue(0);

            f.chk_f_tipo_material.Checked = this.chk_f_tipo_material.Checked;
            f.chk_f_tipo_material.SetValue(MComboBox.GetIdByIndex(cbo_f_tipo_material));
            f.chk_f_empresa.Checked = this.chk_f_empresa.Checked;
            f.chk_f_empresa.SetValue(MComboBox.GetIdByIndex(cbo_f_empresa));
            f.chk_tp_oper.Checked = this.chk_tp_oper.Checked;
            f.chk_tp_oper.SetValue(MComboBox.GetIdStringByIndex(cbo_f_tp_oper));
            f.chk_f_periodo.Checked = this.chk_f_periodo.Checked;
            f.chk_f_periodo.SetValue(txt_f_data_de.Value, txt_f_data_ate.Value);
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            //c.id = (int)dg.getValue("id");
            //this.AbrirRecibo(c.id);
        }

        private void AbrirRecibo(int movimento_id) {
            //Cursor.Current = Cursors.WaitCursor;
            //var form = new View.TelaReciboCaixa();
            //form.SetPedido(movimento_id);
            //form.ShowDialog();
            //form.Dispose();
            //GC.Collect();
        }
        #endregion
    }
}