using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class DataReader<T>
    {
        public T row { get; set; }
        public DataReader()
        {

        }

        #region: Conversão by DataRow
        /// <summary>
        /// Converte um valor para o tipo int ou retorna '0' em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public int ToInt(object column)
        {
            // Captura o valor.
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null) return 0;
                else return (int)(b);
            }
            catch { return 0; }
        }

        /// <summary>
        /// Converte um valor para o tipo string ou retorna vazio em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public string ToString(object column)
        {
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return "";
                else
                    return column.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Converte um valor para o tipo double ou '0' em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public double ToDouble(object column)
        {
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return 0;
                else
                    return (double)(column);
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Converte um valor para o tipo decimal ou '0' em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public decimal ToDecimal(object column)
        {
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return 0;
                else
                    return (decimal)(column);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converte um valor para o tipo DateTime ou 01/01/1900 em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public DateTime ToDateTime(object column)
        {
            // Captura o valor.
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return System.Convert.ToDateTime("1900-01-01");
                else
                    return Convert.ToDateTime(column);
            }
            catch
            {
                return System.Convert.ToDateTime("1900-01-01");
            }
        }

        /// <summary>
        /// Converte um valor para o tipo bool ou false em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public bool ToBoolean(object column)
        {
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return false;
                else
                    return Convert.ToBoolean(column);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converte um valor para o tipo object ou null em caso de nulo.
        /// </summary>
        /// <param name="column">Coluna a ser convertida.</param>        
        public object ToObject(object column)
        {
            var b = column;

            try
            {
                // Verifica se o valor é nulo e retorna o primeiro argumento, senão retorna o valor.
                if (b == null)
                    return false;
                else
                    return (object)column;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
