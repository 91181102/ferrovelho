using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Usuario : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Obtém ou define o email do usuário.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Obtém ou define a senha do usuário.
        /// </summary>
        public string senha { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de usuário. 0: usuario, 1: administrador.
        /// </summary>
        public int tipo { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion
        
        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Usuario.
        /// </summary>
        public Usuario() {
            this.SetDefaultValues();
            this.SetTabela("id", "USUARIOS", "token,usuario,confirmacao_senha,Request");
            //controller = new DefaultController<Usuario>(this);
            //controller.SetDelegate(SetParam);
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.nome = string.Empty;
            this.email = string.Empty;
            this.senha = string.Empty;
            this.tipo = 0;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Faz a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            this.nome = nome.Trim().ToUpper();
            this.email = email.Trim().ToLower();
            this.senha = senha.Trim();

            if (string.IsNullOrEmpty(nome)) {
                this.SetErro("O campo NOME não pode ser vazio.");
                valid = false; }

            if (string.IsNullOrEmpty(email)) {
                this.SetErro("O campo E-MAIL não pode ser vazio.");
                valid = false; }

            if (string.IsNullOrEmpty(senha)) {
                this.SetErro("O campo SENHA não pode ser vazio.");
                valid = false; }

            return valid;
        }

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.usuario.usuario.crud.Table = this.GetName();
            Rotas.usuario.usuario.crud.PK = this.GetPK();
            Rotas.usuario.usuario.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.usuario.usuario.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.usuario.usuario.crud.columns.Add(this.nome);
            Rotas.usuario.usuario.crud.columns.Add(this.email);
            Rotas.usuario.usuario.crud.columns.Add(this.senha);
            Rotas.usuario.usuario.crud.columns.Add(this.tipo);
            Rotas.usuario.usuario.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.usuario.usuario.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Usuario c) {
            this.id = c.id;
            this.nome = c.nome;
            this.email = c.email;
            this.senha = c.senha;
            this.tipo = c.tipo;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public UsuarioController Request {
            get {
                //Rotas.usuario.usuario.SetTable(this.GetTable());
                Rotas.usuario.usuario.SetDelegate(SetParam);
                return Rotas.usuario;
            }
        }
    }
}
