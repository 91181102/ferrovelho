using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCompraVenda.Dados
{
    public class MComboBox
    {
        /// <summary>
        /// Altera a aparência do comboBox incluíndo a lista de itens com IDs.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="nomes"></param>
        /// <param name="ids"></param>
        public static void SetComboBox(System.Windows.Forms.ComboBox cbo, string[] nomes, string[] ids) {
            SetItems(cbo, nomes);
            SetIds(cbo, ids);
            SetStyle(cbo);
        }

        /// <summary>
        /// Altera a aparência do comboBox incluíndo a lista de itens com IDs.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="i"></param>
        public static void SetComboBox(System.Windows.Forms.ComboBox cbo, Intent i) {
            cbo.Items.Clear();
            SetComboBox(cbo, i.getStringArrayExtra("nomes"), i.getStringArrayExtra("ids"));
            SetStyle(cbo);
        }

        /// <summary>
        /// Obtém o ID no formato string pelo índice.
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static string GetIdStringByIndex(System.Windows.Forms.ComboBox cbo) {
            if (cbo.AccessibleDescription == null) return string.Empty;
            if (string.IsNullOrEmpty(cbo.AccessibleDescription)) return string.Empty;
            int index = 0;
            index = cbo.SelectedIndex;
            string[] id = cbo.AccessibleDescription.Split(',');
            return id[index];
        }

        /// <summary>
        /// Obtém o ID no formato int pelo índice.
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static int GetIdByIndex(System.Windows.Forms.ComboBox cbo) {
            if (cbo.AccessibleDescription == null) return -1;
            if (string.IsNullOrEmpty(cbo.AccessibleDescription)) return -1;
            int index = 0;
            index = cbo.SelectedIndex;
            string[] id = cbo.AccessibleDescription.Split(',');
            int ID = Convert.ToInt32(id[index]);
            return ID;
        }

        /// <summary>
        /// Adiciona a lista de itens.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="items"></param>
        private static void SetItems(System.Windows.Forms.ComboBox cbo, string[] items) {
            foreach (string item in items)
                cbo.Items.Add(item);

            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
        }

        /// <summary>
        /// Guarda os ids numa string.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="ids"></param>
        private static void SetIds(System.Windows.Forms.ComboBox cbo, string[] ids) {
            var t = new StringBuilder();
            foreach (string item in ids)
                t.Append(item + ",");

            var a = string.Empty;
            if (t.Length > 0)
                a = t.ToString().Substring(0, t.Length - 1);
            cbo.AccessibleDescription = a;
        }

        /// <summary>
        /// Seleciona o indice pelo ID.
        /// </summary>
        /// <param name="cbo">Objeto ComboBox.</param>
        /// <param name="id">ID no formato string.</param>
        public static void setIndexById(System.Windows.Forms.ComboBox cbo, string id) {
            if (cbo.AccessibleDescription == null) return;
            if (string.IsNullOrEmpty(cbo.AccessibleDescription)) return;
            int index = 0;
            string[] ids = cbo.AccessibleDescription.Split(',');
            foreach (string item in ids) {
                if (item == id) break;
                index += 1; }
            if ((index > cbo.Items.Count - 1))
                index = cbo.Items.Count - 1;
            cbo.SelectedIndex = index;
        }

        /// <summary>
        /// Altera a aparência do ComboBox.
        /// </summary>
        /// <param name="cbo"></param>
        public static void SetStyle(System.Windows.Forms.ComboBox cbo) {
            cbo.BackColor = System.Drawing.Color.LightYellow;
            cbo.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbo.DropDownHeight = 120;
        }
    }
}
