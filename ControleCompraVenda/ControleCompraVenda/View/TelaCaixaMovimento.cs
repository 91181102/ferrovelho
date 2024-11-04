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
    public partial class TelaCaixaMovimento : Form
    {
        #region: Membros da classe
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private Models.CaixaMovimento c = new Models.CaixaMovimento();
        private Dados.MDataGridView dg;
        #endregion

        #region: Construtor
        public TelaCaixaMovimento() {
            InitializeComponent();
            this.Setevents();
        }

        private void TelaCaixaMovimento_Load(object sender, EventArgs e) {
            this.SetGrid();
        }

        private void Setevents() {
            this.Load += new EventHandler(this.TelaCaixaMovimento_Load);
            this.btns.Add(new Dados.MButton(btnSair, this.btnSair_Click));
            this.btns.Add(new Dados.MButton(btnAtualizar, this.btnAtualizar_Click));
            this.btns.Add(new Dados.MButton(btnExcel, btnExcel_Click));
            this.btns.Add(new Dados.MButton(btnNovo, btnNovo_Click));
        }

        private void SetGrid()  {
            this.dgDados.DataSource = new List<Models.CaixaMovimento>();
            dg = new Dados.MDataGridView(this.dgDados);
            dg.setVisibleFalse("ativo,request,id,usuario,usuario_id,caixa_id,quantia,tipo");
            dg.setColumn("data_mov", "DATA", 100);
            dg.setColumn("debito", "SAIDA R$", 100, Align.Right);
            dg.setColumn("credito", "ENTRADA R$", 100, Align.Right);
            dg.setColumn("saldo", "SALDO R$", 100, Align.Right);
            dg.setColumn("memorando", "MEMORANDO", 420);
            dg.setNumberFormat("debito", "n2");
            dg.setNumberFormat("credito", "n2");
            dg.setNumberFormat("saldo", "n2");
            dg.RenderizeStyle(Dados.GridTheme.Green, false);
        }


        #endregion

        #region: Eventos de botões
        private void btnSair_Click() {
            ControleCompraVenda.Controllers.ModuloGeral.CAIXAMOVIMENTO.EnableMenu();
            this.btns = null;
            this.dg = null;
            this.Close();
        }

        private void btnExcel_Click() {

        }

        private void btnNovo_Click() {

        }

        private void btnAtualizar_Click() {
            this.Refresh_Grid();
        }
        #endregion

        #region: Operações
        private void Refresh_Grid() {
           // this.SetFiltro();
            var result = new ResultRequest<List<Models.CaixaMovimento>>();

            //if (!chk_agrupar.Checked) {
                //result = c.Request.caixa_movimento.FindAll(f.GetSql());
                result = c.Request.GetMovimento(this.txt_data_de.Value, this.txt_data_ate.Value);
            //}
            //else
           // {
            //    result = c.Request.GroupResult(f.GetSql());
           // }

            if (!result.status) {
                Dados._MsgBox.Error(result.message);
             //   this.lb_result_message.Text = result.message;
                return;
            }

            this.dgDados.DataSource = result.data;
            //this.lb_result_message.Text = result.message;
            //this.produtos = result.data;
            //this.SetResumo(result.data);
        }
    
        #endregion
    }
}
