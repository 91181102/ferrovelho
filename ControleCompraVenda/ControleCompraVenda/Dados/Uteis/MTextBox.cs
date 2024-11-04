using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    public class MTextBox
    {
        #region: Atributos da classe
        private TextBox txt;
        private Control control;
        private Panel pn = new Panel();
        private int _Top = 0;
        private int _Left = 0;
        private int _Height = 0;
        private int _Width = 0;
        private Color currentColor;
        private AnchorStyles ancor = new AnchorStyles();
        /// <summary>
        /// Objeto para guardar métodos de outras classes.
        /// </summary>
        public delegate void PassControl();
        /// <summary>
        /// Obtém ou define o evento de clique do botão.
        /// </summary>
        public PassControl Click;
        /// <summary>
        /// Obtém ou define o evento de perder o foco no controle.
        /// </summary>
        public PassControl Leave;
        /// <summary>
        /// Obtém ou define o evento de pressionar ENTER.
        /// </summary>
        public PassControl KeyEnter;
        /// <summary>
        /// OBtém ou define o evento de KEYDOWN.
        /// </summary>
        public PassControl KeyDown;
        //private bool numericOnly = false;
        //private bool decimalOnly = false;
        #region: Getters e setters
        /// <summary>
        /// Obtém ou define se o controle está habilitado.
        /// </summary>
        public bool Enabled
        {
            get { return this.txt.Enabled; }
            set { this.txt.Enabled = value; }
        }
        /// <summary>
        /// Obtém ou define a cor de fundo.
        /// </summary>
        public Color BackColor
        {
            get { return this.txt.BackColor; }
            set { this.txt.BackColor = value; }
        }

        /// <summary>
        /// Obtém ou define o atributo Text.
        /// </summary>
        public string Text
        {
            get { return this.txt.Text; }
            set { this.txt.Text = value; }
        }

        /// <summary>
        /// Obtém ou define um valor booleano.
        /// </summary>
        public bool CausesValidation
        {
            get { return this.txt.CausesValidation; }
            set { this.txt.CausesValidation = value; }
        }

        /// <summary>
        /// Obtém ou define o campo AccessibleDescription.
        /// </summary>
        public string AccessibleDescription
        {
            get { return this.txt.AccessibleDescription; }
            set { this.AccessibleDescription = value; }
        }
        #endregion
        #endregion

        #region: Construtor
        /// <summary>
        /// Cria uma nova instância da classe MTextBox.
        /// </summary>
        /// <param name="txt"></param>
        public MTextBox(TextBox txt)
        {
            this.txt = txt;
            this.SetModel(txt);
        }
        public MTextBox() {

        }

        /// <summary>
        /// Cria uma nova instância da classe MTextBox.
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="KeyEnter"></param>
        public MTextBox(TextBox txt, PassControl KeyEnter)
        {
            this.txt = txt;
            this.KeyEnter = KeyEnter;
            this.SetModel(txt);
        }

        /// <summary>
        /// Cria uma nova instância da classe MTextBox.
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="KeyEnter"></param>
        /// <param name="KeyDown"></param>
        public MTextBox(TextBox txt, PassControl KeyEnter, PassControl KeyDown)
        {
            this.txt = txt;
            this.KeyEnter = KeyEnter;
            this.KeyDown = KeyDown;
            this.SetModel(txt);
        }

        /// <summary>
        /// Cria uma nova instância da classe MTextBox.
        /// </summary>
        /// <param name="txt">Texbox</param>
        /// <param name="KeyEnter">Evento de pressionar Enter.</param>
        /// <param name="KeyDown">Evento de pressionar teclas.</param>
        /// <param name="Leave">Evento de perder foco no controle.</param>
        public MTextBox(TextBox txt, PassControl KeyEnter, PassControl KeyDown, PassControl Leave)
        {
            this.txt = txt;
            this.KeyEnter = KeyEnter;
            this.KeyDown = KeyDown;
            this.Leave = Leave;
            this.SetModel(txt);
        }

        /// <summary>
        /// Cria uma nova instância da classe MTextBox.
        /// </summary>
        /// <param name="txt">Objeto TextBox.</param>
        /// <param name="t">Tipo numérico: NumType.Numeric ou NumType.Decimal</param>
        public MTextBox(TextBox txt, NumType t)
        {
            this.txt = txt;
            this.SetModel(txt);
            if (t == NumType.Numeric) setOnlyNumeric();
            if (t == NumType.Decimal) setOnlyDecimal();
        }
        
        /// <summary>
        /// Define o evento de KeyPress Decimal.
        /// </summary>
        /// <param name="txt"></param>
        public static void SetDecimal(TextBox txt) {
            var t = new MTextBox();
            txt.KeyPress += new KeyPressEventHandler(t.val_decimal);
            txt.Leave += new EventHandler(t.txt_Leave);
            if (txt.Tag != null) {
                try {
                    new MToolTips<TextBox>(txt, txt.Tag.ToString()); }
                catch { } }
        }

        /// <summary>
        /// Define o evento de KeyPress Numerico.
        /// </summary>
        /// <param name="txt"></param>
        public static void SetNumeric(TextBox txt) {
            var t = new MTextBox();
            txt.KeyPress += new KeyPressEventHandler(t.val_numeric);
            txt.Leave += new EventHandler(t.txt_Leave);
            if (txt.Tag != null) {
                try {
                    new MToolTips<TextBox>(txt, txt.Tag.ToString()); }
                catch { } }
        }
        #endregion

        #region: Operações
        /// <summary>
        /// Limpa o texto.
        /// </summary>
        public void Clear()
        {
            this.txt.Clear();
        }

        /// <summary>
        /// Altera o foco para o controle.
        /// </summary>
        public void Focus()
        {
            this.txt.Focus();
        }
        private void setEvents()
        {
            this.txt.KeyDown += new KeyEventHandler(this.txt_KeyDown);
            this.txt.Leave += new EventHandler(this.txt_Leave);
        }

        /// <summary>
        /// Define que o textbox aceite simbolos decimais.
        /// </summary>
        public void setOnlyDecimal()
        {
            this.txt.KeyPress += new KeyPressEventHandler(this.val_decimal);
        }

        /// <summary>
        /// Define que o textbox aceite somente números.
        /// </summary>
        public void setOnlyNumeric()
        {
            this.txt.KeyPress += new KeyPressEventHandler(this.val_numeric);
        }

        /// <summary>
        /// Define as propriedades do botão.
        /// </summary>
        /// <param name="btn"></param>
        private void SetModel(TextBox txt) {
            this.control = txt.Parent;
            this._Top = txt.Location.X;
            this._Left = txt.Location.Y;
            this._Height = txt.Height;
            this._Width = txt.Width;
            this.currentColor = txt.BackColor;
            this.ancor = txt.Anchor;

            this.txt.BorderStyle = BorderStyle.None;
            this.txt.Margin = new Padding(3, 4, 3, 4);
            this.txt.Location = new Point(_Top + 2, _Left + 2);
            this.txt.Size = new Size(_Width - 4, _Height);

            if (txt.Tag != null) {
                try {
                    new MToolTips<TextBox>(txt, txt.Tag.ToString()); }
                catch { } }

            if (this.txt.ReadOnly)
                this.SetReadOnly();

            this.SetBack();
        }

        private void SetBack()
        {
            this.pn.BorderStyle = BorderStyle.Fixed3D;
            this.pn.Location = new Point(_Top, _Left);
            if (txt.Multiline)
            {
                this.pn.Size = new Size(_Width, _Height + 4);
            }
            else
            {
                //this.pn.Size = new Size(_Width, _Height - 3);
                this.txt.Size = new Size(_Width - 6, _Height - 3);
                this.txt.Location = new Point(pn.Location.X + 4, pn.Location.Y + 3);
                this.pn.Size = new Size(_Width, _Height);
            }

            this.pn.Anchor = this.ancor;
            this.pn.Visible = true;

            this.control.Controls.Add(pn);
        }

        /// <summary>
        /// Define somente leitura.
        /// </summary>
        public void SetReadOnly()
        {
            this.txt.BackColor = Color.LightYellow;
            this.txt.ReadOnly = true;
        }

        /// <summary>
        /// Define o estado de edição.
        /// </summary>
        /// <param name="value">true ou false</param>
        public void SetEditMode(bool value)
        {
            if (value)
            {
                this.txt.BackColor = Color.LightCyan;
                this.txt.ReadOnly = false;
            }
            else
            {
                this.SetReadOnly();
            }
        }
        #endregion

        #region: Eventos
        private void txt_KeyDown(object sender, KeyEventArgs e) {
            if (KeyEnter == null) return;

            if (e.KeyCode == Keys.Enter) {
                this.KeyEnter();
                return; }
            if (KeyDown != null)
                this.KeyDown();
        }
        private void txt_Leave(object sender, EventArgs e) {
            if (Leave == null) return;
            this.Leave();
        }

        private void check_numeric()
        {
            decimal value = 0;
            if (Decimal.TryParse(txt.Text, out value))
            {
                this.txt.Text = "0";
            }
        }

        private void val_decimal(object sender, KeyPressEventArgs e)
        {
            char[] lista = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', (char)Keys.Back };

            string text = string.Empty;

            text = ((TextBox)sender).Text;

            // Aceita 0-9, backspace e decimal
            if (!(lista.Contains(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            // Checa para ter certeza que somente um decimal seja aceito.
            if ((e.KeyChar == ','))
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

            if ((text.Length > 0))
            {
                if ((text.Substring(0, 1) == ","))
                    text = text.Replace(",", "0,");
            }
        }

        private void val_numeric(object sender, KeyPressEventArgs e)
        {
            char[] lista = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', (char)Keys.Back };
            if (!(lista.Contains(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region: Obter valores
        /// <summary>
        /// Obtém o valor String.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return this.txt.Text;
        }

        /// <summary>
        /// Obtém o valor Int.
        /// </summary>
        /// <returns></returns>
        public int GetInt()
        {
            decimal value = 0;
            if (!Decimal.TryParse(txt.Text, out value))
            {
                this.txt.Text = "0";
                return 0;
            }
            return Convert.ToInt32(this.txt.Text);
        }

        /// <summary>
        /// Obtém o valor decimal.
        /// </summary>
        /// <returns></returns>
        public decimal GetDecimal()
        {
            decimal value = 0;
            if (!Decimal.TryParse(txt.Text, out value))
            {
                this.txt.Text = "0";
                return 0;
            }
            return Convert.ToDecimal(this.txt.Text);
        }

        /// <summary>
        /// Obtém o valor inteiro de um TextBox.
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>Retorna um int.</returns>
        public static int GetInt(TextBox txt) {
            decimal value = 0;
            if (!Decimal.TryParse(txt.Text, out value)) {
                return 0; }
            return Convert.ToInt32(txt.Text);
        }

        /// <summary>
        /// Obtém o valor decimal de um TextBox.
        /// </summary>
        /// <param name="txt">TextBox</param>
        /// <returns>Retorna um decimal.</returns>
        public static decimal GetDecimal(TextBox txt) {
            decimal value = 0;
            if (!Decimal.TryParse(txt.Text, out value)) {
                return 0; }
            return Convert.ToDecimal(txt.Text);
        }
        #endregion
    }

    /// <summary>
    /// Define o tipo numérico do TextBox.
    /// </summary>
    public enum NumType
    {
        /// <summary>
        /// Faz com que o TextBox aceite somente números.
        /// </summary>
        Numeric = 0,
        /// <summary>
        /// Faz com que o TextBox aceite números, vírgula e ponto.
        /// </summary>
        Decimal = 1
    }
}



