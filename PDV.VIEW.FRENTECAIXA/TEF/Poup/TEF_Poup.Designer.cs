namespace PDV.VIEW.FRENTECAIXA.TEF.Poup
{
    partial class TEF_Poup
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
            this.valorPagamentoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEfetuarPagamento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valorPagamentoTextBox
            // 
            this.valorPagamentoTextBox.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorPagamentoTextBox.Location = new System.Drawing.Point(49, 34);
            this.valorPagamentoTextBox.Name = "valorPagamentoTextBox";
            this.valorPagamentoTextBox.Size = new System.Drawing.Size(208, 40);
            this.valorPagamentoTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor";
            // 
            // btnEfetuarPagamento
            // 
            this.btnEfetuarPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEfetuarPagamento.Location = new System.Drawing.Point(49, 90);
            this.btnEfetuarPagamento.Name = "btnEfetuarPagamento";
            this.btnEfetuarPagamento.Size = new System.Drawing.Size(208, 25);
            this.btnEfetuarPagamento.TabIndex = 2;
            this.btnEfetuarPagamento.Text = "Efetuar";
            this.btnEfetuarPagamento.UseVisualStyleBackColor = true;
            this.btnEfetuarPagamento.Click += new System.EventHandler(this.btnEfetuarPagamento_Click);
            // 
            // TEF_Poup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnEfetuarPagamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valorPagamentoTextBox);
            this.Name = "TEF_Poup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEF_Poup";
            this.Load += new System.EventHandler(this.TEF_Poup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEfetuarPagamento;
        public System.Windows.Forms.TextBox valorPagamentoTextBox;
    }
}