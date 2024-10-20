namespace PDV.UTIL.FORMS.Forms
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ovTXT_Login = new System.Windows.Forms.TextBox();
            this.ovTXT_Senha = new System.Windows.Forms.TextBox();
            this.ovTXT_StatusLogin = new System.Windows.Forms.Label();
            this.ovCKB_Lembrar = new System.Windows.Forms.CheckBox();
            this.ovTXT_Versao = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLogar = new System.Windows.Forms.Button();
            this.btnConfig = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pictureBox1DueERP = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1DuePDV = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new PDV.UTIL.Components.Custom.PictureBox();
            this.pictureBox2 = new PDV.UTIL.Components.Custom.PictureBox();
            this.lblShortDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSairFooter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1DueERP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1DuePDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ovTXT_Login
            // 
            this.ovTXT_Login.BackColor = System.Drawing.Color.White;
            this.ovTXT_Login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_Login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ovTXT_Login.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Login.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_Login.Location = new System.Drawing.Point(393, 208);
            this.ovTXT_Login.Multiline = true;
            this.ovTXT_Login.Name = "ovTXT_Login";
            this.ovTXT_Login.Size = new System.Drawing.Size(162, 17);
            this.ovTXT_Login.TabIndex = 3;
            this.ovTXT_Login.TextChanged += new System.EventHandler(this.ovTXT_Login_TextChanged);
            // 
            // ovTXT_Senha
            // 
            this.ovTXT_Senha.BackColor = System.Drawing.Color.White;
            this.ovTXT_Senha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ovTXT_Senha.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Senha.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_Senha.Location = new System.Drawing.Point(393, 276);
            this.ovTXT_Senha.Multiline = true;
            this.ovTXT_Senha.Name = "ovTXT_Senha";
            this.ovTXT_Senha.PasswordChar = '•';
            this.ovTXT_Senha.Size = new System.Drawing.Size(162, 18);
            this.ovTXT_Senha.TabIndex = 4;
            this.ovTXT_Senha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovTXT_Senha_KeyUp);
            // 
            // ovTXT_StatusLogin
            // 
            this.ovTXT_StatusLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ovTXT_StatusLogin.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_StatusLogin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_StatusLogin.ForeColor = System.Drawing.Color.White;
            this.ovTXT_StatusLogin.Location = new System.Drawing.Point(288, -28);
            this.ovTXT_StatusLogin.Name = "ovTXT_StatusLogin";
            this.ovTXT_StatusLogin.Size = new System.Drawing.Size(120, 23);
            this.ovTXT_StatusLogin.TabIndex = 9;
            this.ovTXT_StatusLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovCKB_Lembrar
            // 
            this.ovCKB_Lembrar.AutoSize = true;
            this.ovCKB_Lembrar.BackColor = System.Drawing.Color.Transparent;
            this.ovCKB_Lembrar.Checked = true;
            this.ovCKB_Lembrar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ovCKB_Lembrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCKB_Lembrar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ovCKB_Lembrar.Location = new System.Drawing.Point(387, 302);
            this.ovCKB_Lembrar.Name = "ovCKB_Lembrar";
            this.ovCKB_Lembrar.Size = new System.Drawing.Size(126, 20);
            this.ovCKB_Lembrar.TabIndex = 13;
            this.ovCKB_Lembrar.Text = "Lembrar Usuário";
            this.ovCKB_Lembrar.UseVisualStyleBackColor = false;
            // 
            // ovTXT_Versao
            // 
            this.ovTXT_Versao.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ovTXT_Versao.AutoSize = true;
            this.ovTXT_Versao.BackColor = System.Drawing.Color.Transparent;
            this.ovTXT_Versao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Versao.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ovTXT_Versao.Location = new System.Drawing.Point(319, 428);
            this.ovTXT_Versao.Name = "ovTXT_Versao";
            this.ovTXT_Versao.Size = new System.Drawing.Size(40, 13);
            this.ovTXT_Versao.TabIndex = 17;
            this.ovTXT_Versao.Text = "Versão";
            this.ovTXT_Versao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ovTXT_Versao.Click += new System.EventHandler(this.ovTXT_Login_TextChanged);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImage = global::PDV.UTIL.FORMS.Properties.Resources.sair1;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.Location = new System.Drawing.Point(498, 326);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(98, 38);
            this.btnSair.TabIndex = 23;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnLogar
            // 
            this.btnLogar.BackColor = System.Drawing.Color.Transparent;
            this.btnLogar.BackgroundImage = global::PDV.UTIL.FORMS.Properties.Resources.entrar;
            this.btnLogar.FlatAppearance.BorderSize = 0;
            this.btnLogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogar.ForeColor = System.Drawing.Color.White;
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogar.Location = new System.Drawing.Point(389, 326);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(98, 38);
            this.btnLogar.TabIndex = 19;
            this.btnLogar.Text = "&Acessar";
            this.btnLogar.UseVisualStyleBackColor = false;
            this.btnLogar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.Appearance.Options.UseFont = true;
            this.btnConfig.ImageOptions.Image = global::PDV.UTIL.FORMS.Properties.Resources.config_login;
            this.btnConfig.Location = new System.Drawing.Point(562, 418);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnConfig.Size = new System.Drawing.Size(30, 30);
            this.btnConfig.TabIndex = 28;
            this.btnConfig.Text = "Configuração";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = global::PDV.UTIL.FORMS.Properties.Resources.unlock;
            this.simpleButton2.Location = new System.Drawing.Point(605, 418);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(30, 30);
            this.simpleButton2.TabIndex = 29;
            this.simpleButton2.Text = "Licença";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // pictureBox1DueERP
            // 
            this.pictureBox1DueERP.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1DueERP.Image = global::PDV.UTIL.FORMS.Properties.Resources.logoprograma;
            this.pictureBox1DueERP.Location = new System.Drawing.Point(27, 62);
            this.pictureBox1DueERP.Name = "pictureBox1DueERP";
            this.pictureBox1DueERP.Size = new System.Drawing.Size(327, 272);
            this.pictureBox1DueERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1DueERP.TabIndex = 30;
            this.pictureBox1DueERP.TabStop = false;
            this.pictureBox1DueERP.Visible = false;
            this.pictureBox1DueERP.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(387, 178);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 16);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Login";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(387, 243);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 16);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Senha";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkSlateGray;
            this.linkLabel1.Location = new System.Drawing.Point(513, 303);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(87, 16);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Mudar Senha";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1DuePDV
            // 
            this.pictureBox1DuePDV.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1DuePDV.Image = global::PDV.UTIL.FORMS.Properties.Resources.logoprograma;
            this.pictureBox1DuePDV.Location = new System.Drawing.Point(27, 62);
            this.pictureBox1DuePDV.Name = "pictureBox1DuePDV";
            this.pictureBox1DuePDV.Size = new System.Drawing.Size(327, 272);
            this.pictureBox1DuePDV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1DuePDV.TabIndex = 37;
            this.pictureBox1DuePDV.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.IDItemMenu = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pictureBox3.Image = global::PDV.UTIL.FORMS.Properties.Resources.Cadeado31;
            this.pictureBox3.Location = new System.Drawing.Point(573, 273);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.IDItemMenu = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pictureBox2.Image = global::PDV.UTIL.FORMS.Properties.Resources.User31;
            this.pictureBox2.Location = new System.Drawing.Point(574, 206);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // lblShortDate
            // 
            this.lblShortDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShortDate.AutoSize = true;
            this.lblShortDate.BackColor = System.Drawing.Color.Transparent;
            this.lblShortDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortDate.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblShortDate.Location = new System.Drawing.Point(212, 407);
            this.lblShortDate.Name = "lblShortDate";
            this.lblShortDate.Size = new System.Drawing.Size(192, 14);
            this.lblShortDate.TabIndex = 434;
            this.lblShortDate.Text = "Palmas , 14 de Março de 2021";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(611, 355);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(78, 47);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 435;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Sair.png");
            this.imageList1.Images.SetKeyName(1, "Sair-Over.png");
            this.imageList1.Images.SetKeyName(2, "Acessar.png");
            this.imageList1.Images.SetKeyName(3, "Acessar-Over.png");
            // 
            // btnSairFooter
            // 
            this.btnSairFooter.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairFooter.Appearance.Options.UseFont = true;
            this.btnSairFooter.ImageOptions.Image = global::PDV.UTIL.FORMS.Properties.Resources.Sair5;
            this.btnSairFooter.Location = new System.Drawing.Point(517, 418);
            this.btnSairFooter.Name = "btnSairFooter";
            this.btnSairFooter.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSairFooter.Size = new System.Drawing.Size(30, 30);
            this.btnSairFooter.TabIndex = 437;
            this.btnSairFooter.Text = "Configuração";
            this.btnSairFooter.Click += new System.EventHandler(this.btnSairFooter_Click);
            // 
            // Login
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::PDV.UTIL.FORMS.Properties.Resources.Tela11;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.btnSairFooter);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblShortDate);
            this.Controls.Add(this.pictureBox1DuePDV);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.ovTXT_Versao);
            this.Controls.Add(this.ovCKB_Lembrar);
            this.Controls.Add(this.ovTXT_StatusLogin);
            this.Controls.Add(this.ovTXT_Senha);
            this.Controls.Add(this.ovTXT_Login);
            this.Controls.Add(this.pictureBox1DueERP);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Login.IconOptions.Icon")));
            this.InactiveGlowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1DueERP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1DuePDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ovTXT_StatusLogin;
        public System.Windows.Forms.TextBox ovTXT_Login;
        public System.Windows.Forms.TextBox ovTXT_Senha;
        public System.Windows.Forms.CheckBox ovCKB_Lembrar;
        public System.Windows.Forms.Label ovTXT_Versao;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Button btnSair;
        private DevExpress.XtraEditors.SimpleButton btnConfig;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.Windows.Forms.PictureBox pictureBox1DueERP;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Components.Custom.PictureBox pictureBox2;
        private Components.Custom.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1DuePDV;
        public System.Windows.Forms.Label lblShortDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btnSairFooter;
    }
}