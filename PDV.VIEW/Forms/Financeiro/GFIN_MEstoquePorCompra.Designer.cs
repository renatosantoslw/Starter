namespace PDV.VIEW.Forms.Cadastro
{
    partial class GFIN_MEstoquePorCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GFIN_MEstoquePorCompra));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonPesquisar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxPesquisaProduto = new System.Windows.Forms.TextBox();
            this.labelProduto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataAte = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dataDe = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAte.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDe.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1176, 586);
            this.gridControl1.TabIndex = 6;
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
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Arraste uma coluna aqui para agrupar";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowHeight = 30;
            this.gridView1.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.gridView1_PrintInitialize);
            // 
            // simpleButtonPesquisar
            // 
            this.simpleButtonPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonPesquisar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonPesquisar.ImageOptions.SvgImage")));
            this.simpleButtonPesquisar.Location = new System.Drawing.Point(974, 4);
            this.simpleButtonPesquisar.Name = "simpleButtonPesquisar";
            this.simpleButtonPesquisar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButtonPesquisar.Size = new System.Drawing.Size(93, 35);
            this.simpleButtonPesquisar.TabIndex = 8;
            this.simpleButtonPesquisar.Text = "Pesquisar";
            this.simpleButtonPesquisar.Click += new System.EventHandler(this.simpleButtonPesquisar_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(1077, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(93, 35);
            this.simpleButton2.TabIndex = 104;
            this.simpleButton2.Text = "Imprimir";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // textBoxPesquisaProduto
            // 
            this.textBoxPesquisaProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisaProduto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisaProduto.Location = new System.Drawing.Point(747, 12);
            this.textBoxPesquisaProduto.Name = "textBoxPesquisaProduto";
            this.textBoxPesquisaProduto.Size = new System.Drawing.Size(221, 21);
            this.textBoxPesquisaProduto.TabIndex = 105;
            // 
            // labelProduto
            // 
            this.labelProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProduto.AutoSize = true;
            this.labelProduto.Location = new System.Drawing.Point(692, 15);
            this.labelProduto.Name = "labelProduto";
            this.labelProduto.Size = new System.Drawing.Size(47, 13);
            this.labelProduto.TabIndex = 106;
            this.labelProduto.Text = "Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "e";
            // 
            // dataAte
            // 
            this.dataAte.EditValue = null;
            this.dataAte.Location = new System.Drawing.Point(177, 12);
            this.dataAte.Name = "dataAte";
            this.dataAte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataAte.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataAte.Size = new System.Drawing.Size(100, 20);
            this.dataAte.TabIndex = 121;
            this.dataAte.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Entre";
            // 
            // dataDe
            // 
            this.dataDe.EditValue = null;
            this.dataDe.Location = new System.Drawing.Point(52, 12);
            this.dataDe.Name = "dataDe";
            this.dataDe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataDe.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataDe.Size = new System.Drawing.Size(100, 20);
            this.dataDe.TabIndex = 119;
            this.dataDe.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // GFIN_MEstoquePorCompra
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataAte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataDe);
            this.Controls.Add(this.labelProduto);
            this.Controls.Add(this.textBoxPesquisaProduto);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButtonPesquisar);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GFIN_MEstoquePorCompra";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimento de Estoque Por Compra";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Transportadora_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAte.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDe.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPesquisar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox textBoxPesquisaProduto;
        private System.Windows.Forms.Label labelProduto;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dataAte;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dataDe;
    }
}