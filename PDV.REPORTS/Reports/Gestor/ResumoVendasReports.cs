using System.Drawing;
using PDV.DAO.Entidades;
using System.IO;
using System.Data;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.QueryModels;

namespace PDV.REPORTS.Reports.Email_Gestor
{
    public partial class ResumoVendasReports : DevExpress.XtraReports.UI.XtraReport
    {
        public ResumoVendasReports(ResumoVendasQueryModel queryModel)
        {
            InitializeComponent();
            Emitente Emit = FuncoesEmitente.GetEmitente();
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);
            DataTable dt = FuncoesVenda.GetExtratoVendaReport(queryModel);
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            dataPeriodo.Text = $"Período de {queryModel.DataDe.ToString("dd/MM/yyyy")} até {queryModel.DataAte.ToString("dd/MM/yyyy")}";
        }

    }
}
