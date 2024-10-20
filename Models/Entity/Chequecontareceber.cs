using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Chequecontareceber
    {
        public int Idchequecontareceber { get; set; }
        public int? Idbaixarecebimento { get; set; }
        public decimal? Numero { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public decimal? Cruzado { get; set; }
        public decimal? Compensado { get; set; }
        public DateTime? Datacompensacao { get; set; }
        public decimal? Devolvido { get; set; }
        public DateTime? Datadevolucao { get; set; }
        public decimal? Repasse { get; set; }
        public DateTime? Datarepasse { get; set; }
        public byte[] Obsrepasse { get; set; }

        public virtual Baixarecebimento IdbaixarecebimentoNavigation { get; set; }
    }
}
