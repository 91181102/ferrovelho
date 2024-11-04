using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class PagamentoTipoController
    {
        /// <summary>
        /// Objeto controlador da classe.
        /// </summary>
        public DefaultController<PagamentoTipo> pagamento_tipo;

        /// <summary>
        /// Cria uma nova instância da classe MaterialTipoController.
        /// </summary>
        /// <param name="tb"></param>
        public PagamentoTipoController(Tabela tb) {
            pagamento_tipo = new DefaultController<PagamentoTipo>(tb);
        }

        /// <summary>
        /// Obtém uma Intent com os dados da classe.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna somente registros ativos.
        /// </remarks>
        public Intent GetIntent() {
            var result = pagamento_tipo.FindAll();
            var i = new Intent();

            var query = from c in result.data
                        orderby c.nome
                        where c.ativo
                        select c;

            i.PutExtra("nomes", (from d in query select d.nome.ToUpper()).ToArray());
            i.PutExtra("ids", (from d in query select Convert.ToString(d.id)).ToArray());
            return i;
        }
    }
}
