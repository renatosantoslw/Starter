using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesFinanceiro;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using static PDV.CONTROLER.Funcoes.FuncoesVenda;
using static PDV.DAO.DB.Utils.Sequence;
namespace PDV.CONTROLER.FuncoesFaturamento
{
    public class VendaFaturamento
    {
        private Venda Venda { get; set; }

        private List<ItemVenda> ItensVenda { get; set; }

        private TipoDeOperacao TipoDeOperacao { get; set; }

        private Usuario Usuario { get; set; }

        public VendaFaturamento(Venda venda, Usuario usuario)
        {
            PopularAtributos(venda, usuario);
        }

        public VendaFaturamento( decimal idVenda, Usuario usuario)//decimal
        {
            var venda = GetVenda(idVenda);
            PopularAtributos(venda, usuario);
        }

        private void PopularAtributos(Venda venda, Usuario usuario)
        {
            Venda = venda;
            ItensVenda = FuncoesItemVenda.GetItensVenda(Venda.IDVenda);
            TipoDeOperacao  = FuncoesTipoDeOperacao.GetTipoDeOperacao(Venda.IDTipoDeOperacao);
            Usuario = usuario;
        }

        public void FaturarVenda()
        {
            if (Venda.Status == StatusPedido.Faturado)
                return;                     

            if (TipoDeOperacao.GerarFinanceiro)
                GerarFinanceiro();

            if (TipoDeOperacao.ControlarEstoque)
                GerarEstoque();
            Venda.Status = StatusPedido.Faturado;
            Venda.DataFaturamento = DateTime.Now;
            Venda.MotivoDeCancelamento = string.Empty;

            SalvarVenda("Não foi possível faturar a venda");
        }

        public void CancelarVenda(string motivoCancelamento)
        {
            if (Venda.Status != StatusPedido.Faturado)
                return;           

            if (TipoDeOperacao.GerarFinanceiro)
                CancelarFinanceiro();

            if (TipoDeOperacao.ControlarEstoque)
                CancelarEstoque("Cancelamento de venda");
            Venda.Status = StatusPedido.Cancelado;
            Venda.DataFaturamento = null;
            Venda.MotivoDeCancelamento = motivoCancelamento;
            SalvarVenda("Não foi possível cancelar a venda");
        }        

        public void DesfazerVenda()
        {
            if (Venda.Status != StatusPedido.Faturado)
                return;            

            VerificarDiasDesdeFaturamento();

            var existeNFe = FuncoesNFe.GetNFeFoiGerada(Venda.IDVenda);
            if (existeNFe)
            {
                VerificarStatusNFe();
                ExcluirNFe();
            }
            if (TipoDeOperacao.GerarFinanceiro)
                CancelarFinanceiro();

            if (TipoDeOperacao.ControlarEstoque)
                CancelarEstoque("Ação de desfazer venda");

            RemoverMovimentosEstoque();


            Venda.Status = StatusPedido.Aberto;
            Venda.DataFaturamento = null;
            SalvarVenda("Não foi possível desfazer a venda.");

        }

        private void RemoverMovimentosEstoque()
        {
            foreach (var itemVenda  in ItensVenda)
                FuncoesMovimentoEstoque.ExcluirMovimentoPorItemVenda(itemVenda.IDItemVenda);
        }

        private void ExcluirNFe()
        {
            var nFe = FuncoesNFe.GetNFePorVenda(Venda.IDVenda);
            var produtosNFeDt = FuncoesProdutoNFe.GetProdutos(nFe.IDNFe);


            if (!FuncoesDuplicataNFe.ExcluirPorNFe(nFe.IDNFe))
                throw new Exception($"Não foi possível excluir as Duplicatas da NFe da venda {Venda.IDVenda}");

            for (int i = 0; i < produtosNFeDt.Rows.Count; i++)
            {
                decimal id = Convert.ToDecimal(produtosNFeDt.Rows[i]["idprodutonfe"]);

                if (!FuncoesProdutoNFe.Remover(id))
                    throw new Exception($"Não foi possível excluir os Produtos da NFe da venda {Venda.IDVenda}");
            }

            if (!FuncoesVolume.ExcluirPorNFe(nFe.IDNFe))
                throw new Exception($"Não foi possível excluir os Volumes da NFe da venda {Venda.IDVenda}");

            if (!FuncoesNFe.Excluir(nFe.IDNFe))
                throw new Exception($"Não foi possível excluir a NFe gerada ao desfazer a venda {Venda.IDVenda}.");
        }

