namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_FluxoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_FluxoCaixa));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.valorAberturaText = new PDV.UTIL.Components.Custom.EditDecimal();
            this.valorFechamentoText = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valorAberturaText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorFechamentoText)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseFont = true;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(419, 147);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(67, 28);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseFont = true;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(332, 147);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(78, 28);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "* Valor de Abertura";
            // 
            // valorAberturaText
            // 
            this.valorAberturaText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valorAberturaText.DecimalPlaces = 2;
            this.valorAberturaText.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.valorAberturaText.Location = new System.Drawing.Point(27, 25);
            this.valorAberturaText.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.valorAberturaText.Name = "valorAberturaText";
            this.valorAberturaText.Sigla = "R$";
            this.valorAberturaText.Size = new System.Drawing.Size(223, 21);
            this.valorAberturaText.TabIndex = 116;
            this.valorAberturaText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorAberturaText.ThousandsSeparator = true;
            this.valorAberturaText.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.valorAberturaText.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valorAberturaText.viPrecisao = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.valorAberturaText.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // valorFechamentoText
            // 
            this.valorFechamentoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valorFechamentoText.DecimalPlaces = 2;
            this.valorFechamentoText.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.valorFechamentoText.Location = new System.Drawing.Point(27, 78);
            this.valorFechamentoText.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.valorFechamentoText.Name = "valorFechamentoText";
            this.valorFechamentoText.Sigla = "R$";
            this.valorFechamentoText.Size = new System.Drawing.Size(223, 21);
            this.valorFechamentoText.TabIndex = 118;
            this.valorFechamentoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorFechamentoText.ThousandsSeparator = true;
            this.valorFechamentoText.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.valorFechamentoText.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valorFechamentoText.viPrecisao = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.valorFechamentoText.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "* Valor de Fechamento";
            // 
            // FCA_FluxoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 187);
            this.Controls.Add(this.valorFechamentoText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valorAberturaText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_FluxoCaixa";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edição de Fluxo de Caixa";
            ((System.ComponentModel.ISupportInitialize)(this.valorAberturaText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorFechamentoText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.Label label3;
        private UTIL.Components.Custom.EditDecimal valorAberturaText;
        private UTIL.Components.Custom.EditDecimal valorFechamentoText;
        private System.Windows.Forms.Label label1;
    }
}