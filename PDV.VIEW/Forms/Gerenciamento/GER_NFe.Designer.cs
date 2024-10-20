namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_NFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_NFe));
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton8 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmitirNFe = new DevExpress.XtraEditors.SimpleButton();
            this.atualizarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.btnBaixarXML = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmailContador = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(1385, 3);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(91, 33);
            this.metroButton1.TabIndex = 126;
            this.metroButton1.Text = "Pesquisar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 101);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1361, 636);
            this.gridControl1.TabIndex = 86;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
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
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.gridView1_PrintInitialize);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.Location = new System.Drawing.Point(3, 5);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(140, 33);
            this.metroButton2.TabIndex = 125;
            this.metroButton2.Text = "Enviar Por E-mail";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.Location = new System.Drawing.Point(497, 5);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(140, 33);
            this.metroButton3.TabIndex = 123;
            this.metroButton3.Text = "Inutilizar Numeração";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton6.Appearance.Options.UseForeColor = true;
            this.metroButton6.Location = new System.Drawing.Point(3, 3);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton6.Size = new System.Drawing.Size(125, 33);
            this.metroButton6.TabIndex = 122;
            this.metroButton6.Text = "Imprimir Danfe";
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Location = new System.Drawing.Point(376, 5);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(115, 33);
            this.metroButton5.TabIndex = 120;
            this.metroButton5.Text = "Cancelar NF-e";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Location = new System.Drawing.Point(230, 5);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(140, 33);
            this.metroButton4.TabIndex = 126;
            this.metroButton4.Text = "Carta de Correção";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton7
            // 
            this.metroButton7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton7.Appearance.Options.UseForeColor = true;
            this.metroButton7.Location = new System.Drawing.Point(3, 5);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton7.Size = new System.Drawing.Size(102, 33);
            this.metroButton7.TabIndex = 121;
            this.metroButton7.Text = "Transmitir";
            this.metroButton7.Click += new System.EventHandler(this.ntnTransmitir_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton8.Appearance.Options.UseForeColor = true;
            this.metroButton8.Location = new System.Drawing.Point(113, 5);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton8.Size = new System.Drawing.Size(100, 33);
            this.metroButton8.TabIndex = 127;
            this.metroButton8.Text = "Editar";
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(111, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(113, 33);
            this.simpleButton1.TabIndex = 128;
            this.simpleButton1.Text = "Consultar NFe";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnEmitirNFe
            // 
            this.btnEmitirNFe.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnEmitirNFe.Appearance.Options.UseForeColor = true;
            this.btnEmitirNFe.Location = new System.Drawing.Point(4, 5);
            this.btnEmitirNFe.Name = "btnEmitirNFe";
            this.btnEmitirNFe.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEmitirNFe.Size = new System.Drawing.Size(100, 33);
            this.btnEmitirNFe.TabIndex = 130;
            this.btnEmitirNFe.Text = "Nova";
            this.btnEmitirNFe.Click += new System.EventHandler(this.btnEmitirNFe_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.atualizarMetroButton.Appearance.Options.UseForeColor = true;
            this.atualizarMetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.AtualizarCarregar;
            this.atualizarMetroButton.Location = new System.Drawing.Point(298, 13);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.atualizarMetroButton.Size = new System.Drawing.Size(38, 33);
            this.atualizarMetroButton.TabIndex = 131;
            this.atualizarMetroButton.Text = "Atualizar";
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl2.Controls.Add(this.metroTabPage5);
            this.metroTabControl2.Controls.Add(this.metroTabPage6);
            this.metroTabControl2.Controls.Add(this.metroTabPage1);
            this.metroTabControl2.Controls.Add(this.metroTabPage3);
            this.metroTabControl2.Location = new System.Drawing.Point(677, 12);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 3;
            this.metroTabControl2.Size = new System.Drawing.Size(681, 83);
            this.metroTabControl2.TabIndex = 132;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.btnBaixarXML);
            this.metroTabPage5.Controls.Add(this.simpleButton2);
            this.metroTabPage5.Controls.Add(this.btnEmitirNFe);
            this.metroTabPage5.Controls.Add(this.metroButton8);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 1;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(673, 41);
            this.metroTabPage5.TabIndex = 0;
            this.metroTabPage5.Text = "Ações";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 2;
            // 
            // btnBaixarXML
            // 
            this.btnBaixarXML.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnBaixarXML.Appearance.Options.UseForeColor = true;
            this.btnBaixarXML.Location = new System.Drawing.Point(343, 5);
            this.btnBaixarXML.Name = "btnBaixarXML";
            this.btnBaixarXML.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBaixarXML.Size = new System.Drawing.Size(100, 33);
            this.btnBaixarXML.TabIndex = 132;
            this.btnBaixarXML.Text = "Baixar XML";
            this.btnBaixarXML.Click += new System.EventHandler(this.btnBaixarXML_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Location = new System.Drawing.Point(225, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(105, 33);
            this.simpleButton2.TabIndex = 131;
            this.simpleButton2.Text = "Visualizar XML";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.metroButton4);
            this.metroTabPage6.Controls.Add(this.metroButton3);
            this.metroTabPage6.Controls.Add(this.simpleButton1);
            this.metroTabPage6.Controls.Add(this.metroButton5);
            this.metroTabPage6.Controls.Add(this.metroButton7);
            this.metroTabPage6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(673, 41);
            this.metroTabPage6.TabIndex = 1;
            this.metroTabPage6.Text = "Sefaz";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.simpleButton3);
            this.metroTabPage1.Controls.Add(this.metroButton6);
            this.metroTabPage1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 4;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(673, 41);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Imprimir";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 7;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.Location = new System.Drawing.Point(134, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(125, 33);
            this.simpleButton3.TabIndex = 123;
            this.simpleButton3.Text = "Imprimir Grid";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.btnEmailContador);
            this.metroTabPage3.Controls.Add(this.metroButton2);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(673, 41);
            this.metroTabPage3.TabIndex = 4;
            this.metroTabPage3.Text = "E-mail";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateEdit1);
            this.groupBox1.Controls.Add(this.dateEdit2);
            this.groupBox1.Controls.Add(this.atualizarMetroButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 57);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(50, 20);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 114;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(175, 20);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 116;
            this.dateEdit2.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 117;
            this.label2.Text = "e";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Entre";
            // 
            // btnEmailContador
            // 
            this.btnEmailContador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailContador.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnEmailContador.Appearance.Options.UseForeColor = true;
            this.btnEmailContador.Location = new System.Drawing.Point(149, 4);
            this.btnEmailContador.Name = "btnEmailContador";
            this.btnEmailContador.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEmailContador.Size = new System.Drawing.Size(140, 33);
            this.btnEmailContador.TabIndex = 126;
            this.btnEmailContador.Text = "Para o Contador";
            this.btnEmailContador.Click += new System.EventHandler(this.btnEmailContador_Click);
            // 
            // GER_NFe
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 740);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroTabControl2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GER_NFe";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " NF-e";
            this.Load += new System.EventHandler(this.GER_NFe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage6.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton6;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton7;
        private DevExpress.XtraEditors.SimpleButton metroButton8;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnEmitirNFe;
        private DevExpress.XtraEditors.SimpleButton atualizarMetroButton;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnBaixarXML;
        private DevExpress.XtraEditors.SimpleButton btnEmailContador;
    }
}