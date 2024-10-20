namespace PDV.UTIL.FORMS.Forms.Atualizador
{
    partial class FAT_AtualizarVersao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAT_AtualizarVersao));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ovTXT_Download = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovPB_Carregando = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovLBL_VersaoDisponivel = new System.Windows.Forms.Label();
            this.ovLBL_VersaoAtual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTimer = new System.Windows.Forms.Timer(this.components);
            this.ovBTN_AtualizarVersao = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovPB_Carregando)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ovTXT_Download
            // 
            this.ovTXT_Download.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Download.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ovTXT_Download.Location = new System.Drawing.Point(23, 396);
            this.ovTXT_Download.Name = "ovTXT_Download";
            this.ovTXT_Download.Size = new System.Drawing.Size(479, 22);
            this.ovTXT_Download.TabIndex = 19;
            this.ovTXT_Download.Text = "Download";
            this.ovTXT_Download.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovPB_Carregando);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovLBL_VersaoDisponivel);
            this.groupBox1.Controls.Add(this.ovLBL_VersaoAtual);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(23, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versão";
            // 
            // ovPB_Carregando
            // 
            this.ovPB_Carregando.Location = new System.Drawing.Point(389, 18);
            this.ovPB_Carregando.Name = "ovPB_Carregando";
            this.ovPB_Carregando.Size = new System.Drawing.Size(84, 76);
            this.ovPB_Carregando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ovPB_Carregando.TabIndex = 11;
            this.ovPB_Carregando.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(23, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Disponível:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Atual:";
            // 
            // ovLBL_VersaoDisponivel
            // 
            this.ovLBL_VersaoDisponivel.AutoSize = true;
            this.ovLBL_VersaoDisponivel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ovLBL_VersaoDisponivel.ForeColor = System.Drawing.Color.Gray;
            this.ovLBL_VersaoDisponivel.Location = new System.Drawing.Point(114, 58);
            this.ovLBL_VersaoDisponivel.Name = "ovLBL_VersaoDisponivel";
            this.ovLBL_VersaoDisponivel.Size = new System.Drawing.Size(189, 17);
            this.ovLBL_VersaoDisponivel.TabIndex = 10;
            this.ovLBL_VersaoDisponivel.Text = "Nenhuma Versão Disponível...";
            // 
            // ovLBL_VersaoAtual
            // 
            this.ovLBL_VersaoAtual.AutoSize = true;
            this.ovLBL_VersaoAtual.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ovLBL_VersaoAtual.ForeColor = System.Drawing.Color.Gray;
            this.ovLBL_VersaoAtual.Location = new System.Drawing.Point(79, 35);
            this.ovLBL_VersaoAtual.Name = "ovLBL_VersaoAtual";
            this.ovLBL_VersaoAtual.Size = new System.Drawing.Size(42, 17);
            this.ovLBL_VersaoAtual.TabIndex = 8;
            this.ovLBL_VersaoAtual.Text = "label2";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(23, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(479, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "RootSys -  Software";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovTimer
            // 
            this.ovTimer.Enabled = true;
            this.ovTimer.Interval = 1000;
            this.ovTimer.Tick += new System.EventHandler(this.ovTimer_Tick);
            // 
            // ovBTN_AtualizarVersao
            // 
            this.ovBTN_AtualizarVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_AtualizarVersao.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ovBTN_AtualizarVersao.Appearance.Options.UseForeColor = true;
            this.ovBTN_AtualizarVersao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ovBTN_AtualizarVersao.ImageOptions.Image")));
            this.ovBTN_AtualizarVersao.Location = new System.Drawing.Point(23, 351);
            this.ovBTN_AtualizarVersao.Name = "ovBTN_AtualizarVersao";
            this.ovBTN_AtualizarVersao.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ovBTN_AtualizarVersao.Size = new System.Drawing.Size(479, 36);
            this.ovBTN_AtualizarVersao.TabIndex = 108;
            this.ovBTN_AtualizarVersao.Text = "Atualizar Versão";
            this.ovBTN_AtualizarVersao.Click += new System.EventHandler(this.ovBTN_AtualizarVersao_Click);
            // 
            // FAT_AtualizarVersao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 490);
            this.Controls.Add(this.ovBTN_AtualizarVersao);
            this.Controls.Add(this.ovTXT_Download);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(541, 529);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(527, 522);
            this.Name = "FAT_AtualizarVersao";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar Atualização";
            this.Load += new System.EventHandler(this.FAT_AtualizarVersao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovPB_Carregando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ovTXT_Download;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ovPB_Carregando;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ovLBL_VersaoDisponivel;
        private System.Windows.Forms.Label ovLBL_VersaoAtual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer ovTimer;
        private DevExpress.XtraEditors.SimpleButton ovBTN_AtualizarVersao;
    }
}