namespace PDV.VIEW.Forms.Cadastro
{
    partial class FCA_FormaDePagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCA_FormaDePagamento));
            this.ovCMB_Bandeiras = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ovCMB_FormaPagamento = new MetroFramework.Controls.MetroComboBox();
            this.ovCKB_Ativo = new System.Windows.Forms.CheckBox();
            this.ovTXT_Identificacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovCKB_TEF = new System.Windows.Forms.CheckBox();
            this.usaCalendarioComercialcomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fatorduplicataEntradaTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fatorDuplicataSemEntradaTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fatorChequeComEntradaTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fatorChequeSemEntradaTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.diasIntervaloTextBox = new System.Windows.Forms.TextBox();
            this.periodicidadeMetroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pdvCheckBox = new System.Windows.Forms.CheckBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.parcelaTextBox = new DevExpress.XtraEditors.SpinEdit();
            this.radioButtonAVista = new System.Windows.Forms.RadioButton();
            this.radioButtonAPrazo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.desabilitarNumeroDeParcelas = new System.Windows.Forms.Timer(this.components);
            this.checkBoxFiscal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.parcelaTextBox.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovCMB_Bandeiras
            // 
            this.ovCMB_Bandeiras.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Bandeiras.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Bandeiras.FormattingEnabled = true;
            this.ovCMB_Bandeiras.ItemHeight = 19;
            this.ovCMB_Bandeiras.Location = new System.Drawing.Point(26, 86);
            this.ovCMB_Bandeiras.Name = "ovCMB_Bandeiras";
            this.ovCMB_Bandeiras.Size = new System.Drawing.Size(519, 25);
            this.ovCMB_Bandeiras.TabIndex = 3;
            this.ovCMB_Bandeiras.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Bandeira:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Descrição:";
            // 
            // ovCMB_FormaPagamento
            // 
            this.ovCMB_FormaPagamento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_FormaPagamento.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_FormaPagamento.FormattingEnabled = true;
            this.ovCMB_FormaPagamento.ItemHeight = 19;
            this.ovCMB_FormaPagamento.Location = new System.Drawing.Point(26, 28);
            this.ovCMB_FormaPagamento.Name = "ovCMB_FormaPagamento";
            this.ovCMB_FormaPagamento.Size = new System.Drawing.Size(690, 25);
            this.ovCMB_FormaPagamento.TabIndex = 23;
            this.ovCMB_FormaPagamento.UseSelectable = true;
            this.ovCMB_FormaPagamento.SelectedIndexChanged += new System.EventHandler(this.ovCMB_FormaPagamento_SelectedIndexChanged);
            // 
            // ovCKB_Ativo
            // 
            this.ovCKB_Ativo.AutoSize = true;
            this.ovCKB_Ativo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Ativo.Location = new System.Drawing.Point(551, 92);
            this.ovCKB_Ativo.Name = "ovCKB_Ativo";
            this.ovCKB_Ativo.Size = new System.Drawing.Size(51, 17);
            this.ovCKB_Ativo.TabIndex = 24;
            this.ovCKB_Ativo.Text = "Ativo";
            this.ovCKB_Ativo.UseVisualStyleBackColor = true;
            // 
            // ovTXT_Identificacao
            // 
            this.ovTXT_Identificacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Identificacao.Location = new System.Drawing.Point(26, 147);
            this.ovTXT_Identificacao.Name = "ovTXT_Identificacao";
            this.ovTXT_Identificacao.Size = new System.Drawing.Size(690, 23);
            this.ovTXT_Identificacao.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Identificação:";
            // 
            // ovCKB_TEF
            // 
            this.ovCKB_TEF.AutoSize = true;
            this.ovCKB_TEF.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_TEF.Location = new System.Drawing.Point(603, 92);
            this.ovCKB_TEF.Name = "ovCKB_TEF";
            this.ovCKB_TEF.Size = new System.Drawing.Size(44, 17);
            this.ovCKB_TEF.TabIndex = 27;
            this.ovCKB_TEF.Text = "TEF";
            this.ovCKB_TEF.UseVisualStyleBackColor = true;
            // 
            // usaCalendarioComercialcomboBox
            // 
            this.usaCalendarioComercialcomboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usaCalendarioComercialcomboBox.FormattingEnabled = true;
            this.usaCalendarioComercialcomboBox.Items.AddRange(new object[] {
            "S",
            "N"});
            this.usaCalendarioComercialcomboBox.Location = new System.Drawing.Point(27, 318);
            this.usaCalendarioComercialcomboBox.Name = "usaCalendarioComercialcomboBox";
            this.usaCalendarioComercialcomboBox.Size = new System.Drawing.Size(173, 21);
            this.usaCalendarioComercialcomboBox.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Usa Calendario Comercial?";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(23, 241);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(42, 13);
            this.name.TabIndex = 33;
            this.name.Text = "Parcela";
            this.name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(265, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Fator Duplicata c/ Entrada";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fatorduplicataEntradaTextBox
            // 
            this.fatorduplicataEntradaTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatorduplicataEntradaTextBox.Location = new System.Drawing.Point(268, 318);
            this.fatorduplicataEntradaTextBox.Name = "fatorduplicataEntradaTextBox";
            this.fatorduplicataEntradaTextBox.Size = new System.Drawing.Size(173, 21);
            this.fatorduplicataEntradaTextBox.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Fator Duplicata s/ Entrada";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fatorDuplicataSemEntradaTextBox
            // 
            this.fatorDuplicataSemEntradaTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatorDuplicataSemEntradaTextBox.Location = new System.Drawing.Point(544, 318);
            this.fatorDuplicataSemEntradaTextBox.Name = "fatorDuplicataSemEntradaTextBox";
            this.fatorDuplicataSemEntradaTextBox.Size = new System.Drawing.Size(173, 21);
            this.fatorDuplicataSemEntradaTextBox.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Fator Cheque c/ Entrada";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fatorChequeComEntradaTextBox
            // 
            this.fatorChequeComEntradaTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatorChequeComEntradaTextBox.Location = new System.Drawing.Point(27, 392);
            this.fatorChequeComEntradaTextBox.Name = "fatorChequeComEntradaTextBox";
            this.fatorChequeComEntradaTextBox.Size = new System.Drawing.Size(173, 21);
            this.fatorChequeComEntradaTextBox.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(265, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Fator Cheque s/ Entrada";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fatorChequeSemEntradaTextBox
            // 
            this.fatorChequeSemEntradaTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatorChequeSemEntradaTextBox.Location = new System.Drawing.Point(268, 392);
            this.fatorChequeSemEntradaTextBox.Name = "fatorChequeSemEntradaTextBox";
            this.fatorChequeSemEntradaTextBox.Size = new System.Drawing.Size(173, 21);
            this.fatorChequeSemEntradaTextBox.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(541, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Dias Intervalo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // diasIntervaloTextBox
            // 
            this.diasIntervaloTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diasIntervaloTextBox.Location = new System.Drawing.Point(544, 392);
            this.diasIntervaloTextBox.Name = "diasIntervaloTextBox";
            this.diasIntervaloTextBox.Size = new System.Drawing.Size(173, 21);
            this.diasIntervaloTextBox.TabIndex = 42;
            // 
            // periodicidadeMetroComboBox
            // 
            this.periodicidadeMetroComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodicidadeMetroComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.periodicidadeMetroComboBox.FormattingEnabled = true;
            this.periodicidadeMetroComboBox.ItemHeight = 19;
            this.periodicidadeMetroComboBox.Items.AddRange(new object[] {
            "Diário",
            "Semanal",
            "Quinzenal",
            "Mensal",
            "Bimestral",
            "35 Dias",
            "45 Dias",
            "Trimestral",
            "Semestral",
            "Anual",
            "Bienal"});
            this.periodicidadeMetroComboBox.Location = new System.Drawing.Point(26, 204);
            this.periodicidadeMetroComboBox.Name = "periodicidadeMetroComboBox";
            this.periodicidadeMetroComboBox.Size = new System.Drawing.Size(502, 25);
            this.periodicidadeMetroComboBox.TabIndex = 45;
            this.periodicidadeMetroComboBox.UseSelectable = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "* Periodicidade :";
            // 
            // pdvCheckBox
            // 
            this.pdvCheckBox.AutoSize = true;
            this.pdvCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pdvCheckBox.Location = new System.Drawing.Point(646, 92);
            this.pdvCheckBox.Name = "pdvCheckBox";
            this.pdvCheckBox.Size = new System.Drawing.Size(50, 17);
            this.pdvCheckBox.TabIndex = 46;
            this.pdvCheckBox.Text = "PDV?";
            this.pdvCheckBox.UseVisualStyleBackColor = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(684, 507);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 115;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.ovBTN_Salvar_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(586, 507);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 114;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Cancelar_Click);
            // 
            // parcelaTextBox
            // 
            this.parcelaTextBox.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.parcelaTextBox.Location = new System.Drawing.Point(26, 260);
            this.parcelaTextBox.Name = "parcelaTextBox";
            this.parcelaTextBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelaTextBox.Properties.Appearance.Options.UseFont = true;
            this.parcelaTextBox.Properties.Appearance.Options.UseTextOptions = true;
            this.parcelaTextBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.parcelaTextBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.parcelaTextBox.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.parcelaTextBox.Properties.IsFloatValue = false;
            this.parcelaTextBox.Properties.Mask.EditMask = "N00";
            this.parcelaTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.parcelaTextBox.Properties.MaxValue = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.parcelaTextBox.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.parcelaTextBox.Size = new System.Drawing.Size(690, 20);
            this.parcelaTextBox.TabIndex = 116;
            // 
            // radioButtonAVista
            // 
            this.radioButtonAVista.AutoSize = true;
            this.radioButtonAVista.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButtonAVista.Location = new System.Drawing.Point(15, 22);
            this.radioButtonAVista.Name = "radioButtonAVista";
            this.radioButtonAVista.Size = new System.Drawing.Size(58, 17);
            this.radioButtonAVista.TabIndex = 117;
            this.radioButtonAVista.Text = "À vista";
            this.radioButtonAVista.UseVisualStyleBackColor = true;
            // 
            // radioButtonAPrazo
            // 
            this.radioButtonAPrazo.AutoSize = true;
            this.radioButtonAPrazo.Checked = true;
            this.radioButtonAPrazo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radioButtonAPrazo.Location = new System.Drawing.Point(91, 22);
            this.radioButtonAPrazo.Name = "radioButtonAPrazo";
            this.radioButtonAPrazo.Size = new System.Drawing.Size(62, 17);
            this.radioButtonAPrazo.TabIndex = 118;
            this.radioButtonAPrazo.TabStop = true;
            this.radioButtonAPrazo.Text = "A prazo";
            this.radioButtonAPrazo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAPrazo);
            this.groupBox1.Controls.Add(this.radioButtonAVista);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(551, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 47);
            this.groupBox1.TabIndex = 119;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transação";
            // 
            // desabilitarNumeroDeParcelas
            // 
            this.desabilitarNumeroDeParcelas.Enabled = true;
            this.desabilitarNumeroDeParcelas.Tick += new System.EventHandler(this.desabilitarNumeroDeParcelas_Tick);
            // 
            // checkBoxFiscal
            // 
            this.checkBoxFiscal.AutoSize = true;
            this.checkBoxFiscal.Location = new System.Drawing.Point(697, 92);
            this.checkBoxFiscal.Name = "checkBoxFiscal";
            this.checkBoxFiscal.Size = new System.Drawing.Size(32, 17);
            this.checkBoxFiscal.TabIndex = 120;
            this.checkBoxFiscal.Text = "F";
            this.checkBoxFiscal.UseVisualStyleBackColor = true;
            // 
            // FCA_FormaDePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 552);
            this.Controls.Add(this.checkBoxFiscal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.pdvCheckBox);
            this.Controls.Add(this.periodicidadeMetroComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.diasIntervaloTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fatorChequeSemEntradaTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.fatorChequeComEntradaTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fatorDuplicataSemEntradaTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fatorduplicataEntradaTextBox);
            this.Controls.Add(this.name);
            this.Controls.Add(this.usaCalendarioComercialcomboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ovCKB_TEF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ovTXT_Identificacao);
            this.Controls.Add(this.ovCKB_Ativo);
            this.Controls.Add(this.ovCMB_FormaPagamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ovCMB_Bandeiras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parcelaTextBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(786, 584);
            this.Name = "FCA_FormaDePagamento";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Forma de Pagamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_FormaDePagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.parcelaTextBox.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_Bandeiras;
        private MetroFramework.Controls.MetroComboBox ovCMB_FormaPagamento;
        private System.Windows.Forms.CheckBox ovCKB_Ativo;
        private System.Windows.Forms.TextBox ovTXT_Identificacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ovCKB_TEF;
        private System.Windows.Forms.ComboBox usaCalendarioComercialcomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fatorduplicataEntradaTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fatorDuplicataSemEntradaTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fatorChequeComEntradaTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fatorChequeSemEntradaTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox diasIntervaloTextBox;
        private MetroFramework.Controls.MetroComboBox periodicidadeMetroComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox pdvCheckBox;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SpinEdit parcelaTextBox;
        private System.Windows.Forms.RadioButton radioButtonAVista;
        private System.Windows.Forms.RadioButton radioButtonAPrazo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer desabilitarNumeroDeParcelas;
        private System.Windows.Forms.CheckBox checkBoxFiscal;
    }
}