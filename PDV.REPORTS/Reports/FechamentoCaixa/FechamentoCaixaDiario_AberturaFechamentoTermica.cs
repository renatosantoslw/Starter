using System;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;
using PDV.DAO.Entidades.PDV;
using static PDV.CONTROLER.Funcoes.FuncoesFluxoCaixa;
using PDV.UTIL.Calculos;
using PDV.DAO.Entidades;

namespace PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica
{
    public partial class FechamentoCaixaDiario_AberturaFechamentoTermica : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDUSUARIO;
        private decimal IDFLUXOCAIXA;
        private string USUARIO;
        private string SERIE;
        private string NOMEPDV;


        public FechamentoCaixaDiario_AberturaFechamentoTermica(Usuario usuario, decimal IDFluxoCaixa, string Serie, string pdv)
        {
            InitializeComponent();
            IDUSUARIO = usuario.IDUsuario;
            IDFLUXOCAIXA = IDFluxoCaixa;
            USUARIO = usuario.Nome;
            SERIE = Serie;
            NOMEPDV = pdv;
        }

        private void FechamentoCaixaDiario_PagamentosTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var dt = FuncoesFluxoCaixa.GetDados_FluxoCaixaAberturaFechamento(IDUSUARIO, IDFLUXOCAIXA);
            if (dt.Rows.Count == 0)
            {
                e.Cancel = true;
                return;
            }
            var fluxo = GetFluxoCaixaAbertoUsuarioByIdFluxoCaixa(IDUSUARIO, IDFLUXOCAIXA);
            if (fluxo == null)
                fluxo = GetFluxoCaixaAbertoUsuario(IDUSUARIO);
            var fluxoCalculos = new FluxoCaixaPDVCalculos(fluxo);
            var totalVendas = fluxoCalculos.GetTotalVendas();
            var totalDinheiro = fluxoCalculos.GetDinheiroCaixa();
            var totalSangrias = fluxoCalculos.TotalSangrias;
            var totalSuprimento = fluxoCalculos.TotalSuprimento;
            var totalAbertura = fluxo.ValorCaixa;
            var totalEntradas = totalAbertura + totalDinheiro + totalSuprimento;
            var totalFechamento = fluxoCalculos.GetValorFechamento();


            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
            xrLabel17.Text = IDFLUXOCAIXA.ToString().PadLeft(8, '0');
            xrLabel20.Text = USUARIO;
            xrLabel22.Text = SERIE;
            xrLabel23.Text = NOMEPDV;
            xrLabel9.Text = totalAbertura.ToString("c2");
            xrLabel10.Text = totalVendas.ToString("c2");
            xrLabel12.Text = totalSangrias.ToString("c2");
            xrLabel19.Text = totalEntradas.ToString("c2");
            xrLabel6.Text = totalFechamento.ToString("c2");
            suprimentoxrLabel.Text = totalSuprimento.ToString("c2");
        }

        
    }
}
