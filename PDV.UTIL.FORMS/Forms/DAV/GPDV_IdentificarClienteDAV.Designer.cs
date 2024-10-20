namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_IdentificarClienteDAV
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
            this.ovTXT_TipoPessoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_TipoDocumento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_EmailCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_CPFCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_ClienteEncontrado = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.ovTXT_NomeCliente = new System.Windows.Forms.TextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // ovTXT_TipoPessoa
            // 
            this.ovTXT_TipoPessoa.Location = new System.Drawing.Point(179, 63);
            this.ovTXT_TipoPessoa.MaxLength = 1;
            this.ovTXT_TipoPessoa.Name = "ovTXT_TipoPessoa";
            this.ovTXT_TipoPessoa.Size = new System.Drawing.Size(45, 22);
            this.ovTXT_TipoPessoa.TabIndex = 0;
            this.ovTXT_TipoPessoa.Text = "1";
            this.ovTXT_TipoPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Tipo Pessoa:";
            // 
            // ovTXT_TipoDocumento
            // 
            this.ovTXT_TipoDocumento.AutoSize = true;
            this.ovTXT_TipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_TipoDocumento.Location = new System.Drawing.Point(23, 97);
            this.ovTXT_TipoDocumento.Name = "ovTXT_TipoDocumento";
            this.ovTXT_TipoDocumento.Size = new System.Drawing.Size(51, 16);
            this.ovTXT_TipoDocumento.TabIndex = 3;
            this.ovTXT_TipoDocumento.Text = "* CPF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(23, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-mail:";
            // 
            // ovTXT_EmailCliente
            // 
            this.ovTXT_EmailCliente.Location = new System.Drawing.Point(179, 125);
            this.ovTXT_EmailCliente.Name = "ovTXT_EmailCliente";
            this.ovTXT_EmailCliente.Size = new System.Drawing.Size(398, 22);
            this.ovTXT_EmailCliente.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(230, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "[0] - JURIDICA [1] - FÍSICA";
            // 
            // ovTXT_CPFCNPJ
            // 
            this.ovTXT_CPFCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CPFCNPJ.Location = new System.Drawing.Point(179, 94);
            this.ovTXT_CPFCNPJ.Name = "ovTXT_CPFCNPJ";
            this.ovTXT_CPFCNPJ.Size = new System.Drawing.Size(118, 22);
            this.ovTXT_CPFCNPJ.TabIndex = 1;
            // 
            // ovTXT_ClienteEncontrado
            // 
            this.ovTXT_ClienteEncontrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ClienteEncontrado.Location = new System.Drawing.Point(23, 162);
            this.ovTXT_ClienteEncontrado.Name = "ovTXT_ClienteEncontrado";
            this.ovTXT_ClienteEncontrado.Size = new System.Drawing.Size(342, 35);
            this.ovTXT_ClienteEncontrado.TabIndex = 9;
            this.ovTXT_ClienteEncontrado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(371, 209);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(206, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 12;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "[F12] - SALVAR IDENTIFICAÇÃO";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ovTXT_NomeCliente
            // 
            this.ovTXT_NomeCliente.Location = new System.Drawing.Point(303, 94);
            this.ovTXT_NomeCliente.Name = "ovTXT_NomeCliente";
            this.ovTXT_NomeCliente.Size = new System.Drawing.Size(274, 22);
            this.ovTXT_NomeCliente.TabIndex = 2;
            this.ovTXT_NomeCliente.TabStop = false;
            this.ovTXT_NomeCliente.Visible = false;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(372, 167);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(205, 35);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton2.TabIndex = 13;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "[F3] - PESQUISAR / NOVO";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // GPDV_IdentificarClienteDAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.ovTXT_NomeCliente);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.ovTXT_ClienteEncontrado);
            this.Controls.Add(this.ovTXT_CPFCNPJ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_EmailCliente);
            this.Controls.Add(this.ovTXT_TipoDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_TipoPessoa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 220);
            this.Name = "GPDV_IdentificarClienteDAV";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IDENTIFICAR CLIENTE DAV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ovTXT_TipoDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ovTXT_ClienteEncontrado;
        private MetroFramework.Controls.MetroButton metroButton1;
        public System.Windows.Forms.TextBox ovTXT_TipoPessoa;
        public System.Windows.Forms.MaskedTextBox ovTXT_CPFCNPJ;
        public System.Windows.Forms.TextBox ovTXT_EmailCliente;
        public System.Windows.Forms.TextBox ovTXT_NomeCliente;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}