        private void VerificarStatusNFe()
        {
            var nFe = FuncoesNFe.GetNFePorVenda(Venda.IDVenda);

            bool existeMovimento = FuncoesMovimentoFiscal.ExistePorNFe(nFe.IDNFe);

            if (existeMovimento)
                throw new Exception($"A venda {Venda.IDVenda} já possui NFe transmitida, portanto não poderá ser desfeita");
        }

        private void GerarEstoque()
        {
            
            foreach (var itemVenda in ItensVenda)
            {
                var produto = FuncoesProduto.GetProduto(itemVenda.IDProduto);
                if (itemVenda.Quantidade > produto.SaldoEstoque && !TipoDeOperacao.PermiteEstoqueNegativo)                
                    throw new Exception(
                        $"Não foi possivel faturar o DAV de número {Venda.IDVenda} pois o tipo de operação " +
                        $"'{TipoDeOperacao.Nome}' está configurado para não permitir estoque negativo." +
                        $"{Environment.NewLine}Produto: '{itemVenda.DescricaoItem}'"
                    );

                var movimentoEstoque = GetMovimentoEstoquePadrao(itemVenda);
                movimentoEstoque.Tipo = MovimentoEstoque.Saida;
                FuncoesMovimentoEstoque.Salvar(movimentoEstoque);
            }
        }
        
        private void CancelarEstoque(string descricao)
        {
            ItensVenda.ForEach(i =>
            {
                var movimentoEstoque = GetMovimentoEstoquePadrao(i);
                movimentoEstoque.Descricao = descricao;
                movimentoEstoque.Tipo = MovimentoEstoque.Entrada;
                ProcessarMovimentoEstoque(movimentoEstoque);
            });
        }

        private MovimentoEstoque GetMovimentoEstoquePadrao(ItemVenda itemVenda)
        {
            var idAlmoxarifadoEntrada = FuncoesProduto.GetProduto(itemVenda.IDProduto).IDAlmoxarifadoEntrada;
            return new MovimentoEstoque
            {
                IDMovimentoEstoque = GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                DataMovimento = DateTime.Now,
                IDAlmoxarifado = idAlmoxarifadoEntrada,
                IDItemVenda = itemVenda.IDItemVenda,
                IDProduto = itemVenda.IDProduto,
                Quantidade = itemVenda.Quantidade,
                IDItemInventario = null,
                IDItemNFeEntrada = null,
                IDItemTransferenciaEstoque = null,
                IDProdutoNFe = null,
                Descricao = TipoDeOperacao.Nome
            };
        }

        private void ProcessarMovimentoEstoque(MovimentoEstoque movimentoEstoque)
        {
            if (!FuncoesMovimentoEstoque.Salvar(movimentoEstoque)) 
                throw new Exception($"Não foi possível salvar o Movimento de Estoque da Venda {Venda.IDVenda}.");
        }

        private void GerarFinanceiro()
        {
            var duplicatasNFCe = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(Venda.IDVenda);

            if (duplicatasNFCe.Count == 0)
                throw new Exception(
                    $"As formas de pagamento da venda {Venda.IDVenda} não foram informadas, " +
                    $"portanto não ela poderá ser faturada!"
                );
            VerificarCreditoDoCliente(duplicatasNFCe);
            InserirContasReceber(duplicatasNFCe);
        }

