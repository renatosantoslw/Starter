using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contareceber
    {
        public Contareceber()
        {
            Baixarecebimentos = new HashSet<Baixarecebimento>();
            Contareccobrancas = new HashSet<Contareccobranca>();
            Contarecobrancas = new HashSet<Contarecobranca>();
            InverseIdcontareceberrenegociacaoNavigation = new HashSet<Contareceber>();
        }

        public int Idcontareceber { get; set; }
        public int? Idcontabancaria { get; set; }
        public int? Idcentrocusto { get; set; }
        public int? Idcliente { get; set; }
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
        public int? Idcontareceberrenegociacao { get; set; }
        public int? Idmovimentofiscal { get; set; }
        public string Chaveerp { get; set; }
        public int? Idvenda { get; set; }
        public DateTime? Pagamento { get; set; }
        public DateTime? Ultimamodificacao { get; set; }
        public int? Idusuario { get; set; }
        public int? Idordemdeservico { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Contareceber IdcontareceberrenegociacaoNavigation { get; set; }
        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Movimentofiscal IdmovimentofiscalNavigation { get; set; }
        public virtual ICollection<Baixarecebimento> Baixarecebimentos { get; set; }
        public virtual ICollection<Contareccobranca> Contareccobrancas { get; set; }
        public virtual ICollection<Contarecobranca> Contarecobrancas { get; set; }
        public virtual ICollection<Contareceber> InverseIdcontareceberrenegociacaoNavigation { get; set; }
    }
}
