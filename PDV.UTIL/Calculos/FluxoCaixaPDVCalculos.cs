using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Linq;
using static PDV.CONTROLER.Funcoes.FuncoesFluxoCaixa;

namespace PDV.UTIL.Calculos
{
    public class FluxoCaixaPDVCalculos
    {
        public object GetTotalSuprimentos;

        public FluxoCaixa FluxoCaixa { get; set; }
        private List<Venda> Vendas { get; set; }

        public decimal TotalSuprimento { get; set; }

        public decimal TotalSangrias { get; set; }

        public FluxoCaixaPDVCalculos(decimal idFluxoCaixa)
        {
            Inicializar(GetFluxoCaixa(idFluxoCaixa));
        }

        public FluxoCaixaPDVCalculos(FluxoCaixa fluxoCaixa)
        {
            Inicializar(fluxoCaixa);
            
        }

        private void Inicializar(FluxoCaixa fluxoCaixa)
        {
            FluxoCaixa = fluxoCaixa;
            Vendas = FuncoesVenda
                .GetVendasPDV(FluxoCaixa.IDFluxoCaixa)
                .Where(v => v.Status != StatusPedido.Cancelado)
                .ToList();
            TotalSuprimento = GetTotalSuprimento(FluxoCaixa.IDFluxoCaixa);
            TotalSangrias = GetTotalSangrias(FluxoCaixa.IDFluxoCaixa);
        }

        public decimal GetDinheiroCaixa()
        {
            var dinheiroVendas = Vendas.Sum(v => v.Dinheiro - v.Troco);
            var totalSuprimento = TotalSuprimento;
            var totalSangrias = TotalSangrias;

            return FluxoCaixa.ValorCaixa + dinheiroVendas + totalSuprimento - totalSangrias;
        }

        public decimal GetTotalVendas()
        {
            return Vendas.Sum(v => v.ValorTotal);
        }

        public Dictionary<string, decimal> GetDuplicatasAgrupadas()
        {
            var duplicatas = new List<DuplicataNFCe>();
            foreach (var venda in Vendas)
                foreach (var duplicata in FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(venda.IDVenda))
                    duplicatas.Add(duplicata);


            var duplicatasAgrupadas = duplicatas.GroupBy(d => d.FormaDePagamento);
            var dictionary = new Dictionary<string, decimal>();
            foreach (var formaDePagamento in duplicatasAgrupadas)
                dictionary.Add(formaDePagamento.Key, formaDePagamento.Sum(d => d.Valor - d.Troco));

            return dictionary;
        }

        public decimal GetValorFechamento()
        {
            var duplicatas = GetDuplicatasAgrupadas().Sum(d => d.Value);
            return duplicatas + FluxoCaixa.ValorCaixa + TotalSuprimento - TotalSangrias;
        }
    }
}
