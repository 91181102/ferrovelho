using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleCompraVenda.View;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda
{
    public partial class Principal : Form
    {
        #region: Membros da classe
        private Dados.MTabControl aba { get; set; }
        #endregion

        #region: Construtor
        public Principal() {
            InitializeComponent();
            this.SetEvents();
        }

        private void Principal_Load(object sender, EventArgs e) {
            this.Text += " - Versão: 2021.06.21.001";
            this.aba = new Dados.MTabControl(this.tbcPrincipal);
            this.Iniciar();
            this.MenuDisable();
        }

        public void SetEvents() {
            this.Load += new EventHandler(this.Principal_Load);
            this.SizeChanged += new EventHandler(this.Principal_SizeChanged);
            this.mniIniciar.Click += new EventHandler(this.mniIniciar_Click);
            this.mniEncerrar.Click += new EventHandler(this.mniEncerrar_Click);
            this.mniUsuario.Click += new EventHandler(this.mniUsuarios_Click);
            this.mniTipoMaterial.Click += new EventHandler(this.mniTipoMaterial_Click);
            this.mniEmpresa.Click += new EventHandler(this.mniEmpresa_Click);
            this.mniTipoPagamento.Click += new EventHandler(this.mniTipoPagamento_Click);
            this.mniMateriais.Click += new EventHandler(this.mniMaterial_click);
            this.mniPessoas.Click += new EventHandler(this.mniPessoas_Click);
            this.mniIniciarPdv.Click += new EventHandler(this.mniIniciarPdv_Click);
            this.mniMovimentacao.Click += new EventHandler(this.mniMovimentacao_Click);
            this.mniEstoque.Click += new EventHandler(this.mniEstoque_Click);
            this.mniRelMovimento.Click += new EventHandler(this.mniRelMovimento_Click);
            this.mniRelPagamento.Click += new EventHandler(this.mniRelPagamento_Click);
            this.mniCaixaMovimento.Click += new EventHandler(this.mniCaixaMovimento_Click);
            this.mniCaixaRelatorio.Click += new EventHandler(this.mniCaixaRelatorio_Click);
        }

        #endregion

        #region: Eventos do Menu
        private void mniIniciar_Click(object sender, EventArgs e) {
            var form = new View.TelaLogin();
            form.ShowDialog();
            if (form.IsConfirmed) {
                this.MenuEnable();
                form.Dispose();
            }
        }

        private void mniEncerrar_Click(object sender, EventArgs e) {
            this.MenuDisable();
        }

        private void mniUsuarios_Click(object sender, EventArgs e) {
            this.ShowDialog(new TelaUsuario());
        }

        private void mniTipoMaterial_Click(object sender, EventArgs e) {
            this.ShowDialog(new TelaTipoMaterial());
        }

        private void mniEmpresa_Click(object sender, EventArgs e) {
            this.ShowDialog(new TelaEmpresa());
        }

        private void mniTipoPagamento_Click(object sender, EventArgs e) {
            this.ShowDialog(new TelaTipoPagamento());
        }

        private void mniPessoas_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
               aba.NewTab("Pessoas"),
               new TelaPessoa(),
               (ToolStripMenuItem)sender,
               ModuloGeral.PESSOA
           );
        }

        private void mniMaterial_click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
               aba.NewTab("Materiais"),
               new TelaMaterial(),
               (ToolStripMenuItem)sender,
               ModuloGeral.MATERIAL
           );
        }
        
        private void mniIniciarPdv_Click(object sender, EventArgs e) {
            this.ShowDialog(new TelaFrenteCaixa());
        }

        private void mniMovimentacao_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
                aba.NewTab("Gerenciar Movimentos"),
                new TelaMovimentacao(),
                (ToolStripMenuItem)sender,
                ModuloGeral.MOVIMENTO
             );
        }

        private void mniEstoque_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
                aba.NewTab("Estoque"),
                new TelaEstoque(),
                (ToolStripMenuItem)sender,
                ModuloGeral.ESTOQUE
             );
        }
        
        private void mniRelMovimento_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
                aba.NewTab("Movimento de Materiais"),
                new TelaRelatorioMovimentos(),
                (ToolStripMenuItem)sender,
                ModuloGeral.MOVMATERIAIS
             );
        }
        
        private void mniRelPagamento_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
                aba.NewTab("Relatório de Pagamentos"),
                new TelaPagamento(),
                (ToolStripMenuItem)sender,
                ModuloGeral.PAGAMENTO);
        }
        
        private void mniCaixaMovimento_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            this.WindowState = FormWindowState.Maximized;
            this.aba.Add(
                aba.NewTab("Movimento de Caixa"),
                new TelaCaixaMovimento(),
                (ToolStripMenuItem)sender,
                ModuloGeral.CAIXAMOVIMENTO);
        }

        private void mniCaixaRelatorio_Click(object sender, EventArgs e) {

        }
        #endregion

        #region: Operações
        /// <summary>
        /// Fecha todas as abas.
        /// </summary>
        private void Iniciar() {
            this.aba.closeAllTabs();
        }

        /// <summary>
        /// Abre uma caixa de diálogo.
        /// </summary>
        /// <param name="form"></param>
        private void ShowDialog(Form form) {
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
        }
        
        private void MenuEnable() {
            this.mnCadastros.Enabled = true;
            this.mnGerenciamento.Enabled = true;
            this.mnPDV.Enabled = true;
            this.mniIniciar.Enabled = false;
            this.mniEncerrar.Enabled = true;
            this.lb_user_name.Text = "Usuário: " + Dados.Rotas.user.nome;
            if (Dados.Rotas.empresa_atual.id == -1) {
                Dados.Rotas.empresa_atual = Dados.Rotas.empresa_atual.Request.GetFirst();
                this.lb_empresa.Text = " | Empresa Atual: " + Dados.Rotas.empresa_atual.nome;
            }
        }

        private void MenuDisable() {
            this.mnCadastros.Enabled = false;
            this.mnGerenciamento.Enabled = false;
            this.mnPDV.Enabled = false;
            this.mniIniciar.Enabled = true;
            this.mniEncerrar.Enabled = false;
            this.lb_user_name.Text = "Usuário: NENHUM";
            this.lb_empresa.Text = " | Empresa Atual: NENHUMA";
            Dados.Rotas.empresa_atual.SetDefaultValues();
        }
        #endregion

        private void Principal_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Size.Height: " + this.Size.Height.ToString() + " Size.Width: " + this.Size.Width.ToString());
            //this.panel1.Size = new Size(this.Size.Width, this.Size.Height - 50);
            this.panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
        }


    }
}
