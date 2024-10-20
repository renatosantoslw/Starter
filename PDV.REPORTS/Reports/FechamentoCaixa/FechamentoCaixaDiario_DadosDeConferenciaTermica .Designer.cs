namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    partial class FechamentoCaixaDiario_DadosDeConferenciaTermica
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
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalDiferenca = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalDigitado = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalCalculado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.ovDS_Dados = new System.Data.DataSet();
            this.DADOS = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataSet2 = new System.Data.DataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel2,
            this.xrLabel3});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 17F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 96F;
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[diferenca]")});
            this.xrLabel6.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(239F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(59F, 16F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel6.TextFormatString = "{0:c2}";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[valorcalculado]")});
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(113F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(63F, 16F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel5.TextFormatString = "{0:c2}";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[valordigitado]")});
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(176F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(63F, 16F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel2.TextFormatString = "{0:c2}";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS].[nomeformapagamento]")});
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 8F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(113F, 16F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 96F;
            this.TopMargin.HeightF = 17F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 96F;
            this.BottomMargin.HeightF = 14F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7});
            this.PageHeader.Dpi = 96F;
            this.PageHeader.HeightF = 16.5F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 96F;
            this.xrLabel10.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(240F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(58F, 16F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "DIFERENÇA";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(177F, 0.5F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(63F, 16F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "DIGITADO";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 96F;
            this.xrLabel8.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(114F, 0.5F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(63F, 16F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "CALCULADO";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(1F, 0.5F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(113F, 16F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "PAGAMENTOS";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(294F, 2F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1F, 34F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "DIFERENÇA";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblTotalDiferenca
            // 
            this.lblTotalDiferenca.Dpi = 96F;
            this.lblTotalDiferenca.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalDiferenca.LocationFloat = new DevExpress.Utils.PointFloat(163F, 34F);
            this.lblTotalDiferenca.Name = "lblTotalDiferenca";
            this.lblTotalDiferenca.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalDiferenca.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.lblTotalDiferenca.StylePriority.UseFont = false;
            this.lblTotalDiferenca.StylePriority.UseTextAlignment = false;
            this.lblTotalDiferenca.Text = "CONFERÊNCIA R$";
            this.lblTotalDiferenca.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalDiferenca.TextFormatString = "{0:c2}";
            // 
            // lblTotalDigitado
            // 
            this.lblTotalDigitado.Dpi = 96F;
            this.lblTotalDigitado.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalDigitado.LocationFloat = new DevExpress.Utils.PointFloat(163F, 18F);
            this.lblTotalDigitado.Name = "lblTotalDigitado";
            this.lblTotalDigitado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalDigitado.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.lblTotalDigitado.StylePriority.UseFont = false;
            this.lblTotalDigitado.StylePriority.UseTextAlignment = false;
            this.lblTotalDigitado.Text = "CONFERÊNCIA R$";
            this.lblTotalDigitado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalDigitado.TextFormatString = "{0:c2}";
            // 
            // lblTotalCalculado
            // 
            this.lblTotalCalculado.Dpi = 96F;
            this.lblTotalCalculado.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalCalculado.LocationFloat = new DevExpress.Utils.PointFloat(163F, 2F);
            this.lblTotalCalculado.Name = "lblTotalCalculado";
            this.lblTotalCalculado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalCalculado.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.lblTotalCalculado.StylePriority.UseFont = false;
            this.lblTotalCalculado.StylePriority.UseTextAlignment = false;
            this.lblTotalCalculado.Text = "CONFERÊNCIA R$";
            this.lblTotalCalculado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalCalculado.TextFormatString = "{0:c2}";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1F, 2F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "TOTAL CALCULADO";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1F, 18F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(131F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "TOTAL DIGITADO";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.DADOS.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idfluxocaixa";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idusuario";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "valorcaixa";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "dataaberturacaixa";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "datafechamentocaixa";
            this.dataColumn5.DataType = typeof(System.DateTime);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "aberto";
            this.dataColumn6.DataType = typeof(double);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "valorfechamentocaixa";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "observacao";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "NewDataSet";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel1,
            this.lblTotalDiferenca,
            this.lblTotalDigitado,
            this.lblTotalCalculado,
            this.xrLabel11,
            this.xrLabel4});
            this.PageFooter.Dpi = 96F;
            this.PageFooter.HeightF = 57F;
            this.PageFooter.Name = "PageFooter";
            // 
            // FechamentoCaixaDiario_DadosDeConferenciaTermica
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSet1,
            this.dataSet2,
            this.bindingSource1});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(1, 2, 17, 14);
            this.PageHeight = 1123;
            this.PageWidth = 301;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.SnapGridSize = 12.5F;
            this.Version = "19.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.FechamentoCaixaDiario_PagamentosTermica_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable DADOS;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel lblTotalCalculado;
        private DevExpress.XtraReports.UI.XRLabel lblTotalDigitado;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblTotalDiferenca;
        private System.Data.DataSet dataSet1;
        private System.Data.DataSet dataSet2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    }
}
