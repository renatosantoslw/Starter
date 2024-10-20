namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Comanda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Comanda));
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Codigo = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(162, 26);
            this.ovTXT_Descricao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(273, 21);
            this.ovTXT_Descricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(159, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Codigo.Location = new System.Drawing.Point(26, 26);
            this.ovTXT_Codigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Codigo.Mask = "##############";
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.Size = new System.Drawing.Size(80, 21);
            this.ovTXT_Codigo.TabIndex = 1;
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(23, 9);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(53, 13);
            this.ovLBL_RazaoSocial.TabIndex = 23;
            this.ovLBL_RazaoSocial.Text = "* Código:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(406, 125);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(66, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(324, 125);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(76, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Comanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_Comanda";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Comanda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Comanda_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}