using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Controllers;
using ControleCompraVenda.Models;

namespace ControleCompraVenda.Dados
{
    public class Request
    {
        #region: Cadastros
        /// <summary>
        /// Controlador da classe Usuario.
        /// </summary>
        public static UsuarioController usuario = new UsuarioController(new Usuario().GetTable());
        /// <summary>
        /// Controlador da classe Linha.
        /// </summary>
        //public static LinhaDados linha = new LinhaDados();
        /// <summary>
        /// Controlador da classe Item.
        /// </summary>
        ////public static ItemDados item = new ItemDados();
        /// <summary>
        /// Controlador da classe Rotulo.
        /// </summary>
       // public static RotuloDados rotulo = new RotuloDados();
        /// <summary>
        /// Controlador da classe PlanoConta.
        /// </summary>
        //public static PlanoContaDados planoConta = new PlanoContaDados();
        /// <summary>
        /// Controlador da classe Favorecido.
        /// </summary>
        //public static FavorecidoDados favorecido = new FavorecidoDados();
        /// <summary>
        /// Controlador da classe InstituicaoFinanceira.
        /// </summary>
        //public static InstituicaoFinanceiraDados instituicaoFinanceira = new InstituicaoFinanceiraDados();
        /// <summary>
        /// Controlador da classe GrupoConta.
        /// </summary>
        //public static GrupoContaDados grupoConta = new GrupoContaDados();
        /// <summary>
        /// Controlador da classe Conta.
        /// </summary>
        //public static ContaDados conta = new ContaDados();
        /// <summary>
        /// Controlador da classe CaixaConfig.
        /// </summary>
        //public static CaixaConfigDados caixaConfig = new CaixaConfigDados();
        #endregion

        #region: Operacional
        /// <summary>
        /// Controlador da classe Lancamento.
        /// </summary>
        //public static LancamentoDados lancamento = new LancamentoDados();
        #endregion

        #region: Repostas
        /// <summary>
        /// Retorna a resposta de uma requisição em formato de JSON.
        /// </summary>
        /// <param name="obj">string JSON</param>
        /// <returns></returns>
        public static HttpResponseMessage GetSucess(string obj) {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(obj);
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/json");

            return response;
        }

        /// <summary>
        /// Retorna a resposta de uma requisição.
        /// </summary>
        /// <param name="obj">string JSON</param>
        /// <param name="type">tipo de retorno. JSON, HTML </param>
        /// <returns></returns>
        public static HttpResponseMessage GetSucess(string obj, string type) {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(obj);
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(type);

            return response;
        }

        /// <summary>
        /// Retorna uma mensagem de erro em formato JSON.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResponseMessage GetError(string msg) {
            ResultRequest<ErrorRequest> obj = new ResultRequest<ErrorRequest>();
            obj.message = msg;
            obj.status = false;

            var response = new HttpResponseMessage();
            response.Content = new StringContent(obj.ToJson());
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/json");

            return response;
        }

        /// <summary>
        /// Retorna uma mensagem de erro em formato definido.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static HttpResponseMessage GetError(string msg, string type) {
            Dados.Request.ConsoleLog("Request.GetError(msg,type): " + msg);
            ResultRequest<ErrorRequest> obj = new ResultRequest<ErrorRequest>();
            obj.message = msg;
            obj.status = false;

            var response = new HttpResponseMessage();
            response.Content = new StringContent(obj.ToJson());
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(type);

            return response;
        }
        #endregion

        #region: Validação de Token
        /// <summary>
        /// Obtém o token da requisição.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        public static string GetToken(System.Net.Http.HttpRequestMessage Request)
        {
            IEnumerable<string> headerValues;
            var token = string.Empty;
            if (Request.Headers.TryGetValues("X-Custom-Token", out headerValues))
            {
                token = headerValues.FirstOrDefault();
            }
            return token;
        }

        /// <summary>
        /// Faz validação do token e obtém o código do usuário.
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static bool IsValidToken(System.Net.Http.HttpRequestMessage Request)
        {
            string token = GetToken(Request);
            int id = 0; // Dados.Request.usuario.GetCodUsuario(token);
            if (id > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Obtém o código do usuário.
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static int GetUsuarioId(System.Net.Http.HttpRequestMessage Request)
        {
            string token = GetToken(Request);
            int id = 0; // Dados.Request.usuario.GetCodUsuario(token);
            return id;
        }

        public static int HasAccess(System.Net.Http.HttpRequestMessage Request)
        {
            string token = GetToken(Request);
            int tipo = 0; // Dados.Request.usuario.GetTipoUsuario(token);
            if (tipo > -1)
                return tipo;
            else
                return -1;
        }

        /// <summary>
        /// Faz a validação do token.
        /// </summary>
        /// <param name="token">Token a ser verificado.</param>
        /// <returns>Retorna o código do funcionário.</returns>
        public int ValidateToken(string token)
        {
            var obj = string.Empty; // UsuarioDados.Descriptografar(token);
            string[] rows = obj.Split(',');

            // var cod_func = UsuarioDados.Descriptografar(token);
            var cod_func = rows[0];

            return Convert.ToInt32(cod_func);
        }
        #endregion

        /// <summary>
        /// Escreve etapa do debug no console.
        /// </summary>
        /// <param name="msg"></param>
        public static void ConsoleLog(string msg) {
            //msg = DateTime.Now.ToString("HH:mm:ss") + " " + msg + Environment.NewLine;
            //System.Diagnostics.Debug.Write(msg);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem.
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowMessage(string msg) {
            System.Windows.Forms.MessageBox.Show(msg, "Mensagem",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de erro.
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg) {
            System.Windows.Forms.MessageBox.Show(msg, "Erro",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de confirmação e retorna true ou false.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetConfirm(string msg) {
            var confirm = System.Windows.Forms.MessageBox.Show(msg, "Confirmação",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question);

            if (confirm == System.Windows.Forms.DialogResult.Yes) return true;
            else return false;
        }
    }
    public class ErrorRequest {
        public string msg { get; set; }
        public ErrorRequest() {
            this.msg = string.Empty;
        }
    }
}
