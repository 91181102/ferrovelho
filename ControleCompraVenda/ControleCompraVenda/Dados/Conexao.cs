using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Conexao
    {
        #region: Atributos da classe
        /// <summary>
        /// Objeto de de conexão com o banco.
        /// </summary>  
        public MySql.Data.MySqlClient.MySqlConnection objCon = new MySql.Data.MySqlClient.MySqlConnection();
        /// <summary>
        /// Objeto de comando do SQL
        /// </summary>
        private MySqlCommand objcmd = null;
        /// <summary>
        /// Descrição de erro do SQL.
        /// </summary>
        private string error = "";
        /// <summary>
        /// String de consulta do SQL.
        /// </summary>
        private StringBuilder query { get; set; }
        /// <summary>
        /// Define um DataReader.
        /// </summary>
        private DataReader<MySqlDataReader> First { get; set; }
        #endregion

        #region: Parametros de credenciais
        /// <summary>
        /// Obtém ou define o caminho do servidor.
        /// </summary>
        private string server { get; set; }
        /// <summary>
        /// Obtém ou define o nome do banco de dados.
        /// </summary>
        private string dataBase { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário do banco de dados.
        /// </summary>
        private string user { get; set; }
        /// <summary>
        /// Obtém ou define a senha do usuário do banco de dados.
        /// </summary>
        private string password { get; set; }
        /// <summary>
        /// Define se as credenciais do config serão carregadas.
        /// </summary>
        private bool getConfig { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância de conexão.
        /// </summary>
        public Conexao() {
            this.query = new StringBuilder();
            this.getConfig = true;
            this.setCredentials();
        }

        /// <summary>
        /// Cria uma nova instância de conexão.
        /// </summary>
        /// <param name="server">caminho do servidor.</param>
        /// <param name="dataBase">Nome do banco de dados.</param>
        /// <param name="user">Nome do usuário do banco de dados.</param>
        /// <param name="password">Senha do usuário do banco de dados.</param>
        public Conexao(string server, string dataBase, string user, string password) {
            query = new StringBuilder();
            this.server = server;
            this.dataBase = dataBase;
            this.user = user;
            this.password = password;
        }
        #endregion

        #region: Credenciais
        /// <summary>
        /// Define as credendiais do banco.
        /// </summary>
        /// <param name="server">caminho do servidor.</param>
        /// <param name="dataBase">Nome do banco de dados.</param>
        /// <param name="user">Nome do usuário do banco de dados.</param>
        /// <param name="password">Senha do usuário do banco de dados.</param>
        public void setCredentials(string server, string dataBase, string user, string password) {
            this.server = server;
            this.dataBase = dataBase;
            this.user = user;
            this.password = password;
        }

        /// <summary>
        /// Obtém as credendiais do Config.
        /// </summary>
        public void setCredentials() {
            this.server = Config.server;
            this.dataBase = Config.dataBase;
            this.user = Config.user;
            this.password = Config.password;
        }

        /// <summary>
        /// Cria uma nova instância de conexão.
        /// </summary>
        /// <param name="server">caminho do servidor.</param>
        /// <param name="dataBase">Nome do banco de dados.</param>
        /// <param name="user">Nome do usuário do banco de dados.</param>
        /// <param name="password">Senha do usuário do banco de dados.</param>
        /// <param name="getConfig">"True" define que as credenciais serão carregadas do config, "false" define que só o campo dataBase será carregado.</param>
        public void setCredentials(string server, string dataBase, string user, string password, bool getConfig)
        {
            this.server = "server=" + server + ";";
            this.dataBase = "database=" + dataBase + ";";
            this.user = "user=" + user + ";";
            this.password = "password=" + password + ";persistsecurityinfo=True;SslMode=none;";
            this.getConfig = getConfig;
        }

        /// <summary>
        /// Obtém as credenciais do banco.
        /// </summary>
        /// <returns>Retorna a string de conexão com o banco.</returns>
        private string getCredentials() {
            if (getConfig) {
                return this.server +
                    this.dataBase +
                    this.user +
                    this.password; }
            else {
                return this.dataBase; }
        }
        #endregion

        #region: Métodos de conexão.
        /// <summary>
        /// Método para abrir uma conexão com o banco.
        /// </summary>
        /// <returns>Retorna true ou false informando que a conexão foi aberta.</returns>
        public bool getConnection()
        {
            /* Esta função abre a conexão com o banco 
            ' e retorna um valor booleano Verdadeiro ou Falso
            ' informando se a conexão está aberta
    
            ' Declaração de objeto para o tipo SqlConnection 
            ' enviando como parâmetro a string de conexão*/
            objCon = new MySql.Data.MySqlClient.MySqlConnection(getCredentials());
            // Efetua a tentativa de abertura de conexao, caso consiga envia True
            try
            {
                objCon.Open();
                return true;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// Método para abrir uma conexão com o banco.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool getConnection(string server)
        {
            //string database = "server=lemos_note;user=convidado;password=123456;database=radiodj16gospel;persistsecurityinfo=True;SslMode=none;";
            string database = "server=vm_lemos;user=convidado;password=123456;database=controle_compra_venda;persistsecurityinfo=True;SslMode=none;";
            objCon = new MySqlConnection(database);
            try
            {
                objCon.Open();
                return true;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                return false;
            }
        }



        /// <summary>
        /// Método para fechar uma conexão com o banco.
        /// </summary>
        /// <returns>Retorna true ou false informando se a conexão foi fechada..</returns>
        public bool closeConnection()
        {
            /*  ' Esta função fecha a conexão com o banco 
                ' e retorna um valor booleano Verdadeiro ou Falso
                ' informando se a conexão foi fechada

                ' Verifica se o estado da conexão é diferente de fechado
                ' se for verdadeiro, a conexao é fechada e o objeto destruído
                ' se for falso apenas destrói o objeto*/
            if (objCon.State != ConnectionState.Closed)
            {
                objCon.Close();
                objCon.Dispose();
                return true;
            }
            else
            {
                objCon.Dispose();
                return false;
            }
        }
        #endregion

        #region: Operações de consulta
        /// <summary>
        /// Define o objeto de conexão com uma nova query.
        /// </summary>
        /// <param name="query">Recebe uma query SELECT, INSERT, UPDATE ou DELETE.</param>
        public void PreparedStatement(string query)
        {
            this.objcmd = new MySqlCommand(query, objCon);
        }

        /// <summary>
        /// Define o objeto de conexão com a query definida na classe.
        /// </summary>
        public void PreparedStatement()
        {
            this.objcmd = new MySqlCommand(getQuery(), objCon);
        }

        /// <summary>
        /// Executa uma consulta no banco e retorna a quantidade de linhas afetadas ou -1 em caso de erro.
        /// Fecha a conexão.
        /// </summary>
        /// <returns>Retorna um inteiro com a quantidade de linhas afetadas.</returns>
        public int ExecuteNonQuery()
        {
            int rows = 0;
            try
            {
                rows = objcmd.ExecuteNonQuery();
                this.closeConnection();
                return rows;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                this.closeConnection();
                return -1;
            }
        }

        /// <summary>
        /// Executa uma consulta SQL e retorna a primeira coluna da primeira linha. Linhas e colunas aidionais são ignoradas.
        /// Fecha a conexão.
        /// </summary>
        /// <returns>Retorna um valor Object</returns>
        public object ExecuteScalar()
        {
            object result;
            try
            {
                result = objcmd.ExecuteScalar();
                this.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                this.closeConnection();
                return null;
            }
        }

        /// <summary>
        /// Executa uma consulta SQL e retorna o primeiro registro.
        /// </summary>
        /// <returns>Retorna um DataReader</returns>
        public bool ExecuteReader()
        {
            this.First = new DataReader<MySqlDataReader>();
            try
            {
                this.First.row = objcmd.ExecuteReader();
                if (this.First.row.HasRows)
                {
                    this.First.row.Read();
                    return true;
                }
                else
                {
                    this.First.row.Close();
                    this.closeConnection();
                    this.error = "Não há registros.";
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                this.closeConnection();
                return false;
            }
        }

        /// <summary>
        /// Fecha um dataReader.
        /// </summary>
        public void CloseReader()
        {
            try
            {
                this.First.row.Close();
                this.closeConnection();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Obtém uma tabela através de uma consulta ou retorna null em caso de erro.
        /// </summary>
        /// <returns>retorna um DataTable.</returns>
        public DataTable getTable()
        {
            try
            {
                MySqlDataAdapter adp = new MySqlDataAdapter(objcmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                this.closeConnection();
                return dt;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                this.closeConnection();
                return null;
            }
        }

        /// <summary>
        /// Obtém o erro de uma consulta enviado ao banco.
        /// </summary>
        /// <returns>Retorna um texto com os detalhes do erro.</returns>
        public string getError()
        {
            return this.error;
        }
        #endregion

        #region: Operações com Query
        /// <summary>
        /// Define uma nova query SQL.
        /// </summary>
        public void Clear()
        {
            this.query.Clear();
        }

        /// <summary>
        /// Define uma nova query SQL adicionando comandos.
        /// </summary>
        /// <param name="Text"></param>
        public void NewQuery(string Text)
        {
            this.query.Clear();
            this.query.Append(Text);
        }

        /// <summary>
        /// Adiciona um novo comando à query SQL.
        /// </summary>
        /// <param name="Text"></param>
        public void Append(string Text)
        {
            this.query.Append(Text);
        }

        /// <summary>
        /// Retorna toda a query SQL numa string.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        public string getQuery()
        {
            return this.query.ToString();
        }
        #endregion

        #region: Adiciona parâmetros.
        /// <summary>
        /// Adiciona um parametro nulo à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: DBNull.Value</param>
        public void Add(string parameter, DBNull value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parametro inteiro à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: número inteiro</param>
        public void Add(string parameter, int value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parametro double à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: número double</param>
        public void Add(string parameter, double value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parametro string à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: string</param>
        public void Add(string parameter, string value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parametro booleano à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: true ou false.</param>
        public void Add(string parameter, bool value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parâmetro DateTimme à query SQL
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor DateTime.</param>
        /// <param name="format">Formato ex.: yyyy-MM-dd</param>
        public void Add(string parameter, DateTime value, string format)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value.ToString(format)));
        }

        /// <summary>
        /// Adiciona um parametro DateTime à query SQL.
        /// O valor enviado ao banco será no formato: yyyy-MM-dd
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: DateTime</param>
        public void Add(string parameter, DateTime value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value.ToString("yyyy-MM-dd")));
        }

        /// <summary>
        /// Adiciona um parametro decimal à query SQL.        
        /// </summary>
        /// <param name="parameter">Nome do parâmetro.</param>
        /// <param name="value">Valor: número decimal.</param>
        public void Add(string parameter, decimal value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }

        /// <summary>
        /// Adiciona um parâmetro do tipo CHAR à query SQL.
        /// </summary>
        /// <param name="parameter">Nome do parâmero.</param>
        /// <param name="value">Valor CHAR.</param>
        public void Add(string parameter, char value)
        {
            objcmd.Parameters.Add(new MySqlParameter(parameter, value));
        }
        #endregion

        #region: Converte colunas de um DataReader
        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um inteiro.</returns>
        public int ToInt(string column)
        {
            return this.First.ToInt(this.First.row[column]);
        }

        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna uma string.</returns>
        public string ToString(string column)
        {
            return this.First.ToString(this.First.row[column]);
        }

        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um double.</returns>
        public Double ToDouble(string column)
        {
            return this.First.ToDouble(this.First.row[column]);
        }

        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um decimal.</returns>
        public Decimal ToDecimal(string column)
        {
            return this.First.ToDecimal(this.First.row[column]);
        }
        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um DateTime.</returns>
        public DateTime ToDateTime(string column)
        {
            return this.First.ToDateTime(this.First.row[column]);
        }
        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um booleano.</returns>
        public bool ToBoolean(string column)
        {
            return this.First.ToBoolean(this.First.row[column]);
        }
        /// <summary>
        /// Retorna o valor de uma coluna do DataReader.
        /// </summary>
        /// <param name="column">Nome da coluna.</param>
        /// <returns>Retorna um object.</returns>
        public object ToObject(string column)
        {
            return this.First.ToObject(this.First.row[column]);
        }
        #endregion
    }
}
