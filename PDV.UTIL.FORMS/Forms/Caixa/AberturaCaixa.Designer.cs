namespace PDV.UTIL.FORMS.Forms.Caixa
{
    partial class AberturaCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AberturaCaixa));
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Usuario = new System.Windows.Forms.TextBox();
            this.ovTXT_DataHora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label4 = new System.Windows.Forms.Label();
            this.caixaComboBox = new System.Windows.Forms.ComboBox();
            this.ovTXT_Valor = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.contadorMoedasButton = new System.Windows.Forms.Button();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário:";
            // 
            // ovTXT_Usuario
            // 
            this.ovTXT_Usuario.Enabled = false;
            this.ovTXT_Usuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Usuario.Location = new System.Drawing.Point(201, 57);
            this.ovTXT_Usuario.Name = "ovTXT_Usuario";
            this.ovTXT_Usuario.ReadOnly = true;
            this.ovTXT_Usuario.Size = new System.Drawing.Size(151, 27);
            this.ovTXT_Usuario.TabIndex = 0;
            this.ovTXT_Usuario.TabStop = false;
            // 
            // ovTXT_DataHora
            // 
            this.ovTXT_DataHora.Enabled = false;
            this.ovTXT_DataHora.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_DataHora.Location = new System.Drawing.Point(201, 90);
            this.ovTXT_DataHora.Name = "ovTXT_DataHora";
            this.ovTXT_DataHora.ReadOnly = true;
            this.ovTXT_DataHora.Size = new System.Drawing.Size(151, 27);
            this.ovTXT_DataHora.TabIndex = 0;
            this.ovTXT_DataHora.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data/Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "* Valor:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Caixa :";
            // 
            // caixaComboBox
            // 
            this.caixaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.caixaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.caixaComboBox.FormattingEnabled = true;
            this.caixaComboBox.Location = new System.Drawing.Point(201, 24);
            this.caixaComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.caixaComboBox.Name = "caixaComboBox";
            this.caixaComboBox.Size = new System.Drawing.Size(151, 24);
            this.caixaComboBox.TabIndex = 10;
            // 
            // ovTXT_Valor
            // 
            this.ovTXT_Valor.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ovTXT_Valor.Location = new System.Drawing.Point(201, 130);
            this.ovTXT_Valor.Name = "ovTXT_Valor";
            this.ovTXT_Valor.Size = new System.Drawing.Size(151, 27);
            this.ovTXT_Valor.TabIndex = 14;
            this.ovTXT_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Valor.TextChanged += new System.EventHandler(this.ovTXT_Valor_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 34);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(97, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // contadorMoedasButton
            // 
            this.contadorMoedasButton.BackColor = System.Drawing.Color.Transparent;
            this.contadorMoedasButton.FlatAppearance.BorderSize = 0;
            this.contadorMoedasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contadorMoedasButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contadorMoedasButton.ForeColor = System.Drawing.Color.Black;
            this.contadorMoedasButton.Image = ((System.Drawing.Image)(resources.GetObject("contadorMoedasButton.Image")));
            this.contadorMoedasButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.contadorMoedasButton.Location = new System.Drawing.Point(8, 165);
            this.contadorMoedasButton.Margin = new System.Windows.Forms.Padding(1);
            this.contadorMoedasButton.Name = "contadorMoedasButton";
            this.contadorMoedasButton.Size = new System.Drawing.Size(107, 36);
            this.contadorMoedasButton.TabIndex = 378;
            this.contadorMoedasButton.TabStop = false;
            this.contadorMoedasButton.Text = "Contador de Moeda";
            this.contadorMoedasButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contadorMoedasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.contadorMoedasButton.UseVisualStyleBackColor = false;
            this.contadorMoedasButton.Click += new System.EventHandler(this.contadorMoedasButton_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(241, 169);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(111, 29);
            this.simpleButton1.TabIndex = 379;
            this.simpleButton1.Text = "Abrir Caixa";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(119, 168);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(111, 29);
            this.simpleButton2.TabIndex = 381;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // AberturaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 210);
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.contadorMoedasButton);
            this.Controls.Add(this.ovTXT_Valor);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.caixaComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_DataHora);
            this.Controls.Add(this.ovTXT_Usuario);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AberturaCaixa";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura de Caixa";
            this.Load += new System.EventHandler(this.AberturaCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_Usuario;
        private System.Windows.Forms.TextBox ovTXT_DataHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox caixaComboBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox ovTXT_Valor;
        public System.Windows.Forms.Button contadorMoedasButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}