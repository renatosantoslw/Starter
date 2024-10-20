namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_ConsultaStatusWS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_ConsultaStatusWS));
            this.RtbRetornoCompletoStr = new System.Windows.Forms.Label();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // RtbRetornoCompletoStr
            // 
            this.RtbRetornoCompletoStr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbRetornoCompletoStr.BackColor = System.Drawing.SystemColors.Window;
            this.RtbRetornoCompletoStr.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtbRetornoCompletoStr.Location = new System.Drawing.Point(23, 60);
            this.RtbRetornoCompletoStr.Name = "RtbRetornoCompletoStr";
            this.RtbRetornoCompletoStr.Size = new System.Drawing.Size(754, 479);
            this.RtbRetornoCompletoStr.TabIndex = 16;
            this.RtbRetornoCompletoStr.Text = "...";
            this.RtbRetornoCompletoStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(700, 555);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 117;
            this.metroButton1.Text = "Consultar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(606, 555);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 116;
            this.metroButton2.Text = "Cancelar";
            this.metroButton2.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(450, 555);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(135, 33);
            this.simpleButton1.TabIndex = 118;
            this.simpleButton1.Text = "Atualizar API NFe";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FCONFIG_ConsultaStatusWS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.RtbRetornoCompletoStr);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCONFIG_ConsultaStatusWS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Status Sefaz";
            this.Load += new System.EventHandler(this.FCONFIG_ConsultaStatusWS_Load);
            this.Shown += new System.EventHandler(this.FCONFIG_ConsultaStatusWS_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label RtbRetornoCompletoStr;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}