using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Pagamento : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o ID do movimento.
        /// </summary>
        public int movimento_id { get; set; }
        /// <summary>
        /// Obtém ou define o ID do tipo de pagamento.
        /// </summary>
        public int pagamento_tipo_id { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de pagamento.
        /// </summary>
        public string pagamento_tipo { get; set; }
        /// <summary>
        /// Obtém ou define a data de pagamento.
        /// </summary>
        public DateTime data_pgto { get; set; }
        /// <summary>
        /// Obtém ou define o valor pago.
        /// </summary>
        public decimal valor_pago { get; set; }
        /// <summary>
        /// Obtém ou define o ID do usuário.
        /// </summary>
        public int usuario_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de operação.
        /// </summary>
        public string movimento_tipo { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Empresa.
        /// </summary>
        public Pagamento() {
            this.SetDefaultValues();
            this.SetTabela("id", "PAGAMENTOS", "usuario,pagamento_tipo,Request,movimento_tipo");
            this.AddJoin(new Join().LeftJoin(new Usuario().GetTable(), 1).On("usuario_id").Equals("id").Select("nome").As("usuario"));
            this.AddJoin(new Join().LeftJoin(new PagamentoTipo().GetTable(), 2).On("pagamento_tipo_id").Equals("id").Select("nome").As("pagamento_tipo"));
            this.AddJoin(new Join().LeftJoin(new Movimento().GetTable(), 3).On("movimento_id").Equals("id").Select("tipo").As("movimento_tipo"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.movimento_id = -1;
            this.pagamento_tipo_id = -1;
            this.pagamento_tipo = string.Empty;
            this.data_pgto = DateTime.Now;
            this.valor_pago = 0;
            this.usuario_id = 0;
            this.usuario = string.Empty;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Faz validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            if (valor_pago <= 0) {
                this.SetErro("O valor pago não pode ser zerado.");
                valid = false; }

            return valid;
        }

        /// <summary>
        /// Faz uma cópia em uma nova instância da classe.
        /// </summary>
        /// <returns></returns>
        public Pagamento Copy() {
            var c = new Pagamento();
            c.id = this.id;
            c.movimento_id =  this.movimento_id;
            c.pagamento_tipo_id = this.pagamento_tipo_id;
            c.pagamento_tipo =  this.pagamento_tipo;
            c.data_pgto =  this.data_pgto;
            c.valor_pago = this.valor_pago;
            c.usuario_id = this.usuario_id;
            c.usuario = this.usuario;
            c.ativo = this.ativo;

            return c;
        }

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.pagamento.pagamento.crud.Table = this.GetName();
            Rotas.pagamento.pagamento.crud.PK = this.GetPK();
            Rotas.pagamento.pagamento.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.pagamento.pagamento.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.pagamento.pagamento.crud.columns.Add(this.movimento_id);
            Rotas.pagamento.pagamento.crud.columns.Add(this.pagamento_tipo_id);
            Rotas.pagamento.pagamento.crud.columns.Add(this.data_pgto);
            Rotas.pagamento.pagamento.crud.columns.Add(this.valor_pago);
            Rotas.pagamento.pagamento.crud.columns.Add(this.usuario_id);
            Rotas.pagamento.pagamento.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.pagamento.pagamento.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Pagamento c) {
            this.id = c.id;
            this.movimento_id = c.movimento_id;
            this.pagamento_tipo_id = c.pagamento_tipo_id;
            this.data_pgto = c.data_pgto;
            this.valor_pago = c.valor_pago;
            this.usuario_id = c.usuario_id;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public PagamentoController Request {
            get {
                Rotas.pagamento.pagamento.SetDelegate(SetParam);
                return Rotas.pagamento; }
        }
    }

    public class FiltroPagamento
    {
        #region: Membros da classe
        /// <summary>
        /// Filtro para ID do material.
        /// </summary>
        public Filtro chk_f_tipo_pagamento { get; set; }
        /// <summary>
        /// Filtro para empresa.
        /// </summary>
        public Filtro chk_f_empresa { get; set; }
        /// <summary>
        /// Filtro para cliente.
        /// </summary>
        public Filtro chk_f_cliente { get; set; }
        /// <summary>
        /// Filtro para tipo de operação.
        /// </summary>
        public Filtro chk_tp_oper { get; set; }
        /// <summary>
        /// Filtro para período.
        /// </summary>
        public Filtro chk_f_periodo { get; set; }
        private Tabela tabela;
        private string tb_movimento = new Movimento().GetTable().GetName();
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de FiltroPagamento.
        /// </summary>
        public FiltroPagamento() {
            this.SetDefaultValues();
        }

        /// <summary>
        /// Cria uma nova instância da classe de FiltroPagamento.
        /// </summary>
        /// <param name="tabela">Classe Pagamento</param>
        public FiltroPagamento(Tabela tabela) {
            this.SetDefaultValues();
            this.tabela = tabela;
        }

        /// <summary>
        /// Reseta os valores do objeto.
        /// </summary>
        public void SetDefaultValues() {
            this.chk_f_tipo_pagamento = new Filtro("TIPO DE PAGAMENTO");
            this.chk_f_empresa = new Filtro("EMPRESA");
            this.chk_f_cliente = new Filtro("CLIENTE");
            this.chk_tp_oper = new Filtro("TIPO DE OPERACAO");
            this.chk_f_periodo = new Filtro("PERIODO");
        }
        #endregion

        /// <summary>
        /// Informa se há algum filtro ativado.
        /// </summary>
        /// <returns></returns>
        public bool IsChecked() {
            if (chk_f_tipo_pagamento.Checked) return true;
            if (chk_f_empresa.Checked) return true;
            if (chk_f_cliente.Checked) return true;
            if (chk_tp_oper.Checked) return true;
            if (chk_f_periodo.Checked) return true;
            return false;
        }

        /// <summary>
        /// Obtém o código sql do filtro.
        /// </summary>
        /// <returns></returns>
        public string GetSql() {
            var sql = new System.Text.StringBuilder();
            var lista = new List<string>();
            var tb_pagamento = tabela.GetName();
            var tb_material = tabela.GetJoin(0);

            if (this.IsChecked()) {
                //sql.Append(" ," + tb_movimento + ".tipo ");
                sql.Append(" LEFT JOIN " + tb_movimento + " ON " + tb_pagamento + ".movimento_id = " + tb_movimento + ".id ");
                sql.Append(" WHERE "); }

            if (chk_f_tipo_pagamento.Checked) {
                lista.Add(tb_pagamento + ".pagamento_tipo_id=" + chk_f_tipo_pagamento.GetInt() + " "); }

            if (chk_f_empresa.Checked) {
                lista.Add(tb_movimento + ".empresa_id=" + chk_f_empresa.GetInt().ToString() + " "); }

            if (chk_f_cliente.Checked) {
                lista.Add(tb_movimento + ".pessoa_id=" + chk_f_cliente.GetInt().ToString() + " "); }

            if (chk_tp_oper.Checked) {
                lista.Add(tb_movimento + ".tipo='" + chk_tp_oper.GetString().ToString() + "' "); }

            if (chk_f_periodo.Checked) {
                lista.Add(tb_movimento + ".data_mov BETWEEN '" +
                    chk_f_periodo.GetDataDe().ToString("yyyy-MM-dd 00:00:00") +
                    "' AND '" +
                    chk_f_periodo.GetDataAte().ToString("yyyy-MM-dd 23:59:59") + "' "); }

            if (this.IsChecked())
                lista.Add(tb_pagamento + ".ativo='1' ");
            else
                lista.Add(" WHERE " + tb_pagamento + ".ativo='1' ");

            if (lista.Count() == 0) return string.Empty;

            foreach (string item in lista) {
                sql.Append(item);
                sql.Append(" AND ");
            }

            sql.Append(" AND ").Replace("AND  AND", string.Empty);
            string result = sql.ToString();

            return result.Replace("AND  AND", string.Empty);
        }

        /// <summary>
        /// Retorna os filtros utilizados.
        /// </summary>
        /// <returns></returns>
        public string toString() {
            var txt = new StringBuilder();
            if (!this.IsChecked()) return txt.ToString();
            txt.Append("FILTROS:" + Environment.NewLine);

            if (chk_f_periodo.Checked)
                txt.Append(chk_f_periodo.toString() + Environment.NewLine);
            if (chk_f_tipo_pagamento.Checked)
                txt.Append(chk_f_tipo_pagamento.toString() + Environment.NewLine);
            if (chk_f_cliente.Checked)
                txt.Append(chk_f_cliente.toString() + Environment.NewLine);
            if (chk_f_empresa.Checked)
                txt.Append(chk_f_empresa.toString() + Environment.NewLine);
            if (chk_tp_oper.Checked)
                txt.Append(chk_tp_oper.toString() + Environment.NewLine);
            return txt.ToString();
        }
    }
}
