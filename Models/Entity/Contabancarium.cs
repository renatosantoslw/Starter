using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contabancarium
    {
        public Contabancarium()
        {
            Baixapagamentos = new HashSet<Baixapagamento>();
            Baixarecebimentos = new HashSet<Baixarecebimento>();
            Contacobrancas = new HashSet<Contacobranca>();
            Contapagars = new HashSet<Contapagar>();
            Movimentobancarios = new HashSet<Movimentobancario>();
            Talonarios = new HashSet<Talonario>();
        }

        public int Idcontabancaria { get; set; }
        public int? Idbanco { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public decimal? Ativo { get; set; }
        public decimal? Caixa { get; set; }
        public decimal? Digitoagencia { get; set; }
        public string Operacao { get; set; }
        public string Chaveerp { get; set; }

        public virtual Banco IdbancoNavigation { get; set; }
        public virtual ICollection<Baixapagamento> Baixapagamentos { get; set; }
        public virtual ICollection<Baixarecebimento> Baixarecebimentos { get; set; }
        public virtual ICollection<Contacobranca> Contacobrancas { get; set; }
        public virtual ICollection<Contapagar> Contapagars { get; set; }
        public virtual ICollection<Movimentobancario> Movimentobancarios { get; set; }
        public virtual ICollection<Talonario> Talonarios { get; set; }
    }
}
