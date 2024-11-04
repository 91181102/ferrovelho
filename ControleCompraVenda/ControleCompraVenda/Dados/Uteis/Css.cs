using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Css
    {
        private List<CssElement> elements { get; set; }
        public Css() {
            this.elements = new List<CssElement>();
        }

        /// <summary>
        /// Adiciona um elemento Css no estilo.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value) {
            var c = new CssElement();
            c.SetElement(name, value);
            this.elements.Add(c);
        }

        /// <summary>
        /// Retorna o estilo.
        /// </summary>
        /// <returns></returns>
        public string GetStyle() {
            var txt = new System.Text.StringBuilder();
            foreach(CssElement item in elements) 
                txt.Append(item.GetElement());
            return txt.ToString();
        }

        /// <summary>
        /// Retorna o estilo no formato style="".
        /// </summary>
        /// <returns></returns>
        public string GetStyleInLine() {
            var txt = new System.Text.StringBuilder();
            txt.Append(" style =\"");
            foreach (CssElement item in elements)
                txt.Append(item.GetElement());
            txt.Append("\" ");
            return txt.ToString();
        }
    }

    public class CssElement { 
        public string name { get; set; }
        public string value { get; set; }

        public CssElement() {
            this.name = string.Empty;
            this.value = string.Empty;
        }

        public void SetElement(string name, string value) {
            this.name = name;
            this.value = value;
        }

        public void SetValue(string value) {
            this.value = value;
        }

        public string GetElement() {
            return name + ": " + value + ";";
        }
    }
}
