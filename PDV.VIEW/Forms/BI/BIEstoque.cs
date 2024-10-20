using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Filtering.Templates;
using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace PDV.VIEW.Forms.BI
{
    public partial class BIEstoque : DevExpress.XtraEditors.XtraForm
    {
        public BIEstoque()
        {
            InitializeComponent();
          
            charEstoque();
            FormatarGrid();
           
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1, "DESCRIÇÃO");
            Grids.FormatColumnType(ref gridView1, new List<string>
            {
                "custo",
                "totalcusto"
            }, GridFormats.Finance);
        }

        public void charEstoque()
        {
            //ChartControl
            estoqueChartControl.Controls.Clear();
            estoqueChartControl.Series.Clear();
            estoqueChartControl.Titles.Clear();
            estoqueChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            estoqueChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            estoqueChartControl.AutoLayout = true;
            estoqueChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "Estoque";
            chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle.Alignment = StringAlignment.Center;
            estoqueChartControl.Titles.Add(chartTitle);
            //Series
            Series series = new Series("Legenda", ViewType.Bar);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //series.Label.TextPattern = "{A} :{V:c2}";
            //series.LegendTextPattern = "{A} : {V:c2}";
            series.ShowInLegend = false;
            //Obtem dados do banco de dados
            series.DataSource = FuncoesProduto.GetPosicaoEstoqueChart();
            series.ArgumentDataMember = "descricao";
            series.ValueDataMembers.AddRange(new string[] { "valor" });
            series.ValueScaleType = ScaleType.Numerical;
            series.ToolTipSeriesPattern = "{c2}";

            gridControl1.DataSource = FuncoesProduto.GetPosicaoEstoqueGeralChart();

            estoqueChartControl.Series.Add(series);
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            charEstoque();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            charEstoque();
        }

    }
}
