namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    partial class FechamentoCaixaDiario_TotaisVendasTermica
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
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalDMes = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalDia = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalAno = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
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
            this.xrLabel1,
            this.xrLabel4,
            this.lblTotalDMes,
            this.lblTotalDia,
            this.xrLabel11,
            this.lblTotalAno});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 50F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1F, 34F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(104F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "TOTAL ANO";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1F, 18F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(104F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "TOTAL MÊS";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblTotalDMes
            // 
            this.lblTotalDMes.Dpi = 96F;
            this.lblTotalDMes.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalDMes.LocationFloat = new DevExpress.Utils.PointFloat(105F, 18F);
            this.lblTotalDMes.Name = "lblTotalDMes";
            this.lblTotalDMes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalDMes.SizeF = new System.Drawing.SizeF(189F, 16F);
            this.lblTotalDMes.StylePriority.UseFont = false;
            this.lblTotalDMes.StylePriority.UseTextAlignment = false;
            this.lblTotalDMes.Text = "TOTAL MÊS R$";
            this.lblTotalDMes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalDMes.TextFormatString = "{0:c2}";
            // 
            // lblTotalDia
            // 
            this.lblTotalDia.Dpi = 96F;
            this.lblTotalDia.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalDia.LocationFloat = new DevExpress.Utils.PointFloat(105F, 2F);
            this.lblTotalDia.Name = "lblTotalDia";
            this.lblTotalDia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalDia.SizeF = new System.Drawing.SizeF(189F, 16F);
            this.lblTotalDia.StylePriority.UseFont = false;
            this.lblTotalDia.StylePriority.UseTextAlignment = false;
            this.lblTotalDia.Text = "TOTAL DIA R$";
            this.lblTotalDia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalDia.TextFormatString = "{0:c2}";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1F, 2F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(104F, 16F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "TOTAL DIA";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblTotalAno
            // 
            this.lblTotalAno.Dpi = 96F;
            this.lblTotalAno.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblTotalAno.LocationFloat = new DevExpress.Utils.PointFloat(105F, 34F);
            this.lblTotalAno.Name = "lblTotalAno";
            this.lblTotalAno.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblTotalAno.SizeF = new System.Drawing.SizeF(189F, 16F);
            this.lblTotalAno.StylePriority.UseFont = false;
            this.lblTotalAno.StylePriority.UseTextAlignment = false;
            this.lblTotalAno.Text = "TOTAL ANO R$";
            this.lblTotalAno.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblTotalAno.TextFormatString = "{0:c2}";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 96F;
            this.TopMargin.HeightF = 13F;
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
            // FechamentoCaixaDiario_TotaisVendasTermica
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSet1,
            this.dataSet2,
            this.bindingSource1});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(1, 2, 13, 14);
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
        private DevExpress.XtraReports.UI.XRLabel lblTotalDia;
        private DevExpress.XtraReports.UI.XRLabel lblTotalDMes;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblTotalAno;
        private System.Data.DataSet dataSet1;
        private System.Data.DataSet dataSet2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
