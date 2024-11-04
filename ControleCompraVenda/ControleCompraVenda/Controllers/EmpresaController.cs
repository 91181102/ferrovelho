using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class EmpresaController
    {
        /// <summary>
        /// Controlador da classe Empresa.
        /// </summary>
        public DefaultController<Empresa> empresa;

        /// <summary>
        /// Cria uma nova instância da classe EmpresaController.
        /// </summary>
        /// <param name="tb"></param>
        public EmpresaController(Tabela tb) {
            empresa = new DefaultController<Empresa>(tb);
        }

        /// <summary>
        /// Obtém uma Intent com os dados da classe.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna somente registros ativos.
        /// </remarks>
        public Intent GetIntent() {
            var result = empresa.FindAll();
            var i = new Intent();

            var query = from c in result.data
                        orderby c.nome
                        where c.ativo
                        select c;

            i.PutExtra("nomes", (from d in query select d.nome.ToUpper()).ToArray());
            i.PutExtra("ids", (from d in query select Convert.ToString(d.id)).ToArray());
            return i;
        }

        /// <summary>
        /// Obtém a primeira empresa da tabela.
        /// </summary>
        /// <returns></returns>
        public Empresa GetFirst() {
            var result = empresa.FindAll();

            var query = from c in result.data
                        orderby c.nome
                        where c.ativo
                        select c;

            if (query.Count() == 0) return new Empresa();
            return query.First();
        }
    }
}
