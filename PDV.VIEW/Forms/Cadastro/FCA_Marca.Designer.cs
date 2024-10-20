namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Marca
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
            this.ovTXT_Codigo = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovLBL_Codigo = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.checkBoxMarcaDeVeiculo = new System.Windows.Forms.CheckBox();
            this.checkBoxMarcaDeProduto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Codigo.Location = new System.Drawing.Point(24, 28);
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.ReadOnly = true;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(81, 21);
            this.ovTXT_Codigo.TabIndex = 1;
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Descricao.Location = new System.Drawing.Point(134, 28);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(297, 21);
            this.ovTXT_Descricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(131, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Descrição:";
            // 
            // ovLBL_Codigo
            // 
            this.ovLBL_Codigo.AutoSize = true;
            this.ovLBL_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovLBL_Codigo.Location = new System.Drawing.Point(21, 9);
            this.ovLBL_Codigo.Name = "ovLBL_Codigo";
            this.ovLBL_Codigo.Size = new System.Drawing.Size(53, 13);
            this.ovLBL_Codigo.TabIndex = 3;
            this.ovLBL_Codigo.Text = "* Código:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Location = new System.Drawing.Point(294, 116);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Location = new System.Drawing.Point(384, 116);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // checkBoxMarcaDeVeiculo
            // 
            this.checkBoxMarcaDeVeiculo.AutoSize = true;
            this.checkBoxMarcaDeVeiculo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxMarcaDeVeiculo.Location = new System.Drawing.Point(24, 74);
            this.checkBoxMarcaDeVeiculo.Name = "checkBoxMarcaDeVeiculo";
            this.checkBoxMarcaDeVeiculo.Size = new System.Drawing.Size(106, 17);
            this.checkBoxMarcaDeVeiculo.TabIndex = 114;
            this.checkBoxMarcaDeVeiculo.Text = "Marca de Veículo";
            this.checkBoxMarcaDeVeiculo.UseVisualStyleBackColor = true;
            // 
            // checkBoxMarcaDeProduto
            // 
            this.checkBoxMarcaDeProduto.AutoSize = true;
            this.checkBoxMarcaDeProduto.Checked = true;
            this.checkBoxMarcaDeProduto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarcaDeProduto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBoxMarcaDeProduto.Location = new System.Drawing.Point(136, 74);
            this.checkBoxMarcaDeProduto.Name = "checkBoxMarcaDeProduto";
            this.checkBoxMarcaDeProduto.Size = new System.Drawing.Size(111, 17);
            this.checkBoxMarcaDeProduto.TabIndex = 115;
            this.checkBoxMarcaDeProduto.Text = "Marca de Produto";
            this.checkBoxMarcaDeProduto.UseVisualStyleBackColor = true;
            // 
            // FCA_Marca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 152);
            this.Controls.Add(this.checkBoxMarcaDeProduto);
            this.Controls.Add(this.checkBoxMarcaDeVeiculo);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovLBL_Codigo);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 184);
            this.Name = "FCA_Marca";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Marcas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Marca_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ovTXT_Codigo;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovLBL_Codigo;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.CheckBox checkBoxMarcaDeVeiculo;
        private System.Windows.Forms.CheckBox checkBoxMarcaDeProduto;
    }
}