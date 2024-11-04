using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class CrudOptions<T>
    {
        //private Crud<T> request;
        //private string rota = string.Empty;

        //public CrudOptions(string rota)
        //{
        //    request = new Crud<T>();
        //    this.rota = rota;
        //}

        ///// <summary>
        ///// Cria um novo registro.
        ///// </summary>
        ///// <param name="c"></param>
        ///// <returns></returns>
        //public ResultRequest<object> Create(T c)
        //{
        //    var result = new ResultRequest<object>();
        //    request = new Crud<T>();
        //    var config = Rotas.GetByApi(rota, "POST");
        //    result = request.PostToApi(config, c);

        //    return result;
        //}

        ///// <summary>
        ///// Atualiza um registro.
        ///// </summary>
        ///// <param name="c"></param>
        ///// <returns></returns>
        //public ResultRequest<object> Update(int id, T c)
        //{
        //    var result = new ResultRequest<object>();
        //    var config = Rotas.GetByApi(rota, "PUT", "id");
        //    result = request.PutToApi(config, c, "id", id);
        //    return result;
        //}

        ///// <summary>
        ///// Exclui um registro.
        ///// </summary>
        ///// <param name="c"></param>
        ///// <returns></returns>
        //public ResultRequest<object> Delete(int id)
        //{
        //    var result = new ResultRequest<object>();
        //    var config = Rotas.GetByApi(rota, "DELETE", "id");
        //    result = request.DeleteToApi(config, id, "id");
        //    return result;
        //}

        ///// <summary>
        ///// Lista todos os registro.
        ///// </summary>
        ///// <param name="c"></param>
        ///// <returns></returns>
        //public ResultRequest<List<T>> FindAll()
        //{
        //    var result = new ResultRequest<List<T>>();
        //    var config = Rotas.GetByApi(rota, "GET");
        //    result = request.GetByListObject(config);
        //    return result;
        //}

        ///// <summary>
        ///// Procura um registro.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ResultRequest<T> Find(int id)
        //{
        //    var result = new ResultRequest<T>();
        //    var config = Rotas.GetByApi(rota, "GET", "id");
        //    result = request.GetByIDObject(config, id, "id");
        //    return result;
        //}

        /// <summary>
        /// Exibe uma caixa de mensagem.
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowMessage(string msg) {
            System.Windows.Forms.MessageBox.Show(msg, "Mensagem",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de erro.
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg) {
            System.Windows.Forms.MessageBox.Show(msg, "Erro",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de confirmação e retorna true ou false.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetConfirm(string msg) {
            var confirm = System.Windows.Forms.MessageBox.Show(msg, "Confirmação",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question);

            if (confirm == System.Windows.Forms.DialogResult.Yes) return true;
            else return false;
        }
    }
}
