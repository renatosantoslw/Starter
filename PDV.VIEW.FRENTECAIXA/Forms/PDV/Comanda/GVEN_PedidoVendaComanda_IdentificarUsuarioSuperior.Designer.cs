namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Comanda
{
    partial class GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Pin = new System.Windows.Forms.TextBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.ovTXT_Mensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(89, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(324, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pin:";
            // 
            // ovTXT_Pin
            // 
            this.ovTXT_Pin.Location = new System.Drawing.Point(89, 57);
            this.ovTXT_Pin.Name = "ovTXT_Pin";
            this.ovTXT_Pin.PasswordChar = '*';
            this.ovTXT_Pin.Size = new System.Drawing.Size(168, 22);
            this.ovTXT_Pin.TabIndex = 3;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(263, 145);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(150, 35);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton4.TabIndex = 22;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "[F10] - CONFIRMAR";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ovTXT_Mensagem
            // 
            this.ovTXT_Mensagem.ForeColor = System.Drawing.Color.Red;
            this.ovTXT_Mensagem.Location = new System.Drawing.Point(26, 145);
            this.ovTXT_Mensagem.Name = "ovTXT_Mensagem";
            this.ovTXT_Mensagem.Size = new System.Drawing.Size(231, 36);
            this.ovTXT_Mensagem.TabIndex = 23;
            this.ovTXT_Mensagem.Text = "   ";
            this.ovTXT_Mensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 209);
            this.Controls.Add(this.ovTXT_Mensagem);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.ovTXT_Pin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior";
            this.Padding = new System.Windows.Forms.Padding(23, 80, 23, 28);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IDENTIFICAR SUPERVISOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ovTXT_Pin;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Label ovTXT_Mensagem;
    }
}