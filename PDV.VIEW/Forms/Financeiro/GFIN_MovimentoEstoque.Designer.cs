namespace PDV.VIEW.Forms.Cadastro
{
    partial class GFIN_MovimentoEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GFIN_MovimentoEstoque));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonPesquisar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.labelProduto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
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
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowHeight = 30;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            // textBoxProduto
            // 
            this.textBoxProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProduto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProduto.Location = new System.Drawing.Point(747, 12);
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.Size = new System.Drawing.Size(221, 21);
            this.textBoxProduto.TabIndex = 105;
            // 
            // labelProduto
            // 
            this.labelProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProduto.AutoSize = true;
            this.labelProduto.Location = new System.Drawing.Point(692, 15);
            this.labelProduto.Name = "labelProduto";
            this.labelProduto.Size = new System.Drawing.Size(49, 13);
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
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(177, 12);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 121;
            this.dateEdit2.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Entre";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(52, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 119;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // GFIN_MovimentoEstoque
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelProduto);
            this.Controls.Add(this.textBoxProduto);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButtonPesquisar);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GFIN_MovimentoEstoque";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimento de Estoque";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCA_Transportadora_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPesquisar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Label labelProduto;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
    }
}