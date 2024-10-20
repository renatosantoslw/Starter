using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Chequecontapagar
    {
        public int Idchequecontapagar { get; set; }
        public int? Idtalonario { get; set; }
        public int? Idbaixapagamento { get; set; }
        public decimal? Numero { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? Cruzado { get; set; }
        public decimal? Compensado { get; set; }
        public DateTime? Datacompensacao { get; set; }
        public decimal? Devolvido { get; set; }
        public DateTime? Datadevolucao { get; set; }

        public virtual Baixapagamento IdbaixapagamentoNavigation { get; set; }
        public virtual Talonario IdtalonarioNavigation { get; set; }
    }
}
