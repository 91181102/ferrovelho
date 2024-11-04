using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlElements.Commons;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Models.Relatorios
{
    /// <summary>
    /// Cria uma nova instância da classe RelPedidos.
    /// </summary>
    public class RelPedidos
    {        
        /// <summary>
        /// Movimentos de entradas.
        /// </summary>
        public RelPedidoOperacao compras { get; set; }
        /// <summary>
        /// Movimentos de saídas.
        /// </summary>
        public RelPedidoOperacao vendas { get; set; }
        /// <summary>
        /// Lista de pedidos.
        /// </summary>
        private List<Movimento> pedidos = new List<Movimento>();
        private string filtros = string.Empty;
        private Css border_simple_tile = new Css();
        private Css border_simple_top = new Css();
        private Css border_doubled_tile = new Css();

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe RelPedidos.
        /// </summary>
        public RelPedidos() {
            this.SetPedidos(new List<Movimento>());
            this.SetCss();
        }

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
        /// Cria uma nova instância da classe RelPedidos.
        /// </summary>
        public RelPedidos(List<Movimento> pedidos) {
            this.SetPedidos(pedidos);
            this.pedidos = pedidos;
            this.SetCss();
        }

        /// <summary>
        /// Cria uma nova instância da classe RelPedidos.
        /// </summary>
        public RelPedidos(List<Movimento> pedidos, string filtros) {
            this.SetPedidos(pedidos);
            this.pedidos = pedidos;
            this.filtros = filtros;
            this.SetCss();
        }
        #endregion

        #region: Operações
        private void SetPedidos(List<Movimento> pedidos) {
            if (pedidos.Count() == 0) {
                compras = new RelPedidoOperacao(pedidos);
                vendas = new RelPedidoOperacao(pedidos);
                return; }

            var query = from p in pedidos
                        where p.tipo == "E"
                        select p;

            if (query.Count() == 0) {
                compras = new RelPedidoOperacao(new List<Movimento>()); }
            else {
                compras = new RelPedidoOperacao(query.ToList()); }

            query = from p in pedidos
                    where p.tipo == "S"
                    select p;

            if (query.Count() == 0) {
                vendas = new RelPedidoOperacao(new List<Movimento>()); }
            else {
                vendas = new RelPedidoOperacao(query.ToList()); }
        }
        
        /// <summary>
        /// Monta e retorna um relatório.
        /// </summary>
        /// <returns></returns>
        public string GetHtml() {
            var page = new Page();
            //page.Add("<div class = \"container\">");
            this.AddTitulo(page);
            this.AddRows(page);
            this.AddResumo(page);
            page.Add("<div @class>".Replace("@class", border_simple_top.GetStyleInLine()));
            //page.Add(new Title("<hr>Controle Compra/Venda - Relatório gerado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".", TitleType.h6).Value);
            page.Add("CONTROLE COMPRA/VENDA - RELATORIO GERADO EM: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ". USUARIO: " + Rotas.user.nome);
            page.Add("</div>");
            return page.Renderize();
        }
        #endregion

        #region: relatório
        /// <summary>
        /// Adiciona o título do relatório.
        /// </summary>
        /// <param name="page"></param>
        private void AddTitulo(Page page) {
            page.Add("<div @class>".Replace("@class", border_doubled_tile.GetStyleInLine()));
            page.Add("RELATÓRIO DE PEDIDOS DE COMPRA E VENDA");
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
                "<th style=\"padding-right: 30px;\">DATA</th>" +
                "<th style=\"padding-right: 30px;\">CLIENTE</th>" +
                "<th style=\"padding-right: 30px;\">VL TOTAL</th>" +
                "<th style=\"padding-right: 30px;\">DESC</th>" +
                "<th style=\"padding-right: 30px;\">VL PAGO</th>" +
                "<th style=\"padding-right: 30px;\">VL ABER</th>" +
                "<th style=\"padding-right: 30px;\">SIT</th></tr>");

            foreach (var item in pedidos) {
                page.Add("<tr>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.id.ToString("000000") + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.data_mov.ToString("dd/MM/yyyy") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: left;width:200px;\">" + Parse.ToLenght(30, item.pessoa) + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.valor_total.ToString("n2") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.desconto.ToString("n2") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.valor_pago.ToString("n2") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.GetTotalAPagar().ToString("n2") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.situacao + "</td></tr>");
                index += 1; }
            page.Add("</table><br>");

            //page.Add("<div style=\"font-family:monospace;font-size:10px;\">");
            //string txt = string.Empty;
            //string espaco = Parse.Strings(1, " ");
            //string barra = Parse.Strings(123, "-");
            //txt += Parse.ToLenght(6, "PEDIDO") + espaco;
            //txt += Parse.ToLenght(9, "DATA") + espaco;
            //txt += Parse.ToLenght(30, "CLIENTE");
            //txt += Parse.ToLenghtRight(12, "VL TOTAL") + espaco;
            //txt += Parse.ToLenghtRight(12, "DESCONTO") + espaco;
            //txt += Parse.ToLenghtRight(12, "VL PAGO") + espaco;
            //txt += Parse.ToLenghtRight(12, "VL ABERTO") + espaco;
            //txt += Parse.ToLenghtRight(12, "VL A PAGAR") + espaco;
            //txt += Parse.ToLenght(3, "SIT");

            //page.Add(barra + "<br>");
            //page.Add(txt.Replace(" ", "&nbsp") + "<br>");
            //page.Add(barra + "<br>");
            //foreach (var item in pedidos) {
            //    page.Add(item.GetRelModel001().Replace(" ", "&nbsp") + " <br>");
            //}
            //page.Add(barra + "<br>");
            //page.Add("</div><br>");

        }

        /// <summary>
        /// Adiciona o resumo do relatório.
        /// </summary>
        /// <param name="page"></param>
        private void AddResumo(Page page) {
            page.Add("<table style=\"font-family:monospace;font-size:10px;\">");
            page.Add("<tr @class>".Replace("@class", border_simple_tile.GetStyleInLine()) +
                "<th colspan=\"3\" style=\"padding-right: 30px;\">TOTALIZACAO:</th>" +
                "</tr>");

            #region: Compras
            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">COMPRAS TOTAL:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.compras.GetQtd().ToString("n0") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">COMPRAS VALOR TOTAL:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.compras.GetValorTotal().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">COMPRAS VALOR DESCONTO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.compras.GetDesconto().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">COMPRAS VALOR PAGO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.compras.GetValorPago().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">COMPRAS VALOR EM ABERTO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.compras.GetValorDevendo().ToString("n2") + "</td></tr>");
            #endregion

            #region: Vendas
            page.Add("<tr>"
                  + "<td style=\"padding-right: 30px; text-align: left\">VENDAS TOTAL:</td> "
                  + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                  + "<td style=\"padding-right: 30px; text-align: right\">" + this.vendas.GetQtd().ToString("n0") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">VENDAS VALOR TOTAL:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.vendas.GetValorTotal().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">VENDAS VALOR DESCONTO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.vendas.GetDesconto().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">VENDAS VALOR PAGO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.vendas.GetValorPago().ToString("n2") + "</td></tr>");

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">VENDAS VALOR EM ABERTO:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.vendas.GetValorDevendo().ToString("n2") + "</td></tr>");
            #endregion

            page.Add("</table><br>");
        }

        #endregion
    }

    public class RelPedidoOperacao
    {
        /// <summary>
        /// Lista de pedidos.
        /// </summary>
        public List<Models.Movimento> pedidos { get; set; }

        public RelPedidoOperacao(List<Movimento> pedidos) {
            this.pedidos = pedidos;
        }

        /// <summary>
        /// Retorna a quantidade de registros.
        /// </summary>
        /// <returns></returns>
        public int GetQtd() {
            return pedidos.Count();
        }

        /// <summary>
        /// Obtém o valor total dos pedidos.
        /// </summary>
        /// <returns></returns>
        public decimal GetValorTotal() {
            if (pedidos.Count() == 0) return 0;
            return pedidos.Where(o => o.ativo).Sum(o => o.valor_total);

        }

        /// <summary>
        /// Obtém o valor pago dos pedidos.
        /// </summary>
        /// <returns></returns>
        public decimal GetValorPago() {
            if (pedidos.Count() == 0) return 0;
            return pedidos.Where(o => o.situacao == "P").Sum(o => o.valor_pago);
        }

        /// <summary>
        /// Obtém o valor de desconto.
        /// </summary>
        /// <returns></returns>
        public decimal GetDesconto() {
            if (pedidos.Count() == 0) return 0;
            return pedidos.Where(o => o.ativo).Sum(o => o.desconto);
        }

        /// <summary>
        /// Obtém o valor em aberto.
        /// </summary>
        /// <returns></returns>
        public decimal GetValorDevendo() {
            if (pedidos.Count() == 0) return 0;
            return pedidos.Where(o => o.situacao == "D").Sum(o => o.valor_total - (o.valor_pago + o.desconto));
        }
    }
}
