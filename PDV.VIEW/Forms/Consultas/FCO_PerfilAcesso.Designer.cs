namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_PerfilAcesso
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnRemover = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.atualizarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-3, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(803, 559);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
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
            // 
            // metroButton3
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Appearance.Options.UseForeColor = true;
            this.btnRemover.Enabled = false;
            this.btnRemover.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.btnRemover.Location = new System.Drawing.Point(703, 4);
            this.btnRemover.Name = "metroButton3";
            this.btnRemover.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnRemover.Size = new System.Drawing.Size(88, 33);
            this.btnRemover.TabIndex = 111;
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // editarperfilmetro
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Appearance.Options.UseForeColor = true;
            this.btnEditar.Enabled = false;
            this.btnEditar.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.btnEditar.Location = new System.Drawing.Point(622, 4);
            this.btnEditar.Name = "editarperfilmetro";
            this.btnEditar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEditar.Size = new System.Drawing.Size(75, 33);
            this.btnEditar.TabIndex = 110;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.ovBTN_Editar_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Impirmir;
            this.metroButton1.Location = new System.Drawing.Point(447, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 109;
            this.metroButton1.Text = "Imprimir";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.metroButton5.Location = new System.Drawing.Point(541, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(75, 33);
            this.metroButton5.TabIndex = 108;
            this.metroButton5.Text = "Novo";
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.atualizarMetroButton.Appearance.Options.UseForeColor = true;
            this.atualizarMetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.AtualizarCarregar;
            this.atualizarMetroButton.Location = new System.Drawing.Point(353, 4);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.atualizarMetroButton.Size = new System.Drawing.Size(88, 33);
            this.atualizarMetroButton.TabIndex = 107;
            this.atualizarMetroButton.Text = "Atualizar";
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // FCO_PerfilAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.atualizarMetroButton);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCO_PerfilAcesso";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perfil de Acesso";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRemover;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton atualizarMetroButton;
    }
}