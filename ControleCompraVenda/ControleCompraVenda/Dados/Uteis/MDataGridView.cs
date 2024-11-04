using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    /// <summary>
    /// Altera as propriedade visuais do DataGridView.
    /// </summary>
    public class MDataGridView
    {

        #region "Variáveis"
        /// <summary>
        /// Obtém ou define a posição corrente do barra de rolagem vertical. 
        /// </summary>
        private int scrollPosition = -1;
        /// <summary>
        /// Obtém ou define o controle DataGridView instanciado na classe.
        /// </summary>
        private DataGridView dg;

        #region: Cores
        /// <summary>
        /// Obtém ou define a cor de fonte do título das colunas.
        /// </summary>
        /// <example>HeaderForeColor = Color.White;</example>
        public Color HeaderForeColor = Color.White;
        /// <summary>
        /// Obtém ou define a cor de fundo do título das colunas.
        /// </summary>
        /// <example>HeaderBackColor = Color.Blue;</example> 
        public Color HeaderBackColor = Color.Blue;
        /// <summary>
        /// Obtém ou define a cor da fonte das células.
        /// </summary>
        /// <example>CellForeColor = Color.Black;</example>
        public Color CellForeColor = Color.Black;
        /// <summary>
        /// Obtém ou define a cor de fundo das linhas da tabela.
        /// </summary>
        /// <example>RowDefaultColor = Color.LightCyan;</example>
        public Color RowDefaultColor = Color.LightCyan;
        /// <summary>
        /// Obtém ou define a cor de fundo das linhas alternadas da tabela.
        /// </summary>
        /// <example>RowAlternativeColor = Color.PowderBlue;</example>
        public Color RowAlternativeColor = Color.PowderBlue;
        /// <summary>
        /// Define a cor da célula selecionada.
        /// </summary>
        public Color SelectionBackColor = Color.Blue;
        #endregion

        #region: Formatação
        /// <summary>
        /// Define se o texto do título das colunas será maiúscula (true).
        /// </summary>
        public bool setHeaderToUpper = false;
        /// <summary>
        /// Define o nome do título da coluana.
        /// </summary>
        private string HeaderName = "";

        private string CellFontName { get; set; }
        private string HeaderFontName { get; set; }
        private int CellFontSize { get; set; }
        private int HeaderFontSize { get; set; }
        private FontStyle HeaderFontStyle { get; set; }
        private FontStyle CellFontStyle { get; set; }
        #endregion

        #region: Linhas e colunas
        /// <summary>
        /// Obtém ou define o índice da linha selecionada.
        /// </summary>
        public int CurrentRow { get; private set; }
        /// <summary>
        /// Obtém ou define o índice da coluna clicada.
        /// </summary>
        public int CurrentColumn { get; private set; }
        private int OldRowIndex { get; set; }
        private int OldColumnIndex { get; set; }
        /// <summary>
        /// Obtém ou define a quantidade de linhas da tabela.
        /// </summary>
        public int RowCount { get; private set; }
        #endregion

        #region: Outros
        /// <summary>
        /// Obtém ou define que o alerta está ativo.
        /// </summary>
        private bool alert { get; set; }
        /// <summary>
        /// Obtém ou define a linha 
        /// </summary>
        private int altertRow { get; set; }
        public bool IsRenderized { get; set; }
        private object Value { get; set; }
        public Parse parse { get; set; }
        #endregion

        #endregion

        #region: Menu
        public MContextMenuStrip menu { get; set; }
        #endregion

        #region: Delegates
        public delegate void PassControl();
        /// <summary>
        /// Define o método da classe a ser executado.
        /// </summary>
        public PassControl ExecOnSorted { get; set; }
        public PassControl ExecOnMouseRightButton { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MDataGridView()
        {
            this.Add(new DataGridView());
            this.RowCount = 0;
            this.setDefaultValues();
        }

        /// <summary>
        /// Construtor da classe, personaliza o DataGridView enviado por parâmetro.
        /// </summary>
        /// <param name="dg">Recebe um DataGridView.</param>
        public MDataGridView(DataGridView dg)
        {
            this.Add(dg);
            this.RowCount = dg.RowCount;
            this.setDefaultValues();
        }
        private void setDefaultValues()
        {
            //this.AlignCenter = "center";
            //this.AlignLeft = "left";
            //this.AlignRight = "right";
            this.parse = new Parse();
            this.IsRenderized = false;
            this.CellFontName = "Calibri";
            this.HeaderFontName = "Calibri";
            this.CellFontSize = 9;
            this.HeaderFontSize = 9;
            this.HeaderFontStyle = FontStyle.Bold;
            this.CellFontStyle = FontStyle.Regular;
            this.Value = null;
            this.menu = new MContextMenuStrip();
            this.setEvents();
        }

        /// <summary>
        /// Carrega os métodos de eventos.
        /// </summary>
        private void setEvents()
        {
            this.dg.EnabledChanged += new EventHandler(this.dg_EnabledChanged);
            this.dg.CurrentCellChanged += new EventHandler(this.dg_CurrentCellChanged);
            this.dg.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dg_CellMouseClick);
            this.dg.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dg_CellMouseDoubleClick);
        }
        public void Add(DataGridView dg)
        {
            this.dg = dg;
            this.setDefaultValues();
        }
        #endregion

        #region: Menu suspenso
        /// <summary>
        /// Adiciona um menu suspenso ao DataGridView.
        /// </summary>        
        /// <param name="AddCopyClipboard">Adiciona os itens de menu de copiar para a área de transferência.</param>
        public void AddMenu(bool AddCopyClipboard)
        {
            this.setOnRightClick(this.menu.ShowMenu);
            if (AddCopyClipboard)
                this.setMenuSuspenso();
        }

        /// <summary>
        /// Adiciona um método para ser executado no evento Click do mouse com o botão direito.
        /// </summary>
        /// <param name="ExecOnRightClick">Nome do método a ser executado..</param>
        public void setOnRightClick(PassControl ExecOnRightClick)
        {
            this.ExecOnMouseRightButton = ExecOnRightClick;
        }

        /// <summary>
        /// Adiciona um método para ser executado quando se ordena uma coluna.
        /// </summary>
        /// <param name="ExecOnSorted">Nome do método a ser executado.</param>
        public void setOnSorted(PassControl ExecOnSorted)
        {
            this.ExecOnSorted = ExecOnSorted;
        }

        /// <summary>
        /// Adiciona os itens de menu no menu suspenso.
        /// </summary>
        private void setMenuSuspenso()
        {
            this.menu.Add("Copiar linha", "Copia a linha para área de transferência", this.CopyRow);
            this.menu.Add("Copiar grade", "Copia toda a grade para área de transferência", this.CopyGrid);
            this.menu.Add("Copiar célula", "Copia a célula para área de transferência", this.CopyCell);
        }

        #region: Métodos para copiar para Área de Transferência        
        /// <summary>
        /// Copia a linha selecionada para a área de transferência.
        /// </summary>
        public void CopyRow()
        {
            try { Clipboard.SetDataObject(this.dg.GetClipboardContent()); }
            catch { }
        }

        /// <summary>
        /// Copia toda a grade com os títulos para a área de transferência.
        /// </summary>
        public void CopyGrid()
        {
            try
            {
                this.dg.MultiSelect = true;
                this.dg.SelectAll();
                Clipboard.SetDataObject(this.dg.GetClipboardContent());
                this.dg.MultiSelect = false;
                this.restoreCurrentPositionScroll();
            }
            catch { }
        }

        /// <summary>
        /// Copia a célula clicada para a área de transferência.
        /// </summary>
        public void CopyCell()
        {
            try { Clipboard.SetText(this.dg.CurrentCell.Value.ToString()); }
            catch { }
        }
        #endregion

        #endregion

        #region: Operações
        /// <summary>
        /// Define a posição da linha e coluna clicada.
        /// </summary>
        /// <param name="e">Evento de clique do mouse.</param>
        public void setPoint(DataGridViewCellMouseEventArgs e)
        {
            this.CurrentRow = e.RowIndex;
            this.CurrentColumn = e.ColumnIndex;
        }

        /// <summary>
        /// Define a posição da linha selecionada.
        /// </summary>
        /// <param name="selectedRow">Número da linha.</param>
        public void setPoint(int selectedRow)
        {
            this.CurrentRow = selectedRow;
        }

        /// <summary>
        /// Aplica os alterações das propriedades no DataGridView.
        /// Se nenhuma propriedade foi definida, carregará a padrão.
        /// </summary>
        public void RenderizeStyle()
        {
            this.dg.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;

            // Desabilita formatação padrão
            this.dg.EnableHeadersVisualStyles = false;

            // Definição das células.
            this.dg.DefaultCellStyle.Font = new Font(this.CellFontName, this.CellFontSize, this.CellFontStyle);
            this.dg.DefaultCellStyle.SelectionBackColor = this.SelectionBackColor;
            this.dg.RowsDefaultCellStyle.BackColor = this.RowDefaultColor;
            this.dg.AlternatingRowsDefaultCellStyle.BackColor = this.RowAlternativeColor;

            // Definição do cabeçalho.
            this.dg.RowHeadersVisible = false;
            this.dg.ColumnHeadersDefaultCellStyle.Font = new Font(this.HeaderFontName, this.HeaderFontSize, this.HeaderFontStyle);
            this.dg.ColumnHeadersDefaultCellStyle.BackColor = this.HeaderBackColor;
            this.dg.ColumnHeadersDefaultCellStyle.ForeColor = this.HeaderForeColor;
            this.dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Desabilita a multi-seleção de linhas.
            this.dg.MultiSelect = false;
            this.IsRenderized = true;
        }

        /// <summary>
        /// Aplica os alterações das propriedades no DataGridView.
        /// </summary>
        /// <param name="tema">Define o tema de cores da grade.</param>
        /// <param name="IsZebra">Define se haverá cor alternada nas linhas.</param>
        public void RenderizeStyle(GridTheme tema, bool IsZebra)
        {
            tema.ApplyTheme(this, IsZebra);
            this.RenderizeStyle();
        }

        /// <summary>
        /// Obtém o nome do título da coluna.
        /// </summary>
        /// <returns>O texto do título alternado para maiúsculo.</returns>
        private string getHeaderName()
        {
            if (setHeaderToUpper)
                return this.HeaderName.ToUpper();
            else
                return this.HeaderName;
        }

        /// <summary>
        /// Guarda a posição corrente da barra de rolagem vertical.
        /// </summary>
        public void saveCurrentPositionScroll()
        {
            try
            {
                this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
            }
            catch { }
        }

        /// <summary>
        /// Define a posição da barra de rolagem vertical.
        /// E seleciona uma célula.
        /// </summary>
        /// <param name="row">Número da linha.</param>
        /// <param name="columnName">Nome da coluna.</param>
        public void restoreCurrentPositionScroll(int row, string columnName)
        {
            try
            {
                dg.FirstDisplayedScrollingRowIndex = scrollPosition;
                dg.CurrentCell = dg.Rows[row].Cells[columnName];
            }
            catch { }
        }

        /// <summary>
        /// Restaura a posição da barra de rolagem vertical.
        /// </summary>
        public void restoreCurrentPositionScroll()
        {
            try
            {
                dg.FirstDisplayedScrollingRowIndex = scrollPosition;
                dg.CurrentCell = dg.Rows[this.OldRowIndex].Cells[this.OldColumnIndex];
            }
            catch { }
        }
        #endregion

        #region "Métodos para alterar colunas"
        /// <summary>
        /// Define as propriedades da coluna: Título, Largura e Alinhamento.
        /// </summary>
        /// <param name="columnName">Índice da coluna</param>
        /// <param name="newHeaderName">Novo nome para o título da coluna.</param>
        /// <param name="size">Largura da coluna</param>
        /// <param name="align">Alinhamento do conteúdo das células.</param>
        public void setColumn(string columnName, string newHeaderName, int size, Align align) {
            setWidth(columnName, size);
            setHeaderName(columnName, newHeaderName);
            setAlign(columnName, align);
        }

        /// <summary>
        /// Define as propriedades da coluna: Título, Largura e Alinhamento.
        /// </summary>
        /// <param name="index">Índice da coluna</param>
        /// <param name="newHeaderName">Novo nome para o título da coluna.</param>
        /// <param name="size">Largura da coluna</param>
        /// <param name="align">Alinhamento do conteúdo das células.</param>
        public void setColumn(int index, string newHeaderName, int size, Align align) {
            this.setWidth(index, size);
            this.setHeaderName(index, newHeaderName);
            this.setAlign(index, align);
        }

        /// <summary>
        /// Define as propriedades da coluna: Título e Largura.
        /// </summary>
        /// <param name="index">Índice da coluna.</param>        
        /// <param name="size">Largura da coluna.</param>
        public void setColumn(int index, string newHeaderName, int size) {
            setWidth(index, size);
            setHeaderName(index, newHeaderName);
        }

        /// <summary>
        /// Define as propriedades da coluna: Título, Largura.
        /// </summary>
        /// <param name="columnName">Índice da coluna</param>
        /// <param name="newHeaderName">Novo nome para o título da coluna.</param>
        /// <param name="size">Largura da coluna.</param>
        public void setColumn(string columnName, string newHeaderName, int size) {
            setWidth(columnName, size);
            setHeaderName(columnName, newHeaderName);
        }

        public void setColumn(string columnName, string newHeaderName, int width, bool visible, Align cellAlign) {
            try {
                this.setHeaderName(columnName, newHeaderName);
                this.setWidth(columnName, width);
                this.setVisible(columnName, visible);
                this.setAlign(columnName, cellAlign); }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + columnName.ToString() + "\n\r" + e.ToString()); }
        }

        #endregion

        #region "Largura da coluna"
        /// <summary>
        /// Define a largura da coluna.
        /// </summary>
        /// <param name="index">Índice da coluna.</param>
        /// <param name="size">Largura da coluna em pixels</param>
        private void setWidth(int index, int size) {
            if (dg.Columns[index] == null) return;
            try {
                dg.Columns[index].Width = size; }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + index.ToString() + "\n\r" + e.ToString()); }
        }

        /// <summary>
        /// Define a largura da coluna.
        /// </summary>
        /// <param name="columnName">Nome da coluna.</param>
        /// <param name="size">Largura da coluna em pixels</param>
        private void setWidth(string columnName, int size) {
            if (dg.Columns[columnName] == null) return;
            try {
                dg.Columns[columnName].Width = size; }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + columnName + "\n\r" + e.ToString()); }
        }
        #endregion

        #region"Cabeçalho"
        /// <summary>
        /// Altera o nome da coluna.
        /// </summary>
        /// <param name="index">Índice da coluna.</param>
        /// <param name="title">Novo nome da coluna.</param>
        private void setHeaderName(int index, string title) {
            if (dg.Columns[index] == null) return;
            try {
                this.HeaderName = title;
                dg.Columns[index].HeaderText = getHeaderName(); }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + index.ToString() + "\n\r" + e.ToString()); }
        }

        /// <summary>
        /// Altera o nome da coluna.
        /// </summary>
        /// <param name="columnName">Nome da coluna.</param>
        /// <param name="title">Novo nome da coluna.</param>
        private void setHeaderName(string columnName, string title) {
            if (dg.Columns[columnName] == null) return;
            try {
                this.HeaderName = title;
                dg.Columns[columnName].HeaderText = getHeaderName(); }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + columnName + "\n\r" + e.ToString()); }
        }
        #endregion

        #region "Coluna visível"
        /// <summary>
        /// Define se a coluna será visível ou não.
        /// </summary>
        /// <param name="index">Índice da coluna.</param>
        /// <param name="isVisible">true ou false</param>
        public void setVisible(int index, bool isVisible) {
            if (dg.Columns[index] == null) return;
            try {
                dg.Columns[index].Visible = isVisible; }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + index.ToString() + "\n\r" + e.ToString()); }
        }

        /// <summary>
        /// Define se a coluna será visível ou não.
        /// </summary>
        /// <param name="columnName">Nome da coluna.</param>
        /// <param name="isVisible">true ou false.</param>
        public void setVisible(string columnName, bool isVisible) {
            if (dg.Columns[columnName] == null) return;

            try {
                dg.Columns[columnName].Visible = isVisible; }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + columnName + "\n\r" + e.ToString()); }
        }

        /// <summary>
        /// Define quais colunas ficarão ocultas.
        /// </summary>
        /// <param name="columnsName">Nome das colunas separadas por vírgulas.</param>
        public void setVisibleFalse(string columnsName) {
            if (string.IsNullOrEmpty(columnsName.Trim())) return;
            try {
                string[] column = columnsName.Split(',');
                foreach (string setThis in column) {
                    if (dg.Columns[setThis.Trim()] != null)
                        try {
                            this.setVisible(setThis.Trim(), false); }
                        catch (Exception e) {
                            _MsgBox.Error("Coluna: " + setThis + "\n\r" + e.ToString()); } } }
            catch { }
        }

        #endregion

        #region "Obtém valor da célula"
        /// <summary>
        /// Obtém o valor da célula indicada pelo número da linha e nome da coluna.
        /// </summary>
        /// <param name="row">Linha da célula.</param>
        /// <param name="columnName">Nome da coluna.</param>
        /// <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
        public object getValue(int row, string columnName) {
            if (dg.Rows[row] == null) return null;
            if (dg.Rows[row].Cells[columnName] == null) return null;
            try { return dg.Rows[row].Cells[columnName].Value; }
            catch { return null; }
        }
        /// <summary>
        /// Obtém o valor da célula indicada pelo número da linha e índice da coluna.
        /// </summary>
        /// <param name="row">Linha da célula.</param>
        /// <param name="columnName">Indice da coluna.</param>
        /// <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
        public object getValue(int row, int index) {
            if (dg.Rows[row] == null) return null;
            if (dg.Rows[row].Cells[index] == null) return null;
            try { return dg.Rows[row].Cells[index].Value; }
            catch { return null; }
        }

        /// <summary>
        /// Obtém o valor da célula indicada pelo número da linha e nome da coluna.
        /// </summary>        
        /// <param name="columnName">Nome da coluna.</param>
        /// <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
        public object getValue(string columnName) {
            if (dg.Rows[CurrentRow] == null) return null;
            if (dg.Rows[CurrentRow].Cells[columnName] == null) return null;
            try { return dg.Rows[this.CurrentRow].Cells[columnName].Value; }
            catch { return null; }
        }

        /// <summary>
        /// Obtém o valor da célula indicada pelo número da linha e índice da coluna.
        /// </summary>        
        /// <param name="columnName">Indice da coluna.</param>
        /// <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
        public object getValue(int columnIndex) {
            if (dg.Rows[CurrentRow] == null) return null;
            if (dg.Rows[CurrentRow].Cells[columnIndex] == null) return null;
            try { return dg.Rows[this.CurrentRow].Cells[columnIndex].Value; }
            catch { return null; }
        }

        public int ToInt(string columnName) {
            if (dg.Rows[CurrentRow] == null) return -1;
            if (dg.Rows[CurrentRow].Cells[columnName] == null) return -1;
            try { return (int)dg.Rows[this.CurrentRow].Cells[columnName].Value; }
            catch { return -1; }
        }
        #endregion

        #region "Formata casas decimais"
        /// <summary>
        /// Define a quantidade de casas decimais.
        /// </summary>
        /// <param name="index">Índice da coluna</param>
        /// <param name="format">Formato indicando o número de casas decimais.</param>
        /// <example>dg.setNumberFormat(10, "n2");</example>
        public void setNumberFormat(int index, string format) {
            if (dg.Columns[index] == null) return;
            dg.Columns[index].DefaultCellStyle.Format = format;
        }

        /// <summary>
        /// Define a quantidade de casas decimais.
        /// </summary>
        /// <param name="columnName">Nome da coluna.</param>
        /// <param name="format">Formato indicando o número de casas decimais.</param>
        /// <example>dg.setNumberFormat("PRECO", "n2");</example>
        public void setNumberFormat(string columnName, string format) {
            if (dg.Columns[columnName] == null) return;
            dg.Columns[columnName].DefaultCellStyle.Format = format;
        }
        #endregion

        #region "Alinhamento da célula"

        /// <summary>
        /// Define o alinhamento de uma coluna pelo seu índice.
        /// </summary>
        /// <param name="index">Índice da coluna.</param>
        /// <param name="align">Tipo de alinhamento.</param>
        /// <example>dg.setAlign(1, dg.AlignCenter);</example>
        /// <value>AlignCenter, AlignLeft ou AlignRight.</value>
        public void setAlign(int index, Align align) {
            if (dg.Columns[index] == null) return;
            try {
                dg.Columns[index].DefaultCellStyle.Alignment = align.getGridAlign(); }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + index.ToString() + "\n\r" + e.ToString()); }
        }

        /// <summary>
        /// Define o alinhamento de uma coluna pelo seu índice.
        /// </summary>
        /// <param name="columnName">Nome da coluna.</param>
        /// <param name="align">Tipo de alinhamento.</param>
        /// <example>dg.setAlign("COD", dg.AlignCenter);</example>
        /// <value>AlignCenter, AlignLeft ou AlignRight.</value>
        public void setAlign(string columnName, Align align)  {
            if (dg.Columns[columnName] == null) return;
            try {
                dg.Columns[columnName].DefaultCellStyle.Alignment = align.getGridAlign(); }
            catch (Exception e) {
                _MsgBox.Error("Coluna: " + columnName + "\n\r" + e.ToString()); }
        }
        #endregion

        #region: Formatação
        /// <summary>
        /// Define a formatação da fonte da célula.
        /// </summary>
        /// <param name="name">Nome da fonte.</param>
        /// <param name="size">Tamanho da fonte.</param>
        /// <param name="style">Estilo da fonte.</param>
        public void setCellFont(string name, int size, FontStyle style)
        {
            this.CellFontName = name;
            this.CellFontSize = size;
            this.CellFontStyle = style;
        }

        /// <summary>
        /// Define a formatação do cabeçalho da grade.
        /// </summary>
        /// <param name="name">Nome da fonte.</param>
        /// <param name="size">Tamanho da fonte.</param>
        /// <param name="style">Estilo da fonte.</param>
        public void setHeaderFont(string name, int size, FontStyle style)
        {
            this.HeaderFontName = name;
            this.HeaderFontSize = size;
            this.HeaderFontStyle = style;
        }

        #endregion

        #region: Eventos
        /// <summary>
        /// Ocorre quando a propriedade Enable muda de estado.
        /// </summary>
        /// <param name="sender">Nome do DataGridView.</param>
        /// <param name="e">Evento.</param>
        private void dg_EnabledChanged(object sender, EventArgs e)
        {
            if (dg.Enabled)
            {
                dg.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
                dg.RowsDefaultCellStyle.BackColor = RowDefaultColor;
                dg.AlternatingRowsDefaultCellStyle.BackColor = RowAlternativeColor;
            }
            else
            {
                dg.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dg.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray;
                dg.ClearSelection();
            }
        }

        /// <summary>
        /// Ocorre quando o indice da célula é alterada.
        /// </summary>
        /// <param name="sender">Nome do dataGridView</param>
        /// <param name="e">Evento de alterar índice da célula.</param>
        private void dg_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.CurrentRow = dg.CurrentRow.Index;
                this.CurrentColumn = dg.CurrentCell.ColumnIndex;
            }
            catch { }
        }

        /// <summary>
        /// Ocorre quando o conteúdo do DataGridView recebe um click do mouse.
        /// </summary>
        /// <param name="sender">Objeto clicado.</param>
        /// <param name="e">Click do botão.</param>
        private void dg_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dg.CurrentCell = dg.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.Value = dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
                    this.OldRowIndex = dg.CurrentRow.Index;
                    this.OldColumnIndex = dg.CurrentCell.ColumnIndex;
                    this.ExecOnMouseRightButton();
                }
                catch { }
            }
            else
            {
                this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
                this.OldRowIndex = dg.CurrentRow.Index;
                this.OldColumnIndex = dg.CurrentCell.ColumnIndex;
            }
        }

        /// <summary>
        /// Ocorre quando o conteúdo do DataGridView recebe dois cliques do mouse.
        /// </summary>
        /// <param name="sender">Objeto DataGridView.</param>
        /// <param name="e">Evento de click.</param>
        private void dg_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
            this.OldRowIndex = dg.CurrentRow.Index;
            this.OldColumnIndex = dg.CurrentCell.ColumnIndex;
        }

        /// <summary>
        /// Ocorre quando o cabeçalho de uma das colunas é clicado.
        /// </summary>
        /// <param name="sender">Objeto DataGridView.</param>
        /// <param name="e">Evento de click.</param>
        private void dg_Sorted(object sender, EventArgs e)
        {
            this.RenderizeStyle();
            this.dg.ClearSelection();
            try
            {
                this.ExecOnSorted();
            }
            catch { }
        }
        #endregion

    }

    /// <summary>
    /// Classe de alinhamento.
    /// </summary>
    public class Align
    {
        #region: Atributos da classe
        /// <summary>
        /// Obtém ou define o alinhamento do conteúdo das células na grade.
        /// </summary>
        private DataGridViewContentAlignment GridAlign { get; set; }
        /// <summary>
        /// Obtém ou define o nome do alinhamento.
        /// </summary>
        private string value { get; set; }
        #endregion

        #region: Constantes
        /// <summary>
        /// Alinhamento à direita.
        /// </summary>
        public static Align Right = new Align("right", DataGridViewContentAlignment.MiddleRight);
        /// <summary>
        /// Alinhamento à esquerda.
        /// </summary>
        public static Align Left = new Align("left", DataGridViewContentAlignment.MiddleLeft);
        /// <summary>
        /// Alinhamento ao centro.
        /// </summary>
        public static Align Center = new Align("center", DataGridViewContentAlignment.MiddleCenter);
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe.
        /// </summary>
        /// <param name="Value">Palavra nome do alinhamento.</param>
        /// <param name="GridAlign">Valor do alinhamento do DataGridView.</param>
        public Align(string Value, DataGridViewContentAlignment GridAlign)
        {
            this.value = Value;
            this.GridAlign = GridAlign;
        }
        #endregion

        #region: Métodos getters
        /// <summary>
        /// Obtém o nome do alinhamento.
        /// </summary>
        /// <returns>Retorna uma string.</returns>
        public string getValue()
        {
            return this.value;
        }

        /// <summary>
        /// Obtém o alinhamento do conteúdo da célula da grade.
        /// </summary>
        /// <returns>Retorna um Content Cell Grid Align</returns>
        public DataGridViewContentAlignment getGridAlign()
        {
            return this.GridAlign;
        }
        #endregion
    }

    /// <summary>
    /// Classe para exibição de caixas de diálogos.
    /// </summary>
    public class _MsgBox
    {
        /// <summary>
        /// Exibe uma caixa de mensagem de informação para o usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem a ser exibida na caixa de mensagem.</param>
        public static void Sucess(object mensagem)
        {
            MessageBox.Show(mensagem.ToString(), ".:: Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de erro para o usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem para o usuário.</param>
        public static void Error(object mensagem)
        {
            MessageBox.Show(mensagem.ToString(), ".:: Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Exibe uma caixa de mensagem de confirmação para o usuário com os botões OK e Cancelar, retorna true ou false.
        /// </summary>
        /// <param name="mensagem">Mensagem para o usuário.</param>
        /// <returns>Retorna true ou false.</returns>
        public static bool Confirm(object mensagem)
        {
            DialogResult result;
            result = MessageBox.Show(mensagem.ToString(), ".:: Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Exibe uma caixa de mensagem para o usuário com três opções: Sim, Não e Cancelar.
        /// </summary>
        /// <param name="mensagem">Mensagem para o usuário.</param>
        /// <returns>Retorna um DialogResult.</returns>
        public static DialogResult Options(object mensagem)
        {
            DialogResult result;
            result = MessageBox.Show(mensagem.ToString(), ".:: Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return result;
        }
    }

    public class MContextMenuStrip
    {
        #region: Atributos
        private System.Windows.Forms.ContextMenuStrip menuSuspenso { get; set; }
        public delegate void PassControl();
        private List<PassControl> onClick { get; set; }
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe de menu suspenso.
        /// </summary>
        public MContextMenuStrip()
        {
            this.menuSuspenso = new System.Windows.Forms.ContextMenuStrip(new System.ComponentModel.Container());
            this.onClick = new List<PassControl>();
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Adiciona um item de menu num menu suspenso.
        /// </summary>
        /// <param name="Text">Texto do menu.</param>
        /// /// <param name="toolTipText">Texto da dica.</param>
        /// <param name="onClick">Evento de click para o menu.</param>
        public void Add(string Text, string toolTipText, PassControl onClick)
        {
            // Cria uma nova instância do item de menu.
            System.Windows.Forms.ToolStripMenuItem MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            MenuItem.Size = new System.Drawing.Size(119, 22);
            // Insere o texto que será exibido.
            MenuItem.Text = Text;
            // Insere o texto da dica.
            MenuItem.ToolTipText = toolTipText;
            // Informa o índice do método.
            MenuItem.AccessibleDescription = this.onClick.Count.ToString();
            // Insere o método a ser executado.
            MenuItem.Click += new EventHandler(this.menu_Click);
            // Insere o método na lista de métodos.
            this.onClick.Add(onClick);
            // Insere o item de menu no menu suspenso.
            this.menuSuspenso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MenuItem });
        }

        /// <summary>
        /// Abre o menu suspenso na posição do ponteiro do mouse.
        /// </summary>
        public void ShowMenu()
        {
            this.menuSuspenso.Show(System.Windows.Forms.Cursor.Position);
        }

        /// <summary>
        /// Ocorre quando o controle recebe um click do mouse.
        /// </summary>
        /// <param name="sender">Controle menu</param>
        /// <param name="e">Evento click do mouse.</param>
        private void menu_Click(object sender, EventArgs e)
        {
            // Identifica o botão clicado.
            System.Windows.Forms.ToolStripMenuItem menuItem =
                (System.Windows.Forms.ToolStripMenuItem)sender;
            // Executa o método associado ao botão.
            this.onClick[Convert.ToInt32(menuItem.AccessibleDescription)]();
        }
        #endregion
    }

    //public class MDataGridView
    //{
    //    public delegate void PassControl(object sender);
    //    public delegate void PassControlClick();
    //    public PassControl ExecProcedure;
    //    public PassControlClick ExecOnDoubleClick;
    //    public PassControl ExecOnMouseRightButton;
    //    //public MenuSuspenso menu { get; set; }
    //    public CheckedListBox checkList;
    //    private bool checkListEvents = false;
    //    private string erro = string.Empty;
    //    /// <summary>
    //    ///     ''' Obtém ou define a posição corrente do barra de rolagem vertical. 
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    private int scrollPosition { get; set; } = -1;

    //    /// <summary>
    //    ///     ''' Obtém ou define o controle DataGridView instanciado na classe.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    private DataGridView dg; 

    //    /// <summary>
    //    ///     ''' Obtém ou define a cor de fonte do título das colunas.
    //    ///     ''' </summary>
    //    ///     ''' <value>Color</value>
    //    ///     ''' <returns>Retorna a cor.</returns>
    //    ///     ''' <remarks></remarks>
    //    public Color HeaderForeColor { get; set; } = Color.White;

    //    /// <summary>
    //    ///     ''' Obtém ou define a cor da fonte do título das colunas: HeaderForeColor = Color.White
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Color HeaderBackColor { get; set; } = Color.Blue;

    //    /// <summary>
    //    ///     ''' Obtém ou define a cor de fundo do título das colunas.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Color CellForeColor { get; set; } = Color.Black;

    //    /// <summary>
    //    ///     ''' Obtém ou define a cor de fundo da linha Default.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <example>HeaderBackColor = Color.Blue;</example> 
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Color RowDefaultColor { get; set; } = Color.AliceBlue;

    //    /// <summary>
    //    ///     ''' Obtém ou define a cor de fundo das linhas alternadas da tabela.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <example>RowDefaultColor = Color.LightCyan;</example>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Color RowAlternativeColor { get; set; } = Color.PowderBlue;

    //    /// <summary>
    //    ///     ''' Define a cor da célula selecionada.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Color SelectionBackColor { get; set; } = Color.Blue;

    //    /// <summary>
    //    ///     ''' Define se o texto do título das colunas será maiúscula (true).
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public bool setHeaderToUpper { get; set; } = false;

    //    /// <summary>
    //    ///     ''' Define o nome do título da coluana.
    //    ///     ''' </summary>
    //    ///     ''' <value>Nome da coluna.</value>
    //    ///     ''' <returns>Retorna o nome da coluna.</returns>
    //    ///     ''' <remarks></remarks>
    //    private string HeaderName { get; set; } = "";

    //    /// <summary>
    //    ///     ''' Obtém o valor para alinhamento central.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public static string AlignCenter = "center";

    //    /// <summary>
    //    ///     ''' Obtém o valor para alinhamento à Esquerda.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public static string AlignLeft = "left";

    //    /// <summary>
    //    ///     ''' Obtém o valor para alinhamento à direita.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public static string AlignRight = "right";

    //    /// <summary>
    //    ///     ''' Obtém ou define o índice da coluna clicada.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public int CurrentColumn { get; set; }

    //    /// <summary>
    //    ///     ''' Obtém ou define o índice da linha selecionada.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public int CurrentRow { get; set; }

    //    private int OldRowIndex { get; set; }
    //    private int OldColumnIndex { get; set; }

    //    /// <summary>
    //    ///     ''' Obtém ou define a quantidade de linhas da tabela.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public int RowCount { get; set; }
    //    private bool alert { get; set; }
    //    private int altertRow { get; set; }
    //    public bool IsRenderized { get; set; } = false;

    //    /// <summary>
    //    ///     ''' Classe de conversão de valores.
    //    ///     ''' </summary>
    //    ///     ''' <value></value>
    //    ///     ''' <returns></returns>
    //    ///     ''' <remarks></remarks>
    //    public Conversao_dg Parse { get; set; }
    //    private object Value { get; set; }
    //    // Public Property showError As Boolean = True
    //    public bool exibirMsgBox { get; set; } = false;

    //    /// <summary>
    //    ///     ''' Altera as propriedade visuais do DataGridView.
    //    ///     ''' </summary>
    //    ///     ''' <param name="dg">Controle DataGridView</param>
    //    ///     ''' <remarks></remarks>
    //    public MDataGridView(DataGridView dg)
    //    {
    //        this.dg = dg;
    //        this.RowCount = dg.RowCount;
    //        this.Parse = new Conversao_dg(this.dg);
    //        //this.menu = new MenuSuspenso();
    //    }

    //    /// <summary>
    //    ///     ''' Altera as propriedades visuais do DataGridView
    //    ///     ''' </summary>
    //    ///     ''' <param name="dg">Controle DataGridView</param>
    //    ///     ''' <param name="exibirMsgBox">Define se será exibido uma caixa de mensagem em caso de erro.</param>
    //    ///     ''' <remarks></remarks>
    //    public MDataGridView(DataGridView dg, bool exibirMsgBox) {
    //        this.dg = dg;
    //        this.RowCount = dg.RowCount;
    //        this.exibirMsgBox = exibirMsgBox;
    //        this.Parse = new Conversao_dg(this.dg);
    //        //this.menu = new MenuSuspenso();
    //    }

    //    /// <summary>
    //    ///     ''' Define a posição da linha e coluna clicada.
    //    ///     ''' </summary>
    //    ///     ''' <param name="e"></param>
    //    ///     ''' <remarks></remarks>
    //    public void setPoint(DataGridViewCellMouseEventArgs e)
    //    {
    //        this.CurrentRow = e.RowIndex;
    //        this.CurrentColumn = e.ColumnIndex;
    //    }

    //    /// <summary>
    //    ///     ''' Define a posição da linha selecionada.
    //    ///     ''' </summary>
    //    ///     ''' <param name="selectedRow">Número da linha.</param>
    //    ///     ''' <remarks></remarks>
    //    public void setPoint(int selectedRow)
    //    {
    //        this.CurrentRow = selectedRow;
    //    }

    //    /// <summary>
    //    ///     ''' Aplica os alterações das propriedades no DataGridView.
    //    ///     ''' Se nenhuma propriedade foi definida, carregará a padrão.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public void RenderizeStyle()
    //    {
    //        this.dg.EditMode = DataGridViewEditMode.EditProgrammatically;
    //        this.dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //        this.dg.AllowUserToAddRows = false;
    //        this.dg.AllowUserToDeleteRows = false;
    //        this.dg.DefaultCellStyle.Font = new Font(this.CellFontName, this.CellFontSize, this.CellFontStyle);
    //        this.dg.DefaultCellStyle.SelectionBackColor = SelectionBackColor;
    //        this.dg.EnableHeadersVisualStyles = false; // // Desabilita formatação padrão
    //        this.dg.ColumnHeadersDefaultCellStyle.Font = new Font(this.HeaderFontName, this.HeaderFontSize, this.HeaderFontStyle);
    //        this.dg.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
    //        this.dg.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
    //        this.dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    //        this.dg.RowsDefaultCellStyle.BackColor = RowDefaultColor;
    //        this.dg.RowHeadersVisible = false;
    //        this.dg.AlternatingRowsDefaultCellStyle.BackColor = RowAlternativeColor;
    //        this.dg.MultiSelect = false;
    //        this.IsRenderized = true;
    //    }

    //    public void RenderizeStyle(GridTheme tema, bool IsZebra)
    //    {
    //        tema.ApplyTheme(this, IsZebra);
    //        this.RenderizeStyle();
    //    }

    //    /// <summary>
    //    ///     ''' Renderiza o DataGridView com o tema azul.
    //    ///     ''' </summary>
    //    ///     ''' <param name="dg">DataGridView.</param>
    //    public static void RenderizeStyle(DataGridView dg)
    //    {
    //        dg.EditMode = DataGridViewEditMode.EditProgrammatically;
    //        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //        dg.AllowUserToAddRows = false;
    //        dg.AllowUserToDeleteRows = false;
    //        dg.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
    //        dg.DefaultCellStyle.SelectionBackColor = Color.Blue;
    //        dg.EnableHeadersVisualStyles = false; // // Desabilita formatação padrão
    //        dg.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
    //        dg.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
    //        dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    //        dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    //        dg.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
    //        dg.RowHeadersVisible = false;
    //        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.PowderBlue;
    //        dg.MultiSelect = false;
    //    }

    //    /// <summary>
    //    ///     ''' Obtém o nome do título da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <returns>O texto do título alternado para maiúsculo.</returns>
    //    ///     ''' <remarks></remarks>
    //    private string getHeaderName()
    //    {
    //        if ((setHeaderToUpper))
    //            return this.HeaderName.ToUpper();
    //        else
    //            return this.HeaderName;
    //    }

    //    /// <summary>
    //    ///     ''' Guarda a posição corrente da barra de rolagem vertical.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public void saveCurrentPositionScroll()
    //    {
    //        try
    //        {
    //            this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Define a posição da barra de rolagem vertical.
    //    ///     ''' E seleciona uma célula.
    //    ///     ''' </summary>
    //    ///     ''' <param name="row">Número da linha.</param>
    //    ///     ''' <param name="columnName">Nome da coluna.</param>
    //    ///     ''' <remarks></remarks>
    //    public void restoreCurrentPositionScroll(int row, string columnName)
    //    {
    //        try
    //        {
    //            this.dg.FirstDisplayedScrollingRowIndex = scrollPosition;
    //            this.dg.CurrentCell = dg.Rows[row].Cells[columnName];
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Define a posição da barra de rolagem vertical.
    //    ///     ''' </summary>
    //    ///     ''' <remarks></remarks>
    //    public void restoreCurrentPositionScroll()
    //    {
    //        try
    //        {
    //            this.dg.FirstDisplayedScrollingRowIndex = scrollPosition;
    //            this.dg.CurrentCell = dg.Rows[this.OldRowIndex].Cells[this.OldColumnIndex];
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    public void setOnDoubleClick(PassControlClick ExecOnDoubleClick)
    //    {
    //        this.ExecOnDoubleClick = ExecOnDoubleClick;
    //    }

    //    public void setColumn(int index, string newHeaderName, int size, string align)
    //    {
    //        this.setWidth(index, size);
    //        this.setHeaderName(index, newHeaderName);
    //        this.setAlign(index, align);
    //    }

    //    public void setColumn(string columnName, string newHeaderName, int size, string align)
    //    {
    //        this.setWidth(columnName, size);
    //        this.setHeaderName(columnName, newHeaderName);
    //        this.setAlign(columnName, align);
    //    }

    //    public void setColumn(string columnName, string newHeaderName, int size)
    //    {
    //        this.setWidth(columnName, size);
    //        this.setHeaderName(columnName, newHeaderName);
    //        this.setAlign(columnName, AlignLeft);
    //    }

    //    public void setColumn(string columnName, string newHeaderName, int width, bool visible, string cellAlign)
    //    {
    //        try
    //        {
    //            this.setHeaderName(columnName, newHeaderName);
    //            this.setWidth(columnName, width);
    //            this.setVisible(columnName, visible);
    //            this.setAlign(columnName, cellAlign);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    public void setColumn(string columnName, string newHeaderName, int width, bool visible, string cellAlign, string numFormat)
    //    {
    //        try
    //        {
    //            this.setHeaderName(columnName, newHeaderName);
    //            this.setWidth(columnName, width);
    //            this.setVisible(columnName, visible);
    //            this.setAlign(columnName, cellAlign);
    //            this.setNumberFormat(columnName, numFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }


    //    /// <summary>
    //    ///     ''' Define a largura da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="index">Índice da coluna.</param>
    //    ///     ''' <param name="size">Tamanho da coluna.</param>
    //    ///     ''' <remarks></remarks>
    //    public void setWidth(int index, int size)
    //    {
    //        try
    //        {
    //            this.dg.Columns[index].Width = size;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(index, ex);
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Define a largura da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnName">Nome da coluna.</param>
    //    ///     ''' <param name="size">Tamanho da coluna.</param>
    //    ///     ''' <remarks></remarks>
    //    public void setWidth(string columnName, int size)
    //    {
    //        try
    //        {
    //            this.dg.Columns[columnName].Width = size;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(columnName, ex);
    //        }
    //    }


    //    /// <summary>
    //    ///     ''' Altera o tamanho da linha da célula.
    //    ///     ''' </summary>
    //    ///     ''' <param name="size"></param>
    //    ///     ''' <remarks></remarks>
    //    public void setRowHeight(int size)
    //    {
    //        try
    //        {
    //            this.dg.RowTemplate.Height = size;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(0, ex);
    //        }
    //    }

    //    private void setHeaderName(int index, string title)
    //    {
    //        try
    //        {
    //            this.HeaderName = title;
    //            this.dg.Columns[index].HeaderText = getHeaderName();
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(index, ex);
    //        }
    //    }

    //    private void setHeaderName(string columnName, string title)
    //    {
    //        try
    //        {
    //            this.HeaderName = title;
    //            this.dg.Columns[columnName].HeaderText = getHeaderName();
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(columnName, ex);
    //        }
    //    }


    //    private void setVisible(int index, bool isVisible)
    //    {
    //        try
    //        {
    //            this.dg.Columns[index].Visible = isVisible;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(index, ex);
    //        }
    //    }

    //    private void setVisible(string columnName, bool isVisible)
    //    {
    //        try
    //        {
    //            this.dg.Columns[columnName].Visible = isVisible;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(columnName, ex);
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Define quais colunas ficarão ocultas.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnsName">Nome das colunas separadas por vírgula.</param>
    //    ///     ''' <remarks></remarks>
    //    public void setVisibleFalse(string columnsName)
    //    {
    //        try
    //        {
    //            Regex rgx = new Regex(",");
    //            string[] column = rgx.Split(columnsName);

    //            foreach (string setThis in column)
    //            {
    //                try
    //                {
    //                    this.setVisible(setThis.Trim(), false);
    //                }
    //                catch (Exception ex)
    //                {
    //                    this.ShowError(setThis, ex);
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    public void setAlign(int index, string align)
    //    {
    //        try
    //        {
    //            this.dg.Columns[index].DefaultCellStyle.Alignment = getAlign(align);
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(index, ex);
    //        }
    //    }
    //    public void setAlign(string columnName, string align)
    //    {
    //        try
    //        {
    //            this.dg.Columns[columnName].DefaultCellStyle.Alignment = getAlign(align);
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(columnName, ex);
    //        }
    //    }
    //    private DataGridViewContentAlignment getAlign(string align)
    //    {
    //        switch ((align))
    //        {
    //            case "center":
    //                {
    //                    return DataGridViewContentAlignment.MiddleCenter;
    //                }

    //            case "left":
    //                {
    //                    return DataGridViewContentAlignment.MiddleLeft;
    //                }

    //            case "right":
    //                {
    //                    return DataGridViewContentAlignment.MiddleRight;
    //                }

    //            default:
    //                {
    //                    return DataGridViewContentAlignment.MiddleLeft;
    //                }
    //        }
    //    }

    //    public void setNumberFormat(int index, string format) {
    //        if ((string.IsNullOrEmpty(format)))
    //            return;
    //        try {
    //            this.dg.Columns[index].DefaultCellStyle.Format = format;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.ShowError(index, ex);
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Altera o formato de numeral.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnName"></param>
    //    ///     ''' <param name="format"></param>
    //    ///     ''' <remarks></remarks>
    //    public void setNumberFormat(string columnName, string format) {
    //        if ((string.IsNullOrEmpty(format)))
    //            return;
    //        try {
    //            this.dg.Columns[columnName].DefaultCellStyle.Format = format; }
    //        catch (Exception ex) {
    //            this.ShowError(columnName, ex); }
    //    }

    //    private void ShowError(int index, Exception ex) {
    //        if ((this.exibirMsgBox))
    //            Request.GetError("Coluna: " + index.ToString() + Environment.NewLine + ex.ToString());
    //        //Interaction.MsgBox("Coluna: " + index.ToString() + Constants.vbCrLf + ex.ToString(), MsgBoxStyle.Critical);
    //    }

    //    private void ShowError(string columnName, Exception ex) {
    //        if ((this.exibirMsgBox))
    //            Request.GetError("Coluna: " + columnName + Environment.NewLine + ex.ToString());
    //            //MessageBox.Show("Coluna: " + columnName + Environment.NewLine + ex.ToString(), "Erro",,"", MessageBoxIcon.Error);
    //    }

    //    /// <summary>
    //    ///     ''' Obtém o valor da célula indicada pelo número da linha e nome da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="row">Linha da célula.</param>
    //    ///     ''' <param name="columnName">Nome da coluna.</param>
    //    ///     ''' <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
    //    ///     ''' <remarks></remarks>
    //    public object getValue(int row, string columnName)
    //    {
    //        try
    //        {
    //            return dg.Rows[row].Cells[columnName].Value;
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Obtém o valor da célula indicada pelo número da linha e índice da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="row">Linha da célula.</param>
    //    ///     ''' <param name="index">Indice da coluna.</param>
    //    ///     ''' <returns>Um objeto definido pelo tipo de dado da coluna.</returns>
    //    ///     ''' <remarks></remarks>
    //    public object getValue(int row, int index)
    //    {
    //        try
    //        {
    //            return dg.Rows[row].Cells[index].Value;
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Obtém o valor da célula indicada pelo nome da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnName">Nome da coluna.</param>
    //    ///     ''' <returns>Retorna um valor não tipado.</returns>
    //    ///     ''' <remarks></remarks>
    //    public object getValue(string columnName)
    //    {
    //        try
    //        {
    //            return dg.Rows[this.CurrentRow].Cells[columnName].Value;
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Obtém o valor da célula indicada pelo índice da coluna.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnIndex">Índice da coluna.</param>
    //    ///     ''' <returns>Retorna um valor não tipado.</returns>
    //    ///     ''' <remarks></remarks>
    //    public object getValue(int columnIndex)
    //    {
    //        try
    //        {
    //            return dg.Rows[this.CurrentRow].Cells[columnIndex].Value;
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Obtém e converte o valor de uma célula para inteiro.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnName">Nome da coluna.</param>
    //    ///     ''' <returns>Retorna um inteiro.</returns>
    //    ///     ''' <remarks></remarks>
    //    public int ToInt(string columnName)
    //    {
    //        try
    //        {
    //            return System.Convert.ToInt32(dg.Rows[this.CurrentRow].Cells[columnName].Value);
    //        }
    //        catch (Exception ex)
    //        {
    //            return default(int);
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Obtém e converte o valor de uma célula para inteiro.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnIndex">Índice da coluna.</param>
    //    ///     ''' <returns>Retorna um inteiro.</returns>
    //    ///     ''' <remarks></remarks>
    //    public int ToInt(int columnIndex)
    //    {
    //        try
    //        {
    //            return System.Convert.ToInt32(dg.Rows[this.CurrentRow].Cells[columnIndex].Value);
    //        }
    //        catch (Exception ex)
    //        {
    //            return default(int);
    //        }
    //    }

    //    public int[] getIntArray(string column)
    //    {
    //        List<int> array = new List<int>();

    //        foreach (DataGridViewRow item in this.dg.Rows)
    //            array.Add(System.Convert.ToInt32(item.Cells[column].Value));
    //        return array.ToArray();
    //    }

    //    /// <summary>
    //    ///     ''' Altera o valor de uma célula.
    //    ///     ''' </summary>
    //    ///     ''' <param name="columnName"></param>
    //    ///     ''' <param name="value"></param>
    //    public void SetValue(string columnName, bool value) {
    //        dg.Rows[this.CurrentRow].Cells[columnName].Value = value;
    //    }

    //    public void AddMenu(bool AddMenuSuspenso, bool AddCopyClipboard)
    //    {
    //        //if ((AddMenuSuspenso))
    //        //{
    //        //    this.setOnRightClick(this.menu.ShowMenu);
    //        //    if ((AddCopyClipboard))
    //        //        this.setMenuSuspenso();
    //        //}
    //    }

    //    public void setOnRightClick(PassControl onRightClick)
    //    {
    //        this.ExecOnMouseRightButton = onRightClick;
    //    }

    //    private void setMenuSuspenso()
    //    {
    //        //this.menu.Add("Copiar célula", "Copia a célula para área de transferência", this.CopyCell);
    //        //this.menu.Add("Copiar linha", "Copia a linha para área de transferência", this.CopyRow);
    //        //this.menu.Add("Copiar grade", "Copia toda a grade para área de transferência", this.CopyGrid);
    //    }
    //    public void CopyRow()
    //    {
    //        try
    //        {
    //            Clipboard.SetDataObject(this.dg.GetClipboardContent());
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }
    //    public void CopyGrid()
    //    {
    //        try
    //        {
    //            this.dg.MultiSelect = true;
    //            this.dg.SelectAll();
    //            Clipboard.SetDataObject(this.dg.GetClipboardContent());
    //            this.dg.MultiSelect = false;
    //            this.restoreCurrentPositionScroll();
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }
    //    public void CopyCell()
    //    {
    //        try
    //        {
    //            Clipboard.SetText(this.dg.CurrentCell.Value.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    /// <summary>
    //    ///     ''' Define um novo CheckBoxLista com as colunas da grade.
    //    ///     ''' </summary>
    //    ///     ''' <param name="chk"></param>
    //    ///     ''' <remarks></remarks>
    //    public void SetCheckListBox(CheckedListBox chk)
    //    {
    //        this.checkList = chk;
    //        chk.Items.Clear();

    //        this.checkList.Font = new Font("Arial", 9);
    //        this.checkList.Size = new Size(190, 29);
    //        this.checkList.Enabled = false;
    //        this.checkList.BackColor = Color.FromArgb(75, 75, 75);

    //        List<string> colunas = new List<string>();
    //        List<string> indices = new List<string>();
    //        List<bool> @checked = new List<bool>();

    //        foreach (DataGridViewColumn column in dg.Columns)
    //        {
    //            colunas.Add(column.HeaderText);
    //            indices.Add(column.Index.ToString());
    //            @checked.Add(column.Visible);
    //        }

    //        //MCheckListBox a = new MCheckListBox(this.checkList, colunas.ToArray(), indices.ToArray());

    //        foreach (string index in indices)
    //            this.checkList.SetItemChecked(System.Convert.ToInt32(index), @checked[System.Convert.ToInt32(index)]);

    //        this.checkList.Enabled = true;
    //        this.checkListEvents = true;
    //    }

    //    /// <summary>
    //    ///     ''' Ocorre quando um dos índices é marcado ou desmarcado.
    //    ///     ''' </summary>
    //    ///     ''' <param name="Sender"></param>
    //    ///     ''' <param name="e"></param>
    //    ///     ''' <remarks></remarks>
    //    private void checkListBox_CheckChanged(object Sender, ItemCheckEventArgs e)
    //    {
    //        if (!(checkListEvents))
    //            return;

    //        // Dim item = checkList.SelectedItem.ToString()
    //        var index = checkList.SelectedIndex;

    //        if ((e.NewValue == CheckState.Checked))
    //            this.setVisible(index, true);
    //        else
    //            this.setVisible(index, false);
    //    }

    //    private void dg_Sorted(object sender, EventArgs e)
    //    {
    //        this.RenderizeStyle();
    //        this.dg.ClearSelection();
    //        try
    //        {
    //            this.ExecProcedure(dg);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    public void setCellFont(string name, int size, FontStyle style)
    //    {
    //        this.CellFontName = name;
    //        this.CellFontSize = size;
    //        this.CellFontStyle = style;
    //    }
    //    public void setHeaderFont(string name, int size, FontStyle style)
    //    {
    //        this.HeaderFontName = name;
    //        this.HeaderFontSize = size;
    //        this.HeaderFontStyle = style;
    //    }
    //    private string CellFontName { get; set; } = "Calibri";
    //    private string HeaderFontName { get; set; } = "Calibri";
    //    private int CellFontSize { get; set; } = 9;
    //    private int HeaderFontSize { get; set; } = 9;
    //    private FontStyle HeaderFontStyle { get; set; } = FontStyle.Bold;
    //    private FontStyle CellFontStyle { get; set; } = FontStyle.Regular;
    //    private void dg_EnableChanged(object Sender, EventArgs e)
    //    {
    //        if ((dg.Enabled))
    //        {
    //            dg.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
    //            dg.RowsDefaultCellStyle.BackColor = RowDefaultColor;
    //            dg.AlternatingRowsDefaultCellStyle.BackColor = RowAlternativeColor;
    //        }
    //        else
    //        {
    //            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
    //            dg.RowsDefaultCellStyle.BackColor = Color.LightGray;
    //            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray;
    //            dg.ClearSelection();
    //        }
    //    }

    //    private void dg_CurrentCellChanged(object Sender, EventArgs e)
    //    {
    //        if ((dg.CurrentRow == null))
    //            return;

    //        try
    //        {
    //            this.CurrentRow = dg.CurrentRow.Index;
    //            this.CurrentColumn = dg.CurrentCell.ColumnIndex;
    //        }
    //        catch (Exception ex)
    //        {
    //            this.erro = ex.Message;
    //        }
    //    }

    //    private void dg_CellMouseClick(object Sender, DataGridViewCellMouseEventArgs e)
    //    {
    //        if ((e.Button == MouseButtons.Right))
    //        {
    //            try
    //            {
    //                this.dg.CurrentCell = dg.Rows[e.RowIndex].Cells[e.ColumnIndex];
    //                this.Value = dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
    //                this.ExecOnMouseRightButton(Cursor.Position);
    //            }
    //            catch (Exception ex)
    //            {
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
    //            }
    //            catch (Exception ex)
    //            {
    //            }
    //            try
    //            {
    //                this.OldRowIndex = dg.CurrentRow.Index;
    //            }
    //            catch (Exception ex)
    //            {
    //            }
    //            try
    //            {
    //                this.OldColumnIndex = dg.CurrentCell.ColumnIndex;
    //            }
    //            catch (Exception ex)
    //            {
    //            }
    //        }
    //    }

    //    private void dg_CellMouseDoubleClick(object Sender, DataGridViewCellMouseEventArgs e)
    //    {
    //        try
    //        {
    //            this.scrollPosition = dg.FirstDisplayedScrollingRowIndex;
    //        }
    //        catch (Exception ex)
    //        {
    //        }

    //        try
    //        {
    //            if (!(dg.CurrentRow == null))
    //                this.OldRowIndex = dg.CurrentRow.Index;
    //        }
    //        catch (Exception ex)
    //        {
    //        }

    //        try
    //        {
    //            this.OldColumnIndex = dg.CurrentCell.ColumnIndex;
    //        }
    //        catch (Exception ex)
    //        {
    //        }

    //        try
    //        {
    //            if (!(ExecOnDoubleClick == null))
    //                this.ExecOnDoubleClick();
    //        }
    //        catch (Exception ex)
    //        {
    //            this.erro = ex.Message;
    //        }
    //    }


    //    public void setThemeOrange()
    //    {
    //        dg.EditMode = DataGridViewEditMode.EditProgrammatically;
    //        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //        dg.AllowUserToAddRows = false;
    //        dg.AllowUserToDeleteRows = false;
    //        dg.DefaultCellStyle.Font = new Font("Calibri", 9);
    //        dg.EnableHeadersVisualStyles = false;
    //        // Desabilita formatação padrão
    //        dg.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
    //        dg.ColumnHeadersDefaultCellStyle.BackColor = Color.OrangeRed;
    //        dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    //        dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    //        dg.RowsDefaultCellStyle.BackColor = Color.LightYellow;
    //        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Khaki;
    //        dg.DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod;
    //        dg.MultiSelect = false;
    //        dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    //        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    //        dg.RowHeadersVisible = false;
    //    }

    //    public void setThemeBlue()
    //    {
    //        dg.EditMode = DataGridViewEditMode.EditProgrammatically;
    //        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //        dg.AllowUserToAddRows = false;
    //        dg.AllowUserToDeleteRows = false;
    //        // Desabilita formatação padrão do cabeçalho
    //        dg.EnableHeadersVisualStyles = false;
    //        dg.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
    //        dg.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
    //        dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    //        dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    //        // Celulas
    //        dg.DefaultCellStyle.Font = new Font("Calibri", 9);
    //        dg.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
    //        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.PowderBlue;
    //        dg.RowHeadersVisible = false;
    //        dg.MultiSelect = false;
    //    }

    //    public void IsWrap(DataGridViewTriState state)
    //    {
    //        this.dg.DefaultCellStyle.WrapMode = state;
    //    }

    //    public void IsRowAutoSize(DataGridViewAutoSizeRowsMode state)
    //    {
    //        this.dg.AutoSizeRowsMode = state;
    //    }

    //    //public void SetSchema(DataSetSchema schema)
    //    //{
    //    //    this.dg.DataSource = schema.GetTable();

    //    //    if ((string.IsNullOrEmpty(schema.extras.type)))
    //    //        return;
    //    //    this.SetDesign(schema.extras.contents);

    //    //    var style = schema.extras.type.Split(",");
    //    //    if ((style(1).ToUpper() == "BLUE"))
    //    //        RenderizeStyle(GridTheme.Blue, System.Convert.ToBoolean(style(2)));
    //    //    if ((style(1).ToUpper() == "CLASSIC"))
    //    //        RenderizeStyle(GridTheme.Classic, System.Convert.ToBoolean(style(2)));
    //    //    if ((style(1).ToUpper() == "GREEN"))
    //    //        RenderizeStyle(GridTheme.Green, System.Convert.ToBoolean(style(2)));
    //    //    if ((style(1).ToUpper() == "ORANGE"))
    //    //        RenderizeStyle(GridTheme.Orange, System.Convert.ToBoolean(style(2)));
    //    //    if ((style(1).ToUpper() == "ROSE"))
    //    //        RenderizeStyle(GridTheme.Rose, System.Convert.ToBoolean(style(2)));
    //    //}

    //    public void SetDesign(List<string> contents) {
    //        if ((contents.Count() == 0))
    //            return;

    //        foreach (var content in contents)
    //            this.SetColumnContent(content.Split(','));
    //    }

    //    private void SetColumnContent(string[] content) {
    //        var columnName = content[0];
    //        var newHeaderName = content[1];
    //        var width = System.Convert.ToInt32(content[2]);
    //        var visible = System.Convert.ToBoolean(content[3]);
    //        var cellAlign = content[4];
    //        var numFormat = string.Empty;

    //        if ((content.Length == 6))
    //            numFormat = content[5];

    //        this.setColumn(columnName, newHeaderName, width, visible, cellAlign, numFormat);
    //    }
    //}
}
