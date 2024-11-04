namespace ControleCompraVenda.View
{
    partial class TelaMovimentacao
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
            this.chk_f_periodo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.cbo_f_empresa = new System.Windows.Forms.ComboBox();
            this.chk_f_empresa = new System.Windows.Forms.CheckBox();
            this.txt_f_data_de = new System.Windows.Forms.DateTimePicker();
            this.txt_f_data_ate = new System.Windows.Forms.DateTimePicker();
            this.cbo_f_tp_oper = new System.Windows.Forms.ComboBox();
            this.chk_f_sit_pagamento = new System.Windows.Forms.CheckBox();
            this.chk_tp_oper = new System.Windows.Forms.CheckBox();
            this.chk_f_sit_pedido = new System.Windows.Forms.CheckBox();
            this.cbo_f_sit_ped = new System.Windows.Forms.ComboBox();
            this.cbo_f_sit_pag = new System.Windows.Forms.ComboBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_compras_desconto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_compras_qtd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_compras_vl_aberto = new System.Windows.Forms.TextBox();
            this.txt_compras_vl_total = new System.Windows.Forms.TextBox();
            this.txt_compras_vl_pago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_vendas_desconto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_vendas_qtd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_vendas_vl_aberto = new System.Windows.Forms.TextBox();
            this.txt_vendas_vl_total = new System.Windows.Forms.TextBox();
            this.txt_vendas_vl_pago = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_result_message = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.pb_exportar = new System.Windows.Forms.ProgressBar();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.pn_top.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.pn_top.Size = new System.Drawing.Size(728, 135);
            this.pn_top.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(538, 80);
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
            this.panel2.Controls.Add(this.chk_f_periodo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnAtualizar);
            this.panel2.Controls.Add(this.cbo_f_empresa);
            this.panel2.Controls.Add(this.chk_f_empresa);
            this.panel2.Controls.Add(this.txt_f_data_de);
            this.panel2.Controls.Add(this.txt_f_data_ate);
            this.panel2.Controls.Add(this.cbo_f_tp_oper);
            this.panel2.Controls.Add(this.chk_f_sit_pagamento);
            this.panel2.Controls.Add(this.chk_tp_oper);
            this.panel2.Controls.Add(this.chk_f_sit_pedido);
            this.panel2.Controls.Add(this.cbo_f_sit_ped);
            this.panel2.Controls.Add(this.cbo_f_sit_pag);
            this.panel2.Location = new System.Drawing.Point(7, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 113);
            this.panel2.TabIndex = 17;
            // 
            // chk_f_periodo
            // 
            this.chk_f_periodo.AutoSize = true;
            this.chk_f_periodo.Location = new System.Drawing.Point(11, 14);
            this.chk_f_periodo.Name = "chk_f_periodo";
            this.chk_f_periodo.Size = new System.Drawing.Size(64, 17);
            this.chk_f_periodo.TabIndex = 5;
            this.chk_f_periodo.Text = "Período";
            this.chk_f_periodo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "até";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(399, 54);
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
            this.cbo_f_empresa.Location = new System.Drawing.Point(368, 7);
            this.cbo_f_empresa.Name = "cbo_f_empresa";
            this.cbo_f_empresa.Size = new System.Drawing.Size(137, 21);
            this.cbo_f_empresa.TabIndex = 16;
            // 
            // chk_f_empresa
            // 
            this.chk_f_empresa.AutoSize = true;
            this.chk_f_empresa.Location = new System.Drawing.Point(297, 9);
            this.chk_f_empresa.Name = "chk_f_empresa";
            this.chk_f_empresa.Size = new System.Drawing.Size(67, 17);
            this.chk_f_empresa.TabIndex = 15;
            this.chk_f_empresa.Text = "Empresa";
            this.chk_f_empresa.UseVisualStyleBackColor = true;
            // 
            // txt_f_data_de
            // 
            this.txt_f_data_de.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_f_data_de.Location = new System.Drawing.Point(77, 11);
            this.txt_f_data_de.Name = "txt_f_data_de";
            this.txt_f_data_de.Size = new System.Drawing.Size(78, 20);
            this.txt_f_data_de.TabIndex = 7;
            // 
            // txt_f_data_ate
            // 
            this.txt_f_data_ate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_f_data_ate.Location = new System.Drawing.Point(185, 11);
            this.txt_f_data_ate.Name = "txt_f_data_ate";
            this.txt_f_data_ate.Size = new System.Drawing.Size(78, 20);
            this.txt_f_data_ate.TabIndex = 8;
            // 
            // cbo_f_tp_oper
            // 
            this.cbo_f_tp_oper.FormattingEnabled = true;
            this.cbo_f_tp_oper.Location = new System.Drawing.Point(164, 85);
            this.cbo_f_tp_oper.Name = "cbo_f_tp_oper";
            this.cbo_f_tp_oper.Size = new System.Drawing.Size(149, 21);
            this.cbo_f_tp_oper.TabIndex = 14;
            // 
            // chk_f_sit_pagamento
            // 
            this.chk_f_sit_pagamento.AutoSize = true;
            this.chk_f_sit_pagamento.Location = new System.Drawing.Point(11, 38);
            this.chk_f_sit_pagamento.Name = "chk_f_sit_pagamento";
            this.chk_f_sit_pagamento.Size = new System.Drawing.Size(143, 17);
            this.chk_f_sit_pagamento.TabIndex = 9;
            this.chk_f_sit_pagamento.Text = "Situação de Pagamento:";
            this.chk_f_sit_pagamento.UseVisualStyleBackColor = true;
            // 
            // chk_tp_oper
            // 
            this.chk_tp_oper.AutoSize = true;
            this.chk_tp_oper.Location = new System.Drawing.Point(11, 87);
            this.chk_tp_oper.Name = "chk_tp_oper";
            this.chk_tp_oper.Size = new System.Drawing.Size(115, 17);
            this.chk_tp_oper.TabIndex = 13;
            this.chk_tp_oper.Text = "Tipo de Operação:";
            this.chk_tp_oper.UseVisualStyleBackColor = true;
            // 
            // chk_f_sit_pedido
            // 
            this.chk_f_sit_pedido.AutoSize = true;
            this.chk_f_sit_pedido.Location = new System.Drawing.Point(11, 64);
            this.chk_f_sit_pedido.Name = "chk_f_sit_pedido";
            this.chk_f_sit_pedido.Size = new System.Drawing.Size(122, 17);
            this.chk_f_sit_pedido.TabIndex = 10;
            this.chk_f_sit_pedido.Text = "Situação do Pedido:";
            this.chk_f_sit_pedido.UseVisualStyleBackColor = true;
            // 
            // cbo_f_sit_ped
            // 
            this.cbo_f_sit_ped.FormattingEnabled = true;
            this.cbo_f_sit_ped.Location = new System.Drawing.Point(164, 60);
            this.cbo_f_sit_ped.Name = "cbo_f_sit_ped";
            this.cbo_f_sit_ped.Size = new System.Drawing.Size(149, 21);
            this.cbo_f_sit_ped.TabIndex = 12;
            // 
            // cbo_f_sit_pag
            // 
            this.cbo_f_sit_pag.FormattingEnabled = true;
            this.cbo_f_sit_pag.Location = new System.Drawing.Point(164, 35);
            this.cbo_f_sit_pag.Name = "cbo_f_sit_pag";
            this.cbo_f_sit_pag.Size = new System.Drawing.Size(149, 21);
            this.cbo_f_sit_pag.TabIndex = 11;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(538, 28);
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
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lb_result_message);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 54);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txt_compras_desconto);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txt_compras_qtd);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_compras_vl_aberto);
            this.panel3.Controls.Add(this.txt_compras_vl_total);
            this.panel3.Controls.Add(this.txt_compras_vl_pago);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(306, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 48);
            this.panel3.TabIndex = 19;
            // 
            // txt_compras_desconto
            // 
            this.txt_compras_desconto.BackColor = System.Drawing.Color.Navy;
            this.txt_compras_desconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_compras_desconto.ForeColor = System.Drawing.Color.White;
            this.txt_compras_desconto.Location = new System.Drawing.Point(160, 23);
            this.txt_compras_desconto.Name = "txt_compras_desconto";
            this.txt_compras_desconto.ReadOnly = true;
            this.txt_compras_desconto.Size = new System.Drawing.Size(100, 20);
            this.txt_compras_desconto.TabIndex = 24;
            this.txt_compras_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Desconto R$";
            // 
            // txt_compras_qtd
            // 
            this.txt_compras_qtd.BackColor = System.Drawing.Color.Navy;
            this.txt_compras_qtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_compras_qtd.ForeColor = System.Drawing.Color.White;
            this.txt_compras_qtd.Location = new System.Drawing.Point(3, 23);
            this.txt_compras_qtd.Name = "txt_compras_qtd";
            this.txt_compras_qtd.ReadOnly = true;
            this.txt_compras_qtd.Size = new System.Drawing.Size(48, 20);
            this.txt_compras_qtd.TabIndex = 21;
            this.txt_compras_qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Aberto R$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Compras";
            // 
            // txt_compras_vl_aberto
            // 
            this.txt_compras_vl_aberto.BackColor = System.Drawing.Color.Navy;
            this.txt_compras_vl_aberto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_compras_vl_aberto.ForeColor = System.Drawing.Color.White;
            this.txt_compras_vl_aberto.Location = new System.Drawing.Point(369, 23);
            this.txt_compras_vl_aberto.Name = "txt_compras_vl_aberto";
            this.txt_compras_vl_aberto.ReadOnly = true;
            this.txt_compras_vl_aberto.Size = new System.Drawing.Size(100, 20);
            this.txt_compras_vl_aberto.TabIndex = 5;
            this.txt_compras_vl_aberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_compras_vl_total
            // 
            this.txt_compras_vl_total.BackColor = System.Drawing.Color.Navy;
            this.txt_compras_vl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_compras_vl_total.ForeColor = System.Drawing.Color.White;
            this.txt_compras_vl_total.Location = new System.Drawing.Point(57, 23);
            this.txt_compras_vl_total.Name = "txt_compras_vl_total";
            this.txt_compras_vl_total.ReadOnly = true;
            this.txt_compras_vl_total.Size = new System.Drawing.Size(100, 20);
            this.txt_compras_vl_total.TabIndex = 1;
            this.txt_compras_vl_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_compras_vl_pago
            // 
            this.txt_compras_vl_pago.BackColor = System.Drawing.Color.Navy;
            this.txt_compras_vl_pago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_compras_vl_pago.ForeColor = System.Drawing.Color.White;
            this.txt_compras_vl_pago.Location = new System.Drawing.Point(263, 23);
            this.txt_compras_vl_pago.Name = "txt_compras_vl_pago";
            this.txt_compras_vl_pago.ReadOnly = true;
            this.txt_compras_vl_pago.Size = new System.Drawing.Size(100, 20);
            this.txt_compras_vl_pago.TabIndex = 3;
            this.txt_compras_vl_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pago R$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total R$";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.txt_vendas_desconto);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txt_vendas_qtd);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txt_vendas_vl_aberto);
            this.panel4.Controls.Add(this.txt_vendas_vl_total);
            this.panel4.Controls.Add(this.txt_vendas_vl_pago);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(788, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(486, 48);
            this.panel4.TabIndex = 20;
            // 
            // txt_vendas_desconto
            // 
            this.txt_vendas_desconto.BackColor = System.Drawing.Color.Navy;
            this.txt_vendas_desconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vendas_desconto.ForeColor = System.Drawing.Color.White;
            this.txt_vendas_desconto.Location = new System.Drawing.Point(169, 23);
            this.txt_vendas_desconto.Name = "txt_vendas_desconto";
            this.txt_vendas_desconto.ReadOnly = true;
            this.txt_vendas_desconto.Size = new System.Drawing.Size(100, 20);
            this.txt_vendas_desconto.TabIndex = 22;
            this.txt_vendas_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(199, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Desconto R$";
            // 
            // txt_vendas_qtd
            // 
            this.txt_vendas_qtd.BackColor = System.Drawing.Color.Navy;
            this.txt_vendas_qtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vendas_qtd.ForeColor = System.Drawing.Color.White;
            this.txt_vendas_qtd.Location = new System.Drawing.Point(3, 23);
            this.txt_vendas_qtd.Name = "txt_vendas_qtd";
            this.txt_vendas_qtd.ReadOnly = true;
            this.txt_vendas_qtd.Size = new System.Drawing.Size(54, 20);
            this.txt_vendas_qtd.TabIndex = 21;
            this.txt_vendas_qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(424, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Aberto R$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Vendas";
            // 
            // txt_vendas_vl_aberto
            // 
            this.txt_vendas_vl_aberto.BackColor = System.Drawing.Color.Navy;
            this.txt_vendas_vl_aberto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vendas_vl_aberto.ForeColor = System.Drawing.Color.White;
            this.txt_vendas_vl_aberto.Location = new System.Drawing.Point(379, 23);
            this.txt_vendas_vl_aberto.Name = "txt_vendas_vl_aberto";
            this.txt_vendas_vl_aberto.ReadOnly = true;
            this.txt_vendas_vl_aberto.Size = new System.Drawing.Size(100, 20);
            this.txt_vendas_vl_aberto.TabIndex = 5;
            this.txt_vendas_vl_aberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_vendas_vl_total
            // 
            this.txt_vendas_vl_total.BackColor = System.Drawing.Color.Navy;
            this.txt_vendas_vl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vendas_vl_total.ForeColor = System.Drawing.Color.White;
            this.txt_vendas_vl_total.Location = new System.Drawing.Point(63, 23);
            this.txt_vendas_vl_total.Name = "txt_vendas_vl_total";
            this.txt_vendas_vl_total.ReadOnly = true;
            this.txt_vendas_vl_total.Size = new System.Drawing.Size(100, 20);
            this.txt_vendas_vl_total.TabIndex = 1;
            this.txt_vendas_vl_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_vendas_vl_pago
            // 
            this.txt_vendas_vl_pago.BackColor = System.Drawing.Color.Navy;
            this.txt_vendas_vl_pago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vendas_vl_pago.ForeColor = System.Drawing.Color.White;
            this.txt_vendas_vl_pago.Location = new System.Drawing.Point(273, 23);
            this.txt_vendas_vl_pago.Name = "txt_vendas_vl_pago";
            this.txt_vendas_vl_pago.ReadOnly = true;
            this.txt_vendas_vl_pago.Size = new System.Drawing.Size(100, 20);
            this.txt_vendas_vl_pago.TabIndex = 3;
            this.txt_vendas_vl_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Pago R$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(114, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total R$";
            // 
            // lb_result_message
            // 
            this.lb_result_message.AutoSize = true;
            this.lb_result_message.Location = new System.Drawing.Point(3, 12);
            this.lb_result_message.Name = "lb_result_message";
            this.lb_result_message.Size = new System.Drawing.Size(220, 13);
            this.lb_result_message.TabIndex = 0;
            this.lb_result_message.Text = "Clique em Atualizar para listar os movimentos.";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 135);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(728, 190);
            this.dgDados.TabIndex = 2;
            // 
            // pb_exportar
            // 
            this.pb_exportar.Location = new System.Drawing.Point(6, 30);
            this.pb_exportar.Name = "pb_exportar";
            this.pb_exportar.Size = new System.Drawing.Size(198, 15);
            this.pb_exportar.TabIndex = 25;
            this.pb_exportar.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(640, 97);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 26);
            this.btnExcel.TabIndex = 24;
            this.btnExcel.Tag = "Exporta o resultado para Excel.";
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(640, 70);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 26);
            this.btnCopiar.TabIndex = 23;
            this.btnCopiar.Tag = "Copia o resultado para a área de transferência.";
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            // 
            // TelaMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 379);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_top);
            this.Name = "TelaMovimentacao";
            this.Text = "TelaMovimentacao";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Label lb_result_message;
        private System.Windows.Forms.DateTimePicker txt_f_data_ate;
        private System.Windows.Forms.DateTimePicker txt_f_data_de;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_f_periodo;
        private System.Windows.Forms.ComboBox cbo_f_sit_ped;
        private System.Windows.Forms.ComboBox cbo_f_sit_pag;
        private System.Windows.Forms.CheckBox chk_f_sit_pedido;
        private System.Windows.Forms.CheckBox chk_f_sit_pagamento;
        private System.Windows.Forms.ComboBox cbo_f_tp_oper;
        private System.Windows.Forms.CheckBox chk_tp_oper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbo_f_empresa;
        private System.Windows.Forms.CheckBox chk_f_empresa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_compras_vl_aberto;
        private System.Windows.Forms.TextBox txt_compras_vl_total;
        private System.Windows.Forms.TextBox txt_compras_vl_pago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_vendas_vl_aberto;
        private System.Windows.Forms.TextBox txt_vendas_vl_total;
        private System.Windows.Forms.TextBox txt_vendas_vl_pago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_compras_qtd;
        private System.Windows.Forms.TextBox txt_vendas_qtd;
        private System.Windows.Forms.TextBox txt_compras_desconto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_vendas_desconto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.ProgressBar pb_exportar;
    }
}