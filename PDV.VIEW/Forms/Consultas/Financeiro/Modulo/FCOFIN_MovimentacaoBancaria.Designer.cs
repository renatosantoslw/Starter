namespace PDV.VIEW.Forms.Consultas.Financeiro.Modulo
{
    partial class FCOFIN_MovimentacaoBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCOFIN_MovimentacaoBancaria));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.editarmovimentacaometroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.imprimriMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.atualizarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton8 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton6 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1290, 555);
            this.gridControl1.TabIndex = 77;
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
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.Enabled = false;
            this.metroButton5.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.metroButton5.Location = new System.Drawing.Point(1193, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(88, 33);
            this.metroButton5.TabIndex = 126;
            this.metroButton5.Text = "Remover";
            this.metroButton5.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // editarmovimentacaometroButton4
            // 
            this.editarmovimentacaometroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editarmovimentacaometroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editarmovimentacaometroButton4.Appearance.Options.UseForeColor = true;
            this.editarmovimentacaometroButton4.Enabled = false;
            this.editarmovimentacaometroButton4.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.editarmovimentacaometroButton4.Location = new System.Drawing.Point(1099, 4);
            this.editarmovimentacaometroButton4.Name = "editarmovimentacaometroButton4";
            this.editarmovimentacaometroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editarmovimentacaometroButton4.Size = new System.Drawing.Size(88, 33);
            this.editarmovimentacaometroButton4.TabIndex = 125;
            this.editarmovimentacaometroButton4.Text = "Editar";
            this.editarmovimentacaometroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // imprimriMetroButton
            // 
            this.imprimriMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimriMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.imprimriMetroButton.Appearance.Options.UseForeColor = true;
            this.imprimriMetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Impirmir;
            this.imprimriMetroButton.Location = new System.Drawing.Point(911, 4);
            this.imprimriMetroButton.Name = "imprimriMetroButton";
            this.imprimriMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.imprimriMetroButton.Size = new System.Drawing.Size(88, 33);
            this.imprimriMetroButton.TabIndex = 124;
            this.imprimriMetroButton.Text = "Imprimir";
            this.imprimriMetroButton.Click += new System.EventHandler(this.imprimriMetroButton_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.simpleButton3.Location = new System.Drawing.Point(1005, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(88, 33);
            this.simpleButton3.TabIndex = 123;
            this.simpleButton3.Text = "Novo";
            this.simpleButton3.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.atualizarMetroButton.Appearance.Options.UseForeColor = true;
            this.atualizarMetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.AtualizarCarregar;
            this.atualizarMetroButton.Location = new System.Drawing.Point(817, 4);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.atualizarMetroButton.Size = new System.Drawing.Size(88, 33);
            this.atualizarMetroButton.TabIndex = 122;
            this.atualizarMetroButton.Text = "Atualizar";
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton8.Appearance.Options.UseForeColor = true;
            this.metroButton8.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton8.ImageOptions.SvgImage")));
            this.metroButton8.Location = new System.Drawing.Point(723, 4);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton8.Size = new System.Drawing.Size(88, 33);
            this.metroButton8.TabIndex = 127;
            this.metroButton8.Text = "Débito";
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // metroButton7
            // 
            this.metroButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton7.Appearance.Options.UseForeColor = true;
            this.metroButton7.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton7.ImageOptions.SvgImage")));
            this.metroButton7.Location = new System.Drawing.Point(629, 4);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton7.Size = new System.Drawing.Size(88, 33);
            this.metroButton7.TabIndex = 128;
            this.metroButton7.Text = "Crédito";
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton6.Appearance.Options.UseForeColor = true;
            this.metroButton6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton6.ImageOptions.SvgImage")));
            this.metroButton6.Location = new System.Drawing.Point(516, 4);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton6.Size = new System.Drawing.Size(107, 33);
            this.metroButton6.TabIndex = 129;
            this.metroButton6.Text = "Transferência";
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // FCOFIN_MovimentacaoBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroButton8);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.editarmovimentacaometroButton4);
            this.Controls.Add(this.imprimriMetroButton);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.atualizarMetroButton);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1316, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1002, 632);
            this.Name = "FCOFIN_MovimentacaoBancaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimentação Bancária";
            this.Load += new System.EventHandler(this.FCOFIN_MovimentacaoBancaria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton editarmovimentacaometroButton4;
        private DevExpress.XtraEditors.SimpleButton imprimriMetroButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton atualizarMetroButton;
        private DevExpress.XtraEditors.SimpleButton metroButton8;
        private DevExpress.XtraEditors.SimpleButton metroButton7;
        private DevExpress.XtraEditors.SimpleButton metroButton6;
    }
}