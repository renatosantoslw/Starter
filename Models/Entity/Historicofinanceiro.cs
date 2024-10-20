using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Historicofinanceiro
    {
        public Historicofinanceiro()
        {
            Baixapagamentos = new HashSet<Baixapagamento>();
            Baixarecebimentos = new HashSet<Baixarecebimento>();
        }

        public int Idhistoricofinanceiro { get; set; }
        public string Descricao { get; set; }
        public int? Tipodemovimento { get; set; }

        public virtual ICollection<Baixapagamento> Baixapagamentos { get; set; }
        public virtual ICollection<Baixarecebimento> Baixarecebimentos { get; set; }
    }
}
