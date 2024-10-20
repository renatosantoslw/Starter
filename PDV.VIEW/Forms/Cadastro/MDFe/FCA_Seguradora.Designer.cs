namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    partial class FCA_Seguradora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Seguradora));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CNPJ = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Descricao.Location = new System.Drawing.Point(35, 94);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(233, 21);
            this.ovTXT_Descricao.TabIndex = 3;
            // 
            // ovTXT_CNPJ
            // 
            this.ovTXT_CNPJ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CNPJ.Location = new System.Drawing.Point(35, 28);
            this.ovTXT_CNPJ.Mask = "##,###,###/####-##";
            this.ovTXT_CNPJ.Name = "ovTXT_CNPJ";
            this.ovTXT_CNPJ.Size = new System.Drawing.Size(160, 21);
            this.ovTXT_CNPJ.TabIndex = 1;
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(32, 9);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(45, 13);
            this.ovLBL_RazaoSocial.TabIndex = 25;
            this.ovLBL_RazaoSocial.Text = "* CNPJ:";
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_Ativo.Location = new System.Drawing.Point(201, 30);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 2;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(384, 126);
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
            this.metroButton5.Location = new System.Drawing.Point(290, 126);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Seguradora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovTXT_CNPJ);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 209);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 209);
            this.Name = "FCA_Seguradora";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Seguradora";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Seguradora_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.MaskedTextBox ovTXT_CNPJ;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}