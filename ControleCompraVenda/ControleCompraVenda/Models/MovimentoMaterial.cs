using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCompraVenda.Dados;
using ControleCompraVenda.Controllers;

namespace ControleCompraVenda.Models
{
    public class MovimentoMaterial : Tabela
    {
        #region: Membros da classe
        /// <summary>
        /// Obtém ou define o ID da tabela.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Obtém ou define a ordem do item no pedido.
        /// </summary>
        public int ordem { get; set; }
        /// <summary>
        /// Obtém ou define o ID do movimento.
        /// </summary>
        public int movimento_id { get; set; }
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
        public decimal qtd { get; set; }
        /// <summary>
        /// Obtém ou define a quantidade de volumes do material.
        /// </summary>
        public decimal vl_unit { get; set; }
        /// <summary>
        /// Obtém ou define a quantidade de volumes.
        /// </summary>
        public int volumes { get; set; }
        /// <summary>
        /// Obtém ou define o total do registro.
        /// </summary>
        public decimal vl_total {
            get {
                if (vl_totalField > 0) return vl_totalField;
                else return this.qtd * this.vl_unit; }
        }
        /// <summary>
        /// Obtém ou define a situação do registro.
        /// </summary>
        public string situacao { get; set; }
        /// <summary>
        /// Obtém ou define o ID do usuario.
        /// </summary>
        public int usuario_id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do usuário.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Obtém ou define se o cadastro está ativo.
        /// </summary>
        public bool ativo { get; set; }
        private decimal vl_totalField = 0;
        private bool is_canceledField = false;
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe Material.
        /// </summary>
        public MovimentoMaterial() {
            this.SetDefaultValues();
            this.SetTabela("id", "MOVIMENTO_MATERIAIS", "material,vl_total,ordem,Request,usuario");
            this.AddJoin(new Join().LeftJoin(new Material().GetTable(), 1).On("material_id").Equals("id").Select("nome").As("material"));
            this.AddJoin(new Join().LeftJoin(new Usuario().GetTable(), 2).On("usuario_id").Equals("id").Select("nome").As("usuario"));
        }

