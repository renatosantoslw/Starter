namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Portaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Portaria));
            this.label35 = new System.Windows.Forms.Label();
            this.ovTXT_Titulo = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.TextBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.White;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label35.Location = new System.Drawing.Point(23, 90);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(57, 13);
            this.label35.TabIndex = 58;
            this.label35.Text = "Descrição:";
            // 
            // ovTXT_Titulo
            // 
            this.ovTXT_Titulo.BackColor = System.Drawing.Color.White;
            this.ovTXT_Titulo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Titulo.Location = new System.Drawing.Point(26, 29);
            this.ovTXT_Titulo.Name = "ovTXT_Titulo";
            this.ovTXT_Titulo.Size = new System.Drawing.Size(668, 23);
            this.ovTXT_Titulo.TabIndex = 55;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.White;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label36.Location = new System.Drawing.Point(23, 10);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(46, 13);
            this.label36.TabIndex = 57;
            this.label36.Text = "* Título:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.BackColor = System.Drawing.Color.White;
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Descricao.Location = new System.Drawing.Point(26, 119);
            this.ovTXT_Descricao.Multiline = true;
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ovTXT_Descricao.Size = new System.Drawing.Size(668, 279);
            this.ovTXT_Descricao.TabIndex = 56;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(640, 455);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(546, 455);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FCA_Portaria
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 500);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.ovTXT_Titulo);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(756, 548);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(742, 532);
            this.Name = "FCA_Portaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Portaria";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Portaria_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox ovTXT_Titulo;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox ovTXT_Descricao;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
    }
}