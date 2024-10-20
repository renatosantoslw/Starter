namespace PDV.REPORTS.Reports.ComandasEmAberto
{
    partial class ComandasEmAbertoUsuario
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
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ovSR_Cabecalho = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.ovTXT_Usuario = new DevExpress.XtraReports.UI.XRLabel();
            this.ovDS_Dados = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 16F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 96F;
            this.xrLabel14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.datacadastro]")});
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(154F, 16F);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 96F;
            this.xrLabel13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.valortotal]")});
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(617.9999F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(116F, 16F);
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel13.TextFormatString = "{0:n2}";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 96F;
            this.xrLabel12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.quantidadeitens]")});
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(564F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(54F, 16F);
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel12.TextFormatString = "{0:n2}";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.usuario]")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(270F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(159F, 16F);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 96F;
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.comanda]")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(154F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(116F, 16F);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DADOS.cliente]")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(429F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(135F, 16F);
            this.xrLabel9.Text = "xrLabel9";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(559.9999F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(174F, 22.08F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLine1,
            this.xrLabel2,
            this.xrLine2,
            this.xrLabel3,
            this.xrLine3,
            this.ovTXT_Usuario});
            this.PageHeader.Dpi = 96F;
            this.PageHeader.HeightF = 96.11998F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 96F;
            this.xrLabel8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(617.9999F, 74.03998F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(116F, 22.08F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "VALOR TOTAL (R$)";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(564F, 74.03998F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(54F, 22.08F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "ITENS";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 96F;
            this.xrLabel6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(429F, 74.03998F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(135F, 22.08F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "CPF CLIENTE";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(270F, 74.03998F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(159F, 22.08F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "USUÁRIO";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(154F, 74.03998F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(116F, 22.08F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "COMANDA";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 74.03998F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(154F, 22.08F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "DATA CADASTRO";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(734F, 2F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.999997F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(734F, 40.08F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "RELATÓRIO DE COMANDAS EM ABERTO POR USUÁRIO";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine2.Dpi = 96F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 42.08002F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(734F, 2F);
            this.xrLine2.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.95999F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(62F, 22.08F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "USUÁRIO:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine3.Dpi = 96F;
            this.xrLine3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 69.03998F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(734F, 2F);
            this.xrLine3.StylePriority.UseBorderDashStyle = false;
            // 
            // ovTXT_Usuario
            // 
            this.ovTXT_Usuario.Dpi = 96F;
            this.ovTXT_Usuario.Font = new System.Drawing.Font("Consolas", 9F);
            this.ovTXT_Usuario.LocationFloat = new DevExpress.Utils.PointFloat(62F, 45.96F);
            this.ovTXT_Usuario.Name = "ovTXT_Usuario";
            this.ovTXT_Usuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.ovTXT_Usuario.SizeF = new System.Drawing.SizeF(672F, 22.08001F);
            this.ovTXT_Usuario.StylePriority.UseFont = false;
            this.ovTXT_Usuario.StylePriority.UseTextAlignment = false;
            this.ovTXT_Usuario.Text = "ovTXT_Usuario";
            this.ovTXT_Usuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.dataColumn1.ColumnName = "quantidadeitens";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "valortotal";
            this.dataColumn2.DataType = typeof(decimal);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "datacadastro";
            this.dataColumn3.DataType = typeof(System.DateTime);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "cliente";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "comanda";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "idusuario";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "usuario";
            // 
            // ComandasEmAbertoUsuario
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 45, 45);
            this.PageHeight = 1123;
            this.PageWidth = 794;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.SnapGridSize = 12.5F;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRSubreport ovSR_Cabecalho;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel ovTXT_Usuario;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
    }
}
