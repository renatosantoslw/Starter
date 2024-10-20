namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    partial class FCA_HistoricoFinanceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_HistoricoFinanceiro));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.radioSaida = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(29, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(32, 28);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(419, 21);
            this.ovTXT_Descricao.TabIndex = 27;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(416, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(56, 33);
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
            this.metroButton5.Location = new System.Drawing.Point(342, 116);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(68, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Checked = true;
            this.radioEntrada.Location = new System.Drawing.Point(32, 93);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(63, 17);
            this.radioEntrada.TabIndex = 114;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            // 
            // radioSaida
            // 
            this.radioSaida.AutoSize = true;
            this.radioSaida.Location = new System.Drawing.Point(114, 93);
            this.radioSaida.Name = "radioSaida";
            this.radioSaida.Size = new System.Drawing.Size(51, 17);
            this.radioSaida.TabIndex = 115;
            this.radioSaida.TabStop = true;
            this.radioSaida.Text = "Saída";
            this.radioSaida.UseVisualStyleBackColor = true;
            // 
            // FCA_HistoricoFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.radioSaida);
            this.Controls.Add(this.radioEntrada);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 209);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 193);
            this.Name = "FCA_HistoricoFinanceiro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Histórico Financeiro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_HistoricoFinanceiro_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.RadioButton radioEntrada;
        private System.Windows.Forms.RadioButton radioSaida;
    }
}