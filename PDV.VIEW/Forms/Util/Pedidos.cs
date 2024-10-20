using DevExpress.Office.Utils;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.CONTROLER.Funcoes;
using DevExpress.DataProcessing;
using System;

namespace PDV.VIEW.Forms.Util
{
    public class Pedidos
    {
        public static string GerarPagamentosObservacao(List<FormaPagamentoAux> listPagamentos)
        {
            var pagamentos = listPagamentos.GroupBy(f => f.Pagamento);

            var pgtosStr = "\nPago";

            foreach (var pagamento in pagamentos)
                pgtosStr = GerarDescricaoFormasDePagamento(pgtosStr, pagamento, pagamentos.Count());

            return pgtosStr + ".";           
        }

        private static string GerarDescricaoFormasDePagamento(string pgtosStr, IGrouping<int, FormaPagamentoAux> pagamento, int contagemPagamentos)
        {
            var nome = pagamento.FirstOrDefault().Nome;
            var valor = pagamento.Select(p => p.Valor).FirstOrDefault().ToString("c2");
            var numParcelas = pagamento.Count();

            if (pagamento.Key == 0)
                pgtosStr += $" em {nome} com {numParcelas} parcela(s) de {valor}";
            else if (pagamento.Key == contagemPagamentos - 1)
                pgtosStr += $" e em {nome} com {numParcelas} parcela(s) de {valor}";
            else
                pgtosStr += $", em {nome} com {numParcelas} parcela(s) de {valor}";



            return pgtosStr;
        }

        public static string GerarPagamentosObservacao(List<DuplicataNFCe> listDuplicatas)
        {
            var listPagamentos = new List<FormaPagamentoAux>();

            foreach (var duplicata in listDuplicatas)
            {
                var idFP = duplicata.IDFormaDePagamento;
                var formaPgto = FuncoesFormaDePagamento.GetFormaDePagamento(idFP);

                listPagamentos.Add(new FormaPagamentoAux() { 
                    Nome = formaPgto.Descricao,
                    Pagamento = (int)duplicata.Pagamento,
                    Valor = duplicata.Valor
                });
            }

            return GerarPagamentosObservacao(listPagamentos);
        }

        
        
    }
}