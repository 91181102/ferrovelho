namespace ControleCompraVenda.View
{
    partial class TelaEstoque
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelecionarProduto = new System.Windows.Forms.Button();
            this.txt_produto_nome = new System.Windows.Forms.TextBox();
            this.chk_f_cod_material = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.cbo_f_empresa = new System.Windows.Forms.ComboBox();
            this.chk_f_empresa = new System.Windows.Forms.CheckBox();
            this.chk_f_tipo_material = new System.Windows.Forms.CheckBox();
            this.cbo_f_tipo_material = new System.Windows.Forms.ComboBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_result_message = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.pb_exportar = new System.Windows.Forms.ProgressBar();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.pn_top.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_top.Controls.Add(this.btnExcel);
            this.pn_top.Controls.Add(this.btnCopiar);
            this.pn_top.Controls.Add(this.btnImprimir);
            this.pn_top.Controls.Add(this.label2);
            this.pn_top.Controls.Add(this.panel2);
            this.pn_top.Controls.Add(this.btnSair);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(758, 119);
            this.pn_top.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(538, 68);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 44);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Tag = "Abre visualizador do relatório.";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Filtros";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSelecionarProduto);
            this.panel2.Controls.Add(this.txt_produto_nome);
            this.panel2.Controls.Add(this.chk_f_cod_material);
            this.panel2.Controls.Add(this.btnAtualizar);
            this.panel2.Controls.Add(this.cbo_f_empresa);
            this.panel2.Controls.Add(this.chk_f_empresa);
            this.panel2.Controls.Add(this.chk_f_tipo_material);
            this.panel2.Controls.Add(this.cbo_f_tipo_material);
            this.panel2.Location = new System.Drawing.Point(7, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 97);
            this.panel2.TabIndex = 17;
            // 
            // btnSelecionarProduto
            // 
            this.btnSelecionarProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarProduto.Location = new System.Drawing.Point(74, 7);
            this.btnSelecionarProduto.Name = "btnSelecionarProduto";
            this.btnSelecionarProduto.Size = new System.Drawing.Size(29, 26);
            this.btnSelecionarProduto.TabIndex = 18;
            this.btnSelecionarProduto.Tag = "Clique para selecionar o material";
            this.btnSelecionarProduto.Text = "...";
            this.btnSelecionarProduto.UseVisualStyleBackColor = true;
            // 
            // txt_produto_nome
            // 
            this.txt_produto_nome.Location = new System.Drawing.Point(118, 9);
            this.txt_produto_nome.Name = "txt_produto_nome";
            this.txt_produto_nome.Size = new System.Drawing.Size(387, 20);
            this.txt_produto_nome.TabIndex = 17;
            // 
            // chk_f_cod_material
            // 
            this.chk_f_cod_material.AutoSize = true;
            this.chk_f_cod_material.Location = new System.Drawing.Point(10, 12);
            this.chk_f_cod_material.Name = "chk_f_cod_material";
            this.chk_f_cod_material.Size = new System.Drawing.Size(63, 17);
            this.chk_f_cod_material.TabIndex = 5;
            this.chk_f_cod_material.Text = "Material";
            this.chk_f_cod_material.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(399, 40);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(106, 50);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Tag = "Lista todos os movimentos.";
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // cbo_f_empresa
            // 
            this.cbo_f_empresa.FormattingEnabled = true;
            this.cbo_f_empresa.Location = new System.Drawing.Point(118, 69);
            this.cbo_f_empresa.Name = "cbo_f_empresa";
            this.cbo_f_empresa.Size = new System.Drawing.Size(200, 21);
            this.cbo_f_empresa.TabIndex = 16;
            this.cbo_f_empresa.Tag = "Selecione a empresa do estoque.";
            // 
            // chk_f_empresa
            // 
            this.chk_f_empresa.AutoSize = true;
            this.chk_f_empresa.Location = new System.Drawing.Point(10, 71);
            this.chk_f_empresa.Name = "chk_f_empresa";
            this.chk_f_empresa.Size = new System.Drawing.Size(67, 17);
            this.chk_f_empresa.TabIndex = 15;
            this.chk_f_empresa.Text = "Empresa";
            this.chk_f_empresa.UseVisualStyleBackColor = true;
            // 
            // chk_f_tipo_material
            // 
            this.chk_f_tipo_material.AutoSize = true;
            this.chk_f_tipo_material.Location = new System.Drawing.Point(10, 39);
            this.chk_f_tipo_material.Name = "chk_f_tipo_material";
            this.chk_f_tipo_material.Size = new System.Drawing.Size(102, 17);
            this.chk_f_tipo_material.TabIndex = 9;
            this.chk_f_tipo_material.Text = "Tipo de Material";
            this.chk_f_tipo_material.UseVisualStyleBackColor = true;
            // 
            // cbo_f_tipo_material
            // 
            this.cbo_f_tipo_material.FormattingEnabled = true;
            this.cbo_f_tipo_material.Location = new System.Drawing.Point(118, 37);
            this.cbo_f_tipo_material.Name = "cbo_f_tipo_material";
            this.cbo_f_tipo_material.Size = new System.Drawing.Size(200, 21);
            this.cbo_f_tipo_material.TabIndex = 11;
            this.cbo_f_tipo_material.Tag = "Selecione o tipo de material";
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(538, 15);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(93, 43);
            this.btnSair.TabIndex = 3;
            this.btnSair.Tag = "Encerra o módulo.";
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb_exportar);
            this.panel1.Controls.Add(this.lb_result_message);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 38);
            this.panel1.TabIndex = 2;
            // 
            // lb_result_message
            // 
            this.lb_result_message.AutoSize = true;
            this.lb_result_message.Location = new System.Drawing.Point(12, 16);
            this.lb_result_message.Name = "lb_result_message";
            this.lb_result_message.Size = new System.Drawing.Size(220, 13);
            this.lb_result_message.TabIndex = 1;
            this.lb_result_message.Text = "Clique em Atualizar para listar os movimentos.";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 119);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(758, 324);
            this.dgDados.TabIndex = 3;
            // 
            // pb_exportar
            // 
            this.pb_exportar.Location = new System.Drawing.Point(548, 11);
            this.pb_exportar.Name = "pb_exportar";
            this.pb_exportar.Size = new System.Drawing.Size(198, 15);
            this.pb_exportar.TabIndex = 22;
            this.pb_exportar.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(651, 83);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 26);
            this.btnExcel.TabIndex = 21;
            this.btnExcel.Tag = "Exporta o resultado para Excel.";
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(651, 56);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 26);
            this.btnCopiar.TabIndex = 20;
            this.btnCopiar.Tag = "Copia o resultado para a área de transferência.";
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            // 
            // TelaEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 481);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_top);
            this.Name = "TelaEstoque";
            this.Text = "TelaEstoque";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk_f_cod_material;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.ComboBox cbo_f_empresa;
        private System.Windows.Forms.CheckBox chk_f_empresa;
        private System.Windows.Forms.CheckBox chk_f_tipo_material;
        private System.Windows.Forms.ComboBox cbo_f_tipo_material;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Button btnSelecionarProduto;
        private System.Windows.Forms.TextBox txt_produto_nome;
        private System.Windows.Forms.Label lb_result_message;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.ProgressBar pb_exportar;
    }
}