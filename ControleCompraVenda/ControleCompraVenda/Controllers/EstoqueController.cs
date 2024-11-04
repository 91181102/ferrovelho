using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class EstoqueController
    {
        /// <summary>
        /// Controlador da classe Estoque.
        /// </summary>
        public DefaultController<Estoque> estoque;

        /// <summary>
        /// Cria uma nova instância da classe EstoqueController.
        /// </summary>
        /// <param name="tb"></param>
        public EstoqueController(Tabela tb) {
            estoque = new DefaultController<Estoque>(tb);
        }

        /// <summary>
        /// Atualiza o saldo de estoque.
        /// </summary>
        /// <param name="empresa_id"></param>
        /// <param name="material_id"></param>
        public void AtualizaSaldo(int empresa_id, int material_id) {
            var q = new System.Text.StringBuilder();
            #region: query
            q.Append(" SELECT COALESCE(E.id, -1) as id, ");
            q.Append(" 	    A.material_id, A.empresa_id,  ");
            q.Append(" 	    SUM(A.qtd) as saldo, ");
            q.Append(" 	    CAST(SUM(A.volumes) as int) as volumes, ");
            q.Append(" 	    COALESCE(E.ativo, '1') as ativo ");
            q.Append(" FROM ( ");
            q.Append("  SELECT I.material_id, P.empresa_id,  ");
            q.Append(" 	    CASE WHEN  ");
            q.Append(" 		    P.tipo='S'  ");
            q.Append(" 	    THEN SUM(I.qtd) * -1 ");
            q.Append(" 	    ELSE SUM(I.qtd) END as qtd,		 ");
            q.Append(" 	    CASE WHEN  ");
            q.Append(" 		    P.tipo='S'  ");
            q.Append(" 	    THEN SUM(I.volumes) * -1 ");
            q.Append(" 	    ELSE SUM(I.volumes) END as volumes, P.tipo ");
            q.Append(" FROM controle_compra_venda.movimento_materiais I ");
            q.Append(" LEFT JOIN controle_compra_venda.movimentos P  ");
            q.Append("  	ON P.id = I.movimento_id  ");
            q.Append(" WHERE I.situacao = 'N' AND I.ativo='1' ");
            q.Append("    AND I.material_id = @material_id ".Replace("@material_id", material_id.ToString()));
            q.Append("    AND P.empresa_id = @empresa_id ".Replace("@empresa_id", empresa_id.ToString()));
            q.Append(" GROUP BY I.material_id, P.empresa_id, P.tipo) AS A ");
            q.Append(" LEFT JOIN CONTROLE_COMPRA_VENDA.Estoques E  ");
            q.Append(" 	    ON E.empresa_id = A.empresa_id  ");
            q.Append(" 	    AND E.material_id = A.material_id ");
            q.Append(" GROUP BY A.material_id, A.empresa_id, E.ativo, E.id; ");
            #endregion

            var dt = new System.Data.DataTable();
            dt = estoque.crud.Execute(q.ToString(), dt);

            if (dt == null) return;
            var query = from row in dt.AsEnumerable()
                        select Parse.GetItem<Estoque>(row);

            if (query.Count() == 0) return;

            foreach(var item in query) {
                if (item.id < 1)
                    item.Request.estoque.Insert();
                else
                    item.Request.estoque.Update(); }
        }
    }
}
