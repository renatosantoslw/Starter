using PDV.UTIL.Components.Custom;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_SangriaCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPDV_SangriaCaixa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_DataHora = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_SaldoAtual = new System.Windows.Forms.TextBox();
            this.ovTXT_AposSangria = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_Observacao = new System.Windows.Forms.TextBox();
            this.ovTXT_Usuario = new System.Windows.Forms.TextBox();
            this.ovTXT_ValorSangria = new EditDecimal();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_ValorSangria)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data/Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo Atual:";
            // 
            // ovTXT_DataHora
            // 
            this.ovTXT_DataHora.Enabled = false;
            this.ovTXT_DataHora.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DataHora.Location = new System.Drawing.Point(120, 51);
            this.ovTXT_DataHora.Name = "ovTXT_DataHora";
            this.ovTXT_DataHora.ReadOnly = true;
            this.ovTXT_DataHora.Size = new System.Drawing.Size(231, 21);
            this.ovTXT_DataHora.TabIndex = 5;
            this.ovTXT_DataHora.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "* Valor:";
            // 
            // ovTXT_SaldoAtual
            // 
            this.ovTXT_SaldoAtual.Enabled = false;
            this.ovTXT_SaldoAtual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_SaldoAtual.Location = new System.Drawing.Point(120, 83);
            this.ovTXT_SaldoAtual.Name = "ovTXT_SaldoAtual";
            this.ovTXT_SaldoAtual.ReadOnly = true;
            this.ovTXT_SaldoAtual.Size = new System.Drawing.Size(148, 21);
            this.ovTXT_SaldoAtual.TabIndex = 25;
            this.ovTXT_SaldoAtual.TabStop = false;
            // 
            // ovTXT_AposSangria
            // 
            this.ovTXT_AposSangria.Enabled = false;
            this.ovTXT_AposSangria.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_AposSangria.Location = new System.Drawing.Point(120, 147);
            this.ovTXT_AposSangria.Name = "ovTXT_AposSangria";
            this.ovTXT_AposSangria.ReadOnly = true;
            this.ovTXT_AposSangria.Size = new System.Drawing.Size(148, 21);
            this.ovTXT_AposSangria.TabIndex = 27;
            this.ovTXT_AposSangria.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Após Sangria:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Observação:";
            // 
            // ovTXT_Observacao
            // 
            this.ovTXT_Observacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Observacao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Observacao.Location = new System.Drawing.Point(29, 200);
            this.ovTXT_Observacao.Multiline = true;
            this.ovTXT_Observacao.Name = "ovTXT_Observacao";
            this.ovTXT_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovTXT_Observacao.Size = new System.Drawing.Size(425, 174);
            this.ovTXT_Observacao.TabIndex = 2;
            // 
            // ovTXT_Usuario
            // 
            this.ovTXT_Usuario.Enabled = false;
            this.ovTXT_Usuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Usuario.Location = new System.Drawing.Point(120, 19);
            this.ovTXT_Usuario.Name = "ovTXT_Usuario";
            this.ovTXT_Usuario.ReadOnly = true;
            this.ovTXT_Usuario.Size = new System.Drawing.Size(334, 21);
            this.ovTXT_Usuario.TabIndex = 30;
            this.ovTXT_Usuario.TabStop = false;
            // 
            // ovTXT_ValorSangria
            // 
            this.ovTXT_ValorSangria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_ValorSangria.DecimalPlaces = 2;
            this.ovTXT_ValorSangria.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ValorSangria.Location = new System.Drawing.Point(120, 115);
            this.ovTXT_ValorSangria.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            131072});
            this.ovTXT_ValorSangria.Name = "ovTXT_ValorSangria";
            this.ovTXT_ValorSangria.Sigla = "R$";
            this.ovTXT_ValorSangria.Size = new System.Drawing.Size(148, 21);
            this.ovTXT_ValorSangria.TabIndex = 1;
            this.ovTXT_ValorSangria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_ValorSangria.ThousandsSeparator = true;
            this.ovTXT_ValorSangria.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_ValorSangria.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_ValorSangria.viPrecisao = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ovTXT_ValorSangria.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(137, 380);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(173, 31);
            this.simpleButton1.TabIndex = 32;
            this.simpleButton1.Text = "Salvar -F10";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // GPDV_SangriaCaixa
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 423);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.ovTXT_ValorSangria);
            this.Controls.Add(this.ovTXT_Usuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ovTXT_Observacao);
            this.Controls.Add(this.ovTXT_AposSangria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_SaldoAtual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_DataHora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_SangriaCaixa";
            this.Padding = new System.Windows.Forms.Padding(23, 83, 23, 28);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SANGRIA DE CAIXA";
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_ValorSangria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_DataHora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ovTXT_SaldoAtual;
        private System.Windows.Forms.TextBox ovTXT_AposSangria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ovTXT_Observacao;
        private System.Windows.Forms.TextBox ovTXT_Usuario;
        public EditDecimal ovTXT_ValorSangria;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}