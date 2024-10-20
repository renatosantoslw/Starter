using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Formadepagamento
    {
        public Formadepagamento()
        {
            Baixapagamentos = new HashSet<Baixapagamento>();
            Baixarecebimentos = new HashSet<Baixarecebimento>();
            Contacobrancas = new HashSet<Contacobranca>();
            Contapagars = new HashSet<Contapagar>();
            Contarecebers = new HashSet<Contareceber>();
            Duplicatanfces = new HashSet<Duplicatanfce>();
            Nves = new HashSet<Nfe>();
            Pedidocompras = new HashSet<Pedidocompra>();
        }

        public int Idformadepagamento { get; set; }
        public int? Idbandeiracartao { get; set; }
        public decimal? Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal? Ativo { get; set; }
        public string Identificacao { get; set; }
        public int? Tef { get; set; }
        public short? Transacao { get; set; }
        public string UsaCalendarioComercial { get; set; }
        public short? QtdParcelas { get; set; }
        public short? DiasIntervalo { get; set; }
        public decimal? FatorDupComEntrada { get; set; }
        public decimal? FatorDupSemEntrada { get; set; }
        public decimal? FatorCheqComEntrada { get; set; }
        public decimal? FatorCheqSemEntrada { get; set; }
        public string Periodicidade { get; set; }
        public int? Pdv { get; set; }

        public virtual Bandeiracartao IdbandeiracartaoNavigation { get; set; }
        public virtual ICollection<Baixapagamento> Baixapagamentos { get; set; }
        public virtual ICollection<Baixarecebimento> Baixarecebimentos { get; set; }
        public virtual ICollection<Contacobranca> Contacobrancas { get; set; }
        public virtual ICollection<Contapagar> Contapagars { get; set; }
        public virtual ICollection<Contareceber> Contarecebers { get; set; }
        public virtual ICollection<Duplicatanfce> Duplicatanfces { get; set; }
        public virtual ICollection<Nfe> Nves { get; set; }
        public virtual ICollection<Pedidocompra> Pedidocompras { get; set; }
    }
}
