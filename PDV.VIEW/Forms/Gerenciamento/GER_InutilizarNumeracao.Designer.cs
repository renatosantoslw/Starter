namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_InutilizarNumeracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_InutilizarNumeracao));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_Justificativa = new System.Windows.Forms.TextBox();
            this.ovTXT_Ano = new PDV.UTIL.Components.Custom.EditDecimal();
            this.ovTXT_NumeroInicial = new PDV.UTIL.Components.Custom.EditDecimal();
            this.ovTXT_NumeroFinal = new PDV.UTIL.Components.Custom.EditDecimal();
            this.ovTXT_Serie = new PDV.UTIL.Components.Custom.EditDecimal();
            this.inutilizarNumeracao = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Ano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_NumeroInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_NumeroFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Serie)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "* Ano:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "* Série:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 85;
            this.label2.Text = "*Número Inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(203, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 90;
            this.label4.Text = "*Número Final:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 92;
            this.label5.Text = "*Justificativa:";
            // 
            // ovTXT_Justificativa
            // 
            this.ovTXT_Justificativa.BackColor = System.Drawing.Color.White;
            this.ovTXT_Justificativa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Justificativa.Location = new System.Drawing.Point(29, 116);
            this.ovTXT_Justificativa.Multiline = true;
            this.ovTXT_Justificativa.Name = "ovTXT_Justificativa";
            this.ovTXT_Justificativa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ovTXT_Justificativa.Size = new System.Drawing.Size(451, 305);
            this.ovTXT_Justificativa.TabIndex = 93;
            // 
            // ovTXT_Ano
            // 
            this.ovTXT_Ano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Ano.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_Ano.Location = new System.Drawing.Point(87, 19);
            this.ovTXT_Ano.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ovTXT_Ano.Name = "ovTXT_Ano";
            this.ovTXT_Ano.Sigla = "**";
            this.ovTXT_Ano.Size = new System.Drawing.Size(110, 27);
            this.ovTXT_Ano.TabIndex = 1;
            this.ovTXT_Ano.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Ano.ThousandsSeparator = true;
            this.ovTXT_Ano.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Ano.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Ano.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Ano.viTamanho = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ovTXT_NumeroInicial
            // 
            this.ovTXT_NumeroInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_NumeroInicial.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_NumeroInicial.Location = new System.Drawing.Point(326, 19);
            this.ovTXT_NumeroInicial.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ovTXT_NumeroInicial.Name = "ovTXT_NumeroInicial";
            this.ovTXT_NumeroInicial.Sigla = "**";
            this.ovTXT_NumeroInicial.Size = new System.Drawing.Size(110, 27);
            this.ovTXT_NumeroInicial.TabIndex = 2;
            this.ovTXT_NumeroInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_NumeroInicial.ThousandsSeparator = true;
            this.ovTXT_NumeroInicial.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_NumeroInicial.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_NumeroInicial.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_NumeroInicial.viTamanho = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ovTXT_NumeroFinal
            // 
            this.ovTXT_NumeroFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_NumeroFinal.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_NumeroFinal.Location = new System.Drawing.Point(326, 54);
            this.ovTXT_NumeroFinal.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ovTXT_NumeroFinal.Name = "ovTXT_NumeroFinal";
            this.ovTXT_NumeroFinal.Sigla = "**";
            this.ovTXT_NumeroFinal.Size = new System.Drawing.Size(110, 27);
            this.ovTXT_NumeroFinal.TabIndex = 4;
            this.ovTXT_NumeroFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_NumeroFinal.ThousandsSeparator = true;
            this.ovTXT_NumeroFinal.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_NumeroFinal.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_NumeroFinal.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_NumeroFinal.viTamanho = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ovTXT_Serie
            // 
            this.ovTXT_Serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Serie.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_Serie.Location = new System.Drawing.Point(87, 54);
            this.ovTXT_Serie.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ovTXT_Serie.Name = "ovTXT_Serie";
            this.ovTXT_Serie.Sigla = "**";
            this.ovTXT_Serie.Size = new System.Drawing.Size(110, 27);
            this.ovTXT_Serie.TabIndex = 3;
            this.ovTXT_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Serie.ThousandsSeparator = true;
            this.ovTXT_Serie.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Serie.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Serie.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Serie.viTamanho = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // inutilizarNumeracao
            // 
            this.inutilizarNumeracao.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.inutilizarNumeracao.Appearance.ForeColor = System.Drawing.Color.Black;
            this.inutilizarNumeracao.Appearance.Options.UseForeColor = true;
            this.inutilizarNumeracao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("inutilizarNumeracao.ImageOptions.SvgImage")));
            this.inutilizarNumeracao.Location = new System.Drawing.Point(189, 438);
            this.inutilizarNumeracao.Name = "inutilizarNumeracao";
            this.inutilizarNumeracao.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.inutilizarNumeracao.Size = new System.Drawing.Size(98, 33);
            this.inutilizarNumeracao.TabIndex = 138;
            this.inutilizarNumeracao.Text = "Inutilizar";
            this.inutilizarNumeracao.Click += new System.EventHandler(this.inutilizarNumeracao_Click);
            // 
            // GER_InutilizarNumeracao
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 480);
            this.Controls.Add(this.inutilizarNumeracao);
            this.Controls.Add(this.ovTXT_Serie);
            this.Controls.Add(this.ovTXT_NumeroFinal);
            this.Controls.Add(this.ovTXT_NumeroInicial);
            this.Controls.Add(this.ovTXT_Ano);
            this.Controls.Add(this.ovTXT_Justificativa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GER_InutilizarNumeracao";
            this.Padding = new System.Windows.Forms.Padding(23, 83, 23, 28);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inutilizar Numeração NFC-e/NF-e";
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Ano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_NumeroInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_NumeroFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Serie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ovTXT_Justificativa;
        private UTIL.Components.Custom.EditDecimal ovTXT_Ano;
        private UTIL.Components.Custom.EditDecimal ovTXT_NumeroInicial;
        private UTIL.Components.Custom.EditDecimal ovTXT_NumeroFinal;
        private UTIL.Components.Custom.EditDecimal ovTXT_Serie;
        private DevExpress.XtraEditors.SimpleButton inutilizarNumeracao;
    }
}