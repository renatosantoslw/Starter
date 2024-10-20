namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_DamfeMDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_DamfeMDFe));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ovCKB_ExibirCaixaDialogo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_NomeImpressora = new System.Windows.Forms.TextBox();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ovCKB_ExibirCaixaDialogo);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.ovTXT_NomeImpressora);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(23, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(396, 92);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Impressora";
            // 
            // ovCKB_ExibirCaixaDialogo
            // 
            this.ovCKB_ExibirCaixaDialogo.AutoSize = true;
            this.ovCKB_ExibirCaixaDialogo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_ExibirCaixaDialogo.Location = new System.Drawing.Point(19, 59);
            this.ovCKB_ExibirCaixaDialogo.Name = "ovCKB_ExibirCaixaDialogo";
            this.ovCKB_ExibirCaixaDialogo.Size = new System.Drawing.Size(157, 20);
            this.ovCKB_ExibirCaixaDialogo.TabIndex = 7;
            this.ovCKB_ExibirCaixaDialogo.Text = "Exibir Caixa de Dialogo";
            this.ovCKB_ExibirCaixaDialogo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.Location = new System.Drawing.Point(16, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome:";
            // 
            // ovTXT_NomeImpressora
            // 
            this.ovTXT_NomeImpressora.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.ovTXT_NomeImpressora.Location = new System.Drawing.Point(70, 28);
            this.ovTXT_NomeImpressora.Name = "ovTXT_NomeImpressora";
            this.ovTXT_NomeImpressora.Size = new System.Drawing.Size(313, 23);
            this.ovTXT_NomeImpressora.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(366, 116);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(64, 33);
            this.metroButton1.TabIndex = 117;
            this.metroButton1.Text = "Salvar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(292, 116);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(67, 33);
            this.metroButton2.TabIndex = 116;
            this.metroButton2.Text = "Cancelar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // FCONFIG_DamfeMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 161);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 193);
            this.Name = "FCONFIG_DamfeMDFe";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão Danfe MDF-e";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ovCKB_ExibirCaixaDialogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_NomeImpressora;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
    }
}