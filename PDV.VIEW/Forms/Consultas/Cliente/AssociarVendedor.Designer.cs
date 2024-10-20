namespace PDV.VIEW.Forms.Consultas
{
    partial class AssociarVendedorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssociarVendedorForm));
            this.selecionarSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selecionarSimpleButton
            // 
            this.selecionarSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selecionarSimpleButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.selecionarSimpleButton.Appearance.Options.UseForeColor = true;
            this.selecionarSimpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("selecionarSimpleButton.ImageOptions.Image")));
            this.selecionarSimpleButton.Location = new System.Drawing.Point(382, 123);
            this.selecionarSimpleButton.Name = "selecionarSimpleButton";
            this.selecionarSimpleButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.selecionarSimpleButton.Size = new System.Drawing.Size(104, 33);
            this.selecionarSimpleButton.TabIndex = 112;
            this.selecionarSimpleButton.Text = "Salvar";
            this.selecionarSimpleButton.Click += new System.EventHandler(this.selecionarSimpleButton_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(272, 123);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(104, 33);
            this.simpleButton1.TabIndex = 113;
            this.simpleButton1.Text = "Cancelar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(279, 21);
            this.comboBox1.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Vendedor";
            // 
            // AssociarVendedorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 168);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.selecionarSimpleButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "AssociarVendedorForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Associar Vendedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton selecionarSimpleButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}