using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlElements.Commons;

namespace ControleCompraVenda.Models.Relatorios
{
    public class ReciboCaixa
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o pedido.
        /// </summary>
        public Movimento pedido { get; set; }
        /// <summary>
        /// Obtém ou define a empresa emitente do pedido.
        /// </summary>
        public Empresa empresa { get; set; }
        /// <summary>
        /// Obtém ou define o cliente ou fornecedor do pedido.
        /// </summary>
        public Pessoa cliente { get; set; }
        /// <summary>
        /// Objeto página de relatório.
        /// </summary>
        private Page page { get; set; }        
        #endregion

        /// <summary>
        /// Cria uma nova instância da classe de ReciboCaixa.
        /// </summary>
        public ReciboCaixa() {
            this.pedido = new Movimento();
            this.empresa = new Empresa();
            this.cliente = new Pessoa();
        }

        /// <summary>
        /// Retorna o recibo em formato HTML.
        /// </summary>
        /// <returns></returns>
        public string GetHtml() {
            this.page = new Page();
            //Lists produtos = new Lists(true);
            //produtos.setListStyleType(ListStyleType.Numbers);
            //Lists pagamentos = new Lists(false);
            // Cabeçalho
            this.page.Add("<div class = \"container\">");
            this.page.Add(new Title("RECIBO" + "<hr>", TitleType.h3).Value);
            //this.page.Add(new Title("Dados do atendimento:", TitleType.h4).Value);
            this.page.Add("Pedido " +  pedido.id.ToString("00000000") + "<br>");
            this.page.Add("Data: " + pedido.data_mov.ToString("dd/MM/yyyy HH:mm:ss") + "<br>");

            if (pedido.tipo == "S")
                this.page.Add("Cliente: " + pedido.pessoa + "<br>");
            else
                this.page.Add("Fornecedor: " + pedido.pessoa + "<br>");
            if (pedido.ativo)
                this.page.Add("Realizado por: " + pedido.usuario + "<hr>");
            else
                this.page.Add("<b>Cancelado por: " + pedido.usuario + "</b><hr>");

            if (pedido.materiais.Count() > 0)
                this.Add(pedido.materiais);

            if (pedido.pagamentos.Count() > 0)
                this.Add(pedido.pagamentos);

            this.Add(pedido);

            // Rodapé do relatório.
            this.page.Add(new Title("<hr>Controle Compra/Venda - Relatório gerado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".", TitleType.h6).Value);
            this.page.Add("</div>");

            return page.Renderize();
        }

        /// <summary>
        /// Adiciona os produtos.
        /// </summary>
        /// <param name="materiais"></param>
        private void Add(List<Models.MovimentoMaterial> materiais) {
            this.page.Add(new Title("Produtos:", TitleType.h4).Value);
            int index = 1;
            this.page.Add("<table style=\"font-family:calibri;font-size:14px;\">");
            this.page.Add("<tr>" +
                "<th style=\"padding-right: 30px;\">ITEM</th>" +
                "<th style=\"padding-right: 30px;\">COD</th>" +
                "<th style=\"padding-right: 30px;\">DESCRICAO</th>" +
                "<th style=\"padding-right: 30px;\">QUANT.(KG)</th>" +
                "<th style=\"padding-right: 30px;\">VALOR UNIT.</th>" +
                "<th style=\"padding-right: 30px;\">VOL.</th>" +
                "<th style=\"padding-right: 30px;\">TOTAL</th>" +
                "<th style=\"padding-right: 30px;\">SIT</th></tr>");

            foreach (var item in materiais) {
                this.page.Add("<tr>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" +  index.ToString("0000") + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.material_id.ToString("000000") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.material + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.qtd.ToString("n3") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.vl_unit.ToString("n3") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.volumes.ToString("n0") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.vl_total.ToString("n3") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.situacao + "</td></tr>");
                index += 1;
            }

            this.page.Add("</table><br>");
        }

        /// <summary>
        /// Adiciona os pagamentos.
        /// </summary>
        /// <param name="pagamentos"></param>
        private void Add(List<Pagamento> pagamentos) {
            this.page.Add(new Title("Pagamentos:", TitleType.h4).Value);
            int index = 1;
            this.page.Add("<table style=\"font-family:calibri;font-size:14px;\">");
            this.page.Add("<tr>" +
                "<th style=\"padding-right: 30px;\">ORDEM</th>" +
                "<th style=\"padding-right: 30px;\">DATA</th>" +
                "<th style=\"padding-right: 30px;\">DESCRICAO</th>" +
                "<th style=\"padding-right: 30px;\">VALOR PAGO</th></tr>");

            foreach (var item in pagamentos) {
                this.page.Add("<tr>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + index.ToString("0000") + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.data_pgto.ToString("dd/MM/yyyy") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.pagamento_tipo.ToUpper() + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.valor_pago.ToString("n3") + "</td>");
                index += 1;
            }

            this.page.Add("</table><br>");
        }

        /// <summary>
        /// Adiciona os totais.
        /// </summary>
        /// <param name="resumo"></param>
        private void Add(Movimento resumo) {
            decimal t_qtd = resumo.materiais.Where(o => o.situacao == "N").Sum(o => o.qtd);
            decimal t_vol = resumo.materiais.Where(o => o.situacao == "N").Sum(o => o.volumes);
            decimal t_cancelados = resumo.materiais.Where(o => o.situacao == "C").Sum(o => o.vl_total);
            decimal t_valor = resumo.materiais.Where(o => o.situacao == "N").Sum(o => o.vl_total) - t_cancelados;
            decimal t_pago = resumo.pagamentos.Where(o => o.ativo).Sum(o => o.valor_pago);
            decimal t_acrescimo = resumo.troco *-1;
            decimal t_a_pagar = (t_valor - (resumo.desconto + t_pago) + t_acrescimo);

            this.page.Add(new Title("Totais:", TitleType.h5).Value);
            this.page.Add("<table style=\"font-family:calibri;font-size:14px;\">");
            this.page.Add("<tr><td>QTD TOTAL DE ITENS:</td> <td style=\"padding-right: 30px; text-align: right\">KG</td>     <td style=\"padding-right: 30px; text-align: right\">" +  t_qtd.ToString("n3") + "</td></tr>");
            this.page.Add("<tr><td>QTD VOLUMES:</td>        <td style=\"padding-right: 30px; text-align: right\">Unid.</td>  <td style=\"padding-right: 30px; text-align: right\">" + t_vol.ToString("n0") + "</td></tr>");
            this.page.Add("<tr><td>VALOR TOTAL:</td>        <td style=\"padding-right: 30px; text-align: right\">R$</td>     <td style=\"padding-right: 30px; text-align: right\">" + t_valor.ToString("n3") + "</td></tr>");
            this.page.Add("<tr><td>VALOR DESCONTO:</td>     <td style=\"padding-right: 30px; text-align: right\">R$</td>     <td style=\"padding-right: 30px; text-align: right\">" + resumo.desconto.ToString("n3") + "</td></tr>");
            this.page.Add("<tr><td>VALOR ACRESCIMO:</td>    <td style=\"padding-right: 30px; text-align: right\">R$</td>     <td style=\"padding-right: 30px; text-align: right\">" + t_acrescimo.ToString("n3") + "</td></tr>");
            this.page.Add("<tr><td>VALOR TOTAL PAGO:</td>   <td style=\"padding-right: 30px; text-align: right\">R$</td>     <td style=\"padding-right: 30px; text-align: right\">" + t_pago.ToString("n3") + "</td></tr>");
            this.page.Add("<tr><td>VALOR A PAGAR:</td>      <td style=\"padding-right: 30px; text-align: right\">R$</td>     <td style=\"padding-right: 30px; text-align: right\">" + t_a_pagar.ToString("n3") + "</td></tr>");
            this.page.Add("</table><br>");
        }
    }
}
