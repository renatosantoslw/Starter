namespace PDV.VIEW.Forms.Relatorios
{
    partial class FREL_ImpressaoComandas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FREL_ImpressaoComandas));
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_CodigoInicial = new System.Windows.Forms.TextBox();
            this.ovTXT_CodigoFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "* De:";
            // 
            // ovTXT_CodigoInicial
            // 
            this.ovTXT_CodigoInicial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoInicial.Location = new System.Drawing.Point(69, 9);
            this.ovTXT_CodigoInicial.Name = "ovTXT_CodigoInicial";
            this.ovTXT_CodigoInicial.Size = new System.Drawing.Size(100, 23);
            this.ovTXT_CodigoInicial.TabIndex = 27;
            // 
            // ovTXT_CodigoFinal
            // 
            this.ovTXT_CodigoFinal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodigoFinal.Location = new System.Drawing.Point(226, 9);
            this.ovTXT_CodigoFinal.Name = "ovTXT_CodigoFinal";
            this.ovTXT_CodigoFinal.Size = new System.Drawing.Size(100, 23);
            this.ovTXT_CodigoFinal.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(175, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "* Até:";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(356, 116);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(116, 33);
            this.metroButton1.TabIndex = 119;
            this.metroButton1.Text = "Gerar Relatório";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(234, 116);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(116, 33);
            this.metroButton5.TabIndex = 118;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FREL_ImpressaoComandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_CodigoFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_CodigoInicial);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FREL_ImpressaoComandas";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão de Comandas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_CodigoInicial;
        private System.Windows.Forms.TextBox ovTXT_CodigoFinal;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}