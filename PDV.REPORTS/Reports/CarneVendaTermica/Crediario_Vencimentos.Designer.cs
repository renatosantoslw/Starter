namespace PDV.REPORTS.Reports.CarneVendaTermica
{
    partial class Crediario_Vencimentos
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
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ovDS_Dados = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLine2,
            this.xrLabel5,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel6});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 16F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 96F;
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.pagamento]")});
            this.xrLabel10.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(175.3077F, 2F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(57.00005F, 14F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel10.TextFormatString = "{0:dd/MM/yyyy}";
            // 
            // xrLine2
            // 
            this.xrLine2.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLine2.Dpi = 96F;
            this.xrLine2.ForeColor = System.Drawing.Color.LightGray;
            this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(3.212376E-05F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(294F, 2F);
            this.xrLine2.StylePriority.UseBorderColor = false;
            this.xrLine2.StylePriority.UseForeColor = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.vencimento]")});
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(118.3077F, 2F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(57.00005F, 14F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel5.TextFormatString = "{0:dd/MM/yyyy}";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.valor]")});
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(230.3078F, 2F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(63.69223F, 14F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel9.TextFormatString = "{0:n2}";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.formadepagamento]")});
            this.xrLabel7.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(42.99998F, 2F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(75.30771F, 14F);
            this.xrLabel7.StylePriority.UseFont = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 96F;
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.parcela]")});
            this.xrLabel6.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.000001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(43F, 14F);
            this.xrLabel6.StylePriority.UseFont = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 96F;
            this.xrLabel12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([DADOS.valor])")});
            this.xrLabel12.Font = new System.Drawing.Font("Consolas", 7.5F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(208.3078F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(85.6922F, 14F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel12.Summary = xrSummary1;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel12.WordWrap = false;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(137.3077F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(71.00003F, 14F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Total:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 96F;
            this.TopMargin.HeightF = 4F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 96F;
            this.BottomMargin.HeightF = 2F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.Dpi = 96F;
            this.ReportHeader.HeightF = 15F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 96F;
            this.xrLabel8.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(175.3078F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(57.00005F, 15F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "PGTO";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(118.3077F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(57.00005F, 15F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "VENCTO";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(231.3078F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(62.69223F, 15F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "VALOR";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(42.99998F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(75.30771F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "FORMA PAGTO";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "COD";
            // 
            // ovDS_Dados
            // 
            this.ovDS_Dados.DataSetName = "NewDataSet";
            this.ovDS_Dados.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7});
            this.dataTable1.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "parcela";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "formadepagamento";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "idformadepagamento";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "vencimento";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "valor";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "fluxo";
            this.dataColumn6.ColumnName = "fluxo";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "pagamento";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11});
            this.ReportFooter.Dpi = 96F;
            this.ReportFooter.HeightF = 17F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Crediario_Vencimentos
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(4, 4, 4, 2);
            this.PageHeight = 1056;
            this.PageWidth = 302;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.RollPaper = true;
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 12.5F;
            this.Version = "18.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReciboPedidoVenda_Itens_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
    }
}
