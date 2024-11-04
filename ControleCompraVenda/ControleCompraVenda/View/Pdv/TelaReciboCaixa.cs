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
    public partial class TelaReciboCaixa : Form
    {
        #region: Membros da classe
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private Models.Relatorios.ReciboCaixa c = new Models.Relatorios.ReciboCaixa();
        #endregion

        #region: Construtor
        public TelaReciboCaixa() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaReciboCaixa_Load(object sender, EventArgs e) {
            this.LoadPedido();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaReciboCaixa_Load);
            this.btns.Add(new Dados.MButton(btnImprimir, btnImprimir_Click));
            this.btns.Add(new Dados.MButton(btnSair, btnSair_Click));
            this.btns.Add(new Dados.MButton(btnPrintPreview, btnPrintPreview_Click));
        }

        public void SetPedido(int movimento_id) {
            this.c.pedido.id = movimento_id;
        }
        #endregion

        #region: Eventos de botões
        private void btnImprimir_Click() {
            this.wb.Print();
        }

        private void btnPrintPreview_Click(){
            this.wb.ShowPrintPreviewDialog();
        }

        private void btnSair_Click() {
            this.Close();
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Carrega o pedido para impressão.
        /// </summary>
        private void LoadPedido() {
            if (c.pedido.id < 0) return;
            Cursor.Current = Cursors.WaitCursor;
            var result = Dados.Rotas.impressao.FindRecibo(c.pedido.id); 

            if (!result.status) {
                return; } 

            c.pedido = result.data.pedido;
            this.wb.DocumentText = c.GetHtml();
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
