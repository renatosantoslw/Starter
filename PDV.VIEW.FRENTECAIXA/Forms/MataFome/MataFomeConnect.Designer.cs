namespace PDV.VIEW.FRENTECAIXA.Forms.MataFome
{
    partial class MataFomeConnect
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(849, 590);
            this.gridControl1.TabIndex = 23;
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
            this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.Row.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            // 
            // MataFomeConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 617);
            this.Controls.Add(this.gridControl1);
            this.Name = "MataFomeConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MataFome Conect";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}