using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Paginacao
    {
        #region: Membros da classe
        private int per_pageField;

        /// <summary>
        /// Obtém ou define a págiuna atual.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de registros por página.
        /// </summary>
        public int per_page
        {
            get { return this.per_pageField; }
            set
            {
                this.per_pageField = value;
                this.offset = (page * per_pageField) - per_pageField;
                //if (this.offset == 0) offset = 1;
            }
        }

        /// <summary>
        /// Obtém ou define o primeiro registro a ser lido.
        /// </summary>
        public int offset { get; private set; }

        /// <summary>
        /// Obtém ou define a quantidade total de páginas.
        /// </summary>                        
        public int all_page { get; set; }
        #endregion

        public Paginacao()
        {
            this.page = 1;
            this.per_page = 10;
            //this.offset = 1;
            this.all_page = 1;
        }

        /// <summary>
        /// Define a quantidade de páginas encontradas.
        /// </summary>
        /// <param name="count"></param>
        public void Set_all_page(int count)
        {
            if (count == 0) return;
            if (per_page == 0) return;
            this.all_page = count / per_page;
            if ((count % per_page) > 0) this.all_page += 1;
        }
    }
}
