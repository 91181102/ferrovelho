using ControleCompraVenda.Dados;
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
    public partial class TelaMovimentacaoEditar : Form
    {
        #region: Construtor
        private List<MButton> btns = new List<MButton>();
        private Models.Movimento c = new Models.Movimento();
        public bool IsChanged = false;
        private MDataGridView dg;
        private MDataGridView dgp;
        private int admin_id = 0;
        #endregion

        #region: Construtor
        public TelaMovimentacaoEditar() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaMovimentacaoEditar_Load(object sender, EventArgs e) {
            this.pn_user_cancel.Visible = false;
            this.SetGrid();
            this.LoadMovimento();
            this.FillForm();
            this.SetcomboBox();
        }
        private void SetEvents() {
            this.Load += new EventHandler(this.TelaMovimentacaoEditar_Load);
            this.btns.Add(new MButton(btnExcluir, btnExcluir_Click));
            this.btns.Add(new MButton(btnSair, btnSair_Click));
            this.btns.Add(new MButton(btnRecibo, btnRecibo_Click));
            this.btns.Add(new Dados.MButton(btnAdmOk, btnAdmOk_Click));
            this.btns.Add(new Dados.MButton(btnAdmCancelar, btnAdmCancelar_Click));
        }
        public void SetPedido(int movimento_id) {
            this.c.id = movimento_id;
        }

        private void SetGrid() {
            this.dgProdutos.DataSource = new List<Models.MovimentoMaterial>();
            this.dg = new MDataGridView(this.dgProdutos);
            this.dg.setVisibleFalse("id,movimento_id,usuario_id,usuario,ativo,request");
            this.dg.setColumn("ordem", "#", 40);
            this.dg.setColumn("material_id", "ID", 40);
            this.dg.setColumn("material", "MATERIAL", 120);
            this.dg.setColumn("qtd", "QTD", 70, Align.Right);
            this.dg.setColumn("volumes", "VOL", 70, Align.Right);
            this.dg.setColumn("vl_unit", "UNIT", 70, Align.Right);
            this.dg.setColumn("vl_total", "TOTAL", 70, Align.Right);
            this.dg.setColumn("situacao", "SIT", 40, Align.Center);
            this.dg.setNumberFormat("qtd", "n3");
            this.dg.setNumberFormat("volumes", "n0");
            this.dg.setNumberFormat("vl_unit", "n2");
            this.dg.setNumberFormat("vl_total", "n2");
            this.dg.RenderizeStyle(GridTheme.Green, false);

            this.dgPagamentos.DataSource = new List<Models.Pagamento>();
            this.dgp = new MDataGridView(this.dgPagamentos);
            this.dgp.setVisibleFalse("id,usuario_id,pagamento_tipo_id,usuario,movimento_id,movimento_tipo,ativo,request");
            this.dgp.setColumn("pagamento_tipo", "TIPO", 120);
            this.dgp.setColumn("data_pgto", "DATA", 70, Align.Center);
            this.dgp.setColumn("valor_pago", "VALOR", 90, Align.Right);
            this.dgp.setNumberFormat("valor_pago", "n2");
            this.dgp.RenderizeStyle(GridTheme.Green, false);
        }

        private void SetcomboBox() {
            var i = Dados.Rotas.usuario.GetIntent();
            Dados.MComboBox.SetComboBox(cbo_usuario, i);
        }

        private void btnAdmOk_Click() {
            string senha = this.txt_senha.Text.Trim();
            if (string.IsNullOrEmpty(senha)) {
                Dados._MsgBox.Error("O campo senha não pode ser vazio.");
                return;
            }
            int id = Dados.MComboBox.GetIdByIndex(cbo_usuario);

            if (Dados.Rotas.usuario.CheckAdmin(id, senha)) {
                this.admin_id = id;
                this.IsChanged = this.Remover();
                if (this.IsChanged)
                    this.Close(); }
            else {
                Dados._MsgBox.Error("Credenciais não conferem."); }
        }

        private void btnAdmCancelar_Click() {
            this.pn_user_cancel.Visible = false;
            this.pn_top.Enabled = true;
        }
        #endregion

        #region: Evento de botões
        private void btnSair_Click() {
            this.Close();
        }

        private void btnExcluir_Click() {
            if (Dados.Rotas.user.tipo == 0) {
                pn_user_cancel.Visible = true;
                pn_top.Enabled = false;
                return; }

            this.IsChanged = this.Remover();
            if (IsChanged)
                btnSair_Click();
        }

        private void btnRecibo_Click() {
            Cursor.Current = Cursors.WaitCursor;
            var form = new View.TelaReciboCaixa();
            form.SetPedido(c.id);
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
        }
        #endregion

        #region: Operações
        private void LoadMovimento() {
            if (c.id <= 0) return;
            var result = c.Request.movimento.Find(c.id);
            if (result.status) {
                result.data.materiais = new Models.MovimentoMaterial().Request.movimento_material.FindAll(c.id, "movimento_id").data;
                result.data.pagamentos = new Models.Pagamento().Request.pagamento.FindAll(c.id, "movimento_id").data;
            }
            c = result.data;
        }
        private void FillForm() {
            this.txt_movimento_id.Text = c.id.ToString();
            this.txt_acrescimo.Text = (c.troco *-1).ToString("n2");
            this.txt_a_pagar.Text = c.GetTotalAPagar().ToString("n2");
            this.txt_data_mov.Text = c.data_mov.ToString("dd/MM/yyyy HH:mm:ss");
            this.txt_descontos.Text = c.desconto.ToString("n2");
            this.txt_empresa.Text = "(" + c.empresa_id.ToString() + ") " + c.empresa;
            this.txt_peso.Text = (from m in c.materiais select m.qtd).Sum().ToString("n3");
            this.txt_pessoa.Text = "(" + c.pessoa_id.ToString() + ") " + c.pessoa;
            this.txt_tipo.Text = c.GetTipo();
            this.txt_usuario.Text = c.usuario;
            this.txt_valor_pago.Text = c.valor_pago.ToString("n2");
            this.txt_valor_total.Text = c.valor_total.ToString("n2");
            this.txt_volumes.Text = (from m in c.materiais select m.volumes).Sum().ToString("n0");
            this.dgProdutos.DataSource = c.ToOrder();
            this.dgPagamentos.DataSource = c.pagamentos;
            this.chk_ativo.Checked = c.ativo;
            if (!c.ativo) {
                lb_usuario.Text = "Cancelado por";
                lb_usuario.ForeColor = Color.Red;
                btnExcluir.Enabled = false;
            }
        }

        private bool Remover() {
            if (!_MsgBox.Confirm("Deseja cancelar este movimento?")) {
                this.pn_user_cancel.Visible = false;
                this.pn_top.Enabled = true;
                return false;
            }
            Cursor.Current = Cursors.WaitCursor;
            int id = Dados.Rotas.user.id;
            if (admin_id > 0) id = admin_id;
            c.usuario_id = id;
            c.ativo = false;
            c.situacao = "C";
            foreach(Models.MovimentoMaterial item in c.materiais) {
                item.ativo = false;
                item.Request.movimento_material.Update();
                Rotas.estoque.AtualizaSaldo(c.empresa_id, item.material_id); }
            foreach(Models.Pagamento p in c.pagamentos) {
                p.ativo = false;
                p.Request.pagamento.Update(); }
            c.Request.movimento.Update();
            Cursor.Current = Cursors.Default;
            return true;
        }
        #endregion
    }
}
