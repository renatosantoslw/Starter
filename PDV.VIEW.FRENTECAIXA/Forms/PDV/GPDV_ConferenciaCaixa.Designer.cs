namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    partial class GPDV_ConferenciaCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPDV_ConferenciaCaixa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.btnInserir = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboFormaPagamento = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalculado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiferenca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.ocorrenciaDoDiaTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forma de Pagamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(250, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor:";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtValor.Location = new System.Drawing.Point(253, 38);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(154, 21);
            this.txtValor.TabIndex = 2;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(464, 34);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(37, 31);
            this.simpleButton2.TabIndex = 17;
            this.simpleButton2.Text = "Excluir";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(515, 488);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(87, 31);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "Fechar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(608, 488);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnConfirmar.Size = new System.Drawing.Size(100, 31);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Appearance.Options.UseFont = true;
            this.btnInserir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInserir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInserir.ImageOptions.SvgImage")));
            this.btnInserir.Location = new System.Drawing.Point(422, 34);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnInserir.Size = new System.Drawing.Size(36, 31);
            this.btnInserir.TabIndex = 4;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(13, 401);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ocorrência do dia:";
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFormaPagamento.EditValue = "...";
            this.cboFormaPagamento.Location = new System.Drawing.Point(12, 39);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.cboFormaPagamento.Properties.Appearance.Options.UseFont = true;
            this.cboFormaPagamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPagamento.Properties.DisplayMember = "DESCRICAO";
            this.cboFormaPagamento.Properties.NullText = "";
            this.cboFormaPagamento.Properties.PopupView = this.gridView3;
            this.cboFormaPagamento.Properties.ValueMember = "CODIGO";
            this.cboFormaPagamento.Size = new System.Drawing.Size(235, 20);
            this.cboFormaPagamento.TabIndex = 35;
            this.cboFormaPagamento.TextChanged += new System.EventHandler(this.cboFormaPagamento_TextChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridControl1.Location = new System.Drawing.Point(8, 71);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(693, 316);
            this.gridControl1.TabIndex = 112;
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
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNome,
            this.colValor,
            this.colCalculado,
            this.colDiferenca});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 1;
            // 
            // colValor
            // 
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", "n2")});
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 2;
            // 
            // colCalculado
            // 
            this.colCalculado.FieldName = "Calculado";
            this.colCalculado.Name = "colCalculado";
            this.colCalculado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Calculado", "n2")});
            this.colCalculado.Visible = true;
            this.colCalculado.VisibleIndex = 3;
            // 
            // colDiferenca
            // 
            this.colDiferenca.Caption = "Diferença";
            this.colDiferenca.FieldName = "Diferenca";
            this.colDiferenca.Name = "colDiferenca";
            this.colDiferenca.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Diferenca", "n2")});
            this.colDiferenca.Visible = true;
            this.colDiferenca.VisibleIndex = 4;
            // 
            // totalTextEdit
            // 
            this.totalTextEdit.Location = new System.Drawing.Point(560, 398);
            this.totalTextEdit.Name = "totalTextEdit";
            this.totalTextEdit.Properties.ReadOnly = true;
            this.totalTextEdit.Size = new System.Drawing.Size(141, 20);
            this.totalTextEdit.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(512, 401);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Total:";
            // 
            // ocorrenciaDoDiaTextBox
            // 
            this.ocorrenciaDoDiaTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ocorrenciaDoDiaTextBox.Location = new System.Drawing.Point(16, 422);
            this.ocorrenciaDoDiaTextBox.Multiline = true;
            this.ocorrenciaDoDiaTextBox.Name = "ocorrenciaDoDiaTextBox";
            this.ocorrenciaDoDiaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ocorrenciaDoDiaTextBox.Size = new System.Drawing.Size(467, 74);
            this.ocorrenciaDoDiaTextBox.TabIndex = 116;
            // 
            // GPDV_ConferenciaCaixa
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 531);
            this.Controls.Add(this.ocorrenciaDoDiaTextBox);
            this.Controls.Add(this.totalTextEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cboFormaPagamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPDV_ConferenciaCaixa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conferência Caixa";
            this.Load += new System.EventHandler(this.frmConferenciaCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnInserir;
        private System.Windows.Forms.TextBox txtValor;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GridLookUpEdit cboFormaPagamento;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private DevExpress.XtraGrid.Columns.GridColumn colCalculado;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferenca;
        private DevExpress.XtraEditors.TextEdit totalTextEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ocorrenciaDoDiaTextBox;
    }
}