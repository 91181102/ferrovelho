using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class PessoaContato: Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de contato.
        /// </summary>
        public string tipo { get; set; }
        /// <summary>
        /// Obtém ou define o valor do contato.
        /// </summary>
        public string contato { get; set; }
        /// <summary>
        /// Obtém ou define uma observação.
        /// </summary>
        public string obs { get; set; }
        /// <summary>
        /// Obtém ou define a data de pagamento.
        /// </summary>
        public int pessoa_id { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe PessoaContato.
        /// </summary>
        public PessoaContato() {
            this.SetDefaultValues();
            this.SetTabela("id", "PESSOA_CONTATOS", "Request");
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.tipo = string.Empty;
            this.contato = string.Empty;
            this.obs = string.Empty;
            this.pessoa_id = -1;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.pessoa_contato.pessoa_contato.crud.Table = this.GetName();
            Rotas.pessoa_contato.pessoa_contato.crud.PK = this.GetPK();
            Rotas.pessoa_contato.pessoa_contato.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.tipo);
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.contato);
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.obs);
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.pessoa_id);
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.pessoa_contato.pessoa_contato.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Obtém a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            this.contato = contato.Trim();
            if (contato.Length > 99) contato = contato.Substring(0, 99).Trim();
            this.obs = obs.Trim();
            if (obs.Length > 99) obs = obs.Substring(0, 99).Trim();

            if (string.IsNullOrEmpty(contato)) {
                this.SetErro("O campo CONTATO não pode ser vazio.");
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(PessoaContato c) {
            this.id = c.id;
            this.tipo = c.tipo;
            this.contato = c.contato;
            this.obs = c.obs;
            this.pessoa_id = c.pessoa_id;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Obtém uma Intent com os dados da classe.
        /// </summary>
        /// <returns></returns>
        public Intent GetIntent() {
            var i = new Intent();
            i.PutExtra("nomes", new string[] { "TELEFONE", "E-MAIL", "OUTRO" });
            i.PutExtra("ids", new string[] { "T", "E", "O" });
            return i;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public PessoaContatoController Request {
            get {
                Rotas.pessoa_contato.pessoa_contato.SetDelegate(SetParam);
                return Rotas.pessoa_contato; }
        }
    }
}
