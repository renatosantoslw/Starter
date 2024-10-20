namespace PDV.VIEW.Forms.Cadastro.BaseProdutos
{
    partial class BuscarBaseProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarBaseProdutos));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pesquisarProdutoAPIText = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButtonSelecionar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisarProdutoAPIText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl1.Location = new System.Drawing.Point(1, 133);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(898, 444);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Para ver os dados agrupados arraste uma coluna para este local";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowHeight = 30;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(560, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(74, 27);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Buscar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pesquisarProdutoAPIText
            // 
            this.pesquisarProdutoAPIText.Location = new System.Drawing.Point(114, 12);
            this.pesquisarProdutoAPIText.Name = "pesquisarProdutoAPIText";
            this.pesquisarProdutoAPIText.Size = new System.Drawing.Size(409, 20);
            this.pesquisarProdutoAPIText.TabIndex = 2;
            this.pesquisarProdutoAPIText.EditValueChanged += new System.EventHandler(this.pesquisarProdutoAPIText_EditValueChanged);
            this.pesquisarProdutoAPIText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pesquisarProdutoAPIText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar produto";
            // 
            // simpleButtonSelecionar
            // 
            this.simpleButtonSelecionar.Enabled = false;
            this.simpleButtonSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSelecionar.ImageOptions.SvgImage")));
            this.simpleButtonSelecionar.Location = new System.Drawing.Point(640, 1);
            this.simpleButtonSelecionar.Name = "simpleButtonSelecionar";
            this.simpleButtonSelecionar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButtonSelecionar.Size = new System.Drawing.Size(93, 28);
            this.simpleButtonSelecionar.TabIndex = 4;
            this.simpleButtonSelecionar.Text = "Cadastrar";
            this.simpleButtonSelecionar.Click += new System.EventHandler(this.simpleButtonSelecionar_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(776, 547);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(123, 42);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Buscar JSON";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PDV.VIEW.Properties.Resources.load_chat;
            this.pictureBox1.Location = new System.Drawing.Point(387, 316);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(739, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 126);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // BuscarBaseProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 589);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButtonSelecionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesquisarProdutoAPIText);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarBaseProdutos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Produtos na Nuvem";
            this.Load += new System.EventHandler(this.BuscarBaseProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisarProdutoAPIText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit pesquisarProdutoAPIText;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSelecionar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
    }
}