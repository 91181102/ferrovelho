using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class GridTheme
    {
        public static GridTheme Blue = new GridTheme(Color.White, Color.Blue, Color.Black, Color.AliceBlue, Color.PowderBlue, Color.Blue);
        public static GridTheme Green = new GridTheme(Color.White, Color.DarkGreen, Color.Black, Color.Beige, Color.LightGreen, Color.Blue);
        public static GridTheme Rose = new GridTheme(Color.White, Color.Brown, Color.Black, Color.LavenderBlush, Color.PeachPuff, Color.Blue);
        public static GridTheme Orange = new GridTheme(Color.White, Color.OrangeRed, Color.Black, Color.LightYellow, Color.Khaki, Color.Blue);
        public static GridTheme Classic = new GridTheme(Color.White, Color.DarkGray, Color.Black, Color.White, Color.LightGray, Color.Blue);

        /// <summary>
        ///     ''' Cor da fonte do título da coluna.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color HeaderForeColor { get; set; }
        /// <summary>
        ///     ''' Cor de fundo do título da coluna.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color HeaderBackColor { get; set; }
        /// <summary>
        ///     ''' Cor de fonte da célula.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color CellForeColor { get; set; }
        /// <summary>
        ///     ''' Cor de fundo da linha par.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color RowDefaultColor { get; set; }
        /// <summary>
        ///     ''' Cor de fundo da linha ímpar.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color RowAlternativeColor { get; set; }
        /// <summary>
        ///     ''' Cor da linha selecionada.
        ///     ''' </summary>
        ///     ''' <value></value>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        private Color SelectionBackColor { get; set; }

        public GridTheme()
        {
        }

        /// <summary>
        ///     ''' Carrega valores para a classe.
        ///     ''' </summary>
        ///     ''' <param name="HeaderForeColor">Cor da fonte do título da coluna.</param>
        ///     ''' <param name="HeaderBackColor">Cor de fundo do título da coluna.</param>
        ///     ''' <param name="CellForeColor">Cor de fonte da célula.</param>
        ///     ''' <param name="RowDefaultColor">Cor de fundo da linha par.</param>
        ///     ''' <param name="RowAlternativeColor">Cor de fundo da linha ímpar.</param>
        ///     ''' <param name="SelectionBackColor">Cor da linha selecionada.</param>
        ///     ''' <remarks></remarks>
        public GridTheme(Color HeaderForeColor, Color HeaderBackColor, Color CellForeColor, Color RowDefaultColor, Color RowAlternativeColor, Color SelectionBackColor)
        {
            this.HeaderForeColor = HeaderForeColor;
            this.HeaderBackColor = HeaderBackColor;
            this.CellForeColor = CellForeColor;
            this.RowDefaultColor = RowDefaultColor;
            this.RowAlternativeColor = RowAlternativeColor;
            this.SelectionBackColor = SelectionBackColor;
        }

        /// <summary>
        ///     ''' Aplica o tema no grid.
        ///     ''' </summary>
        ///     ''' <param name="dg">A variável Model_DataGridView.</param>
        ///     ''' <param name="IsZebra">Informa se haverá cor zebrada na grade.</param>
        ///     ''' <remarks></remarks>
        public void ApplyTheme(MDataGridView dg, bool IsZebra)
        {
            dg.HeaderForeColor = this.HeaderForeColor;
            dg.HeaderBackColor = this.HeaderBackColor;
            dg.CellForeColor = this.CellForeColor;
            dg.RowDefaultColor = this.RowDefaultColor;
            if ((IsZebra))
                dg.RowAlternativeColor = this.RowAlternativeColor;
            else
                dg.RowAlternativeColor = this.RowDefaultColor;
            dg.SelectionBackColor = this.SelectionBackColor;
        }
    }
}
