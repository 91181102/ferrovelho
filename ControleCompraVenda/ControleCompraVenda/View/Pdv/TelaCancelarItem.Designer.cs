namespace ControleCompraVenda.View
{
    partial class TelaCancelarItem
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
            this.pn_user_cancel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.btnAdmOk = new System.Windows.Forms.Button();
            this.cbo_usuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.btnAdmCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pn_top.SuspendLayout();
            this.pn_user_cancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.Controls.Add(this.btnCancelar);
            this.pn_top.Controls.Add(this.btnOk);
            this.pn_top.Controls.Add(this.label2);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(432, 56);
            this.pn_top.TabIndex = 0;
            // 
            // pn_user_cancel
            // 
            this.pn_user_cancel.BackColor = System.Drawing.Color.Khaki;
            this.pn_user_cancel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_user_cancel.Controls.Add(this.label5);
            this.pn_user_cancel.Controls.Add(this.label4);
            this.pn_user_cancel.Controls.Add(this.btnAdmCancelar);
            this.pn_user_cancel.Controls.Add(this.txt_senha);
            this.pn_user_cancel.Controls.Add(this.label3);
            this.pn_user_cancel.Controls.Add(this.cbo_usuario);
            this.pn_user_cancel.Controls.Add(this.btnAdmOk);
            this.pn_user_cancel.Controls.Add(this.label1);
            this.pn_user_cancel.Location = new System.Drawing.Point(57, 91);
            this.pn_user_cancel.Name = "pn_user_cancel";
            this.pn_user_cancel.Size = new System.Drawing.Size(317, 156);
            this.pn_user_cancel.TabIndex = 1;
            this.pn_user_cancel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário sem permissão para cancelar item.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecione o item e click OK.";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 56);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(432, 240);
            this.dgDados.TabIndex = 2;
            // 
            // btnAdmOk
            // 
            this.btnAdmOk.Location = new System.Drawing.Point(227, 108);
            this.btnAdmOk.Name = "btnAdmOk";
            this.btnAdmOk.Size = new System.Drawing.Size(83, 38);
            this.btnAdmOk.TabIndex = 1;
            this.btnAdmOk.Text = "Ok";
            this.btnAdmOk.UseVisualStyleBackColor = true;
            // 
            // cbo_usuario
            // 
            this.cbo_usuario.FormattingEnabled = true;
            this.cbo_usuario.Location = new System.Drawing.Point(16, 60);
            this.cbo_usuario.Name = "cbo_usuario";
            this.cbo_usuario.Size = new System.Drawing.Size(205, 21);
            this.cbo_usuario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Peça ao administrador para inserir as credenciais.";
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(16, 108);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(177, 20);
            this.txt_senha.TabIndex = 4;
            // 
            // btnAdmCancelar
            // 
            this.btnAdmCancelar.Location = new System.Drawing.Point(227, 64);
            this.btnAdmCancelar.Name = "btnAdmCancelar";
            this.btnAdmCancelar.Size = new System.Drawing.Size(83, 38);
            this.btnAdmCancelar.TabIndex = 5;
            this.btnAdmCancelar.Text = "Cancelar";
            this.btnAdmCancelar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Senha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Usuário";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(337, 9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 38);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(248, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 38);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCancelarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 296);
            this.Controls.Add(this.pn_user_cancel);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.pn_top);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCancelarItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cancelar Item";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.pn_user_cancel.ResumeLayout(false);
            this.pn_user_cancel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pn_user_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdmOk;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdmCancelar;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_usuario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
    }
}