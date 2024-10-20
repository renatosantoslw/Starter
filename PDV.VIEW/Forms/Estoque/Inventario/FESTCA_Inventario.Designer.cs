namespace PDV.VIEW.Forms.Estoque.Inventario
{
    partial class FESTCA_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FESTCA_Inventario));
            this.ovTXT_DataInventairo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ovGB_Itens = new System.Windows.Forms.GroupBox();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ovGB_DadosItem = new System.Windows.Forms.GroupBox();
            this.metroButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.button2 = new System.Windows.Forms.Button();
            this.ovTXT_Produto = new System.Windows.Forms.MaskedTextBox();
            this.ovTXT_CodProduto = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_Quantidade = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ovCMB_Almoxarifado = new MetroFramework.Controls.MetroComboBox();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.ovGB_Itens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.ovGB_DadosItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // ovTXT_DataInventairo
            // 
            this.ovTXT_DataInventairo.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_DataInventairo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_DataInventairo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_DataInventairo.Location = new System.Drawing.Point(57, 24);
            this.ovTXT_DataInventairo.Name = "ovTXT_DataInventairo";
            this.ovTXT_DataInventairo.Size = new System.Drawing.Size(117, 21);
            this.ovTXT_DataInventairo.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(12, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Data:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ovGB_Itens);
            this.groupBox1.Controls.Add(this.ovGB_DadosItem);
            this.groupBox1.Controls.Add(this.ovTXT_DataInventairo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 614);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Inventário";
            // 
            // ovGB_Itens
            // 
            this.ovGB_Itens.Controls.Add(this.metroButton3);
            this.ovGB_Itens.Controls.Add(this.metroButton2);
            this.ovGB_Itens.Controls.Add(this.gridControl1);
            this.ovGB_Itens.Controls.Add(this.metroButton1);
            this.ovGB_Itens.Location = new System.Drawing.Point(6, 152);
            this.ovGB_Itens.Name = "ovGB_Itens";
            this.ovGB_Itens.Size = new System.Drawing.Size(939, 456);
            this.ovGB_Itens.TabIndex = 77;
            this.ovGB_Itens.TabStop = false;
            this.ovGB_Itens.Text = "Itens do Inventário";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.metroButton3.Location = new System.Drawing.Point(845, 26);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 122;
            this.metroButton3.Text = "Remover";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.metroButton2.Location = new System.Drawing.Point(751, 26);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 121;
            this.metroButton2.Text = "Editar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(9, 65);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(924, 371);
            this.gridControl1.TabIndex = 45;
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
            this.gridView1.PaintStyleName = "Default";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.metroButton1.Location = new System.Drawing.Point(657, 26);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 120;
            this.metroButton1.Text = "Novo";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ovGB_DadosItem
            // 
            this.ovGB_DadosItem.BackColor = System.Drawing.Color.White;
            this.ovGB_DadosItem.Controls.Add(this.metroButton7);
            this.ovGB_DadosItem.Controls.Add(this.metroButton6);
            this.ovGB_DadosItem.Controls.Add(this.button2);
            this.ovGB_DadosItem.Controls.Add(this.ovTXT_Produto);
            this.ovGB_DadosItem.Controls.Add(this.ovTXT_CodProduto);
            this.ovGB_DadosItem.Controls.Add(this.label3);
            this.ovGB_DadosItem.Controls.Add(this.ovTXT_Quantidade);
            this.ovGB_DadosItem.Controls.Add(this.label2);
            this.ovGB_DadosItem.Controls.Add(this.label1);
            this.ovGB_DadosItem.Controls.Add(this.ovCMB_Almoxarifado);
            this.ovGB_DadosItem.Location = new System.Drawing.Point(6, 55);
            this.ovGB_DadosItem.Name = "ovGB_DadosItem";
            this.ovGB_DadosItem.Size = new System.Drawing.Size(939, 91);
            this.ovGB_DadosItem.TabIndex = 45;
            this.ovGB_DadosItem.TabStop = false;
            this.ovGB_DadosItem.Text = "Dados do Item";
            // 
            // metroButton7
            // 
            this.metroButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton7.Appearance.Options.UseForeColor = true;
            this.metroButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton7.ImageOptions.Image")));
            this.metroButton7.Location = new System.Drawing.Point(845, 52);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton7.Size = new System.Drawing.Size(88, 33);
            this.metroButton7.TabIndex = 117;
            this.metroButton7.Text = "Salvar";
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton6.Appearance.Options.UseForeColor = true;
            this.metroButton6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton6.ImageOptions.Image")));
            this.metroButton6.Location = new System.Drawing.Point(845, 17);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton6.Size = new System.Drawing.Size(88, 33);
            this.metroButton6.TabIndex = 116;
            this.metroButton6.Text = "Cancelar";
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(246, 55);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 21);
            this.button2.TabIndex = 126;
            this.button2.Text = "...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ovTXT_Produto
            // 
            this.ovTXT_Produto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ovTXT_Produto.Enabled = false;
            this.ovTXT_Produto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Produto.Location = new System.Drawing.Point(289, 55);
            this.ovTXT_Produto.Name = "ovTXT_Produto";
            this.ovTXT_Produto.ReadOnly = true;
            this.ovTXT_Produto.Size = new System.Drawing.Size(494, 21);
            this.ovTXT_Produto.TabIndex = 128;
            // 
            // ovTXT_CodProduto
            // 
            this.ovTXT_CodProduto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ovTXT_CodProduto.Enabled = false;
            this.ovTXT_CodProduto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_CodProduto.Location = new System.Drawing.Point(123, 55);
            this.ovTXT_CodProduto.Name = "ovTXT_CodProduto";
            this.ovTXT_CodProduto.ReadOnly = true;
            this.ovTXT_CodProduto.Size = new System.Drawing.Size(120, 21);
            this.ovTXT_CodProduto.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "* Produto:";
            // 
            // ovTXT_Quantidade
            // 
            this.ovTXT_Quantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Quantidade.DecimalPlaces = 4;
            this.ovTXT_Quantidade.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Quantidade.Location = new System.Drawing.Point(653, 25);
            this.ovTXT_Quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            262144});
            this.ovTXT_Quantidade.Name = "ovTXT_Quantidade";
            this.ovTXT_Quantidade.Sigla = "QT";
            this.ovTXT_Quantidade.Size = new System.Drawing.Size(130, 21);
            this.ovTXT_Quantidade.TabIndex = 26;
            this.ovTXT_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Quantidade.ThousandsSeparator = true;
            this.ovTXT_Quantidade.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Quantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Quantidade.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Quantidade.viPrecisao = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ovTXT_Quantidade.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(571, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "* Quantidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "* Almoxarifado:";
            // 
            // ovCMB_Almoxarifado
            // 
            this.ovCMB_Almoxarifado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovCMB_Almoxarifado.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ovCMB_Almoxarifado.FormattingEnabled = true;
            this.ovCMB_Almoxarifado.ItemHeight = 19;
            this.ovCMB_Almoxarifado.Location = new System.Drawing.Point(123, 24);
            this.ovCMB_Almoxarifado.Name = "ovCMB_Almoxarifado";
            this.ovCMB_Almoxarifado.Size = new System.Drawing.Size(418, 25);
            this.ovCMB_Almoxarifado.TabIndex = 23;
            this.ovCMB_Almoxarifado.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(900, 655);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 119;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(808, 655);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 118;
            this.metroButton5.Text = "Cancelar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // FESTCA_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1016, 748);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1002, 732);
            this.Name = "FESTCA_Inventario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Inventário";
            this.Load += new System.EventHandler(this.FESTCA_Inventario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ovGB_Itens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ovGB_DadosItem.ResumeLayout(false);
            this.ovGB_DadosItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Quantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker ovTXT_DataInventairo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ovGB_DadosItem;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox ovCMB_Almoxarifado;
        private System.Windows.Forms.Label label2;
        private UTIL.Components.Custom.EditDecimal ovTXT_Quantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox ovTXT_Produto;
        private System.Windows.Forms.MaskedTextBox ovTXT_CodProduto;
        private System.Windows.Forms.GroupBox ovGB_Itens;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton metroButton7;
        private DevExpress.XtraEditors.SimpleButton metroButton6;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
    }
}