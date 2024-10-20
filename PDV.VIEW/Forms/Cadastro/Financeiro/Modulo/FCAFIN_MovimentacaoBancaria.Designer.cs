namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    partial class FCAFIN_MovimentacaoBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_MovimentacaoBancaria));
            this.ovCMB_ContaBancaria = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Documento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ovTXT_Sequencia = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label5 = new System.Windows.Forms.Label();
            this.ovCMB_Natureza = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Movimento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Valor = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Historico = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ovCKB_Credito = new System.Windows.Forms.RadioButton();
            this.ovCKB_Debito = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Sequencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // ovCMB_ContaBancaria
            // 
            this.ovCMB_ContaBancaria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_ContaBancaria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_ContaBancaria.FormattingEnabled = true;
            this.ovCMB_ContaBancaria.ItemHeight = 19;
            this.ovCMB_ContaBancaria.Location = new System.Drawing.Point(26, 29);
            this.ovCMB_ContaBancaria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_ContaBancaria.Name = "ovCMB_ContaBancaria";
            this.ovCMB_ContaBancaria.Size = new System.Drawing.Size(607, 25);
            this.ovCMB_ContaBancaria.TabIndex = 1;
            this.ovCMB_ContaBancaria.UseSelectable = true;
            // 
            // ovTXT_Documento
            // 
            this.ovTXT_Documento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Documento.Location = new System.Drawing.Point(454, 95);
            this.ovTXT_Documento.Name = "ovTXT_Documento";
            this.ovTXT_Documento.Size = new System.Drawing.Size(179, 21);
            this.ovTXT_Documento.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "* Portador:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.Location = new System.Drawing.Point(451, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 116;
            this.label10.Text = "Documento:";
            // 
            // ovTXT_Sequencia
            // 
            this.ovTXT_Sequencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Sequencia.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Sequencia.Location = new System.Drawing.Point(26, 232);
            this.ovTXT_Sequencia.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ovTXT_Sequencia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Sequencia.Name = "ovTXT_Sequencia";
            this.ovTXT_Sequencia.Sigla = "**";
            this.ovTXT_Sequencia.Size = new System.Drawing.Size(120, 21);
            this.ovTXT_Sequencia.TabIndex = 6;
            this.ovTXT_Sequencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Sequencia.ThousandsSeparator = true;
            this.ovTXT_Sequencia.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Sequencia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Sequencia.vdValorDecimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Sequencia.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Sequencia.viTamanho = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(23, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "* Sequência:";
            // 
            // ovCMB_Natureza
            // 
            this.ovCMB_Natureza.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Natureza.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Natureza.FormattingEnabled = true;
            this.ovCMB_Natureza.ItemHeight = 19;
            this.ovCMB_Natureza.Location = new System.Drawing.Point(26, 95);
            this.ovCMB_Natureza.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_Natureza.Name = "ovCMB_Natureza";
            this.ovCMB_Natureza.Size = new System.Drawing.Size(378, 25);
            this.ovCMB_Natureza.TabIndex = 2;
            this.ovCMB_Natureza.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Natureza:";
            // 
            // ovTXT_Movimento
            // 
            this.ovTXT_Movimento.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Movimento.Enabled = false;
            this.ovTXT_Movimento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Movimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Movimento.Location = new System.Drawing.Point(26, 165);
            this.ovTXT_Movimento.Name = "ovTXT_Movimento";
            this.ovTXT_Movimento.Size = new System.Drawing.Size(123, 21);
            this.ovTXT_Movimento.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(23, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "* Movimento:";
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Valor.Location = new System.Drawing.Point(191, 232);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.Sigla = "R$";
            this.ovTXT_Valor.Size = new System.Drawing.Size(155, 21);
            this.ovTXT_Valor.TabIndex = 7;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(188, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "* Valor:";
            // 
            // ovTXT_Historico
            // 
            this.ovTXT_Historico.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Historico.Location = new System.Drawing.Point(191, 165);
            this.ovTXT_Historico.Name = "ovTXT_Historico";
            this.ovTXT_Historico.Size = new System.Drawing.Size(442, 21);
            this.ovTXT_Historico.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(188, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Histórico:";
            // 
            // ovCKB_Credito
            // 
            this.ovCKB_Credito.AutoSize = true;
            this.ovCKB_Credito.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Credito.Location = new System.Drawing.Point(431, 232);
            this.ovCKB_Credito.Name = "ovCKB_Credito";
            this.ovCKB_Credito.Size = new System.Drawing.Size(60, 17);
            this.ovCKB_Credito.TabIndex = 8;
            this.ovCKB_Credito.TabStop = true;
            this.ovCKB_Credito.Text = "Crédito";
            this.ovCKB_Credito.UseVisualStyleBackColor = true;
            this.ovCKB_Credito.CheckedChanged += new System.EventHandler(this.ovCKB_Credito_CheckedChanged);
            // 
            // ovCKB_Debito
            // 
            this.ovCKB_Debito.AutoSize = true;
            this.ovCKB_Debito.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Debito.Location = new System.Drawing.Point(507, 232);
            this.ovCKB_Debito.Name = "ovCKB_Debito";
            this.ovCKB_Debito.Size = new System.Drawing.Size(56, 17);
            this.ovCKB_Debito.TabIndex = 9;
            this.ovCKB_Debito.TabStop = true;
            this.ovCKB_Debito.Text = "Débito";
            this.ovCKB_Debito.UseVisualStyleBackColor = true;
            this.ovCKB_Debito.CheckedChanged += new System.EventHandler(this.ovCKB_Debito_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(429, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 128;
            this.label7.Text = "* Tipo:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(700, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 130;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(606, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 129;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCAFIN_MovimentacaoBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ovCKB_Debito);
            this.Controls.Add(this.ovCKB_Credito);
            this.Controls.Add(this.ovTXT_Historico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ovTXT_Valor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_Movimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCMB_Natureza);
            this.Controls.Add(this.ovCMB_ContaBancaria);
            this.Controls.Add(this.ovTXT_Documento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ovTXT_Sequencia);
            this.Controls.Add(this.label5);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCAFIN_MovimentacaoBancaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Movimentação Bancária";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCAFIN_MovimentacaoBancaria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Sequencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox ovCMB_ContaBancaria;
        private System.Windows.Forms.MaskedTextBox ovTXT_Documento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private UTIL.Components.Custom.EditDecimal ovTXT_Sequencia;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroComboBox ovCMB_Natureza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ovTXT_Movimento;
        private System.Windows.Forms.Label label2;
        private UTIL.Components.Custom.EditDecimal ovTXT_Valor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Historico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton ovCKB_Credito;
        private System.Windows.Forms.RadioButton ovCKB_Debito;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}