using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    /// <summary>
    /// Classe para controle de abertura e fechamento das guias do TabControl.
    /// </summary>
    public class MTabControl
    {
        /// <summary>
        /// Representa um formulário aberto por um item do menu.
        /// </summary>
        private TabControl tbcPrincipal { get; set; }

        #region: Construtor
        /// <summary>
        /// Classe para controlar o container TabControl.
        /// </summary>
        /// <param name="tbc">Recebe um TabControl que represente a área de fundo da aplicação.</param>
        public MTabControl(TabControl tbc)
        {
            this.tbcPrincipal = tbc;
            this.TabControlDesign();
        }
        #endregion

        #region "Eventos do TabControl"
        /// <summary>
        /// Altera a aparência do TabControl.
        /// </summary>
        private void TabControlDesign()
        {
            // Formatando o TabControl
            this.tbcPrincipal.SelectedIndex = 0;
            this.tbcPrincipal.Appearance = TabAppearance.Buttons;

            // Nome das abas do TabControl
            this.tbcPrincipal.TabPages[0].Text = "Pagina 1";

            // Cor de fundo do TabControl
            this.tbcPrincipal.TabPages[0].BackColor = SystemColors.Control;

            // Não visualizar
            this.RemoveTab();
            this.tbcPrincipal.Visible = false;
        }

        /// <summary>
        /// Abre uma nova Aba para carregar um formulário.
        /// </summary>
        /// <param name="NovaAba">Recebe o nome para o título da aba.</param>
        /// <returns></returns>
        public int NewTab(string NovaAba) {
            // Deixa o tab control visível.
            this.tbcPrincipal.Visible = true;
            // Declara uma página dentro do TabControl.
            TabPage myTabPage = new TabPage();
            // Conta quantas abas existem no TabControl.
            int Aba = tbcPrincipal.TabPages.Count;
            // Altera o nome da nova página.
            myTabPage.Text = NovaAba;
            // Adiciona a nova página no TabControl.
            this.tbcPrincipal.TabPages.Add(myTabPage);
            myTabPage.Parent.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
            myTabPage.Parent.BackColor = SystemColors.ControlDark;
            // Seleciona a nova aba.
            this.tbcPrincipal.SelectedIndex = Aba;
            // Retorna o número da nova aba.
            return Aba;
        }

        /// <summary>
        /// Remove a aba selecionada.
        /// </summary>
        public void RemoveTab()
        {
            // Obtém o índice da aba selecionada.
            int index = tbcPrincipal.SelectedIndex;

            try
            {
                // Remove a aba selecionada.
                tbcPrincipal.TabPages.Remove(tbcPrincipal.SelectedTab);
                //tbcPrincipal.TabPages[index].Dispose();
            }
            catch { }

            // Verifica se todas as abas estão fechadas.
            // Estando deixa o TabControl invisível.
            if (tbcPrincipal.TabPages.Count < 1)
                tbcPrincipal.Visible = false;
            // Elimina as abas da memória.
            GC.Collect();
        }

        /// <summary>
        /// Fecha todas as abas abertas no área de trabalho da aplicação.
        /// </summary>
        public void closeAllTabs()
        {
            // Declara um inteiro para contar as abas abertas no TabControl.
            int Aba;
            // Declara um booleano para informar se as abas estão fechadas.
            bool AbasFechadas = false;

            // Laço para ser executado enquanto houver abas abertas.
            while (!AbasFechadas)
            {
                // Contas a quantidade de abas.
                Aba = tbcPrincipal.TabPages.Count;
                // Seleciona a última aba.
                this.tbcPrincipal.SelectedIndex = Aba - 1;
                // Se a quantidade de abas for maior do que zero continue fechando.
                if (Aba > 0)
                {
                    // Destrói a aba selecionada.
                    this.tbcPrincipal.TabPages[tbcPrincipal.SelectedIndex].Dispose();
                    try
                    {
                        // Remove a aba selecionada.
                        this.tbcPrincipal.TabPages.Remove(tbcPrincipal.SelectedTab);
                    }
                    catch { }
                }
                else
                    // Se todas as abas estiverem fechadas, altera o valor para true.
                    AbasFechadas = true;
            }
            // Deixa o TabControl invisível.
            this.tbcPrincipal.Visible = false;
            GC.Collect();
        }

        /// <summary>
        /// Carrega um formulário para a nova aba.
        /// </summary>
        /// <param name="numAba">Número da aba selecionada.</param>
        /// <param name="form">Nome do formulário a ser aberto.</param>
        public void Add(int numAba, Form form) {
            this.tbcPrincipal.TabPages[numAba].Controls.Add(form);
        }

        /// <summary>
        /// Carrega um formulário para a nova aba.
        /// </summary>
        /// <param name="numAba">Número da aba selecionada.</param>
        /// <param name="form">Nome do formulário a ser aberto.</param>
        /// <param name="menu">Item do menu a ser desabilitado.</param>
        public void Add(int numAba, Form form, ToolStripMenuItem menu)
        {
            menu.Enabled = false;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            this.tbcPrincipal.TabPages[numAba].Controls.Add(form);
            form.Show();
        }

        /// <summary>
        /// Carrega um formulário para a nova aba.
        /// </summary>
        /// <param name="numAba">Número da aba selecionada.</param>
        /// <param name="form">Nome do formulário a ser aberto.</param>
        /// <param name="menu">Item do menu a ser desabilitado.</param>
        /// <param name="modulo">Nome do módulo referente ao menu.</param>
        public void Add(int numAba, Form form, ToolStripMenuItem menu, Modulo modulo) {
            menu.Enabled = false;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            this.tbcPrincipal.TabPages[numAba].Controls.Add(form);
            modulo.setMenu(menu, this);
            form.FormClosed += new FormClosedEventHandler(this.form_FormClosed);
            form.AccessibleDescription = numAba.ToString();
            //form.Parent.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            //form.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            form.AutoScroll = true;
            form.Show();
            form.Parent.SizeChanged += new EventHandler(this.form_SizeChanged);
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var form = (Form)sender;
            //RemoveTab();
        }
        
        private void form_SizeChanged(object sender, EventArgs e) {
            //MessageBox.Show("Size.Height: " + this.tbcPrincipal.Height.ToString() + " Size.Width: " + this.tbcPrincipal.Width.ToString());
            //MessageBox.Show("Size.Height: " + this.tbcPrincipal.SelectedTab.Height.ToString() + " Size.Width: " + this.tbcPrincipal.SelectedTab.Width.ToString());
            //MessageBox.Show("Size.Height: " + this.tbcPrincipal.SelectedTab.Controls[0].Height.ToString() + " Size.Width: " + this.tbcPrincipal.SelectedTab.Controls[0].Width.ToString());
            //this.tbcPrincipal.SelectedTab.Controls[0].Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            //this.tbcPrincipal.SelectedTab.Controls[0].Dock = DockStyle.Fill;
            //this.tbcPrincipal.SelectedTab.Controls[0].Size = new Size(this.tbcPrincipal.SelectedTab.Width, this.tbcPrincipal.SelectedTab.Height);
            //this.tbcPrincipal.SelectedTab.Controls[0].Refresh();
            //MessageBox.Show(tbcPrincipal.SelectedTab.Controls[0].Controls[0].Name);
            //MessageBox.Show("Size.Height: " + this.tbcPrincipal.SelectedTab.Controls[0].Height.ToString() + " Size.Width: " + this.tbcPrincipal.SelectedTab.Controls[0].Width.ToString());
        }
        #endregion
    }
}
