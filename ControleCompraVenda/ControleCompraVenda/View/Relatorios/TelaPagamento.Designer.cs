namespace ControleCompraVenda.View
{
    partial class TelaPagamento
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
            this.chk_agrupar = new System.Windows.Forms.CheckBox();
            this.cbo_f_tp_oper = new System.Windows.Forms.ComboBox();
            this.chk_tp_oper = new System.Windows.Forms.CheckBox();
            this.chk_f_periodo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_f_data_de = new System.Windows.Forms.DateTimePicker();
            this.txt_f_data_ate = new System.Windows.Forms.DateTimePicker();
            this.btnSelecionarCliente = new System.Windows.Forms.Button();
            this.txt_f_cliente_nome = new System.Windows.Forms.TextBox();
            this.chk_f_cliente = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.cbo_f_empresa = new System.Windows.Forms.ComboBox();
            this.chk_f_empresa = new System.Windows.Forms.CheckBox();
            this.chk_f_tipo_pagamento = new System.Windows.Forms.CheckBox();
            this.cbo_f_tipo_pagamento = new System.Windows.Forms.ComboBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_saidas_vl_total = new System.Windows.Forms.TextBox();
            this.lb_result_message = new System.Windows.Forms.Label();
            this.txt_entradas_vl_total = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.pn_top.Controls.Add(this.pb_exportar);
            this.pn_top.Controls.Add(this.btnExcel);
            this.pn_top.Controls.Add(this.btnCopiar);
            this.pn_top.Controls.Add(this.btnImprimir);
            this.pn_top.Controls.Add(this.label2);
            this.pn_top.Controls.Add(this.panel2);
            this.pn_top.Controls.Add(this.btnSair);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(759, 144);
            this.pn_top.TabIndex = 3;
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
            this.panel2.Controls.Add(this.chk_agrupar);
            this.panel2.Controls.Add(this.cbo_f_tp_oper);
            this.panel2.Controls.Add(this.chk_tp_oper);
            this.panel2.Controls.Add(this.chk_f_periodo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_f_data_de);
            this.panel2.Controls.Add(this.txt_f_data_ate);
            this.panel2.Controls.Add(this.btnSelecionarCliente);
            this.panel2.Controls.Add(this.txt_f_cliente_nome);
            this.panel2.Controls.Add(this.chk_f_cliente);
            this.panel2.Controls.Add(this.btnAtualizar);
            this.panel2.Controls.Add(this.cbo_f_empresa);
            this.panel2.Controls.Add(this.chk_f_empresa);
            this.panel2.Controls.Add(this.chk_f_tipo_pagamento);
            this.panel2.Controls.Add(this.cbo_f_tipo_pagamento);
            this.panel2.Location = new System.Drawing.Point(7, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 118);
            this.panel2.TabIndex = 17;
            // 
            // chk_agrupar
            // 
            this.chk_agrupar.AutoSize = true;
            this.chk_agrupar.Location = new System.Drawing.Point(278, 66);
            this.chk_agrupar.Name = "chk_agrupar";
            this.chk_agrupar.Size = new System.Drawing.Size(83, 17);
            this.chk_agrupar.TabIndex = 29;
            this.chk_agrupar.Text = "Agrupar tipo";
            this.chk_agrupar.UseVisualStyleBackColor = true;
            // 
            // cbo_f_tp_oper
            // 
            this.cbo_f_tp_oper.FormattingEnabled = true;
            this.cbo_f_tp_oper.Location = new System.Drawing.Point(390, 34);
            this.cbo_f_tp_oper.Name = "cbo_f_tp_oper";
            this.cbo_f_tp_oper.Size = new System.Drawing.Size(115, 21);
            this.cbo_f_tp_oper.TabIndex = 27;
            // 
            // chk_tp_oper
            // 
            this.chk_tp_oper.AutoSize = true;
            this.chk_tp_oper.Location = new System.Drawing.Point(278, 36);
            this.chk_tp_oper.Name = "chk_tp_oper";
            this.chk_tp_oper.Size = new System.Drawing.Size(115, 17);
            this.chk_tp_oper.TabIndex = 26;
            this.chk_tp_oper.Text = "Tipo de Operação:";
            this.chk_tp_oper.UseVisualStyleBackColor = true;
            // 
            // chk_f_periodo
            // 
            this.chk_f_periodo.AutoSize = true;
            this.chk_f_periodo.Location = new System.Drawing.Point(11, 92);
            this.chk_f_periodo.Name = "chk_f_periodo";
            this.chk_f_periodo.Size = new System.Drawing.Size(64, 17);
            this.chk_f_periodo.TabIndex = 22;
            this.chk_f_periodo.Text = "Período";
            this.chk_f_periodo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "até";
            // 
            // txt_f_data_de
            // 
            this.txt_f_data_de.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_f_data_de.Location = new System.Drawing.Point(86, 89);
            this.txt_f_data_de.Name = "txt_f_data_de";
            this.txt_f_data_de.Size = new System.Drawing.Size(78, 20);
            this.txt_f_data_de.TabIndex = 24;
            // 
            // txt_f_data_ate
            // 
            this.txt_f_data_ate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_f_data_ate.Location = new System.Drawing.Point(194, 89);
            this.txt_f_data_ate.Name = "txt_f_data_ate";
            this.txt_f_data_ate.Size = new System.Drawing.Size(78, 20);
            this.txt_f_data_ate.TabIndex = 25;
            // 
            // btnSelecionarCliente
            // 
            this.btnSelecionarCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarCliente.Location = new System.Drawing.Point(73, 5);
            this.btnSelecionarCliente.Name = "btnSelecionarCliente";
            this.btnSelecionarCliente.Size = new System.Drawing.Size(29, 26);
            this.btnSelecionarCliente.TabIndex = 21;
            this.btnSelecionarCliente.Tag = "Clique para selecionar o material";
            this.btnSelecionarCliente.Text = "...";
            this.btnSelecionarCliente.UseVisualStyleBackColor = true;
            // 
            // txt_f_cliente_nome
            // 
            this.txt_f_cliente_nome.Location = new System.Drawing.Point(118, 7);
            this.txt_f_cliente_nome.Name = "txt_f_cliente_nome";
            this.txt_f_cliente_nome.Size = new System.Drawing.Size(387, 20);
            this.txt_f_cliente_nome.TabIndex = 20;
            // 
            // chk_f_cliente
            // 
            this.chk_f_cliente.AutoSize = true;
            this.chk_f_cliente.Location = new System.Drawing.Point(10, 10);
            this.chk_f_cliente.Name = "chk_f_cliente";
            this.chk_f_cliente.Size = new System.Drawing.Size(58, 17);
            this.chk_f_cliente.TabIndex = 19;
            this.chk_f_cliente.Text = "Cliente";
            this.chk_f_cliente.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(399, 61);
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
            this.cbo_f_empresa.Location = new System.Drawing.Point(83, 62);
            this.cbo_f_empresa.Name = "cbo_f_empresa";
            this.cbo_f_empresa.Size = new System.Drawing.Size(189, 21);
            this.cbo_f_empresa.TabIndex = 16;
            this.cbo_f_empresa.Tag = "Selecione a empresa do estoque.";
            // 
            // chk_f_empresa
            // 
            this.chk_f_empresa.AutoSize = true;
            this.chk_f_empresa.Location = new System.Drawing.Point(10, 64);
            this.chk_f_empresa.Name = "chk_f_empresa";
            this.chk_f_empresa.Size = new System.Drawing.Size(67, 17);
            this.chk_f_empresa.TabIndex = 15;
            this.chk_f_empresa.Text = "Empresa";
            this.chk_f_empresa.UseVisualStyleBackColor = true;
            // 
            // chk_f_tipo_pagamento
            // 
            this.chk_f_tipo_pagamento.AutoSize = true;
            this.chk_f_tipo_pagamento.Location = new System.Drawing.Point(10, 36);
            this.chk_f_tipo_pagamento.Name = "chk_f_tipo_pagamento";
            this.chk_f_tipo_pagamento.Size = new System.Drawing.Size(119, 17);
            this.chk_f_tipo_pagamento.TabIndex = 9;
            this.chk_f_tipo_pagamento.Text = "Tipo de Pagamento";
            this.chk_f_tipo_pagamento.UseVisualStyleBackColor = true;
            // 
            // cbo_f_tipo_pagamento
            // 
            this.cbo_f_tipo_pagamento.FormattingEnabled = true;
            this.cbo_f_tipo_pagamento.Location = new System.Drawing.Point(135, 34);
            this.cbo_f_tipo_pagamento.Name = "cbo_f_tipo_pagamento";
            this.cbo_f_tipo_pagamento.Size = new System.Drawing.Size(137, 21);
            this.cbo_f_tipo_pagamento.TabIndex = 11;
            this.cbo_f_tipo_pagamento.Tag = "Selecione o tipo de material";
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
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_saidas_vl_total);
            this.panel1.Controls.Add(this.lb_result_message);
            this.panel1.Controls.Add(this.txt_entradas_vl_total);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 32);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Saídas R$";
            // 
            // txt_saidas_vl_total
            // 
            this.txt_saidas_vl_total.BackColor = System.Drawing.Color.Navy;
            this.txt_saidas_vl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_saidas_vl_total.ForeColor = System.Drawing.Color.White;
            this.txt_saidas_vl_total.Location = new System.Drawing.Point(330, 6);
            this.txt_saidas_vl_total.Name = "txt_saidas_vl_total";
            this.txt_saidas_vl_total.ReadOnly = true;
            this.txt_saidas_vl_total.Size = new System.Drawing.Size(100, 20);
            this.txt_saidas_vl_total.TabIndex = 3;
            this.txt_saidas_vl_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_result_message
            // 
            this.lb_result_message.AutoSize = true;
            this.lb_result_message.Location = new System.Drawing.Point(12, 8);
            this.lb_result_message.Name = "lb_result_message";
            this.lb_result_message.Size = new System.Drawing.Size(220, 13);
            this.lb_result_message.TabIndex = 1;
            this.lb_result_message.Text = "Clique em Atualizar para listar os movimentos.";
            // 
            // txt_entradas_vl_total
            // 
            this.txt_entradas_vl_total.BackColor = System.Drawing.Color.Navy;
            this.txt_entradas_vl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_entradas_vl_total.ForeColor = System.Drawing.Color.White;
            this.txt_entradas_vl_total.Location = new System.Drawing.Point(508, 6);
            this.txt_entradas_vl_total.Name = "txt_entradas_vl_total";
            this.txt_entradas_vl_total.ReadOnly = true;
            this.txt_entradas_vl_total.Size = new System.Drawing.Size(100, 20);
            this.txt_entradas_vl_total.TabIndex = 1;
            this.txt_entradas_vl_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Entradas R$";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 144);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(759, 232);
            this.dgDados.TabIndex = 5;
            // 
            // pb_exportar
            // 
            this.pb_exportar.Location = new System.Drawing.Point(538, 119);
            this.pb_exportar.Name = "pb_exportar";
            this.pb_exportar.Size = new System.Drawing.Size(198, 15);
            this.pb_exportar.TabIndex = 28;
            this.pb_exportar.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(659, 86);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 26);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.Tag = "Exporta o resultado para Excel.";
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(659, 59);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 26);
            this.btnCopiar.TabIndex = 26;
            this.btnCopiar.Tag = "Copia o resultado para a área de transferência.";
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            // 
            // TelaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 408);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_top);
            this.Name = "TelaPagamento";
            this.Text = "TelaPagamento";
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
        private System.Windows.Forms.ComboBox cbo_f_tp_oper;
        private System.Windows.Forms.CheckBox chk_tp_oper;
        private System.Windows.Forms.CheckBox chk_f_periodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txt_f_data_de;
        private System.Windows.Forms.DateTimePicker txt_f_data_ate;
        private System.Windows.Forms.Button btnSelecionarCliente;
        private System.Windows.Forms.TextBox txt_f_cliente_nome;
        private System.Windows.Forms.CheckBox chk_f_cliente;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.ComboBox cbo_f_empresa;
        private System.Windows.Forms.CheckBox chk_f_empresa;
        private System.Windows.Forms.CheckBox chk_f_tipo_pagamento;
        private System.Windows.Forms.ComboBox cbo_f_tipo_pagamento;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_result_message;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.TextBox txt_entradas_vl_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_agrupar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_saidas_vl_total;
        private System.Windows.Forms.ProgressBar pb_exportar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCopiar;
    }
}