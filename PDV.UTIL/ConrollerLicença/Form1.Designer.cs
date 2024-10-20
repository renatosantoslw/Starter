namespace ConrollerLicença
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.clientetextBox = new System.Windows.Forms.TextBox();
            this.documentotextBox = new System.Windows.Forms.TextBox();
            this.observacaotextBox = new System.Windows.Forms.TextBox();
            this.ativocheckBox = new System.Windows.Forms.CheckBox();
            this.datavencimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataAplicacaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ChaveDeAcessotextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.pesquisaqrtextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(122, 24);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(65, 20);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.Text = "0";
            // 
            // clientetextBox
            // 
            this.clientetextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clientetextBox.Location = new System.Drawing.Point(193, 24);
            this.clientetextBox.Name = "clientetextBox";
            this.clientetextBox.Size = new System.Drawing.Size(212, 20);
            this.clientetextBox.TabIndex = 1;
            // 
            // documentotextBox
            // 
            this.documentotextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.documentotextBox.Location = new System.Drawing.Point(429, 24);
            this.documentotextBox.Name = "documentotextBox";
            this.documentotextBox.Size = new System.Drawing.Size(120, 20);
            this.documentotextBox.TabIndex = 2;
            // 
            // observacaotextBox
            // 
            this.observacaotextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.observacaotextBox.Location = new System.Drawing.Point(122, 63);
            this.observacaotextBox.Name = "observacaotextBox";
            this.observacaotextBox.Size = new System.Drawing.Size(427, 20);
            this.observacaotextBox.TabIndex = 3;
            // 
            // ativocheckBox
            // 
            this.ativocheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ativocheckBox.AutoSize = true;
            this.ativocheckBox.Location = new System.Drawing.Point(499, 176);
            this.ativocheckBox.Name = "ativocheckBox";
            this.ativocheckBox.Size = new System.Drawing.Size(50, 17);
            this.ativocheckBox.TabIndex = 4;
            this.ativocheckBox.Text = "Ativo";
            this.ativocheckBox.UseVisualStyleBackColor = true;
            // 
            // datavencimentoDateTimePicker
            // 
            this.datavencimentoDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datavencimentoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datavencimentoDateTimePicker.Location = new System.Drawing.Point(442, 89);
            this.datavencimentoDateTimePicker.Name = "datavencimentoDateTimePicker";
            this.datavencimentoDateTimePicker.Size = new System.Drawing.Size(107, 20);
            this.datavencimentoDateTimePicker.TabIndex = 5;
            this.datavencimentoDateTimePicker.ValueChanged += new System.EventHandler(this.datavencimentoDateTimePicker_ValueChanged);
            // 
            // dataAplicacaoDateTimePicker
            // 
            this.dataAplicacaoDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataAplicacaoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataAplicacaoDateTimePicker.Location = new System.Drawing.Point(442, 114);
            this.dataAplicacaoDateTimePicker.Name = "dataAplicacaoDateTimePicker";
            this.dataAplicacaoDateTimePicker.Size = new System.Drawing.Size(107, 20);
            this.dataAplicacaoDateTimePicker.TabIndex = 6;
            this.dataAplicacaoDateTimePicker.ValueChanged += new System.EventHandler(this.dataAplicacaoDateTimePicker_ValueChanged);
            // 
            // ChaveDeAcessotextBox
            // 
            this.ChaveDeAcessotextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChaveDeAcessotextBox.Location = new System.Drawing.Point(122, 150);
            this.ChaveDeAcessotextBox.Name = "ChaveDeAcessotextBox";
            this.ChaveDeAcessotextBox.Size = new System.Drawing.Size(427, 20);
            this.ChaveDeAcessotextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Documento";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Observação";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Data Vencimento";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Data Aplicação";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Chave de Acesso";
            // 
            // dgClientes
            // 
            this.dgClientes.AllowUserToAddRows = false;
            this.dgClientes.AllowUserToDeleteRows = false;
            this.dgClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Location = new System.Drawing.Point(0, 251);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgClientes.Size = new System.Drawing.Size(703, 225);
            this.dgClientes.TabIndex = 16;
            this.dgClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgClientes_CellDoubleClick);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSalvar.Location = new System.Drawing.Point(207, 192);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcluir.Location = new System.Drawing.Point(301, 192);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 18;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnListar
            // 
            this.btnListar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListar.Location = new System.Drawing.Point(395, 192);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 19;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // pesquisaqrtextBox
            // 
            this.pesquisaqrtextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pesquisaqrtextBox.Location = new System.Drawing.Point(12, 225);
            this.pesquisaqrtextBox.Name = "pesquisaqrtextBox";
            this.pesquisaqrtextBox.Size = new System.Drawing.Size(677, 20);
            this.pesquisaqrtextBox.TabIndex = 20;
            this.pesquisaqrtextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Pesquisar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pesquisaqrtextBox);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChaveDeAcessotextBox);
            this.Controls.Add(this.dataAplicacaoDateTimePicker);
            this.Controls.Add(this.datavencimentoDateTimePicker);
            this.Controls.Add(this.ativocheckBox);
            this.Controls.Add(this.observacaotextBox);
            this.Controls.Add(this.documentotextBox);
            this.Controls.Add(this.clientetextBox);
            this.Controls.Add(this.idTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller Licença";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox clientetextBox;
        private System.Windows.Forms.TextBox documentotextBox;
        private System.Windows.Forms.TextBox observacaotextBox;
        private System.Windows.Forms.CheckBox ativocheckBox;
        private System.Windows.Forms.DateTimePicker datavencimentoDateTimePicker;
        private System.Windows.Forms.DateTimePicker dataAplicacaoDateTimePicker;
        private System.Windows.Forms.TextBox ChaveDeAcessotextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.TextBox pesquisaqrtextBox;
        private System.Windows.Forms.Label label8;
    }
}

