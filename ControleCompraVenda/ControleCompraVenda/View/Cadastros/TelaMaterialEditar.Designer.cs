namespace ControleCompraVenda.View
{
    partial class TelaMaterialEditar
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
            this.chk_ativo = new System.Windows.Forms.CheckBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_tipo_material = new System.Windows.Forms.ComboBox();
            this.txt_preco_compra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_preco_venda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chk_ativo
            // 
            this.chk_ativo.AutoSize = true;
            this.chk_ativo.Checked = true;
            this.chk_ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ativo.Location = new System.Drawing.Point(412, 33);
            this.chk_ativo.Name = "chk_ativo";
            this.chk_ativo.Size = new System.Drawing.Size(50, 17);
            this.chk_ativo.TabIndex = 23;
            this.chk_ativo.Text = "Ativo";
            this.chk_ativo.UseVisualStyleBackColor = true;
            // 
            // txt_nome
            // 
            this.txt_nome.BackColor = System.Drawing.SystemColors.Info;
            this.txt_nome.Location = new System.Drawing.Point(83, 33);
            this.txt_nome.MaxLength = 30;
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(323, 20);
            this.txt_nome.TabIndex = 13;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(12, 33);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(65, 20);
            this.txt_id.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(387, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Tag = "Cancela a operação";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(94, 131);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 28);
            this.btnExcluir.TabIndex = 25;
            this.btnExcluir.Tag = "Exclui o cadastro.";
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(13, 131);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 28);
            this.btnSalvar.TabIndex = 24;
            this.btnSalvar.Tag = "Salva as alterações.";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tipo de Material:";
            // 
            // cbo_tipo_material
            // 
            this.cbo_tipo_material.FormattingEnabled = true;
            this.cbo_tipo_material.Location = new System.Drawing.Point(15, 85);
            this.cbo_tipo_material.Name = "cbo_tipo_material";
            this.cbo_tipo_material.Size = new System.Drawing.Size(187, 21);
            this.cbo_tipo_material.TabIndex = 15;
            // 
            // txt_preco_compra
            // 
            this.txt_preco_compra.BackColor = System.Drawing.SystemColors.Info;
            this.txt_preco_compra.Location = new System.Drawing.Point(208, 85);
            this.txt_preco_compra.MaxLength = 30;
            this.txt_preco_compra.Name = "txt_preco_compra";
            this.txt_preco_compra.Size = new System.Drawing.Size(124, 20);
            this.txt_preco_compra.TabIndex = 16;
            this.txt_preco_compra.Tag = "Informe o preço que será usado para compra.";
            this.txt_preco_compra.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Preço de Compra (R$)";
            // 
            // txt_preco_venda
            // 
            this.txt_preco_venda.BackColor = System.Drawing.SystemColors.Info;
            this.txt_preco_venda.Location = new System.Drawing.Point(338, 85);
            this.txt_preco_venda.MaxLength = 30;
            this.txt_preco_venda.Name = "txt_preco_venda";
            this.txt_preco_venda.Size = new System.Drawing.Size(124, 20);
            this.txt_preco_venda.TabIndex = 17;
            this.txt_preco_venda.Tag = "Informe o preço que será usado para venda.";
            this.txt_preco_venda.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Preço de Venda (R$)";
            // 
            // TelaMaterialEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 169);
            this.Controls.Add(this.txt_preco_venda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_preco_compra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_tipo_material);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.chk_ativo);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaMaterialEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Material";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_ativo;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_tipo_material;
        private System.Windows.Forms.TextBox txt_preco_compra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_preco_venda;
        private System.Windows.Forms.Label label5;
    }
}