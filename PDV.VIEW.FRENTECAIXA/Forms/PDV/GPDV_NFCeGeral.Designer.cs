namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_NFCeGeral
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_Sequencia = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Serie = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_RazaoSocial = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(108, 358);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(150, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 29;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "CANCELAR";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(264, 358);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(150, 35);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton4.TabIndex = 28;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "SALVAR";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovTXT_Sequencia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_Serie);
            this.groupBox1.Controls.Add(this.ovLBL_RazaoSocial);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 106);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações de Série";
            // 
            // ovTXT_Sequencia
            // 
            this.ovTXT_Sequencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Sequencia.Location = new System.Drawing.Point(116, 68);
            this.ovTXT_Sequencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Sequencia.Name = "ovTXT_Sequencia";
            this.ovTXT_Sequencia.Size = new System.Drawing.Size(262, 22);
            this.ovTXT_Sequencia.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "* Sequência:";
            // 
            // ovTXT_Serie
            // 
            this.ovTXT_Serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Serie.Location = new System.Drawing.Point(116, 35);
            this.ovTXT_Serie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Serie.Name = "ovTXT_Serie";
            this.ovTXT_Serie.Size = new System.Drawing.Size(262, 22);
            this.ovTXT_Serie.TabIndex = 1;
            // 
            // ovLBL_RazaoSocial
            // 
            this.ovLBL_RazaoSocial.AutoSize = true;
            this.ovLBL_RazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_RazaoSocial.Location = new System.Drawing.Point(20, 38);
            this.ovLBL_RazaoSocial.Name = "ovLBL_RazaoSocial";
            this.ovLBL_RazaoSocial.Size = new System.Drawing.Size(59, 16);
            this.ovLBL_RazaoSocial.TabIndex = 5;
            this.ovLBL_RazaoSocial.Text = "* Série:";
            // 
            // GPDV_NFCeGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 416);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(437, 416);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(437, 416);
            this.Name = "GPDV_NFCeGeral";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GERAL NFC-E";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox ovTXT_Sequencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox ovTXT_Serie;
        private System.Windows.Forms.Label ovLBL_RazaoSocial;
    }
}