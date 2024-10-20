using System;
using System.Collections.Generic;

namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class Venda
    {
        public decimal IDVenda { get; set; }
        public decimal IDComandaUtilizada { get; set; }
        public decimal IDComanda { get; set; }
        public Usuario Usuario { get; set; }

        public decimal IDUsuario { get; set; }
        public decimal IDCliente { get; set; }

        public Cliente Cliente { get; set; }
        public decimal QuantidadeItens { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }

        public List<ItemVenda> Itens { get; set; }

        public MovimentoFiscal MovimentoFiscal { get; set; }

        public int IDRomaneio { get; set; }
        public Venda() { }

    }
}
