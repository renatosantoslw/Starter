
namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    partial class FEST_AltualizarPrecos
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.grdAtualizarPrecos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estoque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustoAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustoNovo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Markup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendaAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendaNovo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_Margem = new PDV.UTIL.Components.Custom.EditDecimal();
            this.label33 = new System.Windows.Forms.Label();
            this.btnAdicionarConversao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtualizarPrecos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Margem)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.grdAtualizarPrecos;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(898, 429);
            this.gridControl1.TabIndex = 120;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAtualizarPrecos});
            // 
            // grdAtualizarPrecos
            // 
            this.grdAtualizarPrecos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grdAtualizarPrecos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdAtualizarPrecos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.White;
            this.grdAtualizarPrecos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grdAtualizarPrecos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.grdAtualizarPrecos.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.grdAtualizarPrecos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.GroupButton.Options.UseForeColor = true;
            this.grdAtualizarPrecos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.grdAtualizarPrecos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.grdAtualizarPrecos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grdAtualizarPrecos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grdAtualizarPrecos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.GroupPanel.Options.UseFont = true;
            this.grdAtualizarPrecos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grdAtualizarPrecos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.grdAtualizarPrecos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdAtualizarPrecos.Appearance.Row.Options.UseFont = true;
            this.grdAtualizarPrecos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grdAtualizarPrecos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grdAtualizarPrecos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdAtualizarPrecos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdAtualizarPrecos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Descricao,
            this.Estoque,
            this.CustoAnterior,
            this.CustoNovo,
            this.Markup,
            this.VendaAnterior,
            this.VendaNovo});
            this.grdAtualizarPrecos.FixedLineWidth = 1;
            this.grdAtualizarPrecos.FooterPanelHeight = 0;
            this.grdAtualizarPrecos.GridControl = this.gridControl1;
            this.grdAtualizarPrecos.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.grdAtualizarPrecos.HorzScrollStep = 50;
            this.grdAtualizarPrecos.Name = "grdAtualizarPrecos";
            this.grdAtualizarPrecos.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.grdAtualizarPrecos.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grdAtualizarPrecos.OptionsEditForm.EditFormColumnCount = 2;
            this.grdAtualizarPrecos.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdAtualizarPrecos.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdAtualizarPrecos.OptionsSelection.MultiSelect = true;
            this.grdAtualizarPrecos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grdAtualizarPrecos.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.grdAtualizarPrecos.OptionsView.ColumnAutoWidth = false;
            this.grdAtualizarPrecos.OptionsView.ShowAutoFilterRow = true;
            this.grdAtualizarPrecos.OptionsView.ShowGroupPanel = false;
            this.grdAtualizarPrecos.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridControl1_CellValueChanged);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "IDProduto";
            this.Codigo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.FixedWidth = true;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 50;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descricao";
            this.Descricao.FieldName = "DescricaoProduto";
            this.Descricao.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Descricao.Name = "Descricao";
            this.Descricao.OptionsColumn.AllowEdit = false;
            this.Descricao.OptionsColumn.FixedWidth = true;
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 2;
            this.Descricao.Width = 250;
            // 
            // Estoque
            // 
            this.Estoque.AppearanceCell.Options.UseTextOptions = true;
            this.Estoque.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Estoque.AppearanceHeader.Options.UseTextOptions = true;
            this.Estoque.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Estoque.Caption = "Estoque";
            this.Estoque.FieldName = "Estoque";
            this.Estoque.Name = "Estoque";
            this.Estoque.OptionsColumn.AllowEdit = false;
            this.Estoque.Visible = true;
            this.Estoque.VisibleIndex = 3;
            this.Estoque.Width = 80;
            // 
            // CustoAnterior
            // 
            this.CustoAnterior.AppearanceCell.Options.UseTextOptions = true;
            this.CustoAnterior.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustoAnterior.AppearanceHeader.Options.UseTextOptions = true;
            this.CustoAnterior.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustoAnterior.Caption = "Custo Anterior";
            this.CustoAnterior.FieldName = "CustoAnterior";
            this.CustoAnterior.Name = "CustoAnterior";
            this.CustoAnterior.OptionsColumn.AllowEdit = false;
            this.CustoAnterior.Visible = true;
            this.CustoAnterior.VisibleIndex = 4;
            this.CustoAnterior.Width = 80;
            // 
            // CustoNovo
            // 
            this.CustoNovo.AppearanceCell.Options.UseTextOptions = true;
            this.CustoNovo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustoNovo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CustoNovo.AppearanceHeader.Options.UseBackColor = true;
            this.CustoNovo.AppearanceHeader.Options.UseTextOptions = true;
            this.CustoNovo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustoNovo.Caption = "Custo Novo";
            this.CustoNovo.FieldName = "CustoNovo";
            this.CustoNovo.Name = "CustoNovo";
            this.CustoNovo.Visible = true;
            this.CustoNovo.VisibleIndex = 5;
            this.CustoNovo.Width = 80;
            // 
            // Markup
            // 
            this.Markup.AppearanceCell.Options.UseTextOptions = true;
            this.Markup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Markup.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Markup.AppearanceHeader.BackColor2 = System.Drawing.Color.Black;
            this.Markup.AppearanceHeader.BorderColor = System.Drawing.Color.Black;
            this.Markup.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.Markup.AppearanceHeader.Options.UseBackColor = true;
            this.Markup.AppearanceHeader.Options.UseBorderColor = true;
            this.Markup.AppearanceHeader.Options.UseForeColor = true;
            this.Markup.AppearanceHeader.Options.UseTextOptions = true;
            this.Markup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Markup.Caption = "Markup %";
            this.Markup.FieldName = "Markup";
            this.Markup.Name = "Markup";
            this.Markup.Visible = true;
            this.Markup.VisibleIndex = 6;
            this.Markup.Width = 80;
            // 
            // VendaAnterior
            // 
            this.VendaAnterior.AppearanceCell.Options.UseTextOptions = true;
            this.VendaAnterior.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VendaAnterior.AppearanceHeader.Options.UseTextOptions = true;
            this.VendaAnterior.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VendaAnterior.Caption = "Venda Anterior";
            this.VendaAnterior.FieldName = "ValorAnterior";
            this.VendaAnterior.Name = "VendaAnterior";
            this.VendaAnterior.OptionsColumn.AllowEdit = false;
            this.VendaAnterior.Visible = true;
            this.VendaAnterior.VisibleIndex = 7;
            this.VendaAnterior.Width = 80;
            // 
            // VendaNovo
            // 
            this.VendaNovo.AppearanceCell.Options.UseTextOptions = true;
            this.VendaNovo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VendaNovo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.VendaNovo.AppearanceHeader.Options.UseBackColor = true;
            this.VendaNovo.AppearanceHeader.Options.UseTextOptions = true;
            this.VendaNovo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VendaNovo.Caption = "Venda Novo";
            this.VendaNovo.FieldName = "ValorNovo";
            this.VendaNovo.Name = "VendaNovo";
            this.VendaNovo.Visible = true;
            this.VendaNovo.VisibleIndex = 8;
            this.VendaNovo.Width = 80;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroButton4.Location = new System.Drawing.Point(722, 461);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 122;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.simpleButton2.Location = new System.Drawing.Point(822, 461);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(88, 33);
            this.simpleButton2.TabIndex = 121;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ovTXT_Margem
            // 
            this.ovTXT_Margem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ovTXT_Margem.DecimalPlaces = 4;
            this.ovTXT_Margem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_Margem.Location = new System.Drawing.Point(328, 467);
            this.ovTXT_Margem.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            262144});
            this.ovTXT_Margem.Name = "ovTXT_Margem";
            this.ovTXT_Margem.Sigla = "";
            this.ovTXT_Margem.Size = new System.Drawing.Size(86, 22);
            this.ovTXT_Margem.TabIndex = 142;
            this.ovTXT_Margem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ovTXT_Margem.ThousandsSeparator = true;
            this.ovTXT_Margem.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.ovTXT_Margem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ovTXT_Margem.vdValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ovTXT_Margem.viPrecisao = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ovTXT_Margem.viTamanho = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ovTXT_Margem.ValueChanged += new System.EventHandler(this.ovTXT_Fator_ValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(262, 469);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(54, 14);
            this.label33.TabIndex = 156;
            this.label33.Text = "Margem:";
            this.label33.Click += new System.EventHandler(this.label33_Click);
            // 
            // btnAdicionarConversao
            // 
            this.btnAdicionarConversao.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdicionarConversao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarConversao.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionarConversao.Location = new System.Drawing.Point(420, 467);
            this.btnAdicionarConversao.Name = "btnAdicionarConversao";
            this.btnAdicionarConversao.Size = new System.Drawing.Size(97, 23);
            this.btnAdicionarConversao.TabIndex = 157;
            this.btnAdicionarConversao.Text = "Atualizar";
            this.btnAdicionarConversao.UseVisualStyleBackColor = true;
            this.btnAdicionarConversao.Click += new System.EventHandler(this.btnAdicionarConversao_Click);
            // 
            // FEST_AltualizarPrecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 523);
            this.Controls.Add(this.btnAdicionarConversao);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.ovTXT_Margem);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.gridControl1);
            this.Cursor = System.Windows.Forms.Cursors.PanSW;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEST_AltualizarPrecos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização de Preços";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtualizarPrecos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovTXT_Margem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView grdAtualizarPrecos;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraGrid.Columns.GridColumn Estoque;
        private DevExpress.XtraGrid.Columns.GridColumn CustoAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn CustoNovo;
        private DevExpress.XtraGrid.Columns.GridColumn Markup;
        private DevExpress.XtraGrid.Columns.GridColumn VendaAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn VendaNovo;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        public UTIL.Components.Custom.EditDecimal ovTXT_Margem;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnAdicionarConversao;
    }
}