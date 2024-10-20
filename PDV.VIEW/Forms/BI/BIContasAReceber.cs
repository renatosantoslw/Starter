using DevExpress.XtraCharts;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.ModelosEspecificos;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PDV.VIEW.Forms.BI
{
    public partial class BIContasAReceber : DevExpress.XtraEditors.XtraForm
    {
        public BIContasAReceber()
        {
            InitializeComponent();
            PreencherCamposDeFiltro();
            #region Contas a Receber
            ChartFormasDePagamento();
            ChartPorSituacao();
            #endregion
        }

        private void PreencherCamposDeFiltro()
        {


            comboFiltrarPor.DataSource = new List<FiltrarPorModel>
            {
                new FiltrarPorModel("VENCIMENTO", "Data de vencimento"),
                new FiltrarPorModel("EMISSAO", "Data de emissão")
            };

            comboFiltrarPor.DisplayMember = "Descricao";
            comboFiltrarPor.ValueMember = "NomeColunaBanco";

            dateAte.DateTime = DateTime.Today;
            dateDe.DateTime = dateAte.DateTime.Date.AddMonths(-3);
        }

        public void ChartFormasDePagamento()
        {
            //ChartControl
            contasAReceberPorFormaDePagamento.Controls.Clear();
            contasAReceberPorFormaDePagamento.Series.Clear();
            contasAReceberPorFormaDePagamento.Titles.Clear();

            contasAReceberPorFormaDePagamento.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            contasAReceberPorFormaDePagamento.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            contasAReceberPorFormaDePagamento.AutoLayout = true;

            contasAReceberPorFormaDePagamento.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            FontFamily fontFamily = new FontFamily("Tahoma");
            Font font = new Font(
               fontFamily,
               8,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Formas de Pagamento";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            contasAReceberPorFormaDePagamento.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Formas de Pagamento", ViewType.Line);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series.Label.TextPattern = "{A} : {V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";
            series.Label.Font = font;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.ShowInLegend = false;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesContaReceber
                .GetContaReceberAgrupadasPorFormaDePagamento(dateDe.DateTime, dateAte.DateTime, comboFiltrarPor.SelectedValue.ToString());
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "soma" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            contasAReceberPorFormaDePagamento.Series.Add(series);
        }
        public void ChartPorSituacao()
        {
            //ChartControl
            contasAReceberPorSituacao.Controls.Clear();
            contasAReceberPorSituacao.Series.Clear();
            contasAReceberPorSituacao.Titles.Clear();

            contasAReceberPorSituacao.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            contasAReceberPorSituacao.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            contasAReceberPorSituacao.AutoLayout = true;

            contasAReceberPorSituacao.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Por Situação";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            contasAReceberPorSituacao.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Clientes", ViewType.Doughnut);
            series.Label.TextPattern = "{A} : {V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.ShowInLegend = false;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesContaReceber
                .GetContasReceberAgrupadasPorSituacao(dateDe.DateTime, dateAte.DateTime, comboFiltrarPor.SelectedValue.ToString());
            series.ArgumentDataMember = "status";
            series.ValueDataMembers.AddRange(new string[] { "soma" });
            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            series.View.Color = Color.Green;
            contasAReceberPorSituacao.Series.Add(series);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ChartFormasDePagamento();
            ChartPorSituacao();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ChartFormasDePagamento();
            ChartPorSituacao();
        }
    }
}
