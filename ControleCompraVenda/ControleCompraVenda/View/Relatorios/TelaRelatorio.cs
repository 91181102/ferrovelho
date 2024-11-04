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
    public partial class TelaRelatorio : Form
    {
        #region: Membros da classe
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private string documentText = string.Empty;
        private string titulo = string.Empty;
        #endregion
 
        #region: Construtor
        public TelaRelatorio() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaRelatorio_Load(object sender, EventArgs e) {
            this.wb.DocumentText = documentText;
            Cursor.Current = Cursors.Default;
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaRelatorio_Load);
            this.btns.Add(new Dados.MButton(btnImprimir, btnImprimir_Click));
            this.btns.Add(new Dados.MButton(btnSair, btnSair_Click));
            this.btns.Add(new Dados.MButton(btnPrintPreview, btnPrintPreview_Click));
        }

        /// <summary>
        /// Define o corpo e nome do relatório.
        /// </summary>
        /// <param name="documentText"></param>
        /// <param name="titulo"></param>
        public void SetRelatorio(string documentText, string titulo) {
            this.documentText = documentText;
            this.titulo = titulo;
            this.Text = titulo;
        }
        #endregion

        #region: Eventos de botões
        private void btnImprimir_Click() {
            this.wb.Print();
        }

        private void btnPrintPreview_Click() {
            this.wb.ShowPrintPreviewDialog();
        }

        private void btnSair_Click() {
            this.Close();
        }
        #endregion
    }
}
