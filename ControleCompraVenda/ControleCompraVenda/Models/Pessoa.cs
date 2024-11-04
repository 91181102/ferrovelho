using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Pessoa : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do pessoa.
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Obtém ou define o cnpj ou cpf da pessoa.
        /// </summary>
        public string cnpj_cpf { get; set; }
        /// <summary>
        /// Obtém ou define o endereço da pessoa.
        /// </summary>
        public string endereco { get; set; }
        /// <summary>
        /// Obtém ou define uma observação da pessoa.
        /// </summary>
        public string obs { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        /// <summary>
        /// Obtém ou define uma lista de contatos da pessoa.
        /// </summary>
        public List<PessoaContato> contatos { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Usuario.
        /// </summary>
        public Pessoa() {
            this.SetTabela("id", "PESSOAS", "contatos,Request");
            this.contatos = new List<PessoaContato>();
            this.SetDefaultValues();
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.nome = string.Empty;
            this.cnpj_cpf = string.Empty;
            this.endereco = string.Empty;
            this.obs = string.Empty;
            this.contatos.Clear();
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.pessoa.pessoa.crud.Table = this.GetName();
            Rotas.pessoa.pessoa.crud.PK = this.GetPK();
            Rotas.pessoa.pessoa.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.pessoa.pessoa.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.pessoa.pessoa.crud.columns.Add(this.nome);
            Rotas.pessoa.pessoa.crud.columns.Add(this.cnpj_cpf);
            Rotas.pessoa.pessoa.crud.columns.Add(this.endereco);
            Rotas.pessoa.pessoa.crud.columns.Add(this.obs);
            Rotas.pessoa.pessoa.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.pessoa.pessoa.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Retorna a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            nome = nome.Trim().ToUpper();
            cnpj_cpf = cnpj_cpf.Trim().ToUpper();
            endereco = endereco.Trim().ToUpper();
            obs = obs.Trim().ToUpper();
            if (nome.Length > 99) nome = nome.Substring(0, 99).Trim();
            if (cnpj_cpf.Length > 14) cnpj_cpf = cnpj_cpf.Substring(0, 14).Trim();
            if (endereco.Length > 149) endereco = endereco.Substring(0, 149).Trim();
            if (obs.Length > 99) obs = obs.Substring(0, 99).Trim();

            if (string.IsNullOrEmpty(nome)) {
                SetErro("O campo NOME não pode ser vazio.");
                valid = false; }

            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Pessoa c) {
            this.id = c.id;
            this.nome = c.nome;
            this.cnpj_cpf = c.cnpj_cpf;
            this.endereco = c.endereco;
            this.obs = c.obs;
            this.ativo = c.ativo;
            this.contatos = c.contatos;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public PessoaController Request {
            get {
                Rotas.pessoa.pessoa.SetDelegate(SetParam);
                return Rotas.pessoa; }
        }
    }
}
