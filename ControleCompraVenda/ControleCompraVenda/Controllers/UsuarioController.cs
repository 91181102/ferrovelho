using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Models;

namespace ControleCompraVenda.Controllers
{
    public class UsuarioController
    {
        public DefaultController<Usuario> usuario;

        public UsuarioController(Tabela tb) {
            usuario = new DefaultController<Usuario>(tb);
        }

        /// <summary>
        /// Obtém uma Intent com os dados da classe.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Retorna somente registros ativos.
        /// </remarks>
        public Intent GetIntent() {
            var result = usuario.FindAll();
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
        /// Faz o login do usuário no sistema.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool SetLogin(int id, string senha) {
            var result = usuario.FindAll();

            var query = from c in result.data
                        where c.id == id
                        && c.senha == senha
                        select c;

            if (query.Count() == 0) return false;

            Rotas.user = query.First();
            return true;
        }

        /// <summary>
        /// Checa se as credenciais do usuário e se ele é administrador.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <param name="senha">Senha.</param>
        /// <returns></returns>
        public bool CheckAdmin(int id, string senha) {
            var result = usuario.FindAll();

            var query = from c in result.data
                        where c.id == id
                        && c.senha == senha
                        && c.tipo == 1
                        select c;

            if (query.Count() == 0) return false;
            return true;
        }


    }
}
