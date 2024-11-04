using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Controllers
{
    public class ImpressaoController
    {
        /// <summary>
        /// Retorna o objeto ReciboCaixa.
        /// </summary>
        /// <param name="movimento_id">ID do pedido.</param>
        /// <returns></returns>
        public Dados.ResultRequest<Models.Relatorios.ReciboCaixa> FindRecibo(int movimento_id) {
            var c = new Dados.ResultRequest<Models.Relatorios.ReciboCaixa>();
            var result = Dados.Rotas.movimento.movimento.Find(movimento_id);
            if (!result.status) {
                c.message = result.message;
                c.status = false;
                return c; }

            var result_materiais = Dados.Rotas.movimento_material.movimento_material.FindAll(movimento_id, "movimento_id");
            if (result_materiais.status)
                result.data.materiais = result_materiais.data;

            var result_pagamentos = Dados.Rotas.pagamento.pagamento.FindAll(movimento_id, "movimento_id");
            if (result_pagamentos.status)
                result.data.pagamentos = result_pagamentos.data;

            c.data.empresa = Dados.Rotas.empresa_atual;
            c.data.pedido = result.data;
            c.message = "Pedido encontrado.";
            return c;
        }
    }
}
