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
    public partial class TelaSelecionarEmpresa : Form
    {
        private List<Dados.MButton> btns = new List<Dados.MButton>();
        /// <summary>
        /// Informa se a empresa foi selecionada.
        /// </summary>
        public bool IsSelected = false;

        #region: Construtor
        public TelaSelecionarEmpresa() {
            InitializeComponent();
            this.SetEvents();
        }

        private void TelaSelecionarEmpresa_Load(object sender, EventArgs e) {
            this.SetComboBox();
        }

        private void SetEvents() {
            this.Load += new EventHandler(this.TelaSelecionarEmpresa_Load);
            this.btns.Add(new Dados.MButton(btnCancelar, btnCancelar_Click));
            this.btns.Add(new Dados.MButton(btnOk, btnOk_Click));
        }


        private void SetComboBox() {
            var i = Dados.Rotas.empresa.GetIntent();
            Dados.MComboBox.SetComboBox(cbo_empresa, i);
        }
        #endregion

        #region: Evento de botões
        private void btnOk_Click() {
            int id = Dados.MComboBox.GetIdByIndex(cbo_empresa);
            var result = Dados.Rotas.empresa.empresa.Find(id);
            if (result.status) {
                Dados.Rotas.empresa_atual = result.data;
                this.IsSelected = true;
                this.Close();
            }
        }

        private void btnCancelar_Click() {
            this.Close();
        }
        #endregion
    }
}
