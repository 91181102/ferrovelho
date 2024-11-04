using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ControleCompraVenda.Dados
{
    public class Parse
    {
        public static string errorField = string.Empty;

        /// <summary>
        /// Converte um DataTable numa lista.
        /// </summary>
        /// <typeparam name="T">Classe da lista.</typeparam>
        /// <param name="dt">DataTable.</param>
        /// <returns>Retorna uma lista.</returns>
        public static void ToList<T>(DataTable dt, List<T> data)
        {
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
                //   try { barra.Increment(); } catch { }
            }
        }

        /// <summary>
        /// Converte um dataTable para lista.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Obtém uma instância populada de um registro da tabela.
        /// </summary>
        /// <typeparam name="T">Classe a ser instanciada.</typeparam>
        /// <param name="dr">Registro da tabela.</param>
        /// <returns>Retorna uma instância da classe.</returns>
        public static T GetItem<T>(DataRow dr) {
            // Define o tipo da instância.
            Type temp = typeof(T);
            // Cria uma instância do tipo definido.
            T obj = Activator.CreateInstance<T>();

            // Pecorre as colunas do registro.
            foreach (DataColumn column in dr.Table.Columns) {
                foreach (PropertyInfo pro in temp.GetProperties()) {
                    if (pro.Name == column.ColumnName) {
                        if (dr[column.ColumnName].GetType().GetTypeInfo() == Type.GetType("System.Int64").GetTypeInfo()) {
                            pro.SetValue(obj, ToInt(dr[column.ColumnName]), null); }
                        //if (dr[column.ColumnName].GetType().GetTypeInfo() == Type.GetType("System.Int32").GetTypeInfo()) {
                        //    pro.SetValue(obj, ToInt(dr[column.ColumnName]), null); }
                        else if (pro.PropertyType.FullName == "System.String") {
                            pro.SetValue(obj, dr[column.ColumnName].ToString(), null); }
                        else if (pro.PropertyType.FullName == "System.Boolean") {
                            pro.SetValue(obj, ToBoolean(dr[column.ColumnName]), null); }
                        else {
                            try {
                                pro.SetValue(obj, dr[column.ColumnName], null); }
                            catch (Exception e) {
                                errorField = e.ToString(); } } }
                    else { continue; } } }
            return obj;
        }

        /// <summary>
        /// Converte um XML para objeto,
        /// </summary>
        /// <typeparam name="T">Tipo de objeto.</typeparam>
        /// <param name="value">Arquivo XML.</param>
        /// <returns>Retorna o objeto.</returns>
        public static T GetItem<T>(string value)
        {
            var settings = new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
                IgnoreWhitespace = true,
                IgnoreComments = true
            };

            var xmlReader = XmlReader.Create(new StringReader(value), settings);
            xmlReader.Read();
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                T ret = (T)ser.Deserialize(xmlReader);
                return ret;
            }
            catch (Exception e)
            {
                string erro = e.ToString();
                int a = 0;
                T ret = Activator.CreateInstance<T>();
                return ret;
            }
        }

        /// <summary>
        /// Converte um object para bool.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ToBoolean(object value) {
            sbyte sbyte_result = 0;

            if (sbyte.TryParse(value.ToString(), out sbyte_result)) {
                if (value.ToString() == "0") return false;
                else return true; }

            bool bool_result = false;
            if (bool.TryParse(value.ToString(), out bool_result)) {
                if ((bool)value == false) return false;
                else return true; }
            return bool_result;
        }

        /// <summary>
        /// Converte um objeto para inteiro.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int ToInt(object value) {
            int int_result = 0;

            if (int.TryParse(value.ToString(),out int_result)) {
                int_result = Convert.ToInt32(value.ToString()); }
            return int_result;
        }

        /// <summary>
        /// Método para verificar se um caractere ou string é um número.
        /// </summary>
        /// <param name="value">Valor a ser analisado.</param>
        /// <returns>Retorna true ou false.</returns>
        public static bool isNumber(object value)
        {
            decimal number = 0;
            if (decimal.TryParse(value.ToString(), out number))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Método para extrair os números de uma string.
        /// </summary>
        /// <param name="value">String a ser analisada.</param>
        /// <returns>Retorna uma nova string apenas com os números.</returns>
        public static string getNumbers(string value)
        {
            string newValue = "";

            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i < value.Length; i++)
                    if (isNumber(value.Substring(i, 1)))
                        newValue += value.Substring(i, 1);
            }
            else
            {
                newValue = String.Empty;
            }
            return newValue;
        }

        /// <summary>
        /// Retorna a string com uma valor vazio caso seja null.
        /// </summary>
        /// <param name="value">String para verificação.</param>
        /// <returns>Retorna a mesma string ou com valor vazio.</returns>
        public static string IfIsNull(string value)
        {
            if (String.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

        /// <summary>
        /// Retorna um double com valor '0' case seja null.
        /// </summary>
        /// <param name="value">Valor para verificação.</param>
        /// <returns>Retorna o mesmo valor ou valor zerado.</returns>
        public static double IfIsNull(object value)
        {
            if (value == null)
                value = 0;
            return (double)value;
        }

        /// <summary>
        /// Formata um CPF ou CNPJ com máscara.
        /// </summary>
        /// <param name="objeto">CPF ou CNPJ somente números.</param>
        /// <returns>Retorna uma string formatada.</returns>
        public static string Formata_CNPJ_CPF(string objeto)
        {
            objeto = getNumbers(objeto);
            try
            {
                if ((objeto.Trim().Length) < 1)
                    objeto = "";
                else if ((objeto.Length) == 14)
                {
                    objeto = Mid(objeto, 0, 2) + "." + Mid(objeto, 2, 3) + "." + Mid(objeto, 5, 3) + "/" + Mid(objeto, 8, 4) + "-" + Mid(objeto, 12, 2);
                    return objeto;
                }
                else if ((objeto.Length) == 11)
                {
                    objeto = Mid(objeto, 1, 3) + "." + Mid(objeto, 4, 3) + "." + Mid(objeto, 7, 3) + "-" + Mid(objeto, 10, 2);
                }
            }
            catch
            {
                objeto = "";
            }
            return objeto;
        }

        /// <summary>
        /// Retorna uma substring.
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="startIndex"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public static string Mid(string objeto, int startIndex, int lenght) {
            try {
                objeto = objeto.Substring(startIndex, lenght);
                return objeto; }
            catch { return objeto; }
        }

        /// <summary>
        /// Repete uma string repetida "n" vezes.
        /// </summary>
        /// <param name="qtd"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Strings(int qtd, string value) {
            var txt = string.Empty;
            if (qtd < 1) return txt;
            for (int i = 0; i <= qtd; i++)
                txt += value;
            return txt;
        }

        /// <summary>
        /// Retorna uma string de um tamanho determinado.
        /// </summary>
        /// <param name="lenght"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLenght(int lenght, string value) {
            var txt = string.Empty;
            int rest = Math.Abs(value.Length - lenght);
            if (value.Length < lenght) {
                txt += value + Strings(rest, " ");
                return txt;
            }
            txt = value.Substring(0, lenght);
            return txt;
        }

        /// <summary>
        /// Retorna ums string de um tamanho determinado com alinhamento à direita.
        /// </summary>
        /// <param name="lenght"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLenghtRight(int lenght, string value) {
            var txt = string.Empty;
            int rest = Math.Abs(value.Length - lenght);
            if (value.Length < lenght) {
                txt += Strings(rest, " ") + value;
                return txt;
            }
            txt = value.Substring(0, lenght);
            return txt;
        }

        /// <summary>
        /// Copia um DataGridView para a área de transferência.
        /// </summary>
        /// <param name="sender">Objeto a ser copiado.</param>
        /// <param name="selectAll">Define se todas as células serão copiadas.</param>
        /// <remarks></remarks>
        public static void CopyToClipboard(System.Windows.Forms.DataGridView sender, bool selectAll) {
            if (!selectAll)
                System.Windows.Forms.Clipboard.SetDataObject(sender.GetClipboardContent());
            else {
                sender.MultiSelect = true;
                sender.SelectAll();
                System.Windows.Forms.Clipboard.SetDataObject(sender.GetClipboardContent());
                sender.MultiSelect = false; }
        }
           
    }
}
