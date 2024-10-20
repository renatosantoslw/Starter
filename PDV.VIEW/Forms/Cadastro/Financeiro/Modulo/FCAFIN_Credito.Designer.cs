namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    partial class FCAFIN_Credito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_Credito));
            this.ovTXT_Historico = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_Valor = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Movimento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_Natureza = new MetroFramework.Controls.MetroComboBox();
            this.ovCMB_ContaBancaria = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Documento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).BeginInit();
            this.SuspendLayout();
            // 
            // ovTXT_Historico
            // 
            this.ovTXT_Historico.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Historico.Location = new System.Drawing.Point(176, 157);
            this.ovTXT_Historico.Name = "ovTXT_Historico";
            this.ovTXT_Historico.Size = new System.Drawing.Size(452, 21);
            this.ovTXT_Historico.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(173, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 146;
            this.label6.Text = "Histórico:";
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Valor.DecimalPlaces = 2;
            this.ovTXT_Valor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Valor.Location = new System.Drawing.Point(26, 230);
            this.ovTXT_Valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.Sigla = "R$";
            this.ovTXT_Valor.Size = new System.Drawing.Size(179, 21);
            this.ovTXT_Valor.TabIndex = 6;
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
            this.label3.Location = new System.Drawing.Point(23, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 145;
            this.label3.Text = "* Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(23, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "* Movimento:";
            // 
            // ovTXT_Movimento
            // 
            this.ovTXT_Movimento.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Movimento.Enabled = false;
            this.ovTXT_Movimento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Movimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Movimento.Location = new System.Drawing.Point(26, 157);
            this.ovTXT_Movimento.Name = "ovTXT_Movimento";
            this.ovTXT_Movimento.Size = new System.Drawing.Size(123, 21);
            this.ovTXT_Movimento.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Natureza:";
            // 
            // ovCMB_Natureza
            // 
            this.ovCMB_Natureza.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Natureza.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Natureza.FormattingEnabled = true;
            this.ovCMB_Natureza.ItemHeight = 19;
            this.ovCMB_Natureza.Location = new System.Drawing.Point(26, 89);
            this.ovCMB_Natureza.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_Natureza.Name = "ovCMB_Natureza";
            this.ovCMB_Natureza.Size = new System.Drawing.Size(378, 25);
            this.ovCMB_Natureza.TabIndex = 2;
            this.ovCMB_Natureza.UseSelectable = true;
            // 
            // ovCMB_ContaBancaria
            // 
            this.ovCMB_ContaBancaria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_ContaBancaria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_ContaBancaria.FormattingEnabled = true;
            this.ovCMB_ContaBancaria.ItemHeight = 19;
            this.ovCMB_ContaBancaria.Location = new System.Drawing.Point(26, 26);
            this.ovCMB_ContaBancaria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_ContaBancaria.Name = "ovCMB_ContaBancaria";
            this.ovCMB_ContaBancaria.Size = new System.Drawing.Size(602, 25);
            this.ovCMB_ContaBancaria.TabIndex = 1;
            this.ovCMB_ContaBancaria.UseSelectable = true;
            // 
            // ovTXT_Documento
            // 
            this.ovTXT_Documento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Documento.Location = new System.Drawing.Point(449, 92);
            this.ovTXT_Documento.Name = "ovTXT_Documento";
            this.ovTXT_Documento.Size = new System.Drawing.Size(179, 21);
            this.ovTXT_Documento.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(23, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "* Portador:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.Location = new System.Drawing.Point(446, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Documento:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(717, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(71, 33);
            this.metroButton4.TabIndex = 148;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(628, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(83, 33);
            this.metroButton5.TabIndex = 147;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCAFIN_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
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
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCAFIN_Credito";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Crédito";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCAFIN_Credito_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Valor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Historico;
        private System.Windows.Forms.Label label6;
        private UTIL.Components.Custom.EditDecimal ovTXT_Valor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ovTXT_Movimento;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_Natureza;
        private MetroFramework.Controls.MetroComboBox ovCMB_ContaBancaria;
        private System.Windows.Forms.MaskedTextBox ovTXT_Documento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}