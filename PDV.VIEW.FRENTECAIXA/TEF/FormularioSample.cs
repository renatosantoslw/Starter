using Cappta.Gp.Api.Com.Model;
using Cappta.Gp.Api.Com.Sample.Model;
using PDV.VIEW.FRENTECAIXA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cappta.Gp.Api.Com.Sample
{
	public partial class FormularioSample : Form
	{
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

		public FormularioSample()
		{
			InitializeComponent();
		}

		#region Métodos de Autenticação e Configuração

		private void OnLoadFormularioSample(object sender, EventArgs e)
		{
			this.cliente = new ClienteCappta();
			this.IniciarControles();
			this.AutenticarPdv();
			this.CarregarOperadorasRecarga();
			this.ConfigurarModoIntegracao(true);
			this.ListarLojas();
			this.HabilitarBotoes();
		}

		private void IniciarControles()
		{
			#region Controles Parcelamento

			tiposParcelamento = new Dictionary<int, TipoParcelamento>();
			tiposParcelamento.Add(0, TipoParcelamento.Administrativo);
			tiposParcelamento.Add(1, TipoParcelamento.Loja);

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
			var chaveAutenticacao = ConfigurationManager.AppSettings["ChaveAutenticacao"];
			if (String.IsNullOrWhiteSpace(chaveAutenticacao)) { this.InvalidarAutenticacao("Chave de Autenticação inválida"); }

			var cnpj = ConfigurationManager.AppSettings["Cnpj"];
			if (String.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) { this.InvalidarAutenticacao("CNPJ inválido"); }

			int pdv;
			if (Int32.TryParse(ConfigurationManager.AppSettings["Pdv"], out pdv) == false || pdv == 0)
			{
				this.InvalidarAutenticacao("PDV inválido");
			}

			int resultadoAutenticacao = this.cliente.AutenticarPdv(cnpj, pdv, chaveAutenticacao);
			if (resultadoAutenticacao == 0) { return; }

			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
            //this.ExibeMensagemAutenticacaoInvalida(resultadoAutenticacao);
            MessageBox.Show(mensagem);
            this.Close();
		}

		private void ExibeMensagemAutenticacaoInvalida(int resultadoAutenticacao)
		{
			var mensagem = Mensagens.ResourceManager.GetString(string.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
			MessageBox.Show(mensagem, "SAMPLE API COM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Environment.Exit(0);
		}

		private void InvalidarAutenticacao(string mensagemErro)
		{
			this.CriarMensagemErroJanela(String.Format("{0}. Verifique seu valor no arquivo de configuração.", mensagemErro));
			Environment.Exit(0);
		}

		private void CarregarOperadorasRecarga()
		{
			IDetalhesOperadoras detalhesOperadoras = this.cliente.ObterOperadoras();

			if (detalhesOperadoras != null)
			{
				if (detalhesOperadoras.Operadoras != null)
				{
					this.ComboBoxOperadorasRecarga.Items.AddRange(detalhesOperadoras.Operadoras.ToArray());
				}
			}
		}

		private void ConfigurarModoIntegracao(bool exibirInterface)
		{
			IConfiguracoes configs = new Configuracoes
			{
				ExibirInterface = exibirInterface
			};

			int resultado = cliente.Configurar(configs);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }
		}

		#endregion

		#region Métodos de Pagamento

		private void OnExecutaPagamentoDebitoClick(object sender, EventArgs e)
		{
			if (this.DeveIniciarMultiCartoes()) { this.IniciarMultiCartoes(); }

			double valor = (double)NumericUpDownValorPagamentoDebito.Value;

			if (this.DeveIniciarMultiCartoes()) { this.IniciarMultiCartoes(); }

			int resultado = this.cliente.PagamentoDebito(valor);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.HabilitarControle(ExecutarCancelarDebito);

			this.IterarOperacaoTef();
		}

		private void OnExecutaPagamentoCreditoClick(object sender, EventArgs e)
		{
			if (this.DeveIniciarMultiCartoes()) { this.IniciarMultiCartoes(); }

			double valor = (double)NumericUpDownValorPagamentoCredito.Value;
			IDetalhesCredito details = new DetalhesCredito
			{
				QuantidadeParcelas = (int)this.NumericUpDownQuantidadeParcelasPagamentoCredito.Value,
				TipoParcelamento = (int)this.tiposParcelamento[ComboBoxTipoParcelamentoPagamentoCredito.SelectedIndex],
				TransacaoParcelada = this.RadioButtonPagamentoCreditoComParcelas.Checked,
			};

			if (this.DeveIniciarMultiCartoes()) { this.IniciarMultiCartoes(); }

			int resultado = this.cliente.PagamentoCredito(valor, details);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.HabilitarControle(ExecutarCancelarCredito);
			this.IterarOperacaoTef();
		}

		private void OnExecutaPagamentoCrediarioClick(object sender, EventArgs e)
		{
			double valor = (double)NumericUpDownValorPagamentoCrediario.Value;
			IDetalhesCrediario detalhes = new DetalhesCrediario
			{
				QuantidadeParcelas = (int)NumericUpDownQuantidadeParcelasPagamentoCrediario.Value,
			};

			if (this.DeveIniciarMultiCartoes()) { this.IniciarMultiCartoes(); }

			int resultado = this.cliente.PagamentoCrediario(valor, detalhes);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.HabilitarControle(ExecutarCancelarCrediario);
			this.IterarOperacaoTef();
		}

		private void OnExecutarPagamentoTicketCarClick(object sender, EventArgs e)
		{
			int resultado = 0;
			double valor = (double)NumericUpDownValorPagamentoTicketCar.Value;

			var detalhesTicketCar = new DetalhesPagamentoTicketCarPessoaFisica
			{
				NumeroReciboFiscal = this.TextBoxDocumentoFiscal.Text,
				NumeroSerialECF = this.TextBoxNumeroSerial.Text
			};

			resultado = cliente.PagamentoTicketCarPessoaFisica(valor, detalhesTicketCar);

			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.IterarOperacaoTef();
		}

		private bool DeveIniciarMultiCartoes()
		{
			return this.sessaoMultiTefEmAndamento == false && this.RadioButtonUsarMultiTef.Checked;
		}

		private void IniciarMultiCartoes()
		{
			this.quantidadeCartoes = (int)this.NumericUpDownQuantidadeDePagamentosMultiTef.Value;
			this.sessaoMultiTefEmAndamento = true;
			this.cliente.IniciarMultiCartoes(this.quantidadeCartoes);
		}

		private void OnExecutarCancelamentoInivisivelClick(object sender, EventArgs e)
		{
			this.cliente.AbortarOperacao();
		}

		#endregion

		#region Métodos Administrativos

		private void OnButtonExecutaReimpressaoCupomClick(object sender, EventArgs e)
		{
			if (this.sessaoMultiTefEmAndamento == true)
			{
				this.CriarMensagemErroJanela("Não é possível reimprimir um cupom com uma sessão multitef em andamento."); return;
			}

			int resultado = this.RadioButtonReimprimirUltimoCupom.Checked

			  ? this.cliente.ReimprimirUltimoCupom(this.tipoVia)
			  : this.cliente.ReimprimirCupom(this.NumericUpDownNumeroControleReimpressaoCupom.Value.ToString("00000000000"), this.tipoVia);

			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = false;
			this.IterarOperacaoTef();
		}

		private void OnButtonExecutaCancelamentoClick(object sender, EventArgs e)
		{
			if (this.sessaoMultiTefEmAndamento == true)
			{
				this.CriarMensagemErroJanela("Não é possível cancelar um pagamento com uma sessão multitef em andamento."); return;
			}

			string senhaAdministrativa = TextBoxSenhaAdministrativaCancelamento.Text;

			if (String.IsNullOrEmpty(senhaAdministrativa)) { this.CriarMensagemErroJanela("A senha administrativa não pode ser vazia."); return; }

			string numeroControle = NumericUpDownNumeroControleCancelamento.Value.ToString("00000000000");

			int resultado = this.cliente.CancelarPagamento(senhaAdministrativa, numeroControle);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = false;
			//WARNING: Não aceita o método abort no cancelamento devido a um bug do scope
			//TODO: Descomentar este trecho quando o bug for fechado
			//this.HabilitarControle(ExecutarCancelarCancelamento);
			this.IterarOperacaoTef();
		}

		private void CriarMensagemErroJanela(string mensagem)
		{
			MessageBox.Show(mensagem, "Erro");
		}

		private void CriarMensagemErroPainel(int resultado)
		{
			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultado));
			if (String.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

			this.AtualizarResultado(String.Format("{0}. Código de erro {1}", mensagem, resultado));
		}

		private string MensagemErro(int resultado)
		{
			String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultado));
			if (String.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

			return String.Format("{0}. Código de erro {1}", mensagem, resultado);
		}

		#endregion

		#region Método IterarOperacaoTef

		public void IterarOperacaoTef()
		{
			//TaskManagerForm.Start(() =>
			//{

			//	if (this.RadioButtonUsarMultiTef.Enabled) { this.DesabilitarControlesMultiTef(); }
			//	this.DesabilitarBotoes();
			//	IIteracaoTef iteracaoTef = null;

			//	do
			//	{
			//		iteracaoTef = cliente.IterarOperacaoTef();

			//		if (iteracaoTef is IMensagem)
			//		{
			//			this.ExibirMensagem((IMensagem)iteracaoTef);
			//			Thread.Sleep(INTERVALO_MILISEGUNDOS);
			//		}

			//		if (iteracaoTef is IRequisicaoParametro) { this.RequisitarParametros((IRequisicaoParametro)iteracaoTef); }
			//		if (iteracaoTef is IRespostaTransacaoPendente) { this.ResolverTransacaoPendente((IRespostaTransacaoPendente)iteracaoTef); }

			//		if (iteracaoTef is IRespostaOperacaoRecusada) { this.ExibirDadosOperacaoRecusada((IRespostaOperacaoRecusada)iteracaoTef); }
			//		if (iteracaoTef is IRespostaOperacaoAprovada)
			//		{
			//			this.ExibirDadosOperacaoAprovada((IRespostaOperacaoAprovada)iteracaoTef);
			//			this.FinalizarPagamento();
			//		}

			//		if (iteracaoTef is IRespostaRecarga)
			//		{
			//			this.ExibirDadosDeRecarga((IRespostaRecarga)iteracaoTef);
			//		}

			//	} while (this.OperacaoNaoFinalizada(iteracaoTef));

			//	if (this.sessaoMultiTefEmAndamento == false) { this.HabilitarControlesMultiTef(); }
			//	this.HabilitarBotoes();
			//});
		}

		private void DesabilitarControlesMultiTef()
		{
			this.DesabilitarControle(RadioButtonUsarMultiTef);
			this.DesabilitarControle(RadioButtonNaoUsarMultiTef);
			this.DesabilitarControle(NumericUpDownQuantidadeDePagamentosMultiTef);
		}

		private void DesabilitarBotoes()
		{
			this.DesabilitarControle(ExecutarDebito);
			this.DesabilitarControle(ExecutarCredito);
			this.DesabilitarControle(ExecutarCrediario);
			this.DesabilitarControle(ExecutarReimpressao);
			this.DesabilitarControle(ExecutarCancelamento);
			this.DesabilitarControle(ExecutarTicketCar);
			this.DesabilitarControle(ButtonSolicitarInformacaoPinpad);
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
			this.AtualizarResultado(mensagem.Descricao);
		}

		private void RequisitarParametros(IRequisicaoParametro requisicaoParametros)
		{
			string input = Microsoft.VisualBasic.Interaction.InputBox(requisicaoParametros.Mensagem + Environment.NewLine + Environment.NewLine);
			this.cliente.EnviarParametro(input, String.IsNullOrWhiteSpace(input) ? 2 : 1);
		}

		private void ResolverTransacaoPendente(IRespostaTransacaoPendente transacaoPendente)
		{
			StringBuilder mensagemTransacoesPendentes = new StringBuilder();
			mensagemTransacoesPendentes.AppendLine(transacaoPendente.Mensagem);

			foreach (var transacao in transacaoPendente.ListaTransacoesPendentes)
			{
				mensagemTransacoesPendentes.AppendLine($"Número de Controle: {transacao.NumeroControle}");
				mensagemTransacoesPendentes.AppendLine($"Bandeira: {transacao.NomeBandeiraCartao}");
				mensagemTransacoesPendentes.AppendLine($"Adquirente: {transacao.NomeAdquirente}");
				mensagemTransacoesPendentes.AppendLine($"Valor: {transacao.Valor}");
				mensagemTransacoesPendentes.AppendLine($"Data: {transacao.DataHoraAutorizacao}");
			}

			string input = Microsoft.VisualBasic.Interaction.InputBox(mensagemTransacoesPendentes.ToString());
			this.cliente.EnviarParametro(input, String.IsNullOrWhiteSpace(input) ? 2 : 1);
		}

		private void ExibirDadosOperacaoRecusada(IRespostaOperacaoRecusada resposta)
		{
			this.AtualizarResultado(String.Format("Código: {0}{1}{2}", resposta.CodigoMotivo, Environment.NewLine, resposta.Motivo));
		}

		private void ExibirDadosOperacaoAprovada(IRespostaOperacaoAprovada resposta)
		{
			StringBuilder mensagemAprovada = new StringBuilder();

			if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomCliente.Replace("\"", String.Empty)).AppendLine().AppendLine(); }
			if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomLojista.Replace("\"", String.Empty)).AppendLine(); }
			if (resposta.CupomReduzido != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", String.Empty)).AppendLine(); }


			this.AtualizarResultado(mensagemAprovada.ToString());
		}

		private void AtualizarResultado(String mensagem)
		{
			TaskManagerForm.InvokeControlAction<Control>(this.TextBoxResultado, (arg) =>
			{
				this.TextBoxResultado.Text = mensagem;
				this.TextBoxResultado.Update();
			});
		}

		private void FinalizarPagamento()
		{
			if (this.processandoPagamento == false) { return; }

			if (this.sessaoMultiTefEmAndamento)
			{
				quantidadeCartoes--;
				if (this.quantidadeCartoes > 0) { return; }
			};

			string mensagem = this.GerarMensagemTransacaoAprovada();

			this.processandoPagamento = false;
			this.sessaoMultiTefEmAndamento = false;

			DialogResult result = MessageBox.Show(mensagem.ToString(), "Sample API COM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			if (result == System.Windows.Forms.DialogResult.OK) { this.cliente.ConfirmarPagamentos(); }
			else { this.cliente.DesfazerPagamentos(); }
		}

		private string GerarMensagemTransacaoAprovada()
		{
			string mensagem = String.Format("Transaç{0} Aprovada{1}!!! {2} Clique em \"OK\" para confirmar a{1} transaç{0} e \"Cancelar\" para desfaze-la{1}.",
					(this.sessaoMultiTefEmAndamento ? "ões" : "ão"),
					(this.sessaoMultiTefEmAndamento ? "s" : ""),
					Environment.NewLine);

			return mensagem;
		}

		private bool OperacaoNaoFinalizada(IIteracaoTef iteracaoTef)
		{
			return iteracaoTef.TipoIteracao != 1 && iteracaoTef.TipoIteracao != 2 && iteracaoTef.TipoIteracao != 12;
		}

		private void HabilitarControlesMultiTef()
		{
			this.HabilitarControle(RadioButtonUsarMultiTef);
			this.HabilitarControle(RadioButtonNaoUsarMultiTef);
			this.HabilitarControle(NumericUpDownQuantidadeDePagamentosMultiTef);
		}

		private void HabilitarBotoes()
		{
			this.HabilitarControle(ExecutarDebito);
			this.HabilitarControle(ExecutarCredito);
			this.HabilitarControle(ExecutarCrediario);
			this.HabilitarControle(ExecutarReimpressao);
			this.HabilitarControle(ExecutarCancelamento);
			this.HabilitarControle(ExecutarCancelarDebito);
			this.HabilitarControle(ExecutarTicketCar);
			this.HabilitarControle(ButtonSolicitarInformacaoPinpad);

			this.DesabilitarControle(ExecutarCancelarDebito);
			this.DesabilitarControle(ExecutarCancelarCrediario);
			this.DesabilitarControle(ExecutarCancelarCredito);
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
			var consultaLojas = this.cliente.ObterLojas();

			if (consultaLojas.CodigoResposta != 0) { this.CriarMensagemErroPainel(consultaLojas.CodigoResposta); return; }

			this.lojas = consultaLojas.ListaLojas;

			ComboBoxCnpjLojas.Items.Clear();
			foreach (IDetalheLoja loja in this.lojas)
			{
				var infoLojas = CriarMensagemInformacaoLoja(loja);

				ComboBoxCnpjLojas.Items.Add(infoLojas);
			}
		}

		private string CriarMensagemInformacaoLoja(IDetalheLoja loja)
		{
			return $"{loja.NomeFantasia} CNPJ: {loja.Cnpj} PDV: {loja.Pdv}";
		}

		private void OnButtonAtivarLojaClick(object sender, EventArgs e)
		{
			var loja = this.lojas[ComboBoxCnpjLojas.SelectedIndex];

			if (loja == null) { MessageBox.Show("Selecione a loja para ativar"); return; }

			IDetalheLoja detalhes = new DetalheLoja()
			{
				Cnpj = loja.Cnpj,
				Pdv = loja.Pdv
			};

			var resultado = this.cliente.AtivarLoja(detalhes);
			if (resultado != 0)
			{
				if (resultado == CODIGO_PAGAMENTO_NAO_FINALIZADO)
				{
					string mensagem = $"{this.MensagemErro(resultado)}! {Environment.NewLine}Clique em \"OK\" para confirmar a transação e \"Cancelar\" para desfaze-la.";

					var finalizacao = MessageBox.Show(mensagem.ToString(), "Sample API COM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					if (finalizacao == DialogResult.OK) { this.cliente.ConfirmarPagamentos(); }
					else { this.cliente.DesfazerPagamentos(); }

					MessageBox.Show("Transação finalizada com sucesso!", "Sample API COM");
					return;
				}

				this.CriarMensagemErroPainel(resultado);
				return;
			}

			this.AtualizarResultado("Loja ativada com sucesso");
		}

		#endregion

		#region Eventos

		private void OnRadioButtonUsarMultiTefCheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButtonUsarMultiTef.Checked == false) { return; }

			this.LabelQuantidadeDePagamentosMultiTef.Show();
			this.NumericUpDownQuantidadeDePagamentosMultiTef.Show();
		}

		private void OnRadioButtonNaoUsarMultiTefCheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButtonNaoUsarMultiTef.Checked == false) { return; }

			this.sessaoMultiTefEmAndamento = false;
			this.LabelQuantidadeDePagamentosMultiTef.Hide();
			this.NumericUpDownQuantidadeDePagamentosMultiTef.Hide();
			this.cliente.DesfazerPagamentos();
		}

		private void OnNumericUpDownQuantidadeDePagamentosMultiTefValueChanged(object sender, EventArgs e)
		{
			this.quantidadeCartoes = (int)this.NumericUpDownQuantidadeDePagamentosMultiTef.Value;
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
			this.tipoVia = TIPO_VIA_TODAS;
		}

		private void OnRadioButtonReimprimirViaLojaCheckedChanged(object sender, EventArgs e)
		{
			this.tipoVia = TIPO_VIA_LOJA;
		}

		private void OnRadioButtonReimprimirViaClienteCheckedChanged(object sender, EventArgs e)
		{
			this.tipoVia = TIPO_VIA_CLIENTE;
		}

		private void OnComboBoxOperadorasRecargaSelectedValueChanged(object sender, EventArgs e)
		{
			ComboBoxProdutosRecarga.Items.Clear();
			ComboBoxProdutosRecarga.SelectedItem = null;
			ComboBoxProdutosRecarga.Text = "";

			var operadora = (string)ComboBoxOperadorasRecarga.SelectedItem;
			var produtos = this.cliente.ObterProdutosOperadoras(operadora).Produtos;
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

			this.CheckIfRequestIsValid();
		}

		private void OnComboBoxProdutosRecargaSelectedIndexChanged(object sender, EventArgs e)
		{
			var produto = ((IProdutoRecarga)this.ComboBoxProdutosRecarga.SelectedItem);
			if (produto.IsVariable)
			{
				this.NumericUpDownValorRecarga.Enabled = true;
				this.NumericUpDownValorRecarga.Increment = (decimal)produto.Increment;
				this.NumericUpDownValorRecarga.Minimum = (decimal)produto.MinPrice;
				this.NumericUpDownValorRecarga.Maximum = (decimal)produto.MaxPrice;
			}
			else
			{
				this.NumericUpDownValorRecarga.Minimum = (decimal)produto.MinPrice;
				this.NumericUpDownValorRecarga.Maximum = (decimal)produto.MaxPrice;
				this.NumericUpDownValorRecarga.Value = (decimal)produto.Price;
			}
			this.CheckIfRequestIsValid();
		}

		private void CheckIfRequestIsValid()
		{
			if (this.NumericUpDownDDDRecarga.Value > 0 && this.NumericUpDownNumeroRecarga.Value > 0 && ComboBoxProdutosRecarga.SelectedItem != null)
			{
				this.ExecutarRecarga.Enabled = true;
			}
			else
			{
				this.ExecutarRecarga.Enabled = false;
			}
		}

		private void OnNumericUpDownNumeroRecargaValueChanged(object sender, EventArgs e)
		{
			this.CheckIfRequestIsValid();
		}

		private void OnNumericUpDownDDDRecargaValueChanged(object sender, EventArgs e)
		{
			this.CheckIfRequestIsValid();
		}

		private void OnExecutarRecargaClick(object sender, EventArgs e)
		{
			IDetalhesRecarga detalhes = new DetalhesRecarga
			{
				Celular = (int)this.NumericUpDownNumeroRecarga.Value,
				Ddd = (int)this.NumericUpDownDDDRecarga.Value,
				Produto = (IProdutoRecarga)ComboBoxProdutosRecarga.SelectedItem,
				ValorRecarga = (double)this.NumericUpDownValorRecarga.Value
			};

			this.cliente.RecargaCelular(detalhes);
			this.IterarOperacaoTef();
		}

		private void ExibirDadosDeRecarga(IRespostaRecarga resposta)
		{
			if (string.IsNullOrEmpty(resposta.CupomCliente)) { }

			StringBuilder mensagemAprovada = new StringBuilder();

			if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomCliente.Replace("\"", String.Empty)).AppendLine().AppendLine(); }
			if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomLojista.Replace("\"", String.Empty)).AppendLine(); }


			this.AtualizarResultado(mensagemAprovada.ToString());
		}

		private void OnSolicitarInformacaoPinpadClick(object sender, EventArgs e)
		{
			int tipoDeEntrada = (int)ComboBoxTipoInformacaoPinpad.SelectedValue;

			IRequisicaoInformacaoPinpad requisicaoPinpad = new RequisicaoInformacaoPinpad
			{
				TipoInformacaoPinpad = tipoDeEntrada
			};

			String informacaoPinpad = this.cliente.SolicitarInformacoesPinpad(requisicaoPinpad);
			this.AtualizarResultado(informacaoPinpad);
		}

		private void OnRadioButtonInterfaceVisivelCheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButtonInterfaceInvisivel.Checked == false) { return; }

			this.ConfigurarModoIntegracao(false);
		}

		private void OnRadioButtonInterfaceInvisivelCheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButtonInterfaceVisivel.Checked == false) { return; }

			this.ConfigurarModoIntegracao(true);
		}

		private void btnCriarPreAutorizacao_Click(object sender, EventArgs e)
		{
			double valor = (double)CriarPreAutorizacaoValor.Value;

			int resultado = this.cliente.PreAutorizacaoPagamentoCredito(valor);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.IterarOperacaoTef();
		}

		private void btnCapturarPreAutorizacao_Click(object sender, EventArgs e)
		{
			string controle = txtCapturaPreAutorizacaoControle.Text;
			double valor = (double)CapturaPreAutorizacaoValor.Value;

			int resultado = this.cliente.CapturarPreAutorizacaoPagamentoCredito(controle, valor);
			if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

			this.processandoPagamento = true;
			this.IterarOperacaoTef();
		}


        #endregion

        private void GroupBoxResultadoPagamentoDebito_Enter(object sender, EventArgs e)
        {

        }
    }
}