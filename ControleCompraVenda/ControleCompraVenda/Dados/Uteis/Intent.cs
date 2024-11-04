using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Intent
    {
        private string id = "";
        private string[] stringArray;
        private List<Intent> lista { get; set; }

        /// <summary>
        /// Adiciona um array de string.
        /// </summary>
        /// <param name="id">Nome do array.</param>
        /// <param name="value">Array de string.</param>
        public void PutExtra(string id, string[] value) {
            Intent c = new Intent();
            c.id = id;
            c.stringArray = value;
            lista.Add(c);
        }

        public Intent() {
            this.id = "";
            this.lista = new List<Intent>();
        }

        /// <summary>
        /// Recupera um array pelo nome.
        /// </summary>
        /// <param name="id">Nome do Array.</param>
        /// <returns></returns>
        public string[] getStringArrayExtra(string id) {
            var query = from c in lista
                        where c.id == id
                        select c;
            try {
                return query.First().stringArray; }
            catch {
                return new string[] { }; }
        }
    }
}
