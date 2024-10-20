namespace PDV.VIEW.Forms.Configuracoes
{
    partial class ModeloImpressaoDav
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeloImpressaoDav));
            this.buttonImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Appearance.ForeColor = System.Drawing.Color.Black;
            this.buttonImprimir.Appearance.Options.UseForeColor = true;
            this.buttonImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.ImageOptions.Image")));
            this.buttonImprimir.Location = new System.Drawing.Point(314, 95);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonImprimir.Size = new System.Drawing.Size(79, 33);
            this.buttonImprimir.TabIndex = 132;
            this.buttonImprimir.Text = "Salvar";
            this.buttonImprimir.Click += new System.EventHandler(this.Salvar);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelar.Appearance.Options.UseForeColor = true;
            this.buttonCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.ImageOptions.Image")));
            this.buttonCancelar.Location = new System.Drawing.Point(232, 95);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.buttonCancelar.Size = new System.Drawing.Size(76, 33);
            this.buttonCancelar.TabIndex = 133;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // comboModelo
            // 
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Items.AddRange(new object[] {
            "Modelo 1",
            "Modelo 1 duas vias",
            "Modelo 2 ",
            "Modelo 2 duas vias",
            "Modelo 3",
            "Modelo 3 unidade"});
            this.comboModelo.Location = new System.Drawing.Point(23, 34);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(329, 21);
            this.comboModelo.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 137;
            this.label1.Text = "Escolha um modelo";
            // 
            // ModeloImpressaoDav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 148);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboModelo);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonImprimir);
            this.Name = "ModeloImpressaoDav";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão de Venda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonImprimir;
        private DevExpress.XtraEditors.SimpleButton buttonCancelar;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.Label label1;
    }
}