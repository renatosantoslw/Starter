namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_EnviarPorEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_EnviarPorEmail));
            this.ovTXT_Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ovBTN_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ovTXT_Email
            // 
            this.ovTXT_Email.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Email.Location = new System.Drawing.Point(23, 35);
            this.ovTXT_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Email.Name = "ovTXT_Email";
            this.ovTXT_Email.Size = new System.Drawing.Size(422, 23);
            this.ovTXT_Email.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "* E-mail";
            // 
            // ovBTN_Cancelar
            // 
            this.ovBTN_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_Cancelar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ovBTN_Cancelar.Appearance.Options.UseForeColor = true;
            this.ovBTN_Cancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ovBTN_Cancelar.ImageOptions.SvgImage")));
            this.ovBTN_Cancelar.Location = new System.Drawing.Point(360, 101);
            this.ovBTN_Cancelar.Name = "ovBTN_Cancelar";
            this.ovBTN_Cancelar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ovBTN_Cancelar.Size = new System.Drawing.Size(85, 33);
            this.ovBTN_Cancelar.TabIndex = 131;
            this.ovBTN_Cancelar.Text = "Enviar";
            this.ovBTN_Cancelar.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // GER_EnviarPorEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 175);
            this.Controls.Add(this.ovBTN_Cancelar);
            this.Controls.Add(this.ovTXT_Email);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 214);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 207);
            this.Name = "GER_EnviarPorEmail";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enviar NFC-e/NF-e por e-mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ovTXT_Email;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton ovBTN_Cancelar;
    }
}