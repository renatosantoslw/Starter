namespace PDV.VIEW.FRENTECAIXA.Forms
{
    partial class GPDV_DescontoItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPDV_DescontoItem));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDItemVenda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorUnitarioItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescontoPorcentagem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescontoValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorTotalItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemover = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridControl1.Location = new System.Drawing.Point(12, 79);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1076, 559);
            this.gridControl1.TabIndex = 112;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
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
            this.colIDItemVenda,
            this.gridColumn1,
            this.colQuantidade,
            this.colValorUnitarioItem,
            this.colDescontoPorcentagem,
            this.colDescontoValor,
            this.colValorTotalItem});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIDItemVenda
            // 
            this.colIDItemVenda.Caption = "ID";
            this.colIDItemVenda.FieldName = "IDItemVenda";
            this.colIDItemVenda.Name = "colIDItemVenda";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Descrição";
            this.gridColumn1.FieldName = "DescricaoItem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Caption = "Qtd/Peso";
            this.colQuantidade.FieldName = "Quantidade";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.Visible = true;
            this.colQuantidade.VisibleIndex = 1;
            // 
            // colValorUnitarioItem
            // 
            this.colValorUnitarioItem.Caption = "Preço";
            this.colValorUnitarioItem.FieldName = "ValorUnitarioItem";
            this.colValorUnitarioItem.Name = "colValorUnitarioItem";
            this.colValorUnitarioItem.Visible = true;
            this.colValorUnitarioItem.VisibleIndex = 2;
            // 
            // colDescontoPorcentagem
            // 
            this.colDescontoPorcentagem.FieldName = "DescontoPorcentagem";
            this.colDescontoPorcentagem.Name = "colDescontoPorcentagem";
            this.colDescontoPorcentagem.Visible = true;
            this.colDescontoPorcentagem.VisibleIndex = 3;
            // 
            // colDescontoValor
            // 
            this.colDescontoValor.FieldName = "DescontoValor";
            this.colDescontoValor.Name = "colDescontoValor";
            this.colDescontoValor.Visible = true;
            this.colDescontoValor.VisibleIndex = 4;
            // 
            // colValorTotalItem
            // 
            this.colValorTotalItem.Caption = "SubTotal";
            this.colValorTotalItem.FieldName = "Subtotal";
            this.colValorTotalItem.Name = "colValorTotalItem";
            this.colValorTotalItem.Visible = true;
            this.colValorTotalItem.VisibleIndex = 5;
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Appearance.Options.UseForeColor = true;
            this.btnRemover.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.ImageOptions.Image")));
            this.btnRemover.Location = new System.Drawing.Point(936, 26);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnRemover.Size = new System.Drawing.Size(152, 33);
            this.btnRemover.TabIndex = 114;
            this.btnRemover.Text = "[F10] - Finalizar";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Appearance.Options.UseForeColor = true;
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.Location = new System.Drawing.Point(778, 26);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEditar.Size = new System.Drawing.Size(152, 33);
            this.btnEditar.TabIndex = 113;
            this.btnEditar.Text = "[F8] - Lançar Desconto";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // GPDV_DescontoItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1102, 682);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1102, 682);
            this.Name = "GPDV_DescontoItem";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DESCONTO ITEM";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIDItemVenda;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidade;
        private DevExpress.XtraGrid.Columns.GridColumn colDescontoPorcentagem;
        private DevExpress.XtraGrid.Columns.GridColumn colDescontoValor;
        private DevExpress.XtraGrid.Columns.GridColumn colValorUnitarioItem;
        private DevExpress.XtraGrid.Columns.GridColumn colValorTotalItem;
        private DevExpress.XtraEditors.SimpleButton btnRemover;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}