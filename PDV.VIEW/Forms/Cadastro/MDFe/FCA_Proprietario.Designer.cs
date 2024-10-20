namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    partial class FCA_Proprietario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Proprietario));
            this.ovCMB_UF = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Nome = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CPF = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_CPF = new System.Windows.Forms.Label();
            this.ovCKB_Fisica = new System.Windows.Forms.RadioButton();
            this.ovCKB_Juridica = new System.Windows.Forms.RadioButton();
            this.ovTXT_RNTRC = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_InscricaoEstadual = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CodigoPorto = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label5 = new System.Windows.Forms.Label();
            this.ovCMB_TipoProprietario = new MetroFramework.Controls.MetroComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_CodigoPorto)).BeginInit();
            this.SuspendLayout();
            // 
            // ovCMB_UF
            // 
            this.ovCMB_UF.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_UF.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_UF.FormattingEnabled = true;
            this.ovCMB_UF.ItemHeight = 19;
            this.ovCMB_UF.Location = new System.Drawing.Point(353, 86);
            this.ovCMB_UF.Name = "ovCMB_UF";
            this.ovCMB_UF.Size = new System.Drawing.Size(86, 25);
            this.ovCMB_UF.TabIndex = 6;
            this.ovCMB_UF.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(350, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "* Un. Federativa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(23, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "* Nome:";
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Nome.Location = new System.Drawing.Point(26, 28);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(547, 21);
            this.ovTXT_Nome.TabIndex = 1;
            // 
            // ovTXT_CPF
            // 
            this.ovTXT_CPF.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_CPF.Location = new System.Drawing.Point(26, 150);
            this.ovTXT_CPF.Mask = "###,###,###-##";
            this.ovTXT_CPF.Name = "ovTXT_CPF";
            this.ovTXT_CPF.Size = new System.Drawing.Size(127, 21);
            this.ovTXT_CPF.TabIndex = 7;
            // 
            // ovLBL_CPF
            // 
            this.ovLBL_CPF.AutoSize = true;
            this.ovLBL_CPF.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_CPF.Location = new System.Drawing.Point(23, 131);
            this.ovLBL_CPF.Name = "ovLBL_CPF";
            this.ovLBL_CPF.Size = new System.Drawing.Size(39, 13);
            this.ovLBL_CPF.TabIndex = 41;
            this.ovLBL_CPF.Text = "* CPF:";
            // 
            // ovCKB_Fisica
            // 
            this.ovCKB_Fisica.AutoSize = true;
            this.ovCKB_Fisica.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Fisica.Location = new System.Drawing.Point(582, 30);
            this.ovCKB_Fisica.Name = "ovCKB_Fisica";
            this.ovCKB_Fisica.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Fisica.TabIndex = 2;
            this.ovCKB_Fisica.TabStop = true;
            this.ovCKB_Fisica.Text = "Física";
            this.ovCKB_Fisica.UseVisualStyleBackColor = true;
            this.ovCKB_Fisica.CheckedChanged += new System.EventHandler(this.ovCKB_Fisica_CheckedChanged);
            // 
            // ovCKB_Juridica
            // 
            this.ovCKB_Juridica.AutoSize = true;
            this.ovCKB_Juridica.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Juridica.Location = new System.Drawing.Point(646, 30);
            this.ovCKB_Juridica.Name = "ovCKB_Juridica";
            this.ovCKB_Juridica.Size = new System.Drawing.Size(61, 17);
            this.ovCKB_Juridica.TabIndex = 3;
            this.ovCKB_Juridica.TabStop = true;
            this.ovCKB_Juridica.Text = "Jurídica";
            this.ovCKB_Juridica.UseVisualStyleBackColor = true;
            this.ovCKB_Juridica.CheckedChanged += new System.EventHandler(this.ovCKB_Juridica_CheckedChanged);
            // 
            // ovTXT_RNTRC
            // 
            this.ovTXT_RNTRC.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_RNTRC.Location = new System.Drawing.Point(26, 89);
            this.ovTXT_RNTRC.Name = "ovTXT_RNTRC";
            this.ovTXT_RNTRC.Size = new System.Drawing.Size(127, 21);
            this.ovTXT_RNTRC.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(27, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "RNTC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(178, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "* Insc. Estadual:";
            // 
            // ovTXT_InscricaoEstadual
            // 
            this.ovTXT_InscricaoEstadual.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_InscricaoEstadual.Location = new System.Drawing.Point(181, 89);
            this.ovTXT_InscricaoEstadual.Name = "ovTXT_InscricaoEstadual";
            this.ovTXT_InscricaoEstadual.Size = new System.Drawing.Size(128, 21);
            this.ovTXT_InscricaoEstadual.TabIndex = 5;
            // 
            // ovTXT_CodigoPorto
            // 
            this.ovTXT_CodigoPorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_CodigoPorto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_CodigoPorto.Location = new System.Drawing.Point(181, 151);
            this.ovTXT_CodigoPorto.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.ovTXT_CodigoPorto.Name = "ovTXT_CodigoPorto";
            this.ovTXT_CodigoPorto.Sigla = "CD";
            this.ovTXT_CodigoPorto.Size = new System.Drawing.Size(128, 21);
            this.ovTXT_CodigoPorto.TabIndex = 8;
            this.ovTXT_CodigoPorto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_CodigoPorto.ThousandsSeparator = true;
            this.ovTXT_CodigoPorto.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_CodigoPorto.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_CodigoPorto.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_CodigoPorto.viTamanho = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(178, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Agência Porto:";
            // 
            // ovCMB_TipoProprietario
            // 
            this.ovCMB_TipoProprietario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_TipoProprietario.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_TipoProprietario.FormattingEnabled = true;
            this.ovCMB_TipoProprietario.ItemHeight = 19;
            this.ovCMB_TipoProprietario.Location = new System.Drawing.Point(353, 151);
            this.ovCMB_TipoProprietario.Name = "ovCMB_TipoProprietario";
            this.ovCMB_TipoProprietario.Size = new System.Drawing.Size(156, 25);
            this.ovCMB_TipoProprietario.TabIndex = 9;
            this.ovCMB_TipoProprietario.UseSelectable = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(350, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "* Tipo Proprietário:";
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
            this.metroButton4.TabIndex = 113;
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
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Proprietario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ovCMB_TipoProprietario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_CodigoPorto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_InscricaoEstadual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_RNTRC);
            this.Controls.Add(this.ovCKB_Juridica);
            this.Controls.Add(this.ovCKB_Fisica);
            this.Controls.Add(this.ovCMB_UF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.ovTXT_CPF);
            this.Controls.Add(this.ovLBL_CPF);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 648);
            this.Name = "FCA_Proprietario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Proprietário";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Proprietario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_CodigoPorto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ovCMB_UF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Nome;
        private System.Windows.Forms.MaskedTextBox ovTXT_CPF;
        private System.Windows.Forms.Label ovLBL_CPF;
        private System.Windows.Forms.RadioButton ovCKB_Fisica;
        private System.Windows.Forms.RadioButton ovCKB_Juridica;
        private System.Windows.Forms.MaskedTextBox ovTXT_RNTRC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox ovTXT_InscricaoEstadual;
        private UTIL.Components.Custom.EditDecimal ovTXT_CodigoPorto;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroComboBox ovCMB_TipoProprietario;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}