using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class PessoaController
    {
        /// <summary>
        /// Controlador da classe Pessoa.
        /// </summary>
        public DefaultController<Pessoa> pessoa;
        /// <summary>
        /// Lista de pessoas para busca.
        /// </summary>
        private List<Models.Pessoa> pessoas = new List<Pessoa>();

        /// <summary>
        /// Cria uma nova instância da classe PessoaController.
        /// </summary>
        /// <param name="tb"></param>
        public PessoaController(Tabela tb) {
            pessoa = new DefaultController<Pessoa>(tb);
        }

        #region: Buscar Pessoas
        /// <summary>
        /// Carrega a listagem de clientes.
        /// </summary>
        public void LoadLista() {
            var result = pessoa.FindAll();
            if (result.status)
                pessoas = result.data;
        }

        /// <summary>
        /// Retorna a lista de clientes que contenham trecho da palavra.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public List<Models.Pessoa> FindAll(string match) {
            var query = from c in pessoas
                        where c.nome.Contains(match.Trim())
                        orderby c.nome
                        select c;

            if (query.Count() == 0)
                return new List<Models.Pessoa>();

            return query.ToList();
        }

        /// <summary>
        /// Retorna a pessoa pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Select(int id) {
            var query = from c in pessoas
                        where c.id == id
                        select c;

            if (query.Count() == 0) return new Pessoa();
            return query.First();

        }

        /// <summary>
        /// Limpa a listagem de pessoas.
        /// </summary>
        public void ClearLista() {
            this.pessoas.Clear();
        }
        #endregion
    }
}
