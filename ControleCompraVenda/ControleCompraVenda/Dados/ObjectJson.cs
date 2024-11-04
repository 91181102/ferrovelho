using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization; // Microsoft.Web.Extensions

namespace ControleCompraVenda.Dados
{
    public class ObjectJson<T>
    {
        private static JavaScriptSerializer serializer { get; set; }


        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public ObjectJson()
        {
            serializer = new JavaScriptSerializer();
        }


        /// <summary>
        /// Obtém o objeto a partir de um json.
        /// </summary>
        /// <param name="json">Objeto json.</param>
        /// <returns>Retorna o objeto.</returns>
        public static T getObject(string json)
        {
            T objeto = new JavaScriptSerializer().Deserialize<T>(json);
            return objeto;
        }

        /// <summary>
        /// Converte um objeto para uma string json.
        /// </summary>
        /// <param name="obj">Objeto para conversão</param>
        /// <returns></returns>
        public string Parse(object obj)
        {
            string json = new JavaScriptSerializer().Serialize(obj);
            return json;
        }

        //public string getJson() {
        //    return this.json.Replace("\n", Environment.NewLine);
        //}
    }
}
