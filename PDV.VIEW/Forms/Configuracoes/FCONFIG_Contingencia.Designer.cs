namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_Contingencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_Contingencia));
            this.ovTXT_Justificativa = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_TempoIntervalo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovTXT_Justificativa
            // 
            this.ovTXT_Justificativa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Justificativa.Location = new System.Drawing.Point(6, 24);
            this.ovTXT_Justificativa.Multiline = true;
            this.ovTXT_Justificativa.Name = "ovTXT_Justificativa";
            this.ovTXT_Justificativa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovTXT_Justificativa.Size = new System.Drawing.Size(472, 239);
            this.ovTXT_Justificativa.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ovTXT_TempoIntervalo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor de Envio em Contingência";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label2.Location = new System.Drawing.Point(128, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "milisegundos";
            // 
            // ovTXT_TempoIntervalo
            // 
            this.ovTXT_TempoIntervalo.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.ovTXT_TempoIntervalo.Location = new System.Drawing.Point(21, 46);
            this.ovTXT_TempoIntervalo.Mask = "########";
            this.ovTXT_TempoIntervalo.Name = "ovTXT_TempoIntervalo";
            this.ovTXT_TempoIntervalo.Size = new System.Drawing.Size(101, 23);
            this.ovTXT_TempoIntervalo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Tempo de Intervalo P/ Envio:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ovTXT_Justificativa);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 269);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "* Justificativa Emissão em Contingência";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(430, 385);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
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
            this.metroButton2.Location = new System.Drawing.Point(336, 385);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 116;
            this.metroButton2.Text = "Cancelar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // FCONFIG_Contingencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 430);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(546, 469);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(532, 462);
            this.Name = "FCONFIG_Contingencia";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contingência";
            this.Load += new System.EventHandler(this.FCONFIG_Contingencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox ovTXT_Justificativa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox ovTXT_TempoIntervalo;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
    }
}