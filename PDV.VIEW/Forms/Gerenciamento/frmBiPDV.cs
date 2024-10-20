using DevExpress.XtraCharts;
using PDV.DAO.DB.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace One.Loja
{
    public partial class frmBiPDV : DevExpress.XtraEditors.XtraForm
    {
        public frmBiPDV()
        {
            InitializeComponent();
            dateAte.DateTime = DateTime.Today;
            dateDe.DateTime = dateAte.DateTime.Date.AddMonths(-1);

            //icones
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 40);
            Bitmap bitmapTotais = IconChar.ChartPie.ToBitmap(Color.SteelBlue, 40);
            
            Bitmap bitmapBtnAtualizar  = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 40);


             
            simpleButton2.ImageOptions.Image = bitmapAtualizar;
            lblChartDia.ImageOptions.Image   = bitmapTotais;
            labelControl1.ImageOptions.Image = bitmapBtnAtualizar;
            labelControl2.ImageOptions.Image = bitmapTotais;
            labelControl5.ImageOptions.Image = bitmapTotais;


        }
        private void frmBiPDV_Load(object sender, EventArgs e)
        {
            carregarChart();
        }

        private DataTable CarregarConsultaVendas(DateTime dtInicial, DateTime dtFinal, string Tipo, string Status)
        {
            DataTable tab = null;




            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                if (Tipo == "Diário")// estava Díario
                {
                    /*   using (SQLQuery oSQL = new SQLQuery())
                       {
                           oSQL.SQL = $@" Select 
                           EXTRACT(Day FROM datacadastro) as Dia
                           ,Sum(valortotal) as Valor
                             From Venda 
                             where EXTRACT(DAY FROM datacadastro) = {DateTime.Now.Date.Day}
                             and EXTRACT(Month FROM datacadastro) = {DateTime.Now.Date.Month}
                             and EXTRACT(Year FROM datacadastro)  = {dtInicial.Date.Year}
                             and status =1
                            Group by EXTRACT(Day FROM datacadastro)  Order By Dia";                    
                           oSQL.Open();
                           return tab =  oSQL.dtDados;
                       }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" SELECT 
                          DAY(DATACADASTRO) AS DIA
                         ,SUM(VALORTOTAL) AS VALOR
                          FROM VENDA 
                          WHERE DAY(DATACADASTRO) = {DateTime.Now.Date.Day}
                          AND MONTH(DATACADASTRO) = {DateTime.Now.Date.Month}
                          AND YEAR(DATACADASTRO) = {dtInicial.Date.Year}
                          AND STATUS = 1
                          GROUP BY DAY(DATACADASTRO)  ORDER BY DIA";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }



                }
                else if (Tipo == "ProdutoValor")
                {
                    /*using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"Select Top 5  
                           vi.idproduto + ' - '+substring(Vi.descricao,1,10) as Produtos,
                            Sum(quantidade * valorunitarioitem) as Valor 
                            from itemvenda VI
                            left Join Venda V on V.idvenda = VI.idvenda
                            where DATACADASTRO BETWEEN @DATE1 AND @DATE2 
  	                        and v.status = 1
                            Group by Vi.descricao, vi.idproduto
                            Order by Sum(quantidade * valorunitarioitem) desc limit 5";
                        oSQL.ParamByName["DATE1"] = dtInicial.Date;
                        oSQL.ParamByName["DATE2"] = dtFinal.Date;
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"SELECT TOP 5  
                           ISNULL(CAST(VI.IDPRODUTO AS VARCHAR), '') + ' - '+ ISNULL(SUBSTRING(VI.DESCRICAO,1,10), '') AS PRODUTOS,
                            SUM(QUANTIDADE * VALORUNITARIOITEM) AS VALOR 
                            FROM ITEMVENDA VI
                            LEFT JOIN VENDA V ON V.IDVENDA = VI.IDVENDA
                            WHERE DATACADASTRO BETWEEN @DATE1 AND @DATE2 
  	                        AND V.STATUS = 1
                            GROUP BY VI.DESCRICAO, VI.IDPRODUTO
                            ORDER BY SUM(QUANTIDADE * VALORUNITARIOITEM) DESC";
                        oSQL.ParamByName["DATE1"] = dtInicial.Date.ToString("yyyy-MM-dd 00:00:00");
                        oSQL.ParamByName["DATE2"] = dtFinal.Date.ToString("yyyy-MM-dd 23:59:59");
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }



                }
                else if (Tipo == "ProdutoQuantidade")
                {
                    /*using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"Select
                            vi.idproduto + ' - '+substring(Vi.descricao,1,10) as Produtos,
                            Sum(quantidade) as Valor 
                            from itemvenda VI
                            left Join Venda V on V.idvenda = VI.idvenda
                            where DATACADASTRO BETWEEN @DATE1 AND @DATE2 
  	                        and v.status = 1
                            Group by Vi.descricao, vi.idproduto
                            Order by Sum(quantidade) desc limit 5";
                        oSQL.ParamByName["DATE1"] = dtInicial.Date;
                        oSQL.ParamByName["DATE2"] = dtFinal.Date;
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"SELECT TOP 5
                            ISNULL(CAST(VI.IDPRODUTO AS VARCHAR), '') + ' - ' + ISNULL(SUBSTRING(VI.DESCRICAO,1,10), '') AS PRODUTOS,
                            SUM(QUANTIDADE) AS VALOR 
                            FROM ITEMVENDA VI
                            LEFT JOIN VENDA V ON V.IDVENDA = VI.IDVENDA
                            WHERE DATACADASTRO BETWEEN @DATE1 AND @DATE2 
  	                        AND V.STATUS = 1
                            GROUP BY VI.DESCRICAO, VI.IDPRODUTO
                            ORDER BY SUM(QUANTIDADE) DESC";
                        oSQL.ParamByName["DATE1"] = dtInicial.Date.ToString("yyyy-MM-dd 00:00:00"); ;
                        oSQL.ParamByName["DATE2"] = dtFinal.Date.ToString("yyyy-MM-dd 23:59:59"); ;
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }


                }
                else if (Tipo == "Mensal")
                {
                    /*using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" Select 
                        EXTRACT(Month FROM datacadastro) as Dia
                        ,Sum(valortotal) as Valor
                          From Venda 
                          Where EXTRACT(Month FROM datacadastro) = {DateTime.Now.Date.Month}
                          and EXTRACT(Year FROM datacadastro) = {dtInicial.Date.Year}
                          and status =1
                         Group by EXTRACT(Month FROM datacadastro) Order By Dia";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"SELECT 
                        MONTH(DATACADASTRO) AS DIA
                        ,SUM(VALORTOTAL) AS VALOR
                        FROM VENDA 
                          WHERE MONTH(DATACADASTRO)= {DateTime.Now.Date.Month}
                          AND YEAR(DATACADASTRO)   = {dtInicial.Date.Year}
                          AND STATUS =1
                         Group by MONTH(DATACADASTRO) ORDER BY DIA";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }



                }
                else if (Tipo == "Anual")
                {
                    /*using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" Select 
                       EXTRACT(Year FROM datacadastro)  as Dia
                        ,Sum(valortotal) as Valor
                          From Venda 
                          Where EXTRACT(Year FROM datacadastro) = {dtInicial.Date.Year}
                          and status =1
                         Group by EXTRACT(Year FROM datacadastro) Order By Dia";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" SELECT 
                        YEAR(DATACADASTRO)  AS DIA
                        ,SUM(VALORTOTAL) AS VALOR
                        FROM VENDA 
                         WHERE YEAR(DATACADASTRO) = {dtInicial.Date.Year}
                          and status =1
                         Group by YEAR(DATACADASTRO) Order By Dia";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }
                }
                else if (Tipo == "AgrupamentoMensal")
                {
                    /*using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" select 
                        case when EXTRACT(Month FROM datacadastro) = 1 then 'JANEIRO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 2 then 'FEVEREIRO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 3 then 'MARÇO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 4 then 'ABRIL' 
                             WHEN EXTRACT(Month FROM datacadastro) = 5 then 'MAIO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 6 then 'JUNHO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 7 then 'JULHO' 
                            WHEN EXTRACT(Month FROM datacadastro) = 8 then 'AGOSTO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 9 then 'SETEMBRO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 10 then 'OUTUBRO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 11 then 'NOVEMBRO' 
                             WHEN EXTRACT(Month FROM datacadastro) = 12 then 'DEZEMBRO' 
                           else ' ' end as Dia ,
                          Sum(valortotal)  as Valor
                           From Venda V 
                           where EXTRACT(Year FROM datacadastro) =  {dtInicial.Date.Year}
                          and status = 1
						  Group By EXTRACT(Month FROM datacadastro)
						  order by EXTRACT(Month FROM datacadastro)";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@" select 
                            case when MONTH(datacadastro) = 1 then 'JANEIRO' 
                            WHEN MONTH(DATACADASTRO) = 2 then 'FEVEREIRO' 
                            WHEN MONTH(DATACADASTRO) = 3 then 'MARÇO' 
                            WHEN MONTH(DATACADASTRO) = 4 then 'ABRIL' 
                            WHEN MONTH(DATACADASTRO) = 5 then 'MAIO' 
                            WHEN MONTH(DATACADASTRO) = 6 then 'JUNHO' 
                            WHEN MONTH(DATACADASTRO) = 7 then 'JULHO' 
                            WHEN MONTH(datacadastro) = 8 then 'AGOSTO' 
                            WHEN MONTH(DATACADASTRO) = 9 then 'SETEMBRO' 
                            WHEN MONTH(DATACADASTRO) = 10 then 'OUTUBRO' 
                            WHEN MONTH(DATACADASTRO) = 11 then 'NOVEMBRO' 
                            WHEN MONTH(DATACADASTRO) = 12 then 'DEZEMBRO' 
                            else ' ' end as DIA ,
                            Sum(VALORTOTAL)  as VALOR
                            From VENDA V 
                           where YEAR(DATACADASTRO) =   {dtInicial.Date.Year}
                          and status = 1
                            Group By MONTH(DATACADASTRO)
                            order by MONTH(DATACADASTRO)";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }



                }


                else if (Tipo == "MensalBarra")
                {

                    /* using (SQLQuery oSQL = new SQLQuery())
                     {
                         oSQL.SQL = $@"  Select 
                                      EXTRACT(Month FROM datacadastro) as Dia ,
                                     Sum(valortotal) as Valor    
                                from Venda V
                                     Where EXTRACT(Year FROM datacadastro) ={dtInicial.Date.Year}
                                       and v.status =1
                                   Group by  EXTRACT(Month FROM datacadastro)
                                   order by EXTRACT(Month FROM datacadastro)";
                         oSQL.Open();
                         return tab = oSQL.dtDados;
                     }*/

                    using (SQLQuery oSQL = new SQLQuery())
                    {
                        oSQL.SQL = $@"  Select 
                                    MONTH(DATACADASTRO) as DIA ,
                                    Sum(VALORTOTAL) as VALOR    
                                    from Venda V
                                    Where YEAR(DATACADASTRO) ={dtInicial.Date.Year}
                                      and v.status =1
                                    Group by  MONTH(DATACADASTRO)
                                    order by MONTH(DATACADASTRO)";
                        oSQL.Open();
                        return tab = oSQL.dtDados;
                    }


                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }

        public void carregarChart()
        {
            try
            {
                #region Por Dia
                //Vendas  Por dia 
                DataTable tabDia = null;
                tabDia = CarregarConsultaVendas(dateDe.DateTime, dateAte.DateTime, "Diário", "Ativo");
                if (tabDia == null)
                {
                    lblTotalDia.Text = "R$ 0,00";
                }

                if (tabDia.Rows.Count > 0)
                {
                    foreach (DataRow item in tabDia.Rows)
                    {
                        decimal valor = decimal.Parse(tabDia.Rows[0]["Valor"].ToString());

                        lblTotalDia.Text = valor.ToString("C");
                    }
                }
                else
                {
                    lblTotalDia.Text = "R$ 0,00";
                }
                #endregion

                #region Produtos Valor

                DataTable tabProdutosValor = CarregarConsultaVendas(dateDe.DateTime, dateAte.DateTime, "ProdutoValor", "Ativo");
                if (tabProdutosValor == null)
                {
                    return;
                }
                chartControl2.Controls.Clear();
                chartControl2.Series.Clear();
                chartControl2.Titles.Clear();
                chartControl2.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
                chartControl2.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl2.AutoLayout = true;
                chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                ChartTitle chartTitle = new ChartTitle();
                chartTitle.Text = $"Produtos Valor ({dateDe.DateTime.Date.Year}) ";
                chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
                chartTitle.Alignment = StringAlignment.Center;
                chartControl2.Titles.Add(chartTitle);
                //Series
                DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series("Legenda", ViewType.Bar);
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Label.TextPattern = "{A} :{V:c2}";
                series.LegendTextPattern = "{A} : {V:c2}";
                //Obtem dados do banco de dados
                series.DataSource = tabProdutosValor;
                series.ArgumentDataMember = "Produtos";
                series.ValueDataMembers.AddRange(new string[] { "Valor" });

                series.ValueScaleType = ScaleType.Numerical;
                series.ToolTipSeriesPattern = "{c2}";
                chartControl2.Series.Add(series);


                #endregion

                #region Produtos Quantidade

                DataTable tabProdutoQuantidade = CarregarConsultaVendas(dateDe.DateTime, dateAte.DateTime, "ProdutoQuantidade", "Ativo");
                if (tabProdutoQuantidade == null)
                {
                    return;
                }

                chartControl3.Controls.Clear();
                chartControl3.Series.Clear();
                chartControl3.Titles.Clear();
                chartControl3.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
                chartControl3.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl3.AutoLayout = true;
                chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                ChartTitle chartTitle3 = new ChartTitle();
                chartTitle3.Text = $"Produtos Quantidade ({dateDe.DateTime.Date.Year}) ";
                chartTitle3.Font = new System.Drawing.Font("Tahoma", 8F);
                chartTitle3.Alignment = StringAlignment.Center;
                chartControl3.Titles.Add(chartTitle3);
                //Series
                DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series("Legenda", ViewType.Line);
                series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //series3.Label.TextPattern = "{A} :{V:n}";
                //series3.LegendTextPattern = "{A} : {V:n}";
                //Obtem dados do banco de dados
                series3.DataSource = tabProdutoQuantidade;
                series3.ArgumentDataMember = "Produtos";
                series3.ValueDataMembers.AddRange(new string[] { "Valor" });

                series3.ValueScaleType = ScaleType.Numerical;
                //series3.ToolTipSeriesPattern = "{n}";
                chartControl3.Series.Add(series3);
                #endregion

                #region Total Mensal
                //Vendas  Por mes 
                DataTable tabmes = null;
                tabmes = CarregarConsultaVendas(dateDe.DateTime, dateDe.DateTime, "Mensal", "Ativo");
                if (tabmes == null)
                {
                    lblTotalMes.Text = "R$ 0,00";
                }
                if (tabmes.Rows.Count > 0)
                {
                    try
                    {

                        if (tabmes.Rows.Count > 0)
                        {
                            foreach (DataRow item in tabmes.Rows)
                            {
                                decimal valor = decimal.Parse(tabmes.Rows[0]["Valor"].ToString());

                                lblTotalMes.Text = valor.ToString("C");
                            }
                        }
                        else
                        {
                            lblTotalMes.Text = "R$ 0,00";
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
                else
                {
                    lblTotalMes.Text = "0,00";
                }
                #endregion

                #region Agrupamento Mensal
                //AgrupamentoMensal
                DataTable tabacumuladomes = null;
                tabacumuladomes = CarregarConsultaVendas(dateDe.DateTime, dateAte.DateTime, "AgrupamentoMensal", "Ativo");

                if (tabacumuladomes == null)
                {
                    return;
                }

                int numeraAcumuladomes = -1;

                chartControl1.Controls.Clear();
                chartControl1.Series.Clear();
                chartControl1.Titles.Clear();
                chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
                chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl1.AutoLayout = true;
                chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = $"Agrupamento de Vendas por Mês {dateDe.DateTime.Date.Year}";
                chartTitle1.Font = new System.Drawing.Font("Tahoma", 8F);
                chartTitle1.Alignment = StringAlignment.Center;
                chartControl1.Titles.Add(chartTitle1);
                //Series
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series("Legenda", ViewType.Doughnut);
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.TextPattern = "{A} :{V:c2}";
                series1.LegendTextPattern = "{A} : {V:c2}";
                //Obtem dados do banco de dados
                series1.DataSource = tabacumuladomes;
                series1.ArgumentDataMember = "Dia";
                series1.ValueDataMembers.AddRange(new string[] { "Valor" });

                series1.ValueScaleType = ScaleType.Numerical;
                series1.ToolTipSeriesPattern = "{c2}";
                chartControl1.Series.Add(series1);

                #endregion

                #region Totalizar Por Ano
                DataTable tabacumuladoano = null;
                tabacumuladoano = CarregarConsultaVendas(DateTime.Now, DateTime.Now, "Anual", "Ativo");
                if (tabacumuladoano == null)
                {
                    lblTotalAno.Text = " R$ 0,00";
                }

                if (tabacumuladoano.Rows.Count > 0)
                {
                    foreach (DataRow item in tabacumuladoano.Rows)
                    {
                        decimal valor = decimal.Parse(tabacumuladoano.Rows[0]["Valor"].ToString());
                        lblTotalAno.Text = valor.ToString("C");
                    }
                }
                else
                {
                    lblTotalAno.Text = " R$ 0,00";
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmBiPDV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    carregarChart();
                    break;
            }
        }

        private void txtAnoRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                carregarChart();
            }
        }
         private void simpleButton1_Click(object sender, EventArgs e)
        {
            carregarChart();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalDia_Click(object sender, EventArgs e)
        {

        }
                
        private void labelControl1_Click(object sender, EventArgs e)
        {
            carregarChart();
        }
    }
}
