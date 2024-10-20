using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Pedidocompra
    {
        public Pedidocompra()
        {
            Contapagars = new HashSet<Contapagar>();
            Itempedidocompras = new HashSet<Itempedidocompra>();
            Nfeentrada = new HashSet<Nfeentradum>();
        }

        public int Idpedidocompra { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idtransportadora { get; set; }
        public int? Idusuariocadastro { get; set; }
        public DateTime? Dataemissao { get; set; }
        public DateTime? Dataentrega { get; set; }
        public decimal? Tipofrete { get; set; }
        public string Observacao { get; set; }
        public DateTime? Dataalteracao { get; set; }
        public DateTime? Datacancelamento { get; set; }
        public decimal? Total { get; set; }
        public decimal? Status { get; set; }
        public int? Idcomprador { get; set; }
        public int? Idtipodeoperacao { get; set; }
        public int? Idfluxocaixa { get; set; }
        public decimal? Quantidadeitens { get; set; }
        public string Motivodecancelamento { get; set; }
        public DateTime? Datafaturamento { get; set; }
        public string Pagamentosdescricao { get; set; }

        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Fornecedor IdfornecedorNavigation { get; set; }
        public virtual Transportadora IdtransportadoraNavigation { get; set; }
        public virtual Usuario IdusuariocadastroNavigation { get; set; }
        public virtual ICollection<Contapagar> Contapagars { get; set; }
        public virtual ICollection<Itempedidocompra> Itempedidocompras { get; set; }
        public virtual ICollection<Nfeentradum> Nfeentrada { get; set; }
    }
}
