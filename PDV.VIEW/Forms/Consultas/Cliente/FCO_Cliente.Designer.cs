namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCO_Cliente));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.excluircliente = new DevExpress.XtraEditors.SimpleButton();
            this.editarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.imprimriMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.atualizarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.selecionarSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.btnAssociarVendedor = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
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
            this.gridView1.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.gridView1_PrintInitialize);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(814, 470);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // excluircliente
            // 
            this.excluircliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.excluircliente.Appearance.ForeColor = System.Drawing.Color.Black;
            this.excluircliente.Appearance.Options.UseForeColor = true;
            this.excluircliente.Enabled = false;
            this.excluircliente.Location = new System.Drawing.Point(395, 4);
            this.excluircliente.Name = "excluircliente";
            this.excluircliente.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.excluircliente.Size = new System.Drawing.Size(88, 33);
            this.excluircliente.TabIndex = 111;
            this.excluircliente.Text = "Remover";
            this.excluircliente.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // editarMetroButton
            // 
            this.editarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editarMetroButton.Appearance.Options.UseForeColor = true;
            this.editarMetroButton.Enabled = false;
            this.editarMetroButton.Location = new System.Drawing.Point(303, 4);
            this.editarMetroButton.Name = "editarMetroButton";
            this.editarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editarMetroButton.Size = new System.Drawing.Size(76, 33);
            this.editarMetroButton.TabIndex = 110;
            this.editarMetroButton.Text = "Editar";
            this.editarMetroButton.Click += new System.EventHandler(this.editarMetroButton_Click);
            // 
            // imprimriMetroButton
            // 
            this.imprimriMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimriMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.imprimriMetroButton.Appearance.Options.UseForeColor = true;
            this.imprimriMetroButton.Location = new System.Drawing.Point(711, 4);
            this.imprimriMetroButton.Name = "imprimriMetroButton";
            this.imprimriMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.imprimriMetroButton.Size = new System.Drawing.Size(88, 33);
            this.imprimriMetroButton.TabIndex = 109;
            this.imprimriMetroButton.Text = "Imprimir";
            this.imprimriMetroButton.Click += new System.EventHandler(this.imprimriMetroButton_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Location = new System.Drawing.Point(212, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(79, 33);
            this.metroButton5.TabIndex = 108;
            this.metroButton5.Text = "Novo";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.atualizarMetroButton.Appearance.Options.UseForeColor = true;
            this.atualizarMetroButton.Location = new System.Drawing.Point(490, 4);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.atualizarMetroButton.Size = new System.Drawing.Size(88, 33);
            this.atualizarMetroButton.TabIndex = 107;
            this.atualizarMetroButton.Text = "Atualizar";
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // selecionarSimpleButton
            // 
            this.selecionarSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selecionarSimpleButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.selecionarSimpleButton.Appearance.Options.UseForeColor = true;
            this.selecionarSimpleButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("selecionarSimpleButton.ImageOptions.SvgImage")));
            this.selecionarSimpleButton.Location = new System.Drawing.Point(710, 519);
            this.selecionarSimpleButton.Name = "selecionarSimpleButton";
            this.selecionarSimpleButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.selecionarSimpleButton.Size = new System.Drawing.Size(104, 33);
            this.selecionarSimpleButton.TabIndex = 112;
            this.selecionarSimpleButton.Text = "Selecionar";
            this.selecionarSimpleButton.Visible = false;
            this.selecionarSimpleButton.Click += new System.EventHandler(this.selecionarSimpleButton_Click);
            // 
            // btnAssociarVendedor
            // 
            this.btnAssociarVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssociarVendedor.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAssociarVendedor.Appearance.Options.UseForeColor = true;
            this.btnAssociarVendedor.Location = new System.Drawing.Point(583, 4);
            this.btnAssociarVendedor.Name = "btnAssociarVendedor";
            this.btnAssociarVendedor.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAssociarVendedor.Size = new System.Drawing.Size(129, 33);
            this.btnAssociarVendedor.TabIndex = 113;
            this.btnAssociarVendedor.Text = "Assoc. Vendedor";
            this.btnAssociarVendedor.Click += new System.EventHandler(this.btnAssociarVendedor_Click);
            // 
            // FCO_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 554);
            this.Controls.Add(this.btnAssociarVendedor);
            this.Controls.Add(this.selecionarSimpleButton);
            this.Controls.Add(this.excluircliente);
            this.Controls.Add(this.editarMetroButton);
            this.Controls.Add(this.imprimriMetroButton);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.atualizarMetroButton);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(786, 586);
            this.Name = "FCO_Cliente";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FCO_Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton excluircliente;
        private DevExpress.XtraEditors.SimpleButton editarMetroButton;
        private DevExpress.XtraEditors.SimpleButton imprimriMetroButton;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton atualizarMetroButton;
        private DevExpress.XtraEditors.SimpleButton selecionarSimpleButton;
        private DevExpress.XtraEditors.SimpleButton btnAssociarVendedor;
    }
}