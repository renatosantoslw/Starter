namespace PDV.VIEW
{
    partial class Sobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sobre));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ovTXT_Footer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Versao = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(144, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "DUE SISTEMAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 414);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ovTXT_Footer
            // 
            this.ovTXT_Footer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Footer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ovTXT_Footer.Location = new System.Drawing.Point(146, 446);
            this.ovTXT_Footer.Name = "ovTXT_Footer";
            this.ovTXT_Footer.Size = new System.Drawing.Size(321, 31);
            this.ovTXT_Footer.TabIndex = 2;
            this.ovTXT_Footer.Text = " Software";
            this.ovTXT_Footer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Versão:";
            // 
            // ovTXT_Versao
            // 
            this.ovTXT_Versao.AutoSize = true;
            this.ovTXT_Versao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Versao.Location = new System.Drawing.Point(205, 119);
            this.ovTXT_Versao.Name = "ovTXT_Versao";
            this.ovTXT_Versao.Size = new System.Drawing.Size(20, 16);
            this.ovTXT_Versao.TabIndex = 4;
            this.ovTXT_Versao.Text = "...";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(147, 137);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://DUE.com.br";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 285);
            this.label4.TabIndex = 7;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // Sobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 500);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ovTXT_Versao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Footer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sobre";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sobre";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ovTXT_Footer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ovTXT_Versao;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
    }
}