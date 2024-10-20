namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_NFCeGeral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_NFCeGeral));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Sequencia = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Serie = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ovCMB_NaturezaOperacao = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_CodNatOp = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_ValorSequence = new PDV.UTIL.Components.Custom.EditDecimal();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_ValorSequence)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovTXT_ValorSequence);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ovTXT_Sequencia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_Serie);
            this.groupBox1.Controls.Add(this.ovLBL_RazaoSocial);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 147);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações de Série";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "* Valor Atual:";
            // 
            // ovTXT_Sequencia
            // 
            this.ovTXT_Sequencia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Sequencia.Location = new System.Drawing.Point(121, 68);
            this.ovTXT_Sequencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Sequencia.Name = "ovTXT_Sequencia";
            this.ovTXT_Sequencia.Size = new System.Drawing.Size(257, 23);
            this.ovTXT_Sequencia.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(20, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "* Sequência:";
            // 
            // ovTXT_Serie
            // 
            this.ovTXT_Serie.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Serie.Location = new System.Drawing.Point(121, 35);
            this.ovTXT_Serie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Serie.Name = "ovTXT_Serie";
            this.ovTXT_Serie.Size = new System.Drawing.Size(257, 23);
            this.ovTXT_Serie.TabIndex = 1;
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(20, 38);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(44, 13);
            this.ovLBL_RazaoSocial.TabIndex = 5;
            this.ovLBL_RazaoSocial.Text = "* Série:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ovCMB_NaturezaOperacao);
            this.groupBox2.Controls.Add(this.ovTXT_CodNatOp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(23, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 118);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuração Fiscal";
            // 
            // ovCMB_NaturezaOperacao
            // 
            this.ovCMB_NaturezaOperacao.DropDownWidth = 564;
            this.ovCMB_NaturezaOperacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_NaturezaOperacao.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_NaturezaOperacao.FormattingEnabled = true;
            this.ovCMB_NaturezaOperacao.ItemHeight = 19;
            this.ovCMB_NaturezaOperacao.Location = new System.Drawing.Point(6, 58);
            this.ovCMB_NaturezaOperacao.Name = "ovCMB_NaturezaOperacao";
            this.ovCMB_NaturezaOperacao.Size = new System.Drawing.Size(372, 25);
            this.ovCMB_NaturezaOperacao.TabIndex = 93;
            this.ovCMB_NaturezaOperacao.UseSelectable = true;
            // 
            // ovTXT_CodNatOp
            // 
            this.ovTXT_CodNatOp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CodNatOp.Location = new System.Drawing.Point(304, 21);
            this.ovTXT_CodNatOp.Name = "ovTXT_CodNatOp";
            this.ovTXT_CodNatOp.Size = new System.Drawing.Size(74, 23);
            this.ovTXT_CodNatOp.TabIndex = 92;
            this.ovTXT_CodNatOp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_CodNatOp_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.Location = new System.Drawing.Point(1, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 13);
            this.label9.TabIndex = 91;
            this.label9.Text = "* Natureza Operação Padrão de Venda.:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(327, 371);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(87, 33);
            this.metroButton4.TabIndex = 117;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(226, 371);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 116;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // ovTXT_ValorSequence
            // 
            this.ovTXT_ValorSequence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_ValorSequence.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ValorSequence.Location = new System.Drawing.Point(121, 100);
            this.ovTXT_ValorSequence.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ovTXT_ValorSequence.Name = "ovTXT_ValorSequence";
            this.ovTXT_ValorSequence.Sigla = "VR";
            this.ovTXT_ValorSequence.Size = new System.Drawing.Size(257, 26);
            this.ovTXT_ValorSequence.TabIndex = 9;
            this.ovTXT_ValorSequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_ValorSequence.ThousandsSeparator = true;
            this.ovTXT_ValorSequence.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_ValorSequence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_ValorSequence.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_ValorSequence.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_ValorSequence.viTamanho = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FCONFIG_NFCeGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 416);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 455);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 448);
            this.Name = "FCONFIG_NFCeGeral";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Geral NFC-e";
            this.Load += new System.EventHandler(this.FCONFIG_NFCeGeral_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_ValorSequence)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private UTIL.Components.Custom.EditDecimal ovTXT_ValorSequence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox ovTXT_Sequencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox ovTXT_Serie;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroComboBox ovCMB_NaturezaOperacao;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodNatOp;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}