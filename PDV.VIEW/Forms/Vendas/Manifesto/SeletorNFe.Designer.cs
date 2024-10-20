namespace PDV.VIEW.Forms.Vendas.Manifesto
{
    partial class SeletorNFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeletorNFe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ovTXT_DataFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_Inicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlNFe = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNFe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.ovTXT_DataFim);
            this.groupBox1.Controls.Add(this.ovTXT_Inicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(23, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 58);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(651, 18);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(97, 33);
            this.metroButton2.TabIndex = 136;
            this.metroButton2.Text = "Pesquisar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // ovTXT_DataFim
            // 
            this.ovTXT_DataFim.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ovTXT_DataFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_DataFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_DataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_DataFim.Location = new System.Drawing.Point(306, 23);
            this.ovTXT_DataFim.Name = "ovTXT_DataFim";
            this.ovTXT_DataFim.Size = new System.Drawing.Size(113, 21);
            this.ovTXT_DataFim.TabIndex = 65;
            // 
            // ovTXT_Inicio
            // 
            this.ovTXT_Inicio.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_Inicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_Inicio.Location = new System.Drawing.Point(124, 23);
            this.ovTXT_Inicio.Name = "ovTXT_Inicio";
            this.ovTXT_Inicio.Size = new System.Drawing.Size(113, 21);
            this.ovTXT_Inicio.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(272, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Até";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label21.Location = new System.Drawing.Point(19, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 13);
            this.label21.TabIndex = 66;
            this.label21.Text = "* Data de Emissão:";
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton4.ImageOptions.Image")));
            this.metroButton4.Location = new System.Drawing.Point(691, 555);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(97, 33);
            this.metroButton4.TabIndex = 135;
            this.metroButton4.Text = "Salvar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton1.ImageOptions.Image")));
            this.metroButton1.Location = new System.Drawing.Point(588, 555);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(97, 33);
            this.metroButton1.TabIndex = 134;
            this.metroButton1.Text = "Cancelar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // gridControlNFe
            // 
            this.gridControlNFe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlNFe.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlNFe.Location = new System.Drawing.Point(23, 74);
            this.gridControlNFe.MainView = this.gridView1;
            this.gridControlNFe.Name = "gridControlNFe";
            this.gridControlNFe.Size = new System.Drawing.Size(754, 449);
            this.gridControlNFe.TabIndex = 144;
            this.gridControlNFe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlNFe.DoubleClick += new System.EventHandler(this.gridControlNFe_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.White;
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
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControlNFe;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SeletorNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.gridControlNFe);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "SeletorNFe";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seletor de NF-e";
            this.Load += new System.EventHandler(this.SeletorNFe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNFe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker ovTXT_DataFim;
        private System.Windows.Forms.DateTimePicker ovTXT_Inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraGrid.GridControl gridControlNFe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}