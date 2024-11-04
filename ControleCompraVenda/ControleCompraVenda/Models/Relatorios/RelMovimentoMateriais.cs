﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using HtmlElements.Commons;

namespace ControleCompraVenda.Models.Relatorios
{
    public class RelMovimentoMateriais
    {
        /// <summary>
        /// Lista de produtos.
        /// </summary>
        private List<MovimentoMaterial> produtos = new List<MovimentoMaterial>();

        private Css border_simple_tile = new Css();
        private Css border_simple_top = new Css();
        private Css border_doubled_tile = new Css();

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe MovimentoMaterial.
        /// </summary>
        public RelMovimentoMateriais() {
            this.produtos = new List<MovimentoMaterial>();
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
        /// Cria uma nova instância da classe MovimentoMaterial.
        /// </summary>
        public RelMovimentoMateriais(List<MovimentoMaterial> produtos) {
            this.produtos = produtos;
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
            page.Add("RELATÓRIO DE MOVIMENTO DE MATERIAIS");
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
                "<th style=\"padding-right: 30px;\">COD</th>" +
                "<th style=\"padding-right: 30px;\">DESCRICAO</th>" +
                "<th style=\"padding-right: 30px;\">VOL</th>" +
                "<th style=\"padding-right: 30px;\">QUANTIDADE</th>" +
                "<th style=\"padding-right: 30px;\">VL UNIT</th>" +
                "<th style=\"padding-right: 30px;\">VL TOTAL</th></tr>");

            foreach (var item in produtos) {
                page.Add("<tr>"
                    + "<td style=\"padding-right: 30px; text-align: left\">" + item.material_id.ToString("000000") + "</td> "
                    + "<td style=\"padding-right: 30px; text-align: left;width:200px;\">" + Parse.ToLenght(30, item.material) + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.volumes.ToString("n0") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.qtd.ToString("n3") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.vl_unit.ToString("n3") + "</td>"
                    + "<td style=\"padding-right: 30px; text-align: right\">" + item.vl_total.ToString("n3") + "</td></tr>");
                index += 1;
            }
            page.Add("</table><br>");
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

            page.Add("<tr>"
                   + "<td style=\"padding-right: 30px; text-align: left\">ITENS:</td> "
                   + "<td style=\"padding-right: 30px; text-align: right\"></td>"
                   + "<td style=\"padding-right: 30px; text-align: right\">" + this.produtos.Count().ToString("n0") + "</td></tr>");

            page.Add("</table><br>");
        }

        #endregion
    }
}

