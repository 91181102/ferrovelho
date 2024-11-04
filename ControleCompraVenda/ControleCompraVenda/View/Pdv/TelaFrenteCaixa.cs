using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleCompraVenda.Controllers;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.View
{
    public partial class TelaFrenteCaixa : Form
    {
        private FrenteCaixaController fc;
        private Tempo tempo;

        #region: Construtor
        public TelaFrenteCaixa() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaFrenteCaixa_Load(object sender, EventArgs e) {
            fc = new FrenteCaixaController(this);
            this.SetRelogio();
            this.SetGrid();
            this.SetEmpresa();
            this.lb_F8.Visible = false;
            //ToolTip tp = new ToolTip();
            //tp.IsBalloon = true;
            //tp.SetToolTip(lb_alterar, lb_alterar.Tag.ToString());
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaFrenteCaixa_Load);
        }
        
        private void SetGrid() {
            var dt = new DataTable();
            dt.Columns.Add("ITEM", typeof(int));
            dt.Columns.Add("COD", typeof(int));
            dt.Columns.Add("DESCRICAO", typeof(string));
            dt.Columns.Add("QTD", typeof(decimal));
            dt.Columns.Add("VL_UNIT R$", typeof(decimal));
            dt.Columns.Add("VOL", typeof(int));
            dt.Columns.Add("SUB R$", typeof(decimal));
            dt.Columns.Add("SIT", typeof(string));
            this.dgDados.DataSource = dt;

            this.dgDados.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dgDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            // Desabilita formatação padrão
            this.dgDados.EnableHeadersVisualStyles = false;
            // Definição das células.
            this.dgDados.DefaultCellStyle.Font = new Font("Consolas", 9, FontStyle.Regular);
            this.dgDados.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            this.dgDados.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgDados.DefaultCellStyle.ForeColor = Color.Black;
            //this.dgDados.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            this.dgDados.DefaultCellStyle.BackColor = Color.LightYellow;
            //this.dgDados.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            // Definição do cabeçalho.
            this.dgDados.RowHeadersVisible = false;
            this.dgDados.ColumnHeadersDefaultCellStyle.Font = new Font("consolas", 12, FontStyle.Bold);
            this.dgDados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            this.dgDados.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.dgDados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Desabilita a multi-seleção de linhas.
            this.dgDados.MultiSelect = false;
            dgDados.Columns["ITEM"].Width = 60;
            dgDados.Columns["ITEM"].DefaultCellStyle.Format = "000";
            dgDados.Columns["ITEM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDados.Columns["COD"].Width = 60;
            dgDados.Columns["COD"].DefaultCellStyle.Format = "00000";
            dgDados.Columns["COD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDados.Columns["DESCRICAO"].Width = 340;
            dgDados.Columns["QTD"].Width = 120;
            dgDados.Columns["QTD"].DefaultCellStyle.Format = "n3";
            dgDados.Columns["QTD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgDados.Columns["VL_UNIT R$"].Width = 130;
            dgDados.Columns["VL_UNIT R$"].DefaultCellStyle.Format = "n3";
            dgDados.Columns["VL_UNIT R$"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgDados.Columns["VOL"].Width = 40;
            dgDados.Columns["SUB R$"].Width = 120;
            dgDados.Columns["SUB R$"].DefaultCellStyle.Format = "n3";
            dgDados.Columns["SUB R$"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgDados.Columns["SIT"].Width = 40;
            dgDados.Columns["SIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region: Eventos de TextBox
        public TextBox Get_txt_codigo_material()  {
            return this.txt_codigo_material;
        }

        /// <summary>
        /// Obtém o TextBox Quantidade.
        /// </summary>
        /// <returns></returns>
        public TextBox Get_txt_qtd() {
            return this.txt_qtd;
        }

        /// <summary>
        /// Obtém o TextBox Volumes.
        /// </summary>
        /// <returns></returns>
        public TextBox Get_txt_volumes() {
            return this.txt_volumes;
        }
        
        #endregion

        #region: Operações
        private void SetRelogio() {
            this.lb_dia.Text = DateTime.Now.Day.ToString("00");
            int month = DateTime.Now.Month;
            switch(month) {
                case 1:
                    this.lb_mes.Text = "JAN";
                    break;
                case 2:
                    this.lb_mes.Text = "FEV";
                    break;
                case 3:
                    this.lb_mes.Text = "NAR";
                    break;
                case 4:
                    this.lb_mes.Text = "ABR";
                    break;
                case 5:
                    this.lb_mes.Text = "MAI";
                    break;
                case 6:
                    this.lb_mes.Text = "JUN";
                    break;
                case 7:
                    this.lb_mes.Text = "JUL";
                    break;
                case 8:
                    this.lb_mes.Text = "AGO";
                    break;
                case 9:
                    this.lb_mes.Text = "SET";
                    break;
                case 10:
                    this.lb_mes.Text = "OUT";
                    break;
                case 11:
                    this.lb_mes.Text = "NOV";
                    break;
                case 12:
                    this.lb_mes.Text = "DEZ";
                    break;
            }

            this.lb_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            this.tempo = new Tempo(lb_hora);
        }

        public void RefreshValues(Models.MovimentoMaterial d, string txt) {
            this.txt_qtd.Text = d.qtd.ToString("n3");
            this.txt_vl_unit.Text = d.vl_unit.ToString("n3");
            this.txt_volumes.Text = d.volumes.ToString();
            this.txt_vl_sub.Text = d.vl_total.ToString("n3");

            if (d.material_id > 0 || d.material == "CAIXA LIVRE" || d.material == "Informe o código do material.") {
                this.pn_material_nome.BackColor = System.Drawing.Color.Navy;
                if (d.material == "CAIXA LIVRE" || d.material == "Informe o código do material.")
                    this.ResetMaterial(); }
            else {
                this.pn_material_nome.BackColor = System.Drawing.Color.Red; }
                
            this.lb_material_nome.Text = d.material;
            this.SetFocus(txt);
        }

        private void ResetMaterial() {
            this.txt_codigo_material.Clear();
            this.txt_qtd.Clear();
            this.txt_volumes.Clear();
        }

        public void RefreshCliente(Models.Movimento c) {
            this.txt_header.Text =
                c.empresa + Environment.NewLine +
                "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "                " +
                c.pessoa;
        }

        private void SetFocus(string txt) {
            if (txt == "QTD") txt_qtd.Focus();
            if (txt == "COD") txt_codigo_material.Focus();
            if (txt == "VOL") txt_volumes.Focus();
        }

        public void RefreshSaldo(DataTable dt, decimal sub) {
            this.dgDados.DataSource = dt;
            this.txt_vl_total.Text = sub.ToString("n3");
        }
        
        /// <summary>
        /// Exibe a empresa atual.
        /// </summary>
        public void SetEmpresa() {
            if (Rotas.empresa_atual.id == -1) {
                Rotas.empresa_atual = Rotas.empresa_atual.Request.GetFirst(); }
                
            this.lb_empresa.Text = "F7 - Empresa Atual: " + Rotas.empresa_atual.nome;
        }
        #endregion
    }
}
