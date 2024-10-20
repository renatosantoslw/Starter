using DevExpress.XtraCharts;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;

namespace PDV.VIEW.Forms.BI
{
    public partial class BIVendedoresEClientes : DevExpress.XtraEditors.XtraForm
    {
        public BIVendedoresEClientes()
        {
            InitializeComponent();
            PreencherCamposDeFiltro();
            #region Vendas E Compra
            chartVendasGeralPorVendedor();
            chartProdutosMaisComprados();
            carttop10Clientes();
            carttop10Fornecedores();
            #endregion
        }

        private void PreencherCamposDeFiltro()
        {
            dateAte.DateTime = DateTime.Today;
            dateDe.DateTime = dateAte.DateTime.Date.AddMonths(-3);

            var tiposDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(DAO.Entidades.TipoDeOperacao.Saida)
                                                           .Select(s => new { Cod = s.IDTipoDeOperacao, Nome = s.Nome })
                                                           .OrderBy(x => x.Cod).ToList();

            comboOperacao.DataSource = tiposDeOperacao;
            comboOperacao.ValueMember = "Cod";
            comboOperacao.DisplayMember = "Nome";
        }

        #region Vendas E Compra
        public void chartVendasGeralPorVendedor()
        {
            //ChartControl
            vendasGeralPorVendedorChartControl.Controls.Clear();
            vendasGeralPorVendedorChartControl.Series.Clear();
            vendasGeralPorVendedorChartControl.Titles.Clear();

            vendasGeralPorVendedorChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            vendasGeralPorVendedorChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            vendasGeralPorVendedorChartControl.AutoLayout = true;

            vendasGeralPorVendedorChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            FontFamily fontFamily = new FontFamily("Tahoma");
            Font font = new Font(
               fontFamily,
               8,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Top Vendas e Vendedores";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            vendasGeralPorVendedorChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Vendedores", ViewType.Bar);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series.Label.TextPattern = "{V:c2}";
            series.LegendTextPattern = "{A}";
            series.Label.Font = font;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesVenda.GetVendasPorVendedorGeral(dateDe.DateTime, dateAte.DateTime, Convert.ToInt32(comboOperacao.SelectedValue));
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });

            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            vendasGeralPorVendedorChartControl.Series.Add(series);
        }
        public void chartProdutosMaisComprados()
        {
            //ChartControl
            //produtosmaiscompradoschartControl.Controls.Clear();
            //produtosmaiscompradoschartControl.Series.Clear();
            //produtosmaiscompradoschartControl.Titles.Clear();


            //produtosmaiscompradoschartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            //produtosmaiscompradoschartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            //produtosmaiscompradoschartControl.AutoLayout = true;

            //produtosmaiscompradoschartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //ChartTitle chartTitle = new ChartTitle();
            //chartTitle.Text = "Top 10 Mais Comprados";
            //chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            //chartTitle.Alignment = StringAlignment.Center;
            //produtosmaiscompradoschartControl.Titles.Add(chartTitle);
            ////Series
            //Series series = new Series("Legenda", ViewType.Doughnut);
            //series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            //series.Label.TextPattern = "{A} :{V:c2}";
            //series.LegendTextPattern = "{A} : {V:c2}";
            ////Obtem dados do banco de dados
            //series.DataSource = FuncoesProduto.GetProdutosMaisComprado();
            //series.ArgumentDataMember = "descricao";
            //series.ValueDataMembers.AddRange(new string[] { "valor" });

            //series.ValueScaleType = ScaleType.Numerical;
            //series.ToolTipSeriesPattern = "{c2}";
            //produtosmaiscompradoschartControl.Series.Add(series);
        }
        public void carttop10Clientes()
        {
            //ChartControl
            top10ClientesChartControl.Controls.Clear();
            top10ClientesChartControl.Series.Clear();
            top10ClientesChartControl.Titles.Clear();

            top10ClientesChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            top10ClientesChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            top10ClientesChartControl.AutoLayout = true;

            top10ClientesChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Top  Clientes";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            top10ClientesChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Clientes", ViewType.Line);
            series.Label.TextPattern = "{V:c2}";
            series.LegendTextPattern = "{A}";
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesVenda.GetTop10Vendas(dateDe.DateTime, dateAte.DateTime, Convert.ToDecimal(comboOperacao.SelectedValue));
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });
            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";
            series.View.Color = Color.Green;
            top10ClientesChartControl.Series.Add(series);
        }
        public void carttop10Fornecedores()
        {
            //ChartControl
            //top10FornecedoresChartControl.Controls.Clear();
            //top10FornecedoresChartControl.Series.Clear();
            //top10FornecedoresChartControl.Titles.Clear();

            //top10FornecedoresChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            //top10FornecedoresChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            //top10FornecedoresChartControl.AutoLayout = true;

            //top10FornecedoresChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //ChartTitle chartTitle = new ChartTitle();
            //chartTitle.Text = "Top 10 Fornecedores";
            //chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            //chartTitle.Alignment = StringAlignment.Center;
            //top10FornecedoresChartControl.Titles.Add(chartTitle);
            ////Series
            //Series series = new Series("Fornecedores", ViewType.StackedBar);
            //series.Label.TextPattern = "{V:c2}";
            //series.LegendTextPattern = "{A}";
            //series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ////Obtem dados do banco de dados
            //series.DataSource = FuncoesItemPedidoCompra.GetTop10Compras();
            //series.ArgumentDataMember = "descricao";
            //series.ValueDataMembers.AddRange(new string[] { "valor" });
            //series.ValueScaleType = ScaleType.Numerical;
            //series.ToolTipSeriesPattern = "{c2}";
            //series.View.Color = Color.Red;
            //top10FornecedoresChartControl.Series.Add(series);
        }
        #endregion

        #region Financeiro

        #endregion

        #region Estoque

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            chartVendasGeralPorVendedor();
            chartProdutosMaisComprados();
            carttop10Clientes();
            carttop10Fornecedores();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            chartVendasGeralPorVendedor();
            chartProdutosMaisComprados();
            carttop10Clientes();
            carttop10Fornecedores();
        }
    }
}
