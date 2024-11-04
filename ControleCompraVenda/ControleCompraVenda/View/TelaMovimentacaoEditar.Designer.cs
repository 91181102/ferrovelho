namespace ControleCompraVenda.View
{
    partial class TelaMovimentacaoEditar
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
            this.pn_bottom = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_movimento_id = new System.Windows.Forms.TextBox();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pessoa = new System.Windows.Forms.TextBox();
            this.lb_usuario = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pn_produtos = new System.Windows.Forms.Panel();
            this.txt_peso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_volumes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_valor_total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_descontos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_acrescimo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_valor_pago = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgProdutos = new System.Windows.Forms.DataGridView();
            this.pn_pagamentos = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.dgPagamentos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_a_pagar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tipo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_empresa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chk_ativo = new System.Windows.Forms.CheckBox();
            this.txt_data_mov = new System.Windows.Forms.TextBox();
            this.pn_user_cancel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAdmCancelar = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbo_usuario = new System.Windows.Forms.ComboBox();
            this.btnAdmOk = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.pn_top.SuspendLayout();
            this.pn_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pn_produtos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
            this.pn_pagamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagamentos)).BeginInit();
            this.panel2.SuspendLayout();
            this.pn_user_cancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.Controls.Add(this.txt_data_mov);
            this.pn_top.Controls.Add(this.chk_ativo);
            this.pn_top.Controls.Add(this.txt_empresa);
            this.pn_top.Controls.Add(this.label15);
            this.pn_top.Controls.Add(this.txt_tipo);
            this.pn_top.Controls.Add(this.label14);
            this.pn_top.Controls.Add(this.splitContainer1);
            this.pn_top.Controls.Add(this.txt_usuario);
            this.pn_top.Controls.Add(this.lb_usuario);
            this.pn_top.Controls.Add(this.txt_pessoa);
            this.pn_top.Controls.Add(this.label3);
            this.pn_top.Controls.Add(this.label2);
            this.pn_top.Controls.Add(this.txt_movimento_id);
            this.pn_top.Controls.Add(this.label1);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(619, 423);
            this.pn_top.TabIndex = 0;
            // 
            // pn_bottom
            // 
            this.pn_bottom.Controls.Add(this.btnRecibo);
            this.pn_bottom.Controls.Add(this.btnExcluir);
            this.pn_bottom.Controls.Add(this.btnSair);
            this.pn_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_bottom.Location = new System.Drawing.Point(0, 423);
            this.pn_bottom.Name = "pn_bottom";
            this.pn_bottom.Size = new System.Drawing.Size(619, 51);
            this.pn_bottom.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(12, 6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 40);
            this.btnSair.TabIndex = 0;
            this.btnSair.Tag = "Fecha esta janela.";
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(116, 6);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(139, 40);
            this.btnExcluir.TabIndex = 1;
            this.btnExcluir.Tag = "Cancela o pedido e os pagamentos.";
            this.btnExcluir.Text = "Cancelar Movimento";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movimento";
            // 
            // txt_movimento_id
            // 
            this.txt_movimento_id.Location = new System.Drawing.Point(12, 25);
            this.txt_movimento_id.Name = "txt_movimento_id";
            this.txt_movimento_id.ReadOnly = true;
            this.txt_movimento_id.Size = new System.Drawing.Size(98, 20);
            this.txt_movimento_id.TabIndex = 1;
            // 
            // btnRecibo
            // 
            this.btnRecibo.Location = new System.Drawing.Point(477, 6);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(139, 40);
            this.btnRecibo.TabIndex = 2;
            this.btnRecibo.Tag = "Abre o recibo do pedido.";
            this.btnRecibo.Text = "Abrir Recibo";
            this.btnRecibo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente:";
            // 
            // txt_pessoa
            // 
            this.txt_pessoa.Location = new System.Drawing.Point(228, 25);
            this.txt_pessoa.Name = "txt_pessoa";
            this.txt_pessoa.ReadOnly = true;
            this.txt_pessoa.Size = new System.Drawing.Size(271, 20);
            this.txt_pessoa.TabIndex = 5;
            // 
            // lb_usuario
            // 
            this.lb_usuario.AutoSize = true;
            this.lb_usuario.Location = new System.Drawing.Point(504, 9);
            this.lb_usuario.Name = "lb_usuario";
            this.lb_usuario.Size = new System.Drawing.Size(75, 13);
            this.lb_usuario.TabIndex = 6;
            this.lb_usuario.Text = "Realizado por:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(505, 25);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.ReadOnly = true;
            this.txt_usuario.Size = new System.Drawing.Size(107, 20);
            this.txt_usuario.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 76);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgProdutos);
            this.splitContainer1.Panel1.Controls.Add(this.pn_produtos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.dgPagamentos);
            this.splitContainer1.Panel2.Controls.Add(this.pn_pagamentos);
            this.splitContainer1.Size = new System.Drawing.Size(619, 347);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 8;
            // 
            // pn_produtos
            // 
            this.pn_produtos.Controls.Add(this.label7);
            this.pn_produtos.Controls.Add(this.txt_volumes);
            this.pn_produtos.Controls.Add(this.label12);
            this.pn_produtos.Controls.Add(this.txt_peso);
            this.pn_produtos.Controls.Add(this.label6);
            this.pn_produtos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_produtos.Location = new System.Drawing.Point(0, 0);
            this.pn_produtos.Name = "pn_produtos";
            this.pn_produtos.Size = new System.Drawing.Size(615, 25);
            this.pn_produtos.TabIndex = 0;
            // 
            // txt_peso
            // 
            this.txt_peso.Location = new System.Drawing.Point(417, 2);
            this.txt_peso.Name = "txt_peso";
            this.txt_peso.ReadOnly = true;
            this.txt_peso.Size = new System.Drawing.Size(59, 20);
            this.txt_peso.TabIndex = 10;
            this.txt_peso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Peso:";
            // 
            // txt_volumes
            // 
            this.txt_volumes.Location = new System.Drawing.Point(553, 2);
            this.txt_volumes.Name = "txt_volumes";
            this.txt_volumes.ReadOnly = true;
            this.txt_volumes.Size = new System.Drawing.Size(59, 20);
            this.txt_volumes.TabIndex = 12;
            this.txt_volumes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Volumes:";
            // 
            // txt_valor_total
            // 
            this.txt_valor_total.Location = new System.Drawing.Point(80, 6);
            this.txt_valor_total.Name = "txt_valor_total";
            this.txt_valor_total.ReadOnly = true;
            this.txt_valor_total.Size = new System.Drawing.Size(113, 20);
            this.txt_valor_total.TabIndex = 14;
            this.txt_valor_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Valor Total:";
            // 
            // txt_descontos
            // 
            this.txt_descontos.Location = new System.Drawing.Point(80, 29);
            this.txt_descontos.Name = "txt_descontos";
            this.txt_descontos.ReadOnly = true;
            this.txt_descontos.Size = new System.Drawing.Size(113, 20);
            this.txt_descontos.TabIndex = 16;
            this.txt_descontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Descontos:";
            // 
            // txt_acrescimo
            // 
            this.txt_acrescimo.Location = new System.Drawing.Point(80, 53);
            this.txt_acrescimo.Name = "txt_acrescimo";
            this.txt_acrescimo.ReadOnly = true;
            this.txt_acrescimo.Size = new System.Drawing.Size(113, 20);
            this.txt_acrescimo.TabIndex = 18;
            this.txt_acrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Acrescimos:";
            // 
            // txt_valor_pago
            // 
            this.txt_valor_pago.Location = new System.Drawing.Point(80, 77);
            this.txt_valor_pago.Name = "txt_valor_pago";
            this.txt_valor_pago.ReadOnly = true;
            this.txt_valor_pago.Size = new System.Drawing.Size(113, 20);
            this.txt_valor_pago.TabIndex = 20;
            this.txt_valor_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Valor Pago:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Materiais:";
            // 
            // dgProdutos
            // 
            this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProdutos.Location = new System.Drawing.Point(0, 25);
            this.dgProdutos.Name = "dgProdutos";
            this.dgProdutos.Size = new System.Drawing.Size(615, 162);
            this.dgProdutos.TabIndex = 1;
            // 
            // pn_pagamentos
            // 
            this.pn_pagamentos.Controls.Add(this.label13);
            this.pn_pagamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_pagamentos.Location = new System.Drawing.Point(0, 0);
            this.pn_pagamentos.Name = "pn_pagamentos";
            this.pn_pagamentos.Size = new System.Drawing.Size(615, 23);
            this.pn_pagamentos.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Pagamentos:";
            // 
            // dgPagamentos
            // 
            this.dgPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPagamentos.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgPagamentos.Location = new System.Drawing.Point(0, 23);
            this.dgPagamentos.Name = "dgPagamentos";
            this.dgPagamentos.Size = new System.Drawing.Size(417, 125);
            this.dgPagamentos.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_a_pagar);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_valor_pago);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txt_valor_total);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txt_acrescimo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txt_descontos);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(417, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 125);
            this.panel2.TabIndex = 3;
            // 
            // txt_a_pagar
            // 
            this.txt_a_pagar.Location = new System.Drawing.Point(80, 99);
            this.txt_a_pagar.Name = "txt_a_pagar";
            this.txt_a_pagar.ReadOnly = true;
            this.txt_a_pagar.Size = new System.Drawing.Size(113, 20);
            this.txt_a_pagar.TabIndex = 22;
            this.txt_a_pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "A Pagar:";
            // 
            // txt_tipo
            // 
            this.txt_tipo.Location = new System.Drawing.Point(114, 50);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.ReadOnly = true;
            this.txt_tipo.Size = new System.Drawing.Size(79, 20);
            this.txt_tipo.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Tipo de Operação:";
            // 
            // txt_empresa
            // 
            this.txt_empresa.Location = new System.Drawing.Point(256, 50);
            this.txt_empresa.Name = "txt_empresa";
            this.txt_empresa.ReadOnly = true;
            this.txt_empresa.Size = new System.Drawing.Size(293, 20);
            this.txt_empresa.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(204, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Empresa:";
            // 
            // chk_ativo
            // 
            this.chk_ativo.AutoSize = true;
            this.chk_ativo.Enabled = false;
            this.chk_ativo.Location = new System.Drawing.Point(556, 53);
            this.chk_ativo.Name = "chk_ativo";
            this.chk_ativo.Size = new System.Drawing.Size(50, 17);
            this.chk_ativo.TabIndex = 13;
            this.chk_ativo.Text = "Ativo";
            this.chk_ativo.UseVisualStyleBackColor = true;
            // 
            // txt_data_mov
            // 
            this.txt_data_mov.Location = new System.Drawing.Point(114, 25);
            this.txt_data_mov.Name = "txt_data_mov";
            this.txt_data_mov.ReadOnly = true;
            this.txt_data_mov.Size = new System.Drawing.Size(108, 20);
            this.txt_data_mov.TabIndex = 14;
            // 
            // pn_user_cancel
            // 
            this.pn_user_cancel.BackColor = System.Drawing.Color.Khaki;
            this.pn_user_cancel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_user_cancel.Controls.Add(this.label16);
            this.pn_user_cancel.Controls.Add(this.label17);
            this.pn_user_cancel.Controls.Add(this.btnAdmCancelar);
            this.pn_user_cancel.Controls.Add(this.txt_senha);
            this.pn_user_cancel.Controls.Add(this.label18);
            this.pn_user_cancel.Controls.Add(this.cbo_usuario);
            this.pn_user_cancel.Controls.Add(this.btnAdmOk);
            this.pn_user_cancel.Controls.Add(this.label19);
            this.pn_user_cancel.Location = new System.Drawing.Point(151, 159);
            this.pn_user_cancel.Name = "pn_user_cancel";
            this.pn_user_cancel.Size = new System.Drawing.Size(317, 156);
            this.pn_user_cancel.TabIndex = 2;
            this.pn_user_cancel.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Usuário";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Senha";
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
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(16, 108);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(177, 20);
            this.txt_senha.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(240, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Peça ao administrador para inserir as credenciais.";
            // 
            // cbo_usuario
            // 
            this.cbo_usuario.FormattingEnabled = true;
            this.cbo_usuario.Location = new System.Drawing.Point(16, 60);
            this.cbo_usuario.Name = "cbo_usuario";
            this.cbo_usuario.Size = new System.Drawing.Size(205, 21);
            this.cbo_usuario.TabIndex = 2;
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(240, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Usuário sem permissão para cancelar movimento.";
            // 
            // TelaMovimentacaoEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 474);
            this.Controls.Add(this.pn_user_cancel);
            this.Controls.Add(this.pn_bottom);
            this.Controls.Add(this.pn_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaMovimentacaoEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Movimentação";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.pn_bottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pn_produtos.ResumeLayout(false);
            this.pn_produtos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
            this.pn_pagamentos.ResumeLayout(false);
            this.pn_pagamentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagamentos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pn_user_cancel.ResumeLayout(false);
            this.pn_user_cancel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.TextBox txt_valor_pago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_acrescimo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_descontos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_valor_total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_volumes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_peso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pn_produtos;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label lb_usuario;
        private System.Windows.Forms.TextBox txt_pessoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_movimento_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn_bottom;
        private System.Windows.Forms.Button btnRecibo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgProdutos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgPagamentos;
        private System.Windows.Forms.Panel pn_pagamentos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_empresa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_tipo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_a_pagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chk_ativo;
        private System.Windows.Forms.TextBox txt_data_mov;
        private System.Windows.Forms.Panel pn_user_cancel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnAdmCancelar;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbo_usuario;
        private System.Windows.Forms.Button btnAdmOk;
        private System.Windows.Forms.Label label19;
    }
}