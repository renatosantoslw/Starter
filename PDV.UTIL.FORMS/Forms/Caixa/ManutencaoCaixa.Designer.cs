
namespace PDV.UTIL.FORMS.Forms.Caixa
{
    partial class ManutencaoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManutencaoCaixa));
            this.grdSuprimento = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSangria = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnGravar = new DevExpress.XtraEditors.SimpleButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdFluxo = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdSuprimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxo)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSuprimento
            // 
            this.grdSuprimento.Location = new System.Drawing.Point(12, 132);
            this.grdSuprimento.MainView = this.gridView2;
            this.grdSuprimento.Name = "grdSuprimento";
            this.grdSuprimento.Size = new System.Drawing.Size(866, 129);
            this.grdSuprimento.TabIndex = 1;
            this.grdSuprimento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdSuprimento;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // grdSangria
            // 
            this.grdSangria.Location = new System.Drawing.Point(12, 286);
            this.grdSangria.MainView = this.gridView3;
            this.grdSangria.Name = "grdSangria";
            this.grdSangria.Size = new System.Drawing.Size(866, 129);
            this.grdSangria.TabIndex = 2;
            this.grdSangria.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdSangria;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // btnGravar
            // 
            this.btnGravar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGravar.ImageOptions.SvgImage")));
            this.btnGravar.Location = new System.Drawing.Point(717, 417);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(161, 39);
            this.btnGravar.TabIndex = 4;
            this.btnGravar.Text = "Salvar - F10";
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Abertura";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Suprimentos";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 267);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Sangrias";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdFluxo;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // grdFluxo
            // 
            this.grdFluxo.Location = new System.Drawing.Point(12, 25);
            this.grdFluxo.MainView = this.gridView1;
            this.grdFluxo.Name = "grdFluxo";
            this.grdFluxo.Size = new System.Drawing.Size(866, 82);
            this.grdFluxo.TabIndex = 0;
            this.grdFluxo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ManutencaoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 470);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.grdSangria);
            this.Controls.Add(this.grdSuprimento);
            this.Controls.Add(this.grdFluxo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManutencaoCaixa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção do Caixa ";
            ((System.ComponentModel.ISupportInitialize)(this.grdSuprimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdSuprimento;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grdSangria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SimpleButton btnGravar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grdFluxo;
    }
}