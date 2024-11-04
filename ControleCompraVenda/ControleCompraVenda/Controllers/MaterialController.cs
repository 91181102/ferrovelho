using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class MaterialController
    {
        /// <summary>
        /// Controlador da classe Material.
        /// </summary>
        public DefaultController<Material> material;
        /// <summary>
        /// Lista de produtos para busca.
        /// </summary>
        private List<Models.Material> materiais = new List<Material>();

        /// <summary>
        /// Cria uma nova instância da classe MaterialController.
        /// </summary>
        /// <param name="tb"></param>
        public MaterialController(Tabela tb) {
            material = new DefaultController<Material>(tb);
        }

        #region: Buscar Pessoas
        /// <summary>
        /// Carrega a listagem de materiais.
        /// </summary>
        public void LoadLista() {
            var result = material.FindAll();
            if (result.status)
                materiais = result.data;
        }

        /// <summary>
        /// Retorna a lista de materiais que contenham trecho da palavra.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public List<Models.Material> FindAll(string match) {
            var query = from c in materiais
                        where c.nome.Contains(match.Trim())
                        select c;

            if (query.Count() == 0)
                return new List<Models.Material>();

            return query.ToList();
        }

        /// <summary>
        /// Retorna a material pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material Select(int id) {
            var query = from c in materiais
                        where c.id == id
                        select c;

            if (query.Count() == 0) return new Material();
            return query.First();

        }

        /// <summary>
        /// Limpa a listagem de materiais.
        /// </summary>
        public void ClearLista() {
            this.materiais.Clear();
        }
        #endregion
    }
}
