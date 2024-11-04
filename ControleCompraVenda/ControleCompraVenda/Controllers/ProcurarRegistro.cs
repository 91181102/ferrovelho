using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Controllers
{
    public class ProcurarRegistro
    {
        private List<Models.Pessoa> pessoas;
        

        public ProcurarRegistro() {
            this.pessoas = new List<Models.Pessoa>();
        }

        public List<Models.Pessoa> FindAll(string nome) {
            var query = from c in pessoas
                        where c.nome.Contains(nome.Trim())
                        select c;

            if (query.Count() == 0)
                return new List<Models.Pessoa>();

            return query.ToList();
        }

    }
}
