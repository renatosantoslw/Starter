namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_InformarDescontoItem
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
            this.ovTXT_ValorDesconto = new System.Windows.Forms.TextBox();
            this.ovTXT_LabelInf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ovTXT_ValorDesconto
            // 
            this.ovTXT_ValorDesconto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovTXT_ValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_ValorDesconto.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_ValorDesconto.Location = new System.Drawing.Point(3, 36);
            this.ovTXT_ValorDesconto.Name = "ovTXT_ValorDesconto";
            this.ovTXT_ValorDesconto.Size = new System.Drawing.Size(254, 40);
            this.ovTXT_ValorDesconto.TabIndex = 0;
            this.ovTXT_ValorDesconto.Text = "0,00";
            this.ovTXT_ValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ovTXT_LabelInf
            // 
            this.ovTXT_LabelInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovTXT_LabelInf.Font = new System.Drawing.Font("Open Sans", 10F);
            this.ovTXT_LabelInf.ForeColor = System.Drawing.Color.Black;
            this.ovTXT_LabelInf.Location = new System.Drawing.Point(3, 102);
            this.ovTXT_LabelInf.Name = "ovTXT_LabelInf";
            this.ovTXT_LabelInf.Size = new System.Drawing.Size(254, 23);
            this.ovTXT_LabelInf.TabIndex = 1;
            this.ovTXT_LabelInf.Text = "(%) Desconto";
            this.ovTXT_LabelInf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GPDV_InformarDescontoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(260, 128);
            this.ControlBox = false;
            this.Controls.Add(this.ovTXT_LabelInf);
            this.Controls.Add(this.ovTXT_ValorDesconto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_InformarDescontoItem";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPDV_InformarDescontoItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ovTXT_ValorDesconto;
        private System.Windows.Forms.Label ovTXT_LabelInf;
    }
}