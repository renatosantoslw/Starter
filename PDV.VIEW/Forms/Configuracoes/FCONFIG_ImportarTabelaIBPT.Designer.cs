namespace PDV.VIEW.Forms.Configuracoes
{
    partial class FCONFIG_ImportarTabelaIBPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCONFIG_ImportarTabelaIBPT));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.progressBarBanco = new MetroFramework.Controls.MetroProgressBar();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(26, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 23);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "* Arquivo .CSV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "% Completado da Leitura do Arquivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "% Completado da Importação dos Dados";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 95);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 26);
            this.progressBar.TabIndex = 11;
            // 
            // progressBarBanco
            // 
            this.progressBarBanco.Location = new System.Drawing.Point(26, 153);
            this.progressBarBanco.Name = "progressBarBanco";
            this.progressBarBanco.Size = new System.Drawing.Size(564, 26);
            this.progressBarBanco.TabIndex = 11;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(417, 38);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(150, 22);
            this.metroButton1.TabIndex = 116;
            this.metroButton1.Text = "Carregar Arquivo";
            this.metroButton1.Click += new System.EventHandler(this.ovBTN_CarregarArquivo_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(486, 197);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(104, 30);
            this.simpleButton1.TabIndex = 117;
            this.simpleButton1.Text = "Gravar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FCONFIG_ImportarTabelaIBPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 247);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.progressBarBanco);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(102, 180);
            this.Name = "FCONFIG_ImportarTabelaIBPT";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Tabela do IBPT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroProgressBar progressBarBanco;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}