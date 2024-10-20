using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Filtering.Templates;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;

namespace PDV.VIEW.Forms.BI
{
    public partial class BIFornecedoresECompras : DevExpress.XtraEditors.XtraForm
    {
        public BIFornecedoresECompras()
        {
            InitializeComponent();
            PreencherCamposDeFiltro();
            chartProdutosMaisComprados();
            carttop10Fornecedores();
        }

        private void PreencherCamposDeFiltro()
        {
            dateAte.DateTime = DateTime.Today;
            dateDe.DateTime = dateAte.DateTime.Date.AddMonths(-3);

            var tiposDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(DAO.Entidades.TipoDeOperacao.Entrada)
                                                           .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                           .OrderBy(x => x.Cod).ToList();

            comboOperacao.DataSource = tiposDeOperacao;
            comboOperacao.ValueMember = "Cod";
            comboOperacao.DisplayMember = "Nome";
        }

        public void chartProdutosMaisComprados()
        {
            //ChartControl
            produtosmaiscompradoschartControl.Controls.Clear();
            produtosmaiscompradoschartControl.Series.Clear();
            produtosmaiscompradoschartControl.Titles.Clear();
            produtosmaiscompradoschartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            produtosmaiscompradoschartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            produtosmaiscompradoschartControl.AutoLayout = true;

            produtosmaiscompradoschartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Top 10 Mais Comprados";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            produtosmaiscompradoschartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Legenda", ViewType.Doughnut);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A} :{V:c2}";
            series.LegendTextPattern = "{A} : {V:c2}";
            series.ShowInLegend = false;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesProduto.GetProdutosMaisComprado(dateDe.DateTime, dateAte.DateTime, Convert.ToDecimal(comboOperacao.SelectedValue));
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            produtosmaiscompradoschartControl.Series.Add(series);
        }
        public void carttop10Fornecedores()
        {
            //ChartControl
            top10FornecedoresChartControl.Controls.Clear();
            top10FornecedoresChartControl.Series.Clear();
            top10FornecedoresChartControl.Titles.Clear();

            top10FornecedoresChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            top10FornecedoresChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            top10FornecedoresChartControl.AutoLayout = true;

            top10FornecedoresChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Top 10 Fornecedores";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            top10FornecedoresChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Fornecedores", ViewType.StackedBar);
            series.Label.TextPattern = "{V:c2}";
            series.LegendTextPattern = "{A}";
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesItemPedidoCompra.GetTop10Compras(dateDe.DateTime, dateAte.DateTime, Convert.ToDecimal(comboOperacao.SelectedValue));
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });
            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            series.View.Color = Color.Red;
            top10FornecedoresChartControl.Series.Add(series);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            chartProdutosMaisComprados();
            carttop10Fornecedores();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            chartProdutosMaisComprados();
            carttop10Fornecedores();
        }
    }
}
