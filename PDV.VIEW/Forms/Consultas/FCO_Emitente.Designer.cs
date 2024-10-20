namespace PDV.VIEW.Forms.Consultas
{
    partial class FCO_Emitente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.ovTXT_InscricaoEstadual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_CPFCNPJ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ovTXT_RazaoSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.editarMetroButton = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.ovTXT_InscricaoEstadual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovTXT_CPFCNPJ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ovTXT_RazaoSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE PESQUISA";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroButton2.Location = new System.Drawing.Point(598, 55);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(150, 35);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton2.TabIndex = 23;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "PESQUISAR";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.ovBTN_Pesquisar_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroButton1.Location = new System.Drawing.Point(598, 14);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(150, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 22;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "LIMPAR";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.ovBTN_LimparFiltros_Click);
            // 
            // ovTXT_InscricaoEstadual
            // 
            this.ovTXT_InscricaoEstadual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_InscricaoEstadual.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_InscricaoEstadual.Location = new System.Drawing.Point(429, 55);
            this.ovTXT_InscricaoEstadual.Name = "ovTXT_InscricaoEstadual";
            this.ovTXT_InscricaoEstadual.Size = new System.Drawing.Size(163, 23);
            this.ovTXT_InscricaoEstadual.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Insc. Estadual:";
            // 
            // ovTXT_CPFCNPJ
            // 
            this.ovTXT_CPFCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_CPFCNPJ.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_CPFCNPJ.Location = new System.Drawing.Point(145, 55);
            this.ovTXT_CPFCNPJ.Name = "ovTXT_CPFCNPJ";
            this.ovTXT_CPFCNPJ.Size = new System.Drawing.Size(180, 23);
            this.ovTXT_CPFCNPJ.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF/CNPJ:";
            // 
            // ovTXT_RazaoSocial
            // 
            this.ovTXT_RazaoSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_RazaoSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ovTXT_RazaoSocial.Location = new System.Drawing.Point(145, 24);
            this.ovTXT_RazaoSocial.Name = "ovTXT_RazaoSocial";
            this.ovTXT_RazaoSocial.Size = new System.Drawing.Size(447, 23);
            this.ovTXT_RazaoSocial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome/Razão Social:";
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Location = new System.Drawing.Point(315, 542);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(150, 35);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 21;
            this.metroButton5.TabStop = false;
            this.metroButton5.Text = "NOVO";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.ovBTN_Novo_Click);
            // 
            // editarMetroButton
            // 
            this.editarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editarMetroButton.Enabled = false;
            this.editarMetroButton.Location = new System.Drawing.Point(471, 542);
            this.editarMetroButton.Name = "editarMetroButton";
            this.editarMetroButton.Size = new System.Drawing.Size(150, 35);
            this.editarMetroButton.Style = MetroFramework.MetroColorStyle.White;
            this.editarMetroButton.TabIndex = 20;
            this.editarMetroButton.TabStop = false;
            this.editarMetroButton.Text = "EDITAR";
            this.editarMetroButton.UseSelectable = true;
            this.editarMetroButton.Click += new System.EventHandler(this.ovBTN_Editar_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Location = new System.Drawing.Point(627, 542);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(150, 35);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton3.TabIndex = 19;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "REMOVER";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.ovBTN_Excluir_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(23, 110);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(754, 371);
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
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
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
            // FCO_Emitente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.editarMetroButton);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCO_Emitente";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Emitente";
            this.Load += new System.EventHandler(this.FCO_Cliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ovTXT_InscricaoEstadual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovTXT_CPFCNPJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ovTXT_RazaoSocial;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton editarMetroButton;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}