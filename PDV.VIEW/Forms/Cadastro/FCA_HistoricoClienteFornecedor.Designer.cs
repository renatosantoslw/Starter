namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_HistoricoClienteFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_HistoricoClienteFornecedor));
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovTXT_Assunto = new System.Windows.Forms.TextBox();
            this.ovTXT_Observacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_DataHora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(23, 9);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(59, 13);
            this.ovLBL_RazaoSocial.TabIndex = 28;
            this.ovLBL_RazaoSocial.Text = "* Assunto:";
            // 
            // ovTXT_Assunto
            // 
            this.ovTXT_Assunto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Assunto.Location = new System.Drawing.Point(26, 29);
            this.ovTXT_Assunto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Assunto.Name = "ovTXT_Assunto";
            this.ovTXT_Assunto.Size = new System.Drawing.Size(498, 21);
            this.ovTXT_Assunto.TabIndex = 1;
            // 
            // ovTXT_Observacao
            // 
            this.ovTXT_Observacao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Observacao.Location = new System.Drawing.Point(26, 95);
            this.ovTXT_Observacao.Multiline = true;
            this.ovTXT_Observacao.Name = "ovTXT_Observacao";
            this.ovTXT_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovTXT_Observacao.Size = new System.Drawing.Size(751, 439);
            this.ovTXT_Observacao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Observação:";
            // 
            // ovTXT_DataHora
            // 
            this.ovTXT_DataHora.Enabled = false;
            this.ovTXT_DataHora.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_DataHora.Location = new System.Drawing.Point(552, 29);
            this.ovTXT_DataHora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_DataHora.Name = "ovTXT_DataHora";
            this.ovTXT_DataHora.ReadOnly = true;
            this.ovTXT_DataHora.Size = new System.Drawing.Size(206, 21);
            this.ovTXT_DataHora.TabIndex = 2;
            this.ovTXT_DataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(549, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Data/Hora Histórico:";
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
            // FCA_HistoricoClienteFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_DataHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Observacao);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.Controls.Add(this.ovTXT_Assunto);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCA_HistoricoClienteFornecedor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Histórico";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_HistoricoClienteFornecedor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.TextBox ovTXT_Assunto;
        private System.Windows.Forms.TextBox ovTXT_Observacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_DataHora;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}