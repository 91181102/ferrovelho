using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Empresa : Tabela
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
        /// Obtém ou define o email do empresa.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Obtém ou define a cnpj da empresa.
        /// </summary>
        public string cnpj { get; set; }
        /// <summary>
        /// Obtém ou define o endereço da empresa.
        /// </summary>
        public string endereco { get; set; }
        /// <summary>
        /// Obtém ou define o telefone da empresa.
        /// </summary>
        public string telefone { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Empresa.
        /// </summary>
        public Empresa() {
            this.SetDefaultValues();
            this.SetTabela("id", "EMPRESAS", "Request");
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.nome = string.Empty;
            this.email = string.Empty;
            this.cnpj = string.Empty;
            this.endereco = string.Empty;
            this.telefone = string.Empty;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.empresa.empresa.crud.Table = this.GetName();
            Rotas.empresa.empresa.crud.PK = this.GetPK();
            Rotas.empresa.empresa.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.empresa.empresa.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.empresa.empresa.crud.columns.Add(this.nome);
            Rotas.empresa.empresa.crud.columns.Add(this.email);
            Rotas.empresa.empresa.crud.columns.Add(this.cnpj);
            Rotas.empresa.empresa.crud.columns.Add(this.endereco);
            Rotas.empresa.empresa.crud.columns.Add(this.telefone);
            Rotas.empresa.empresa.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.empresa.empresa.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Faz a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            bool valid = true;
            this.nome = nome.Trim().ToUpper();
            this.email = email.Trim().ToLower();
            this.endereco = endereco.Trim();
            this.telefone = telefone.Trim();
            this.cnpj = cnpj.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                this.SetErro("O campo NOME não pode ser vazio.");
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Empresa c) {
            this.id = c.id;
            this.nome = c.nome;
            this.email = c.email;
            this.cnpj = c.cnpj;
            this.endereco = c.endereco;
            this.telefone = c.telefone;
            this.ativo = c.ativo;
        }
        
        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public EmpresaController Request {
            get {
                Rotas.empresa.empresa.SetDelegate(SetParam);
                return Rotas.empresa; }
        }
    }
}
