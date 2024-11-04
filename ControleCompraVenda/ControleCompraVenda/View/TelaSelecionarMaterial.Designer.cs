namespace ControleCompraVenda.View
{
    partial class TelaSelecionarMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_top = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.pn_bottom = new System.Windows.Forms.Panel();
            this.rb_codClie = new System.Windows.Forms.RadioButton();
            this.rb_cnpj = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rb_fantasia = new System.Windows.Forms.RadioButton();
            this.rb_razaoSocial = new System.Windows.Forms.RadioButton();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.pn_top.SuspendLayout();
            this.pn_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.Controls.Add(this.btnLimpar);
            this.pn_top.Controls.Add(this.label1);
            this.pn_top.Controls.Add(this.txt_find);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(655, 56);
            this.pn_top.TabIndex = 6;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(448, 20);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Informe parte do nome do material";
            // 
            // txt_find
            // 
            this.txt_find.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_find.Location = new System.Drawing.Point(12, 26);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(430, 20);
            this.txt_find.TabIndex = 0;
            // 
            // pn_bottom
            // 
            this.pn_bottom.Controls.Add(this.rb_codClie);
            this.pn_bottom.Controls.Add(this.rb_cnpj);
            this.pn_bottom.Controls.Add(this.btnCancel);
            this.pn_bottom.Controls.Add(this.btnOk);
            this.pn_bottom.Controls.Add(this.rb_fantasia);
            this.pn_bottom.Controls.Add(this.rb_razaoSocial);
            this.pn_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_bottom.Location = new System.Drawing.Point(0, 479);
            this.pn_bottom.Name = "pn_bottom";
            this.pn_bottom.Size = new System.Drawing.Size(655, 39);
            this.pn_bottom.TabIndex = 7;
            // 
            // rb_codClie
            // 
            this.rb_codClie.AutoSize = true;
            this.rb_codClie.Location = new System.Drawing.Point(298, 10);
            this.rb_codClie.Name = "rb_codClie";
            this.rb_codClie.Size = new System.Drawing.Size(58, 17);
            this.rb_codClie.TabIndex = 8;
            this.rb_codClie.TabStop = true;
            this.rb_codClie.Text = "Código";
            this.rb_codClie.UseVisualStyleBackColor = true;
            this.rb_codClie.Visible = false;
            // 
            // rb_cnpj
            // 
            this.rb_cnpj.AutoSize = true;
            this.rb_cnpj.Location = new System.Drawing.Point(231, 10);
            this.rb_cnpj.Name = "rb_cnpj";
            this.rb_cnpj.Size = new System.Drawing.Size(52, 17);
            this.rb_cnpj.TabIndex = 7;
            this.rb_cnpj.TabStop = true;
            this.rb_cnpj.Text = "CNPJ";
            this.rb_cnpj.UseVisualStyleBackColor = true;
            this.rb_cnpj.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(575, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(494, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // rb_fantasia
            // 
            this.rb_fantasia.AutoSize = true;
            this.rb_fantasia.Location = new System.Drawing.Point(120, 10);
            this.rb_fantasia.Name = "rb_fantasia";
            this.rb_fantasia.Size = new System.Drawing.Size(96, 17);
            this.rb_fantasia.TabIndex = 4;
            this.rb_fantasia.TabStop = true;
            this.rb_fantasia.Text = "Nome Fantasia";
            this.rb_fantasia.UseVisualStyleBackColor = true;
            this.rb_fantasia.Visible = false;
            // 
            // rb_razaoSocial
            // 
            this.rb_razaoSocial.AutoSize = true;
            this.rb_razaoSocial.Checked = true;
            this.rb_razaoSocial.Location = new System.Drawing.Point(12, 10);
            this.rb_razaoSocial.Name = "rb_razaoSocial";
            this.rb_razaoSocial.Size = new System.Drawing.Size(88, 17);
            this.rb_razaoSocial.TabIndex = 3;
            this.rb_razaoSocial.TabStop = true;
            this.rb_razaoSocial.Text = "Razão Social";
            this.rb_razaoSocial.UseVisualStyleBackColor = true;
            this.rb_razaoSocial.Visible = false;
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 56);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(655, 423);
            this.dgDados.TabIndex = 9;
            // 
            // TelaSelecionarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 518);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.pn_bottom);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "TelaSelecionarMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Procurar Material";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.pn_bottom.ResumeLayout(false);
            this.pn_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.Panel pn_bottom;
        private System.Windows.Forms.RadioButton rb_codClie;
        private System.Windows.Forms.RadioButton rb_cnpj;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rb_fantasia;
        private System.Windows.Forms.RadioButton rb_razaoSocial;
        private System.Windows.Forms.DataGridView dgDados;
    }
}