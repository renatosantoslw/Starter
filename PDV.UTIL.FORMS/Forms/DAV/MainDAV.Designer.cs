namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.DAV
{
    partial class MainDAV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDAV));
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.imprimriMetroButton = new MetroFramework.Controls.MetroButton();
            this.novoMetroButton = new MetroFramework.Controls.MetroButton();
            this.editarMetroButton = new MetroFramework.Controls.MetroButton();
            this.excluirMetroButton = new MetroFramework.Controls.MetroButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.atualizarMetroButton = new MetroFramework.Controls.MetroButton();
            this.gerarFaturamentoMetroButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // imprimriMetroButton
            // 
            this.imprimriMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimriMetroButton.Location = new System.Drawing.Point(532, 4);
            this.imprimriMetroButton.Name = "imprimriMetroButton";
            this.imprimriMetroButton.Size = new System.Drawing.Size(150, 35);
            this.imprimriMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.imprimriMetroButton.TabIndex = 27;
            this.imprimriMetroButton.TabStop = false;
            this.imprimriMetroButton.Text = "IMPRIMIR";
            this.imprimriMetroButton.UseSelectable = true;
            this.imprimriMetroButton.Click += new System.EventHandler(this.imprimriMetroButton_Click);
            // 
            // novoMetroButton
            // 
            this.novoMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.novoMetroButton.Location = new System.Drawing.Point(688, 4);
            this.novoMetroButton.Name = "novoMetroButton";
            this.novoMetroButton.Size = new System.Drawing.Size(150, 35);
            this.novoMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.novoMetroButton.TabIndex = 26;
            this.novoMetroButton.TabStop = false;
            this.novoMetroButton.Text = "NOVO";
            this.novoMetroButton.UseSelectable = true;
            this.novoMetroButton.Click += new System.EventHandler(this.novoMetroButton_Click);
            // 
            // editarMetroButton
            // 
            this.editarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarMetroButton.Enabled = false;
            this.editarMetroButton.Location = new System.Drawing.Point(844, 4);
            this.editarMetroButton.Name = "editarMetroButton";
            this.editarMetroButton.Size = new System.Drawing.Size(150, 35);
            this.editarMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.editarMetroButton.TabIndex = 25;
            this.editarMetroButton.TabStop = false;
            this.editarMetroButton.Text = "EDITAR";
            this.editarMetroButton.UseSelectable = true;
            this.editarMetroButton.Click += new System.EventHandler(this.editarMetroButton_Click);
            // 
            // excluirMetroButton
            // 
            this.excluirMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.excluirMetroButton.Location = new System.Drawing.Point(1000, 4);
            this.excluirMetroButton.Name = "excluirMetroButton";
            this.excluirMetroButton.Size = new System.Drawing.Size(150, 35);
            this.excluirMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.excluirMetroButton.TabIndex = 24;
            this.excluirMetroButton.TabStop = false;
            this.excluirMetroButton.Text = "REMOVER";
            this.excluirMetroButton.UseSelectable = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1150, 407);
            this.gridControl1.TabIndex = 28;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
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
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.PaintStyleName = "Flat";
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarMetroButton.Location = new System.Drawing.Point(376, 4);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.Size = new System.Drawing.Size(150, 35);
            this.atualizarMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.atualizarMetroButton.TabIndex = 29;
            this.atualizarMetroButton.TabStop = false;
            this.atualizarMetroButton.Text = "ATUALIZAR";
            this.atualizarMetroButton.UseSelectable = true;
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // gerarFaturamentoMetroButton
            // 
            this.gerarFaturamentoMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gerarFaturamentoMetroButton.Location = new System.Drawing.Point(220, 4);
            this.gerarFaturamentoMetroButton.Name = "gerarFaturamentoMetroButton";
            this.gerarFaturamentoMetroButton.Size = new System.Drawing.Size(150, 35);
            this.gerarFaturamentoMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.gerarFaturamentoMetroButton.TabIndex = 30;
            this.gerarFaturamentoMetroButton.TabStop = false;
            this.gerarFaturamentoMetroButton.Text = "GERAR FATURAMENTO";
            this.gerarFaturamentoMetroButton.UseSelectable = true;
            this.gerarFaturamentoMetroButton.Click += new System.EventHandler(this.gerarFaturamentoMetroButton_Click);
            // 
            // MainDAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 450);
            this.Controls.Add(this.gerarFaturamentoMetroButton);
            this.Controls.Add(this.atualizarMetroButton);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.imprimriMetroButton);
            this.Controls.Add(this.novoMetroButton);
            this.Controls.Add(this.editarMetroButton);
            this.Controls.Add(this.excluirMetroButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainDAV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAV - Documento Auxiliar de Venda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDAV_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private MetroFramework.Controls.MetroButton imprimriMetroButton;
        private MetroFramework.Controls.MetroButton novoMetroButton;
        private MetroFramework.Controls.MetroButton editarMetroButton;
        private MetroFramework.Controls.MetroButton excluirMetroButton;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private MetroFramework.Controls.MetroButton atualizarMetroButton;
        private MetroFramework.Controls.MetroButton gerarFaturamentoMetroButton;
    }
}