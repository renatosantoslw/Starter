namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    partial class FCAFIN_ChequePagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_ChequePagamento));
            this.ovTXT_Vencimento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ovCKB_Cruzado = new System.Windows.Forms.CheckBox();
            this.ovTXT_Numero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Emissao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Compensado = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Devolvido = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCMB_Talonario = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Valor = new PDV.UTIL.Components.Custom.EditDecimal();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // ovTXT_Vencimento
            // 
            this.ovTXT_Vencimento.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Vencimento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Vencimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Vencimento.Location = new System.Drawing.Point(345, 38);
            this.ovTXT_Vencimento.Name = "ovTXT_Vencimento";
            this.ovTXT_Vencimento.Size = new System.Drawing.Size(122, 21);
            this.ovTXT_Vencimento.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(264, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "* Vencimento:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.Location = new System.Drawing.Point(548, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 88;
            this.label15.Text = "* Valor:";
            // 
            // ovCKB_Cruzado
            // 
            this.ovCKB_Cruzado.AutoSize = true;
            this.ovCKB_Cruzado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Cruzado.Location = new System.Drawing.Point(716, 10);
            this.ovCKB_Cruzado.Name = "ovCKB_Cruzado";
            this.ovCKB_Cruzado.Size = new System.Drawing.Size(66, 17);
            this.ovCKB_Cruzado.TabIndex = 3;
            this.ovCKB_Cruzado.Text = "Cruzado";
            this.ovCKB_Cruzado.UseVisualStyleBackColor = true;
            // 
            // ovTXT_Numero
            // 
            this.ovTXT_Numero.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Numero.Location = new System.Drawing.Point(106, 7);
            this.ovTXT_Numero.MaxLength = 11;
            this.ovTXT_Numero.Name = "ovTXT_Numero";
            this.ovTXT_Numero.Size = new System.Drawing.Size(361, 21);
            this.ovTXT_Numero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "* Número:";
            // 
            // ovTXT_Emissao
            // 
            this.ovTXT_Emissao.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Emissao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Emissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Emissao.Location = new System.Drawing.Point(106, 38);
            this.ovTXT_Emissao.Name = "ovTXT_Emissao";
            this.ovTXT_Emissao.Size = new System.Drawing.Size(125, 21);
            this.ovTXT_Emissao.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "* Emissão:";
            // 
            // ovTXT_Compensado
            // 
            this.ovTXT_Compensado.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Compensado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Compensado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Compensado.Location = new System.Drawing.Point(627, 40);
            this.ovTXT_Compensado.Name = "ovTXT_Compensado";
            this.ovTXT_Compensado.ShowCheckBox = true;
            this.ovTXT_Compensado.Size = new System.Drawing.Size(150, 21);
            this.ovTXT_Compensado.TabIndex = 6;
            // 
            // ovTXT_Devolvido
            // 
            this.ovTXT_Devolvido.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Devolvido.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Devolvido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Devolvido.Location = new System.Drawing.Point(627, 74);
            this.ovTXT_Devolvido.Name = "ovTXT_Devolvido";
            this.ovTXT_Devolvido.ShowCheckBox = true;
            this.ovTXT_Devolvido.Size = new System.Drawing.Size(150, 21);
            this.ovTXT_Devolvido.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(548, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "Compensado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(550, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Devolvido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(30, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Talonário:";
            // 
            // ovCMB_Talonario
            // 
            this.ovCMB_Talonario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Talonario.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Talonario.FormattingEnabled = true;
            this.ovCMB_Talonario.ItemHeight = 19;
            this.ovCMB_Talonario.Location = new System.Drawing.Point(106, 73);
            this.ovCMB_Talonario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_Talonario.Name = "ovCMB_Talonario";
            this.ovCMB_Talonario.Size = new System.Drawing.Size(361, 25);
            this.ovCMB_Talonario.TabIndex = 113;
            this.ovCMB_Talonario.UseSelectable = true;
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Valor.Location = new System.Drawing.Point(598, 6);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.Sigla = "R$";
            this.ovTXT_Valor.Size = new System.Drawing.Size(112, 21);
            this.ovTXT_Valor.TabIndex = 2;
            this.ovTXT_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Valor.ThousandsSeparator = true;
            this.ovTXT_Valor.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Valor.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Valor.viPrecisao = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ovTXT_Valor.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(716, 202);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(72, 33);
            this.metroButton4.TabIndex = 115;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(622, 202);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 114;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCAFIN_ChequePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 247);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_Valor);
            this.Controls.Add(this.ovCMB_Talonario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_Devolvido);
            this.Controls.Add(this.ovTXT_Compensado);
            this.Controls.Add(this.ovTXT_Emissao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Numero);
            this.Controls.Add(this.ovCKB_Cruzado);
            this.Controls.Add(this.ovTXT_Vencimento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCAFIN_ChequePagamento";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Pagamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCAFIN_ChequePagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker ovTXT_Vencimento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ovCKB_Cruzado;
        private System.Windows.Forms.TextBox ovTXT_Numero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ovTXT_Emissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ovTXT_Compensado;
        private System.Windows.Forms.DateTimePicker ovTXT_Devolvido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox ovCMB_Talonario;
        private UTIL.Components.Custom.EditDecimal ovTXT_Valor;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}