        /// <summary>
        /// Retorna a classe para valor padrão.
        /// </summary>
        public void SetDefaultValues() {
            this.id = -1;
            this.movimento_id = -1;
            this.material_id = 0;
            this.material = string.Empty;
            this.situacao = "N";
            this.qtd = 0;
            this.vl_unit = 0;
            this.volumes = 0;
            this.ativo = true;
            this.usuario = string.Empty;
            this.usuario_id = -1;
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Envia os parâmetros da classe para as colunas.
        /// </summary>
        public void SetParam() {
            // Popula a classe.
            Rotas.movimento_material.movimento_material.crud.Table = this.GetName();
            Rotas.movimento_material.movimento_material.crud.PK = this.GetPK();
            Rotas.movimento_material.movimento_material.crud.setExceptColumns(this.GetExceptAtributes());
            // Limpa os parâmetros.
            Rotas.movimento_material.movimento_material.crud.columns.Clear();
            // Adiciona novos valores para os parâmetros.
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.movimento_id);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.material_id);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.qtd);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.vl_unit);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.volumes);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.situacao);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.usuario_id);
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.ativo);
            //A chave-primária é passada por último em caso de UPDATE ou DELETE.
            Rotas.movimento_material.movimento_material.crud.columns.Add(this.id);
        }

        /// <summary>
        /// Define o campo valor total.
        /// </summary>
        public void Set_vl_total() {
            this.vl_totalField = this.qtd * this.vl_unit;
        }

        /// <summary>
        /// Define o campo valor total.
        /// </summary>
        /// <param name="value"></param>
        public void Set_vl_total(decimal value) {
            this.vl_totalField = value;
        }

        /// <summary>
        /// Faz a validação dos campos.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            bool valid = true;

            //if (this.movimento_id < 0) {
            //    this.SetErro("O pedido não foi registrado.");
            //    valid = false; }

            if (Math.Abs(qtd) == 0) {
                this.SetErro("A quantidade não pode ser zero.");
                valid = false; }

            if (Math.Abs(vl_unit) == 0) {
                this.SetErro("O valor unitário não pode ser zero.");
                valid = false; }

            if (Math.Abs(volumes) == 0) {
                this.SetErro("A quantidade de volumes não pode ser zero.");
                valid = false; }

            return valid;
        }

        /// <summary>
        /// Obtém se o item está cancelado.
        /// </summary>
        /// <returns></returns>
        public bool IsCanceled() {
            return this.is_canceledField;
        }

        /// <summary>
        /// Define o status de cancelamento do item.
        /// </summary>
        /// <param name="value"></param>
        public void SetCanceled(bool value) {
            this.is_canceledField = value;
        }

        /// <summary>
        /// Faz uma cópia da instância.
        /// </summary>
        /// <returns></returns>
        public MovimentoMaterial Copy() {
            var c = new MovimentoMaterial();
            c.id = this.id;
            c.movimento_id = this.movimento_id;
            c.material_id = this.material_id;
            c.material = this.material;
            c.situacao = this.situacao;
            c.qtd = this.qtd;
            c.vl_unit = this.vl_unit;
            c.volumes = this.volumes;
            c.usuario_id = this.usuario_id;
            c.usuario = this.usuario;
            return c;
        }

        /// <summary>
        /// Altera a situação para cancelado.
        /// </summary>
        /// <returns></returns>
        public MovimentoMaterial CopyChangeSit(int usuario_id) {
            var c = new MovimentoMaterial();
            c.id = this.id;
            c.movimento_id = this.movimento_id;
            c.material_id = this.material_id;
            c.material = this.material;
            c.situacao = "C";
            c.qtd = this.qtd * -1;
            c.vl_unit = this.vl_unit * -1;
            c.volumes = this.volumes * -1;
            c.usuario = this.usuario;
            c.usuario_id = usuario_id;
            c.SetCanceled(this.IsCanceled());
            return c;
        }

        /// <summary>
        /// Define os valores do objeto.
        /// </summary>
        /// <param name="c"></param>
        public void SetObject(MovimentoMaterial c) {
            this.id = c.id;
            this.movimento_id = c.movimento_id;
            this.material_id = c.material_id;
            this.material = c.material;
            this.qtd = c.qtd;
            this.vl_unit = c.vl_unit;
            this.volumes = c.volumes;
            this.situacao = c.situacao;
            this.ativo = c.ativo;
        }

        /// <summary>
        /// Chama o controlador.
        /// </summary>
        /// <returns></returns>
        public MovimentoMaterialController Request {
            get {
                Rotas.movimento_material.movimento_material.SetDelegate(SetParam);
                return Rotas.movimento_material; }
        }
        #endregion
    }

    public class FiltroMovimentoMaterial
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
        /// <summary>
        /// Filtro para cliente.
        /// </summary>
        public Filtro chk_f_cliente { get; set; }
        /// <summary>
        /// Filtro para tipo de operação.
        /// </summary>
        public Filtro chk_tp_oper { get; set; }
        /// <summary>
        /// Filtro para período.
        /// </summary>
        public Filtro chk_f_periodo { get; set; }
        private Tabela tabela;
        private string tb_movimento = new Movimento().GetTable().GetName();
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de FiltroMovimentoMaterial.
        /// </summary>
        public FiltroMovimentoMaterial() {
            this.SetDefaultValues();
        }

        /// <summary>
        /// Cria uma nova instância da classe de FiltroMovimentoMaterial.
        /// </summary>
        /// <param name="tabela">Classe MovimentoMaterial</param>
        public FiltroMovimentoMaterial(Tabela tabela) {
            this.SetDefaultValues();
            this.tabela = tabela;
        }
        
        /// <summary>
        /// Reseta os valores do objeto.
        /// </summary>
        public void SetDefaultValues() {
            this.chk_f_tipo_material = new Filtro();
            this.chk_f_cod_material = new Filtro();
            this.chk_f_empresa = new Filtro();
            this.chk_f_cliente = new Filtro();
            this.chk_tp_oper = new Filtro();
            this.chk_f_periodo = new Filtro();
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
            if (chk_f_cliente.Checked) return true;
            if (chk_tp_oper.Checked) return true;
            if (chk_f_periodo.Checked) return true;
            return false;
        }

        /// <summary>
        /// Obtém o código html do filtro.
        /// </summary>
        /// <returns></returns>
        public string GetSql() {
            var sql = new System.Text.StringBuilder();
            var lista = new List<string>();
            var tb_movimento_material = tabela.GetName();
            var tb_material = tabela.GetJoin(0);
            
            if (this.IsChecked()) {
                sql.Append(" LEFT JOIN " + tb_movimento + " ON " + tb_movimento_material + ".movimento_id = " + tb_movimento + ".id ");
                sql.Append(" WHERE "); }

            if (chk_f_cod_material.Checked) {
                lista.Add(tb_movimento_material + ".material_id=" + chk_f_cod_material.GetInt() + " "); }

            if (chk_f_tipo_material.Checked) {
                lista.Add(tb_material.GetColumn("tipo_material_id") + "=" + chk_f_tipo_material.GetInt() + " "); }

            if (chk_f_empresa.Checked) {
                lista.Add(tb_movimento + ".empresa_id=" + chk_f_empresa.GetInt().ToString() + " "); }

            if (chk_f_cliente.Checked) {
                lista.Add(tb_movimento + ".pessoa_id=" + chk_f_cliente.GetInt().ToString() + " "); }

            if (chk_tp_oper.Checked) {
                lista.Add(tb_movimento + ".tipo='" + chk_tp_oper.GetString().ToString() + "' "); }

            if (chk_f_periodo.Checked) {
                lista.Add(tb_movimento + ".data_mov BETWEEN '" +
                    chk_f_periodo.GetDataDe().ToString("yyyy-MM-dd 00:00:00") +
                    "' AND '" +
                    chk_f_periodo.GetDataAte().ToString("yyyy-MM-dd 23:59:59") + "' "); }

            if (this.IsChecked())
                lista.Add(tb_movimento_material + ".ativo='1' ");
            else
                lista.Add(" WHERE " + tb_movimento_material + ".ativo='1' ");

            if (lista.Count() == 0) return string.Empty;

            foreach (string item in lista) {
                sql.Append(item);
                sql.Append(" AND "); }

            sql.Append(" AND ").Replace("AND  AND", string.Empty);
            string result = sql.ToString();

            return result.Replace("AND  AND", string.Empty);
        }
    }
}
