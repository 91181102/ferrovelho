using ControleCompraVenda.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Controllers
{
    /// <summary>
    /// Cria uma nova instância da classe DefaultController.
    /// </summary>
    /// <typeparam name="T">Classe a ser usada.</typeparam>
    /// <remarks>
    /// Esta classe guarda os métodos de acesso ao SQL.
    /// </remarks>
    public class DefaultController<T> where T : class
    {
        #region: Membros da classe
        /// <summary>
        /// Objeto CRUD com o acesso ao SQL.
        /// </summary>
        public Crud<T> crud = new Crud<T>();
        /// <summary>
        /// Delegate para criar um ponteiro de função.
        /// </summary>
        public delegate void PassControl();
        /// <summary>
        /// Ponteiro de função a ser executada para popular a classe.
        /// </summary>
        public PassControl SetParam;
        #endregion

        /// <summary>
        /// Cria uma nova intância da classe DefaultController com as definições de tabelas do SQL.
        /// </summary>
        /// <param name="tb">Objeto Tabela.</param>
        public DefaultController(Tabela tb) {
            crud.Table = tb.GetName();
            crud.PK = tb.GetPK();
            crud.setExceptColumns(tb.GetExceptAtributes());
            crud.tab = tb.GetTable();
            //SetParam = new PassControl(Nada);
        }

        /// <summary>
        /// Define o ponteiro para a função de popular a classe.
        /// </summary>
        /// <param name="setparam"></param>
        public void SetDelegate(PassControl setparam) {
            this.SetParam = setparam;
        }

        /// <summary>
        /// Define a tabela a ser usada no controle.
        /// </summary>
        /// <param name="tb"></param>
        public void SetTable(Tabela tb) {
            crud.Table = tb.GetName();
            crud.PK = tb.GetPK();
            crud.setExceptColumns(tb.GetExceptAtributes());
            crud.tab = tb.GetTable();
        }

        /// <summary>
        /// Lista todos os registros.
        /// </summary>
        /// <returns></returns>
        public ResultRequest<List<T>> FindAll() {
            var result = new ResultRequest<List<T>>();
            result.data = crud.Select(0, string.Empty);
            if (!string.IsNullOrEmpty(crud.Error)) {
                result.status = false;
                result.message = crud.Error;
            }
            else result.message = result.data.Count().ToString() + " encontrado(s).";
            return result;
        }

        /// <summary>
        /// Lista todos os registros contenham o ID num determinado campo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public ResultRequest<List<T>> FindAll(int id, string field) {
            var result = new ResultRequest<List<T>>();
            result.data = crud.Select(id,field);
            if (!string.IsNullOrEmpty(crud.Error)) {
                result.status = false;
                result.message = crud.Error;
            }
            else result.message = result.data.Count().ToString() + " encontrado(s).";
            return result;
        }

        /// <summary>
        /// Adiciona filtros.
        /// </summary>
        /// <param name="filtros"></param>
        /// <returns></returns>
        public ResultRequest<List<T>> FindAll(string filtros) {
            var result = new ResultRequest<List<T>>();
            result.data = crud.Select(0, filtros);
            if (!string.IsNullOrEmpty(crud.Error)) {
                result.status = false;
                result.message = crud.Error;
            }
            else result.message = result.data.Count().ToString() + " encontrado(s).";
            return result;
        }

        /// <summary>
        /// Retorna o registro pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultRequest<T> Find(int id) {
            var result = new ResultRequest<T>();
            var data = crud.Select(id, string.Empty);
            if (data.Count() > 0) result.data = data.First();
            if (!string.IsNullOrEmpty(crud.Error)) {
                result.status = false;
                result.message = crud.Error; }
            else result.message = "Cadastro encontrado.";
            return result;
        }

        /// <summary>
        /// Insere um novo registro na tabela.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ResultRequest<object> Insert() {
            var result = new ResultRequest<object>();
            Dados.Request.ConsoleLog(crud.Table + ".Insert: Populando parâmetros.");
            SetParam();
            Dados.Request.ConsoleLog(crud.Table + ": Enviando dados.");
            result.status = crud.Insert();
            if (!result.status)
                result.message = crud.Error;
            else result.message = "Cadastro criado com secesso.";
            return result;
        }

        /// <summary>
        /// Altera um registro na tabela.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ResultRequest<object> Update() {
            var result = new ResultRequest<object>();
            Dados.Request.ConsoleLog(crud.Table + ".Update: Enviando dados.");
            SetParam();
            result.status = crud.Update();
            if (!result.status)
                result.message = crud.Error;
            else result.message = "Cadastro alterado com secesso.";
            Dados.Request.ConsoleLog(crud.Table + ".Update: Retornando requisição..");
            return result;
        }

        /// <summary>
        /// Exclui um registro da tabela.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ResultRequest<object> Delete(int id) {
            var result = new ResultRequest<object>();
            Dados.Request.ConsoleLog(crud.Table  + ".Delete: Enviando dados.");
            result.status = crud.Delete(id);
            if (!result.status)
                result.message = crud.Error;
            else result.message = "Cadastro excluído com sucesso.";
            Dados.Request.ConsoleLog(crud.Table + ".Delete: Retornando requisição..");
            return result;
        }

        /// <summary>
        /// Retorna o último ID da tabela.
        /// </summary>
        /// <returns></returns>
        public ResultRequest<object> GetLastID() {
            return crud.GetLastID();
        }

    }
}
