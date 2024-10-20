using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.ImpressaoComandas
{
    public partial class ImpressaoComanda : DevExpress.XtraReports.UI.XtraReport
    {
        public ImpressaoComanda(decimal CodigoInicial, decimal CodigoFinal, string UsuarioEmissao)
        {
            InitializeComponent();

            ovSR_Cabecalho.ReportSource = new Cabecalho(UsuarioEmissao);

            ovTXT_CodigoInicial.Text = CodigoInicial.ToString();
            ovTXT_CodigoFinal.Text = CodigoFinal.ToString();

            DataTable dt = FuncoesComanda.GetComandas(CodigoInicial, CodigoFinal);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
