using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    public class OutToExcel
    {
        /// <summary>
        /// Barra de progresso.
        /// </summary>
        public ProgressBar pb;

        /// <summary>
        /// Método para exportar um DataGridView para uma planilha Excel.
        /// </summary>
        /// <param name="dg">Componente DataGridView</param>
        /// <returns>true ou false</returns>
        public bool ExportarParaExcel(DataGridView dg) {
            // Deixa o ponteiro do mouse em foma de esperando.
            Cursor.Current = Cursors.WaitCursor;

            // Instancia o formulário com a barra de progresso.
            //Form_ProgressBar form = new Form_ProgressBar();
            // Informa quantos resgistros serão importadoss.
            //pb.Maximum = dg.RowCount - 1;
            //form.IniciarProgressiveBar(dg.RowCount - 1);
            // Posiciona a janela no centro da tela.
            //pb.Value = 0;
            //form.StartPosition = FormStartPosition.CenterScreen;
            // Mostra o formulário.
            //pb.Visible = true;
            //form.Show();
            SetPBDefault(dg.RowCount);

            // Instancia caixa de diálogo Salvar Arquivo
            SaveFileDialog salvar = new SaveFileDialog();

            // Declara variáveis.
            bool Exportar = false;
            Microsoft.Office.Interop.Excel.Application App;
            Microsoft.Office.Interop.Excel.Workbook WorkBook;
            Microsoft.Office.Interop.Excel.Worksheet WorkSheet;
            object misValue = System.Reflection.Missing.Value;
            int i, j;
            App = new Microsoft.Office.Interop.Excel.Application();

            try {
                WorkBook = App.Workbooks.Add(misValue);
                //WorkSheet = WorkBook.ActiveSheet();
                WorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                for (int k = 1; k <= dg.ColumnCount; k++)
                    WorkSheet.Cells[1, k] = dg.Columns[k - 1].HeaderText;

                // Pecorre as linhas.
                for (i = 0; i <= dg.RowCount - 1; i++) {
                    // Pecorre as colunas.
                    for (j = 0; j <= dg.ColumnCount - 1; j++) {
                        try {
                            WorkSheet.Cells[i + 2, j + 1] = dg[j, i].Value; }
                        catch {
                            WorkSheet.Cells[i + 2, j + 1] = "'" + dg[j, i].Value.ToString(); } }
                    // Incrementa a barra de progresso.
                    try {
                        pb.Increment(1); //form.IncrementarBarra(); 
                    } catch { } }
                WorkSheet.Columns.AutoFit();
                WorkSheet.Rows.AutoFit();

                // Retira o ponteiro do mouse do modo de espera
                Cursor.Current = Cursors.Default;

                // Abre Excel
                App.Visible = true;

                try { Exportar = true; }
                catch { _MsgBox.Error("Arquivo já aberto"); }

                releaseObject(App);
                releaseObject(WorkBook);
                releaseObject(WorkSheet); }
            catch (Exception ex) {
                _MsgBox.Error(ex.ToString());
                App.Visible = true; }
            // Fecha janela da barra de progresso.
            //pb.Visible = false;
            //form.Close();
            // Limpa janela da memória.
            //pb.Value = 0;
            //form.Dispose();
            SetPbFinish();
            return Exportar;
        }

        /// <summary>
        /// Método para exportar um DataTable para uma planilha Excel.
        /// </summary>
        /// <param name="dt">Componente DataTable</param>
        /// <param name="typeOut">EXCEL ou TXT</param>
        /// <returns>true ou false</returns>
        public static bool Send(System.Data.DataTable dt, string typeOut, bool visible) {
            if (dt != null) {
                if (dt.Rows.Count > 0) {
                    if (typeOut == "EXCEL") {
                        return Sending(dt); }
                    else if (typeOut == "TXT") {
                        return SendTabTxt(dt, visible); }
                    else {
                        // return SaveCsv(dt, visible);
                        return false; } }
                else {
                    return false; } }
            else {
                return false; }
        }

        /// <summary>
        /// Método para exportar um DataGridView para uma planilha Excel.
        /// </summary>
        /// <param name="dg">Componente DataGridView</param>
        /// <returns></returns>
        public static bool Send(System.Windows.Forms.DataGridView dg, ProgressBar pb) {
            if (dg != null) {
                if (dg.Rows.Count > 0) {
                    OutToExcel c = new OutToExcel();
                    c.pb = pb;
                    return c.ExportarParaExcel(dg); }
                else {
                    return false; } }
            else {
                return false; }
        }

        /// <summary>
        /// Exporta um arquivo de clientes para o JD.
        /// </summary>
        /// <param name="dt">Tabela</param>
        /// <returns>Retorna true ou false.</returns>
        private static bool SendTabTxt(System.Data.DataTable dt, bool visible) {
            //// Declara variáveis.
            bool Exportar = false;
            return Exportar;
        }

        private static bool Sending(System.Data.DataTable dt) {
            // Deixa o ponteiro do mouse em foma de esperando.
            Cursor.Current = Cursors.WaitCursor;

            //// Instancia o formulário com a barra de progresso.
            //Form_ProgressBar form = new Form_ProgressBar();
            //// Informa quantos resgistros serão importadoss.
            //form.IniciarProgressiveBar(dt.Rows.Count - 1);
            //// Posiciona a janela no centro da tela.
            //form.StartPosition = FormStartPosition.CenterScreen;
            //// Mostra o formulário.
            //form.Show();

            // Instancia caixa de diálogo Salvar Arquivo
            SaveFileDialog salvar = new SaveFileDialog();

            // Declara variáveis.
            bool Exportar = false;
            Microsoft.Office.Interop.Excel.Application App;
            Microsoft.Office.Interop.Excel.Workbook WorkBook;
            Microsoft.Office.Interop.Excel.Worksheet WorkSheet;
            object misValue = System.Reflection.Missing.Value;
            int i, j;

            try {
                App = new Microsoft.Office.Interop.Excel.Application();
                WorkBook = App.Workbooks.Add(misValue);
                //WorkSheet = WorkBook.ActiveSheet();
                WorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                for (int k = 1; k <= dt.Columns.Count; k++)
                    WorkSheet.Cells[1, k] = dt.Columns[k - 1].ColumnName;

                // Pecorre as linhas.
                for (i = 0; i <= dt.Rows.Count - 1; i++) {
                    // Pecorre as colunas.
                    for (j = 0; j <= dt.Columns.Count - 1; j++)
                        WorkSheet.Cells[i + 2, j + 1] = "'" + dt.Rows[i].Field<object>(j);
                    // Incrementa a barra de progresso.
                    try { //form.IncrementarBarra();
                    } catch { }
                }
                WorkSheet.Columns.AutoFit();
                WorkSheet.Rows.AutoFit();

                // Retira o ponteiro do mouse do modo de espera
                Cursor.Current = Cursors.Default;

                // Abre Excel
                App.Visible = true;

                try {
                    Exportar = true; }
                catch (Exception ex) {
                    _MsgBox.Error("Arquivo já aberto"); }

                releaseObject(App);
                releaseObject(WorkBook);
                releaseObject(WorkSheet); }
            catch (Exception ex) {
                _MsgBox.Error(ex.ToString()); }
            //// Fecha janela da barra de progresso.
            //form.Close();
            //// Limpa janela da memória.
            //form.Dispose();

            return Exportar;
        }

        private static void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null; }
            catch (Exception ex) {
                obj = null; }
            finally {
                GC.Collect(); }
        }

        #region: progressive bar
        /// <summary>
        /// Define o valor padrão para o Progressive bar.
        /// </summary>
        /// <param name="count"></param>
        private void SetPBDefault(int count) {
            // Informa quantos resgistros serão importadoss.
            pb.Maximum = count - 1;
            // Posiciona o progressive bar na primeira posição.
            pb.Value = 0;
            // Exibe o progressive bar.
            pb.Visible = true;
        }

        private void Increment() {
            pb.Increment(1);
        }

        /// <summary>
        /// Finaliza o progressive bar.
        /// </summary>
        private void SetPbFinish() {
            // Posiciona o progressive bar na primeira posição.
            pb.Value = 0;
            // Exibe o progressive bar.
            pb.Visible = false;
        }

        #endregion

        public static string formatJson(string content) {
            content = content
                        .Replace("}", Environment.NewLine + "}" + Environment.NewLine + Tab())
                        .Replace("{", "{" + Environment.NewLine + Tab())
                        .Replace("[\"", "[" + Environment.NewLine + Tab() + "\"")
                        .Replace(":[\"", ": [" + Environment.NewLine + Tab() + "\"")
                        .Replace("],", Environment.NewLine + "]," + Environment.NewLine + Tab())
                        .Replace("]}", Environment.NewLine + "]" + Environment.NewLine + Tab() + "}")
                        .Replace(",\"", "," + Environment.NewLine + Tab() + "\"");
            return content;
        }

        private static string Tab() {
            return new string(' ', 4);
        }
    }
}
