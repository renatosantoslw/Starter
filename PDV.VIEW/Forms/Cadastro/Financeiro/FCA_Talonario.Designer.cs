namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    partial class FCA_Talonario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Talonario));
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Observacao = new System.Windows.Forms.TextBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.ovCMB_Conta = new MetroFramework.Controls.MetroComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ovTXT_Emissao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_Numero = new System.Windows.Forms.TextBox();
            this.ovTXT_Inicio = new PDV.UTIL.Components.Custom.EditDecimal();
            this.ovTXT_Fim = new PDV.UTIL.Components.Custom.EditDecimal();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fim)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Observação:";
            // 
            // ovTXT_Observacao
            // 
            this.ovTXT_Observacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Observacao.Location = new System.Drawing.Point(115, 81);
            this.ovTXT_Observacao.Multiline = true;
            this.ovTXT_Observacao.Name = "ovTXT_Observacao";
            this.ovTXT_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovTXT_Observacao.Size = new System.Drawing.Size(662, 408);
            this.ovTXT_Observacao.TabIndex = 7;
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(719, 18);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 2;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // ovCMB_Conta
            // 
            this.ovCMB_Conta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Conta.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Conta.FormattingEnabled = true;
            this.ovCMB_Conta.ItemHeight = 19;
            this.ovCMB_Conta.Location = new System.Drawing.Point(115, 16);
            this.ovCMB_Conta.Name = "ovCMB_Conta";
            this.ovCMB_Conta.Size = new System.Drawing.Size(598, 25);
            this.ovCMB_Conta.TabIndex = 1;
            this.ovCMB_Conta.UseSelectable = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.Location = new System.Drawing.Point(23, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "* Conta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(23, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "* Número:";
            // 
            // ovTXT_Emissao
            // 
            this.ovTXT_Emissao.CalendarFont = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Emissao.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Emissao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Emissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Emissao.Location = new System.Drawing.Point(356, 47);
            this.ovTXT_Emissao.Name = "ovTXT_Emissao";
            this.ovTXT_Emissao.Size = new System.Drawing.Size(113, 21);
            this.ovTXT_Emissao.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(290, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Emissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(634, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Fim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(475, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Início:";
            // 
            // ovTXT_Numero
            // 
            this.ovTXT_Numero.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Numero.Location = new System.Drawing.Point(115, 48);
            this.ovTXT_Numero.MaxLength = 20;
            this.ovTXT_Numero.Name = "ovTXT_Numero";
            this.ovTXT_Numero.Size = new System.Drawing.Size(169, 23);
            this.ovTXT_Numero.TabIndex = 3;
            // 
            // ovTXT_Inicio
            // 
            this.ovTXT_Inicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Inicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Inicio.Location = new System.Drawing.Point(524, 47);
            this.ovTXT_Inicio.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ovTXT_Inicio.Name = "ovTXT_Inicio";
            this.ovTXT_Inicio.Sigla = "**";
            this.ovTXT_Inicio.Size = new System.Drawing.Size(104, 21);
            this.ovTXT_Inicio.TabIndex = 5;
            this.ovTXT_Inicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Inicio.ThousandsSeparator = true;
            this.ovTXT_Inicio.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Inicio.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Inicio.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Inicio.viTamanho = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // ovTXT_Fim
            // 
            this.ovTXT_Fim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Fim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Fim.Location = new System.Drawing.Point(673, 47);
            this.ovTXT_Fim.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.ovTXT_Fim.Name = "ovTXT_Fim";
            this.ovTXT_Fim.Sigla = "**";
            this.ovTXT_Fim.Size = new System.Drawing.Size(104, 21);
            this.ovTXT_Fim.TabIndex = 6;
            this.ovTXT_Fim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Fim.ThousandsSeparator = true;
            this.ovTXT_Fim.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Fim.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Fim.viPrecisao = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Fim.viTamanho = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(700, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 115;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(606, 555);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 114;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Talonario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_Fim);
            this.Controls.Add(this.ovTXT_Inicio);
            this.Controls.Add(this.ovTXT_Numero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_Emissao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ovCMB_Conta);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Observacao);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 648);
            this.Name = "FCA_Talonario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Talonário";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Talonario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Fim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_Observacao;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private MetroFramework.Controls.MetroComboBox ovCMB_Conta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker ovTXT_Emissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ovTXT_Numero;
        private UTIL.Components.Custom.EditDecimal ovTXT_Inicio;
        private UTIL.Components.Custom.EditDecimal ovTXT_Fim;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}