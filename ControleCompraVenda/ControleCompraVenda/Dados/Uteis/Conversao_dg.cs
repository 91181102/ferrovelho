using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    public class Conversao_dg
    {
        private DataGridView dg { get; set; }
        private int rows { get; set; }

        public Conversao_dg(DataGridView dg)
        {
            this.dg = dg;
            this.rows = dg.RowCount;
        }


        /// <summary>
        ///     ''' Obtém o valor da célula indicada pelo número da linha e nome da coluna.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna.</param>
        ///     ''' <returns>Retorna um objeto definido pelo tipo de dado da coluna.</returns>
        ///     ''' <remarks></remarks>
        public object getValue(string columnName)
        {
            try
            {
                return dg.Rows[this.dg.CurrentRow.Index].Cells[columnName].Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo int ou retorna '0' em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna.</param>
        ///     ''' <returns>Retorna o valor do inteiro ou 0.</returns>
        ///     ''' <remarks></remarks>
        public int ToInt(string columnName)
        {
            try
            {
                return System.Convert.ToInt32(this.getValue(columnName));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo string ou retorna vazio em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public string To_String(string columnName)
        {
            try
            {
                return this.getValue(columnName).ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo Double ou retorna 0 em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public double ToDouble(string columnName)
        {
            try
            {
                return System.Convert.ToDouble(this.getValue(columnName));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo decimal ou retorna 0 em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public decimal ToDecimal(string columnName)
        {
            try
            {
                return System.Convert.ToDecimal(this.getValue(columnName));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo DateTime ou retorna 01/01/1900 em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public DateTime ToDateTime(string columnName)
        {
            try
            {
                return Convert.ToDateTime(this.getValue(columnName));
            }
            catch (Exception ex)
            {
                return Convert.ToDateTime("1900-01-01");
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo booleano ou retorna false em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public bool ToBoolean(string columnName)
        {
            try
            {
                return System.Convert.ToBoolean(this.getValue(columnName));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        ///     ''' Converte um valor para o tipo Object ou retorna NULL em caso de nulo.
        ///     ''' </summary>
        ///     ''' <param name="columnName">Nome da coluna</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public object ToObject(string columnName)
        {
            try
            {
                return this.getValue(columnName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
