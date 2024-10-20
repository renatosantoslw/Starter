namespace PDV.UTIL.FORMS.Forms
{
    partial class AlterarSenha
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
            this.btnLogar = new System.Windows.Forms.Button();
            this.senhaAtualTextBox = new System.Windows.Forms.TextBox();
            this.novasenha01 = new System.Windows.Forms.TextBox();
            this.novasenha02 = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ovTXT_Login = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogar
            // 
            this.btnLogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(9)))), ((int)(((byte)(96)))));
            this.btnLogar.FlatAppearance.BorderSize = 0;
            this.btnLogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogar.ForeColor = System.Drawing.Color.White;
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogar.Location = new System.Drawing.Point(118, 330);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(73, 30);
            this.btnLogar.TabIndex = 5;
            this.btnLogar.Text = "&Alterar";
            this.btnLogar.UseVisualStyleBackColor = false;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // senhaAtualTextBox
            // 
            this.senhaAtualTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senhaAtualTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senhaAtualTextBox.Location = new System.Drawing.Point(67, 200);
            this.senhaAtualTextBox.Name = "senhaAtualTextBox";
            this.senhaAtualTextBox.PasswordChar = '*';
            this.senhaAtualTextBox.Size = new System.Drawing.Size(177, 23);
            this.senhaAtualTextBox.TabIndex = 2;
            // 
            // novasenha01
            // 
            this.novasenha01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.novasenha01.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novasenha01.Location = new System.Drawing.Point(67, 243);
            this.novasenha01.Name = "novasenha01";
            this.novasenha01.PasswordChar = '*';
            this.novasenha01.Size = new System.Drawing.Size(177, 23);
            this.novasenha01.TabIndex = 3;
            // 
            // novasenha02
            // 
            this.novasenha02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.novasenha02.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novasenha02.Location = new System.Drawing.Point(67, 291);
            this.novasenha02.Name = "novasenha02";
            this.novasenha02.PasswordChar = '*';
            this.novasenha02.Size = new System.Drawing.Size(177, 23);
            this.novasenha02.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 181);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Informe a Senha Atual";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(67, 229);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 13);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Informe a Nova Senha";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(67, 272);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(113, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Confirme a Nova Senha";
            // 
            // ovTXT_Login
            // 
            this.ovTXT_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Login.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Login.Location = new System.Drawing.Point(67, 152);
            this.ovTXT_Login.Name = "ovTXT_Login";
            this.ovTXT_Login.Size = new System.Drawing.Size(177, 23);
            this.ovTXT_Login.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(67, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 13);
            this.labelControl4.TabIndex = 37;
            this.labelControl4.Text = "Informe Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PDV.UTIL.FORMS.Properties.Resources.DueERP;
            this.pictureBox1.Location = new System.Drawing.Point(106, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // AlterarSenha
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.ovTXT_Login);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.novasenha02);
            this.Controls.Add(this.novasenha01);
            this.Controls.Add(this.senhaAtualTextBox);
            this.Controls.Add(this.btnLogar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlterarSenha";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AlterarSenha_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogar;
        public System.Windows.Forms.TextBox senhaAtualTextBox;
        public System.Windows.Forms.TextBox novasenha01;
        public System.Windows.Forms.TextBox novasenha02;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.TextBox ovTXT_Login;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}