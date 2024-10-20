namespace PDV.VIEW.Forms.Financeiro
{
    partial class GFIN_Duplicata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GFIN_Duplicata));
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_ContaCobranca = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.ovCKB_EmRemessa = new System.Windows.Forms.CheckBox();
            this.ovCKB_Impresso = new System.Windows.Forms.CheckBox();
            this.ovCKB_Cancelado = new System.Windows.Forms.CheckBox();
            this.ovCKB_NaoGerado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_EmissaoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoInicio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_Cliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "* Conta:";
            // 
            // ovCMB_ContaCobranca
            // 
            this.ovCMB_ContaCobranca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovCMB_ContaCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ovCMB_ContaCobranca.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_ContaCobranca.FormattingEnabled = true;
            this.ovCMB_ContaCobranca.ItemHeight = 24;
            this.ovCMB_ContaCobranca.Location = new System.Drawing.Point(85, 69);
            this.ovCMB_ContaCobranca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCMB_ContaCobranca.Name = "ovCMB_ContaCobranca";
            this.ovCMB_ContaCobranca.Size = new System.Drawing.Size(691, 30);
            this.ovCMB_ContaCobranca.TabIndex = 5;
            this.ovCMB_ContaCobranca.UseSelectable = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.metroButton2);
            this.groupBox2.Controls.Add(this.metroButton3);
            this.groupBox2.Controls.Add(this.ovCKB_EmRemessa);
            this.groupBox2.Controls.Add(this.ovCKB_Impresso);
            this.groupBox2.Controls.Add(this.ovCKB_Cancelado);
            this.groupBox2.Controls.Add(this.ovCKB_NaoGerado);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ovCMB_ContaCobranca);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ovTXT_EmissaoFim);
            this.groupBox2.Controls.Add(this.ovTXT_EmissaoInicio);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox2.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ovTXT_Cliente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 47);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1391, 150);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(1267, 25);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(117, 39);
            this.metroButton2.TabIndex = 122;
            this.metroButton2.Text = "Pesquisar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(1267, 74);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(117, 39);
            this.metroButton3.TabIndex = 123;
            this.metroButton3.Text = "Limpar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // ovCKB_EmRemessa
            // 
            this.ovCKB_EmRemessa.AutoSize = true;
            this.ovCKB_EmRemessa.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_EmRemessa.Location = new System.Drawing.Point(422, 110);
            this.ovCKB_EmRemessa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCKB_EmRemessa.Name = "ovCKB_EmRemessa";
            this.ovCKB_EmRemessa.Size = new System.Drawing.Size(108, 21);
            this.ovCKB_EmRemessa.TabIndex = 83;
            this.ovCKB_EmRemessa.Text = "Em Remessa";
            this.ovCKB_EmRemessa.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Impresso
            // 
            this.ovCKB_Impresso.AutoSize = true;
            this.ovCKB_Impresso.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Impresso.Location = new System.Drawing.Point(208, 108);
            this.ovCKB_Impresso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCKB_Impresso.Name = "ovCKB_Impresso";
            this.ovCKB_Impresso.Size = new System.Drawing.Size(86, 21);
            this.ovCKB_Impresso.TabIndex = 82;
            this.ovCKB_Impresso.Text = "Impresso";
            this.ovCKB_Impresso.UseVisualStyleBackColor = true;
            // 
            // ovCKB_Cancelado
            // 
            this.ovCKB_Cancelado.AutoSize = true;
            this.ovCKB_Cancelado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_Cancelado.Location = new System.Drawing.Point(311, 108);
            this.ovCKB_Cancelado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCKB_Cancelado.Name = "ovCKB_Cancelado";
            this.ovCKB_Cancelado.Size = new System.Drawing.Size(93, 21);
            this.ovCKB_Cancelado.TabIndex = 81;
            this.ovCKB_Cancelado.Text = "Cancelado";
            this.ovCKB_Cancelado.UseVisualStyleBackColor = true;
            // 
            // ovCKB_NaoGerado
            // 
            this.ovCKB_NaoGerado.AutoSize = true;
            this.ovCKB_NaoGerado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovCKB_NaoGerado.Location = new System.Drawing.Point(85, 108);
            this.ovCKB_NaoGerado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovCKB_NaoGerado.Name = "ovCKB_NaoGerado";
            this.ovCKB_NaoGerado.Size = new System.Drawing.Size(102, 21);
            this.ovCKB_NaoGerado.TabIndex = 80;
            this.ovCKB_NaoGerado.Text = "Não Gerado";
            this.ovCKB_NaoGerado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(7, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "Status:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(1031, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 77;
            this.label6.Text = "Até";
            // 
            // ovTXT_EmissaoFim
            // 
            this.ovTXT_EmissaoFim.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ovTXT_EmissaoFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_EmissaoFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_EmissaoFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_EmissaoFim.Location = new System.Drawing.Point(1070, 28);
            this.ovTXT_EmissaoFim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_EmissaoFim.Name = "ovTXT_EmissaoFim";
            this.ovTXT_EmissaoFim.Size = new System.Drawing.Size(131, 24);
            this.ovTXT_EmissaoFim.TabIndex = 3;
            // 
            // ovTXT_EmissaoInicio
            // 
            this.ovTXT_EmissaoInicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ovTXT_EmissaoInicio.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_EmissaoInicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_EmissaoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_EmissaoInicio.Location = new System.Drawing.Point(888, 28);
            this.ovTXT_EmissaoInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_EmissaoInicio.Name = "ovTXT_EmissaoInicio";
            this.ovTXT_EmissaoInicio.Size = new System.Drawing.Size(136, 24);
            this.ovTXT_EmissaoInicio.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(784, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "Emissão:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(1031, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 73;
            this.label5.Text = "Até";
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(1070, 68);
            this.ovTXT_VencimentoFim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(131, 24);
            this.ovTXT_VencimentoFim.TabIndex = 7;
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(888, 68);
            this.ovTXT_VencimentoInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(136, 24);
            this.ovTXT_VencimentoInicio.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(784, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Vencimento:";
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Cliente.Location = new System.Drawing.Point(85, 30);
            this.ovTXT_Cliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Size = new System.Drawing.Size(691, 24);
            this.ovTXT_Cliente.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(7, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Cliente:";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(5, 204);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1391, 519);
            this.gridControl1.TabIndex = 77;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(924, -1);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(157, 41);
            this.simpleButton1.TabIndex = 117;
            this.simpleButton1.Text = "Cancelar Duplicatas";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(1088, -1);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(133, 41);
            this.simpleButton3.TabIndex = 119;
            this.simpleButton3.Text = "Gerar Remessa";
            this.simpleButton3.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton4.Appearance.Options.UseForeColor = true;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(639, -1);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton4.Size = new System.Drawing.Size(126, 41);
            this.simpleButton4.TabIndex = 118;
            this.simpleButton4.Text = "Segunda Via";
            this.simpleButton4.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton7
            // 
            this.metroButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton7.Appearance.Options.UseForeColor = true;
            this.metroButton7.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Baixar;
            this.metroButton7.Location = new System.Drawing.Point(1228, -1);
            this.metroButton7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton7.Size = new System.Drawing.Size(157, 41);
            this.metroButton7.TabIndex = 121;
            this.metroButton7.Text = "Importar Retorno";
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton6.Appearance.Options.UseForeColor = true;
            this.simpleButton6.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.barcode_32x32;
            this.simpleButton6.Location = new System.Drawing.Point(772, -1);
            this.simpleButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton6.Size = new System.Drawing.Size(145, 41);
            this.simpleButton6.TabIndex = 120;
            this.simpleButton6.Text = "Gerar Boleto";
            this.simpleButton6.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // GFIN_Duplicata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 738);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "GFIN_Duplicata";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Duplicatas - Geração de Boletos";
            this.Load += new System.EventHandler(this.GFIN_Duplicata_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox ovCMB_ContaCobranca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoFim;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoFim;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ovTXT_Cliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ovCKB_NaoGerado;
        private System.Windows.Forms.CheckBox ovCKB_Impresso;
        private System.Windows.Forms.CheckBox ovCKB_Cancelado;
        private System.Windows.Forms.CheckBox ovCKB_EmRemessa;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton7;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
    }
}