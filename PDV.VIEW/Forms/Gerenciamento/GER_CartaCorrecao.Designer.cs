namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_CartaCorrecao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_CartaCorrecao));
            this.ovTXT_Protocolo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Justificativa = new System.Windows.Forms.TextBox();
            this.ovTXT_Chave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_IDLote = new System.Windows.Forms.TextBox();
            this.ovBTN_Enviar = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovTXT_Protocolo
            // 
            this.ovTXT_Protocolo.Enabled = false;
            this.ovTXT_Protocolo.Location = new System.Drawing.Point(26, 39);
            this.ovTXT_Protocolo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ovTXT_Protocolo.Name = "ovTXT_Protocolo";
            this.ovTXT_Protocolo.ReadOnly = true;
            this.ovTXT_Protocolo.Size = new System.Drawing.Size(413, 23);
            this.ovTXT_Protocolo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Protocolo de Autorização";
            // 
            // ovTXT_Justificativa
            // 
            this.ovTXT_Justificativa.BackColor = System.Drawing.Color.White;
            this.ovTXT_Justificativa.Enabled = false;
            this.ovTXT_Justificativa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Justificativa.Location = new System.Drawing.Point(26, 128);
            this.ovTXT_Justificativa.Multiline = true;
            this.ovTXT_Justificativa.Name = "ovTXT_Justificativa";
            this.ovTXT_Justificativa.ReadOnly = true;
            this.ovTXT_Justificativa.Size = new System.Drawing.Size(522, 114);
            this.ovTXT_Justificativa.TabIndex = 8;
            this.ovTXT_Justificativa.Text = resources.GetString("ovTXT_Justificativa.Text");
            this.ovTXT_Justificativa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovTXT_Chave
            // 
            this.ovTXT_Chave.Enabled = false;
            this.ovTXT_Chave.Location = new System.Drawing.Point(26, 94);
            this.ovTXT_Chave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ovTXT_Chave.Name = "ovTXT_Chave";
            this.ovTXT_Chave.ReadOnly = true;
            this.ovTXT_Chave.Size = new System.Drawing.Size(522, 23);
            this.ovTXT_Chave.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(26, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "* Chave da NF-e";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(26, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "* Descrição da Correção";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.BackColor = System.Drawing.Color.White;
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Descricao.Location = new System.Drawing.Point(26, 266);
            this.ovTXT_Descricao.Multiline = true;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(522, 161);
            this.ovTXT_Descricao.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(442, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "* ID Lote";
            // 
            // ovTXT_IDLote
            // 
            this.ovTXT_IDLote.Enabled = false;
            this.ovTXT_IDLote.Location = new System.Drawing.Point(445, 39);
            this.ovTXT_IDLote.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ovTXT_IDLote.Name = "ovTXT_IDLote";
            this.ovTXT_IDLote.ReadOnly = true;
            this.ovTXT_IDLote.Size = new System.Drawing.Size(103, 23);
            this.ovTXT_IDLote.TabIndex = 14;
            this.ovTXT_IDLote.Text = "1";
            this.ovTXT_IDLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovBTN_Enviar
            // 
            this.ovBTN_Enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_Enviar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ovBTN_Enviar.Appearance.Options.UseForeColor = true;
            this.ovBTN_Enviar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ovBTN_Enviar.ImageOptions.SvgImage")));
            this.ovBTN_Enviar.Location = new System.Drawing.Point(463, 433);
            this.ovBTN_Enviar.Name = "ovBTN_Enviar";
            this.ovBTN_Enviar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ovBTN_Enviar.Size = new System.Drawing.Size(85, 33);
            this.ovBTN_Enviar.TabIndex = 133;
            this.ovBTN_Enviar.Text = "Enviar";
            this.ovBTN_Enviar.Click += new System.EventHandler(this.ovBTN_Enviar_Click);
            // 
            // GER_CartaCorrecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 481);
            this.Controls.Add(this.ovBTN_Enviar);
            this.Controls.Add(this.ovTXT_IDLote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ovTXT_Chave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_Justificativa);
            this.Controls.Add(this.ovTXT_Protocolo);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GER_CartaCorrecao";
            this.Padding = new System.Windows.Forms.Padding(23, 83, 23, 28);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carta de Correção";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ovTXT_Protocolo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_Justificativa;
        private System.Windows.Forms.TextBox ovTXT_Chave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ovTXT_IDLote;
        private DevExpress.XtraEditors.SimpleButton ovBTN_Enviar;
    }
}