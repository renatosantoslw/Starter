using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System.Linq;

namespace PDV.CONTROLER.FuncoesFinanceiro
{
    public class FinanceiroCliente
    {
        public Cliente Cliente { get; set; }



        public FinanceiroCliente(Cliente cliente)
        {
            Inicializar(cliente);
        }        

        public FinanceiroCliente(decimal idCliente)
        {
            var cliente = FuncoesCliente.GetCliente(idCliente);
            Inicializar(cliente);
        }

        private void Inicializar(Cliente cliente)
        {
            Cliente = cliente;
        }

        public bool ClientePodeCompraAPrazo()
        {
            if (Cliente.LimiteDeCredito == 0)
                return true;
            return CreditoDisponivel() > 0;
        }

        public decimal CreditoDisponivel()
        {
            var contasNaoBaixadas = FuncoesContaReceber.GetContasReceberNaoBaixadasPorCliente(Cliente.IDCliente);
            var somaSaldo = contasNaoBaixadas.Sum(c => c.Saldo);
            return Cliente.LimiteDeCredito - somaSaldo;
        }
    }
}
