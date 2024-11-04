using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class MovimentoController
    {
        /// <summary>
        /// Objeto controlador da classe Movimento.
        /// </summary>
        public DefaultController<Movimento> movimento;

        /// <summary>
        /// Cria uma nova instância da classe MovimentoController.
        /// </summary>
        /// <param name="tb"></param>
        public MovimentoController(Tabela tb) {
            movimento = new DefaultController<Movimento>(tb);
        }

        /// <summary>
        /// Obtém uma Intent com a situação de pagamento.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna os ids D paga aberto e P para pago.
        /// </remarks>
        public Intent GetIntent_SitPag() {
            var i = new Intent();
            i.PutExtra("nomes", new string[] { "ABERTO", "PAGO", "CANCELADO" });
            i.PutExtra("ids", new string[] { "D", "P", "C" });
            return i;
        }

        /// <summary>
        /// Obtém uma Intent com a situação do pedido.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna os ids 0 para aberto e 1 para fechado
        /// </remarks>
        public Intent GetIntent_SitPed() {
            var i = new Intent();
            i.PutExtra("nomes", new string[] { "ABERTO", "FECHADO" });
            i.PutExtra("ids", new string[] { "0", "1" });
            return i;
        }

        /// <summary>
        /// Obtém uma Intent com o tipo de operação.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna os ids E para entrada e S para Saída.
        /// </remarks>
        public Intent GetIntent_TpOper() {
            var i = new Intent();
            i.PutExtra("nomes", new string[] { "VENDAS / SAIDAS", "COMPRAS / ENTRADAS" });
            i.PutExtra("ids", new string[] { "S", "E" });
            return i;
        }

    }
}
