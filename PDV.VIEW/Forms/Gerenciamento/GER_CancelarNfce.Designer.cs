namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_CancelarNfce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_CancelarNfce));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Protocolo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_Justificativa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovBTN_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_Chave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(26, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "* Protocolo de Autorização";
            // 
            // ovTXT_Protocolo
            // 
            this.ovTXT_Protocolo.Enabled = false;
            this.ovTXT_Protocolo.Location = new System.Drawing.Point(29, 29);
            this.ovTXT_Protocolo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Protocolo.Name = "ovTXT_Protocolo";
            this.ovTXT_Protocolo.ReadOnly = true;
            this.ovTXT_Protocolo.Size = new System.Drawing.Size(420, 23);
            this.ovTXT_Protocolo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(26, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "* Chave";
            // 
            // ovTXT_Justificativa
            // 
            this.ovTXT_Justificativa.BackColor = System.Drawing.Color.White;
            this.ovTXT_Justificativa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Justificativa.Location = new System.Drawing.Point(26, 151);
            this.ovTXT_Justificativa.Multiline = true;
            this.ovTXT_Justificativa.Name = "ovTXT_Justificativa";
            this.ovTXT_Justificativa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ovTXT_Justificativa.Size = new System.Drawing.Size(423, 287);
            this.ovTXT_Justificativa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(26, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "* Justificativa";
            // 
            // ovBTN_Cancelar
            // 
            this.ovBTN_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_Cancelar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ovBTN_Cancelar.Appearance.Options.UseForeColor = true;
            this.ovBTN_Cancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ovBTN_Cancelar.ImageOptions.SvgImage")));
            this.ovBTN_Cancelar.Location = new System.Drawing.Point(347, 458);
            this.ovBTN_Cancelar.Name = "ovBTN_Cancelar";
            this.ovBTN_Cancelar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ovBTN_Cancelar.Size = new System.Drawing.Size(97, 33);
            this.ovBTN_Cancelar.TabIndex = 134;
            this.ovBTN_Cancelar.Text = "Enviar";
            this.ovBTN_Cancelar.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // ovTXT_Chave
            // 
            this.ovTXT_Chave.Enabled = false;
            this.ovTXT_Chave.Location = new System.Drawing.Point(29, 103);
            this.ovTXT_Chave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Chave.Name = "ovTXT_Chave";
            this.ovTXT_Chave.ReadOnly = true;
            this.ovTXT_Chave.Size = new System.Drawing.Size(420, 23);
            this.ovTXT_Chave.TabIndex = 135;
            // 
            // GER_CancelarNfce
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 494);
            this.Controls.Add(this.ovTXT_Chave);
            this.Controls.Add(this.ovBTN_Cancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_Justificativa);
            this.Controls.Add(this.ovTXT_Protocolo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GER_CancelarNfce";
            this.Padding = new System.Windows.Forms.Padding(23, 83, 23, 28);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar NFC-e/NF-e";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_Protocolo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ovTXT_Justificativa;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton ovBTN_Cancelar;
        private System.Windows.Forms.TextBox ovTXT_Chave;
    }
}