using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class MaterialTipo: Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o tipo de movimento: E ou S.
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe MaterialTipo.
        /// </summary>
        public MaterialTipo() {
            this.SetDefaultValues();
            this.SetTabela("id", "MATERIAL_TIPOS", "Request");
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
            Rotas.material_tipo.material_tipo.crud.Table = this.GetName();
            Rotas.material_tipo.material_tipo.crud.PK = this.GetPK();
            Rotas.material_tipo.material_tipo.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.material_tipo.material_tipo.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.material_tipo.material_tipo.crud.columns.Add(this.nome);
            Rotas.material_tipo.material_tipo.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.material_tipo.material_tipo.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Retorna a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid(){
            bool valid = true;
            nome = nome.Trim().ToUpper();
            if (nome.Length > 30) nome = nome.Substring(0, 29).Trim();
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
        public void SetObject(MaterialTipo c) {
            this.id = c.id;
            this.nome = c.nome;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public MaterialTipoController Request {
            get {
                Rotas.material_tipo.material_tipo.SetDelegate(SetParam);
                return Rotas.material_tipo; }
        }
    }
}
