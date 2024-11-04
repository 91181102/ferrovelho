using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Filtro
    {
        private string strValueField = string.Empty;
        private string nomeField = string.Empty;
        private string valorField = string.Empty;
        private int intValueField = 0;
        private decimal decValueField = 0;
        private DateTime dtDeValueField = DateTime.Now;
        private DateTime dtAteValueField = DateTime.Now;
        /// <summary>
        /// Obtém ou define se o filtro está ativo.
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Cria uma nova instância da classe de filtro.
        /// </summary>
        public Filtro() {
            this.Checked = false;
        }

        /// <summary>
        /// Cria uma nova instância da classe de filtro.
        /// </summary>
        /// <param name="nome">Nome do Filtro.</param>
        public Filtro(string nome) {
            this.Checked = false;
            this.nomeField = nome;
        }

        #region: Setters
        /// <summary>
        /// Define o valor do filtro em string.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(string value) {
            this.strValueField = value;
        }

        /// <summary>
        /// Define o valor do filtro em string;
        /// </summary>
        /// <param name="value">Valor do filtro</param>
        /// <param name="txt">Descrição do campo</param>
        public void SetValue(string value, string txt) {
            this.strValueField = value;
            this.valorField = "(" + value.ToString() + ")" + txt;
        }

        /// <summary>
        /// Define o valor do filtro em inteiro.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(int value) {
            this.intValueField = value;
        }

        /// <summary>
        /// Define o valor do filtro em inteiro.
        /// </summary>
        /// <param name="value">Valor do filtro.</param>
        /// <param name="txt">Descrição do campo.</param>
        public void SetValue(int value, string txt) {
            this.intValueField = value;
            this.valorField = "(" + value.ToString() + ")" + txt;
        }

        /// <summary>
        /// Define o valor do filtro em decimal.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(decimal value) {
            this.decValueField = value;
        }

        /// <summary>
        /// Define o valor do filtro em decimal.
        /// </summary>
        /// <param name="value">Valor do filtro.</param>
        /// <param name="txt">Descrição do campo.</param>
        public void SetValue(decimal value, string txt) {
            this.decValueField = value;
            this.valorField = "(" + value.ToString() + ")" + txt;
        }

        /// <summary>
        /// Define o valor do filtro em DateTime.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(DateTime value) {
            this.dtDeValueField = value;
            this.valorField = "Data: " + value.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Define o valor do filtro em DateTime.
        /// </summary>
        /// <param name="de"></param>
        /// <param name="ate"></param>
        public void SetValue(DateTime de, DateTime ate) {
            this.dtDeValueField = de;
            this.dtAteValueField = ate;
            this.valorField =
                "de: " + de.ToString("dd/MM/yyyy") +
                " ate " + ate.ToString("dd/MM/yyyy");
        }
        #endregion

        #region: Getters
        /// <summary>
        /// Obtém um valor um INT.
        /// </summary>
        /// <returns></returns>
        public int GetInt() {
            return this.intValueField;
        }
        /// <summary>
        /// Obtém um valor em STRING.
        /// </summary>
        /// <returns></returns>
        public string GetString() {
            return this.strValueField;
        }
        /// <summary>
        /// Obtém um valor em DECIMAL.
        /// </summary>
        /// <returns></returns>
        public decimal GetDecimal() {
            return this.decValueField;
        }
        /// <summary>
        /// Obtém um valor em DATA (data inicial).
        /// </summary>
        /// <returns></returns>
        public DateTime GetDataDe() {
            return this.dtDeValueField;
        }
        /// <summary>
        /// Obtém um valor em DATA (data final).
        /// </summary>
        /// <returns></returns>
        public DateTime GetDataAte() {
            return this.dtAteValueField;
        }
        #endregion

        /// <summary>
        /// Define o nome do filtro.
        /// </summary>
        /// <param name="nome"></param>
        public void SetFiltroNome(string nome) {
            this.nomeField = nome;
        }

        /// <summary>
        /// Obtém o nome e valor do filtro.
        /// </summary>
        /// <returns></returns>
        public string toString() {
            var txt = new System.Text.StringBuilder();
            txt.Append(nomeField + ": " + valorField);
            return txt.ToString();
        }
    }
}
