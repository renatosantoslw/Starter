namespace PDV.VIEW.Forms.Estoque.Inventario
{
    partial class FESTCO_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FESTCO_Inventario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ovTXT_EmissaoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_EmissaoInicio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.ovBTN_Processar = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoFim);
            this.groupBox1.Controls.Add(this.ovTXT_EmissaoInicio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.metroButton3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(21, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 63);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(258, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Até";
            // 
            // ovTXT_EmissaoFim
            // 
            this.ovTXT_EmissaoFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_EmissaoFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_EmissaoFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_EmissaoFim.Location = new System.Drawing.Point(291, 26);
            this.ovTXT_EmissaoFim.Name = "ovTXT_EmissaoFim";
            this.ovTXT_EmissaoFim.Size = new System.Drawing.Size(113, 21);
            this.ovTXT_EmissaoFim.TabIndex = 3;
            // 
            // ovTXT_EmissaoInicio
            // 
            this.ovTXT_EmissaoInicio.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_EmissaoInicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_EmissaoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_EmissaoInicio.Location = new System.Drawing.Point(114, 25);
            this.ovTXT_EmissaoInicio.Name = "ovTXT_EmissaoInicio";
            this.ovTXT_EmissaoInicio.Size = new System.Drawing.Size(117, 21);
            this.ovTXT_EmissaoInicio.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Data do Inventário:";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(560, 22);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(91, 33);
            this.metroButton2.TabIndex = 128;
            this.metroButton2.Text = "Pesquisar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(657, 22);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(91, 33);
            this.metroButton3.TabIndex = 127;
            this.metroButton3.Text = "Limpar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(21, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(754, 482);
            this.gridControl1.TabIndex = 43;
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
            this.gridView1.PaintStyleName = "Default";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.Enabled = false;
            this.metroButton1.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Deletar;
            this.metroButton1.Location = new System.Drawing.Point(701, 6);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(88, 33);
            this.metroButton1.TabIndex = 131;
            this.metroButton1.Text = "Remover";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.Enabled = false;
            this.metroButton4.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Editar;
            this.metroButton4.Location = new System.Drawing.Point(607, 6);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(88, 33);
            this.metroButton4.TabIndex = 130;
            this.metroButton4.Text = "Editar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton4.Appearance.Options.UseForeColor = true;
            this.simpleButton4.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.Adicionar;
            this.simpleButton4.Location = new System.Drawing.Point(513, 6);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton4.Size = new System.Drawing.Size(88, 33);
            this.simpleButton4.TabIndex = 129;
            this.simpleButton4.Text = "Novo";
            this.simpleButton4.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // ovBTN_Processar
            // 
            this.ovBTN_Processar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovBTN_Processar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ovBTN_Processar.Appearance.Options.UseForeColor = true;
            this.ovBTN_Processar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ovBTN_Processar.ImageOptions.SvgImage")));
            this.ovBTN_Processar.Location = new System.Drawing.Point(419, 6);
            this.ovBTN_Processar.Name = "ovBTN_Processar";
            this.ovBTN_Processar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ovBTN_Processar.Size = new System.Drawing.Size(88, 33);
            this.ovBTN_Processar.TabIndex = 132;
            this.ovBTN_Processar.Text = "Processar";
            this.ovBTN_Processar.Click += new System.EventHandler(this.ovBTN_Processar_Click);
            // 
            // FESTCO_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ovBTN_Processar);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 632);
            this.Name = "FESTCO_Inventario";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de Inventário";
            this.Load += new System.EventHandler(this.FESTCO_Inventario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoFim;
        private System.Windows.Forms.DateTimePicker ovTXT_EmissaoInicio;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton ovBTN_Processar;
    }
}