namespace ControleCompraVenda.View
{
    partial class TelaCaixaMovimento
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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_data_ate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_data_de = new System.Windows.Forms.DateTimePicker();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.chk_f_periodo = new System.Windows.Forms.CheckBox();
            this.pn_bottom = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_sd_atual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_saidas = new System.Windows.Forms.TextBox();
            this.txt_entradas = new System.Windows.Forms.TextBox();
            this.txt_sd_anterior = new System.Windows.Forms.TextBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.pn_top.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pn_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_top
            // 
            this.pn_top.Controls.Add(this.btnSair);
            this.pn_top.Controls.Add(this.btnExcel);
            this.pn_top.Controls.Add(this.btnNovo);
            this.pn_top.Controls.Add(this.label1);
            this.pn_top.Controls.Add(this.panel3);
            this.pn_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_top.Location = new System.Drawing.Point(0, 0);
            this.pn_top.Name = "pn_top";
            this.pn_top.Size = new System.Drawing.Size(801, 79);
            this.pn_top.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(584, 19);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 36);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(503, 19);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 36);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(422, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 36);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtros";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_data_ate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_data_de);
            this.panel3.Controls.Add(this.btnAtualizar);
            this.panel3.Controls.Add(this.chk_f_periodo);
            this.panel3.Location = new System.Drawing.Point(12, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 44);
            this.panel3.TabIndex = 0;
            // 
            // txt_data_ate
            // 
            this.txt_data_ate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_data_ate.Location = new System.Drawing.Point(183, 7);
            this.txt_data_ate.Name = "txt_data_ate";
            this.txt_data_ate.Size = new System.Drawing.Size(76, 20);
            this.txt_data_ate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "a";
            // 
            // txt_data_de
            // 
            this.txt_data_de.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_data_de.Location = new System.Drawing.Point(82, 7);
            this.txt_data_de.Name = "txt_data_de";
            this.txt_data_de.Size = new System.Drawing.Size(76, 20);
            this.txt_data_de.TabIndex = 2;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(276, 3);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 36);
            this.btnAtualizar.TabIndex = 2;
            this.btnAtualizar.Text = "Buscar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // chk_f_periodo
            // 
            this.chk_f_periodo.AutoSize = true;
            this.chk_f_periodo.Checked = true;
            this.chk_f_periodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_f_periodo.Enabled = false;
            this.chk_f_periodo.Location = new System.Drawing.Point(17, 9);
            this.chk_f_periodo.Name = "chk_f_periodo";
            this.chk_f_periodo.Size = new System.Drawing.Size(64, 17);
            this.chk_f_periodo.TabIndex = 3;
            this.chk_f_periodo.Text = "Período";
            this.chk_f_periodo.UseVisualStyleBackColor = true;
            // 
            // pn_bottom
            // 
            this.pn_bottom.Controls.Add(this.label6);
            this.pn_bottom.Controls.Add(this.txt_sd_atual);
            this.pn_bottom.Controls.Add(this.label5);
            this.pn_bottom.Controls.Add(this.label4);
            this.pn_bottom.Controls.Add(this.label3);
            this.pn_bottom.Controls.Add(this.txt_saidas);
            this.pn_bottom.Controls.Add(this.txt_entradas);
            this.pn_bottom.Controls.Add(this.txt_sd_anterior);
            this.pn_bottom.Controls.Add(this.lb_status);
            this.pn_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_bottom.Location = new System.Drawing.Point(0, 308);
            this.pn_bottom.Name = "pn_bottom";
            this.pn_bottom.Size = new System.Drawing.Size(801, 42);
            this.pn_bottom.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Saldo Anterior:";
            // 
            // txt_sd_atual
            // 
            this.txt_sd_atual.Location = new System.Drawing.Point(673, 17);
            this.txt_sd_atual.Name = "txt_sd_atual";
            this.txt_sd_atual.Size = new System.Drawing.Size(125, 20);
            this.txt_sd_atual.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(670, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Saldo Atual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Saídas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Entradas";
            // 
            // txt_saidas
            // 
            this.txt_saidas.Location = new System.Drawing.Point(545, 17);
            this.txt_saidas.Name = "txt_saidas";
            this.txt_saidas.Size = new System.Drawing.Size(125, 20);
            this.txt_saidas.TabIndex = 5;
            // 
            // txt_entradas
            // 
            this.txt_entradas.Location = new System.Drawing.Point(417, 17);
            this.txt_entradas.Name = "txt_entradas";
            this.txt_entradas.Size = new System.Drawing.Size(125, 20);
            this.txt_entradas.TabIndex = 4;
            // 
            // txt_sd_anterior
            // 
            this.txt_sd_anterior.Location = new System.Drawing.Point(289, 17);
            this.txt_sd_anterior.Name = "txt_sd_anterior";
            this.txt_sd_anterior.Size = new System.Drawing.Size(125, 20);
            this.txt_sd_anterior.TabIndex = 3;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(9, 13);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(203, 13);
            this.lb_status.TabIndex = 2;
            this.lb_status.Text = "Clique em Buscar para listar o movimento.";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDados.Location = new System.Drawing.Point(0, 79);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(801, 229);
            this.dgDados.TabIndex = 2;
            // 
            // TelaCaixaMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 350);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.pn_bottom);
            this.Controls.Add(this.pn_top);
            this.Name = "TelaCaixaMovimento";
            this.Text = "TelaCaixaMovimento";
            this.pn_top.ResumeLayout(false);
            this.pn_top.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pn_bottom.ResumeLayout(false);
            this.pn_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_top;
        private System.Windows.Forms.Panel pn_bottom;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker txt_data_ate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txt_data_de;
        private System.Windows.Forms.CheckBox chk_f_periodo;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_sd_atual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_saidas;
        private System.Windows.Forms.TextBox txt_entradas;
        private System.Windows.Forms.TextBox txt_sd_anterior;
        private System.Windows.Forms.Label lb_status;
    }
}