using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Movimento : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de movimento: E ou S.
        /// </summary>
        public string tipo { get; set; }
        /// <summary>
        /// Obtém ou define a data do movimento.
        /// </summary>
        public DateTime data_mov { get; set; }
        /// <summary>
        /// Obtém ou define o ID da pessoa.
        /// </summary>
        public int pessoa_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome da pessoa.
        /// </summary>
        public string pessoa { get; set; }
        /// <summary>
        /// Obtém ou define o ID da empresa que está fazendo a movimentação.
        /// </summary>
        public int empresa_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome da empresa.
        /// </summary>
        public string empresa { get; set; }
        /// <summary>
        /// Obtém ou define se o movimento está fechado.
        /// </summary>
        public bool flag_fechado { get; set; }
        /// <summary>
        /// Obtém ou define a situação do movimento.
        /// D: Devendo.
        /// P: Pago.
        /// </summary>
        public string situacao { get; set; }
        /// <summary>
        /// Obtém ou define o valor total do movimento.
        /// </summary>
        public decimal valor_total { get; set; }
        /// <summary>
        /// Obtém ou define o valor pago do movimento.
        /// </summary>
        public decimal valor_pago { get; set; }
        /// <summary>
        /// Obtém ou define o valor do troco.
        /// </summary>
        public decimal troco { get; set; }
        /// <summary>
        /// Obtém ou define o valor de desconto.
        /// </summary>
        public decimal desconto { get; set; }
        /// <summary>
        /// Obtém ou define o ID do usuário.
        /// </summary>
        public int usuario_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        /// <summary>
        /// Obtém ou define uma lista de materiais.
        /// </summary>
        public List<MovimentoMaterial> materiais { get; set; }
        /// <summary>
        /// Obtém ou define uma lista de pagamentos.
        /// </summary>
        public List<Pagamento> pagamentos { get; set; }
        #endregion
        
        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Movimento.
        /// </summary>
        public Movimento() {
            this.materiais = new List<MovimentoMaterial>();
            this.pagamentos = new List<Pagamento>();
            this.SetDefaultValues();
            this.SetTabela("id", "MOVIMENTOS", "materiais,pessoa,pagamentos,empresa,usuario,Request");
            this.AddJoin(new Join().LeftJoin(new Pessoa().GetTable(), 1).On("pessoa_id").Equals("id").Select("nome").As("pessoa"));
            this.AddJoin(new Join().LeftJoin(new Empresa().GetTable(), 2).On("empresa_id").Equals("id").Select("nome").As("empresa"));
            this.AddJoin(new Join().LeftJoin(new Usuario().GetTable(), 3).On("usuario_id").Equals("id").Select("nome").As("usuario"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.tipo = string.Empty;
            this.data_mov = DateTime.Now;
            this.pessoa_id = 1;
            this.pessoa = "CLIENTE PADRÃO";
            this.empresa_id = -1;
            this.empresa = string.Empty;
            this.materiais.Clear();
            this.pagamentos.Clear();
            this.situacao = string.Empty;
            this.valor_total = 0;
            this.valor_pago = 0;
            this.troco = 0;
            this.desconto = 0;
            this.usuario_id = 0;
            this.usuario = string.Empty;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.movimento.movimento.crud.Table = this.GetName();
            Rotas.movimento.movimento.crud.PK = this.GetPK();
            Rotas.movimento.movimento.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.movimento.movimento.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.movimento.movimento.crud.columns.Add(this.tipo);
            Rotas.movimento.movimento.crud.columns.Add(this.data_mov.ToString("yyyy-MM-dd HH:mm:ss"));
            Rotas.movimento.movimento.crud.columns.Add(this.pessoa_id);
            Rotas.movimento.movimento.crud.columns.Add(this.empresa_id);
            Rotas.movimento.movimento.crud.columns.Add(this.flag_fechado);
            Rotas.movimento.movimento.crud.columns.Add(this.situacao);
            Rotas.movimento.movimento.crud.columns.Add(this.valor_total);
            Rotas.movimento.movimento.crud.columns.Add(this.valor_pago);
            Rotas.movimento.movimento.crud.columns.Add(this.troco);
            Rotas.movimento.movimento.crud.columns.Add(this.desconto);
            Rotas.movimento.movimento.crud.columns.Add(this.usuario_id);
            Rotas.movimento.movimento.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.movimento.movimento.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Faz a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            decimal soma = 0;
            decimal subtr = 0;

            if (empresa_id < 0) {
                this.SetErro("A loja a ser movimentada não foi definida.");
                valid = false; }

            if (pessoa_id < 0) {
                this.SetErro("O cliente não foi definid0.");
                valid = false; }

            if (materiais.Count() > 0) {
                string sit = "N";
                var query = from c in materiais
                            where c.situacao == sit
                            select c;
                if (query.Count() > 0)
                    soma = query.Sum(o => o.vl_total);
                sit = "C";
                if (query.Count() > 0)
                    subtr = query.Sum(o => o.vl_total);
                valor_total = soma - subtr; }
            else
                valor_total = 0;

            if (pagamentos.Count() > 0)
                valor_pago = pagamentos.
                    Where(o => o.ativo).
                    Sum(o => o.valor_pago);
            else
                valor_pago = 0;

            if (valor_pago > valor_total)
                troco = valor_total - valor_pago;

            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Movimento c) {
            this.id = c.id;
            this.tipo = c.tipo;
            this.data_mov = c.data_mov;
            this.pessoa_id = c.pessoa_id;
            this.empresa_id = c.empresa_id;
            this.empresa = c.empresa;
            this.flag_fechado = c.flag_fechado;
            this.ativo = c.ativo;
            this.materiais = c.materiais;
            this.pagamentos = c.pagamentos;
            this.valor_total = c.valor_total;
            this.valor_pago = c.valor_pago;
            this.desconto = c.desconto;
            this.troco = c.troco;
            this.usuario_id = c.usuario_id;
        }

        /// <summary>
        /// Obtém o valor a pagar.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalAPagar() {
            decimal valor = 0;
            valor = valor_total - valor_pago;
            return 0;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public MovimentoController Request {
            get {
                Rotas.movimento.movimento.SetDelegate(SetParam);
                return Rotas.movimento; }
        }

        /// <summary>
        /// Retorna uma string com os campos do objeto.
        /// </summary>
        /// <returns></returns>
        public string GetRelModel001() {
            string txt = string.Empty;
            string espaco = Parse.Strings( 1, " ");
            txt += id.ToString("000000") + espaco;
            txt += data_mov.ToString("dd/MM/yyyy") + espaco;
            txt += Parse.ToLenght(30, pessoa);
            txt += Parse.ToLenghtRight(12, valor_total.ToString("n2")) + espaco;
            txt += Parse.ToLenghtRight(12, desconto.ToString("n2")) + espaco;
            txt += Parse.ToLenghtRight(12, valor_pago.ToString("n2")) + espaco;
            txt += Parse.ToLenghtRight(12, GetTotalAPagar().ToString("n2")) + espaco;
            txt += Parse.ToLenghtRight(12, valor_pago.ToString("n2")) + espaco;
            txt += Parse.ToLenght(2, situacao + " ");
            return txt;
        }

        /// <summary>
        /// Retorna a descrição do tipo de operação.
        /// </summary>
        /// <returns></returns>
        public string GetTipo() {
            if (tipo == "E") return "ENTRADA";
            else return "SAÍDA";
        }

        /// <summary>
        /// Retorna a lista de materiais com o índice ordenado.
        /// </summary>
        /// <returns></returns>
        public List<Models.MovimentoMaterial> ToOrder() {
            int index = 1;
            foreach (MovimentoMaterial item in materiais) {
                item.ordem = index;
                index += 1; }
            return this.materiais;
        }
    }

    /// <summary>
    /// Cria uma nova instância da classe de FiltroMovimento.
    /// </summary>
    public class FiltroMovimento {

        #region: Membros da classe
        /// <summary>
        /// Filtro para período. Recebe dos DateTime.
        /// </summary>
        public Filtro chk_f_periodo { get; set; }
        /// <summary>
        /// Filtro para situação de pagamento: D = devendo, P = Pago.
        /// </summary>
        public Filtro chk_f_sit_pagamento { get; set; }
        public Filtro chk_f_sit_pedido { get; set; }
        public Filtro chk_tp_oper { get; set; }
        public Filtro chk_f_empresa { get; set; }
        private Tabela tabela;
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de FiltroMovimento.
        /// </summary>
        public FiltroMovimento() {
            this.SetDefaultValues();
        }

        public FiltroMovimento(Tabela tabela) {
            this.SetDefaultValues();
            this.tabela = tabela;
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.chk_f_periodo = new Filtro("PERIODO");
            this.chk_f_sit_pagamento = new Filtro("SITUACAO DE PAGAMENTO");
            this.chk_f_sit_pedido = new Filtro("SITUACAO DO PEDIDO");
            this.chk_tp_oper = new Filtro("TIPO DE OPERACAO");
            this.chk_f_empresa = new Filtro("EMPRESA");
        }
        #endregion

        /// <summary>
        /// Informa se há algum filtro ativado.
        /// </summary>
        /// <returns></returns>
        public bool IsChecked() {
            if (chk_f_periodo.Checked) return true;
            if (chk_f_sit_pagamento.Checked) return true;
            if (chk_f_sit_pedido.Checked) return true;
            if (chk_tp_oper.Checked) return true;
            if (chk_f_empresa.Checked) return true;
            return false;
        }

        /// <summary>
        /// Obtém o código html do filtro.
        /// </summary>
        /// <returns></returns>
        public string GetSql() {
            var sql = new System.Text.StringBuilder();
            var lista = new List<string>();

            if (this.IsChecked())
                sql.Append(" WHERE ");

            if (chk_f_periodo.Checked) {
                lista.Add(tabela.GetName() + ".data_mov BETWEEN '" + 
                    chk_f_periodo.GetDataDe().ToString("yyyy-MM-dd 00:00:00") + 
                    "' AND '" + 
                    chk_f_periodo.GetDataAte().ToString("yyyy-MM-dd 23:59:59") + "' " ); }

            if (chk_f_sit_pagamento.Checked) {
                lista.Add(tabela.GetName() + ".situacao='" + chk_f_sit_pagamento.GetString() + "' "); }

            if (chk_f_sit_pedido.Checked) {
                lista.Add(tabela.GetName() + ".flag_fechado='" + chk_f_sit_pedido.GetString() + "' "); }

            if (chk_tp_oper.Checked) {
                lista.Add(tabela.GetName() + ".tipo='" + chk_tp_oper.GetString() + "' "); }

            if (chk_f_empresa.Checked) {
                lista.Add(tabela.GetName() + ".empresa_id=" + chk_f_empresa.GetInt().ToString() + " "); }

            if (lista.Count() == 0) return string.Empty;

            foreach(string item in lista) {
                sql.Append(item);
                sql.Append(" AND "); }
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
            if (chk_f_sit_pagamento.Checked)
                txt.Append(chk_f_sit_pagamento.toString() + Environment.NewLine);
            if (chk_f_sit_pedido.Checked)
                txt.Append(chk_f_sit_pedido.toString() + Environment.NewLine);
            if (chk_f_empresa.Checked)
                txt.Append(chk_f_empresa.toString() + Environment.NewLine);
            if (chk_tp_oper.Checked)
                txt.Append(chk_tp_oper.toString() + Environment.NewLine);
            return txt.ToString();
        }
    }
}
