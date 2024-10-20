namespace PDV.VIEW.Forms.Cadastro.Suprimentos
{
    partial class FCA_Requisitante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Requisitante));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_CentroCusto = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Nome = new System.Windows.Forms.TextBox();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "* Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "* Centro de Custo:";
            // 
            // ovCMB_CentroCusto
            // 
            this.ovCMB_CentroCusto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_CentroCusto.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_CentroCusto.FormattingEnabled = true;
            this.ovCMB_CentroCusto.ItemHeight = 19;
            this.ovCMB_CentroCusto.Location = new System.Drawing.Point(12, 90);
            this.ovCMB_CentroCusto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_CentroCusto.Name = "ovCMB_CentroCusto";
            this.ovCMB_CentroCusto.Size = new System.Drawing.Size(265, 25);
            this.ovCMB_CentroCusto.TabIndex = 2;
            this.ovCMB_CentroCusto.UseSelectable = true;
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Nome.Location = new System.Drawing.Point(12, 29);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(265, 21);
            this.ovTXT_Nome.TabIndex = 1;
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(384, 116);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 113;
            this.metroButton3.Text = "Salvar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(290, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 112;
            this.metroButton4.Text = "Cancelar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // FCA_Requisitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCMB_CentroCusto);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(500, 209);
            this.MinimumSize = new System.Drawing.Size(500, 209);
            this.Name = "FCA_Requisitante";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Requisitante";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Requisitante_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_CentroCusto;
        private System.Windows.Forms.TextBox ovTXT_Nome;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
    }
}