using DevExpress.XtraReports.UI;
using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiarioTermica : XtraReport
    {
        public FechamentoCaixaDiarioTermica(Usuario usuario, decimal IDFluxoCaixa, string Serie, string PDV, bool Resumido)
        {
            InitializeComponent();

            ovTXT_Usuario.Text = usuario.Nome;
            ovSR_Cabecalho.ReportSource = new CabecalhoTermica();
            ovSR_TotalVendasPorClienteTermica.ReportSource = new FechamentoCaixaDiario_TotalVendasPorClienteTermica(IDFluxoCaixa);
            ovSR_TotalizadorFormaPagamento.ReportSource = new FechamentoCaixaDiario_TotalizadorPagamentosTermica(usuario.IDUsuario, IDFluxoCaixa);
            ovSR_Recebimentos.ReportSource = new FechamentoCaixaDiario_RecebimentosTermica(IDFluxoCaixa);
            ovSR_Sangrias.ReportSource = new FechamentoCaixaDiario_SangriasTermica(usuario.IDUsuario, IDFluxoCaixa);
            ovSR_Suprimentos.ReportSource = new FechamentoCaixaDiario_SuprimentoDeCaixaTermica(IDFluxoCaixa);
            ov_SR_AberturaFechamento.ReportSource = new FechamentoCaixaDiario_AberturaFechamentoTermica(usuario, IDFluxoCaixa, Serie, PDV);           
            ov_SR_DadosDeConferencia.ReportSource = new FechamentoCaixaDiario_DadosDeConferenciaTermica(IDFluxoCaixa);
            ov_SR_ProdutosVendidos.ReportSource = new FechamentoCaixaDiario_ProdutoVendidosTermica(IDFluxoCaixa);
            ov_SR_TotaisVendas.ReportSource = new FechamentoCaixaDiario_TotaisVendasTermica();

            Detail.Visible = Resumido;
            DataTable dt = FuncoesFluxoCaixa.GetDados_FluxoCaixa(usuario.IDUsuario, IDFluxoCaixa);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }

    }
}
