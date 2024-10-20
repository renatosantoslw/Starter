namespace PDV.UTIL.FORMS.Forms
{
    partial class ConversorCriptografia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversorCriptografia));
            this.textoDescriptografadoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textoEncriptografadoText = new System.Windows.Forms.TextBox();
            this.copiarTextoDescriptografadoBtn = new DevExpress.XtraEditors.SimpleButton();
            this.copiarTextoEncriptografadoBtn = new DevExpress.XtraEditors.SimpleButton();
            this.verTextoDescriptografadoBtn = new DevExpress.XtraEditors.SimpleButton();
            this.verTextoEncriptografadoBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // textoDescriptografadoText
            // 
            this.textoDescriptografadoText.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textoDescriptografadoText.Location = new System.Drawing.Point(29, 45);
            this.textoDescriptografadoText.Name = "textoDescriptografadoText";
            this.textoDescriptografadoText.Size = new System.Drawing.Size(412, 21);
            this.textoDescriptografadoText.TabIndex = 0;
            this.textoDescriptografadoText.UseSystemPasswordChar = true;
            this.textoDescriptografadoText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texto descriptografado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto encriptografado";
            // 
            // textoEncriptografadoText
            // 
            this.textoEncriptografadoText.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textoEncriptografadoText.Location = new System.Drawing.Point(29, 102);
            this.textoEncriptografadoText.Name = "textoEncriptografadoText";
            this.textoEncriptografadoText.Size = new System.Drawing.Size(412, 21);
            this.textoEncriptografadoText.TabIndex = 2;
            this.textoEncriptografadoText.UseSystemPasswordChar = true;
            this.textoEncriptografadoText.TextChanged += new System.EventHandler(this.textEncriptografadoText_TextChanged);
            // 
            // copiarTextoDescriptografadoBtn
            // 
            this.copiarTextoDescriptografadoBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("criptografiaBtn.ImageOptions.Image")));
            this.copiarTextoDescriptografadoBtn.Location = new System.Drawing.Point(476, 46);
            this.copiarTextoDescriptografadoBtn.Name = "copiarTextoDescriptografadoBtn";
            this.copiarTextoDescriptografadoBtn.Size = new System.Drawing.Size(23, 20);
            this.copiarTextoDescriptografadoBtn.TabIndex = 32;
            this.copiarTextoDescriptografadoBtn.Click += new System.EventHandler(this.copiarTextoDescriptografadoBtn_Click);
            // 
            // copiarTextoEncriptografadoBtn
            // 
            this.copiarTextoEncriptografadoBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.copiarTextoEncriptografadoBtn.Location = new System.Drawing.Point(476, 103);
            this.copiarTextoEncriptografadoBtn.Name = "copiarTextoEncriptografadoBtn";
            this.copiarTextoEncriptografadoBtn.Size = new System.Drawing.Size(23, 20);
            this.copiarTextoEncriptografadoBtn.TabIndex = 33;
            this.copiarTextoEncriptografadoBtn.Click += new System.EventHandler(this.copiarTextoEncriptografadoBtn_Click);
            // 
            // verTextoDescriptografadoBtn
            // 
            this.verTextoDescriptografadoBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image1")));
            this.verTextoDescriptografadoBtn.Location = new System.Drawing.Point(447, 45);
            this.verTextoDescriptografadoBtn.Name = "verTextoDescriptografadoBtn";
            this.verTextoDescriptografadoBtn.Size = new System.Drawing.Size(23, 20);
            this.verTextoDescriptografadoBtn.TabIndex = 34;
            this.verTextoDescriptografadoBtn.Click += new System.EventHandler(this.verTextoDescriptografadoBtn_Click);
            // 
            // verTextoEncriptografadoBtn
            // 
            this.verTextoEncriptografadoBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.verTextoEncriptografadoBtn.Location = new System.Drawing.Point(447, 103);
            this.verTextoEncriptografadoBtn.Name = "verTextoEncriptografadoBtn";
            this.verTextoEncriptografadoBtn.Size = new System.Drawing.Size(23, 20);
            this.verTextoEncriptografadoBtn.TabIndex = 35;
            this.verTextoEncriptografadoBtn.Click += new System.EventHandler(this.verTextoEncriptografadoBtn_Click);
            // 
            // ConversorCriptografia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 207);
            this.Controls.Add(this.verTextoEncriptografadoBtn);
            this.Controls.Add(this.verTextoDescriptografadoBtn);
            this.Controls.Add(this.copiarTextoEncriptografadoBtn);
            this.Controls.Add(this.copiarTextoDescriptografadoBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textoEncriptografadoText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textoDescriptografadoText);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ConversorCriptografia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criptografia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoDescriptografadoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textoEncriptografadoText;
        private DevExpress.XtraEditors.SimpleButton copiarTextoDescriptografadoBtn;
        private DevExpress.XtraEditors.SimpleButton copiarTextoEncriptografadoBtn;
        private DevExpress.XtraEditors.SimpleButton verTextoDescriptografadoBtn;
        private DevExpress.XtraEditors.SimpleButton verTextoEncriptografadoBtn;
    }
}