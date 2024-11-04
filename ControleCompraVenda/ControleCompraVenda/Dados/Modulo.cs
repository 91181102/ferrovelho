using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    /// <summary>
    /// Classe de controle de módulos do sistema.
    /// </summary>
    public class Modulo
    {
        #region: Atributos da classe
        /// <summary>
        /// Obtém ou define o nome do módulo.
        /// </summary>
        private string name { get; set; }
        /// <summary>
        /// Obtém ou define o id do módulo.
        /// </summary>
        private int id_modulo { get; set; }
        /// <summary>
        /// Obtém ou define o item de menu associado ao módulo.
        /// </summary>
        private ToolStripMenuItem menu { get; set; }
        /// <summary>
        /// Obtém ou define a aba onde o módulo está aberto.
        /// </summary>
        private MTabControl aba { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Define o nome e o id do módulo.
        /// </summary>
        /// <param name="name">Nome do módulo.</param>
        /// <param name="id">Id do módulo.</param>
        public Modulo(string name, int id)
        {
            this.name = name;
            this.id_modulo = id;
        }
        #endregion

        #region: Métodos getters e setters
        /// <summary>
        /// Obtém o nome do módulo.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        public string getName()
        {
            return this.name;
        }

        /// <summary>
        /// Obtém o id do módulo.
        /// </summary>
        /// <returns>Retorna um int.</returns>
        public int getId()
        {
            return this.id_modulo;
        }

        /// <summary>
        /// Define o item do menu e a aba associados ao módulo.
        /// </summary>
        /// <param name="menu">Nome do item de menu.</param>
        /// <param name="aba">Nome do Aba.</param>
        public void setMenu(ToolStripMenuItem menu, MTabControl aba)
        {
            this.menu = menu;
            this.aba = aba;
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Habilita o menu associado ao módulo.
        /// </summary>
        public void EnableMenu()
        {
            this.menu.Enabled = true;
            this.aba.RemoveTab();
        }
        #endregion
    }
}
