namespace PDV.REPORTS.Reports.PedidoVendaTermica
{
    partial class ReciboPedidoVenda_Itens
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel10,
            this.xrLine1,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 17F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 96F;
            this.xrLabel12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[valortotal]")});
            this.xrLabel12.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(248F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(33F, 14F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel9";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel12.TextFormatString = "{0:n2}";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 96F;
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[descontovalor]")});
            this.xrLabel10.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(223F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(25F, 14F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel9";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel10.TextFormatString = "{0:n2}";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.ForeColor = System.Drawing.Color.DarkGray;
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 14F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(294F, 2F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            this.xrLine1.Visible = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.valorunitarioitem]")});
            this.xrLabel9.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(161.71F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(33F, 14F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel9.TextFormatString = "{0:n2}";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 96F;
            this.xrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.QTD]")});
            this.xrLabel8.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(194.71F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(28.29F, 14F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel8.TextFormatString = "{0:n3}";
            this.xrLabel8.WordWrap = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[PRODUTO]")});
            this.xrLabel7.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(43.00003F, 0F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(118.71F, 14F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 96F;
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.codigo]")});
            this.xrLabel6.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(33.00003F, 14F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.Dpi = 96F;
            this.ReportHeader.HeightF = 15F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(26F, 15F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "TOTAL";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(222F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(26F, 15F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "DESC.";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(164.71F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(26F, 15F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "UNIT.";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(194.71F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(22.29F, 15F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "QTD";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(43.00003F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(92.7058F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "DESCRIÇÃO";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(33.00003F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "COD";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
            this.dataTable1.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "IDITEMVENDA";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "CODIGO";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "IDPRODUTO";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "PRODUTO";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "QUANTIDADE";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "VALORUNITARIOITEM";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "VALORTOTAL";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "QTD";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "DESCONTOVALOR";
            this.dataColumn9.DataType = typeof(decimal);
            // 
            // ReciboPedidoVenda_Itens
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(3, 3, 4, 0);
            this.PageHeight = 1056;
            this.PageWidth = 302;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.RollPaper = true;
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 12.5F;
            this.Version = "19.1";
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private System.Data.DataColumn dataColumn9;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
    }
}
