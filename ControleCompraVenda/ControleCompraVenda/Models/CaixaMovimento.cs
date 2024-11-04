using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    /// <summary>
    /// Cria uma nova instância da classe CaixaMovimento.
    /// </summary>
    public class CaixaMovimento : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define a data do movimento.
        /// </summary>
        public DateTime data_mov { get; set; }
        /// <summary>
        /// Obtém ou define a descrição do movimento.
        /// Tamanho: 150.
        /// </summary>
        public string memorando { get; set; }
        /// <summary>
        /// Obtém ou define o ID do caixa.
        /// </summary>
        public int caixa_id { get; set; }
        /// <summary>
        /// Obtém ou define o ID do usuário.
        /// </summary>
        public int usuario_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário que fez o movimento.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Obtém ou define o valor do movimento.
        /// </summary>
        public decimal quantia { get; set; }
        /// <summary>
        /// Obtém ou define se a operação pe Entrada ou Saída.
        /// </summary>
        public string tipo { get; set; }
        /// <summary>
        /// Obtém ou define o valor de débito.
        /// </summary>
        public decimal debito {
            get {
                if (tipo == "S") return quantia;
                else return 0; } }
        /// <summary>
        /// Obtém ou define o valor de crédito.
        /// </summary>
        public decimal credito {
            get {
                if (tipo == "E") return quantia;
                else return 0; } }
        /// <summary>
        /// Obtém ou define o saldo do movimento.
        /// </summary>
        public decimal saldo { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        private string errorField = string.Empty;
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe CaixaMovimento.
        /// </summary>
        public CaixaMovimento() {
            this.SetDefaultValues();
            this.SetTabela("id", "CAIXA_MOVIMENTOS", "usuario,debito,credito,saldo,Request");
            this.AddJoin(new Join().LeftJoin(new Usuario().GetTable(), 1).On("usuario_id").Equals("id").Select("nome").As("usuario"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;            
            this.data_mov = DateTime.Now;
            this.memorando = string.Empty;
            this.caixa_id = 1;
            this.usuario_id = 0;
            this.usuario = string.Empty;
            this.quantia = 0;
            this.tipo = string.Empty;
            this.saldo = 0;
            this.ativo = true;
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.caixa_movimento.caixa_movimento.crud.Table = this.GetName();
            Rotas.caixa_movimento.caixa_movimento.crud.PK = this.GetPK();
            Rotas.caixa_movimento.caixa_movimento.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.            
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.data_mov.ToString("yyyy-MM-dd"));
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.memorando);
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.caixa_id);
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.usuario_id);
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.quantia);
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.tipo);
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.caixa_movimento.caixa_movimento.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Faz a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            this.errorField = string.Empty;
            if (this.memorando == null) memorando = string.Empty;
            if (this.memorando.Length > 149) this.memorando = this.memorando.Substring(0, 149);
            if (this.quantia < 0) this.quantia = 0;
            if (this.quantia == 0) {
                this.errorField = "O valor da quantia precisa ser maior do que zero.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Retorna a mensagem de erro da classe.
        /// </summary>
        /// <returns></returns>
        public string GetError() {
            return this.errorField;
        }
        #endregion

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public CaixaMovimentoController Request {
            get {
                Rotas.caixa_movimento.caixa_movimento.SetDelegate(SetParam);
                return Rotas.caixa_movimento;
            }
        }
    }
}
