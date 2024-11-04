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
    public partial class TelaCancelarItem : Form
    {
        #region: Membros da classe
        private Dados.MDataGridView dg;
        public bool IsSelected = false;
        private int admin_id = 0;
        public Models.Pessoa cliente;
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        private List<Models.MovimentoMaterial> lista;
        #endregion

        #region: Construtor
        public TelaCancelarItem() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaCancelarItem_Load(object sender, EventArgs e) {
            if (lista != null) this.SetGrid();
            this.SetcomboBox();
        }

        public void SetEvents() {
            this.Load += new EventHandler(this.TelaCancelarItem_Load);
            this.dgDados.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgDados_CellMouseDoubleClick);
            this.txt_senha.KeyDown += new KeyEventHandler(this.txt_senha_KeyDown);
            this.btns.Add(new Dados.MButton(btnOk, btnOk_Click));
            this.btns.Add(new Dados.MButton(btnCancelar, btnCancelar_Click));
            this.btns.Add(new Dados.MButton(btnAdmOk, btnAdmOk_Click));
            this.btns.Add(new Dados.MButton(btnAdmCancelar, btnAdmCancelar_Click));
        }

        public void SetLista(List<Models.MovimentoMaterial> lista) {
            this.lista = lista;
        }

        private void SetGrid() {
            this.dgDados.DataSource = this.lista.Where(o => !o.IsCanceled()).ToList();
            dg = new Dados.MDataGridView(this.dgDados);
            dg.setVisibleFalse("id,movimento_id,situacao,usuario_id,usuario,ativo,vl_unit,vl_total,request");
            dg.setColumn("ordem", "#", 40);
            dg.setColumn("material_id", "COD", 40);
            dg.setColumn("material", "DESCRICAO", 140);
            dg.setColumn("qtd", "QTD.", 70, Dados.Align.Right);
            dg.setColumn("volumes", "VOL.", 70, Dados.Align.Right);
            dg.setNumberFormat("qtd", "n3");
            dg.setNumberFormat("volumes", "n0");
            dg.RenderizeStyle(Dados.GridTheme.Classic, false);
        }

        private void SetcomboBox() {
            var i = Dados.Rotas.usuario.GetIntent();
            Dados.MComboBox.SetComboBox(cbo_usuario, i);
        }
        #endregion

        #region: Evento de Botões
        private void btnOk_Click() {
            if (Dados.Rotas.user.tipo == 0) {
                pn_user_cancel.Visible = true;
                pn_top.Enabled = false;
                return; }
            this.Remover();
        }

        private void btnCancelar_Click() {
            this.Close();
        }

        private void btnAdmOk_Click() {
            string senha = this.txt_senha.Text.Trim();
            if (string.IsNullOrEmpty(senha)) {
                Dados._MsgBox.Error("O campo senha não pode ser vazio.");
                return; }
            int id = Dados.MComboBox.GetIdByIndex(cbo_usuario);

            if (Dados.Rotas.usuario.CheckAdmin(id, senha)) {
                this.admin_id = id;
                if (this.Remover())
                    this.Close(); }
            else {
                Dados._MsgBox.Error("Credenciais não conferem."); }
        }

        private void btnAdmCancelar_Click() {
            this.pn_user_cancel.Visible = false;
            this.pn_top.Enabled = true;
        }
        #endregion

        private void txt_senha_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.btnAdmOk_Click();            
        }

        private void dgDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (Dados.Rotas.user.tipo == 0) {
                pn_user_cancel.Visible = true;
                pn_top.Enabled = false;
                return; }
            this.Remover();
        }

        /// <summary>
        /// Remove o item selecionado.
        /// </summary>
        /// <returns></returns>
        private bool Remover() {
            int ordem = (int)dg.getValue("ordem");
            if (!Dados._MsgBox.Confirm("Deseja cancelar item @ordem ?".Replace("@ordem", ordem.ToString()))) return IsSelected;

            var query = from c in lista
                        where c.ordem == ordem
                        select c;

            if (query.Count() == 0) return IsSelected;
            
            int id = Dados.Rotas.user.id;
            if (admin_id > 0) id = admin_id;
            query.First().SetCanceled(true);
            var material = query.First().CopyChangeSit(id);
            lista.Add(material);
            IsSelected = true;
            return IsSelected;
        }
    }
}