        private void VerificarCreditoDoCliente(List<DuplicataNFCe> duplicatasNFCe)
        {
            var somaPagamentosAPrazo = duplicatasNFCe.Sum(d =>
            {
                var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(d.IDFormaDePagamento);
                if (formaDePagamento.Transacao == FormaDePagamento.APrazo)
                    return d.Valor;
                return 0;
            });
            if (somaPagamentosAPrazo > 0)
            {
                var idCliente = Venda.IDCliente;
                if (idCliente.HasValue && idCliente > 0)
                {
                    var financeiroCliente = new FinanceiroCliente(idCliente.Value);
                    if (financeiroCliente.ClientePodeCompraAPrazo())
                    {
                        if (financeiroCliente.Cliente.LimiteDeCredito != 0)
                        {
                            var creditoDisponivel = financeiroCliente.CreditoDisponivel();
                            var diferenca = creditoDisponivel - somaPagamentosAPrazo;
                            if (diferenca < 0)
                                throw new Exception($"O total dos pagamentos a prazo informados nesta venda ultrapassam o " +
                                    $"limite de crédito do(a) cliente {financeiroCliente.Cliente._DESCRICAO} " +
                                    $"em {diferenca.ToString("c2").Replace("-", "")}.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Não há crédito disponível para o cliente {financeiroCliente.Cliente._DESCRICAO}.");
                    }
                }
            }            
        }

        private void InserirContasReceber(List<DuplicataNFCe> duplicatasNFCe)
        {
            var pagamentos = duplicatasNFCe.GroupBy(d => d.Pagamento);            
            foreach (var pagamento in pagamentos)
                GerarContasReceberPorPagamento(pagamento);
        }

        private void GerarContasReceberPorPagamento(IGrouping<decimal, DuplicataNFCe> pagamento)
        {
            foreach (var duplicata in pagamento)
                GerarContaReceberPorDuplicata(duplicata);
        }

        private void GerarContaReceberPorDuplicata(DuplicataNFCe duplicata)
        {
            var tipoOperacao = TipoOperacao.INSERT;
            var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(duplicata.IDFormaDePagamento);
            var conta = new ContaReceber
            {
                Parcela = duplicata.NumeroParcela,
                Origem = TipoDeOperacao.Nome.Length > 30 ? TipoDeOperacao.Nome.Substring(0, 30) : TipoDeOperacao.Nome,
                IDUsuario = Usuario.IDUsuario,
                IDFormaDePagamento = formaDePagamento.IDFormaDePagamento,
                Situacao = formaDePagamento.Transacao == FormaDePagamento.AVista ? 3 : 1,
                Saldo = formaDePagamento.Transacao == FormaDePagamento.AVista ? 0 : duplicata.Valor
            };

            conta = PopularContasReceber(conta, duplicata);

            if (!FuncoesContaReceber.Salvar(conta, tipoOperacao))
                throw new Exception($"Não foi possível salvar o lançamento na Venda {Venda.IDVenda}");

            if (formaDePagamento.Transacao == FormaDePagamento.AVista)
                GerarBaixa(conta);
        }

        private void GerarBaixa(ContaReceber conta)
        {
            BaixaRecebimento baixaRecebimento = new BaixaRecebimento()
            {
                IDContaReceber = conta.IDContaReceber,
                IDBaixaRecebimento = GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO"),
                Valor = conta.ValorTotal,
                IDFormaDePagamento = Convert.ToDecimal(conta.IDFormaDePagamento),
                IDHistoricoFinanceiro = TipoDeOperacao.IDHistoricoFinanceiro,
                IDContaBancaria = Convert.ToDecimal(conta.IDContaBancaria),
                Baixa = DateTime.Now,
                IDFluxoCaixa = Venda.IDFluxoCaixa
            };
            if (!FuncoesBaixaRecebimento.Salvar(baixaRecebimento, TipoOperacao.INSERT))
                throw new Exception($"Não foi possível salvar a Baixa na Venda {Venda.IDVenda}.");
        }

        private ContaReceber PopularContasReceber(ContaReceber conta, DuplicataNFCe duplicata)
        {
            conta.IDContaReceber = GetNextID("CONTARECEBER", "IDCONTARECEBER");
            conta.IDVenda = Venda.IDVenda;
            conta.IDContaBancaria = TipoDeOperacao.IDContaBancaria;
            conta.IDCentroCusto = TipoDeOperacao.IdCentroCusto;
            conta.IDHistoricoFinanceiro = TipoDeOperacao.IDHistoricoFinanceiro;
            conta.IDCliente = Venda.IDCliente;
            conta.Titulo = "";
            conta.Emissao = DateTime.Now;
            conta.Vencimento = duplicata.DataVencimento;
            conta.Fluxo = DateTime.Now;
            conta.ComplmHisFin = $"Venda Codigo: {Venda.IDVenda}.";
            conta.Valor = duplicata.Valor;
            conta.Multa = 0;
            conta.Juros = 0;
            conta.Desconto = 0;
            conta.ValorTotal = duplicata.Valor;
            return conta;
        }

        private void CancelarFinanceiro()
        {
            FuncoesContaReceber.CancelarContaReceberDocumento(Venda.IDVenda, Usuario);
        }

        private void VerificarDiasDesdeFaturamento()
        {
            if (DateTime.Today.Day - Venda.DataFaturamento.Value.Date.Day > 3)
                throw new Exception($"A venda {Venda.IDVenda} foi faturada a mais três dias, portando não poderá ser desfeita.");
        }

        private void SalvarVenda(string exceptionMsg)
        {
            if (!FuncoesVenda.SalvarVenda(Venda))
                throw new Exception(exceptionMsg);
        }
    }
}
