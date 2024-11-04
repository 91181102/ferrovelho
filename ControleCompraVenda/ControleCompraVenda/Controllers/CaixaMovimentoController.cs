using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class CaixaMovimentoController
    {
        /// <summary>
        /// Objeto controlador da classe Movimento.
        /// </summary>
        public DefaultController<CaixaMovimento> caixa_movimento;

        /// <summary>
        /// Cria uma nova instância da classe MovimentoController.
        /// </summary>
        /// <param name="tb"></param>
        public CaixaMovimentoController(Tabela tb) {
            caixa_movimento = new DefaultController<CaixaMovimento>(tb);
        }

        /// <summary>
        /// Recupera a listagem de movimento no período.
        /// </summary>
        /// <param name="dt_de">Data inicial</param>
        /// <param name="dt_ate">Data Final</param>
        public ResultRequest<List<CaixaMovimento>> GetMovimento(DateTime dt_de, DateTime dt_ate) {
            var q = new System.Text.StringBuilder();
            #region: query
            q.Append(" (SELECT 0 as id, caixa_id, usuario_id, 'E' AS tipo, 'SALDO ANTERIOR' AS memorando, data_mov, ");
            q.Append(" 	COALESCE((SELECT SUM(quantia) ");
            q.Append(" 	FROM CONTROLE_COMPRA_VENDA.caixa_movimentos ");
            q.Append(" 	WHERE ativo = '1' AND tipo = 'E' AND data_mov < '@data_de'),0.0) - ".Replace("@data_de", dt_de.ToString("yyyy-MM-dd")));
            q.Append(" 	COALESCE(( SELECT COALESCE(SUM(quantia), 0.0) as quantia ");
            q.Append(" 	FROM CONTROLE_COMPRA_VENDA.caixa_movimentos ");
            q.Append(" 	WHERE ativo = '1' AND tipo = 'S' AND data_mov < '@data_de'),0) as quantia ".Replace("@data_de", dt_de.ToString("yyyy-MM-dd")));
            q.Append(" FROM CONTROLE_COMPRA_VENDA.caixa_movimentos ");
            q.Append(" WHERE ativo = '1' ");
            q.Append(" ORDER BY data_mov LIMIT 1) ");
            q.Append(" UNION ");
            q.Append(" (SELECT id, caixa_id, usuario_id, tipo, memorando, data_mov, quantia ");
            q.Append(" FROM CONTROLE_COMPRA_VENDA.caixa_movimentos ");
            q.Append(" WHERE ativo = '1' AND data_mov BETWEEN '@data_de' AND '@data_ate 23:59:59' ".
                Replace("@data_de", dt_de.ToString("yyyy-MM-dd")).Replace("@data_ate", dt_ate.ToString("yyyy-MM-dd")));
            q.Append(" ORDER BY data_mov); ");
            #endregion

            var dt = new System.Data.DataTable();
            dt = caixa_movimento.crud.Execute(q.ToString(), dt);
            var result = new ResultRequest<List<CaixaMovimento>>();

            if (dt == null) {
                result.status = false;
                return result;
            }

            var query = from row in dt.AsEnumerable()
                        select Parse.GetItem<CaixaMovimento>(row);

            if (query.Count() == 0) return result;
            var sd_anterior = query.First();
            result.data = query.ToList();

            foreach (var item in result.data.Where(o => o.id > 0)) {
                sd_anterior.quantia += item.credito - item.debito;
                item.saldo = sd_anterior.quantia;
            }

            
            return result;
        }
    }
}
