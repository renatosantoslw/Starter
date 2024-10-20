using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using System.IO;
using PDV.REPORTS.Reports.DAV;

namespace PDV.REPORTS.Reports.Modelo_1

{
    public partial class Modelo1DuasVias : DevExpress.XtraReports.UI.XtraReport
    {
        int subreportRowsCount = 4;
        int Itens = 0;
        decimal _IDVENDA = 0;
        public Modelo1DuasVias(decimal IDVENDA)
        {
            _IDVENDA = IDVENDA;
            InitializeComponent();
            DataTable dt = FuncoesPedidoVendaTermica.GetDAV(IDVENDA);
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            Itens = dt.Rows.Count;

            for (int i = 0; i < Itens; i++)
                dt.Rows[i]["observacao"] = dt.Rows[i]["observacao"].ToString() + dt.Rows[i]["pagamentosdescricao"].ToString();


            xrSubreport2.ReportSource = new SubRelatorioModelo1(_IDVENDA);
            xrSubreport1.ReportSource = new SubRelatorioModelo1(_IDVENDA);

        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int i = Convert.ToInt32(this.GetCurrentColumnValue("calculatedField1"));
            XtraReport report = ((XRSubreport)sender).ReportSource;
            int minIndex = i * subreportRowsCount + 1;
            report.FilterString = "[codigoProduto]<" + (minIndex + subreportRowsCount).ToString() + "AND [codigoProduto]>= " + minIndex.ToString();

        }

        private void calculatedField1_GetValue(object sender, GetValueEventArgs e)
        {
            try
            {
                e.Value = ((Itens) / subreportRowsCount);
            }
            catch (Exception)
            {

               
            }
            
        }

        private void impressaoDavC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
            
        }
    }
}
