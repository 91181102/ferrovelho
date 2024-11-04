using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class Estoque : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define o ID da empresa que está fazendo a movimentação.
        /// </summary>
        public int empresa_id { get; set; }
        /// <summary>
        /// Obtém ou define o ID do material.
        /// </summary>
        public int material_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do material.
        /// </summary>
        public string material { get; set; }
        /// <summary>
        /// Obtém ou define o saldo do material.
        /// </summary>
        public decimal saldo { get; set; }
        /// <summary>
        /// Obtém ou define a quantidade de volumes do material.
        /// </summary>
        public int volumes { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Estoque.
        /// </summary>
        public Estoque() {
            this.SetDefaultValues();
            this.SetTabela("id", "ESTOQUES", "material,Request");
            this.AddJoin(new Join().LeftJoin(new Material().GetTable(), 1).On("material_id").Equals("id").Select("nome").As("material"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.material_id = 0;
            this.material = string.Empty;
            this.empresa_id = 0;
            this.saldo = 0;
            this.volumes = 0;
            this.ativo = true;
        }
        #endregion

        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.estoque.estoque.crud.Table = this.GetName();
            Rotas.estoque.estoque.crud.PK = this.GetPK();
            Rotas.estoque.estoque.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.estoque.estoque.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.estoque.estoque.crud.columns.Add(this.empresa_id);
            Rotas.estoque.estoque.crud.columns.Add(this.material_id);
            Rotas.estoque.estoque.crud.columns.Add(this.saldo);
            Rotas.estoque.estoque.crud.columns.Add(this.volumes);
            Rotas.estoque.estoque.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.estoque.estoque.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(Estoque c) {
            this.id = c.id;
            this.empresa_id = c.empresa_id;
            this.material_id = c.material_id;
            this.saldo = c.saldo;
            this.volumes = c.volumes;
            this.ativo = c.ativo;
        }
        
        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public EstoqueController Request {
            get {
                Rotas.estoque.estoque.SetDelegate(SetParam);
                return Rotas.estoque; }
        }
    }

    /// <summary>
    /// Cria uma nova instância da classe de FiltroEstoque.
    /// </summary>
    public class FiltroEstoque
    {
        #region: Membros da classe
        /// <summary>
        /// Filtro para tipo de material.
        /// </summary>
        public Filtro chk_f_tipo_material { get; set; }
        /// <summary>
        /// Filtro para ID do material.
        /// </summary>
        public Filtro chk_f_cod_material { get; set; }
        /// <summary>
        /// Filtro para empresa.
        /// </summary>
        public Filtro chk_f_empresa { get; set; }
        private Tabela tabela;
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de FiltroEstoque.
        /// </summary>
        public FiltroEstoque() {
            this.SetDefaultValues();
        }

        public FiltroEstoque(Tabela tabela) {
            this.SetDefaultValues();
            this.tabela = tabela;
        }

        public void SetDefaultValues() {
            this.chk_f_tipo_material = new Filtro("TIPO DE MATERIAL");
            this.chk_f_cod_material = new Filtro("COD. DE MATERIAL");
            this.chk_f_empresa = new Filtro("EMPRESA");
        }
        #endregion

        /// <summary>
        /// Informa se há algum filtro ativado.
        /// </summary>
        /// <returns></returns>
        public bool IsChecked() {
            if (chk_f_tipo_material.Checked) return true;
            if (chk_f_cod_material.Checked) return true;
            if (chk_f_empresa.Checked) return true;
            return false;
        }

        /// <summary>
        /// Obtém o código html do filtro.
        /// </summary>
        /// <returns></returns>
        public string GetSql() {
            var sql = new System.Text.StringBuilder();
            var lista = new List<string>();

            if (this.IsChecked())
                sql.Append(" WHERE ");

            if (chk_f_cod_material.Checked) {
                lista.Add(tabela.GetName() + ".material_id=" + chk_f_cod_material.GetInt() + " ");
            }

            if (chk_f_tipo_material.Checked) {
                lista.Add(tabela.GetJoin(0).GetColumn("tipo_material_id") + "=" + chk_f_tipo_material.GetInt() + " ");
            }

            if (chk_f_empresa.Checked) {
                lista.Add(tabela.GetName() + ".empresa_id=" + chk_f_empresa.GetInt().ToString() + " ");
            }

            if (lista.Count() == 0) return string.Empty;

            foreach (string item in lista) {
                sql.Append(item);
                sql.Append(" AND ");
            }
            sql.Append(" AND ").Replace("AND  AND", string.Empty);
            string result = sql.ToString();

            return result.Replace("AND  AND", string.Empty);
        }

        /// <summary>
        /// Retorna os filtros utilizados.
        /// </summary>
        /// <returns></returns>
        public string toString() {
            var txt = new StringBuilder();
            if (!this.IsChecked()) return txt.ToString();
            txt.Append("FILTROS:" + Environment.NewLine);

            if (chk_f_tipo_material.Checked) 
                txt.Append(chk_f_tipo_material.toString() + Environment.NewLine);
            if (chk_f_cod_material.Checked)
                txt.Append(chk_f_cod_material.toString() + Environment.NewLine);
            if (chk_f_empresa.Checked)
                txt.Append(chk_f_empresa.toString() + Environment.NewLine);
            return txt.ToString();
        }
    }
}
