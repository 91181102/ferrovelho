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
    public partial class TelaMovimentacao : Form
    {
        #region: Membros da classe
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private Models.Movimento c = new Models.Movimento();
        private Dados.MDataGridView dg;
        private Models.FiltroMovimento f;
        private List<Models.Movimento> pedidos = new List<Models.Movimento>();
        #endregion

        #region: Construtor
        public TelaMovimentacao() {
            InitializeComponent();
            f = new Models.FiltroMovimento(c.GetTable());
            this.SetEvents();
            this.SetGrid();
        }

        private void TelaMovimentacao_Load(object sender, EventArgs e) {
            //this.RefreshGrid();
            this.SetcomboBox();
            this.txt_f_data_de.Enabled = false;
            this.txt_f_data_ate.Enabled = false;
            this.cbo_f_sit_pag.Enabled = false;
            this.cbo_f_sit_ped.Enabled = false;
            this.cbo_f_tp_oper.Enabled = false;
            this.cbo_f_empresa.Enabled = false;
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaMovimentacao_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.btns.Add(new Dados.MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new Dados.MButton(btnAtualizar, this.btnAtualizar_Click));
            this.btns.Add(new MButton(btnImprimir, btnImprimir_Click));
            this.chk_f_periodo.CheckedChanged += new EventHandler(chk_f_periodo_CheckedChanged);
            this.chk_f_sit_pagamento.CheckedChanged += new EventHandler(chk_f_sit_pagamento_CheckedChanged);
            this.chk_f_sit_pedido.CheckedChanged += new EventHandler(chk_f_sit_pedido_CheckedChanged);
            this.chk_tp_oper.CheckedChanged += new EventHandler(chk_tp_oper_CheckedChanged);
            this.chk_f_empresa.CheckedChanged += new EventHandler(chk_f_empresa_CheckedChanged);
            this.btns.Add(new MButton(btnCopiar, this.btnCopiar_Click));
            this.btns.Add(new MButton(btnExcel, this.btnExcel_Click));
        }

        private void SetGrid() {
            this.dgDados.DataSource = new List<Models.Movimento>();
            dg = new Dados.MDataGridView(this.dgDados);
            dg.setVisibleFalse("ativo,request,pessoa_id,empresa_id,usuario_id,troco");
            dg.setColumn("id", "ID", 40);
            dg.setColumn("flag_fechado", "FECH", 40, Align.Center);
            dg.setColumn("tipo", "E/S", 40, Align.Center);
            dg.setColumn("situacao", "SIT", 40, Align.Center);
            dg.setColumn("valor_total", "VL TOTAL R$", 100, Align.Right);
            dg.setColumn("desconto", "DESCONTO R$", 100, Align.Right);
            dg.setColumn("valor_pago", "VL PAGO R$", 100, Align.Right);
            dg.setColumn("troco", "TROCO R$", 100, Align.Right);
            dg.setColumn("data_mov", "DATA", 100);
            dg.setColumn("pessoa", "CLIENTE", 220);
            dg.setColumn("empresa", "EMPRESA", 160);
            dg.setColumn("usuario", "USUARIO", 120);
            dg.setNumberFormat("valor_total", "n2");
            dg.setNumberFormat("desconto", "n2");
            dg.setNumberFormat("valor_pago", "n2");
            dg.setNumberFormat("troco", "n2");
            dg.RenderizeStyle(Dados.GridTheme.Green, false);
        }

        private void SetcomboBox() {
            var i = Rotas.movimento.GetIntent_SitPag();
            MComboBox.SetComboBox(cbo_f_sit_pag, i);
            i = Rotas.movimento.GetIntent_SitPed();
            MComboBox.SetComboBox(cbo_f_sit_ped, i);
            i = Rotas.movimento.GetIntent_TpOper();
            MComboBox.SetComboBox(cbo_f_tp_oper, i);
            i = Rotas.empresa.GetIntent();
            MComboBox.SetComboBox(cbo_f_empresa, i);
        }
        #endregion

        #region: Evento de botões
        private void btnSair_Click() {
            ControleCompraVenda.Controllers.ModuloGeral.MOVIMENTO.EnableMenu();
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
                new Models.Relatorios.RelPedidos(pedidos, f.toString()).GetHtml(), 
                "Relatório de Pedidos de Compra e Venda");
            form.ShowDialog();
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
                _MsgBox.Error("Erro ao exportar.");
            }
        }
        #endregion

        #region: Eventos CheckBox
        private void chk_f_periodo_CheckedChanged(object sender, EventArgs e) {
            this.txt_f_data_ate.Enabled = chk_f_periodo.Checked;
            this.txt_f_data_de.Enabled = chk_f_periodo.Checked;
        }

        private void chk_f_sit_pagamento_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_sit_pag.Enabled = this.chk_f_sit_pagamento.Checked;
        }

        private void chk_f_sit_pedido_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_sit_ped.Enabled = this.chk_f_sit_pedido.Checked;
        }

        private void chk_tp_oper_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_tp_oper.Enabled = this.chk_tp_oper.Checked;
        }
        
        private void chk_f_empresa_CheckedChanged(object sender, EventArgs e) {
            this.cbo_f_empresa.Enabled = this.chk_f_empresa.Checked;
        }
        #endregion

        #region: Operações
        private void RefreshGrid() {
            this.SetFiltro();
            var result = c.Request.movimento.FindAll(f.GetSql());

            if (!result.status) {
                Dados._MsgBox.Error(result.message);
                this.lb_result_message.Text = result.message;
                return; }

            foreach(var m in result.data) {
                m.valor_total += (m.troco * -1);
            }

            this.dgDados.DataSource = result.data;
            this.lb_result_message.Text = result.message;
            this.pedidos = result.data;
            this.SetResumo(result.data);
        }

        /// <summary>
        /// Preenche o quadro de totalização.
        /// </summary>
        /// <param name="pedidos"></param>
        private void SetResumo(List<Models.Movimento> pedidos) {
            var r = new Models.Relatorios.RelPedidos(pedidos);

            this.txt_compras_qtd.Text = r.compras.GetQtd().ToString("n0");
            this.txt_compras_vl_total.Text = r.compras.GetValorTotal().ToString("n2");
            this.txt_compras_desconto.Text = r.compras.GetDesconto().ToString("n2");
            this.txt_compras_vl_pago.Text = r.compras.GetValorPago().ToString("n2");
            this.txt_compras_vl_aberto.Text = r.compras.GetValorDevendo().ToString("n2");
            this.txt_vendas_qtd.Text = r.vendas.GetQtd().ToString("n0");
            this.txt_vendas_vl_total.Text = r.vendas.GetValorTotal().ToString("n2");
            this.txt_vendas_desconto.Text = r.vendas.GetDesconto().ToString("n2");
            this.txt_vendas_vl_pago.Text = r.vendas.GetValorPago().ToString("n2");
            this.txt_vendas_vl_aberto.Text = r.vendas.GetValorDevendo().ToString("n2");
        }

        /// <summary>
        /// Define os filtros.
        /// </summary>
        private void SetFiltro() {
            f.chk_f_periodo.Checked = this.chk_f_periodo.Checked;
            f.chk_f_periodo.SetValue(this.txt_f_data_de.Value, this.txt_f_data_ate.Value);
            f.chk_f_sit_pagamento.Checked = this.chk_f_sit_pagamento.Checked;
            f.chk_f_sit_pagamento.SetValue(MComboBox.GetIdStringByIndex(cbo_f_sit_pag), cbo_f_sit_pag.Text);
            f.chk_f_sit_pedido.Checked = this.chk_f_sit_pedido.Checked;
            f.chk_f_sit_pedido.SetValue(MComboBox.GetIdStringByIndex(cbo_f_sit_ped), cbo_f_sit_ped.Text);
            f.chk_tp_oper.Checked = this.chk_tp_oper.Checked;
            f.chk_tp_oper.SetValue(MComboBox.GetIdStringByIndex(cbo_f_tp_oper), cbo_f_tp_oper.Text);
            f.chk_f_empresa.Checked = this.chk_f_empresa.Checked;
            f.chk_f_empresa.SetValue(MComboBox.GetIdByIndex(cbo_f_empresa), cbo_f_empresa.Text);
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            c.id = (int)dg.getValue("id");
            //this.AbrirRecibo(c.id);
            this.AbrirMovimento(c.id);
        }

        private void AbrirRecibo(int movimento_id) {
            Cursor.Current = Cursors.WaitCursor;
            var form = new View.TelaReciboCaixa();
            form.SetPedido(movimento_id);
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
        }

        private void AbrirMovimento(int movimento_id) {
            Cursor.Current = Cursors.WaitCursor;
            var form = new View.TelaMovimentacaoEditar();
            form.SetPedido(movimento_id);
            form.ShowDialog();
            if (form.IsChanged)
                this.RefreshGrid();
            form.Dispose();
            GC.Collect();
        }

        #endregion
    }
}
