namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class FCA_HistoricoClienteFornecedor
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
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.ovTXT_Assunto = new System.Windows.Forms.TextBox();
            this.ovTXT_Observacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_DataHora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(471, 541);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(150, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 26;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "CANCELAR";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(627, 541);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(150, 35);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton4.TabIndex = 25;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "SALVAR";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(23, 16);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(77, 16);
            this.ovLBL_RazaoSocial.TabIndex = 28;
            this.ovLBL_RazaoSocial.Text = "* Assunto:";
            // 
            // ovTXT_Assunto
            // 
            this.ovTXT_Assunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Assunto.Location = new System.Drawing.Point(104, 13);
            this.ovTXT_Assunto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Assunto.Name = "ovTXT_Assunto";
            this.ovTXT_Assunto.Size = new System.Drawing.Size(673, 22);
            this.ovTXT_Assunto.TabIndex = 1;
            // 
            // ovTXT_Observacao
            // 
            this.ovTXT_Observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Observacao.Location = new System.Drawing.Point(26, 129);
            this.ovTXT_Observacao.Multiline = true;
            this.ovTXT_Observacao.Name = "ovTXT_Observacao";
            this.ovTXT_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ovTXT_Observacao.Size = new System.Drawing.Size(751, 442);
            this.ovTXT_Observacao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Observação:";
            // 
            // ovTXT_DataHora
            // 
            this.ovTXT_DataHora.Enabled = false;
            this.ovTXT_DataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DataHora.Location = new System.Drawing.Point(571, 46);
            this.ovTXT_DataHora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_DataHora.Name = "ovTXT_DataHora";
            this.ovTXT_DataHora.ReadOnly = true;
            this.ovTXT_DataHora.Size = new System.Drawing.Size(206, 22);
            this.ovTXT_DataHora.TabIndex = 2;
            this.ovTXT_DataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(434, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Data/Hora Histórico:";
            // 
            // FCA_HistoricoClienteFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_DataHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovTXT_Observacao);
            this.Controls.Add(this.ovLBL_RazaoSocial);
            this.Controls.Add(this.ovTXT_Assunto);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(802, 632);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FCA_HistoricoClienteFornecedor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CADASTRO DE HISTÓRICO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
        private System.Windows.Forms.TextBox ovTXT_Assunto;
        private System.Windows.Forms.TextBox ovTXT_Observacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_DataHora;
        private System.Windows.Forms.Label label2;
    }
}