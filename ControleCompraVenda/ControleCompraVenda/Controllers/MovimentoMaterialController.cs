using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class MovimentoMaterialController
    {
        /// <summary>
        /// Controlador da classe MovimentoMaterial.
        /// </summary>
        public DefaultController<MovimentoMaterial> movimento_material;

        /// <summary>
        /// Cria uma nova instância da classe MovimentoMaterialController.
        /// </summary>
        /// <param name="tb"></param>
        public MovimentoMaterialController(Tabela tb) {
            movimento_material = new DefaultController<MovimentoMaterial>(tb);
        }

        /// <summary>
        /// Retorna todos os produtos de um movimento.
        /// </summary>
        /// <param name="movimento_id"></param>
        /// <returns></returns>
        public ResultRequest<List<MovimentoMaterial>> FindAll(int movimento_id) {
            return movimento_material.FindAll(movimento_id, "movimento_id");
        }

        /// <summary>
        /// Agrupa o resultado.
        /// </summary>
        /// <returns></returns>
        public ResultRequest<List<MovimentoMaterial>> GroupResult(string conditions) {
            var result = movimento_material.FindAll(conditions);
            if (!result.status) return result;

            int[] ids = (from i in result.data
                         orderby i.material
                         select i.material_id)
                         .Distinct()
                         .ToArray();

            int material_id = 0;
            var lista = new List<MovimentoMaterial>();
            MovimentoMaterial item;

            var query = from mov in result.data
                        where mov.material_id == material_id
                        select mov;

            foreach(var mov in result.data) 
                mov.Set_vl_total();

            foreach(int id in ids) {
                material_id = id;
                item = new MovimentoMaterial();
                item.material_id = material_id;
                item.material = query.First().material;
                item.qtd = query.Sum(o => o.qtd);
                item.volumes = query.Sum(o => o.volumes);
                item.Set_vl_total(query.Sum(o => o.vl_total));
                if (item.vl_total > 0 && item.qtd > 0)
                    item.vl_unit = item.vl_total / item.qtd;
                lista.Add(item);
            }

            result.data = lista;
            result.message = lista.Count().ToString("n0") + " encontrado(s).";
            return result;
        }
    }
}
