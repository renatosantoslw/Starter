using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Movimentofiscalmdfe
    {
        public Movimentofiscalmdfe()
        {
            Eventomdves = new HashSet<Eventomdfe>();
        }

        public int Idmovimentofiscalmdfe { get; set; }
        public int? Idmdfe { get; set; }
        public decimal? Serie { get; set; }
        public byte[] Xmlenvio { get; set; }
        public byte[] Xmlretorno { get; set; }
        public decimal? Emitida { get; set; }
        public decimal? Cancelada { get; set; }
        public DateTime? Dataemissao { get; set; }
        public string Chave { get; set; }
        public decimal? Cstat { get; set; }
        public string Motivo { get; set; }
        public DateTime? Recebimento { get; set; }
        public decimal? Ambiente { get; set; }
        public decimal? Numero { get; set; }
        public decimal? Tipodocumento { get; set; }
        public decimal? Encerrada { get; set; }

        public virtual Mdfe IdmdfeNavigation { get; set; }
        public virtual ICollection<Eventomdfe> Eventomdves { get; set; }
    }
}
