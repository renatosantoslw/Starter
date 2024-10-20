using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contapagar
    {
        public Contapagar()
        {
            Baixapagamentos = new HashSet<Baixapagamento>();
        }

        public int Idcontapagar { get; set; }
        public int? Idcontabancaria { get; set; }
        public int? Idcentrocusto { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idhistoricofinanceiro { get; set; }
        public string Titulo { get; set; }
        public decimal? Parcela { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public string Complmhisfin { get; set; }
        public DateTime? Fluxo { get; set; }
        public decimal? Valor { get; set; }
        public string Origem { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Situacao { get; set; }
        public decimal? Valortotal { get; set; }
        public decimal? Saldo { get; set; }
        public int? Idnfeentrada { get; set; }
        public string Ord { get; set; }
        public int? Idpedidocompra { get; set; }

        public virtual Contabancarium IdcontabancariaNavigation { get; set; }
        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Fornecedor IdfornecedorNavigation { get; set; }
        public virtual Nfeentradum IdnfeentradaNavigation { get; set; }
        public virtual Pedidocompra IdpedidocompraNavigation { get; set; }
        public virtual ICollection<Baixapagamento> Baixapagamentos { get; set; }
    }
}
