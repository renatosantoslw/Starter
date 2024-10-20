namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_Categoria));
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Descricao = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Codigo = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_Codigo = new System.Windows.Forms.Label();
            this.imageCategoriaPictureBox = new System.Windows.Forms.PictureBox();
            this.linkTextEdit = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCategoriaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "* Descrição:";
            // 
            // ovTXT_Descricao
            // 
            this.ovTXT_Descricao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Descricao.Location = new System.Drawing.Point(12, 78);
            this.ovTXT_Descricao.Name = "ovTXT_Descricao";
            this.ovTXT_Descricao.Size = new System.Drawing.Size(273, 21);
            this.ovTXT_Descricao.TabIndex = 2;
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Codigo.Location = new System.Drawing.Point(12, 28);
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.ReadOnly = true;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(81, 21);
            this.ovTXT_Codigo.TabIndex = 1;
            // 
            // ovLBL_Codigo
            // 
            this.ovLBL_Codigo.AutoSize = true;
            this.ovLBL_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_Codigo.Location = new System.Drawing.Point(9, 9);
            this.ovLBL_Codigo.Name = "ovLBL_Codigo";
            this.ovLBL_Codigo.Size = new System.Drawing.Size(53, 13);
            this.ovLBL_Codigo.TabIndex = 12;
            this.ovLBL_Codigo.Text = "* Código:";
            // 
            // imageCategoriaPictureBox
            // 
            this.imageCategoriaPictureBox.Location = new System.Drawing.Point(323, 4);
            this.imageCategoriaPictureBox.Name = "imageCategoriaPictureBox";
            this.imageCategoriaPictureBox.Size = new System.Drawing.Size(149, 124);
            this.imageCategoriaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageCategoriaPictureBox.TabIndex = 100;
            this.imageCategoriaPictureBox.TabStop = false;
            // 
            // linkTextEdit
            // 
            this.linkTextEdit.Location = new System.Drawing.Point(12, 119);
            this.linkTextEdit.Name = "linkTextEdit";
            this.linkTextEdit.Size = new System.Drawing.Size(150, 21);
            this.linkTextEdit.TabIndex = 101;
            this.linkTextEdit.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(407, 134);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(65, 25);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton5.Appearance.Options.UseForeColor = true;
            this.simpleButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(335, 132);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton5.Size = new System.Drawing.Size(66, 29);
            this.simpleButton5.TabIndex = 112;
            this.simpleButton5.Text = "Cancelar";
            this.simpleButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(187, 119);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(115, 17);
            this.metroButton1.TabIndex = 114;
            this.metroButton1.Text = "Localizar Imagem";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // FCA_Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.linkTextEdit);
            this.Controls.Add(this.imageCategoriaPictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovTXT_Descricao);
            this.Controls.Add(this.ovTXT_Codigo);
            this.Controls.Add(this.ovLBL_Codigo);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_Categoria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Categoria";
            this.Load += new System.EventHandler(this.FCA_Categoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Categoria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageCategoriaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_Descricao;
        private System.Windows.Forms.MaskedTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label ovLBL_Codigo;
        private System.Windows.Forms.PictureBox imageCategoriaPictureBox;
        private System.Windows.Forms.TextBox linkTextEdit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}