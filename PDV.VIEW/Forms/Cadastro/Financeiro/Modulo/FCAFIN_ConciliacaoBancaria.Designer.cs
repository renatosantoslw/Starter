namespace PDV.VIEW.Forms.Cadastro.Financeiro.Modulo
{
    partial class FCAFIN_ConciliacaoBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCAFIN_ConciliacaoBancaria));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.ovTXT_VencimentoFim = new System.Windows.Forms.DateTimePicker();
            this.ovTXT_FormaPagamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ovTXT_Origem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ovTXT_VencimentoInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ovTXT_Cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.metroButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.metroButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.atualizarMetroButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.metroButton3);
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoFim);
            this.groupBox1.Controls.Add(this.ovTXT_FormaPagamento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ovTXT_Origem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ovTXT_VencimentoInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ovTXT_Cliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(25, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 98);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Pesquisa";
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton3.Appearance.Options.UseForeColor = true;
            this.metroButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton3.ImageOptions.Image")));
            this.metroButton3.Location = new System.Drawing.Point(860, 15);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton3.Size = new System.Drawing.Size(88, 33);
            this.metroButton3.TabIndex = 115;
            this.metroButton3.Text = "Limpar";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton2.Appearance.Options.UseForeColor = true;
            this.metroButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton2.ImageOptions.Image")));
            this.metroButton2.Location = new System.Drawing.Point(860, 54);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton2.Size = new System.Drawing.Size(88, 33);
            this.metroButton2.TabIndex = 114;
            this.metroButton2.Text = "Pesquisar";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(646, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "Até";
            // 
            // ovTXT_VencimentoFim
            // 
            this.ovTXT_VencimentoFim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoFim.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_VencimentoFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_VencimentoFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_VencimentoFim.Location = new System.Drawing.Point(679, 25);
            this.ovTXT_VencimentoFim.Name = "ovTXT_VencimentoFim";
            this.ovTXT_VencimentoFim.Size = new System.Drawing.Size(113, 21);
            this.ovTXT_VencimentoFim.TabIndex = 3;
            // 
            // ovTXT_FormaPagamento
            // 
            this.ovTXT_FormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_FormaPagamento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_FormaPagamento.Location = new System.Drawing.Point(422, 56);
            this.ovTXT_FormaPagamento.Name = "ovTXT_FormaPagamento";
            this.ovTXT_FormaPagamento.Size = new System.Drawing.Size(370, 21);
            this.ovTXT_FormaPagamento.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(303, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Forma de Pagamento:";
            // 
            // ovTXT_Origem
            // 
            this.ovTXT_Origem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Origem.Location = new System.Drawing.Point(67, 56);
            this.ovTXT_Origem.Name = "ovTXT_Origem";
            this.ovTXT_Origem.Size = new System.Drawing.Size(203, 21);
            this.ovTXT_Origem.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Origem:";
            // 
            // ovTXT_VencimentoInicio
            // 
            this.ovTXT_VencimentoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_VencimentoInicio.CustomFormat = "dd/MM/yyyy";
            this.ovTXT_VencimentoInicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_VencimentoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ovTXT_VencimentoInicio.Location = new System.Drawing.Point(523, 25);
            this.ovTXT_VencimentoInicio.Name = "ovTXT_VencimentoInicio";
            this.ovTXT_VencimentoInicio.Size = new System.Drawing.Size(117, 21);
            this.ovTXT_VencimentoInicio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(454, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Movimento:";
            // 
            // ovTXT_Cliente
            // 
            this.ovTXT_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovTXT_Cliente.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ovTXT_Cliente.Location = new System.Drawing.Point(67, 24);
            this.ovTXT_Cliente.Name = "ovTXT_Cliente";
            this.ovTXT_Cliente.Size = new System.Drawing.Size(361, 21);
            this.ovTXT_Cliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(25, 142);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(954, 526);
            this.gridControl1.TabIndex = 77;
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
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Appearance.Options.UseForeColor = true;
            this.metroButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton1.ImageOptions.SvgImage")));
            this.metroButton1.Location = new System.Drawing.Point(893, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton1.Size = new System.Drawing.Size(96, 33);
            this.metroButton1.TabIndex = 112;
            this.metroButton1.Text = "Conciliar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton4.Appearance.Options.UseForeColor = true;
            this.metroButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("metroButton4.ImageOptions.SvgImage")));
            this.metroButton4.Location = new System.Drawing.Point(791, 5);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton4.Size = new System.Drawing.Size(96, 33);
            this.metroButton4.TabIndex = 111;
            this.metroButton4.Text = "Desconciliar";
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.metroButton5.Appearance.Options.UseForeColor = true;
            this.metroButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("metroButton5.ImageOptions.Image")));
            this.metroButton5.Location = new System.Drawing.Point(704, 5);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.metroButton5.Size = new System.Drawing.Size(81, 33);
            this.metroButton5.TabIndex = 110;
            this.metroButton5.Text = "Fechar";
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // atualizarMetroButton
            // 
            this.atualizarMetroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atualizarMetroButton.Appearance.ForeColor = System.Drawing.Color.Black;
            this.atualizarMetroButton.Appearance.Options.UseForeColor = true;
            this.atualizarMetroButton.ImageOptions.Image = global::PDV.VIEW.Properties.Resources.AtualizarCarregar;
            this.atualizarMetroButton.Location = new System.Drawing.Point(609, 5);
            this.atualizarMetroButton.Name = "atualizarMetroButton";
            this.atualizarMetroButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.atualizarMetroButton.Size = new System.Drawing.Size(89, 33);
            this.atualizarMetroButton.TabIndex = 113;
            this.atualizarMetroButton.Text = "Atualizar";
            this.atualizarMetroButton.Click += new System.EventHandler(this.atualizarMetroButton_Click);
            // 
            // FCAFIN_ConciliacaoBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.atualizarMetroButton);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "FCAFIN_ConciliacaoBancaria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conciliação Bancária";
            this.Load += new System.EventHandler(this.FCAFIN_ConciliacaoBancaria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCAFIN_ConciliacaoBancaria_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoFim;
        private System.Windows.Forms.TextBox ovTXT_FormaPagamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ovTXT_Origem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ovTXT_VencimentoInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ovTXT_Cliente;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton metroButton3;
        private DevExpress.XtraEditors.SimpleButton metroButton2;
        private DevExpress.XtraEditors.SimpleButton metroButton1;
        private DevExpress.XtraEditors.SimpleButton metroButton4;
        private DevExpress.XtraEditors.SimpleButton metroButton5;
        private DevExpress.XtraEditors.SimpleButton atualizarMetroButton;
    }
}