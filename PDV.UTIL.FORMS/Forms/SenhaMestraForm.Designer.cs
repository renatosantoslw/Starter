namespace PDV.UTIL.FORMS.Forms
{
    partial class SenhaMestraForm
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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.senha = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(9)))), ((int)(((byte)(96)))));
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.Location = new System.Drawing.Point(107, 90);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(73, 30);
            this.btnContinuar.TabIndex = 5;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // senha
            // 
            this.senha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senha.Location = new System.Drawing.Point(56, 51);
            this.senha.Name = "senha";
            this.senha.PasswordChar = '*';
            this.senha.Size = new System.Drawing.Size(177, 23);
            this.senha.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Insira a senha Root";
            // 
            // SenhaMestraForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 144);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.senha);
            this.Controls.Add(this.btnContinuar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SenhaMestraForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Senha Root";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        public System.Windows.Forms.TextBox senha;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}