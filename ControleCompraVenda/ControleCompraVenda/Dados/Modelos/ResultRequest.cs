using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class ResultRequest<T>
    {
        #region: Atributos da classe
        /// <summary>
        /// Informa se a requisição foi realizada com sucesso.
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// Mensagem referente ao status da requisição.
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Objeto de retorno do tipo definido na declaração.
        /// </summary>
        public T data { get; set; }

        private ObjectJson<T> obj = new ObjectJson<T>();

        /// <summary>
        /// Obtém ou define a paginação.
        /// </summary>
        public Paginacao page { get; set; }
        #endregion

        /// <summary>
        /// Cria uma nova instância da classe de resultado.
        /// </summary>
        public ResultRequest()
        {
            this.status = true;
            this.message = string.Empty;
            this.data = Activator.CreateInstance<T>();
            this.page = new Paginacao();
        }

        /// <summary>
        /// Retorna o json do objeto corrente.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var result = obj.Parse(this);
            return result;
        }

        /// <summary>
        /// Retorna a mensagem de erro.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ToJson(string message)
        {
            var r = new ResultRequest<object>();
            r.status = false;
            r.message = message;
            var result = obj.Parse(r);
            return result;
        }

        /// <summary>
        /// Retorna a mensagem personalida.
        /// </summary>
        /// <param name="message">Mensagem.</param>
        /// <param name="status">true ou false.</param>
        /// <returns></returns>
        public string ToJson(bool status, string message)
        {
            var r = new ResultRequest<object>();
            r.status = status;
            r.message = message;
            var result = obj.Parse(r);
            return result;
        }

        /// <summary>
        /// Retorna texto de quantidade de registros encontrados.
        /// </summary>
        /// <param name="quant"></param>
        /// <returns></returns>
        public string Count(int quant)
        {
            return "@total registros encontrados.".Replace("@total", quant.ToString());
        }
    }
}
