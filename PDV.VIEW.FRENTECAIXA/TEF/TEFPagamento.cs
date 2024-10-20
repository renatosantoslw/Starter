using Cappta.Gp.Api.Com;
using Cappta.Gp.Api.Com.Model;
using Cappta.Gp.Api.Com.Sample.Model;
using DevExpress.XtraReports.UI;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.VIEW.FRENTECAIXA.TEF;
using PDV.VIEW.FRENTECAIXA.TEF.Poup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace PDV.VIEW.FRENTECAIXA
{
    public partial class TEFPagamento : Form
    {
        #region Propriedades
        private Emitente _Emitente = null;

        public FormaDePagamento _FormaDePagamento = new FormaDePagamento();

        public bool Aprovado = false;

        public string numeroControle { get; set; }

        public List<String> TextoRecibo { get; set; }

        private const int INTERVALO_MILISEGUNDOS = 500;

        private const int TIPO_VIA_TODAS = 1;

        private const int TIPO_VIA_CLIENTE = 2;

        private const int TIPO_VIA_LOJA = 3;

        private const int CODIGO_PAGAMENTO_NAO_FINALIZADO = 18;

        private bool processandoPagamento;

        private bool sessaoMultiTefEmAndamento;

        private int tipoVia = TIPO_VIA_TODAS;

        private int quantidadeCartoes;

        private ClienteCappta cliente;

        private Dictionary<int, TipoParcelamento> tiposParcelamento;

        private IList<IDetalheLoja> lojas;

        public decimal Valor { get; set; }

        public bool  _Cancelamento { get; set; }

        public TEFPagamento(decimal ValorDigitado, FormaDePagamento formaDePagamento, bool Cancelamento)
        {
            InitializeComponent();
            Valor = ValorDigitado;
           
            _Cancelamento = Cancelamento;
            if(_Cancelamento)
            {
                panelCancelamento.Visible = true;
            }
            else
            {
                _FormaDePagamento = formaDePagamento;
            }
        }
        #endregion

        #region Métodos de Autenticação e Configuração

        private void OnLoadFormularioSample(object sender, EventArgs e)
        {
            try
            {
                
                cliente = new ClienteCappta();
                IniciarControles();
                AutenticarPdv();
                //CarregarOperadorasRecarga();
                //ConfigurarModoIntegracao(true);
                //ListarLojas();
                HabilitarBotoes();
                //Inicializando Pagamento
                int Parcelas = 0;
                if (!_Cancelamento)
                {
                    if (_FormaDePagamento.Codigo == 2 || _FormaDePagamento.Codigo == 4)
                    {
                        new Aplicacao.InputBox("1").Show("", "Informe as Parcelas", out string parcelas);
                        Parcelas = int.Parse(parcelas);
                        //Crédito
                        NumericUpDownValorPagamentoCredito.Value = Valor;
                        if (Parcelas > 1)
                        {
                            RadioButtonPagamentoCreditoSemParcelas.Enabled = false;
                            RadioButtonPagamentoCreditoComParcelas.Enabled = true;
                            NumericUpDownQuantidadeParcelasPagamentoCredito.Value = Parcelas;
                        }
                        else
                        {
                            RadioButtonPagamentoCreditoSemParcelas.Enabled = true;
                            RadioButtonPagamentoCreditoComParcelas.Enabled = false;
                            //NumericUpDownQuantidadeParcelasPagamentoCredito.Value = Parcelas;
                        }
                        OnExecutaPagamentoCreditoClick(sender, e);
                    }
                    else if (_FormaDePagamento.Codigo == 3)
                    {
                        //Débito
                        NumericUpDownValorPagamentoDebito.Value = Valor;
                        OnExecutaPagamentoDebitoClick(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Forma de Pagamento inexistente");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void ImprimirComprante(String Texto)
        {

            CompranteTEF rel = new CompranteTEF();
            rel.Parameters["parameter1"].Value = Texto;
            rel.Parameters["parameter1"].Visible = false;
            using (ReportPrintTool printTool = new ReportPrintTool(rel))
            {
                printTool.Print();
            }
        }

        private void IniciarControles()
        {
            #region Controles Parcelamento

            tiposParcelamento = new Dictionary<int, TipoParcelamento>
            {
                { 0, TipoParcelamento.Administrativo },
                { 1, TipoParcelamento.Loja }
            };

            ComboBoxTipoParcelamentoPagamentoCredito.SelectedIndex = 0;
            ComboBoxTipoInformacaoPinpad.DataSource = Enum.GetValues(typeof(TipoInformacaoPinpad));

            #endregion
            #region Controles Recarga

            ComboBoxProdutosRecarga.Enabled = false;
            NumericUpDownValorRecarga.Enabled = false;
            ExecutarRecarga.Enabled = false;
            NumericUpDownNumeroRecarga.DecimalPlaces = 0;
            NumericUpDownNumeroRecarga.Minimum = 10000000;
            NumericUpDownNumeroRecarga.Maximum = 999999999;
            NumericUpDownDDDRecarga.DecimalPlaces = 0;

            #endregion
        }

        /// <summary>
        /// Utilize este método de autenticação para garantir a sincronização das vendas entre o Tef(Cappta) e o seu Sistema de vendas.
        /// </summary>
        private void AutenticarPdv()
        {
            //_Emitente = FuncoesEmitente.GetEmitente();
            Configuracao config1 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.TEF_CHAVE_AUTENTICACAO);
            if (config1 != null)
            {
                string chaveAutenticacao = Encoding.UTF8.GetString(config1.Valor);//ConfigurationManager.AppSettings["ChaveAutenticacao"];
                if (string.IsNullOrWhiteSpace(chaveAutenticacao)) { InvalidarAutenticacao("Chave de Autenticação inválida"); }


                string cnpj = "34555898000186";//_Emitente.CNPJ; //ConfigurationManager.AppSettings["Cnpj"];
                if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) { InvalidarAutenticacao("CNPJ inválido"); }

                //if (Int32.TryParse(ConfigurationManager.AppSettings["Pdv"], out pdv) == false || pdv == 0)
                if (int.TryParse("6", out int pdv) == false || pdv == 0)
                {
                    InvalidarAutenticacao("PDV inválido");
                }

                int resultadoAutenticacao = cliente.AutenticarPdv(cnpj, pdv, chaveAutenticacao);
                String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
                this.ExibeMensagemAutenticacaoInvalida(resultadoAutenticacao);
            }
            else
            {
                MessageBox.Show("Não é possivel inicializar o TEF pois não está configurado uma chave de configuração nas configuirações do sistema!");
                Close();
            }
        }

        private void ExibeMensagemAutenticacaoInvalida(int resultadoAutenticacao)
        {
            string mensagem = PDV.VIEW.FRENTECAIXA.Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
            //MessageBox.Show(mensagem, "SAMPLE API COM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }
        private void InvalidarAutenticacao(string mensagemErro)
        {
            CriarMensagemErroJanela(string.Format("{0}. Verifique seu valor no arquivo de configuração.", mensagemErro));
            //Environment.Exit(0);

        }

        private void CarregarOperadorasRecarga()
        {
            IDetalhesOperadoras detalhesOperadoras = cliente.ObterOperadoras();

            if (detalhesOperadoras != null)
            {
                if (detalhesOperadoras.Operadoras != null)
                {
                    ComboBoxOperadorasRecarga.Items.AddRange(detalhesOperadoras.Operadoras.ToArray());
                }
            }
        }

        private void ConfigurarModoIntegracao(bool exibirInterface)
        {
            //exibirInterface = false;
            IConfiguracoes configs = new Configuracoes
            {
                ExibirInterface = exibirInterface
            };

            int resultado = cliente.Configurar(configs);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }
        }

        #endregion

        #region Métodos de Pagamento

        private void OnExecutaPagamentoDebitoClick(object sender, EventArgs e)
        {
            if (DeveIniciarMultiCartoes()) { IniciarMultiCartoes(); }

            double valor = (double)NumericUpDownValorPagamentoDebito.Value;

            if (DeveIniciarMultiCartoes()) { IniciarMultiCartoes(); }

            int resultado = cliente.PagamentoDebito(valor);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;

            HabilitarControle(ExecutarCancelarDebito);

            IterarOperacaoTef();



        }

        private void OnExecutaPagamentoCreditoClick(object sender, EventArgs e)
        {
            if (DeveIniciarMultiCartoes()) { IniciarMultiCartoes(); }

            double valor = (double)NumericUpDownValorPagamentoCredito.Value;
            IDetalhesCredito details = new DetalhesCredito
            {
                QuantidadeParcelas = (int)NumericUpDownQuantidadeParcelasPagamentoCredito.Value,
                TipoParcelamento = (int)tiposParcelamento[ComboBoxTipoParcelamentoPagamentoCredito.SelectedIndex],
                TransacaoParcelada = RadioButtonPagamentoCreditoComParcelas.Checked,
            };

            if (DeveIniciarMultiCartoes()) { IniciarMultiCartoes(); }

            int resultado = cliente.PagamentoCredito(valor, details);
            if (resultado != 0)
            { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;
            HabilitarControle(ExecutarCancelarCredito);
            IterarOperacaoTef();


        }

        private void OnExecutaPagamentoCrediarioClick(object sender, EventArgs e)
        {
            double valor = (double)NumericUpDownValorPagamentoCrediario.Value;
            IDetalhesCrediario detalhes = new DetalhesCrediario
            {
                QuantidadeParcelas = (int)NumericUpDownQuantidadeParcelasPagamentoCrediario.Value,
            };

            if (DeveIniciarMultiCartoes()) { IniciarMultiCartoes(); }

            int resultado = cliente.PagamentoCrediario(valor, detalhes);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;
            HabilitarControle(ExecutarCancelarCrediario);
            IterarOperacaoTef();
        }

        private void OnExecutarPagamentoTicketCarClick(object sender, EventArgs e)
        {
            int resultado = 0;
            double valor = (double)NumericUpDownValorPagamentoTicketCar.Value;

            DetalhesPagamentoTicketCarPessoaFisica detalhesTicketCar = new DetalhesPagamentoTicketCarPessoaFisica
            {
                NumeroReciboFiscal = TextBoxDocumentoFiscal.Text,
                NumeroSerialECF = TextBoxNumeroSerial.Text
            };

            resultado = cliente.PagamentoTicketCarPessoaFisica(valor, detalhesTicketCar);

            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;
            IterarOperacaoTef();
        }

        private bool DeveIniciarMultiCartoes()
        {
            return sessaoMultiTefEmAndamento == false && RadioButtonUsarMultiTef.Checked;
        }

        private void IniciarMultiCartoes()
        {
            quantidadeCartoes = (int)NumericUpDownQuantidadeDePagamentosMultiTef.Value;
            sessaoMultiTefEmAndamento = true;
            cliente.IniciarMultiCartoes(quantidadeCartoes);
        }

        private void OnExecutarCancelamentoInivisivelClick(object sender, EventArgs e)
        {
            cliente.AbortarOperacao();
        }

        #endregion

        #region Métodos Administrativos

        private void OnButtonExecutaReimpressaoCupomClick(object sender, EventArgs e)
        {
            if (sessaoMultiTefEmAndamento == true)
            {
                CriarMensagemErroJanela("Não é possível reimprimir um cupom com uma sessão multitef em andamento."); return;
            }

            int resultado = RadioButtonReimprimirUltimoCupom.Checked

              ? cliente.ReimprimirUltimoCupom(tipoVia)
              : cliente.ReimprimirCupom(NumericUpDownNumeroControleReimpressaoCupom.Value.ToString("00000000000"), tipoVia);

            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = false;
            IterarOperacaoTef();
        }

        private void OnButtonExecutaCancelamentoClick(object sender, EventArgs e)
        {
            if (sessaoMultiTefEmAndamento == true)
            {
                CriarMensagemErroJanela("Não é possível cancelar um pagamento com uma sessão multitef em andamento."); return;
            }

            string senhaAdministrativa = TextBoxSenhaAdministrativaCancelamento.Text;

            if (string.IsNullOrEmpty(senhaAdministrativa)) { CriarMensagemErroJanela("A senha administrativa não pode ser vazia."); return; }

            numeroControle = NumericUpDownNumeroControleCancelamento.Value.ToString("00000000000");

            int resultado = cliente.CancelarPagamento(senhaAdministrativa, numeroControle);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = false;
            //WARNING: Não aceita o método abort no cancelamento devido a um bug do scope
            //TODO: Descomentar este trecho quando o bug for fechado
            //this.HabilitarControle(ExecutarCancelarCancelamento);
            IterarOperacaoTef();

          
        }

        private void CriarMensagemErroJanela(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro");
        }

        private void CriarMensagemErroPainel(int resultado)
        {
            string mensagem = PDV.VIEW.FRENTECAIXA.Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultado));
            if (string.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

            AtualizarResultado(string.Format("{0}. Código de erro {1}", mensagem, resultado));
        }

        private string MensagemErro(int resultado)
        {
            string mensagem = PDV.VIEW.FRENTECAIXA.Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultado));
            if (string.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

            return string.Format("{0}. Código de erro {1}", mensagem, resultado);
        }

        #endregion

        #region Método IterarOperacaoTef

        public void IterarOperacaoTef()
        {
            //TaskManagerForm.Start(() =>
            //{
            //    if (RadioButtonUsarMultiTef.Enabled) { DesabilitarControlesMultiTef(); }
            //    DesabilitarBotoes();
            //    IIteracaoTef iteracaoTef = null;
            //    bool Aprovado = false;
            //    do
            //    {
            //        iteracaoTef = cliente.IterarOperacaoTef();
            //        if (iteracaoTef is IMensagem)
            //        {
            //            ExibirMensagem((IMensagem)iteracaoTef);
            //            Thread.Sleep(INTERVALO_MILISEGUNDOS);
            //        }
            //        if (iteracaoTef is IRequisicaoParametro) { RequisitarParametros((IRequisicaoParametro)iteracaoTef); }
            //        if (iteracaoTef is IRespostaTransacaoPendente) { ResolverTransacaoPendente((IRespostaTransacaoPendente)iteracaoTef); }

            //        if (iteracaoTef is IRespostaOperacaoRecusada)
            //        {
            //            ExibirDadosOperacaoRecusada((IRespostaOperacaoRecusada)iteracaoTef);
            //            Delegate @delegate = new Action(Close);
            //            Invoke(@delegate);
            //        }
            //        if (iteracaoTef is IRespostaOperacaoAprovada)
            //        {
            //            numeroControle = ExibirDadosOperacaoAprovada((IRespostaOperacaoAprovada)iteracaoTef);
            //            FinalizarPagamento();
            //            Aprovado = true;
            //        }
            //        if (iteracaoTef is IRespostaRecarga)
            //        {
            //            ExibirDadosDeRecarga((IRespostaRecarga)iteracaoTef);
            //        }
            //    } while (OperacaoNaoFinalizada(iteracaoTef));
            //    if (sessaoMultiTefEmAndamento == false) { HabilitarControlesMultiTef(); }
            //    HabilitarBotoes();
            //    if (Aprovado)
            //    {
            //        TextoRecibo = new List<string>();
            //        String Texto = TextBoxResultado.Text;
            //        TextoRecibo.Add(Texto);
            //        Delegate @delegate = new Action(Close);
            //        Invoke(@delegate);
            //    }
            //});

        }

        private void DesabilitarControlesMultiTef()
        {
            DesabilitarControle(RadioButtonUsarMultiTef);
            DesabilitarControle(RadioButtonNaoUsarMultiTef);
            DesabilitarControle(NumericUpDownQuantidadeDePagamentosMultiTef);
        }

        private void DesabilitarBotoes()
        {
            DesabilitarControle(ExecutarDebito);
            DesabilitarControle(ExecutarCredito);
            DesabilitarControle(ExecutarCrediario);
            DesabilitarControle(ExecutarReimpressao);
            DesabilitarControle(ExecutarCancelamento);
            DesabilitarControle(ExecutarTicketCar);
            DesabilitarControle(ButtonSolicitarInformacaoPinpad);
        }

        private void DesabilitarControle(Control controle)
        {
            TaskManagerForm.InvokeControlAction(controle, (arg) =>
            {
                controle.Enabled = false;
                controle.Update();
            });
        }

        private void ExibirMensagem(IMensagem mensagem)
        {
            AtualizarResultado(mensagem.Descricao);
        }

        private void RequisitarParametros(IRequisicaoParametro requisicaoParametros)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(requisicaoParametros.Mensagem + Environment.NewLine + Environment.NewLine);
            cliente.EnviarParametro(input, string.IsNullOrWhiteSpace(input) ? 2 : 1);
        }

        private void ResolverTransacaoPendente(IRespostaTransacaoPendente transacaoPendente)
        {
            StringBuilder mensagemTransacoesPendentes = new StringBuilder();
            mensagemTransacoesPendentes.AppendLine(transacaoPendente.Mensagem);

            foreach (ITransacaoPendente transacao in transacaoPendente.ListaTransacoesPendentes)
            {
                mensagemTransacoesPendentes.AppendLine($"Número de Controle: {transacao.NumeroControle}");
                mensagemTransacoesPendentes.AppendLine($"Bandeira: {transacao.NomeBandeiraCartao}");
                mensagemTransacoesPendentes.AppendLine($"Adquirente: {transacao.NomeAdquirente}");
                mensagemTransacoesPendentes.AppendLine($"Valor: {transacao.Valor}");
                mensagemTransacoesPendentes.AppendLine($"Data: {transacao.DataHoraAutorizacao}");
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(mensagemTransacoesPendentes.ToString());
            cliente.EnviarParametro(input, string.IsNullOrWhiteSpace(input) ? 2 : 1);
        }

        private void ExibirDadosOperacaoRecusada(IRespostaOperacaoRecusada resposta)
        {
            AtualizarResultado(string.Format("Código: {0}{1}{2}", resposta.CodigoMotivo, Environment.NewLine, resposta.Motivo));
        }

        private string ExibirDadosOperacaoAprovada(IRespostaOperacaoAprovada resposta)
        {
            StringBuilder mensagemAprovada = new StringBuilder();

            if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", string.Empty)).AppendLine().AppendLine(); }
            if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", string.Empty)).AppendLine(); }
            if (resposta.CupomReduzido != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", string.Empty)).AppendLine(); }


            AtualizarResultado(mensagemAprovada.ToString());

            return resposta.NumeroControle;
        }

        private void AtualizarResultado(string mensagem)
        {
            TaskManagerForm.InvokeControlAction<Control>(TextBoxResultado, (arg) =>
            {
                TextBoxResultado.Text = mensagem;
                TextBoxResultado.Update();
            });
        }

        private void FinalizarPagamento()
        {
            if (processandoPagamento == false) { return; }

            if (sessaoMultiTefEmAndamento)
            {
                quantidadeCartoes--;
                if (quantidadeCartoes > 0) { return; }
            };

            string mensagem = GerarMensagemTransacaoAprovada();

            processandoPagamento = false;
            sessaoMultiTefEmAndamento = false;

            Aprovado = true;
            //DialogResult result = MessageBox.Show(mensagem.ToString(), "Sample API COM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (Aprovado) { cliente.ConfirmarPagamentos(); }
            else { cliente.DesfazerPagamentos(); }
        }

        private string GerarMensagemTransacaoAprovada()
        {
            string mensagem = string.Format("Transaç{0} Aprovada{1}!!! {2} Clique em \"OK\" para confirmar a{1} transaç{0} e \"Cancelar\" para desfaze-la{1}.",
                    (sessaoMultiTefEmAndamento ? "ões" : "ão"),
                    (sessaoMultiTefEmAndamento ? "s" : ""),
                    Environment.NewLine);

            return mensagem;
        }

        private bool OperacaoNaoFinalizada(IIteracaoTef iteracaoTef)
        {
            return iteracaoTef.TipoIteracao != 1 && iteracaoTef.TipoIteracao != 2 && iteracaoTef.TipoIteracao != 12;
        }

        private void HabilitarControlesMultiTef()
        {
            HabilitarControle(RadioButtonUsarMultiTef);
            HabilitarControle(RadioButtonNaoUsarMultiTef);
            HabilitarControle(NumericUpDownQuantidadeDePagamentosMultiTef);
        }

        private void HabilitarBotoes()
        {
            HabilitarControle(ExecutarDebito);
            HabilitarControle(ExecutarCredito);
            HabilitarControle(ExecutarCrediario);
            HabilitarControle(ExecutarReimpressao);
            HabilitarControle(ExecutarCancelamento);
            HabilitarControle(ExecutarCancelarDebito);
            HabilitarControle(ExecutarTicketCar);
            HabilitarControle(ButtonSolicitarInformacaoPinpad);

            DesabilitarControle(ExecutarCancelarDebito);
            DesabilitarControle(ExecutarCancelarCrediario);
            DesabilitarControle(ExecutarCancelarCredito);
            //this.DesabilitarControle(ExecutarCancelarCancelamento);
        }

        private void HabilitarControle(Control controle)
        {
            TaskManagerForm.InvokeControlAction(controle, (arg) =>
            {
                controle.Enabled = true;
                controle.Update();
            });
        }

        #endregion

        #region Métodos para obter e ativar lojas

        private void ListarLojas()
        {
            IRespostaLoja consultaLojas = cliente.ObterLojas();

            if (consultaLojas.CodigoResposta != 0) { CriarMensagemErroPainel(consultaLojas.CodigoResposta); return; }

            lojas = consultaLojas.ListaLojas;

            ComboBoxCnpjLojas.Items.Clear();
            foreach (IDetalheLoja loja in lojas)
            {
                string infoLojas = CriarMensagemInformacaoLoja(loja);

                ComboBoxCnpjLojas.Items.Add(infoLojas);
            }
        }

        private string CriarMensagemInformacaoLoja(IDetalheLoja loja)
        {
            return $"{loja.NomeFantasia} CNPJ: {loja.Cnpj} PDV: {loja.Pdv}";
        }

        private void OnButtonAtivarLojaClick(object sender, EventArgs e)
        {
            IDetalheLoja loja = lojas[ComboBoxCnpjLojas.SelectedIndex];

            if (loja == null) { MessageBox.Show("Selecione a loja para ativar"); return; }

            IDetalheLoja detalhes = new DetalheLoja()
            {
                Cnpj = loja.Cnpj,
                Pdv = loja.Pdv
            };

            int resultado = cliente.AtivarLoja(detalhes);
            if (resultado != 0)
            {
                if (resultado == CODIGO_PAGAMENTO_NAO_FINALIZADO)
                {
                    string mensagem = $"{MensagemErro(resultado)}! {Environment.NewLine}Clique em \"OK\" para confirmar a transação e \"Cancelar\" para desfaze-la.";

                    DialogResult finalizacao = MessageBox.Show(mensagem.ToString(), "Sample API COM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (finalizacao == DialogResult.OK) { cliente.ConfirmarPagamentos(); }
                    else { cliente.DesfazerPagamentos(); }

                    //MessageBox.Show("Transação finalizada com sucesso!", "Sample API COM");
                    this.Close();
                    return;
                }
                CriarMensagemErroPainel(resultado);
                return;
            }

            AtualizarResultado("Loja ativada com sucesso");
        }

        #endregion

        #region Eventos

        private void OnRadioButtonUsarMultiTefCheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonUsarMultiTef.Checked == false) { return; }

            LabelQuantidadeDePagamentosMultiTef.Show();
            NumericUpDownQuantidadeDePagamentosMultiTef.Show();
        }

        private void OnRadioButtonNaoUsarMultiTefCheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonNaoUsarMultiTef.Checked == false) { return; }

            sessaoMultiTefEmAndamento = false;
            LabelQuantidadeDePagamentosMultiTef.Hide();
            NumericUpDownQuantidadeDePagamentosMultiTef.Hide();
            cliente.DesfazerPagamentos();
        }

        private void OnNumericUpDownQuantidadeDePagamentosMultiTefValueChanged(object sender, EventArgs e)
        {
            quantidadeCartoes = (int)NumericUpDownQuantidadeDePagamentosMultiTef.Value;
        }

        private void OnRadioButtonPagamentoCreditoComParcelasCheckedChanged(object sender, EventArgs e)
        {
            ComboBoxTipoParcelamentoPagamentoCredito.Show();
            LabelTipoParcelamentoPagamentoCredito.Show();
            NumericUpDownQuantidadeParcelasPagamentoCredito.Show();
            LabelQuantidadeParcelasPagamentoCredito.Show();
        }

        private void OnRadioButtonPagamentoCreditoSemParcelasCheckedChanged(object sender, EventArgs e)
        {
            ComboBoxTipoParcelamentoPagamentoCredito.Hide();
            LabelTipoParcelamentoPagamentoCredito.Hide();
            NumericUpDownQuantidadeParcelasPagamentoCredito.Hide();
            LabelQuantidadeParcelasPagamentoCredito.Hide();
        }

        private void OnRadioButtonReimprimirUltimoCupomCheckedChanged(object sender, EventArgs e)
        {
            LabelNumeroControleReimpressaoCupom.Hide();
            NumericUpDownNumeroControleReimpressaoCupom.Hide();
        }

        private void OnRadioButtonNaoReimprimirUltimoCupomCheckedChanged(object sender, EventArgs e)
        {
            LabelNumeroControleReimpressaoCupom.Show();
            NumericUpDownNumeroControleReimpressaoCupom.Show();
        }

        private void OnRadioButtonReimprimirTodasViasOnCheckedChanged(object sender, EventArgs e)
        {
            tipoVia = TIPO_VIA_TODAS;
        }

        private void OnRadioButtonReimprimirViaLojaCheckedChanged(object sender, EventArgs e)
        {
            tipoVia = TIPO_VIA_LOJA;
        }

        private void OnRadioButtonReimprimirViaClienteCheckedChanged(object sender, EventArgs e)
        {
            tipoVia = TIPO_VIA_CLIENTE;
        }

        private void OnComboBoxOperadorasRecargaSelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxProdutosRecarga.Items.Clear();
            ComboBoxProdutosRecarga.SelectedItem = null;
            ComboBoxProdutosRecarga.Text = "";

            string operadora = (string)ComboBoxOperadorasRecarga.SelectedItem;
            ProdutoRecarga[] produtos = cliente.ObterProdutosOperadoras(operadora).Produtos;
            if (produtos == null)
            {
                ComboBoxProdutosRecarga.Enabled = false;
            }
            else
            {
                ComboBoxProdutosRecarga.Items.AddRange(produtos.ToArray());
            }

            ComboBoxProdutosRecarga.DisplayMember = "Name";
            ComboBoxProdutosRecarga.Enabled = true;

            CheckIfRequestIsValid();
        }

        private void OnComboBoxProdutosRecargaSelectedIndexChanged(object sender, EventArgs e)
        {
            IProdutoRecarga produto = ((IProdutoRecarga)ComboBoxProdutosRecarga.SelectedItem);
            if (produto.IsVariable)
            {
                NumericUpDownValorRecarga.Enabled = true;
                NumericUpDownValorRecarga.Increment = (decimal)produto.Increment;
                NumericUpDownValorRecarga.Minimum = (decimal)produto.MinPrice;
                NumericUpDownValorRecarga.Maximum = (decimal)produto.MaxPrice;
            }
            else
            {
                NumericUpDownValorRecarga.Minimum = (decimal)produto.MinPrice;
                NumericUpDownValorRecarga.Maximum = (decimal)produto.MaxPrice;
                NumericUpDownValorRecarga.Value = (decimal)produto.Price;
            }
            CheckIfRequestIsValid();
        }

        private void CheckIfRequestIsValid()
        {
            if (NumericUpDownDDDRecarga.Value > 0 && NumericUpDownNumeroRecarga.Value > 0 && ComboBoxProdutosRecarga.SelectedItem != null)
            {
                ExecutarRecarga.Enabled = true;
            }
            else
            {
                ExecutarRecarga.Enabled = false;
            }
        }

        private void OnNumericUpDownNumeroRecargaValueChanged(object sender, EventArgs e)
        {
            CheckIfRequestIsValid();
        }

        private void OnNumericUpDownDDDRecargaValueChanged(object sender, EventArgs e)
        {
            CheckIfRequestIsValid();
        }

        private void OnExecutarRecargaClick(object sender, EventArgs e)
        {
            IDetalhesRecarga detalhes = new DetalhesRecarga
            {
                Celular = (int)NumericUpDownNumeroRecarga.Value,
                Ddd = (int)NumericUpDownDDDRecarga.Value,
                Produto = (IProdutoRecarga)ComboBoxProdutosRecarga.SelectedItem,
                ValorRecarga = (double)NumericUpDownValorRecarga.Value
            };

            cliente.RecargaCelular(detalhes);
            IterarOperacaoTef();
        }

        private void ExibirDadosDeRecarga(IRespostaRecarga resposta)
        {
            if (string.IsNullOrEmpty(resposta.CupomCliente)) { }

            StringBuilder mensagemAprovada = new StringBuilder();

            if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomCliente.Replace("\"", string.Empty)).AppendLine().AppendLine(); }
            if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomLojista.Replace("\"", string.Empty)).AppendLine(); }


            AtualizarResultado(mensagemAprovada.ToString());
        }

        private void OnSolicitarInformacaoPinpadClick(object sender, EventArgs e)
        {
            int tipoDeEntrada = (int)ComboBoxTipoInformacaoPinpad.SelectedValue;

            IRequisicaoInformacaoPinpad requisicaoPinpad = new RequisicaoInformacaoPinpad
            {
                TipoInformacaoPinpad = tipoDeEntrada
            };

            string informacaoPinpad = cliente.SolicitarInformacoesPinpad(requisicaoPinpad);
            AtualizarResultado(informacaoPinpad);
        }

        private void OnRadioButtonInterfaceVisivelCheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonInterfaceInvisivel.Checked == false) { return; }

            ConfigurarModoIntegracao(false);
        }

        private void OnRadioButtonInterfaceInvisivelCheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonInterfaceVisivel.Checked == false) { return; }

            ConfigurarModoIntegracao(true);
        }

        private void btnCriarPreAutorizacao_Click(object sender, EventArgs e)
        {
            double valor = (double)CriarPreAutorizacaoValor.Value;

            int resultado = cliente.PreAutorizacaoPagamentoCredito(valor);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;
            IterarOperacaoTef();
        }

        private void btnCapturarPreAutorizacao_Click(object sender, EventArgs e)
        {
            string controle = txtCapturaPreAutorizacaoControle.Text;
            double valor = (double)CapturaPreAutorizacaoValor.Value;

            int resultado = cliente.CapturarPreAutorizacaoPagamentoCredito(controle, valor);
            if (resultado != 0) { CriarMensagemErroPainel(resultado); return; }

            processandoPagamento = true;
            IterarOperacaoTef();
        }



        #endregion

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            ImprimirComprante(TextBoxResultado.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TEFPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}