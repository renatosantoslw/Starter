namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    partial class FechamentoCaixaDiario_SangriasTermica
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ovDS_Dados = new System.Data.DataSet();
            this.DADOS = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel7});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.valor")});
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(217F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(83F, 16F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel9.TextFormatString = "{0:c2}";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.observacao")});
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(217F, 16F);
            this.xrLabel7.StylePriority.UseFont = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(298F, 2F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 96F;
            this.TopMargin.HeightF = 45F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 96F;
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel1});
            this.PageHeader.Dpi = 96F;
            this.PageHeader.HeightF = 16F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(217F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(83F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "VALOR";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(217F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "DESCRIÇÃO";
            // 
            // ovDS_Dados
            // 
            this.ovDS_Dados.DataSetName = "NewDataSet";
            this.ovDS_Dados.Tables.AddRange(new System.Data.DataTable[] {
            this.DADOS});
            // 
            // DADOS
            // 
            this.DADOS.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.DADOS.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idusuario";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idfluxocaixa";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "valor";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "observacao";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel11,
            this.xrLabel5});
            this.ReportFooter.Dpi = 96F;
            this.ReportFooter.HeightF = 21F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.valor")});
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(162F, 2F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(138F, 16F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel11.Summary = xrSummary1;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel11.TextFormatString = "{0:c2}";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(126F, 16F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "TOTAL DE SANGRIAS:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // FechamentoCaixaDiario_SangriasTermica
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(2, 0, 45, 45);
            this.PageHeight = 1123;
            this.PageWidth = 302;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.SnapGridSize = 12.5F;
            this.Version = "19.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.FechamentoCaixaDiario_PagamentosTermica_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private System.Data.DataSet ovDS_Dados;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private System.Data.DataTable DADOS;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
    }
}
