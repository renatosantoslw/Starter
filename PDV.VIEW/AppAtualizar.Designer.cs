namespace PDV.VIEW
{
    partial class AppAtualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppAtualizar));
            this.simpleButtonAppForçaVendas = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButtonAppForçaVendas
            // 
            this.simpleButtonAppForçaVendas.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonAppForçaVendas.ImageOptions.SvgImage")));
            this.simpleButtonAppForçaVendas.Location = new System.Drawing.Point(74, 12);
            this.simpleButtonAppForçaVendas.Name = "simpleButtonAppForçaVendas";
            this.simpleButtonAppForçaVendas.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButtonAppForçaVendas.Size = new System.Drawing.Size(225, 36);
            this.simpleButtonAppForçaVendas.TabIndex = 0;
            this.simpleButtonAppForçaVendas.Text = "App Força de Vendas e Estoque";
            this.simpleButtonAppForçaVendas.Click += new System.EventHandler(this.simpleButtonAppForçaVendas_Click);
            // 
            // AppAtualizar
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 93);
            this.Controls.Add(this.simpleButtonAppForçaVendas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppAtualizar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização APP";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonAppForçaVendas;
    }
}