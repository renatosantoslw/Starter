namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    partial class FCA_Condutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Condutor));
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Nome = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CPF = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_UF = new MetroFramework.Controls.MetroComboBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_Ativo.Location = new System.Drawing.Point(394, 94);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 4;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "* Nome:";
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Nome.Location = new System.Drawing.Point(35, 92);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(344, 21);
            this.ovTXT_Nome.TabIndex = 3;
            // 
            // ovTXT_CPF
            // 
            this.ovTXT_CPF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CPF.Location = new System.Drawing.Point(35, 28);
            this.ovTXT_CPF.Mask = "###,###,###-##";
            this.ovTXT_CPF.Name = "ovTXT_CPF";
            this.ovTXT_CPF.Size = new System.Drawing.Size(155, 21);
            this.ovTXT_CPF.TabIndex = 1;
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(32, 9);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(39, 13);
            this.ovLBL_RazaoSocial.TabIndex = 32;
            this.ovLBL_RazaoSocial.Text = "* CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "* UF:";
            // 
            // ovCMB_UF
            // 
            this.ovCMB_UF.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_UF.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_UF.FormattingEnabled = true;
            this.ovCMB_UF.ItemHeight = 19;
            this.ovCMB_UF.Location = new System.Drawing.Point(35, 156);
            this.ovCMB_UF.Name = "ovCMB_UF";
            this.ovCMB_UF.Size = new System.Drawing.Size(281, 25);
            this.ovCMB_UF.TabIndex = 2;
            this.ovCMB_UF.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(384, 216);
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
            this.metroButton5.Location = new System.Drawing.Point(290, 216);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Condutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovCMB_UF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.ovTXT_CPF);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 309);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 309);
            this.Name = "FCA_Condutor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Condutor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Condutor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Nome;
        private System.Windows.Forms.MaskedTextBox ovTXT_CPF;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_UF;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}