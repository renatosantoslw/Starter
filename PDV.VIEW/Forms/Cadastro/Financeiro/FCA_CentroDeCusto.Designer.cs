namespace PDV.VIEW.Forms.Cadastro.Financeiro
{
    partial class FCA_CentroCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_CentroCusto));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_Centro = new System.Windows.Forms.Label();
            this.ovTXT_Sigla = new System.Windows.Forms.TextBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.radioSaida = new System.Windows.Forms.RadioButton();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(23, 28);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(449, 21);
            this.ovTXT_Descricao.TabIndex = 1;
            // 
            // ovLBL_Centro
            // 
            this.ovLBL_Centro.AutoSize = true;
            this.ovLBL_Centro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Centro.Location = new System.Drawing.Point(23, 63);
            this.ovLBL_Centro.Name = "ovLBL_Centro";
            this.ovLBL_Centro.Size = new System.Drawing.Size(33, 13);
            this.ovLBL_Centro.TabIndex = 37;
            this.ovLBL_Centro.Text = "Sigla:";
            // 
            // ovTXT_Sigla
            // 
            this.ovTXT_Sigla.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Sigla.Location = new System.Drawing.Point(23, 82);
            this.ovTXT_Sigla.MaxLength = 4;
            this.ovTXT_Sigla.Name = "ovTXT_Sigla";
            this.ovTXT_Sigla.Size = new System.Drawing.Size(100, 21);
            this.ovTXT_Sigla.TabIndex = 2;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(384, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
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
            this.metroButton5.Location = new System.Drawing.Point(290, 116);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // radioSaida
            // 
            this.radioSaida.AutoSize = true;
            this.radioSaida.Location = new System.Drawing.Point(263, 86);
            this.radioSaida.Name = "radioSaida";
            this.radioSaida.Size = new System.Drawing.Size(51, 17);
            this.radioSaida.TabIndex = 117;
            this.radioSaida.Text = "Saída";
            this.radioSaida.UseVisualStyleBackColor = true;
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Checked = true;
            this.radioEntrada.Location = new System.Drawing.Point(181, 86);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(63, 17);
            this.radioEntrada.TabIndex = 116;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            // 
            // FCA_CentroCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.radioSaida);
            this.Controls.Add(this.radioEntrada);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.ovTXT_Sigla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovLBL_Centro);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 209);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 193);
            this.Name = "FCA_CentroCusto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Centro de Custo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_CentroCusto_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.Label ovLBL_Centro;
        private System.Windows.Forms.TextBox ovTXT_Sigla;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.RadioButton radioSaida;
        private System.Windows.Forms.RadioButton radioEntrada;
    }
}