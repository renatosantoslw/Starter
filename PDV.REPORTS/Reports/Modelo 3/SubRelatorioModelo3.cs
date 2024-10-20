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

namespace PDV.REPORTS.Reports.Modelo3
{
    public partial class SubRelatorioModelo3 : DevExpress.XtraReports.UI.XtraReport
    {
        public SubRelatorioModelo3(decimal IDVENDA)
        {
            InitializeComponent();
            DataTable dt = FuncoesPedidoVendaTermica.GetDAV(IDVENDA);
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            
        }

    }
}
