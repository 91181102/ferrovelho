using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class PagamentoController
    {
        /// <summary>
        /// Controlador da classe Pagamento.
        /// </summary>
        public DefaultController<Pagamento> pagamento;

        /// <summary>
        /// Cria uma nova instância da classe PagamentoController.
        /// </summary>
        /// <param name="tb"></param>
        public PagamentoController(Tabela tb) {
            pagamento = new DefaultController<Pagamento>(tb);
        }

        /// <summary>
        /// Retorna todos os pagamentos de um movimento.
        /// </summary>
        /// <param name="movimento_id"></param>
        /// <returns></returns>
        public ResultRequest<List<Pagamento>> FindAll(int movimento_id) {
            return pagamento.FindAll(movimento_id, "movimento_id");
        }

        /// <summary>
        /// Agrupa o resultado.
        /// </summary>
        /// <returns></returns>
        public ResultRequest<List<Pagamento>> GroupResult(string conditions) {
            var result = pagamento.FindAll(conditions);
            if (!result.status) return result;

            int[] ids = (from i in result.data
                         orderby i.pagamento_tipo
                         select i.pagamento_tipo_id)
                         .Distinct()
                         .ToArray();

            int pagamento_tipo_id = 0;
            var lista = new List<Pagamento>();
            Pagamento item;

            var query = from mov in result.data
                        where mov.pagamento_tipo_id == pagamento_tipo_id
                        select mov;

            foreach (int id in ids) {
                pagamento_tipo_id = id;
                item = new Pagamento();
                item.pagamento_tipo_id = pagamento_tipo_id;
                item.pagamento_tipo = query.First().pagamento_tipo;
                item.valor_pago = query.Sum(o => o.valor_pago);
                item.movimento_id = 0;
                lista.Add(item); }

            result.data = lista;
            result.message = lista.Count().ToString("n0") + " encontrado(s).";
            return result;
        }
    }
}
