namespace PDV.VIEW.Forms.Relatorios
{
    partial class FREL_ComandasEmAberto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FREL_ComandasEmAberto));
            this.label2 = new System.Windows.Forms.Label();
            this.ovCMB_Usuario = new MetroFramework.Controls.MetroComboBox();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "* Usuário:";
            // 
            // ovCMB_Usuario
            // 
            this.ovCMB_Usuario.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Usuario.FormattingEnabled = true;
            this.ovCMB_Usuario.ItemHeight = 19;
            this.ovCMB_Usuario.Location = new System.Drawing.Point(102, 15);
            this.ovCMB_Usuario.Name = "ovCMB_Usuario";
            this.ovCMB_Usuario.Size = new System.Drawing.Size(370, 25);
            this.ovCMB_Usuario.TabIndex = 4;
            this.ovCMB_Usuario.UseSelectable = true;
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
            this.metroButton5.TabIndex = 116;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(356, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(116, 33);
            this.metroButton4.TabIndex = 117;
            this.metroButton4.Text = "Gerar Relatório";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // FREL_ComandasEmAberto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovCMB_Usuario);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FREL_ComandasEmAberto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Comandas em Aberto por Usuário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox ovCMB_Usuario;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
    }
}