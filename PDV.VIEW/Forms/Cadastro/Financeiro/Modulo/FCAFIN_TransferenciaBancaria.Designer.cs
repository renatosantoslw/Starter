namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    partial class FCAFIN_TransferenciaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_TransferenciaBancaria));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovCMB_NaturezaDestino = new MetroFramework.Controls.MetroComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ovCMB_ContaDestino = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_ContaOrigem = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCMB_NaturezaOrigem = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovTXT_Historico = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_Movimento = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Valor = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_Documento = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovCMB_NaturezaDestino);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ovCMB_ContaDestino);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovCMB_ContaOrigem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ovCMB_NaturezaOrigem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 270);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origem/Destino";
            // 
            // ovCMB_NaturezaDestino
            // 
            this.ovCMB_NaturezaDestino.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_NaturezaDestino.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_NaturezaDestino.FormattingEnabled = true;
            this.ovCMB_NaturezaDestino.ItemHeight = 19;
            this.ovCMB_NaturezaDestino.Location = new System.Drawing.Point(9, 220);
            this.ovCMB_NaturezaDestino.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_NaturezaDestino.Name = "ovCMB_NaturezaDestino";
            this.ovCMB_NaturezaDestino.Size = new System.Drawing.Size(584, 25);
            this.ovCMB_NaturezaDestino.TabIndex = 4;
            this.ovCMB_NaturezaDestino.UseSelectable = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(6, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 123;
            this.label7.Text = "Natureza de Destino:";
            // 
            // ovCMB_ContaDestino
            // 
            this.ovCMB_ContaDestino.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_ContaDestino.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_ContaDestino.FormattingEnabled = true;
            this.ovCMB_ContaDestino.ItemHeight = 19;
            this.ovCMB_ContaDestino.Location = new System.Drawing.Point(9, 158);
            this.ovCMB_ContaDestino.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_ContaDestino.Name = "ovCMB_ContaDestino";
            this.ovCMB_ContaDestino.Size = new System.Drawing.Size(584, 25);
            this.ovCMB_ContaDestino.TabIndex = 3;
            this.ovCMB_ContaDestino.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "* Conta de Destino:";
            // 
            // ovCMB_ContaOrigem
            // 
            this.ovCMB_ContaOrigem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_ContaOrigem.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_ContaOrigem.FormattingEnabled = true;
            this.ovCMB_ContaOrigem.ItemHeight = 19;
            this.ovCMB_ContaOrigem.Location = new System.Drawing.Point(9, 38);
            this.ovCMB_ContaOrigem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_ContaOrigem.Name = "ovCMB_ContaOrigem";
            this.ovCMB_ContaOrigem.Size = new System.Drawing.Size(584, 25);
            this.ovCMB_ContaOrigem.TabIndex = 1;
            this.ovCMB_ContaOrigem.UseSelectable = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "* Conta de Origem:";
            // 
            // ovCMB_NaturezaOrigem
            // 
            this.ovCMB_NaturezaOrigem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_NaturezaOrigem.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_NaturezaOrigem.FormattingEnabled = true;
            this.ovCMB_NaturezaOrigem.ItemHeight = 19;
            this.ovCMB_NaturezaOrigem.Location = new System.Drawing.Point(9, 99);
            this.ovCMB_NaturezaOrigem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_NaturezaOrigem.Name = "ovCMB_NaturezaOrigem";
            this.ovCMB_NaturezaOrigem.Size = new System.Drawing.Size(584, 25);
            this.ovCMB_NaturezaOrigem.TabIndex = 2;
            this.ovCMB_NaturezaOrigem.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 121;
            this.label3.Text = "Natureza de Origem:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ovTXT_Historico);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ovTXT_Movimento);
            this.groupBox2.Controls.Add(this.ovTXT_Valor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ovTXT_Documento);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(23, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 191);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações da Transferência";
            // 
            // ovTXT_Historico
            // 
            this.ovTXT_Historico.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Historico.Location = new System.Drawing.Point(9, 48);
            this.ovTXT_Historico.Name = "ovTXT_Historico";
            this.ovTXT_Historico.Size = new System.Drawing.Size(584, 21);
            this.ovTXT_Historico.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 128;
            this.label6.Text = "* Movimento:";
            // 
            // ovTXT_Movimento
            // 
            this.ovTXT_Movimento.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Movimento.Enabled = false;
            this.ovTXT_Movimento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Movimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Movimento.Location = new System.Drawing.Point(9, 113);
            this.ovTXT_Movimento.Name = "ovTXT_Movimento";
            this.ovTXT_Movimento.Size = new System.Drawing.Size(122, 21);
            this.ovTXT_Movimento.TabIndex = 6;
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_Valor.Location = new System.Drawing.Point(435, 112);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.Sigla = "R$";
            this.ovTXT_Valor.Size = new System.Drawing.Size(158, 27);
            this.ovTXT_Valor.TabIndex = 8;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(432, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "* Valor:";
            // 
            // ovTXT_Documento
            // 
            this.ovTXT_Documento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Documento.Location = new System.Drawing.Point(180, 113);
            this.ovTXT_Documento.Name = "ovTXT_Documento";
            this.ovTXT_Documento.Size = new System.Drawing.Size(206, 23);
            this.ovTXT_Documento.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.Location = new System.Drawing.Point(177, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Histórico:";
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton6.Appearance.Options.UseForeColor = true;
            this.metroButton6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton6.ImageOptions.Image")));
            this.metroButton6.Location = new System.Drawing.Point(717, 555);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton6.Size = new System.Drawing.Size(71, 33);
            this.metroButton6.TabIndex = 113;
            this.metroButton6.Text = "Salvar";
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(627, 555);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(84, 33);
            this.metroButton3.TabIndex = 112;
            this.metroButton3.Text = "Cancelar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // FCAFIN_TransferenciaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCAFIN_TransferenciaBancaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Transferência Bancária";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCAFIN_TransferenciaBancaria_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroComboBox ovCMB_ContaOrigem;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox ovCMB_ContaDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroComboBox ovCMB_NaturezaOrigem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UTIL.Components.Custom.EditDecimal ovTXT_Valor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox ovTXT_Documento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ovTXT_Movimento;
        private System.Windows.Forms.MaskedTextBox ovTXT_Historico;
        private MetroFramework.Controls.MetroComboBox ovCMB_NaturezaDestino;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton metroButton6;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
    }
}