using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleCompraVenda.Dados;
using System.Data;

namespace ControleCompraVenda.Controllers
{
    public class FrenteCaixaController
    {
        #region: Membros da classe
        private View.TelaFrenteCaixa form;
        private Models.Material material = new Models.Material();
        private Models.Movimento movimento = new Models.Movimento();
        private Models.MovimentoMaterial mov = new Models.MovimentoMaterial();
        private string operacao = "VENDA";
        private bool IsVendaAtivada = false;
        private bool IsESCPressioned = false;
        #endregion

        /// <summary>
        /// Cria uma nova instância da classe FrenteCaixaControllers.
        /// </summary>
        /// <param name="form"></param>
        public FrenteCaixaController(View.TelaFrenteCaixa form) {
            this.form = form;
            form.Get_txt_codigo_material().KeyDown += new KeyEventHandler(this.txt_codigo_material_KeyDown);
            form.Get_txt_codigo_material().Leave += new EventHandler(this.txt_codigo_material_Leave);
            form.Get_txt_qtd().GotFocus += new EventHandler(Get_txt_qtd_GotFocus);
            form.Get_txt_qtd().LostFocus += new EventHandler(Get_txt_qtd_LostFocus);
            form.Get_txt_volumes().KeyDown += new KeyEventHandler(this.txt_volumes_KeyDown);
            form.Get_txt_volumes().Leave += new EventHandler(this.txt_volumes_Leave);
            form.Get_txt_qtd().Leave += new EventHandler(this.txt_qtd_Leave);
            form.Get_txt_qtd().KeyDown += new KeyEventHandler(this.txt_qtd_KeyDown);
            MTextBox.SetNumeric(form.Get_txt_codigo_material());
        }
        
        #region: Eventos de TextBox
        public void txt_codigo_material_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (IsVendaAtivada) {
                    this.ProcurarMaterial("QTD"); }
                else { 
                    this.NovaVenda(); }
                return; }

            if (e.KeyCode == Keys.Tab) {
                if (IsVendaAtivada) {
                    this.ProcurarMaterial("COD"); }
                else {
                    this.NovaVenda(); }
                return; }

