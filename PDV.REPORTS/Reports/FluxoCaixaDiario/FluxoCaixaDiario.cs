using DevExpress.XtraReports.UI;
using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;

namespace PDV.REPORTS.Reports.FluxoCaixaDiario
{
    public partial class FluxoCaixaDiario : XtraReport
    {
        public FluxoCaixaDiario(decimal IDUsuario, decimal IDFluxoCaixa, string UsuarioEmissao, string Usuario)
        {
            InitializeComponent();

            ovTXT_Usuario.Text = Usuario;
            ovSR_Cabecalho.ReportSource = new Cabecalho(UsuarioEmissao);
            ovSR_TotalizadorFormaPagamento.ReportSource = new FluxoCaixaDiario_TotalizadorPagamentos(IDUsuario, IDFluxoCaixa);

            DataTable dt = FuncoesFluxoCaixa.GetDados_FluxoCaixa(IDUsuario, IDFluxoCaixa);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
