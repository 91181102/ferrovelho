using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using HtmlElements.Commons;

namespace ControleCompraVenda.Models.Relatorios
{
    public class RelPagamentos
    {
        /// <summary>
        /// Lista de pagamentos.
        /// </summary>
        private List<Pagamento> pagamentos = new List<Pagamento>();
        private string filtros = string.Empty;
        private Css border_simple_tile = new Css();
        private Css border_simple_top = new Css();
        private Css border_doubled_tile = new Css();

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe RelPagamentos.
        /// </summary>
        public RelPagamentos() {
            this.pagamentos = new List<Pagamento>();
            this.SetCss();
        }

        /// <summary>
        /// Define o CSS.
        /// </summary>
        private void SetCss() {
            border_simple_tile.Add("margin-top", "1em");
            border_simple_tile.Add("margin-bottom", "1em");
            border_simple_tile.Add("padding", "1em");
            border_simple_tile.Add("font-family", "monospace");
            border_simple_tile.Add("font-weight", "bold");
            border_simple_tile.Add("border-bottom-style", "dashed");
            border_simple_tile.Add("border-bottom-width", "1px");
            border_simple_tile.Add("border-top-style", "dashed");
            border_simple_tile.Add("border-top-width", "1px");
            border_simple_tile.Add("border-color", "black");

            border_simple_top.Add("margin-top", "1em");
            border_simple_top.Add("padding", "1em");
            border_simple_top.Add("font-family", "monospace");
            border_simple_top.Add("font-size", "10px");
            border_simple_top.Add("font-weight", "bold");
            border_simple_top.Add("border-top-style", "dashed");
            border_simple_top.Add("border-top-width", "1px");
            border_simple_top.Add("border-color", "black");

            border_doubled_tile.Add("margin-top", "1em");
            border_doubled_tile.Add("margin-bottom", "1em");
            border_doubled_tile.Add("padding", "1em");
            border_doubled_tile.Add("font-family", "monospace");
            border_doubled_tile.Add("font-size", "10px");
            border_doubled_tile.Add("border-bottom-style", "double");
            border_doubled_tile.Add("border-top-style", "double");
            border_doubled_tile.Add("border-color", "black");
        }

        /// <summary>
        /// Cria uma nova instância da classe RelPagamentos.
        /// </summary>
        public RelPagamentos(List<Pagamento> pagamentos) {
            this.pagamentos = pagamentos;
            this.SetCss();
        }

        /// <summary>
        /// Cria uma nova instância da classe RelPagamentos.
        /// </summary>
        public RelPagamentos(List<Pagamento> pagamentos, string filtros) {
            this.pagamentos = pagamentos;
            this.filtros = filtros;
            this.SetCss();
        }
        #endregion

        /// <summary>
        /// Monta e retorna um relatório.
        /// </summary>
        /// <returns></returns>
        public string GetHtml() {
            var page = new Page();
            this.AddTitulo(page);
            this.AddRows(page);
            this.AddResumo(page);
            page.Add("<div @class>".Replace("@class", border_simple_top.GetStyleInLine()));
            page.Add("CONTROLE COMPRA/VENDA - RELATORIO GERADO EM: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ". USUARIO: " + Rotas.user.nome);
            page.Add("</div>");
            return page.Renderize();
        }

        #region: relatório
        /// <summary>
        /// Adiciona o título do relatório.
        /// </summary>
        /// <param name="page"></param>
        private void AddTitulo(Page page) {
            page.Add("<div @class>".Replace("@class", border_doubled_tile.GetStyleInLine()));
            page.Add("RELATÓRIO DE PAGAMENTOS");
            if (!string.IsNullOrEmpty(filtros))
                page.Add("<br>" + filtros.Replace(Environment.NewLine, "<br>"));
            page.Add("</div>");
        }

        /// <summary>
        /// Adiciona as linhas de dados.
        /// </summary>
        /// <param name="page"></param>
        private void AddRows(Page page) {
            int index = 1;
            page.Add("<table style=\"font-family:monospace;font-size:10px;\">");
            page.Add("<tr @class>".Replace("@class", border_simple_tile.GetStyleInLine()) +
                "<th style=\"padding-right: 30px;\">PEDIDO</th>" +
                "<th style=\"padding-right: 30px;\">E/S</th>" +
                "<th style=\"padding-right: 30px;\">DESCRICAO</th>" +
                "<th style=\"padding-right: 30px;\">DATA</th>" +
                "<th style=\"padding-right: 30px;\">VL TOTAL</th></tr>");

            foreach (var item in pagamentos) {
                page.Add("<tr>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.movimento_id.ToString("000000") + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: center\">" + item.movimento_tipo + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: left;width:200px;\">" + Parse.ToLenght(30, item.pagamento_tipo) + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.data_pgto.ToString("dd/MM/yyyy") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.valor_pago.ToString("n2") + "</td></tr>");
                index += 1;
            }
            page.Add("</table><br>");
        }

        /// <summary>
        /// Adiciona o resumo do relatório.
        /// </summary>
        /// <param name="page"></param>
        private void AddResumo(Page page) {
            int[] pagamento_tipos = (from tipo in pagamentos select tipo.pagamento_tipo_id).Distinct().ToArray();
            int pagamento_tipo_id = 0;

            var query = from p in pagamentos
                        where p.pagamento_tipo_id == pagamento_tipo_id
                        select p;

            page.Add("<table style=\"font-family:monospace;font-size:10px;\">");
            page.Add("<tr @class>".Replace("@class", border_simple_tile.GetStyleInLine()) +
                "<th colspan=\"4\" style=\"padding-right: 30px;\">TOTALIZACAO:</th>" +
                "</tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">REGISTROS:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">SAIDAS: " + 
                   this.pagamentos.Where(o => o.movimento_tipo == "S").Count().ToString("n0") + "</td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">ENTRADAS: " + 
                   this.pagamentos.Where(o => o.movimento_tipo == "E").Count().ToString("n0") + "</td></tr>");

            if (this.pagamentos.Count() > 0)
                foreach (int id in pagamento_tipos) {
                    pagamento_tipo_id = id;
                    page.Add("<tr>"
                        + "<td style=\"padding-right: 30px; text-align: left\">" + query.First().pagamento_tipo + "</td>"
                        + "<td style=\"padding-right: 30px; text-align: right\">R$</td>"
                        + "<td style=\"padding-right: 30px; text-align: right\">" + 
                        query.Where(o => o.movimento_tipo == "S").Sum(o => o.valor_pago).ToString("n2") + "</td>"
                        + "<td style=\"padding-right: 30px; text-align: right\">" + 
                        query.Where(o => o.movimento_tipo == "E").Sum(o => o.valor_pago).ToString("n2") + "</td></tr>"); }

            if (this.pagamentos.Count() > 0)
                page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">TOTAL:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\">R$</td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + 
                   this.pagamentos.Where(o => o.movimento_tipo == "S").Sum(o => o.valor_pago).ToString("n3") + "</td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + 
                   this.pagamentos.Where(o => o.movimento_tipo == "E").Sum(o => o.valor_pago).ToString("n3") + "</td></tr>");

            page.Add("</table><br>");
        }

        #endregion
    }
}
