using ControleCompraVenda.Dados;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCompraVenda.Dados
{
    /// <summary>
    /// Classe gerenciadora de botões.
    /// </summary>
    public class MButton
    {
        #region "Atributos da classe"
        private Button btn;
        private Panel botaoUp = new Panel();
        private Panel botaoDown = new Panel();
        private Control control;
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
        #endregion

        #region "Construtor"
        /// <summary>
        /// Construtor da classe. Faz com que o botão assuma a aparência da classe.
        /// </summary>
        /// <param name="btn">Nome da variável do botão.</param>
        public MButton(Button btn)
        {
            this.Model_button(btn);
        }

        /// <summary>
        /// Define as propriedades do botão.
        /// </summary>
        /// <param name="btn"></param>
        private void Model_button(Button btn)
        {
            this.btn = btn;
            this.control = btn.Parent;
            this._Top = btn.Location.X;
            this._Left = btn.Location.Y;
            this._Height = btn.Height;
            this._Width = btn.Width;
            this.currentColor = btn.ForeColor;
            this.ancor = btn.Anchor;

            btnDesign();
            setDefaultValues();
            setEvents();
        }

        /// <summary>
        /// Cria uma nova instância da classe de Model_Button.
        /// <param name="btn">Objeto Button.</param>
        /// <param name="click">Evento de click.</param>
        /// </summary>
        public MButton(Button btn, PassControl click)
        {
            this.Model_button(btn);
            this.Click = click;
        }

        /// <summary>
        /// Faz com que o botão assuma a aparência da classe Model_Button.
        /// </summary>
        /// <param name="btn">Nome da variável do botão.</param>
        public void setModel(Button btn)
        {
            this.btn = btn;
            this.control = btn.Parent;
            this._Top = btn.Location.X;
            this._Left = btn.Location.Y;
            this._Height = btn.Height;
            this._Width = btn.Width;
            this.currentColor = btn.ForeColor;
            this.ancor = btn.Anchor;

            btnDesign();
            setDefaultValues();
            setEvents();
        }
        private void btnDesign()
        {
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 207, 201);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(212, 207, 201);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btn.UseVisualStyleBackColor = false;
            btn.UseCompatibleTextRendering = false;
            btn.ForeColor = currentColor;
            btn.BackColor = Color.FromArgb(212, 207, 201);
            btn.Location = new Point(_Top + 2, _Left + 2);
            btn.Size = new Size(_Width - 5, _Height - 5);

            if (btn.Tag != null) {
                try {
                    new MToolTips<Button>(btn, btn.Tag.ToString()); }
                catch { } }
        }

        private void setDefaultValues()
        {
            this.botaoUp.BorderStyle = BorderStyle.None;
            this.botaoUp.BackColor = Color.FromArgb(212, 207, 201);
            this.botaoUp.ForeColor = SystemColors.ControlText;
            this.botaoUp.Location = new Point(_Top, _Left);
            this.botaoUp.Size = new Size(_Width, _Height);
            this.botaoUp.Font = new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
            this.botaoUp.Anchor = this.ancor;
            this.botaoUp.Visible = true;

            this.botaoDown.BorderStyle = BorderStyle.None;
            this.botaoDown.BackColor = Color.FromArgb(212, 207, 201);
            this.botaoDown.ForeColor = SystemColors.ControlText;
            this.botaoDown.Location = new Point(_Top, _Left);
            this.botaoDown.Size = new Size(_Width, _Height);
            this.botaoDown.Font = new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
            this.botaoDown.Anchor = this.ancor;
            this.botaoDown.Visible = true;

            this.control.Controls.Add(botaoUp);
            this.control.Controls.Add(botaoDown);
        }

        private void setEvents()
        {
            this.btn.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            this.btn.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            this.btn.EnabledChanged += new EventHandler(this.btn_EnabledChanged);
            this.btn.Click += new EventHandler(this.btn_Click);

            botaoUp.Paint += new PaintEventHandler(this.desenhaBotaoRegular);
            botaoUp.Refresh();
            botaoDown.Paint += new PaintEventHandler(this.desenhaBotaoClicado);
            botaoDown.Refresh();
        }
        #endregion

        #region "Eventos do botão"
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            btn.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            //botao_MouseDown(botao, e);            
            this.botaoUp.Visible = false;
        }
        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            btn.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.botaoUp.Visible = true;
        }

        /// <summary>
        /// Ocorre quando o estado de habilitado do botão é alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_EnabledChanged(object sender, EventArgs e)
        {
            if (btn.Enabled)
            {
                btn.ForeColor = currentColor;
                //btn.BackColor = Color.FromArgb(212, 207, 201);
                btn.BackColor = Color.FromArgb(212, 207, 201);
            }
            else
            {
                btn.ForeColor = Color.LightGray;
                btn.BackColor = SystemColors.ControlDark;
            }
        }
        private void btn_MouseHover(object sender, EventArgs e)
        {

        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            //btn.Paint += new PaintEventHandler(this.desenhaBotaoRegular);
            //btn.Refresh();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (this.Click == null) return;
            try { this.Click(); } catch { }
        }
        #endregion

        #region "Eventos do Panel"

        private void desenhaBotaoRegular(object sender, PaintEventArgs e)
        {
            Graphics g = botaoUp.CreateGraphics();
            Pen WhitePen = new Pen(Color.White, 2);
            Pen GrayPen = new Pen(Color.DarkGray, 2);
            Pen DarkGrayPen = new Pen(Color.FromArgb(105, 105, 105), 1);

            // Linha superior.
            g.DrawLine(WhitePen, 0, 0, botaoUp.Width, 1);
            g.DrawLine(GrayPen, 0, 0, botaoUp.Width, 0);
            // Linha esquerda.
            g.DrawLine(WhitePen, 0, 0, 1, botaoUp.Height);
            g.DrawLine(GrayPen, 0, 0, 0, botaoUp.Height);
            // Linha inferior.
            g.DrawLine(GrayPen, 1, botaoUp.Height - 3, botaoUp.Width, botaoUp.Height - 2);
            g.DrawLine(DarkGrayPen, 0, botaoUp.Height - 1, botaoUp.Width, botaoUp.Height - 1);
            // Linha direita.
            g.DrawLine(GrayPen, botaoUp.Width - 3, 0, botaoUp.Width - 2, botaoUp.Height - 2);
            g.DrawLine(DarkGrayPen, botaoUp.Width - 1, 0, botaoUp.Width - 1, botaoUp.Height);

            WhitePen.Dispose();
            GrayPen.Dispose();
            DarkGrayPen.Dispose();
            g.Dispose();
        }
        private void desenhaBotaoClicado(object sender, PaintEventArgs e)
        {
            Graphics g = botaoDown.CreateGraphics();
            Pen WhitePen = new Pen(Color.White, 2);
            Pen GrayPen = new Pen(Color.Gray, 2);
            Pen DarkGrayPen = new Pen(Color.DarkGray, 1);
            //Pen DarkGrayPen = new Pen(Color.FromArgb(105, 105, 105), 1);

            g.DrawLine(GrayPen, 0, 0, botaoDown.Width, 1); // Top            
            g.DrawLine(GrayPen, 0, 0, 1, botaoDown.Height); // Left
            g.DrawLine(WhitePen, 1, botaoDown.Height - 3, botaoDown.Width, botaoDown.Height - 2); // Botton
            g.DrawLine(DarkGrayPen, 0, botaoDown.Height - 1, botaoDown.Width, botaoDown.Height - 1); // Botton
            g.DrawLine(WhitePen, botaoDown.Width - 3, 0, botaoDown.Width - 2, botaoDown.Height - 2); // Right
            g.DrawLine(DarkGrayPen, botaoDown.Width - 1, 0, botaoDown.Width - 1, botaoDown.Height); // Right

            GrayPen.Dispose();
            WhitePen.Dispose();
            DarkGrayPen.Dispose();
            g.Dispose();
        }
        #endregion       
    }
}
