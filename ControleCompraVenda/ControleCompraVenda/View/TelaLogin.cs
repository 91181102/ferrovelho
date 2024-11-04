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
    public partial class TelaLogin : Form
    {
        private List<MButton> btns = new List<MButton>();
        public bool IsConfirmed = false;

        #region: Construtor
        public TelaLogin() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaLogin_Load(object sender, EventArgs e) {
            this.SetcomboBox();
            this.cbo_usuario.Focus();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaLogin_Load);
            this.cbo_usuario.DropDownClosed += new EventHandler(this.cbo_usuario_DropDownClosed);
            this.btns.Add(new MButton(btnOk, btnOk_Click));
            this.btns.Add(new MButton(btnCancelar, btnCancelar_Click));
        }

        private void SetcomboBox() {
            var i = Rotas.usuario.GetIntent();
            MComboBox.SetComboBox(cbo_usuario, i);
        }
        #endregion

        #region: Eventos
        private void cbo_usuario_DropDownClosed(object sender, EventArgs e) {
            this.txt_password.Focus();
        }

        private void btnOk_Click() {
            int id = MComboBox.GetIdByIndex(cbo_usuario);
            string senha = txt_password.Text.Trim();

            if (Rotas.usuario.SetLogin(id, senha)) {
                IsConfirmed = true;
                this.Close(); }
            else {
                _MsgBox.Error("Usuário não encontrado.");
                this.txt_password.Focus();
            }
        }

        private void btnCancelar_Click() {
            this.Close();
        }
        #endregion
    }
}
