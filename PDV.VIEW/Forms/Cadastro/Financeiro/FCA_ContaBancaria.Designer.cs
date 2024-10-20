namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    partial class FCA_ContaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_ContaBancaria));
            this.ovTXT_Nome = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_Centro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_Banco = new MetroFramework.Controls.MetroComboBox();
            this.ovTXT_Agencia = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Conta = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovCKB_CaixaInterno = new System.Windows.Forms.CheckBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.ovTXT_Digito = new System.Windows.Forms.TextBox();
            this.ovTXT_DigitoAgencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_Operacao = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovTXT_Nome
            // 
            this.ovTXT_Nome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Nome.Location = new System.Drawing.Point(23, 27);
            this.ovTXT_Nome.Name = "ovTXT_Nome";
            this.ovTXT_Nome.Size = new System.Drawing.Size(287, 23);
            this.ovTXT_Nome.TabIndex = 1;
            // 
            // ovLBL_Centro
            // 
            this.ovLBL_Centro.AutoSize = true;
            this.ovLBL_Centro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_Centro.Location = new System.Drawing.Point(20, 8);
            this.ovLBL_Centro.Name = "ovLBL_Centro";
            this.ovLBL_Centro.Size = new System.Drawing.Size(47, 13);
            this.ovLBL_Centro.TabIndex = 30;
            this.ovLBL_Centro.Text = "* Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "* Banco:";
            // 
            // ovCMB_Banco
            // 
            this.ovCMB_Banco.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Banco.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Banco.FormattingEnabled = true;
            this.ovCMB_Banco.ItemHeight = 19;
            this.ovCMB_Banco.Location = new System.Drawing.Point(23, 75);
            this.ovCMB_Banco.Name = "ovCMB_Banco";
            this.ovCMB_Banco.Size = new System.Drawing.Size(442, 25);
            this.ovCMB_Banco.TabIndex = 4;
            this.ovCMB_Banco.UseSelectable = true;
            // 
            // ovTXT_Agencia
            // 
            this.ovTXT_Agencia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Agencia.Location = new System.Drawing.Point(23, 131);
            this.ovTXT_Agencia.Name = "ovTXT_Agencia";
            this.ovTXT_Agencia.Size = new System.Drawing.Size(154, 23);
            this.ovTXT_Agencia.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Agência:";
            // 
            // ovTXT_Conta
            // 
            this.ovTXT_Conta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Conta.Location = new System.Drawing.Point(23, 176);
            this.ovTXT_Conta.Name = "ovTXT_Conta";
            this.ovTXT_Conta.Size = new System.Drawing.Size(154, 23);
            this.ovTXT_Conta.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Conta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(197, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Digito:";
            // 
            // ovCKB_CaixaInterno
            // 
            this.ovCKB_CaixaInterno.AutoSize = true;
            this.ovCKB_CaixaInterno.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_CaixaInterno.Location = new System.Drawing.Point(316, 31);
            this.ovCKB_CaixaInterno.Name = "ovCKB_CaixaInterno";
            this.ovCKB_CaixaInterno.Size = new System.Drawing.Size(92, 17);
            this.ovCKB_CaixaInterno.TabIndex = 2;
            this.ovCKB_CaixaInterno.Text = "Caixa Interno";
            this.ovCKB_CaixaInterno.UseVisualStyleBackColor = true;
            this.ovCKB_CaixaInterno.CheckedChanged += new System.EventHandler(this.ovCKB_CaixaInterno_CheckedChanged);
            this.ovCKB_CaixaInterno.Click += new System.EventHandler(this.ovCKB_CaixaInterno_Click);
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_Ativo.Location = new System.Drawing.Point(414, 31);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 3;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // ovTXT_Digito
            // 
            this.ovTXT_Digito.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Digito.Location = new System.Drawing.Point(200, 176);
            this.ovTXT_Digito.MaxLength = 1;
            this.ovTXT_Digito.Name = "ovTXT_Digito";
            this.ovTXT_Digito.Size = new System.Drawing.Size(58, 23);
            this.ovTXT_Digito.TabIndex = 8;
            // 
            // ovTXT_DigitoAgencia
            // 
            this.ovTXT_DigitoAgencia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DigitoAgencia.Location = new System.Drawing.Point(200, 131);
            this.ovTXT_DigitoAgencia.MaxLength = 1;
            this.ovTXT_DigitoAgencia.Name = "ovTXT_DigitoAgencia";
            this.ovTXT_DigitoAgencia.Size = new System.Drawing.Size(58, 23);
            this.ovTXT_DigitoAgencia.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Digito:";
            // 
            // ovTXT_Operacao
            // 
            this.ovTXT_Operacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Operacao.Location = new System.Drawing.Point(285, 131);
            this.ovTXT_Operacao.Name = "ovTXT_Operacao";
            this.ovTXT_Operacao.Size = new System.Drawing.Size(62, 23);
            this.ovTXT_Operacao.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(282, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Operação:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(410, 207);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(70, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(336, 207);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(68, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_ContaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 252);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_Operacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ovTXT_DigitoAgencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_Digito);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.ovCKB_CaixaInterno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_Conta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Agencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovCMB_Banco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Nome);
            this.Controls.Add(this.ovLBL_Centro);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 284);
            this.Name = "FCA_ContaBancaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Conta Bancária";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_ContaBancaria_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Nome;
        private System.Windows.Forms.Label ovLBL_Centro;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_Banco;
        private System.Windows.Forms.MaskedTextBox ovTXT_Agencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox ovTXT_Conta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ovCKB_CaixaInterno;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.TextBox ovTXT_Digito;
        private System.Windows.Forms.TextBox ovTXT_DigitoAgencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox ovTXT_Operacao;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}