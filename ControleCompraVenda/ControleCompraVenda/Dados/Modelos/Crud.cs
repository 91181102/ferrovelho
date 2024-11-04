using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Crud<T> where T : class
    {
        #region: Atributos da classe
        /// <summary>
        /// Objeto de conexão com o banco de dados.
        /// </summary>
        //public DataContext Context { get; set; }
        /// <summary>
        /// Tabela vinculada à classe.
        /// </summary>
        //public Table<T> table { get; set; }
        /// <summary>
        /// Objeto de conexão com a base de dados.
        /// </summary>
        public Conexao conn { get; set; }

        /// <summary>
        /// Obtém ou define o nome das colunas da tabela.
        /// </summary>
        private string Propriedades { get; set; }
        /// <summary>
        /// Obtém ou define os parametros das colunas.
        /// </summary>
        private string Param { get; set; }
        /// <summary>
        /// Obtém ou define o nome da tabela.
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// Obtém ou define o nome da coluna de chave primária.
        /// </summary>
        public string PK { get; set; }
        /// <summary>
        /// Tabela da classe.
        /// </summary>
        public DataTable dt { get; set; }

        /// <summary>
        /// Guarda os valores a serem passados por parâmetro.
        /// </summary>
        public ArrayList columns { get; set; } = new ArrayList();

        /// <summary>
        /// Obtém ou define uma lista de colunas que não pertence à tabela.
        /// </summary>
        public List<string> ExceptColumns { get; set; } = new List<string>();

        /// <summary>
        /// Exibe a query montada.
        /// </summary>
        public string query = "";

        /// <summary>
        /// Obtém ou define uma mensagem de erro.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Objeto raiz da classe.
        /// </summary>
        public T crud { get; set; }
        /// <summary>
        /// Obtém ou define o objeto tabela.
        /// </summary>
        public Tabela tab { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de Cud<T>.
        /// </summary>
        public Crud()
        {
            this.conn = new Conexao();
            //this.Context = Conexao.getDataContext();
            this.dt = new DataTable();
            this.Error = "";
            this.crud = this.CreateNewObject();
        }

        public void Iniciatize()
        {
            this.conn = new Conexao();
            //this.Context = Conexao.getDataContext();
            this.dt = new DataTable();
            this.Error = "";
        }
        #endregion

        #region: Operações do CRUD

        /// <summary>
        /// Carrega uma tabela.
        /// </summary>
        /// <returns>Retorna um DataTable</returns>
        public DataTable Select(string Table, string ExceptColumns)
        {
            this.Table = Table;
            this.setExceptColumns(ExceptColumns);
            //this.conn.setCredentials("", conn. Conexao.getDataBase(), "", "");
            this.query = this.GetSelectQuery();
            this.conn.NewQuery(query);

            if (conn.getConnection())
            {
                try
                {
                    conn.PreparedStatement();
                    return conn.getTable();
                }
                catch (Exception e)
                {
                    this.Error = e.ToString();
                    return null;
                }
                finally { conn.closeConnection(); }
            }
            else { return null; }
        }

        /// <summary>
        /// Obtém uma tabela de uma query personalizada.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable Select(string query, string key, int id)
        {
            conn.Clear();
            conn.Append(query);

            if (conn.getConnection())
            {
                try
                {
                    conn.PreparedStatement();
                    conn.Add("@" + key, id);

                    return conn.getTable();
                }
                catch (Exception e)
                {
                    this.Error = e.ToString();
                    return null;
                }
                finally { conn.closeConnection(); }
            }
            else
            {
                this.Error = conn.getError();
                return null;
            }
        }

        /// <summary>
        /// Obtém uma tabela de uma query personalizada.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string SelectJson(string query) {
            conn.Clear();
            conn.Append(query);

            if (conn.getConnection()) {
                try {
                    conn.PreparedStatement();
                    return conn.ExecuteScalar().ToString(); }
                catch (Exception e) {
                    this.Error = e.ToString();
                    return null; }
                finally { conn.closeConnection(); } }
            else {
                this.Error = conn.getError();
                return null; }
        }


        /// <summary>
        /// Retorna a tabela ou um registro da tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> Select(int id, string field) {
            Dados.Request.ConsoleLog("CRUD: Consulta SQL Select(id).");
            this.Error = string.Empty;

            if (id > 0)
                this.conn.NewQuery(this.GetSelectQuery(id, field));
            else {
                this.conn.NewQuery(this.GetSelectQuery());
                if (!string.IsNullOrEmpty(field)) {
                    this.conn.Append(field); } }
            //else
            //    this.conn.NewQuery(this.GetSelectQuery(id, field));

            var dt = new DataTable();
            var lista = new List<T>();

            if (conn.getConnection()) {
                conn.PreparedStatement();
                try {
                    dt = conn.getTable(); }
                catch {
                    this.Error = conn.getError(); } }
            else {
                this.Error = conn.getError();
                Dados.Request.ConsoleLog("CRUD: Erro de Consulta SQL: " + this.Error);
                return null; }

            if (dt == null) {
                this.Error = conn.getError();
                Dados.Request.ConsoleLog("CRUD: Erro de Consulta SQL: " + this.Error);
                return lista; }

            var query = from row in dt.AsEnumerable()
                        select Parse.GetItem<T>(row);

            if (id > 0 && string.IsNullOrEmpty(field)) {
                Dados.Request.ConsoleLog("CRUD: Procurando o ID.");
                query = from row in dt.AsEnumerable()
                        where row.Field<int>("id").Equals(id)
                        select Parse.GetItem<T>(row);

                if (query.Count() > 0)
                    lista.Add(query.First()); }
            else {
                Dados.Request.ConsoleLog("CRUD: Populando lista.");
                if (query.Count() > 0)
                    lista = query.ToList(); }
            Dados.Request.ConsoleLog("CRUD: Retornando objeto.");
            return lista;
        }

        /// <summary>
        /// Faz o insert na tabela.
        /// </summary>
        /// <returns>Retorna true ou false.</returns>
        public bool Insert()
        {
            Dados.Request.ConsoleLog("CRUD: Consulta SQL Insert().");
            //this.conn.setCredentials("", Conexao.getDataBase(), "", "");
            this.conn.NewQuery(this.GetInsertQuery());
            this.query = this.GetInsertQuery();

            if (conn.getConnection())
            {
                try
                {
                    conn.PreparedStatement();

                    string[] colunas = Param.Replace(",,", "").Split(',');
                    int i = 0;
                    foreach (string item in colunas)
                    {
                        if (("@" + PK) != item.Trim())
                        {
                            TypeCode tipo = Type.GetTypeCode(columns[i].GetType());
                            this.AddParam(item, tipo, i);
                            i++;
                        }
                    }
                    Dados.Request.ConsoleLog("CRUD: Executando SQL Insert().");
                    if (conn.ExecuteNonQuery() > 0)
                        return true;
                    else
                    {
                        this.Error = conn.getError();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    this.Error = e.Message;
                    Dados.Request.ConsoleLog("CRUD: Erro SQL Insert()." + e.Message);
                    return false;
                }
                finally
                {
                    //conn.closeConnection();
                }
            }
            else
            {
                Dados.Request.ConsoleLog("CRUD: Erro SQL Insert()." + conn.getError());
                return false;
            }
        }

        /// <summary>
        /// Faz um Update na tabela.
        /// </summary>
        /// <returns>Retorna true ou false.</returns>
        public bool Update()
        {
            //this.conn.setCredentials("", Conexao.getDataBase(), "", "");
            this.conn.NewQuery(this.GetUpdateQuery());
            this.query = this.GetUpdateQuery();
            int i = 0;

            if (conn.getConnection())
            {
                try
                {
                    conn.PreparedStatement();
                    string[] colunas = Param.Replace(",,", "").Split(',');
                    foreach (string item in colunas)
                    {
                        if (("@" + PK) != item.Trim())
                        {
                            TypeCode tipo = Type.GetTypeCode(columns[i].GetType());
                            this.AddParam(item, tipo, i);
                            i++;
                        }
                    }
                    this.AddParam("@" + PK, TypeCode.Int32, i);

                    if (conn.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    this.Error = e.ToString(); return false;
                }
                finally
                { //conn.closeConnection();
                }
            }
            else { this.Error = conn.getError(); return false; }
        }

        /// <summary>
        /// Exclui um registro da tabela.
        /// </summary>
        /// <param name="id">Id do registro.</param>
        /// <returns>Retorna true ou false.</returns>
        public bool Delete(int id) {
            //this.conn.setCredentials("", Conexao.getDataBase(), "", "");
            this.conn.NewQuery(this.GetDeleteQuery());

            if (conn.getConnection()) {
                try {
                    conn.PreparedStatement();
                    conn.Add("@" + PK, id);

                    if (conn.ExecuteNonQuery() > 0)
                        return true;
                    else {
                        this.Error = conn.getError();
                        return false; } }
                catch (Exception e) {
                    this.Error = e.Message;
                    return false; }
                finally
                { //conn.closeConnection();
                }
            }
            else { return false; }
        }

        /// <summary>
        /// Executa uma query personalizada.
        /// </summary>
        /// <param name="query">QueryString a ser enviada.</param>
        /// <returns>Retorna true ou false.</returns>
        public bool Execute(string query) {
            this.conn.NewQuery(query);
            this.Error = string.Empty;

            if (conn.getConnection()) {
                try {
                    conn.PreparedStatement();

                    if (conn.ExecuteNonQuery() > 0)
                        return true;
                    else {
                        this.Error = conn.getError();
                        return false; } }
                catch {
                    this.Error = conn.getError();
                    return false; } }
            else {
                this.Error = conn.getError();
                return false; }
        }

        /// <summary>
        /// Preenche uma tabela com uma query personalizada.
        /// </summary>
        /// <param name="query">Consulta SQL.</param>
        /// <param name="tb">Tabela para ser populada.</param>
        public DataTable Execute(string query, DataTable tb) {
            //this.conn.setCredentials("", Conexao.getDataBase(), "", "");
            this.conn.NewQuery(query);

            if (conn.getConnection()) {
                try {
                    conn.PreparedStatement();
                    tb = conn.getTable();
                    return tb; }
                catch { this.Error = conn.getError(); return null; }
                finally { conn.closeConnection(); } }
            else { this.Error = conn.getError(); return null; }
        }

        /// <summary>
        /// Obtém o último ID da tabela.
        /// </summary>
        /// <returns></returns>
        public ResultRequest<object> GetLastID() {
            var result = new ResultRequest<object>();
            this.conn.NewQuery(" SELECT MAX(id) FROM " + this.Table);

            if (conn.getConnection()) {
                try {
                    conn.PreparedStatement();
                    result.data = conn.ExecuteScalar();
                    if (result.data == null) {
                        result.status = false;
                        result.message = conn.getError(); }
                } catch (Exception e) {
                    result.status = false;
                    result.message = e.ToString() + conn.getError(); } }
            return result;
        }

        /// <summary>
        /// Atualiza a tabela da classe.
        /// </summary>
        public void RefreshTable()
        {
            //var context = Conexao.getDataContext();
            //this.table = context.GetTable<T>();
        }

        /// <summary>
        /// Atualiza a tabela de dados.
        /// </summary>
        /// <param name="Table">Nome da tabela.</param>
        /// <param name="ExceptColumns">Nome das colunas de exceção.</param>
        public void RefreshTable(string Table, string ExceptColumns)
        {
            this.dt = this.Select(Table, ExceptColumns);
        }
        #endregion

        #region: Conversores
        /// <summary>
        /// Converte um DataTable numa lista.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> ToList(DataTable dt, int id)
        {
            this.Error = string.Empty;
            var lista = new List<T>();

            var query = from row in dt.AsEnumerable()
                        select Parse.GetItem<T>(row);

            if (id > 0)
            {
                query = from row in dt.AsEnumerable()
                        where row.Field<int>("id").Equals(id)
                        select Parse.GetItem<T>(row);

                if (query.Count() > 0)
                    lista.Add(query.First());
            }
            else
            {
                if (query.Count() > 0)
                    lista = query.ToList();
            }
            return lista;
        }
        #endregion

        #region: Operações internas
        /// <summary>
        /// Obtém as colunas da tabela.
        /// </summary>
        /// <returns></returns>
        private string GetProperties()
        {
            this.Propriedades = "";
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            int i = 0;

            foreach (PropertyInfo p in propriedades)
            {
                if (!ExceptColumns.Contains(p.Name.Trim()))
                {
                    Propriedades += " " + p.Name + ",";
                }
            }
            Propriedades += ",";
            Propriedades = Propriedades.Replace(",,", "");
            return Propriedades;
        }

        /// <summary>
        /// Obtém as colunas da tabela com alias.
        /// </summary>
        /// <param name="table_alias"></param>
        /// <returns></returns>
        private string GetProperties(string table_alias)
        {
            this.Propriedades = "";
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            int i = 0;

            foreach (PropertyInfo p in propriedades)
            {
                if (!ExceptColumns.Contains(p.Name.Trim()))
                {
                    Propriedades += " " + table_alias + "." + p.Name + ",";
                }
            }
            Propriedades += ",";
            Propriedades = Propriedades.Replace(",,", "");
            return Propriedades;
        }

        /// <summary>
        /// Adiciona nome de colunas na lista.
        /// </summary>
        /// <param name="columns">Nomes separados por vírgula.</param>
        public void setExceptColumns(string columns)
        {
            if (!string.IsNullOrEmpty(columns))
            {
                this.ExceptColumns.Clear();
                string[] Cols = columns.Split(',');
                foreach (string item in Cols)
                {
                    this.ExceptColumns.Add(item.Trim());
                }
            }
        }


        /// <summary>
        /// Obtém os parâmetros.
        /// </summary>
        /// <returns></returns>
        private string GetParam() {
            this.Param = "";
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            int i = 0;

            foreach (PropertyInfo p in propriedades) {
                if (!ExceptColumns.Contains(p.Name.Trim())) {
                    Param += " @" + p.Name + ","; } }
            Param += ",";
            return Param.Replace(",,", "");
        }

        /// <summary>
        /// Retorna uma query do tipo SELECT.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        private string GetSelectQuery() {
            var q = new System.Text.StringBuilder();
            q.Append("SELECT #@COLUMNS#");
            q.Append("FROM @TABLE;");
            
            if (tab != null)
                if (tab.GetJoinCount() > 0) {
                    q.Clear();
                    q.Append("SELECT #@COLUMNS#");
                    for (int i = 0; i < tab.GetJoinCount(); i++) {
                        q.Append(tab.GetJoin(i).GetFK_membro()); }
                    q.Append("FROM @TABLE#");
                    for (int i = 0; i < tab.GetJoinCount(); i++) {
                        q.Append(tab.GetJoin(i).GetJoin(Table)); } }
            string query = q.ToString();
            query = query.Replace("#", Environment.NewLine);
            query = query.Replace("@TABLE", Table);
            if (tab == null) {
                query = query.Replace("@COLUMNS", GetProperties()); }
            else {
                query = query.Replace("@COLUMNS", GetProperties(Table)); }
            return query;
        }

        /// <summary>
        /// Retorna uma query do tipo SELECT.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        private string GetSelectQuery(int id, string field) {
            var q = new System.Text.StringBuilder();
            q.Append("SELECT #@COLUMNS#");
            q.Append("FROM @TABLE ");
            //q.Append("WHERE " + field + "=" + id.ToString());
            if (string.IsNullOrEmpty(field))
                q.Append("WHERE @TABLE." + PK + "=" + id.ToString());
            else
                q.Append("#WHERE " + field + "=" + id.ToString());

            if (tab != null)
                if (tab.GetJoinCount() > 0) {
                    q.Clear();
                    q.Append("SELECT #@COLUMNS#");
                    for (int i = 0; i < tab.GetJoinCount(); i++) {
                        q.Append(tab.GetJoin(i).GetFK_membro()); }
                    q.Append("FROM @TABLE#");
                    for (int i = 0; i < tab.GetJoinCount(); i++) {
                        q.Append(tab.GetJoin(i).GetJoin(Table)); }
                    if (!string.IsNullOrEmpty(field))
                        q.Append("#WHERE " + field + "=" + id.ToString()); }
            string query = q.ToString();
            query = query.Replace("#", Environment.NewLine);
            query = query.Replace("@TABLE", Table);
            if (tab == null) {
                query = query.Replace("@COLUMNS", GetProperties()); }
            else {
                query = query.Replace("@COLUMNS", GetProperties(Table)); }
            return query;
        }

        /// <summary>
        /// Retorna uma query do tipo INSERT.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        private string GetInsertQuery()
        {
            string query =
                "INSERT INTO @TABLE#" +
                "    (@COLUMNS)#" +
                "VALUES#" +
                "    (@VALUES);";

            query = query.Replace("#", Environment.NewLine);
            query = query.Replace("@TABLE", Table);
            query = query.Replace("@COLUMNS", GetProperties().Replace(" " + PK + ",", ""));
            query = query.Replace("@VALUES", GetParam().Replace(" @" + PK + ",", ""));

            return query;
        }

        /// <summary>
        /// Retorna uma query do tipo UPDATE.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        private string GetUpdateQuery()
        {
            string query = "UPDATE @TABLE SET #";
            string[] columns = GetProperties().Split(',');
            this.Param = this.GetParam();
            int i = 0;

            foreach (string item in columns)
            {
                if (PK != item.Trim())
                {
                    query += "    ITEM = @ITEM".Replace("ITEM", item.Trim());
                    if (i < columns.Count() - 1)
                        query += ",#";
                }
                i++;
            }
            query += "#,updated_at = CURRENT_TIMESTAMP";
            query += "#WHERE PK = @PK;";
            query = query.Replace("@TABLE", Table);
            query = query.Replace("#", Environment.NewLine);
            query = query.Replace("PK", PK);

            return query;
        }

        /// <summary>
        /// Retorna uma query do tipo DELETE.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        private string GetDeleteQuery()
        {
            string query = "DELETE FROM @TABLE WHERE PK = @PK;";
            query = query.Replace("@TABLE", Table);
            query = query.Replace("PK", PK);
            return query;
        }

        /// <summary>
        /// Adiciona os parâmetros na query.
        /// </summary>
        /// <param name="Param">Nome do parâmetro.</param>
        /// <param name="value">Tipo de valor.</param>
        /// <param name="index">Índice do ArrayList.</param>
        private void AddParam(string Param, TypeCode value, int index)
        {
            if (string.IsNullOrEmpty(Param))
                return;
            switch (value)
            {
                case TypeCode.Boolean:
                    this.query = query.Replace(Param.Trim(), "'1'");
                    this.conn.Add(Param.Trim(), Convert.ToBoolean(columns[index]));
                    break;
                case TypeCode.Int16:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), Convert.ToInt16(columns[index]));
                    break;
                case TypeCode.Int32:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), Convert.ToInt32(columns[index]));
                    break;
                case TypeCode.Double:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), Convert.ToDouble(columns[index]));
                    break;
                case TypeCode.Decimal:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), Convert.ToDecimal(columns[index]));
                    break;
                case TypeCode.DateTime:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), Convert.ToDateTime(columns[index]));
                    break;
                case TypeCode.SByte:
                    this.query = query.Replace(Param.Trim(), "'1'");
                    this.conn.Add(Param.Trim(), Convert.ToBoolean(columns[index]));
                    break;
                default:
                    this.query = query.Replace(Param.Trim(), columns[index].ToString());
                    this.conn.Add(Param.Trim(), columns[index].ToString());
                    break;
            }
        }

        /// <summary>
        /// Exibe os atributos da classe com seus valores.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        public override string ToString()
        {
            string Propriedades = "";

            PropertyInfo[] propriedades = typeof(T).GetProperties();
            int i = 0;

            foreach (PropertyInfo p in propriedades)
            {
                Propriedades += p.Name + p.GetValue(p.Attributes).ToString();
                if (i < propriedades.Count() - 1)
                    Propriedades += ", " + Environment.NewLine;
                i++;
            }

            return Propriedades;
        }

        /// <summary>
        /// Adiciona uma string na coluna caso o valor não seja null.
        /// </summary>
        /// <param name="Value">Valor da coluna.</param>
        /// <param name="Default">Valor default da coluna.</param>
        public void ColumnsAdd(string Value, string Default)
        {
            if (!string.IsNullOrEmpty(Value))
                columns.Add(Value);
            else
                columns.Add(Default);
        }

        /// <summary>
        /// Retorna o resultado da operação.
        /// </summary>
        /// <param name="value">True ou false.</param>
        /// <param name="operation">nome da operação: INSERT, UPDATE ou DELETE.</param>
        /// <returns></returns>
        public ResultRequest<object> GetResult(bool value, string operation)
        {
            var obj = new ResultRequest<object>();
            if (!value)
            {
                obj.status = false;
                obj.message = this.Error;
                return obj;
            }
            if (operation == "INSERT")
                obj.message = "Cadastro criado com sucesso.";
            if (operation == "UPDATE")
                obj.message = "Cadastro alterado com sucesso.";
            if (operation == "DELETE")
                obj.message = "Cadastro excluído com sucesso.";
            return obj;
        }

        /// <summary>
        /// Obtém um objeto resut com o erro da validação.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResultRequest<object> GetErrorValidation(string message)
        {
            var obj = new ResultRequest<object>();
            obj.status = false;
            obj.message = message;
            return obj;
        }

        /// <summary>
        /// Cria uma nova instância do objeto raiz.
        /// </summary>
        /// <returns></returns>
        public T CreateNewObject() {
            // Cria uma instância do tipo definido.
            var obj = Activator.CreateInstance<T>();
            return obj;
        }
        #endregion
    }
}
