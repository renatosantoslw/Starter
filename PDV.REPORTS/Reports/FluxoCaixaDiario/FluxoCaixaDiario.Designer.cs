namespace PDV.REPORTS.Reports.FluxoCaixaDiario
{
    partial class FluxoCaixaDiario
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
            this.ovSR_FormasPagamento = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ovSR_Cabecalho = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.ovSR_TotalizadorFormaPagamento = new DevExpress.XtraReports.UI.XRSubreport();
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
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ovSR_FormasPagamento,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11});
            this.Detail.Dpi = 96F;
            this.Detail.HeightF = 36.47999F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 96F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ovSR_FormasPagamento
            // 
            this.ovSR_FormasPagamento.Dpi = 96F;
            this.ovSR_FormasPagamento.LocationFloat = new DevExpress.Utils.PointFloat(0F, 14.39999F);
            this.ovSR_FormasPagamento.Name = "ovSR_FormasPagamento";
            this.ovSR_FormasPagamento.ReportSource = new PDV.REPORTS.Reports.FluxoCaixaDiario.FluxoCaixaDiario_Pagamentos();
            this.ovSR_FormasPagamento.SizeF = new System.Drawing.SizeF(733.9999F, 22.08F);
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.valortotal", "{0:n2}")});
            this.xrLabel17.Dpi = 96F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(643.3202F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(90.67975F, 14.4F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.quantidadeitens", "{0:n2}")});
            this.xrLabel16.Dpi = 96F;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(598.0001F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(45.32007F, 14.4F);
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.valordesconto", "{0:n2}")});
            this.xrLabel15.Dpi = 96F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(520F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(78.00012F, 14.4F);
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.comanda")});
            this.xrLabel14.Dpi = 96F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(110F, 14.4F);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.nomecliente")});
            this.xrLabel13.Dpi = 96F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(245F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(165F, 14.4F);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.usuario")});
            this.xrLabel12.Dpi = 96F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(80.00002F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(165F, 14.4F);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DADOS.datacadastro", "{0:dd/MM/yyyy}")});
            this.xrLabel11.Dpi = 96F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(80.00001F, 14.4F);
            this.xrLabel11.Text = "xrLabel11";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(560.3199F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(173.6801F, 22.08F);
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
            this.xrLabel9,
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
            this.PageHeader.HeightF = 92.24002F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 96F;
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(643.3202F, 70.16001F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(90.67975F, 22.08001F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "TOTAL (R$)";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 96F;
            this.xrLabel8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(598.3201F, 70.16F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(45.00006F, 22.08F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "ITENS";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 96F;
            this.xrLabel7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(520.3201F, 70.16F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(78.00006F, 22.08F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "DESCONTO";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 96F;
            this.xrLabel6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(410.32F, 70.16F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(110F, 22.08F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "COMANDA";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 96F;
            this.xrLabel5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(245.32F, 70.16F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(165F, 22.08F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "CLIENTE";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 96F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(80.32F, 70.16F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(165F, 22.08F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "USUÁRIO";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 96F;
            this.xrLabel1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.3199997F, 70.16F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(80F, 22.08F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CADASTRO";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine1.Dpi = 96F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(733.9999F, 2.142862F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 96F;
            this.xrLabel2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.142862F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(734F, 39.93715F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "RELATÓRIO DE FLUXO DE CAIXA DIÁRIO";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLine2.Dpi = 96F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 42.08001F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(734F, 2F);
            this.xrLine2.StylePriority.UseBorderDashStyle = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 96F;
            this.xrLabel3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 44.08002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(67F, 22.08F);
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
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66.16F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(733.9999F, 2.14286F);
            this.xrLine3.StylePriority.UseBorderDashStyle = false;
            // 
            // ovTXT_Usuario
            // 
            this.ovTXT_Usuario.Dpi = 96F;
            this.ovTXT_Usuario.Font = new System.Drawing.Font("Consolas", 9F);
            this.ovTXT_Usuario.LocationFloat = new DevExpress.Utils.PointFloat(66.99996F, 44.22285F);
            this.ovTXT_Usuario.Name = "ovTXT_Usuario";
            this.ovTXT_Usuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.ovTXT_Usuario.SizeF = new System.Drawing.SizeF(667.0001F, 21.93713F);
            this.ovTXT_Usuario.StylePriority.UseFont = false;
            this.ovTXT_Usuario.StylePriority.UseTextAlignment = false;
            this.ovTXT_Usuario.Text = "ovTXT_Usuario";
            this.ovTXT_Usuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.ovSR_TotalizadorFormaPagamento});
            this.ReportFooter.Dpi = 96F;
            this.ReportFooter.HeightF = 44.16003F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 96F;
            this.xrLabel10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.3199997F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(324.68F, 22.08F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "TOTALIZADOR POR FORMA DE PAGAMENTO";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ovSR_TotalizadorFormaPagamento
            // 
            this.ovSR_TotalizadorFormaPagamento.Dpi = 96F;
            this.ovSR_TotalizadorFormaPagamento.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.08001F);
            this.ovSR_TotalizadorFormaPagamento.Name = "ovSR_TotalizadorFormaPagamento";
            this.ovSR_TotalizadorFormaPagamento.SizeF = new System.Drawing.SizeF(733.9999F, 22.08F);
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
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.DADOS.TableName = "DADOS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idvenda";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "quantidadeitens";
            this.dataColumn2.DataType = typeof(decimal);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "valortotal";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "datacadastro";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idcomanda";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "comanda";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "idcliente";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "nomecliente";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "idusuario";
            this.dataColumn9.DataType = typeof(decimal);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "usuario";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "valordesconto";
            this.dataColumn11.DataType = typeof(decimal);
            // 
            // FluxoCaixaDiario
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.DataMember = "DADOS";
            this.DataSource = this.ovDS_Dados;
            this.Dpi = 96F;
            this.Font = new System.Drawing.Font("Consolas", 8F);
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 45, 45);
            this.PageHeight = 1123;
            this.PageWidth = 794;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Pixels;
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.ovDS_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DADOS)).EndInit();
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRSubreport ovSR_TotalizadorFormaPagamento;
        private System.Data.DataSet ovDS_Dados;
        private System.Data.DataTable DADOS;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRSubreport ovSR_FormasPagamento;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
