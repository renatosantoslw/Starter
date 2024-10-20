namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_Caixa
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
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_NumeroCaixa = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_Codigo = new System.Windows.Forms.MaskedTextBox();
            this.ovLBL_Codigo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_NomePOS = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.tipoDeVendaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_SerialPOS = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1Mercado = new System.Windows.Forms.CheckBox();
            this.checkBoxRestaurante = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.grouboxRelatorioCaixa = new System.Windows.Forms.GroupBox();
            this.checkBoxMostrarRelatorio = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            this.grouboxRelatorioCaixa.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "* Numero do Caixa";
            // 
            // ovTXT_NumeroCaixa
            // 
            this.ovTXT_NumeroCaixa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_NumeroCaixa.Location = new System.Drawing.Point(18, 74);
            this.ovTXT_NumeroCaixa.Name = "ovTXT_NumeroCaixa";
            this.ovTXT_NumeroCaixa.Size = new System.Drawing.Size(332, 21);
            this.ovTXT_NumeroCaixa.TabIndex = 2;
            // 
            // ovTXT_Codigo
            // 
            this.ovTXT_Codigo.Enabled = false;
            this.ovTXT_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Codigo.Location = new System.Drawing.Point(18, 31);
            this.ovTXT_Codigo.Name = "ovTXT_Codigo";
            this.ovTXT_Codigo.ReadOnly = true;
            this.ovTXT_Codigo.Size = new System.Drawing.Size(81, 21);
            this.ovTXT_Codigo.TabIndex = 1;
            // 
            // ovLBL_Codigo
            // 
            this.ovLBL_Codigo.AutoSize = true;
            this.ovLBL_Codigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovLBL_Codigo.Location = new System.Drawing.Point(15, 12);
            this.ovLBL_Codigo.Name = "ovLBL_Codigo";
            this.ovLBL_Codigo.Size = new System.Drawing.Size(53, 13);
            this.ovLBL_Codigo.TabIndex = 12;
            this.ovLBL_Codigo.Text = "* Código:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "* Serial POS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "* Nome POS";
            // 
            // ovTXT_NomePOS
            // 
            this.ovTXT_NomePOS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_NomePOS.Location = new System.Drawing.Point(18, 167);
            this.ovTXT_NomePOS.Name = "ovTXT_NomePOS";
            this.ovTXT_NomePOS.Size = new System.Drawing.Size(332, 21);
            this.ovTXT_NomePOS.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "* Ativo";
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Checked = true;
            this.checkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAtivo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAtivo.Location = new System.Drawing.Point(74, 268);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAtivo.TabIndex = 31;
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseFont = true;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Location = new System.Drawing.Point(478, 371);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(108, 30);
            this.metroButton4.TabIndex = 113;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseFont = true;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Location = new System.Drawing.Point(601, 371);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(108, 30);
            this.metroButton5.TabIndex = 112;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // tipoDeVendaComboBox
            // 
            this.tipoDeVendaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDeVendaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tipoDeVendaComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoDeVendaComboBox.FormattingEnabled = true;
            this.tipoDeVendaComboBox.Items.AddRange(new object[] {
            "NFCe",
            "MFe",
            "Normal"});
            this.tipoDeVendaComboBox.Location = new System.Drawing.Point(18, 217);
            this.tipoDeVendaComboBox.Name = "tipoDeVendaComboBox";
            this.tipoDeVendaComboBox.Size = new System.Drawing.Size(332, 21);
            this.tipoDeVendaComboBox.TabIndex = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "* Tipo de Emissão Fiscal";
            // 
            // ovTXT_SerialPOS
            // 
            this.ovTXT_SerialPOS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_SerialPOS.Location = new System.Drawing.Point(18, 123);
            this.ovTXT_SerialPOS.Name = "ovTXT_SerialPOS";
            this.ovTXT_SerialPOS.Size = new System.Drawing.Size(332, 21);
            this.ovTXT_SerialPOS.TabIndex = 25;
            // 
            // checkBox1Mercado
            // 
            this.checkBox1Mercado.AutoSize = true;
            this.checkBox1Mercado.Location = new System.Drawing.Point(6, 20);
            this.checkBox1Mercado.Name = "checkBox1Mercado";
            this.checkBox1Mercado.Size = new System.Drawing.Size(83, 18);
            this.checkBox1Mercado.TabIndex = 116;
            this.checkBox1Mercado.Text = "1-Mercado";
            this.checkBox1Mercado.UseVisualStyleBackColor = true;
            this.checkBox1Mercado.CheckedChanged += new System.EventHandler(this.checkBox1Mercado_CheckedChanged);
            // 
            // checkBoxRestaurante
            // 
            this.checkBoxRestaurante.AutoSize = true;
            this.checkBoxRestaurante.Location = new System.Drawing.Point(106, 20);
            this.checkBoxRestaurante.Name = "checkBoxRestaurante";
            this.checkBoxRestaurante.Size = new System.Drawing.Size(103, 18);
            this.checkBoxRestaurante.TabIndex = 117;
            this.checkBoxRestaurante.Text = "2-Restaurante";
            this.checkBoxRestaurante.UseVisualStyleBackColor = true;
            this.checkBoxRestaurante.CheckedChanged += new System.EventHandler(this.checkBoxRestaurante_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox1Mercado);
            this.groupBox1.Controls.Add(this.checkBoxRestaurante);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(118, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 42);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo PDV";
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl2.Controls.Add(this.metroTabPage3);
            this.metroTabControl2.Controls.Add(this.metroTabPage6);
            this.metroTabControl2.Location = new System.Drawing.Point(27, 12);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 1;
            this.metroTabControl2.Size = new System.Drawing.Size(688, 344);
            this.metroTabControl2.TabIndex = 135;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.groupBox1);
            this.metroTabPage3.Controls.Add(this.label5);
            this.metroTabPage3.Controls.Add(this.ovTXT_Codigo);
            this.metroTabPage3.Controls.Add(this.tipoDeVendaComboBox);
            this.metroTabPage3.Controls.Add(this.ovLBL_Codigo);
            this.metroTabPage3.Controls.Add(this.ovTXT_NumeroCaixa);
            this.metroTabPage3.Controls.Add(this.label3);
            this.metroTabPage3.Controls.Add(this.checkBoxAtivo);
            this.metroTabPage3.Controls.Add(this.ovTXT_SerialPOS);
            this.metroTabPage3.Controls.Add(this.label4);
            this.metroTabPage3.Controls.Add(this.label1);
            this.metroTabPage3.Controls.Add(this.label2);
            this.metroTabPage3.Controls.Add(this.ovTXT_NomePOS);
            this.metroTabPage3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 4;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(680, 302);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Principal";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 7;
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.grouboxRelatorioCaixa);
            this.metroTabPage6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(680, 302);
            this.metroTabPage6.TabIndex = 1;
            this.metroTabPage6.Text = "Configurações";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // grouboxRelatorioCaixa
            // 
            this.grouboxRelatorioCaixa.BackColor = System.Drawing.Color.Transparent;
            this.grouboxRelatorioCaixa.Controls.Add(this.checkBoxMostrarRelatorio);
            this.grouboxRelatorioCaixa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouboxRelatorioCaixa.Location = new System.Drawing.Point(14, 16);
            this.grouboxRelatorioCaixa.Name = "grouboxRelatorioCaixa";
            this.grouboxRelatorioCaixa.Size = new System.Drawing.Size(492, 62);
            this.grouboxRelatorioCaixa.TabIndex = 136;
            this.grouboxRelatorioCaixa.TabStop = false;
            this.grouboxRelatorioCaixa.Text = "Relatório do Caixa";
            // 
            // checkBoxMostrarRelatorio
            // 
            this.checkBoxMostrarRelatorio.AutoSize = true;
            this.checkBoxMostrarRelatorio.Location = new System.Drawing.Point(22, 26);
            this.checkBoxMostrarRelatorio.Name = "checkBoxMostrarRelatorio";
            this.checkBoxMostrarRelatorio.Size = new System.Drawing.Size(166, 18);
            this.checkBoxMostrarRelatorio.TabIndex = 116;
            this.checkBoxMostrarRelatorio.Text = "Mostrar Relatório do Caixa";
            this.checkBoxMostrarRelatorio.UseVisualStyleBackColor = true;
            // 
            // FCA_Caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 427);
            this.Controls.Add(this.metroTabControl2);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCA_Caixa";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Caixa PDV";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Caixa_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.metroTabPage6.ResumeLayout(false);
            this.grouboxRelatorioCaixa.ResumeLayout(false);
            this.grouboxRelatorioCaixa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovTXT_NumeroCaixa;
        private System.Windows.Forms.MaskedTextBox ovTXT_Codigo;
        private System.Windows.Forms.Label ovLBL_Codigo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox ovTXT_NomePOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAtivo;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private System.Windows.Forms.ComboBox tipoDeVendaComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox ovTXT_SerialPOS;
        private System.Windows.Forms.CheckBox checkBox1Mercado;
        private System.Windows.Forms.CheckBox checkBoxRestaurante;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private System.Windows.Forms.GroupBox grouboxRelatorioCaixa;
        private System.Windows.Forms.CheckBox checkBoxMostrarRelatorio;
    }
}