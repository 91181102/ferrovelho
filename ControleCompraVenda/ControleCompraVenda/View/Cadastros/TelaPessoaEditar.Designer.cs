namespace ControleCompraVenda.View
{
    partial class TelaPessoaEditar
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
            this.txt_endereco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cnpj_cpf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.chk_ativo = new System.Windows.Forms.CheckBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_obs = new System.Windows.Forms.TextBox();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pn_controls = new System.Windows.Forms.Panel();
            this.btnCancelarContato = new System.Windows.Forms.Button();
            this.cbo_tipo = new System.Windows.Forms.ComboBox();
            this.btnExcluirContato = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalvarContato = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_contato_obs = new System.Windows.Forms.TextBox();
            this.txt_contato = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNovoContato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.panel1.SuspendLayout();
            this.pn_controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_endereco
            // 
            this.txt_endereco.BackColor = System.Drawing.SystemColors.Info;
            this.txt_endereco.Location = new System.Drawing.Point(12, 85);
            this.txt_endereco.MaxLength = 150;
            this.txt_endereco.Name = "txt_endereco";
            this.txt_endereco.Size = new System.Drawing.Size(431, 20);
            this.txt_endereco.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Observação:";
            // 
            // txt_cnpj_cpf
            // 
            this.txt_cnpj_cpf.BackColor = System.Drawing.SystemColors.Info;
            this.txt_cnpj_cpf.Location = new System.Drawing.Point(337, 46);
            this.txt_cnpj_cpf.MaxLength = 14;
            this.txt_cnpj_cpf.Name = "txt_cnpj_cpf";
            this.txt_cnpj_cpf.Size = new System.Drawing.Size(106, 20);
            this.txt_cnpj_cpf.TabIndex = 28;
            this.txt_cnpj_cpf.Tag = "Informe apenas números.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "CPF/CNPJ:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(368, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Tag = "Cancela a operação";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(90, 394);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 28);
            this.btnExcluir.TabIndex = 31;
            this.btnExcluir.Tag = "Exclui o cadastro.";
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(9, 394);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 28);
            this.btnSalvar.TabIndex = 30;
            this.btnSalvar.Tag = "Salva as alterações.";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // chk_ativo
            // 
            this.chk_ativo.AutoSize = true;
            this.chk_ativo.Location = new System.Drawing.Point(271, 11);
            this.chk_ativo.Name = "chk_ativo";
            this.chk_ativo.Size = new System.Drawing.Size(50, 17);
            this.chk_ativo.TabIndex = 31;
            this.chk_ativo.Text = "Ativo";
            this.chk_ativo.UseVisualStyleBackColor = true;
            // 
            // txt_nome
            // 
            this.txt_nome.BackColor = System.Drawing.SystemColors.Info;
            this.txt_nome.Location = new System.Drawing.Point(12, 46);
            this.txt_nome.MaxLength = 100;
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(319, 20);
            this.txt_nome.TabIndex = 27;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(33, 8);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(65, 20);
            this.txt_id.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            // 
            // txt_obs
            // 
            this.txt_obs.BackColor = System.Drawing.SystemColors.Info;
            this.txt_obs.Location = new System.Drawing.Point(12, 126);
            this.txt_obs.MaxLength = 100;
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.Size = new System.Drawing.Size(431, 20);
            this.txt_obs.TabIndex = 30;
            // 
            // dgDados
            // 
            this.dgDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDados.Location = new System.Drawing.Point(0, 83);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(433, 115);
            this.dgDados.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pn_controls);
            this.panel1.Controls.Add(this.dgDados);
            this.panel1.Location = new System.Drawing.Point(9, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 202);
            this.panel1.TabIndex = 41;
            // 
            // pn_controls
            // 
            this.pn_controls.Controls.Add(this.btnCancelarContato);
            this.pn_controls.Controls.Add(this.cbo_tipo);
            this.pn_controls.Controls.Add(this.btnExcluirContato);
            this.pn_controls.Controls.Add(this.label7);
            this.pn_controls.Controls.Add(this.btnSalvarContato);
            this.pn_controls.Controls.Add(this.label8);
            this.pn_controls.Controls.Add(this.txt_contato_obs);
            this.pn_controls.Controls.Add(this.txt_contato);
            this.pn_controls.Controls.Add(this.label9);
            this.pn_controls.Location = new System.Drawing.Point(0, 2);
            this.pn_controls.Name = "pn_controls";
            this.pn_controls.Size = new System.Drawing.Size(433, 77);
            this.pn_controls.TabIndex = 44;
            // 
            // btnCancelarContato
            // 
            this.btnCancelarContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarContato.Location = new System.Drawing.Point(399, 46);
            this.btnCancelarContato.Name = "btnCancelarContato";
            this.btnCancelarContato.Size = new System.Drawing.Size(31, 28);
            this.btnCancelarContato.TabIndex = 49;
            this.btnCancelarContato.Tag = "Cancela operação de editar contato.";
            this.btnCancelarContato.Text = "C";
            this.btnCancelarContato.UseVisualStyleBackColor = true;
            // 
            // cbo_tipo
            // 
            this.cbo_tipo.FormattingEnabled = true;
            this.cbo_tipo.Location = new System.Drawing.Point(7, 19);
            this.cbo_tipo.Name = "cbo_tipo";
            this.cbo_tipo.Size = new System.Drawing.Size(107, 21);
            this.cbo_tipo.TabIndex = 42;
            // 
            // btnExcluirContato
            // 
            this.btnExcluirContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirContato.Location = new System.Drawing.Point(368, 46);
            this.btnExcluirContato.Name = "btnExcluirContato";
            this.btnExcluirContato.Size = new System.Drawing.Size(31, 28);
            this.btnExcluirContato.TabIndex = 48;
            this.btnExcluirContato.Tag = "Remove o contato.";
            this.btnExcluirContato.Text = "-";
            this.btnExcluirContato.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tipo:";
            // 
            // btnSalvarContato
            // 
            this.btnSalvarContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarContato.Location = new System.Drawing.Point(336, 46);
            this.btnSalvarContato.Name = "btnSalvarContato";
            this.btnSalvarContato.Size = new System.Drawing.Size(31, 28);
            this.btnSalvarContato.TabIndex = 47;
            this.btnSalvarContato.Tag = "Salva o contato.";
            this.btnSalvarContato.Text = "+";
            this.btnSalvarContato.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Contato:";
            // 
            // txt_contato_obs
            // 
            this.txt_contato_obs.BackColor = System.Drawing.SystemColors.Info;
            this.txt_contato_obs.Location = new System.Drawing.Point(48, 51);
            this.txt_contato_obs.MaxLength = 100;
            this.txt_contato_obs.Name = "txt_contato_obs";
            this.txt_contato_obs.Size = new System.Drawing.Size(283, 20);
            this.txt_contato_obs.TabIndex = 46;
            // 
            // txt_contato
            // 
            this.txt_contato.BackColor = System.Drawing.SystemColors.Info;
            this.txt_contato.Location = new System.Drawing.Point(119, 20);
            this.txt_contato.MaxLength = 100;
            this.txt_contato.Name = "txt_contato";
            this.txt_contato.Size = new System.Drawing.Size(312, 20);
            this.txt_contato.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Obs.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Contatos:";
            // 
            // btnNovoContato
            // 
            this.btnNovoContato.Location = new System.Drawing.Point(321, 152);
            this.btnNovoContato.Name = "btnNovoContato";
            this.btnNovoContato.Size = new System.Drawing.Size(125, 28);
            this.btnNovoContato.TabIndex = 43;
            this.btnNovoContato.Tag = "Cria um novo contato para o cliente.";
            this.btnNovoContato.Text = "Novo contato";
            this.btnNovoContato.UseVisualStyleBackColor = true;
            // 
            // TelaPessoaEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNovoContato);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_obs);
            this.Controls.Add(this.txt_endereco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_cnpj_cpf);
            this.Controls.Add(this.label4);
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
            this.Name = "TelaPessoaEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Pessoa";
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pn_controls.ResumeLayout(false);
            this.pn_controls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_endereco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cnpj_cpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.CheckBox chk_ativo;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_obs;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExcluirContato;
        private System.Windows.Forms.Button btnSalvarContato;
        private System.Windows.Forms.TextBox txt_contato_obs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_contato;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo_tipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNovoContato;
        private System.Windows.Forms.Button btnCancelarContato;
        private System.Windows.Forms.Panel pn_controls;
    }
}