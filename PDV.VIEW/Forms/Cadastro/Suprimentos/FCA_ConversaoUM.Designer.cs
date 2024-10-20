namespace PDV.VIEW.Forms.Cadastro.Suprimentos
{
    partial class FCA_ConversaoUM
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCMB_UnidadeEntrada = new MetroFramework.Controls.MetroComboBox();
            this.ovCMB_UnidadeSaida = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_Fator = new PDV.UTIL.Components.Custom.EditDecimal();
            this.ovTXT_CodProduto = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Produto = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.ovCMB_Calculo = new MetroFramework.Controls.MetroComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodFornecedor = new System.Windows.Forms.MaskedTextBox();
            this.txtFornecedor = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarFornecedor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProdutoFornecedor = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fator)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(19, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "* Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "* UN. Entrada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(179, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "* Cálculo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(425, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "* UN. Saida:";
            // 
            // ovCMB_UnidadeEntrada
            // 
            this.ovCMB_UnidadeEntrada.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_UnidadeEntrada.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_UnidadeEntrada.FormattingEnabled = true;
            this.ovCMB_UnidadeEntrada.ItemHeight = 19;
            this.ovCMB_UnidadeEntrada.Location = new System.Drawing.Point(19, 135);
            this.ovCMB_UnidadeEntrada.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_UnidadeEntrada.Name = "ovCMB_UnidadeEntrada";
            this.ovCMB_UnidadeEntrada.Size = new System.Drawing.Size(119, 25);
            this.ovCMB_UnidadeEntrada.TabIndex = 5;
            this.ovCMB_UnidadeEntrada.UseSelectable = true;
            this.ovCMB_UnidadeEntrada.SelectedIndexChanged += new System.EventHandler(this.ovCMB_UnidadeEntrada_SelectedIndexChanged);
            // 
            // ovCMB_UnidadeSaida
            // 
            this.ovCMB_UnidadeSaida.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_UnidadeSaida.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_UnidadeSaida.FormattingEnabled = true;
            this.ovCMB_UnidadeSaida.ItemHeight = 19;
            this.ovCMB_UnidadeSaida.Location = new System.Drawing.Point(428, 134);
            this.ovCMB_UnidadeSaida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_UnidadeSaida.Name = "ovCMB_UnidadeSaida";
            this.ovCMB_UnidadeSaida.Size = new System.Drawing.Size(120, 25);
            this.ovCMB_UnidadeSaida.TabIndex = 8;
            this.ovCMB_UnidadeSaida.UseSelectable = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(310, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "*Quantidade:";
            // 
            // ovTXT_Fator
            // 
            this.ovTXT_Fator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Fator.DecimalPlaces = 4;
            this.ovTXT_Fator.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Fator.Location = new System.Drawing.Point(307, 135);
            this.ovTXT_Fator.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            262144});
            this.ovTXT_Fator.Name = "ovTXT_Fator";
            this.ovTXT_Fator.Sigla = "Qtd";
            this.ovTXT_Fator.Size = new System.Drawing.Size(111, 23);
            this.ovTXT_Fator.TabIndex = 7;
            this.ovTXT_Fator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Fator.ThousandsSeparator = true;
            this.ovTXT_Fator.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Fator.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Fator.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Fator.viPrecisao = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ovTXT_Fator.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ovTXT_Fator.ValueChanged += new System.EventHandler(this.ovTXT_Fator_ValueChanged);
            // 
            // ovTXT_CodProduto
            // 
            this.ovTXT_CodProduto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_CodProduto.Location = new System.Drawing.Point(19, 84);
            this.ovTXT_CodProduto.Name = "ovTXT_CodProduto";
            this.ovTXT_CodProduto.Size = new System.Drawing.Size(120, 21);
            this.ovTXT_CodProduto.TabIndex = 2;
            this.ovTXT_CodProduto.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.ovTXT_CodProduto_MaskInputRejected);
            this.ovTXT_CodProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_CodProduto_KeyUp);
            // 
            // ovTXT_Produto
            // 
            this.ovTXT_Produto.Enabled = false;
            this.ovTXT_Produto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Produto.Location = new System.Drawing.Point(182, 84);
            this.ovTXT_Produto.Name = "ovTXT_Produto";
            this.ovTXT_Produto.ReadOnly = true;
            this.ovTXT_Produto.Size = new System.Drawing.Size(236, 21);
            this.ovTXT_Produto.TabIndex = 127;
            this.ovTXT_Produto.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.ovTXT_Produto_MaskInputRejected);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(145, 83);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Location = new System.Drawing.Point(460, 237);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 10;
            this.metroButton4.Text = "Cancelar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.Location = new System.Drawing.Point(366, 237);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 9;
            this.metroButton3.Text = "Salvar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // ovCMB_Calculo
            // 
            this.ovCMB_Calculo.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Calculo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ovCMB_Calculo.FormattingEnabled = true;
            this.ovCMB_Calculo.ItemHeight = 19;
            this.ovCMB_Calculo.Items.AddRange(new object[] {
            "Multiplicar",
            "Dividir"});
            this.ovCMB_Calculo.Location = new System.Drawing.Point(182, 134);
            this.ovCMB_Calculo.Name = "ovCMB_Calculo";
            this.ovCMB_Calculo.Size = new System.Drawing.Size(116, 25);
            this.ovCMB_Calculo.TabIndex = 6;
            this.ovCMB_Calculo.UseSelectable = true;
            this.ovCMB_Calculo.SelectedIndexChanged += new System.EventHandler(this.ovCMB_Calculo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(19, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "* Fornecedor:";
            // 
            // txtCodFornecedor
            // 
            this.txtCodFornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodFornecedor.Location = new System.Drawing.Point(19, 38);
            this.txtCodFornecedor.Name = "txtCodFornecedor";
            this.txtCodFornecedor.Size = new System.Drawing.Size(120, 21);
            this.txtCodFornecedor.TabIndex = 0;
            this.txtCodFornecedor.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtCodFornecedor_MaskInputRejected);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtFornecedor.Location = new System.Drawing.Point(182, 38);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(366, 21);
            this.txtFornecedor.TabIndex = 134;
            // 
            // btnSelecionarFornecedor
            // 
            this.btnSelecionarFornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSelecionarFornecedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelecionarFornecedor.Location = new System.Drawing.Point(145, 37);
            this.btnSelecionarFornecedor.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelecionarFornecedor.Name = "btnSelecionarFornecedor";
            this.btnSelecionarFornecedor.Size = new System.Drawing.Size(30, 23);
            this.btnSelecionarFornecedor.TabIndex = 1;
            this.btnSelecionarFornecedor.Text = "...";
            this.btnSelecionarFornecedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelecionarFornecedor.UseVisualStyleBackColor = true;
            this.btnSelecionarFornecedor.Click += new System.EventHandler(this.btnSelecionarFornecedor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(428, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 136;
            this.label7.Text = "* Produto Fornecedor:";
            // 
            // txtProdutoFornecedor
            // 
            this.txtProdutoFornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtProdutoFornecedor.Location = new System.Drawing.Point(428, 84);
            this.txtProdutoFornecedor.Name = "txtProdutoFornecedor";
            this.txtProdutoFornecedor.Size = new System.Drawing.Size(120, 21);
            this.txtProdutoFornecedor.TabIndex = 4;
            this.txtProdutoFornecedor.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtProdutoFornecedor_MaskInputRejected);
            // 
            // FCA_ConversaoUM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 289);
            this.Controls.Add(this.txtProdutoFornecedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSelecionarFornecedor);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.txtCodFornecedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ovCMB_Calculo);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ovTXT_Produto);
            this.Controls.Add(this.ovTXT_CodProduto);
            this.Controls.Add(this.ovTXT_Fator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovCMB_UnidadeSaida);
            this.Controls.Add(this.ovCMB_UnidadeEntrada);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_ConversaoUM";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Conversão de Unidade de Medida";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_ConversaoUM_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox ovCMB_UnidadeEntrada;
        private MetroFramework.Controls.MetroComboBox ovCMB_UnidadeSaida;
        private System.Windows.Forms.Label label4;
        private UTIL.Components.Custom.EditDecimal ovTXT_Fator;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodProduto;
        private System.Windows.Forms.MaskedTextBox ovTXT_Produto;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private MetroFramework.Controls.MetroComboBox ovCMB_Calculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtCodFornecedor;
        private System.Windows.Forms.MaskedTextBox txtFornecedor;
        private System.Windows.Forms.Button btnSelecionarFornecedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtProdutoFornecedor;
    }
}