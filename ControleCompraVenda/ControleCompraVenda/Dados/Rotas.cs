using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Controllers;
using ControleCompraVenda.Models;

namespace ControleCompraVenda.Dados
{
    public class Rotas
    {
        #region: Sistema
        /// <summary>
        /// Objeto usuário para guardar o retorno de Login.
        /// </summary>
        public static Models.Usuario user = new Models.Usuario();
        /// <summary>
        /// Objeto empresa (usada para movimentar os produtos.
        /// </summary>
        public static Models.Empresa empresa_atual = new Empresa();
        /// <summary>
        /// Controlador de impressão.
        /// </summary>
        public static ImpressaoController impressao = new ImpressaoController();
        #endregion

        #region: Classes
        /// <summary>
        /// Controlador da classe Usuario.
        /// </summary>
        public static UsuarioController usuario = new UsuarioController(new Usuario().GetTable());
        /// <summary>
        /// Controlador da classe Empresa.
        /// </summary>
        public static EmpresaController empresa = new EmpresaController(new Empresa().GetTable());
        /// <summary>
        /// Controlador da classe Estoque.
        /// </summary>
        public static EstoqueController estoque = new EstoqueController(new Estoque().GetTable());
        /// <summary>
        /// Controlador da classe Material.
        /// </summary>
        public static MaterialController material = new MaterialController(new Material().GetTable());
        /// <summary>
        /// Controlador da classe MaterialTipo.
        /// </summary>
        public static MaterialTipoController material_tipo = new MaterialTipoController(new MaterialTipo().GetTable());
        /// <summary>
        /// Controlador da classe Movimento.
        /// </summary>
        public static MovimentoController movimento = new MovimentoController(new Movimento().GetTable());
        /// <summary>
        /// Controlador da classe MovimentoMaterial.
        /// </summary>
        public static MovimentoMaterialController movimento_material = new MovimentoMaterialController(new MovimentoMaterial().GetTable());
        /// <summary>
        /// Controlador da classe Pagamento.
        /// </summary>
        public static PagamentoController pagamento = new PagamentoController(new Pagamento().GetTable());
        /// <summary>
        /// Controlador da classe PagamentoTipo.
        /// </summary>
        public static PagamentoTipoController pagamento_tipo = new PagamentoTipoController(new PagamentoTipo().GetTable());
        /// <summary>
        /// Controlador da classe PessoaContato.
        /// </summary>
        public static PessoaContatoController pessoa_contato = new PessoaContatoController(new PessoaContato().GetTable());
        /// <summary>
        /// Controlador da classe Pessoa.
        /// </summary>
        public static PessoaController pessoa = new PessoaController(new Pessoa().GetTable());
        /// <summary>
        /// Controlador da classe CaixaMovimento.
        /// </summary>
        public static CaixaMovimentoController caixa_movimento = new CaixaMovimentoController(new CaixaMovimento().GetTable());
        #endregion

        public Rotas()
        {
                      
        }

