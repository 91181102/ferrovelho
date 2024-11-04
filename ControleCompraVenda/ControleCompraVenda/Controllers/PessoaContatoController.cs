using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Models;
using ControleCompraVenda.Dados;

namespace ControleCompraVenda.Controllers
{
    public class PessoaContatoController
    {
        /// <summary>
        /// Controlador da classe PessoaContato.
        /// </summary>
        public DefaultController<PessoaContato> pessoa_contato;

        /// <summary>
        /// Cria uma nova instância da classe PessoaContatoController.
        /// </summary>
        /// <param name="tb"></param>
        public PessoaContatoController(Tabela tb) {
            pessoa_contato= new DefaultController<PessoaContato>(tb);
        }

        /// <summary>
        /// Retorna todos os contatos da pessoa.
        /// </summary>
        /// <param name="pessoa_id"></param>
        /// <returns></returns>
        public ResultRequest<List<PessoaContato>> FindAll(int pessoa_id) {
            return pessoa_contato.FindAll(pessoa_id, "pessoa_id");
        }

    }
}
