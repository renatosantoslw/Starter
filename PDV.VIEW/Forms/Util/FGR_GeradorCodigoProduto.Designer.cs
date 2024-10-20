namespace PDV.VIEW.Forms.Util
{
    partial class FGR_GeradorCodigoProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGR_GeradorCodigoProduto));
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_CodigoPais = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CodigoFabrica = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CodigoProduto = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_DigitoChecksum = new System.Windows.Forms.MaskedTextBox();
            this.ovCMB_Codigos = new MetroFramework.Controls.MetroComboBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(27, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 21);
            this.label18.TabIndex = 14;
            this.label18.Text = "* Codigo do País:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "* Codigo da Fabrica:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "* Codigo do Produto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "* Dígito Checksum:";
            // 
            // ovTXT_CodigoPais
            // 
            this.ovTXT_CodigoPais.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoPais.Location = new System.Drawing.Point(199, 11);
            this.ovTXT_CodigoPais.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_CodigoPais.Name = "ovTXT_CodigoPais";
            this.ovTXT_CodigoPais.Size = new System.Drawing.Size(58, 27);
            this.ovTXT_CodigoPais.TabIndex = 18;
            // 
            // ovTXT_CodigoFabrica
            // 
            this.ovTXT_CodigoFabrica.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoFabrica.Location = new System.Drawing.Point(198, 49);
            this.ovTXT_CodigoFabrica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_CodigoFabrica.Name = "ovTXT_CodigoFabrica";
            this.ovTXT_CodigoFabrica.Size = new System.Drawing.Size(189, 27);
            this.ovTXT_CodigoFabrica.TabIndex = 19;
            this.ovTXT_CodigoFabrica.Text = "0000001";
            // 
            // ovTXT_CodigoProduto
            // 
            this.ovTXT_CodigoProduto.Enabled = false;
            this.ovTXT_CodigoProduto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoProduto.Location = new System.Drawing.Point(198, 87);
            this.ovTXT_CodigoProduto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_CodigoProduto.Name = "ovTXT_CodigoProduto";
            this.ovTXT_CodigoProduto.ReadOnly = true;
            this.ovTXT_CodigoProduto.Size = new System.Drawing.Size(189, 27);
            this.ovTXT_CodigoProduto.TabIndex = 20;
            // 
            // ovTXT_DigitoChecksum
            // 
            this.ovTXT_DigitoChecksum.Enabled = false;
            this.ovTXT_DigitoChecksum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DigitoChecksum.Location = new System.Drawing.Point(198, 126);
            this.ovTXT_DigitoChecksum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_DigitoChecksum.Name = "ovTXT_DigitoChecksum";
            this.ovTXT_DigitoChecksum.ReadOnly = true;
            this.ovTXT_DigitoChecksum.Size = new System.Drawing.Size(59, 27);
            this.ovTXT_DigitoChecksum.TabIndex = 21;
            // 
            // ovCMB_Codigos
            // 
            this.ovCMB_Codigos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Codigos.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Codigos.FormattingEnabled = true;
            this.ovCMB_Codigos.ItemHeight = 21;
            this.ovCMB_Codigos.Items.AddRange(new object[] {
            "CNPJ",
            "CPF"});
            this.ovCMB_Codigos.Location = new System.Drawing.Point(265, 11);
            this.ovCMB_Codigos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_Codigos.Name = "ovCMB_Codigos";
            this.ovCMB_Codigos.Size = new System.Drawing.Size(314, 27);
            this.ovCMB_Codigos.TabIndex = 74;
            this.ovCMB_Codigos.UseSelectable = true;
            this.ovCMB_Codigos.SelectedIndexChanged += new System.EventHandler(this.ovCMB_Codigos_SelectedIndexChanged);
            // 
            // picBarcode
            // 
            this.picBarcode.BackColor = System.Drawing.Color.Transparent;
            this.picBarcode.Location = new System.Drawing.Point(199, 164);
            this.picBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(380, 233);
            this.picBarcode.TabIndex = 73;
            this.picBarcode.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(395, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "No Máximo 7 Digitos.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label5.Location = new System.Drawing.Point(27, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 162);
            this.label5.TabIndex = 77;
            this.label5.Text = "Código de Barras:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(479, 425);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(113, 41);
            this.metroButton4.TabIndex = 137;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(359, 425);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(113, 41);
            this.metroButton5.TabIndex = 136;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(421, 81);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(141, 41);
            this.metroButton1.TabIndex = 138;
            this.metroButton1.Text = "Gerar Código";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // FGR_GeradorCodigoProduto
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 478);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovCMB_Codigos);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.ovTXT_DigitoChecksum);
            this.Controls.Add(this.ovTXT_CodigoProduto);
            this.Controls.Add(this.ovTXT_CodigoFabrica);
            this.Controls.Add(this.ovTXT_CodigoPais);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(536, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 422);
            this.Name = "FGR_GeradorCodigoProduto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Código de Barras";
            this.Load += new System.EventHandler(this.FGR_GeradorCodigoProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodigoPais;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodigoFabrica;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodigoProduto;
        private System.Windows.Forms.MaskedTextBox ovTXT_DigitoChecksum;
        private System.Windows.Forms.PictureBox picBarcode;
        private MetroFramework.Controls.MetroComboBox ovCMB_Codigos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}