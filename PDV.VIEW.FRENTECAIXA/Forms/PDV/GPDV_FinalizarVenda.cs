using DevExpress.XtraReports.UI;
using FastReport.Data;
using NFe.Classes.Informacoes.Pagamento;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesFaturamento;
using PDV.CONTROLER.FuncoesFinanceiro;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.CONTROLLER.NFCE.Transmissao;
using PDV.CONTROLLER.NFCE.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.REPORTS.Reports.PedidoVendaComandaTermica;
using PDV.REPORTS.Reports.PedidoVendaTermica;
using PDV.UTIL;
using PDV.UTIL.Components;
using PDV.VIEW.Forms.Relatorios;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms.PDV;
using PDV.VIEW.FRENTECAIXA.MFe.Emissao;
using PDV.VIEW.FRENTECAIXA.TEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class
        GPDV_FinalizarVenda : Form
    {
        public GPDV_PainelInicial TelaInicial = null;
        public IntegracaoMFE.MFE mfe;
        public List<string> TextoReciboTef { get; set; }
        private string NOME_TELA = "FINALIZAR VENDA";
        private int Fiscal = 0;
        public FormaDePagamento FormaDePagamento;
        private Configuracao Config_NomeImpressora = null;
        private Configuracao Config_ExibirCaixaDialogo = null;
        private ContaReceber Conta = null;
        private decimal idForma;
        private object txtTexto;
        TipoDeOperacao tipoDeOperacao;


        public decimal TotalDesconto
        {
            set => ovTXT_TotalDesconto.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_TotalDesconto.Text);
        }

        public decimal TotalPagamentosVenda
        {
            set => ovTXT_TotalPagamentosVenda.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_TotalPagamentosVenda.Text);
        }

        public decimal SubTotalVenda
        {
            set => ovTXT_SubTotalVenda.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_SubTotalVenda.Text);
        }

        public decimal TrocoVenda
        {
            set => ovTXT_TrocoVenda.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_TrocoVenda.Text);
        }

        public decimal FaltaVenda
        {
            set => ovTXT_FaltaVenda.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_FaltaVenda.Text);
        }

        public decimal ValorPago
        {
            set => ovTXT_ValorPago.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_ValorPago.Text);
        }

        public decimal TotalVenda
        {
            set => ovTXT_TotalVenda.Text = GetValueDecToReais(value);
            get => GetValueReaisToDec(ovTXT_TotalVenda.Text);
        }

        public int QuantidadeParcelas
        {
            set => value.ToString();
            get
            {
                try
                {
                    return Convert.ToInt32(ovTXT_QuantidadeParcelas.Text);
                }
                catch (FormatException)
                {
                    return 0;
                }
            }
        }

        public decimal ValorPagamento
        {
            set => valorFormaPagTextBox.Text = value.ToString("c2");
            get => GetValueReaisToDec(valorFormaPagTextBox.Text);
        }

        public GPDV_FinalizarVenda(GPDV_PainelInicial _TelaInicial, int _Fiscal)
        {
            InitializeComponent();
            TelaInicial = _TelaInicial;
            Fiscal = _Fiscal;
            tipoDeOperacao = new TipoDeOperacao();

            Config_NomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
            Config_ExibirCaixaDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);

            ovTXT_SubTotalVenda.Text = TelaInicial.VENDA.ValorTotal.ToString("n2");
            ovTXT_FaltaVenda.Text = TelaInicial.VENDA.ValorTotal.ToString("n2");
            
            //CarregarComboboxFormaPagamento();
            PreencheCabecalho();

          
        }




        private void AjustaTituloPagamentos()
        {
            int WidthGrid = ovGRD_Pagamentos.Width;
            DataGridViewCellStyle style = new DataGridViewCellStyle
            {
                Font = new Font("Open Sans", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.TopLeft
            };
            ovGRD_Pagamentos.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in ovGRD_Pagamentos.Columns)
            {
                switch (column.Name)
                {
                    case "FormaDePagamento":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.50);
                        column.Width = Convert.ToInt32(WidthGrid * 0.50);
                        column.HeaderText = "Tipo";
                        column.HeaderCell.Style = style;
                        break;
                    case "NumeroParcela":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "Parcela";
                        column.HeaderCell.Style = style;
                        column.Visible = false;
                        break;
                    case "DataVencimento":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Vencimento";
                        column.HeaderCell.Style = style;
                        column.Visible = false;
                        break;
                    case "Valor":
                        column.DisplayIndex = 4;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "Valor";
                        column.HeaderCell.Style = style;
                        break;
                    default:
                        column.Width = 0;
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                case (Keys.Alt | Keys.F4):
                    if (MessageBox.Show(this, "Deseja Voltar?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Close();
                    }

                    break;
                case Keys.F1: // INCLUIR PAGAMENTO
                    IncluirPagamento();
                    break;
                case Keys.F2:    
                    
                    break;
                case Keys.F3: // CANCELAR PAGAMENTO
                    CancelarFormasPagamento();
                    break;
                case Keys.F4: // LIMPAR PAGAMENTOS
                    LimparPagamentos();
                    break;
                case Keys.F5: // FOCA VALOR RECEBIDO 

                  
                    FinalizarVenda();// FINALIZA VENDA
                    break;
                case Keys.F6: //IMPRIMIR RELAÇÃO DE ITENS
                               //ImprimirRelacaoDeItens();
                    break;
                case Keys.F7: //NÃO IDENTIFICAR CLIENTE
                    RemoverCliente();
                    break;
                case Keys.F9: // DESCONTO DOS ITENS;
                    DescontoItens();
                    break;
                case Keys.F8: //DESCONTO VENDA
                    DescontoVenda();
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void ovGRD_Pagamentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Pagamentos.Columns[e.ColumnIndex].Name)
            {
                case "Valor":
                    e.Value = Convert.ToDecimal(e.Value).ToString("c2");
                    break;
                case "DataVencimento":
                    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                    break;
            }
        }
        public string Texto { get; set; }
        private bool ValidaVenda()
        {
            if (TelaInicial.PAGAMENTOS.Count == 0)
                throw new Exception("Informe os pagamentos.");

            decimal TotalPagamentosComDesconto = TelaInicial.PAGAMENTOS.Sum(o => o.Valor) + Convert.ToDecimal(ovTXT_TotalDesconto.Text);
            decimal sValor = decimal.Parse(TelaInicial.VENDA.ValorTotal.ToString("n2"));
            if (sValor != TotalPagamentosComDesconto)
            {

                //throw new Exception("Pagamento está incorreto.");
                //return false;
            }

            if (FuncoesPerfilAcesso.ISEstoqueLiberado())
            {
                ///* Validação do Estoque */
                //foreach (decimal IDProduto in TelaInicial.ITENS_VENDA.Select(o => o.IDProduto))
                //{
                //    decimal QuantidadeVenda = TelaInicial.ITENS_VENDA.Where(o => o.IDProduto == IDProduto).Sum(o => o.Quantidade);
                //    Produto _Produto = FuncoesProduto.GetProduto(IDProduto);
                //    if (_Produto.VenderSemSaldo == 0)
                //    {
                //        DataRow dr = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(_Produto.IDAlmoxarifadoSaida.Value, _Produto.IDProduto);
                //        if (dr == null)
                //        {

                //            throw new Exception($"O Saldo do Item {_Produto.Descricao} não encontrado no almoxarifado de saida. Verifique!");
                //            return false;
                //        }

                //        if (QuantidadeVenda > Convert.ToDecimal(dr["SALDO"]))
                //        {

                //            throw new Exception($"O Saldo do Item {_Produto.Descricao} é menor que a quantidade de venda. Saldo: {QuantidadeVenda.ToString("n4")}.");
                //            return false;
                //        }
                //    }
                //}
            }
            return true;
        }
        public void SalvarVenda()
        {
            try
            {

                ValidarRecebimentos();
                aguardePictureBox.Visible = true;
                CONTROLER.Funcoes.FuncoesComanda.AtualizaStatusComanda(TelaInicial.VENDA.IDComanda, "Null");
                TelaInicial.VENDA.IDCliente = null;
                if (TelaInicial.Cliente != null)
                {
                    TelaInicial.VENDA.IDCliente = TelaInicial.Cliente.IDCliente;
                    if (!FuncoesCliente.SalvarAtualizarClienteNFCe(TelaInicial.Cliente.Nome, TelaInicial.Cliente.IDCliente, TelaInicial.Cliente.Email, TelaInicial.Cliente._CPF_CNPJ, TelaInicial.Cliente.TipoDocumento))
                    {
                        throw new Exception("Não foi possível salvar o Cliente.");
                    }

                }
                //Tipo de Operação 
                Configuracao config3 = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.TIPO_OPERACAO_PADRAO_PDV);
                if (config3 != null)
                {
                    var idtipo = Encoding.UTF8.GetString(config3.Valor);
                    tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(decimal.Parse(idtipo.Replace(',', '.'), CultureInfo.InvariantCulture));
                    //virgula ponto decimal FFFFF
                    if (tipoDeOperacao == null)
                    {
                        throw new Exception("Tipo de operação padrão do PDV não foi definido nas configurações da venda. Defina um tipo de operação para vendas no PDV no retaguarda.");
                    }
                }
                else
                {
                    throw new Exception("Tipo de operação padrão do PDV não foi definido nas configurações da venda. Defina um tipo de operação para vendas no PDV.");
                }

                TelaInicial.VENDA.IDTipoDeOperacao = tipoDeOperacao.IDTipoDeOperacao;
                TelaInicial.VENDA.IDComanda = null;
                TelaInicial.VENDA.IDComandaUtilizada = null;
                TelaInicial.VENDA.Status = StatusPedido.Aberto;
                if (TelaInicial.Comanda != null)
                {
                    TelaInicial.VENDA.IDComanda = null;
                    TelaInicial.VENDA.IDComandaUtilizada = TelaInicial.Comanda.IDComanda;
                }

                foreach (var pagamento in TelaInicial.PAGAMENTOS)
                {
                    var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(pagamento.IDFormaDePagamento);


               

                    if (formaDePagamento.FISCAL == 1)
                    {
                        Fiscal = 2;
                    }




                    if (formaDePagamento.Codigo == FormaDePagamento.CodigoDinheiro)
                        TelaInicial.VENDA.Dinheiro += pagamento.Valor;


                                                                          





                }

                TelaInicial.VENDA.Troco = TrocoVenda;
                TelaInicial.VENDA.TipoDeVenda = 1;

                
                
                TelaInicial.PAGAMENTOS[0].Pagamento = 4;

               /* if (FormaDePagamento.Descricao.Contains("CART"))
                {
                    Fiscal = 2;
                }
                else
                {
                    Fiscal = 1;
                }*/






               /* if(Fiscal == 2)
                {               
                     if (MessageBox.Show("Deseja emitir NFC-e?", "Rootsys", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                     {
                         Fiscal = 2;
                     }
                     else
                     {
                         Fiscal = 1;
                     }
                }*/



                //Enviar Documentos Fiscais
                if (Fiscal == 2)
                {
         
                    
                        EmitirNFCE();
           
                 
                }



                else if (Fiscal == 3)
                {
                    EmitirMFe emitirMFe = new EmitirMFe();
                    System.Threading.Tasks.Task.Run(() => emitirMFe.TransmitirMFe(TelaInicial));
                    GPDV_ProgressoMFe gPDV_ProgressoMFe = new GPDV_ProgressoMFe();
                    gPDV_ProgressoMFe.ShowDialog();
                    if (gPDV_ProgressoMFe.Sucesso)
                    {
                        SalvarVendaPDV();
                        TelaInicial.IniciaNovaVenda();
                        Close();
                    }
                    
                }
                else if (Fiscal == 1)
                {
                    SalvarVendaPDV();
                    EmitirCupomGerencial();
                }
                else
                {
                    Alert("Não existe tipo de venda configurada para esse PDV");
                }
                aguardePictureBox.Visible = false;
            }
            catch (Exception Ex)
            {
                Alert(Ex.Message);
                aguardePictureBox.Visible = false;

                return;
            }
        }

        private void ValidarRecebimentos()
        {
            try
            {
                if (finalizadoraFlowLayoutPanel.Controls.Count == 0)
                {
                    throw new Exception("Informe o valor recebido.");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SalvarVendaPDV()
        {
            try
            {
                PDVControlador.BeginTransaction();
                ValidaVenda();

                TelaInicial.VENDA.PagamentosDescricao = Pedidos.GerarPagamentosObservacao(TelaInicial.PAGAMENTOS);
                TelaInicial.VENDA.ValorTotal = TotalVenda;

                if (!FuncoesVenda.SalvarVenda(TelaInicial.VENDA))
                    throw new Exception("Não foi possível salvar a venda");
                SalvarItensVenda();
                SalvarDuplicatas();
                GerarFaturamento();

                PDVControlador.Commit();
                aguardePictureBox.Visible = false;
            }
            catch (Exception exception)
            {                
                PDVControlador.Rollback();
                throw exception;
            }
        }

        private void GerarFaturamento()
        {
            var vendaFaturamento = new VendaFaturamento(TelaInicial.VENDA, Contexto.USUARIOLOGADO);
            vendaFaturamento.FaturarVenda();
        }

        private void SalvarDuplicatas()
        {
            foreach (var pagamento in TelaInicial.PAGAMENTOS)
                FuncoesItemDuplicataNFCe.SalvarDuplicataNFCe(pagamento);
        }

        private void SalvarItensVenda()
        {
            FuncoesItemVenda.RemoverItensDaVenda(TelaInicial.ITENS_VENDA.ToList(), TelaInicial.VENDA.IDVenda);

            foreach (var itemVenda in TelaInicial.ITENS_VENDA)
                if (!FuncoesItemVenda.SalvarItemVenda(itemVenda))
                    throw new Exception("Não foi possível salvar os itens da venda");
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool MFeCompletado = false;

        private void EmitirMFe_OnCompleted(RetornoMFe retornoMFe)
        {
            try
            {
                MFeCompletado = true;
                if (retornoMFe.Enviado)
                {
                    retornoMFe.CFe.InfCFe.Pagto.VTroco = TelaInicial.VENDA.Troco;
                    SalvarVendaPDV();
                    TelaInicial.IniciaNovaVenda();
                    Close();
                }
                else
                {
                    FuncoesMovimentoFiscal.ExcluirMovimentoFIscal(TelaInicial.VENDA.IDVenda);
                    throw new Exception(retornoMFe.Resposta);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void imprimirReciboTEF()
        {
            if (TextoReciboTef != null)
            {
                foreach (string item in TextoReciboTef)
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
        private void CalculaPagamentos()
        {
            TotalDesconto = GetValorDesconto();
            TotalVenda = TelaInicial.VENDA.ValorTotal - TotalDesconto;
            TotalPagamentosVenda = TelaInicial.PAGAMENTOS.Sum(o => o.Valor);
            SubTotalVenda = TelaInicial.VENDA.ValorTotal;
            
            var diferenca = TotalVenda - TotalPagamentosVenda;
            FaltaVenda = diferenca < 0 ? 0 : diferenca;
            TrocoVenda = diferenca > 0 ? 0 : Math.Abs(diferenca);
        }


        private decimal GetValorDesconto()
        {
            return TelaInicial.ITENS_VENDA.Sum(i => 
            {

                var produto = FuncoesProduto.GetProduto(i.IDProduto);
                var sigla = FuncoesUnidadeMedida.GetUnidadeMedida(produto.IDUnidadeDeMedida).Sigla;
                string[] unidadesDePeso = { "kg", "Kilo", "Kilograma" };
                var IsPeso = unidadesDePeso.Where(u => u.ToLower() == sigla.ToLower()).Count() > 0;
                var quantidade = i.Quantidade; /// (IsPeso ? 1000 : 1);
                var desconto = i.DescontoValor * quantidade;                
                i.Subtotal = quantidade * i.ValorUnitarioItem - desconto;

                return desconto;
            });

         
        }

        public void CancelarFormasPagamento()
        {
            if (ovGRD_Pagamentos.RowCount > 0)
                if (Confirm("Deseja cancelar as formas de pagamento?") == DialogResult.Yes)
                    LimparFormasDePagamento();
        }

        private void LimparFormasDePagamento()
        {
            aguardePictureBox.Visible = false;
            TelaInicial.PAGAMENTOS.Clear();
            ovGRD_Pagamentos.DataSource = TelaInicial.PAGAMENTOS;
            CalculaPagamentos();
            var diferenca = TotalVenda - TotalPagamentosVenda;
            ValorPago = diferenca < 0 ? 0 : diferenca;
            FormaDePagamento = null;
            codFormaPagTextBox.Focus();
            finalizadoraFlowLayoutPanel.Controls.Clear();
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void EmitirCupomGerencial()
        {
            try
            {
                Configuracao Config_NomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_NOMEIMPRESSORA);
                Configuracao Config_ExibirCaixaDialogo = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_EXIBIRCAIXADIALOGO);



                ReciboPedidoVenda _ReciboPedidoVenda = new ReciboPedidoVenda(TelaInicial.VENDA.IDVenda);



                if (Config_ExibirCaixaDialogo != null && "1".Equals(Encoding.UTF8.GetString(Config_ExibirCaixaDialogo.Valor)))
                {

                    if (MessageBox.Show("Deseja imprimir Cupom?", "Rootsys", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(_ReciboPedidoVenda))
                        {
                            printTool.Print();
                        }

                    }


     


                }
                else
                {
                    Stream STRel = new MemoryStream();
                    _ReciboPedidoVenda.ExportToPdf(STRel);
                    new FREL_Preview(STRel).ShowDialog(this);

                }





                TelaInicial.IniciaNovaVenda();
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Não foi possivel imprimir o cupom Detalhes:" + Ex.Message, NOME_TELA);
                TelaInicial.IniciaNovaVenda();
                Close();

            }
        }

        private bool EmitirNFCE()
        {
            try
            {
                var emitente = FuncoesEmitente.GetEmitente();

                EventosNFCe EventoNFCe = new EventosNFCe()
                {
                    VENDA = TelaInicial.VENDA,
                    ITENS_VENDA = TelaInicial.ITENS_VENDA.ToList(),
                    PAGAMENTOS = TelaInicial.PAGAMENTOS,
                    CaminhoSolution = Contexto.CaminhoSolution,
                    IDCLiente = TelaInicial.Cliente == null ? null : (decimal?)TelaInicial.Cliente.IDCliente,
                    IDMovimentoFiscal = Sequence.GetNextID("MOVIMENTOFISCAL", "IDMOVIMENTOFISCAL"),
                    SERIE = Contexto.CONFIGURACAO_SERIE.SerieNFCe,
                    TipoCliente = TelaInicial.Cliente == null ? null : (decimal?)TelaInicial.Cliente.TipoDocumento,
                    VERSAO = "Rootsys" + Contexto.VERSAO,
                    CPF_CNPJ = TelaInicial.Cliente == null ? null : TelaInicial.Cliente._CPF_CNPJ,
                    NOME_CLIENTE = TelaInicial.Cliente == null ? null : TelaInicial.Cliente.Nome,
                    RAZAO = TelaInicial.Cliente == null ? null : TelaInicial.Cliente.RazaoSocial,
                    NUMERO = Convert.ToInt32(emitente.ProximoNumeroNFCe)
                };

               // RetornoTransmissaoNFCe Retorno = EventoNFCe.TransmitirNFCe();

                RetornoTransmissaoNFCe Retorno;

                if (TelaInicial.EmitirContingenciaNFCE)
                {
                    Retorno = EventoNFCe.TransmitirNFCeContingenciaManual();            
                }
                else
                {
                    Retorno = EventoNFCe.TransmitirNFCe();
                }


                

                if (Retorno.isAutorizada)
                {
                    SalvarVendaPDV();
                    emitente.ProximoNumeroNFCe++;
                    FuncoesEmitente.SalvarEmitente(emitente, TipoOperacao.UPDATE);
                }
                else
                {
                    FuncoesMovimentoFiscal.ExcluirMovimentoFIscal(TelaInicial.VENDA.IDVenda);
                }

                if (Retorno.danfe == null)
                {

                    throw new Exception(Retorno.MotivoErro);
                }



                if (Retorno.isVisualizar)
                {
                    Retorno.danfe.Visualizar();
                }
                else
                {

                    if (MessageBox.Show("Deseja imprimir NFC-e?", "Rootsys", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                       
                       // Retorno.danfe.Relatorio.PrintSettings.Copies = 1;
                        Retorno.danfe.Imprimir(Retorno.isCaixaDialogo, Retorno.NomeImpressora);
                     


                        //Retorno.danfe.Visualizar();
                        //  Retorno.danfe.ExportarPdf("C:/Rootsys_/CUPOM.PDF");

                    }
                                     
                
                }
                TelaInicial.IniciaNovaVenda();
                Close();
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Não foi possível emitir a NFC-e, Motivo: " + Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ImprimirRelacaoDeItens();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RemoverCliente();
        }

        private void FinalizarVenda()
        {
            SalvarVenda();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            DescontoItens();
        }

        private void DescontoItens()
        {
            var msg = "Ao aplicar um desconto as formas de pagamento deverão ser reinseridas. Deseja prosseguir?";
            if (TelaInicial.PAGAMENTOS.Count() == 0)
                AbrirTelaDesconto();
            else if (Confirm(msg) == DialogResult.Yes)
                AbrirTelaDesconto();
        }

        private void AbrirTelaDesconto()
        {
            new GPDV_DescontoItem(this).ShowDialog(this);
            CalculaPagamentos();
            LimparFormasDePagamento();
            var diferenca = TotalVenda - TotalPagamentosVenda;
            ValorPago = diferenca < 0 ? 0 : diferenca;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            IncluirPagamento();
        }

        private void IncluirPagamento()
        {
            try
            {
                FormaDePagamento = new FormaDePagamento();
                //Chamar a tela para escolher a forma de pagamento
                // new Aplicacao.InputBox("").Show("", "Infome o codigo da forma de pagamento", out string ID);
                if (string.IsNullOrEmpty(codFormaPagTextBox.Text))
                {
                    codFormaPagTextBox.SelectAll();
                    //codFormaPagTextBox.Focus();
                    Alert("Informe o codigo da forma de pagamento.");
                    return;
                }

                FormaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamentoPDV(decimal.Parse(codFormaPagTextBox.Text));
                //gridLookUpEditFormaPagamento.EditValue = FormaDePagamento.IDFormaDePagamento;

               


                if (FormaDePagamento == null)
                    throw new Exception("Forma de pagamento não encontrada!");
                else
                    valorFormaPagTextBox.Focus();

            }
            catch (Exception ex)
            {
               Alert(ex.Message);
            }

        }



        

        public void ProcessarPagamento()
        {
            try
            {
                ValidarPagamento();

                string NumeroControle = "";
                if (FormaDePagamento != null)
                {
                    if (FormaDePagamento.Descricao.Contains("CARTAO DE CRÉDITO") || FormaDePagamento.Descricao.Contains("CARTAO DE DÉBITO"))
                        if (Fiscal == 3)
                        {
                            EmitirMFe emitirMFe = new EmitirMFe();
                            if (!emitirMFe.VerificarIntegrador())
                            {
                                CancelarFormasPagamento();
                                return;
                            }
                        }
                    //new Aplicacao.InputBox(ovTXT_Diferenca.Text).Show("", "Infome o valor recebido", out string valor);
                    valorFormaPagTextBox.Focus();
                    processarFormaPagamento();
                    ovTXT_ValorPago.Text = valorFormaPagTextBox.Text;
                }
                else
                {
                    return;
                }

                //Verificar se é TEF]
                if (FormaDePagamento.TEF == 1)
                {
                    TEFPagamento tef = new TEFPagamento(ValorPago, FormaDePagamento, false);
                    tef.ShowDialog();
                    if (tef.Aprovado == false)
                    {
                        return;
                    }
                    else
                    {
                        NumeroControle = tef.numeroControle;
                        TextoReciboTef = tef.TextoRecibo;
                    }
                }
                if (ValorPago == 0)
                {
                    ovTXT_ValorPago.Select();
                    return;
                }


                if (TotalVenda - TotalPagamentosVenda <= 0)
                    return;


                if (FormaDePagamento.IsDinheiro)
                    InserirPagamentoAVistaEmDinheiro(NumeroControle);
                else
                    InserirPagamentoAPrazo(NumeroControle);

                if (QuantidadeParcelas > 1)
                {
                    decimal ValorFalta = (ValorPago + TotalPagamentosVenda) - TelaInicial.PAGAMENTOS.AsEnumerable().Sum(o => o.Valor);
                    foreach (DuplicataNFCe Duplicata in TelaInicial.PAGAMENTOS)
                    {
                        Duplicata.Valor += ValorFalta;
                        break;
                    }
                }
                CarregarPagamentos();
                ovGRD_Pagamentos.DataSource = new BindingSource(TelaInicial.PAGAMENTOS, null);
                CalculaPagamentos();
                LimparFormaPagamento();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        private void InserirPagamentoAVistaEmDinheiro(string NumeroControle)
        {
            idForma = FormaDePagamento.IDFormaDePagamento;
            var troco = ValorPagamento - FaltaVenda;
            TelaInicial.PAGAMENTOS.Add(new DuplicataNFCe()
            {
                FormaDePagamento = FormaDePagamento.Identificacao,
                IDFormaDePagamento = FormaDePagamento.IDFormaDePagamento,
                NumeroParcela = 1,
                Valor = ValorPagamento,
                Troco = troco > 0 ? troco : 0,
                IDDuplicataNFCe = Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                IDVenda = TelaInicial.VENDA.IDVenda,
                DataVencimento = DateTime.Today,
                Controle = NumeroControle
            });
        }

        private void InserirPagamentoAPrazo(string NumeroControle)
        {
            var valorParcela = ZeusUtil.Arredondar(Convert.ToDouble(ValorPagamento / QuantidadeParcelas), 2);
            idForma = FormaDePagamento.IDFormaDePagamento;
            for (int i = 0; i < QuantidadeParcelas; i++)
            {
                //var troco = CalcularTrocoPagamento(i);
                TelaInicial.PAGAMENTOS.Add(new DuplicataNFCe()
                {
                    FormaDePagamento = FormaDePagamento.Identificacao,//(ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Descricao,
                    IDFormaDePagamento = FormaDePagamento.IDFormaDePagamento, //(ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento,
                    NumeroParcela = i + 1,
                    Valor = Convert.ToDecimal(valorParcela),
                    IDDuplicataNFCe = Sequence.GetNextID("DUPLICATANFCE", "IDDUPLICATANFCE"),
                    IDVenda = TelaInicial.VENDA.IDVenda,
                    DataVencimento = ovTXT_Vencimento.Value.AddMonths(i),
                    Controle = NumeroControle
                });
            }
        }

        private void ValidarPagamento()
        {
            if (ValorPagamento > FaltaVenda && !FormaDePagamento.IsDinheiro)
                throw new Exception("O valor de formas de pagamento que não sejam em dinheiro não podem ultrapassar o valor que falta");
        }

        private decimal CalcularTrocoPagamento(int itemPgto)
        {
            var vPago = ValorPago;

            if (itemPgto == 0)
            {
                var diferenca = TotalVenda - TotalPagamentosVenda;
                return vPago > diferenca ? vPago - diferenca : 0;
            }
            return 0;
        }

        private void CarregarPagamentos()
        {
            //Adicionando no flower panel 
            finalizadoraFlowLayoutPanel.AutoScroll = true;
            finalizadoraFlowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            finalizadoraFlowLayoutPanel.Controls.Clear();
            finalizadoraFlowLayoutPanel.Update();

            foreach (var item in TelaInicial.PAGAMENTOS)
            {
                var DescricaoItemLabel = new Label();
                var ValorLabel = new Label();
                var flwPanelItems = new FlowLayoutPanel();
                flwPanelItems.Size = new System.Drawing.Size(1500, 50);
                flwPanelItems.BackColor = Color.White;
                flwPanelItems.FlowDirection = FlowDirection.TopDown;
                flwPanelItems.BorderStyle = BorderStyle.FixedSingle;

                String Item = $"{item.FormaDePagamento}";

                //Descrição
                DescricaoItemLabel.Text = Item;
                DescricaoItemLabel.Size = new System.Drawing.Size(300, 50);
                DescricaoItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left)));
                DescricaoItemLabel.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Regular);
                DescricaoItemLabel.TextAlign = ContentAlignment.MiddleLeft;
                DescricaoItemLabel.ForeColor = Color.MidnightBlue;
                //Adicionando ao controle flowPanels Unitários
                flwPanelItems.Controls.Add(DescricaoItemLabel);
                finalizadoraFlowLayoutPanel.Controls.Add(flwPanelItems);


                String Valor = $"{item.Valor.ToString("C")}";

                //vALOR
                ValorLabel.Text = Valor;
                ValorLabel.Size = new System.Drawing.Size(500, 50);
                ValorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right)));
                ValorLabel.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Regular);
                ValorLabel.TextAlign = ContentAlignment.MiddleRight;
                ValorLabel.ForeColor = Color.MidnightBlue;
                //Adicionando ao controle flowPanels Unitários
                flwPanelItems.Controls.Add(DescricaoItemLabel);
                flwPanelItems.Controls.Add(ValorLabel);
                finalizadoraFlowLayoutPanel.Controls.Add(flwPanelItems);
            }
            //Fim
        }

        private void LimparFormaPagamento()
        {
            // ovCMB_FormaPagamento.SelectedItem = null;
            FormaDePagamento = null;
            QuantidadeParcelas = 1;
            var diferenca = TotalVenda - TotalPagamentosVenda;
            ValorPago = diferenca < 0 ? 0 : diferenca;            
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            AbrePagamentos();
        }

        private void AbrePagamentos()
        {
            ovCMB_FormaPagamento.DroppedDown = true;
            ovCMB_FormaPagamento.Select();
        }

        private void ovTXT_QuantidadeParcelas_MouseClick(object sender, MouseEventArgs e)
        {
            ovTXT_QuantidadeParcelas.Select(0, ovTXT_QuantidadeParcelas.Text.Length);
        }

        private void ovTXT_ValorPago_MouseClick(object sender, MouseEventArgs e)
        {
            ovTXT_ValorPago.Select(0, ovTXT_ValorPago.Text.Length);
        }

        private void OvTXT_ValorPago_GotFocus(object sender, EventArgs e)
        {
            ovTXT_ValorPago.Select(0, ovTXT_ValorPago.Text.Length);
        }

        private void OvTXT_QuantidadeParcelas_GotFocus(object sender, EventArgs e)
        {
            ovTXT_QuantidadeParcelas.Select(0, ovTXT_QuantidadeParcelas.Text.Length);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            LimparPagamentos();
        }

        private void LimparPagamentos()
        {
            if (ovGRD_Pagamentos.RowCount > 0)
            {
                if (MessageBox.Show(this, "Deseja Limpar os Pagamento(s)?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TelaInicial.PAGAMENTOS = new List<DuplicataNFCe>();
                    ovGRD_Pagamentos.DataSource = new BindingSource(TelaInicial.PAGAMENTOS, null);
                    CalculaPagamentos();
                    var diferenca = TotalVenda - TotalPagamentosVenda;
                    ValorPago = diferenca < 0 ? 0 : diferenca;
                    // ovCMB_FormaPagamento.SelectedItem = FormasPagamento.AsEnumerable().Where(o => o.Codigo == Convert.ToDecimal(FormaPagamento.fpDinheiro)).FirstOrDefault();
                    FormaDePagamento = null;
                }
            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            CancelarFormasPagamento();
        }
        public void processarFormaPagamento()
        {
            if (FormaDePagamento == null)
            {
                ovTXT_QuantidadeParcelas.Text = "1";
                ovTXT_QuantidadeParcelas.Enabled = false;
            }
            else
            {
                switch ((FormaPagamento)Enum.Parse(typeof(FormaPagamento), FormaDePagamento.Codigo.ToString()))
                {
                    case FormaPagamento.fpCartaoCredito:
                    case FormaPagamento.fpValeAlimentacao:
                    case FormaPagamento.fpValeRefeicao:
                    case FormaPagamento.fpCheque:
                    case FormaPagamento.fpCreditoLoja:
                        ovTXT_Vencimento.Value = DateTime.Now + TimeSpan.FromDays(Convert.ToDouble(FormaDePagamento.Dias_Intervalo));

                        ovTXT_QuantidadeParcelas.Text = "1";
                        break;
                    case FormaPagamento.fpOutro:
                    case FormaPagamento.fpValePresente:
                    case FormaPagamento.fpValeCombustivel:
                        ovTXT_QuantidadeParcelas.Enabled = true;
                        ovTXT_QuantidadeParcelas.Text = "1";
                        ovTXT_Vencimento.Enabled = true;
                        break;
                    default:
                        ovTXT_QuantidadeParcelas.Text = "1";
                        ovTXT_QuantidadeParcelas.Enabled = false;
                        ovTXT_Vencimento.Value = DateTime.Now;
                        ovTXT_Vencimento.Enabled = false;
                        break;
                }
            }
        }
        private void ovCMB_FormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                ovTXT_QuantidadeParcelas.Text = "1";
                ovTXT_QuantidadeParcelas.Enabled = false;
            }
            else
            {
                switch ((FormaPagamento)Enum.Parse(typeof(FormaPagamento), (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).Codigo.ToString()))
                {
                    case FormaPagamento.fpCartaoCredito:
                    case FormaPagamento.fpValeAlimentacao:
                    case FormaPagamento.fpValeRefeicao:
                    case FormaPagamento.fpCheque:
                    case FormaPagamento.fpCreditoLoja:
                        ovTXT_Vencimento.Value = DateTime.Now + TimeSpan.FromDays(Convert.ToDouble(FormaDePagamento.Dias_Intervalo));

                        ovTXT_QuantidadeParcelas.Text = "1";
                        break;
                    case FormaPagamento.fpOutro:
                    case FormaPagamento.fpValePresente:
                    case FormaPagamento.fpValeCombustivel:
                        ovTXT_QuantidadeParcelas.Enabled = true;
                        ovTXT_QuantidadeParcelas.Text = "1";
                        ovTXT_Vencimento.Enabled = true;
                        break;
                    default:
                        ovTXT_QuantidadeParcelas.Text = "1";
                        ovTXT_QuantidadeParcelas.Enabled = false;
                        ovTXT_Vencimento.Value = DateTime.Now;
                        ovTXT_Vencimento.Enabled = false;
                        break;
                }
            }
        }

        private void GPDV_FinalizarVenda_Load(object sender, EventArgs e)
        {
            var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamentoPDV().Select(s => new { Cod = s.Codigo, Nome = s.Identificacao }).OrderBy(x => x.Cod).ToList();
            dgFormaDePagamento.DataSource = formaPagamento;
            dgFormaDePagamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            TelaInicial.PAGAMENTOS = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(TelaInicial.VENDA.IDVenda);
            ovGRD_Pagamentos.DataSource = new BindingSource(TelaInicial.PAGAMENTOS, null);
            AjustaTituloPagamentos();

            ovTXT_ValorPago.Text = TelaInicial.VENDA.ValorTotal.ToString("n2");

            CalculaPagamentos();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DescontoVenda();
        }

        private void DescontoVenda()
        {
            Configuracao CONFIG_DESCONTO = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGURACAOPEDIDOVENDA_DESCONTO_POR);
            if (CONFIG_DESCONTO != null && Encoding.UTF8.GetString(CONFIG_DESCONTO.Valor).Equals("1"))
            {
                new GPDV_InformarDescontoItem(TelaInicial.ITENS_VENDA.Sum(o => o.DescontoValor), null, this).ShowDialog(this);
            }
            else
            {
                new GPDV_InformarDescontoItem((TelaInicial.ITENS_VENDA.Sum(o => o.DescontoValor) / TelaInicial.VENDA.ValorTotal) * 100, null, this).ShowDialog(this);
            }
        }

        public void LancarDesconto(decimal Valor, string TipoDesconto)
        {

            switch (TipoDesconto)
            {
                case "P":
                    // Rateio Por Valor e Quantidade
                    //foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                    //{
                    //    Item.DescontoValor = (Item.ValorTotalItem * (Valor / 100));
                    //    Item.DescontoPorcentagem = (Item.DescontoValor / Item.ValorTotalItem) * 100;
                    //}

                    double ValorDesconto = (double)(TelaInicial.VENDA.ValorTotal * (Valor / 100));
                    double Rateio = ZeusUtil.Arredondar((ValorDesconto / TelaInicial.ITENS_VENDA.Count()), 2);
                    foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                    {
                        Item.DescontoValor = Convert.ToDecimal(Rateio);
                        Item.DescontoPorcentagem = (Item.DescontoValor / Item.Subtotal) * 100;
                    }

                    //Verificando se os descontos estão Ok, (Problema do 6,52/3=2,17333333)!
                    decimal Falta = Convert.ToDecimal(ValorDesconto) - TelaInicial.ITENS_VENDA.Sum(o => o.DescontoValor);
                    if (Falta != 0)
                    {
                        foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                        {
                            if (Falta != 0 && Item.DescontoValor + Falta < Item.Subtotal || (Item.DescontoValor - Falta >= 0))
                            {
                                Item.DescontoValor += Falta;
                                Falta = 0; // Zera o
                            }
                            Item.DescontoPorcentagem = (Item.DescontoValor / Item.Subtotal) * 100;
                        }
                    }

                    break;
                case "V":
                    //Rateio Por Valor e Quantidade
                    /* decimal PercentualRateio = (Valor / TelaInicial.VENDA.ValorTotal) * 100;
                     foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                     {
                         Item.DescontoValor = (Item.ValorTotalItem * (PercentualRateio / 100));
                         Item.DescontoPorcentagem = PercentualRateio;
                     }*/

                    double ValorRateio = ZeusUtil.Arredondar((double)(Valor / TelaInicial.ITENS_VENDA.Count()), 2);
                    foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                    {
                        Item.DescontoValor = Convert.ToDecimal(ValorRateio);
                        Item.DescontoPorcentagem = (Item.DescontoValor / Item.Subtotal) * 100;
                    }

                    //Verificando se os descontos estão Ok, (Problema do 6,52/3=2,17333333)!
                    decimal ValorFalta = Valor - TelaInicial.ITENS_VENDA.Sum(o => o.DescontoValor);
                    if (ValorFalta != 0)
                    {
                        foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
                        {
                            if (ValorFalta != 0 && Item.DescontoValor + ValorFalta < Item.Subtotal || (Item.DescontoValor - ValorFalta >= 0))
                            {
                                Item.DescontoValor += ValorFalta;
                                ValorFalta = 0; // Zera o
                            }
                            Item.DescontoPorcentagem = (Item.DescontoValor / Item.Subtotal) * 100;
                        }
                    }

                    break;
            }

            CalculaPagamentos();
            ovTXT_ValorPago.Text = (Convert.ToDecimal(ovTXT_TotalVenda.Text) - Convert.ToDecimal(ovTXT_TotalPagamentosVenda.Text) < 0 ? 0 : Convert.ToDecimal(ovTXT_TotalVenda.Text) - Convert.ToDecimal(ovTXT_TotalPagamentosVenda.Text)).ToString("n2");
        }

        private void ImprimirRelacaoDeItens()
        {
            ReciboPedidoVendaComanda _ReciboPedidoVendaComanda = new ReciboPedidoVendaComanda(GetDataTableVenda(), GetItensVenda());
            if (Config_ExibirCaixaDialogo != null && "1".Equals(Encoding.UTF8.GetString(Config_ExibirCaixaDialogo.Valor)))
            {
                using (ReportPrintTool printTool = new ReportPrintTool(_ReciboPedidoVendaComanda))
                {
                    if (Config_NomeImpressora != null && !string.IsNullOrEmpty(Encoding.UTF8.GetString(Config_NomeImpressora.Valor)))
                    {
                        printTool.PrinterSettings.PrinterName = Encoding.UTF8.GetString(Config_NomeImpressora.Valor);
                    }

                    printTool.PrintDialog();
                }
            }
            else
            {
                Stream STRel = new MemoryStream();
                _ReciboPedidoVendaComanda.ExportToPdf(STRel);
                new FREL_Preview(STRel).ShowDialog(this);
                //SaveFileDialog SaveFile = new SaveFileDialog();
                //SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
                //SaveFile.Title = "Salvar Relatório de Pedido de Venda Por Comanda";
                //SaveFile.ShowDialog(this);
                //SaveFile.ShowHelp = false;
                //if (string.IsNullOrEmpty(SaveFile.FileName))
                //    return;

                //switch (SaveFile.FilterIndex)
                //{
                //    case 1:
                //        _ReciboPedidoVendaComanda.ExportToRtf(SaveFile.FileName);
                //        break;
                //    case 2:
                //        _ReciboPedidoVendaComanda.ExportToPdf(SaveFile.FileName);
                //        break;
                //    case 3:
                //        _ReciboPedidoVendaComanda.ExportToXls(SaveFile.FileName);
                //        break;
                //    case 4:
                //        _ReciboPedidoVendaComanda.ExportToXlsx(SaveFile.FileName);
                //        break;
                //}
            }
        }

        private DataTable GetItensVenda()
        {
            DataTable dtItensVenda = FuncoesPedidoPorComanda.GetItensPedidoPorComanda(TelaInicial.VENDA.IDVenda);
            dtItensVenda.Clear();

            foreach (ItemVenda Item in TelaInicial.ITENS_VENDA)
            {
                DataRow dr = dtItensVenda.NewRow();
                Produto Prod = FuncoesProduto.GetProduto(Item.IDProduto);

                dr["IDITEMVENDA"] = Item.IDItemVenda;
                dr["CODIGO"] = Prod.Codigo;
                dr["IDPRODUTO"] = Prod.IDProduto;
                if (Item.Descricao != "")
                {
                    dr["PRODUTO"] = Item.Descricao;
                }
                else
                {
                    dr["PRODUTO"] = Prod.Descricao;
                }

                dr["QUANTIDADE"] = string.Format("{0} {1}", Item.Quantidade, FuncoesUnidadeMedida.GetUnidadeMedida(Prod.IDUnidadeDeMedida).Sigla);
                dr["VALORUNITARIOITEM"] = Item.ValorUnitarioItem - Item.DescontoValor;
                dr["VALORTOTAL"] = Item.Quantidade * (Item.ValorUnitarioItem - Item.DescontoValor);
                dr["QTD"] = Item.Quantidade;
                dr["DESCONTOVALOR"] = Item.DescontoValor;
                dtItensVenda.Rows.Add(dr);
            }
            return dtItensVenda;
        }

        private DataTable GetDataTableVenda()
        {
            DataTable dtVenda = FuncoesPedidoPorComanda.GetPedidoPorComanda(TelaInicial.VENDA.IDVenda);
            dtVenda.Clear();

            DataRow dr = dtVenda.NewRow();
            dr["IDVENDA"] = TelaInicial.VENDA.IDVenda;
            dr["QUANTIDADEITENS"] = TelaInicial.VENDA.QuantidadeItens;
            dr["VALORTOTAL"] = TelaInicial.VENDA.ValorTotal;
            dr["DINHEIRO"] = TelaInicial.VENDA.Dinheiro;
            dr["TROCO"] = TelaInicial.VENDA.Troco;
            dr["IDUSUARIO"] = TelaInicial.VENDA.IDUsuario;
            dr["USUARIO"] = FuncoesUsuario.GetUsuario(TelaInicial.VENDA.IDUsuario).Nome;
            dr["IDCLIENTE"] = TelaInicial.Cliente != null ? TelaInicial.Cliente.IDCliente : -1;
            dr["CLIENTE"] = TelaInicial.Cliente != null ? TelaInicial.Cliente._DESCRICAO : "<Não Informado>";
            dr["CPFCNPJ"] = TelaInicial.Cliente != null ? TelaInicial.Cliente._CPF_CNPJ : string.Empty;

            if (TelaInicial.Cliente != null)
            {
                Cliente Cli = FuncoesCliente.GetCliente(TelaInicial.Cliente.IDCliente);
                if (Cli != null && Cli.IDEndereco.HasValue)
                {
                    Endereco End = FuncoesEndereco.GetEndereco(Cli.IDEndereco.Value);

                    dr["TELEFONE"] = End.Telefone;
                    dr["LOGRADOURO"] = string.Format("{0}, {1}, {2}", End.Logradouro, End.Numero, End.Complemento);
                    dr["BAIRRO"] = End.Bairro;
                    if (End.IDMunicipio.HasValue)
                    {
                        Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
                        dr["MUNICIPIO"] = string.Format("{0}-{1}", Mun.Descricao, FuncoesUF.GetUnidadeFederativa(Mun.IDUnidadeFederativa).Sigla);
                    }
                }
            }

            dr["CODIGOCOMANDA"] = TelaInicial.Comanda != null ? TelaInicial.Comanda.Codigo : string.Empty;
            dr["DESCRICAOCOMANDA"] = TelaInicial.Comanda != null ? TelaInicial.Comanda.Descricao : "<Não Informado>";

            dtVenda.Rows.Add(dr);
            return dtVenda;
        }

        private void RemoverCliente()
        {
            if (TelaInicial.Cliente != null)
            {
                if (MessageBox.Show(this, $"Deseja Remover o Cliente CPF/CNPJ: {TelaInicial.Cliente._CPF_CNPJ} da NFCe?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TelaInicial.Cliente = null;
                    TelaInicial.VENDA.IDCliente = null;
                }
                PreencheCabecalho();
                TelaInicial.ovTXT_Cliente.Text = "<CPF/CNPJ Não Informado>";
            }
        }

        private void PreencheCabecalho()
        {
            Emitente _Emitente = FuncoesEmitente.GetEmitente();
            using (var ms = new MemoryStream(_Emitente.logopropraganda))
                pictureBoxPropraganda.Image = Image.FromStream(ms);
                
            ovTXT_Cliente.Text = "<Cliente Não Informado>";
            if (TelaInicial.Cliente != null)
            {
                ovTXT_Cliente.Text = TelaInicial.Cliente._CPF_CNPJ;
            }

            ovTXT_Comanda.Text = "<Comanda Não Informada>";
            if (TelaInicial.Comanda != null)
            {
                ovTXT_Comanda.Text = $"{TelaInicial.Comanda.Codigo} / {TelaInicial.Comanda.Descricao}";
            }
        }

        private void ovTXT_ValorPago_TextChanged(object sender, EventArgs e)
        {
            DecimalMoeda.Moeda(ref ovTXT_ValorPago);
        }

        private void valorFormaPagTextBox_TextChanged(object sender, EventArgs e)
        {
            DecimalMoeda.Moeda(ref valorFormaPagTextBox);
        }

        private void codFormaPagTextBox_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Enter)
            {
                IncluirPagamento();
                valorFormaPagTextBox.Text = FaltaVenda.ToString();
                valorFormaPagTextBox.SelectAll();
            }
        }

        private void valorFormaPagTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessarPagamento();
                codFormaPagTextBox.Focus();
                valorFormaPagTextBox.Text = "";
                codFormaPagTextBox.Text = "";
            }
        }

        private void GPDV_FinalizarVenda_Shown(object sender, EventArgs e)
        {
            codFormaPagTextBox.Focus();
        }

        private async void finalizarButton_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelarFormasPagamento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Close();
            }
        }

        public decimal GetValueReaisToDec(string stringReais)
        {
            try
            {
                return Convert.ToDecimal(stringReais);
            }
            catch (FormatException)
            {
                return 0;
            }
           
        }


      /*  private void CarregarComboboxFormaPagamento()
        {
            var formaPagamento = FuncoesFormaDePagamento.GetFormasPagamento().Select(s => new { Cod = s.IDFormaDePagamento, Nome = s.Identificacao }).OrderBy(x => x.Cod).ToList();
            gridLookUpEditFormaPagamento.Properties.DataSource = formaPagamento;
        }*/


        public string GetValueDecToReais(decimal value) => value.ToString("n2");

        private void gridLookUpEditFormaPagamento_VisibleChanged(object sender, EventArgs e)
        {

        
        }

        private void gridLookUpEditFormaPagamento_EditValueChanged(object sender, EventArgs e)
        {
            //IncluirPagamento2();
          //  valorFormaPagTextBox.Text = FaltaVenda.ToString();
           // valorFormaPagTextBox.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }

        private void btnLimparPagto_Click(object sender, EventArgs e)
        {
            CancelarFormasPagamento();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.SteelBlue, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.SteelBlue, ButtonBorderStyle.Solid);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, "Deseja Voltar?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Close();
            }


        }

       

        private void btnDescontoVenda_Click(object sender, EventArgs e)
        {
            DescontoVenda();
        }

        private void btnDescontoItem_Click(object sender, EventArgs e)
        {
            DescontoItens();
        }

        private void finalizadoraFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.SteelBlue, ButtonBorderStyle.Solid);
        }

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            RemoverCliente();
        }
    }
}
