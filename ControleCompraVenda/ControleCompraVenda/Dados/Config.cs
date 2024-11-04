using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class Config
    {
        #region: Parametros de credenciais
        /// <summary>
        /// Obtém ou define o caminho do servidor.
        /// </summary>
        public static string server { get; private set; } = "server=vm_lemos;";//"server=localhost;";
        /// <summary>
        /// Obtém ou define o nome do banco de dados.
        /// </summary>
        public static string dataBase { get; private set; } =
            //"server=108.179.193.22;" + 
            //"user=techs832_lemos;" + 
            //"password=lemos123;" + 
            "database=controle_compra_venda;" + // _202106141336
            "persistsecurityinfo=True;SslMode=none;";
        /// <summary>
        /// Obtém ou define o nome do usuário do banco de dados.
        /// </summary>
        public static string user { get; private set; } = "user=convidado;"; //"user=root;";
        /// <summary>
        /// Obtém ou define a senha do usuário do banco de dados.
        /// </summary>
        public static string password { get; private set; } = "password=123456;"; //"password=76774737;";
        #endregion

        /// <summary>
        /// Define as credendiais para acesso ao banco de dados.
        /// </summary>
        /// <param name="setServer">Caminho do servidor de banco de dados.</param>
        /// <param name="setDataBase">Nome do banco de dados.</param>
        /// <param name="setUser">Nome do usuário do banco de dados.</param>
        /// <param name="setPassword">Senha do usuário do banco de dados.</param>
        public static void setCredentials(string setServer, string setDataBase, string setUser, string setPassword) {
            server = setServer;
            dataBase = setDataBase;
            user = setUser;
            password = setPassword;
        }

        /// <summary>
        /// Obtém o nome da base de dados.
        /// </summary>
        /// <returns></returns>
        public static string getDataBase() {
            return "controle_compra_venda."; // _202106141336
        }
    }
}
