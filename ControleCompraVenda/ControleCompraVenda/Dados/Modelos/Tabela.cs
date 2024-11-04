using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém a chave primária da tabela.
        /// </summary>
        private string PK { get; set; }
        /// <summary>
        /// Obtém o nome da tabela.
        /// </summary>
        private string Name { get; set; }
        /// <summary>
        /// Obtém os atributos que não fazem parte da tabela.
        /// </summary>
        private string ExceptAtributes { get; set; }
        /// <summary>
        /// Guarda a mensagem de erro da validãção.
        /// </summary>
        private string Erro { get; set; }
        /// <summary>
        /// OBtém ou define as tabelas JOIN.
        /// </summary>
        private List<Join> join { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma uma nova instância da classe tabela.
        /// </summary>
        /// <param name="PK">Chave primária da tabela.</param>
        /// <param name="Name">Nome da tabela.</param>
        /// <param name="ExceptAtributes">Membros que não perteçam à tabela.</param>
        public Tabela(string PK, string Name, string ExceptAtributes) {
            this.PK = PK;
            this.Name = Name;
            this.ExceptAtributes = ExceptAtributes;
            this.join = new List<Join>();
            this.ClearErro();
        }

        /// <summary>
        /// Cria uma nova instância da classe de Tabela.
        /// </summary>
        public Tabela() {
            this.PK = string.Empty;
            this.Name = string.Empty;
            this.ExceptAtributes = string.Empty;
            this.join = new List<Join>();
            this.ClearErro();
        }
        #endregion

        #region: Getters e Setters
        /// <summary>
        /// Define os valores dos membros da classe.
        /// </summary>
        /// <param name="PK"></param>
        /// <param name="Name"></param>
        /// <param name="ExceptAtributes"></param>
        public void SetTabela(string PK, string Name, string ExceptAtributes) {
            this.PK = PK;
            this.Name = Config.getDataBase() + Name;
            this.ExceptAtributes = ExceptAtributes;
            this.ClearErro();
        }

        /// <summary>
        /// Define a mensagem de erro.
        /// </summary>
        /// <param name="erro">Texto do erro.</param>
        public void SetErro(string erro) {
            this.Erro = erro;
        }

        /// <summary>
        /// Obtém a mensagem de erro.
        /// </summary>
        /// <returns>Retorna uma string</returns>
        public string GetErro() {
            return this.Erro;
        }

        /// <summary>
        /// Limpa a mensagem de erro.
        /// </summary>
        public void ClearErro() {
            this.Erro = string.Empty;
        }

        /// <summary>
        /// Obtém o nome da chave primária da tabela.
        /// </summary>
        /// <returns></returns>
        public string GetPK() {
            return this.PK;
        }

        /// <summary>
        /// Obtém o nome da tabela.
        /// </summary>
        /// <returns></returns>
        public string GetName() {
            return this.Name;
        }

        /// <summary>
        /// Obtém os membros que não fazem parte da tabela.
        /// </summary>
        /// <returns></returns>
        public string GetExceptAtributes() {
            return this.ExceptAtributes;
        }

        /// <summary>
        /// Adiciona um novo Join.
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="PK"></param>
        /// <param name="FK"></param>
        public void AddJoin(Tabela tb, string PK, string FK, string FK_membro, string FK_alias, int index) {
            if (this.join == null) this.join = new List<Join>();
            this.join.Add(new Join(tb, FK, PK, FK_membro, FK_alias, index));
        }

        /// <summary>
        /// Adiciona um novo Join.
        /// </summary>
        /// <param name="join"></param>
        public void AddJoin(Join join) {
            if (this.join == null) this.join = new List<Join>();
            this.join.Add(join);
        }

        /// <summary>
        /// Retorna o objeto Tabela.
        /// </summary>
        /// <returns></returns>
        public Tabela GetTable() {
            return this;
        }

        /// <summary>
        /// Retorn a quantidade de joins da tabela.
        /// </summary>
        /// <returns></returns>
        public int GetJoinCount() {
            return this.join.Count();
        }

        /// <summary>
        /// OBtém o primeiro índice do Join.
        /// </summary>
        /// <returns></returns>
        public Join GetJoin() {
            return this.join[0];
        }

        /// <summary>
        /// Obtém o Join pelo Indice.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Join GetJoin(int index) {
            if (index > GetJoinCount() - 1) index = 0;
            return this.join[index];
        }
        #endregion
    }



    public class Join
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define a chave primária da tabela.
        /// </summary>
        public string PK { get; set; }
        /// <summary>
        /// Obtém ou define a chave estrangeira da tabela.
        /// </summary>
        public string FK { get; set; }
        /// <summary>
        /// Obtém ou define o nome da coluna na tabela estrangeira.
        /// </summary>
        public string FK_membro { get; set; }
        /// <summary>
        /// Obtém ou define o apelido para a coluna estrangeira.
        /// </summary>
        public string FK_alias { get; set; }
        /// <summary>
        /// Obtém ou define a Tabela.
        /// </summary>
        public Tabela tabela { get; set; }
        /// <summary>
        /// Obtém ou define o ordem de leitura da tabela.
        /// </summary>
        public int index { get; set; }
        #endregion

        /// <summary>
        /// Cria uma nova instância de Join.
        /// </summary>
        /// <param name="tabela">Tabela Join</param>
        /// <param name="FK">ID da tabela Join</param>
        /// <param name="PK">ID da tabela Join</param>
        /// <param name="FK_membro">Coluna da tabela Join</param>
        /// <param name="FK_alias">Novo Nome da coluna</param>
        /// <param name="index"></param>
        public Join(Tabela tabela, string FK, string PK, string FK_membro, string FK_alias, int index) {
            this.tabela = tabela;
            this.FK = FK;
            this.PK = PK;
            this.FK_membro = FK_membro;
            this.FK_alias = FK_alias;
            this.index = index;
        }

        /// <summary>
        /// Cria uma nova instância da classe Join.
        /// </summary>
        public Join() { }

        /// <summary>
        /// Obtém a sentença do Left Join com a tabela Join e as colunas de comparação.
        /// </summary>
        /// <param name="tabela_raiz"></param>
        /// <returns></returns>
        public string GetJoin(string tabela_raiz) {
            return " LEFT JOIN " + tabela.GetName() + " AS table" + index.ToString() + " ON table" + index.ToString() + "." + PK + " = " + tabela_raiz + "." + FK;
        }

        /// <summary>
        /// Obtém o nome a coluna da tabela Join a ser selecionada.
        /// </summary>
        /// <returns></returns>
        public string GetFK_membro() {
            return ",table" + index.ToString() + "." + FK_membro + " AS " + FK_alias + "#";
        }

        /// <summary>
        /// Obtém o nome da columa junto com o nome da tabela.
        /// </summary>
        /// <param name="column_name"></param>
        /// <returns></returns>
        public string GetColumn(string column_name) {
            return " table" + index.ToString() + "." + column_name;
        }

        /// <summary>
        /// Define a tabela do Join com o index.
        /// </summary>
        /// <param name="tabela">Objeto tabela.</param>
        /// <param name="index">Índice do Join.</param>
        /// <returns></returns>
        public Join LeftJoin(Tabela tabela, int index) {
            this.tabela = tabela;
            this.index = index;
            return this;
        }

        /// <summary>
        /// Define a Chave estrangeira para comparar.
        /// </summary>
        /// <param name="FK">Nome da coluna na tabela raiz.</param>
        /// <returns></returns>
        public Join On(string FK) {
            this.FK = FK;
            return this;
        }

        /// <summary>
        /// Define a Chave Primária da tabela Join.
        /// </summary>
        /// <param name="PK">Nome da coluna chave primária.</param>
        /// <returns></returns>
        public Join Equals(string PK) {
            this.PK = PK;
            return this;
        }

        /// <summary>
        /// Nome da coluna a ser selecionada na tabela Join.
        /// </summary>
        /// <param name="FK_membro"></param>
        /// <returns></returns>
        public Join Select(string FK_membro) {
            this.FK_membro = FK_membro;
            return this;
        }

        /// <summary>
        /// Apelido da coluna na tabela Join.
        /// </summary>
        /// <param name="FK_alias"></param>
        /// <returns></returns>
        public Join As(string FK_alias) {
            this.FK_alias = FK_alias;
            return this;
        }
    }
}
