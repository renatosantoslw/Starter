namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_UnidadeMedida
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
            this.ovTXT_Sigla = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovTXT_Sigla
            // 
            this.ovTXT_Sigla.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Sigla.Location = new System.Drawing.Point(15, 28);
            this.ovTXT_Sigla.Mask = "AAAA";
            this.ovTXT_Sigla.Name = "ovTXT_Sigla";
            this.ovTXT_Sigla.Size = new System.Drawing.Size(100, 21);
            this.ovTXT_Sigla.TabIndex = 1;
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(193, 28);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(258, 21);
            this.ovTXT_Descricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(184, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Descrição:";
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(6, 9);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(42, 13);
            this.ovLBL_RazaoSocial.TabIndex = 3;
            this.ovLBL_RazaoSocial.Text = "* Sigla:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Appearance.Options.UseTextOptions = true;
            this.metroButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.metroButton4.Location = new System.Drawing.Point(290, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(85, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.Appearance.Options.UseTextOptions = true;
            this.metroButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.metroButton3.Location = new System.Drawing.Point(386, 116);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(85, 33);
            this.metroButton3.TabIndex = 112;
            this.metroButton3.Text = "Cancelar";
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // FCA_UnidadeMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovTXT_Sigla);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 209);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 193);
            this.Name = "FCA_UnidadeMedida";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Unidade de Medida";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_UnidadeMedida_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Sigla;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
    }
}