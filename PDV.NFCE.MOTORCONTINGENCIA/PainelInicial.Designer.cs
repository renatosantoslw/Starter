namespace PDV.NFCE.MOTORCONTINGENCIA
{
    partial class PainelInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PainelInicial));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovTXT_Qtd_Autorizada = new System.Windows.Forms.Label();
            this.ovTXT_QtdTransmitida = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Status = new System.Windows.Forms.Label();
            this.ovTXT_Inicio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ovTXT_Rodape = new MetroFramework.Controls.MetroLabel();
            this.ovTXT_Versao = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificarAtualizaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizarNaBandejaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovTXT_Qtd_Autorizada);
            this.groupBox1.Controls.Add(this.ovTXT_QtdTransmitida);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_Status);
            this.groupBox1.Controls.Add(this.ovTXT_Inicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(163, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMAÇÕES DO SERVIÇO";
            // 
            // ovTXT_Qtd_Autorizada
            // 
            this.ovTXT_Qtd_Autorizada.AutoSize = true;
            this.ovTXT_Qtd_Autorizada.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Qtd_Autorizada.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_Qtd_Autorizada.Location = new System.Drawing.Point(444, 61);
            this.ovTXT_Qtd_Autorizada.Name = "ovTXT_Qtd_Autorizada";
            this.ovTXT_Qtd_Autorizada.Size = new System.Drawing.Size(16, 16);
            this.ovTXT_Qtd_Autorizada.TabIndex = 13;
            this.ovTXT_Qtd_Autorizada.Text = "0";
            // 
            // ovTXT_QtdTransmitida
            // 
            this.ovTXT_QtdTransmitida.AutoSize = true;
            this.ovTXT_QtdTransmitida.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_QtdTransmitida.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_QtdTransmitida.Location = new System.Drawing.Point(444, 37);
            this.ovTXT_QtdTransmitida.Name = "ovTXT_QtdTransmitida";
            this.ovTXT_QtdTransmitida.Size = new System.Drawing.Size(16, 16);
            this.ovTXT_QtdTransmitida.TabIndex = 12;
            this.ovTXT_QtdTransmitida.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(249, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Qtd. de NFC-e Autorizadas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(246, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Qtd. de NFC-e Transmitidas:";
            // 
            // ovTXT_Status
            // 
            this.ovTXT_Status.AutoSize = true;
            this.ovTXT_Status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Status.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_Status.Location = new System.Drawing.Point(71, 61);
            this.ovTXT_Status.Name = "ovTXT_Status";
            this.ovTXT_Status.Size = new System.Drawing.Size(42, 16);
            this.ovTXT_Status.TabIndex = 9;
            this.ovTXT_Status.Text = "Início";
            // 
            // ovTXT_Inicio
            // 
            this.ovTXT_Inicio.AutoSize = true;
            this.ovTXT_Inicio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Inicio.ForeColor = System.Drawing.Color.SteelBlue;
            this.ovTXT_Inicio.Location = new System.Drawing.Point(71, 37);
            this.ovTXT_Inicio.Name = "ovTXT_Inicio";
            this.ovTXT_Inicio.Size = new System.Drawing.Size(42, 16);
            this.ovTXT_Inicio.TabIndex = 8;
            this.ovTXT_Inicio.Text = "Início";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(22, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Início:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // ovTXT_Rodape
            // 
            this.ovTXT_Rodape.Location = new System.Drawing.Point(163, 546);
            this.ovTXT_Rodape.Name = "ovTXT_Rodape";
            this.ovTXT_Rodape.Size = new System.Drawing.Size(528, 23);
            this.ovTXT_Rodape.TabIndex = 11;
            this.ovTXT_Rodape.Text = "metroLabel1";
            this.ovTXT_Rodape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTXT_Versao
            // 
            this.ovTXT_Versao.Location = new System.Drawing.Point(23, 546);
            this.ovTXT_Versao.Name = "ovTXT_Versao";
            this.ovTXT_Versao.Size = new System.Drawing.Size(134, 23);
            this.ovTXT_Versao.TabIndex = 12;
            this.ovTXT_Versao.Text = "metroLabel1";
            this.ovTXT_Versao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verificarAtualizaçõesToolStripMenuItem,
            this.minimizarNaBandejaToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.ajudaToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajudaToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.ajudaToolStripMenuItem.Text = "CONTROLES";
            // 
            // verificarAtualizaçõesToolStripMenuItem
            // 
            this.verificarAtualizaçõesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.verificarAtualizaçõesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verificarAtualizaçõesToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.verificarAtualizaçõesToolStripMenuItem.Name = "verificarAtualizaçõesToolStripMenuItem";
            this.verificarAtualizaçõesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.verificarAtualizaçõesToolStripMenuItem.Text = "VERIFICAR ATUALIZAÇÕES";
            this.verificarAtualizaçõesToolStripMenuItem.Click += new System.EventHandler(this.verificarAtualizaçõesToolStripMenuItem_Click);
            // 
            // minimizarNaBandejaToolStripMenuItem
            // 
            this.minimizarNaBandejaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.minimizarNaBandejaToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizarNaBandejaToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.minimizarNaBandejaToolStripMenuItem.Name = "minimizarNaBandejaToolStripMenuItem";
            this.minimizarNaBandejaToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.minimizarNaBandejaToolStripMenuItem.Text = "MINIMIZAR NA BANDEJA";
            this.minimizarNaBandejaToolStripMenuItem.Click += new System.EventHandler(this.minimizarNaBandejaToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sobreToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobreToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sobreToolStripMenuItem.Text = "SOBRE";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sairToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sairToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sairToolStripMenuItem.Text = "SAIR";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 443);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 89);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(668, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PainelInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 595);
            this.Controls.Add(this.ovTXT_Versao);
            this.Controls.Add(this.ovTXT_Rodape);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(714, 595);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(714, 595);
            this.Name = "PainelInicial";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "RootSys- Motor de Envio de NFC-e em Contingência";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PainelInicial_FormClosing);
            this.Load += new System.EventHandler(this.PainelInicial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ovTXT_Qtd_Autorizada;
        private System.Windows.Forms.Label ovTXT_QtdTransmitida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ovTXT_Status;
        private System.Windows.Forms.Label ovTXT_Inicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private MetroFramework.Controls.MetroLabel ovTXT_Rodape;
        private MetroFramework.Controls.MetroLabel ovTXT_Versao;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificarAtualizaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizarNaBandejaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}