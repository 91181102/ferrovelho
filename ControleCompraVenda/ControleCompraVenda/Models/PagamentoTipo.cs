using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class PagamentoTipo : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do empresa.
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe PagamentoTipo.
        /// </summary>
        public PagamentoTipo() {
            this.SetDefaultValues();
            this.SetTabela("id", "PAGAMENTO_TIPOS", "Request");
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.nome = string.Empty;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.pagamento_tipo.pagamento_tipo.crud.Table = this.GetName();
            Rotas.pagamento_tipo.pagamento_tipo.crud.PK = this.GetPK();
            Rotas.pagamento_tipo.pagamento_tipo.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.pagamento_tipo.pagamento_tipo.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.pagamento_tipo.pagamento_tipo.crud.columns.Add(this.nome);
            Rotas.pagamento_tipo.pagamento_tipo.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.pagamento_tipo.pagamento_tipo.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Retorna a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            nome = nome.Trim();
            if (nome.Length > 99) nome = nome.Substring(0, 99).Trim();
            if (string.IsNullOrEmpty(nome)) {
                SetErro("O campo NOME não pode ser vazio.");
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(PagamentoTipo c) {
            this.id = c.id;
            this.nome = c.nome;
            this.ativo = c.ativo;
        }


        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public PagamentoTipoController Request
        {
            get
            {
                Rotas.pagamento_tipo.pagamento_tipo.SetDelegate(SetParam);
                return Rotas.pagamento_tipo;
            }
        }
    }
}