            #region: Select Case
            switch (e.KeyCode) {
                case Keys.Enter:
                    break;
                case Keys.F1:
                    this.FecharVenda();
                    break;
                case Keys.F2:
                    this.OpenProcurarMaterial();
                    break;
                case Keys.F3:
                    this.CancelarMaterial();
                    break;
                case Keys.F4:
                    this.AlterarCliente();
                    break;
                case Keys.F5:
                    this.CancelarOperacao();
                    break;
                case Keys.F6:
                    this.NovaVenda();
                    break;
                case Keys.F7:
                    this.AlterarEmpresa();
                    break;
                default:
                    return;
            }
            #endregion
        }

        public void txt_codigo_material_Leave(object sender, EventArgs e) {
            if (!IsVendaAtivada) {
                this.NovaVenda();
                return; }
                
            this.ProcurarMaterial("QTD");
        }
        
        public void Get_txt_qtd_GotFocus(object sender, EventArgs e) {
            form.lb_F8.Visible = true;
        }
        public void Get_txt_qtd_LostFocus(object sender, EventArgs e) {
            form.lb_F8.Visible = false;
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Abre janela de busca de material
        /// </summary>
        private void OpenProcurarMaterial() {
            if (!IsVendaAtivada) {
                _MsgBox.Error("Inicie uma nova operação antes de selecionar material.");
                return; }
            var form = new View.TelaSelecionarMaterial();
            form.ShowDialog();
            if (form.IsSelected) {
                this.material = form.material;
                this.form.Get_txt_codigo_material().Text = this.material.id.ToString();
                this.RefreshMaterial("QTD"); }
            form.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Procura o item pelo código digitado no TextBox.
        /// </summary>
        /// <param name="txt">Próximo TextBox a selecionar.</param>
        private void ProcurarMaterial(string txt) {
            material.id = MTextBox.GetInt(form.Get_txt_codigo_material());

            if (material.id == 0) {
                MaterialErro();
                return; }

            var result = material.Request.material.Find(material.id);

            if (!result.status) {
                MaterialErro();
                return; }

            if (result.data.id == -1) {
                MaterialErro();
                return; }

            material = result.data;
            this.RefreshMaterial(txt);
        }

        /// <summary>
        /// Exibe erro de escolha de material.
        /// </summary>
        private void MaterialErro() {
            material.SetDefaultValues();
            material.nome = "Código de material inválido";
            this.RefreshMaterial("COD");
        }

        /// <summary>
        /// Abre janela de forma de pagamento e fecha a operação.
        /// </summary>
        private void FecharVenda() {
            if (movimento.materiais.Count() == 0) {
                _MsgBox.Error("O pedido precisa de pelo menos um item.");
                return; }

            if (!_MsgBox.Confirm("Deseja fechar a operação?"))
                return;

            var form = new View.TelaFrenteCaixaFechar();
            form.SetMovimento(this.movimento);
            form.ShowDialog();
            if (form.IsConfirmed) {
                movimento.flag_fechado = true;
                this.SalvarPedido();
                this.ImprimirRecibo(movimento.id);
                this.SetCaixaLivre();
                form.Dispose();
                GC.Collect(); }
            else {
                movimento.pagamentos.Clear(); }
        }

        /// <summary>
        /// Cancela um Item do pedido.
        /// </summary>
        private void CancelarMaterial() {
            if (movimento.materiais.Where(o => !o.IsCanceled()).Count() == 0) {
                _MsgBox.Error("Não há itens para cancelar.");
                return; }

            var form = new View.TelaCancelarItem();
            form.SetLista(this.movimento.materiais);
            form.ShowDialog();
            if (form.IsSelected) {
                this.RefreshItems(); }
            form.Dispose();
        }

        /// <summary>
        /// Altera o cliente/fornecedor do pedido.
        /// </summary>
        private void AlterarCliente() {            
            if (!IsVendaAtivada) {
                _MsgBox.Error("Inicie uma nova operação antes de alterar o cliente.");
                return; }
            var form = new View.TelaSelecionarCliente();
            form.ShowDialog();
            if (form.IsSelected) {
                this.movimento.pessoa_id = form.cliente.id;
                this.movimento.pessoa = form.cliente.nome;
                // Exibe o cabeçalho do pedido.
                this.RefreshCliente(); }
        }

        /// <summary>
        /// Altera o preço unitário do item.
        /// </summary>
        private void AlterarPrecoUnitario() {
            if (!IsVendaAtivada) {
                _MsgBox.Error("Inicie uma nova operação antes de alterar o preço.");
                return; }

            if (mov.material_id < 0) {
                _MsgBox.Error("Selecione um material antes de alterar o preço.");
                return; }

            var form = new View.TelaFrenteCaixaAlterarPreco();
            form.SetMaterial(this.mov);
            form.ShowDialog();
            if (form.IsChanged) {
                this.form.RefreshValues(this.mov, "QTD"); }
            form.Dispose();
        }

        /// <summary>
        /// Cancela a operação atual e define Caixa Livre.
        /// </summary>
        private void CancelarOperacao() {
            if (!_MsgBox.Confirm("Deseja cancelar a operação atual?"))
                return;

            this.SetCaixaLivre();
        }

        /// <summary>
        /// Reseta os campos e inicia a nova venda.
        /// </summary>
        private void NovaVenda() {
            if (this.IsVendaAtivada) {
                MessageBox.Show("A operação está em andamento." + 
                    Environment.NewLine + "Feche ou cancele antes de alterar a operação.");
                return; }
            var form = new View.TelaFrenteLojaOperacao();
            form.SetLabelOpcao(this.form.lb_operacao);
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
            this.operacao = this.form.lb_operacao.Text;
            this.IsVendaAtivada = true;
            material.SetDefaultValues();
            material.nome = "Informe o código do material.";
            this.RefreshMaterial("COD");
            
            // Reseta os valores do pedido.
            movimento.SetDefaultValues();
            // Define a operação.
            if (this.operacao != "VENDA") {
                movimento.tipo = "E"; }
            else movimento.tipo = "S";
            // Define o usuário logado.
            movimento.usuario_id = Rotas.user.id;
            movimento.usuario = Rotas.user.nome;
            // Define a empresa emitente do pedido.
            movimento.empresa_id = Rotas.empresa_atual.id;
            movimento.empresa = Rotas.empresa_atual.nome;
            // Exibe o cabeçalho do pedido.
            this.RefreshCliente();
        }

        /// <summary>
        /// F7 - Alterar empresa.
        /// </summary>
        private void AlterarEmpresa() {
            var form = new View.TelaSelecionarEmpresa();
            form.ShowDialog();
            if (form.IsSelected) {
                this.form.SetEmpresa();
            }
        }

        /// <summary>
        /// Define os campos do pedido.
        /// </summary>
        private void SetCaixaLivre() {
            this.IsVendaAtivada = false;
            material.SetDefaultValues();
            material.nome = "CAIXA LIVRE";
            RefreshMaterial("COD");
            movimento.SetDefaultValues();
            RefreshItems();
        }
        
        private void SetNovoProduto() {
            material.SetDefaultValues();
            material.nome = "Informe o código do material.";
            mov.vl_unit = 0;
            mov.volumes = 0;
            mov.qtd = 0;
            mov.usuario_id = Rotas.user.id;
            mov.usuario = Rotas.user.nome;
            RefreshMaterial("COD");
        }
        
        /// <summary>
        /// Atualiza os dados do item selecionado e exibe na tela.
        /// </summary>
        /// <param name="txt"></param>
        private void RefreshMaterial(string txt) {
            mov.material_id = material.id;
            mov.material = material.nome;
            mov.usuario_id = Rotas.user.id;
            mov.usuario = Rotas.user.nome;

            if (operacao == "VENDA")
                mov.vl_unit = material.preco_venda;
            else
                mov.vl_unit = material.preco_compra;
            this.form.RefreshValues(mov, txt);
        }
        
        /// <summary>
        ///  Exibe o cabeçalho do pedido na tela.
        /// </summary>
        private void RefreshCliente() {
            form.RefreshCliente(movimento);
        }
        #endregion

        #region: Operações Quantidade
        public void txt_qtd_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                IsESCPressioned = true;
                form.Get_txt_qtd().Text = "1";
                form.Get_txt_codigo_material().Focus();
                return; }

            if (e.KeyCode == Keys.Enter) {
                if (!this.IsQtdValid()) {
                    return; } }

            if (e.KeyCode == Keys.F8) {
                this.AlterarPrecoUnitario();
            }
        }

        public void txt_qtd_Leave(object sender, EventArgs e) {
            if (IsESCPressioned) return;
            this.IsQtdValid();
        }

        private bool IsQtdValid() {
            mov.qtd = MTextBox.GetDecimal(form.Get_txt_qtd());
            if (mov.qtd == 0) {
                _MsgBox.Error("A quantidade precisa ser maior do que zero.");
                form.Get_txt_qtd().Focus();
                return false; }
            this.form.RefreshValues(mov, "VOL");
            return true;
        }
        #endregion

        #region: Operações com Volumes
        public void txt_volumes_Leave(object sender, EventArgs e) {
            this.IsVolumeValid();
        }

        public void txt_volumes_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (!this.IsVolumeValid()) {
                    return; }
                else {
                    if (SalvarProduto()) {
                        SetNovoProduto(); } } }
        }

        private bool IsVolumeValid() {
            mov.volumes = MTextBox.GetInt(form.Get_txt_volumes());
            if (mov.volumes == 0) {
                _MsgBox.Error("O volume precisa ser maior do que zero.");
                form.Get_txt_volumes().Focus();
                return false; }
            this.form.RefreshValues(mov, "COD");
            return true;
        }
        #endregion

        #region: Operações com Pedidos
        public bool IsConfirmed() {
            return true;
        }
        
        /// <summary>
        /// Salva o pedido, itens e pagamento.
        /// </summary>
        /// <returns></returns>
        private bool SalvarPedido() {
            if (!movimento.IsValid()) {
                return false; }

            var result = movimento.Request.movimento.Insert();
            if (!result.status) {
                _MsgBox.Error(result.message);
                return false; }

            result = movimento.Request.movimento.GetLastID();
            if (!result.status) {
                _MsgBox.Error(result.message);
                return false; }
            movimento.id = Convert.ToInt32(result.data);

            List<Models.MovimentoMaterial> materiais = new List<Models.MovimentoMaterial>();
            foreach (Models.MovimentoMaterial item in movimento.materiais) {
                item.movimento_id = movimento.id;
                // Guarda o item caso dê erro no Insert.
                if (!item.Request.movimento_material.Insert().status) {
                    materiais.Add(item); }
                else
                    Rotas.estoque.AtualizaSaldo(movimento.empresa_id, item.material_id);
            }

            if (materiais.Count() > 0)
                foreach (Models.MovimentoMaterial item in materiais) {
                    item.Request.movimento_material.Insert();
                    Rotas.estoque.AtualizaSaldo(movimento.empresa_id, item.material_id); }

            foreach (Models.Pagamento item in movimento.pagamentos) {
                item.movimento_id = movimento.id;
                item.Request.pagamento.Insert(); }

            return true;
        }
        #endregion

        #region: Operações com produto
        /// <summary>
        /// Adiciona o item ao pedido.
        /// </summary>
        /// <returns></returns>
        private bool SalvarProduto() {
            if (!mov.IsValid()) {
                _MsgBox.Error(mov.GetErro());
                return false;
            }
            movimento.materiais.Add(mov.Copy());
            this.RefreshItems();
            return true;
        }

        /// <summary>
        /// Atualiza o ID dos itens.
        /// </summary>
        private void RefreshItems() {
            int ordem = 1;
            foreach (Models.MovimentoMaterial item in movimento.materiais) {
                item.movimento_id = movimento.id;
                item.ordem = ordem;
                ordem += 1;
            }
            movimento.IsValid();
            form.RefreshSaldo(GetTable(), movimento.valor_total);
        }

        /// <summary>
        /// Prepara uma tabela com os itens do pedido.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable() {
            var dt = new DataTable();
            DataRow row;
            dt.Columns.Add("ITEM", typeof(int));
            dt.Columns.Add("COD", typeof(int));
            dt.Columns.Add("DESCRICAO", typeof(string));
            dt.Columns.Add("QTD", typeof(decimal));
            dt.Columns.Add("VL_UNIT R$", typeof(decimal));
            dt.Columns.Add("VOL", typeof(int));
            dt.Columns.Add("SUB R$", typeof(decimal));
            dt.Columns.Add("SIT", typeof(string));

            foreach (Models.MovimentoMaterial item in movimento.materiais) {
                row = dt.NewRow();
                row.SetField("ITEM", item.ordem);
                row.SetField("COD", item.material_id);
                row.SetField("DESCRICAO", item.material);
                row.SetField("QTD", item.qtd);
                row.SetField("VL_UNIT R$", item.vl_unit);
                row.SetField("VOL", item.volumes);
                row.SetField("SUB R$", item.vl_total);
                row.SetField("SIT", item.situacao);
                dt.Rows.Add(row);
            }
            return dt;
        }

        #endregion

        #region: Recibo
        /// <summary>
        /// Abre tela para exibir recibo.
        /// </summary>
        /// <param name="movimento_id"></param>
        private void ImprimirRecibo(int movimento_id) {
            var form = new View.TelaReciboCaixa();
            form.SetPedido(movimento_id);
            form.ShowDialog();
            form.Dispose();
            GC.Collect();
        }
        #endregion
    }
}
