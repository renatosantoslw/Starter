namespace PDV.VIEW.Forms.Gerenciamento.DAV
{
    partial class LoginAdminDAV
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
            this.ovTXT_Senha = new System.Windows.Forms.TextBox();
            this.ovTXT_Login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_StatusLogin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.logarTextBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ovTXT_Senha
            // 
            this.ovTXT_Senha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Senha.Location = new System.Drawing.Point(91, 119);
            this.ovTXT_Senha.Name = "ovTXT_Senha";
            this.ovTXT_Senha.PasswordChar = '*';
            this.ovTXT_Senha.Size = new System.Drawing.Size(205, 27);
            this.ovTXT_Senha.TabIndex = 27;
            // 
            // ovTXT_Login
            // 
            this.ovTXT_Login.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Login.Location = new System.Drawing.Point(91, 68);
            this.ovTXT_Login.Name = "ovTXT_Login";
            this.ovTXT_Login.Size = new System.Drawing.Size(205, 27);
            this.ovTXT_Login.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(90, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Informe o Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(90, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Informe a Senha";
            // 
            // ovTXT_StatusLogin
            // 
            this.ovTXT_StatusLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ovTXT_StatusLogin.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_StatusLogin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_StatusLogin.ForeColor = System.Drawing.Color.White;
            this.ovTXT_StatusLogin.Location = new System.Drawing.Point(68, 9);
            this.ovTXT_StatusLogin.Name = "ovTXT_StatusLogin";
            this.ovTXT_StatusLogin.Size = new System.Drawing.Size(251, 22);
            this.ovTXT_StatusLogin.TabIndex = 30;
            this.ovTXT_StatusLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(9)))), ((int)(((byte)(96)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(86, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 32;
            this.button1.Text = "&Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logarTextBox
            // 
            this.logarTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(9)))), ((int)(((byte)(96)))));
            this.logarTextBox.FlatAppearance.BorderSize = 0;
            this.logarTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logarTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logarTextBox.ForeColor = System.Drawing.Color.White;
            this.logarTextBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logarTextBox.Location = new System.Drawing.Point(200, 173);
            this.logarTextBox.Name = "logarTextBox";
            this.logarTextBox.Size = new System.Drawing.Size(98, 30);
            this.logarTextBox.TabIndex = 31;
            this.logarTextBox.Text = "&Acessar";
            this.logarTextBox.UseVisualStyleBackColor = false;
            this.logarTextBox.Click += new System.EventHandler(this.logarTextBox_Click);
            // 
            // LoginAdminDAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logarTextBox);
            this.Controls.Add(this.ovTXT_StatusLogin);
            this.Controls.Add(this.ovTXT_Senha);
            this.Controls.Add(this.ovTXT_Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginAdminDAV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login de Administrador";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginAdminDAV_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox ovTXT_Senha;
        public System.Windows.Forms.TextBox ovTXT_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ovTXT_StatusLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logarTextBox;
    }
}