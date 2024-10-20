using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using PDV.DAO.Enum;
using PDV.DAO.DB.Utils;
using PDV.VIEW.App_Context;
using MetroFramework.Forms;
using MetroFramework;
using System.Net;
using PDV.DAO.Entidades.Cep;
using System.Web.Script.Serialization;
using PDV.UTIL;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraCharts;
using System.Data;
using DevExpress.XtraPrinting;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class GER_FluxoFinanceiro : DevExpress.XtraEditors.XtraForm
    {
        private string tabSelecionado = "1";
        public GER_FluxoFinanceiro()
        {
            InitializeComponent();

            int mesindex = DateTime.Now.Month - 1;

            anoTextEdit.Text = DateTime.Now.Year.ToString();

            
            CarregarCaixa(DateTime.Now.Month.ToString(), anoTextEdit.Text);
            chartRecebimentos();
            charPagamentos();
            metroTabControl1.SelectedIndex = mesindex;
        }

        public void CarregarCaixa(string ANO, string MES)
        {
            
            //CarregarGrafico();
            gridControl1.DataSource = GetFluxoCaixa();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            gridControl1.ForceInitialize();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.Columns[0].Caption = "ID";
            gridView1.Columns[1].Caption = "DATA DE EMISSÃO";
            gridView1.Columns[2].Caption = "VENCIMENTO";
            gridView1.Columns[3].Caption = "PESSOA";
            gridView1.Columns[4].Caption = "ORIGEM";
            gridView1.Columns[5].Caption = "DESCRIÇÂO";
            gridView1.Columns[6].Caption = "SALDO";
            gridView1.Columns[7].Caption = "PAGO";
            gridView1.Columns[8].Caption = "STATUS";
            gridView1.Columns[9].Caption = "TIPO";
            gridView1.Columns[6].DisplayFormat.FormatType =   DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[6].DisplayFormat.FormatString = "n2";
            gridView1.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[7].DisplayFormat.FormatString = "n2";
            //gridView1.Columns[9].Caption = "SITUAÇÃO";

            //gridView1.Columns[8].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

            //gridView1.Columns[8].SummaryItem.DisplayFormat = "Total R$ : {0:n2}";
            //gridView1.Columns[2].SummaryItem.DisplayFormat = "Registros : {0}";


        }

        private void FCA_Transportadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabSelecionado = Convert.ToString(metroTabControl1.SelectedIndex +1);
            CarregarCaixa(anoTextEdit.Text, tabSelecionado.ToString());
            CarregarGrafico();
            CarregarTotais();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tabSelecionado = (metroTabControl1.SelectedIndex + 1).ToString();
            CarregarCaixa(anoTextEdit.Text, tabSelecionado.ToString());
            CarregarGrafico();
            CarregarTotais();
            chartRecebimentos();
            charPagamentos();
        }
        public void chartRecebimentos()
        {
            //ChartControl

            recebimentosChartControl.Controls.Clear();
            recebimentosChartControl.Series.Clear();
            recebimentosChartControl.Titles.Clear();


            recebimentosChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            recebimentosChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            recebimentosChartControl.AutoLayout = true;
            recebimentosChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Recebimentos";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            recebimentosChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Legenda", ViewType.Doughnut);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A} :{V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";
            //Obtem dados do banco de dados
            series.DataSource = FuncoesDuplicataNFe.GetDuplicatasTudo();
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            recebimentosChartControl.Series.Add(series);
        }
        public void charPagamentos()
        {
            //ChartControl
            pagamentosChartControl.Controls.Clear();
            pagamentosChartControl.Series.Clear();
            pagamentosChartControl.Titles.Clear();
            pagamentosChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            pagamentosChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pagamentosChartControl.AutoLayout = true;
            pagamentosChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Recebimentos";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            pagamentosChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Legenda", ViewType.Doughnut);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A} :{V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";
            //Obtem dados do banco de dados
            series.DataSource = FuncoesDuplicataNFe.GetDuplicatasCompraTudo();
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            pagamentosChartControl.Series.Add(series);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            //if (e.Column.FieldName == "tipo")
            //{
                //e.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                var value = view.GetRowCellValue(e.RowHandle, "TIPO");
                if (value != null)
                {
                    if (value.ToString().Contains("C"))
                    {
                        e.Appearance.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
                

            //}
        }

        private void GER_FluxoDeCaixa_Load(object sender, EventArgs e)
        {
            CarregarGrafico();
            CarregarTotais();
        }
        private void CarregarGrafico()
        {

            //ChartControl
            chartControl1.Controls.Clear();
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();


            chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl1.AutoLayout = true;
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.DataSource = null;
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Fluxo Caixa Entrada X SAIDA";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            chartControl1.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Legenda", ViewType.Doughnut);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A} :{V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";

            //Obtem dados do banco de dados
            series.DataSource = null;
            series.DataSource = GetFluxoCaixaAgrupado();
            series.ArgumentDataMember = "origem";
            series.ValueDataMembers.AddRange(new string[] { "pago" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            chartControl1.Series.Add(series);

        }

        private bool[] SituacoesSelecionadas()
        {
          return new bool[] { checkEditCancelado.Checked, checkEditAberto.Checked, checkEditParcial.Checked, checkEditBaixado.Checked };
        }
        private void CarregarTotais()
        {
            DataTable dataTable = GetFluxoCaixa();
            decimal totalPagar = 0.00M;
            decimal totalPago = 0.00M;
            decimal totalReceber = 0.00M;
            decimal totalRecebido = 0.00M;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["TIPO"].ToString() == "D")
                {
                    totalPagar  += Convert.ToDecimal(dataTable.Rows[i]["VALOR"]);
                    totalPago += Convert.ToDecimal(dataTable.Rows[i]["PAGO"]);
                }
                else
                {
                    totalReceber += Convert.ToDecimal(dataTable.Rows[i]["VALOR"]);
                    totalRecebido += Convert.ToDecimal(dataTable.Rows[i]["PAGO"]);
                }
            }
            //ovTXT_TotalAPagar.Text = "Total a Pagar " + Environment.NewLine  +"R$ " + totalPagar.ToString("n2");
            //ovTXT_TotalAReceber.Text = "Total a Receber" + Environment.NewLine + "R$ " + totalReceber.ToString("n2");
            //ovTXT_TotalPago.Text = "Total Pago" + Environment.NewLine + "R$ " + totalPago.ToString("n2");
            //ovTXT_TotalRecebido.Text = "Total Recebido" + Environment.NewLine + "R$ " + totalRecebido.ToString("n2");

            ovTXT_TotalAPagar.Text = "Total a Pagar " + " R$ " + totalPagar.ToString("n2");
            ovTXT_TotalAReceber.Text = "Total a Receber" + " R$ " + totalReceber.ToString("n2");
            ovTXT_TotalPago.Text = "Total Pago" + " R$ " + totalPago.ToString("n2");
            ovTXT_TotalRecebido.Text = "Total Recebido"+ " R$ " + totalRecebido.ToString("n2");
        }
        private DataTable GetFluxoCaixa()
        {
            return FuncoesCaixa.GetFluxoCaixa(anoTextEdit.Text, tabSelecionado, GetOrganizarPor(), SituacoesSelecionadas());
        }

        private DataTable GetFluxoCaixaAgrupado()
        {
            return FuncoesCaixa.GetFluxoCaixaAgrupado(anoTextEdit.Text, tabSelecionado, GetOrganizarPor(), SituacoesSelecionadas());
        }
        private string GetOrganizarPor()
        {
            if (spinEditOrganizarPor.SelectedIndex == 0)
                return "emissao";
            else
                return "vencimento";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
        }
    }
}