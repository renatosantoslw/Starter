namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_TipoVenda
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
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(32, 64);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(406, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 30;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "[1] - VENDA A VISTA";
            this.metroButton5.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(32, 119);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(406, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 31;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "[3] - VENDA A PRAZO";
            this.metroButton1.UseSelectable = true;
            // 
            // GPDV_TipoVenda
            // 
            this.ClientSize = new System.Drawing.Size(469, 172);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_TipoVenda";
            this.ShowIcon = false;
            this.Text = "Selecione o Tipo de Venda";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}