        private void nata() {
            //#region: Membros da classe
            ////private static string end_point = "http://lacsystem.azurewebsites.net";
            //private static string end_point = "http://localhost:19270";
            ///// <summary>
            ///// Objeto usuário para guardar o retorno de Login.
            ///// </summary>
            ////public static Cadastros.Models.Usuario user = new Cadastros.Models.Usuario();
            ////public static Cadastros.Models.CaixaConfig caixa_config = new Cadastros.Models.CaixaConfig();
            ////public static WebConfig login = new WebConfig();

            //private static string apiCaixaConfig = "/api/CaixaConfig/";
            //private static string apiConta = "/api/Conta/";
            //private static string apiFavorecido = "/api/Favorecido/";
            //private static string apiGrupoConta = "/api/GrupoConta/";
            //private static string apiInstituicaoFinanceira = "/api/InstituicaoFinanceira/";
            //private static string apiItem = "/api/Item/";
            //private static string apiLinha = "/api/Linha/";
            //private static string apiLogin = "/api/Login/";
            //private static string apiPlanoConta = "/api/PlanoConta/";
            //private static string apiRotulo = "/api/Rotulo/";
            //private static string apiUsuario = "/api/Usuario/";

            //public static string CaixaConfig = "caixaconfig";
            //public static string Conta = "conta";
            //public static string Favorecido = "favorecido";
            //public static string GrupoConta = "grupoconta";
            //public static string InstituicaoFinanceira = "instituicaofinanceira";
            //public static string Item = "item";
            //public static string Linha = "linha";
            //public static string Login = "login";
            //public static string PlanoConta = "planoconta";
            //public static string Rotulo = "rotulo";
            //public static string Usuario = "usuario";
            //#endregion


            ///// <summary>
            ///// Retorna a WebConfig customizável.
            ///// </summary>
            ///// <param name="api">Nome da API</param>
            ///// <param name="method">GET, POST, PUT ou DELETE</param>
            ///// <param name="param">nome da variável.</param>
            ///// <returns></returns>
            //public static WebConfig GetByApi(string api, string method, string param)
            //{
            //    //user.token = "WLvtrMLAl4w=";
            //    var wc = new WebConfig();
            //    wc.argumento = string.Empty;
            //    wc.numUsu = "X-Custom-Token";
            //    wc.senha = user.token;
            //    wc.type = new WebConfigType(0, string.Empty, method.ToUpper());
            //    wc.url = end_point + GetApiName(api) + "?";
            //    if (!string.IsNullOrEmpty(param))
            //        wc.argumento = param + "=@" + param;
            //    return wc;
            //}

            ///// <summary>
            ///// Retorna um WebConfig customizável.
            ///// </summary>
            ///// <param name="api"></param>
            ///// <param name="method"></param>
            ///// <returns></returns>
            //public static WebConfig GetByApi(string api, string method)
            //{
            //    var wc = new WebConfig();
            //    wc.argumento = string.Empty;
            //    wc.numUsu = "X-Custom-Token";
            //    wc.senha = user.token;
            //    wc.type = new WebConfigType(0, string.Empty, method.ToUpper());
            //    wc.url = end_point + GetApiName(api);
            //    return wc;
            //}

            ///// <summary>
            ///// Retorna um WebConfig customizável.
            ///// </summary>
            ///// <param name="api"></param>
            ///// <param name="method"></param>
            ///// <returns></returns>
            //public static WebConfig PostToApi(string api, string method, string param)
            //{
            //    var wc = new WebConfig();
            //    wc.argumento = string.Empty;
            //    wc.numUsu = "X-Custom-Token";
            //    wc.senha = user.token;
            //    wc.type = new WebConfigType(0, string.Empty, method.ToUpper());
            //    wc.url = end_point + GetApiName(api);
            //    if (!string.IsNullOrEmpty(param))
            //        wc.argumento = param + "=@" + param;
            //    return wc;
            //}

            ///// <summary>
            ///// Obtém a API pelo nome.
            ///// </summary>
            ///// <param name="api"></param>
            ///// <returns></returns>
            //private static string GetApiName(string api)
            //{
            //    switch (api.ToLower())
            //    {
            //        case "caixaconfig":
            //            return apiCaixaConfig;
            //        case "conta":
            //            return apiConta;
            //        case "favorecido":
            //            return apiFavorecido;
            //        case "grupoconta":
            //            return apiGrupoConta;
            //        case "instituicaofinanceira":
            //            return apiInstituicaoFinanceira;
            //        case "item":
            //            return apiItem;
            //        case "linha":
            //            return apiLinha;
            //        case "login":
            //            return apiLogin;
            //        case "planoconta":
            //            return apiPlanoConta;
            //        case "rotulo":
            //            return apiRotulo;
            //        case "usuario":
            //            return apiUsuario;
            //        default:
            //            return string.Empty;
            //    }
            //}
        }
        
    }
}
