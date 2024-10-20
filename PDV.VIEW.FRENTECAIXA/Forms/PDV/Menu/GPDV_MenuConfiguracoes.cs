using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.FechamentoCaixaDiarioTermica;
using PDV.UTIL.Calculos;
using PDV.UTIL.FORMS.Forms;
using PDV.UTIL.FORMS.Forms.Caixa;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.TEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV.Menu
{
    public partial class GPDV_MenuConfiguracoes : DevExpress.XtraEditors.XtraForm
    {
        public List<String> TextoReciboTef { get; set; }
        private string NOME_TELA = "CONFIGURAÇÕES DO PDV";
        private FluxoCaixa FluxoAberto = null;
        private FluxoCaixa FLUXO = null;
        private GPDV_PainelInicial TelaPDV = null;
        public Caixa MostrarRelatorio = null;
        private FluxoCaixaPDVCalculos FluxoCalculos { get; set; }

        /* InformaçõesVersao */
        private string VERSAO = string.Empty;
        private string Endereco = string.Empty;
        private string Usuario = string.Empty;
        private string Senha = string.Empty;

        private void TrataRetorno(RetornoBasico retornoBasico)
        {
            RetornoDados(retornoBasico.Retorno, statusSefazLabel1);
        }

        internal void RetornoDados<T>(T objeto, SimpleButton TextBox) where T : class
        {
            TextBox.Text = string.Empty;

            foreach (var atributos in LerPropriedades(objeto))
            {
                if (atributos.Key == "xMotivo")
                    TextBox.Text += (atributos.Key + " = " + atributos.Value);
            }

        }


        private void OcutarTotais()
        {

            ovTXT_TotalAbertura.Visible = false;
            ovTXT_Suprimento.Visible = false;
            ovTXT_Sangria.Visible = false;
            ovTXT_TotalVendas.Visible = false;
            ovTXT_DinheiroCaixa.Visible = false;
            produtosMaisChartControl.Visible = false;
        }



        public static Dictionary<string, object> LerPropriedades<T>(T objeto) where T : class
        {
            //A função pode ser melhorada para trazer recursivamente as proprieades dos objetos filhos
            var dicionario = new Dictionary<string, object>();

            foreach (var attributo in objeto.GetType().GetProperties())
            {
                var value = attributo.GetValue(objeto, null);
                dicionario.Add(attributo.Name, value);
            }

            return dicionario;
        }
        private void ConsultarStatus()
        {
            try
            {
                #region Status do serviço
                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFCe.CfgServico);
                var retornoStatus = servicoNFe.NfeStatusServico();
                TrataRetorno(retornoStatus);
                statusSefazLabel1.ForeColor = System.Drawing.Color.Green;
                statusSefazLabel1.Text = statusSefazLabel1.Text.Replace("xMotivo", "STATUS SEFAZ");
                #endregion
            }
            catch (Exception ex)
            {
                statusSefazLabel1.ForeColor = System.Drawing.Color.Red;
                statusSefazLabel1.Text = ex.Message;
            }
        }
        public GPDV_MenuConfiguracoes(GPDV_PainelInicial _TelaPDV)
        {
            InitializeComponent();
            TelaPDV = _TelaPDV;
            FluxoAberto = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
            MostrarRelatorio = (FuncoesCaixa.GetCaixa(FluxoAberto.CaixaID));

            if (!MostrarRelatorio.Mostrar_Relatorio_Caixa) OcutarTotais();

            CarregarValores();
            chartProdutosMaisVendidos();

            //  VerificaAtualizacao();
        }

        private void CarregarValores()
        {
            btnManutencao.Enabled = false;
            if (FluxoAberto == null)
                return;

            FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuarioByIdFluxoCaixa(Contexto.USUARIOLOGADO.IDUsuario, FluxoAberto.IDFluxoCaixa);
            if (FLUXO == null)
                FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
            if (FLUXO != null)
            {
                btnManutencao.Enabled = true;
                if (FLUXO.Aberto == 1)
                {
                    FluxoCalculos = new FluxoCaixaPDVCalculos(FLUXO);
                    ovTXT_DataAbertura.Text = FluxoAberto.DataAberturaCaixa.ToString();


                    ovTXT_TotalAbertura.Text = FLUXO.ValorCaixa.ToString("c2");
                    ovTXT_TotalVendas.Text = FluxoCalculos.GetTotalVendas().ToString("c2");
                    ovTXT_Sangria.Text = FluxoCalculos.TotalSangrias.ToString("c2");
                    ovTXT_Suprimento.Text = FluxoCalculos.TotalSuprimento.ToString("c2");
                    ovTXT_DinheiroCaixa.Text = FluxoCalculos.GetDinheiroCaixa().ToString("c2");
                }
                else
                {
                    ovTXT_DataAbertura.Text = "";
                    ovTXT_TotalAbertura.Text = "0,00";
                    ovTXT_TotalVendas.Text = "0,00";
                    ovTXT_Sangria.Text = "0,00";
                    ovTXT_Suprimento.Text = "0,00";
                    ovTXT_DinheiroCaixa.Text = "0,00";

                }

                ovTXT_Usuario.Text = Contexto.USUARIOLOGADO.Nome;

                ovTXT_SerieAtual.Text = "Serie NFCe :" + Contexto.CONFIGURACAO_SERIE.SerieNFCe.ToString();
                ovTXT_UltimaNFCe.Text = "Ultima NFCe:" + FuncoesMovimentoFiscal.GetUltimaNFCeEmitidaPorSerie(Contexto.CONFIGURACAO_SERIE.SerieNFCe, (int)Contexto.CONFIG_NFCe.CfgServico.tpAmb).ToString();
            }
        }

        private void Sangria()
        {
            if (FluxoAberto == null)
            {
                Alert("É necessário abrir o Caixa para fazer Sangria.");
                return;
            }

            new GPDV_SangriaCaixa().ShowDialog(this);
            CarregarValores();
        }

        private void Manutencao()
        {
            if (FluxoAberto == null)
            {
                Alert("É necessário abrir o Caixa para fazer Sangria.");
                return;
            }
            var perfilAcesso = FuncoesPerfilAcesso.GetPerfil(Contexto.USUARIOLOGADO.IDPerfilAcesso);
            if (perfilAcesso.IsAdmin != 1)
            {
                var loginAdmin = new LoginAdmin();
                loginAdmin.ShowDialog();
                if (!loginAdmin.IsLogado)
                    return;
            }

            ManutencaoCaixa manutencaoCaixa = new ManutencaoCaixa(Contexto.USUARIOLOGADO);
            manutencaoCaixa.ShowDialog();
            CarregarValores();

        }

        private void Suprimento()
        {
            if (FluxoAberto == null)
            {
                Alert("É Necessário abrir o Caixa para efetivar um suprimento.");
                return;
            }

            GPDV_SuprimentoCaixa sup = new GPDV_SuprimentoCaixa();
            sup.ShowDialog();
            CarregarValores();
        }

        private void AbrirCaixa()
        {
            FluxoAberto = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
            if (FluxoAberto == null)
                new AberturaCaixa(Contexto.USUARIOLOGADO).ShowDialog(this);
            else
                Alert("O Caixa já está aberto.");
            CarregarValores();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            FecharCaixa();
        }

        private void FecharCaixa()
        {
            try
            {
                GPDV_ConferenciaCaixa frm = new GPDV_ConferenciaCaixa(Contexto.USUARIOLOGADO.IDUsuario);
                frm.ShowDialog();
                if (frm.Fechou)
                {
                    CarregarValores();
                    FechamentoCaixaDiarioTermica RelatorioFluxoCaixa = new FechamentoCaixaDiarioTermica(Contexto.USUARIOLOGADO,
                                                   FluxoAberto == null ? -1 : FluxoAberto.IDFluxoCaixa,
                                                   Contexto.CONFIGURACAO_SERIE.SerieNFCe.ToString(), Contexto.CONFIGURACAO_SERIE.NomeSequenceNFCe.ToString(), cbDetalhado.Checked);

                    Stream STRel = new MemoryStream();
                    RelatorioFluxoCaixa.ExportToPdf(STRel);
                    new FREL_Preview(STRel).ShowDialog(this);
                    FluxoAberto = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.InnerException.Message, NOME_TELA);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void Serie()
        {
            new GPDV_NFCeGeral().ShowDialog(this);
            CarregarValores();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void Sair()
        {
            if (MessageBox.Show(this, "Deseja sair do RootSys ERP?", NOME_TELA, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //FluxoAberto = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                //if (FluxoAberto != null)
                //{
                //    MessageBox.Show(this, "É necessário fechar o caixa antes de Sair.", NOME_TELA);
                //    return;
                //}

                Application.Exit();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.F4):
                    if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return true;
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    Suprimento();
                    break;

                case Keys.F5:
                    FluxoCaixa Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                    VerificaAtualizacao(Fluxo.IDFluxoCaixa);
                    break;
                case Keys.F6:
                    AbrirCaixa();
                    break;
                case Keys.F7:
                    Sangria();
                    break;
                case Keys.F8:
                    FecharCaixa();
                    break;
                case Keys.F9:
                    Serie();
                    break;
                case Keys.F10:
                    Sair();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    PDVControlador.BeginTransaction();

            //    FAT_AtualizarVersao Form = new FAT_AtualizarVersao(DAO.Enum.Modulo.PDV, new VersaoModulo()
            //    {
            //        VersaoAtual = Contexto.VERSAO,
            //        VersaoDisponivel = null,
            //    });
            //    Form.ShowDialog(this);
            //    PDVControlador.Commit();
            //}
            //catch (Exception Ex)
            //{
            //    PDVControlador.Rollback();
            //}
            try
            {
                FluxoCaixa Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                if (Fluxo == null)
                    Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaUltimoFechadoUsuario(Contexto.USUARIOLOGADO.IDUsuario);
                VerificaAtualizacao(Fluxo.IDFluxoCaixa);
            }
            catch (Exception ex)
            {

            }

        }

        private void VerificaAtualizacao(decimal fluxo)
        {

            try
            {
                FechamentoCaixaDiarioTermica RelatorioFluxoCaixa = new FechamentoCaixaDiarioTermica(Contexto.USUARIOLOGADO,
                        fluxo, Contexto.CONFIGURACAO_SERIE.SerieNFCe.ToString(), Contexto.CONFIGURACAO_SERIE.NomeSequenceNFCe.ToString(), cbDetalhado.Checked);

                Stream STRel = new MemoryStream();
                RelatorioFluxoCaixa.ExportToPdf(STRel);
                new FREL_Preview(STRel).ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.InnerException.ToString(), NOME_TELA);
            }
            //try
            //{
            //    VersaoModulo _Versao = ZeusUtil.VerificarVersaoDisponivel(DAO.Enum.Modulo.PDV, new Version(FileVersionInfo.GetVersionInfo(Path.GetFullPath(".") + "/PDV.VIEW.FRENTECAIXA.exe").ProductVersion));
            //    ovBTN_AtualizarVersao.Enabled = _Versao.Disponivel;
            //}
            //catch (Exception Ex)
            //{
            //    ovBTN_AtualizarVersao.Enabled = false;
            //}
        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {

        }


        public void imprimirReciboTEF()
        {
            if (TextoReciboTef != null)
            {
                foreach (var item in TextoReciboTef)
                {
                    CompranteTEF rel = new CompranteTEF();
                    rel.Parameters["parameter1"].Value = item;
                    rel.Parameters["parameter1"].Visible = false;
                    using (ReportPrintTool printTool = new ReportPrintTool(rel))
                    {
                        rel.ShowPrintMarginsWarning = false;
                        printTool.Print();
                    }
                }
            }

        }
        private void estornoCartãoMetroButton_Click(object sender, EventArgs e)
        {
            TEFPagamento tef = new TEFPagamento(0, null, true);
            tef.ShowDialog();
            //Imprimir Texto Recibo Carncalmento
            if (tef.TextoRecibo != null)
            {
                TextoReciboTef = tef.TextoRecibo;
                imprimirReciboTEF();
            }

        }


        private void metroButton8_Click(object sender, EventArgs e)
        {

        }

        private void statusSefazLabel1_Click(object sender, EventArgs e)
        {

            ConsultarStatus();
        }

        private void suprimentoDeCaixaSimpleButton_Click(object sender, EventArgs e)
        {
            Suprimento();
        }

        private void sangriaSimpleButton_Click(object sender, EventArgs e)
        {
            Sangria();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Contexto.USUARIOLOGADO.IDUsuario);

            if (fluxo == null)
            {
                Alert("É necessário abrir o caixa para imprimir o fluxo.");
                return;
            }
            if (textBox1.Text != "")
                VerificaAtualizacao(int.Parse(textBox1.Text));
            else
                VerificaAtualizacao(fluxo.IDFluxoCaixa - 1);


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Serie();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            TEFPagamento tef = new TEFPagamento(0, null, true);
            tef.ShowDialog();
            //Imprimir Texto Recibo Carncalmento
            if (tef.TextoRecibo != null)
            {
                TextoReciboTef = tef.TextoRecibo;
                imprimirReciboTEF();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            GPDV_CarregarVendaMFe gPDV_CarregarVendaMFe = new GPDV_CarregarVendaMFe();
            gPDV_CarregarVendaMFe.ShowDialog();
        }

        #region chart
        public void chartProdutosMaisVendidos()
        {
            var duplicatasAgrupadas = FluxoCalculos.GetDuplicatasAgrupadas();
            if (duplicatasAgrupadas.Count > 0)
            {
                //ChartControl
                produtosMaisChartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
                produtosMaisChartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                produtosMaisChartControl.AutoLayout = true;
                produtosMaisChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                ChartTitle chartTitle = new ChartTitle();
                chartTitle.Text = "Vendas Por Pagamento";
                chartTitle.Font = new System.Drawing.Font("Tahoma", 8F);
                chartTitle.Alignment = StringAlignment.Center;
                produtosMaisChartControl.Titles.Add(chartTitle);
                //Series
                Series series = new Series("Legenda", ViewType.Doughnut);
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                series.Label.TextPattern = "{A} :{V:c2}";
                series.LegendTextPattern = "{A} : {V:c2}";

                series.DataSource = duplicatasAgrupadas;
                series.ArgumentDataMember = "Key";
                series.ValueDataMembers.AddRange(new string[] { "Value" });

                series.ValueScaleType = ScaleType.Numerical;
                series.ToolTipSeriesPattern = "{c2}";
                produtosMaisChartControl.Series.Add(series);
            }
        }

        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FecharCaixa();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            GPDV_EncerramentoCaixa gPDV_EncerramentoCaixa = new GPDV_EncerramentoCaixa(FLUXO.IDFluxoCaixa);
            gPDV_EncerramentoCaixa.ShowDialog();
        }


        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ovTXT_Usuario_Click(object sender, EventArgs e)
        {

        }

        private void GPDV_MenuConfiguracoes_Load(object sender, EventArgs e)
        {

        }

        private void btnManutencao_Click(object sender, EventArgs e)
        {
            Manutencao();
        }
    }
}
