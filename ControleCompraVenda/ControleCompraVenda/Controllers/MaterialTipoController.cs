using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class MaterialTipoController
    {
        /// <summary>
        /// Objeto controlador da classe.
        /// </summary>
        public DefaultController<MaterialTipo> material_tipo;

        /// <summary>
        /// Cria uma nova instância da classe MaterialTipoController.
        /// </summary>
        /// <param name="tb"></param>
        public MaterialTipoController(Tabela tb) {
            material_tipo = new DefaultController<MaterialTipo>(tb);
        }

        /// <summary>
        /// Obtém uma Intent com os dados da classe.
        /// </summary>
        /// <returns></returns>
        public Intent GetIntent() {
            var result = material_tipo.FindAll();
            var i = new Intent();

            var query = from c in result.data
                        orderby c.nome
                        where c.ativo
                        select c;

            i.PutExtra("nomes", (from d in query select d.nome).ToArray());
            i.PutExtra("ids", (from d in query select Convert.ToString(d.id)).ToArray());
            return i;
        }
    }
}
