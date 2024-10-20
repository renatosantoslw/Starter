namespace PDV.REPORTS.Reports.ImpressaoComandas
{
    partial class ImpressaoComanda
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
            DevExpress.XtraPrinting.BarCode.CodabarGenerator codabarGenerator1 = new DevExpress.XtraPrinting.BarCode.CodabarGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ovDS_Dados = new System.Data.DataSet();
            this.DADOS = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ovSR_Cabecalho = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ovTXT_CodigoFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.ovTXT_CodigoInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrBarCode1});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 111.16F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.ColumnWidth = 250F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.descricao]")});
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80.08002F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(245F, 22.08F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode1.Dpi = 96F;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8F);
            this.xrBarCode1.Module = 2.25F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 96F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(245F, 72.08F);
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            codabarGenerator1.WideNarrowRatio = 2F;
            this.xrBarCode1.Symbology = codabarGenerator1;
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
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
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 96F;
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 96F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(560F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(174.0001F, 22.08F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.dataColumn3});
            this.DADOS.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idcomanda";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "codigo";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "descricao";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ovSR_Cabecalho});
            this.ReportHeader.Dpi = 96F;
            this.ReportHeader.HeightF = 22.08F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ovSR_Cabecalho
            // 
            this.ovSR_Cabecalho.Dpi = 96F;
            this.ovSR_Cabecalho.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ovSR_Cabecalho.Name = "ovSR_Cabecalho";
            this.ovSR_Cabecalho.SizeF = new System.Drawing.SizeF(734F, 22.08F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ovTXT_CodigoFinal,
            this.ovTXT_CodigoInicial,
            this.xrLine3,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLine2,
            this.xrLabel2,
            this.xrLine1});
            this.PageHeader.Dpi = 96F;
            this.PageHeader.HeightF = 90.24005F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ovTXT_CodigoFinal
            // 
            this.ovTXT_CodigoFinal.Dpi = 96F;
            this.ovTXT_CodigoFinal.Font = new System.Drawing.Font("Consolas", 9F);
            this.ovTXT_CodigoFinal.LocationFloat = new DevExpress.Utils.PointFloat(120F, 66.16003F);
            this.ovTXT_CodigoFinal.Name = "ovTXT_CodigoFinal";
            this.ovTXT_CodigoFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.ovTXT_CodigoFinal.SizeF = new System.Drawing.SizeF(155F, 22.08F);
            this.ovTXT_CodigoFinal.StylePriority.UseFont = false;
            this.ovTXT_CodigoFinal.StylePriority.UseTextAlignment = false;
            this.ovTXT_CodigoFinal.Text = "ovTXT_CodigoFinal";
            this.ovTXT_CodigoFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ovTXT_CodigoInicial
            // 
            this.ovTXT_CodigoInicial.Dpi = 96F;
            this.ovTXT_CodigoInicial.Font = new System.Drawing.Font("Consolas", 9F);
            this.ovTXT_CodigoInicial.LocationFloat = new DevExpress.Utils.PointFloat(120F, 44.08002F);
            this.ovTXT_CodigoInicial.Name = "ovTXT_CodigoInicial";
            this.ovTXT_CodigoInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.ovTXT_CodigoInicial.SizeF = new System.Drawing.SizeF(155F, 22.08F);
            this.ovTXT_CodigoInicial.StylePriority.UseFont = false;
            this.ovTXT_CodigoInicial.StylePriority.UseTextAlignment = false;
            this.ovTXT_CodigoInicial.Text = "ovTXT_CodigoInicial";
            this.ovTXT_CodigoInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine3.Dpi = 96F;
            this.xrLine3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 88.24005F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(734.0001F, 2F);
            this.xrLine3.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66.16003F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(120F, 22.08F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "CÓDIGO FINAL:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 44.08002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(120F, 22.08F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "CÓDIGO INICIAL:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine2.Dpi = 96F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 42.08002F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(734.0001F, 2F);
            this.xrLine2.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.000003F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(734.0001F, 40.08F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "RELATÓRIO DE IMPRESSÃO DE COMANDAS";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(734.0001F, 2F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            // 
            // ImpressaoComanda
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 10F);
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 45, 45);
            this.PageHeight = 1123;
            this.PageWidth = 794;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.SnapGridSize = 12.5F;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable DADOS;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRSubreport ovSR_Cabecalho;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel ovTXT_CodigoFinal;
        private DevExpress.XtraReports.UI.XRLabel ovTXT_CodigoInicial;
    }
}
