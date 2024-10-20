namespace PDV.VIEW.Forms.Gerenciamento
{
    partial class GER_EventosRegistrados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GER_EventosRegistrados));
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_DataFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_InicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.metroButton8 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(609, 11);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(91, 33);
            this.metroButton1.TabIndex = 129;
            this.metroButton1.Text = "Pesquisar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ovTXT_DataFim
            // 
            this.ovTXT_DataFim.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ovTXT_DataFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_DataFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_DataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_DataFim.Location = new System.Drawing.Point(316, 11);
            this.ovTXT_DataFim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_DataFim.Name = "ovTXT_DataFim";
            this.ovTXT_DataFim.Size = new System.Drawing.Size(131, 21);
            this.ovTXT_DataFim.TabIndex = 65;
            // 
            // ovTXT_InicioVigencia
            // 
            this.ovTXT_InicioVigencia.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_InicioVigencia.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_InicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_InicioVigencia.Location = new System.Drawing.Point(116, 12);
            this.ovTXT_InicioVigencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ovTXT_InicioVigencia.Name = "ovTXT_InicioVigencia";
            this.ovTXT_InicioVigencia.Size = new System.Drawing.Size(131, 21);
            this.ovTXT_InicioVigencia.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(282, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Até";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label21.Location = new System.Drawing.Point(11, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 13);
            this.label21.TabIndex = 66;
            this.label21.Text = "* Data de Emissão:";
            // 
            // metroButton8
            // 
            this.metroButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton8.Appearance.Options.UseForeColor = true;
            this.metroButton8.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Impirmir;
            this.metroButton8.Location = new System.Drawing.Point(803, 10);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton8.Size = new System.Drawing.Size(97, 33);
            this.metroButton8.TabIndex = 128;
            this.metroButton8.Text = "Imprimir";
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(702, 10);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(95, 33);
            this.metroButton2.TabIndex = 127;
            this.metroButton2.Text = "Cancelar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(4, 50);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(905, 608);
            this.gridControl2.TabIndex = 130;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView2.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            // 
            // GER_EventosRegistrados
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 662);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.ovTXT_DataFim);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.ovTXT_InicioVigencia);
            this.Controls.Add(this.metroButton8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GER_EventosRegistrados";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eventos Registrados";
            this.Load += new System.EventHandler(this.GER_EventosRegistrados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker ovTXT_DataFim;
        private System.Windows.Forms.DateTimePicker ovTXT_InicioVigencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton8;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}