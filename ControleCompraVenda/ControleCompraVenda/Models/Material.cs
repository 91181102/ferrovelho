using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Material : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o ID da empresa que está fazendo a movimentação.
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Obtém ou define o ID do material.
        /// </summary>
        public int tipo_material_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do material.
        /// </summary>
        public string tipo_material { get; set; }
        /// <summary>
        /// Obtém ou define o saldo do material.
        /// </summary>
        public decimal preco_compra { get; set; }
        /// <summary>
        /// Obtém ou define a quantidade de volumes do material.
        /// </summary>
        public decimal preco_venda { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Material.
        /// </summary>
        public Material() {
            this.SetDefaultValues();
            this.SetTabela("id", "MATERIAIS", "tipo_material,Request");
            this.AddJoin(new Join().LeftJoin(new MaterialTipo().GetTable(), 1).On("tipo_material_id").Equals("id").Select("nome").As("tipo_material"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.nome = string.Empty;
            this.tipo_material_id = 0;
            this.tipo_material = string.Empty;
            this.preco_compra = 0;
            this.preco_venda = 0;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            //Popula a classe.
            Rotas.material.material.crud.Table = this.GetName();
            Rotas.material.material.crud.PK = this.GetPK();
            Rotas.material.material.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.material.material.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.material.material.crud.columns.Add(this.nome);
            Rotas.material.material.crud.columns.Add(this.tipo_material_id);
            Rotas.material.material.crud.columns.Add(this.preco_compra);
            Rotas.material.material.crud.columns.Add(this.preco_venda);
            Rotas.material.material.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.material.material.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Retorna a validação do objeto.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;
            nome = nome.ToUpper().Trim();

            if (string.IsNullOrEmpty(nome)) {
                SetErro("O campo NOME não pode ser vazio.");
                valid = false;
            }

            if (preco_compra <= 0) {
                SetErro("O campo PREÇO DE COMPRA não pode ser zero.");
                valid = false;
            }

            if (preco_venda <= 0) {
                SetErro("O campo PREÇO DE VENDA não pode ser zero.");
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Material c) {
            this.id = c.id;
            this.nome = c.nome;
            this.tipo_material_id = c.tipo_material_id;
            this.preco_compra = c.preco_compra;
            this.preco_venda = c.preco_venda;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public MaterialController Request {
            get {
                Rotas.material.material.SetDelegate(SetParam);
                return Rotas.material;
            }
        }
    }
}
