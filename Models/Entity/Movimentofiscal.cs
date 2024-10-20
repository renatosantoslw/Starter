using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Movimentofiscal
    {
        public Movimentofiscal()
        {
            Contarecebers = new HashSet<Contareceber>();
            Eventonves = new HashSet<Eventonfe>();
        }

        public int Idmovimentofiscal { get; set; }
        public int? Idnfe { get; set; }
        public int? Idvenda { get; set; }
        public decimal? Serie { get; set; }
        public byte[] Xmlenvio { get; set; }
        public byte[] Xmlretorno { get; set; }
        public decimal? Emitida { get; set; }
        public decimal? Cancelada { get; set; }
        public DateTime? Dataemissao { get; set; }
        public string Chave { get; set; }
        public decimal? Cstat { get; set; }
        public string Xmotivo { get; set; }
        public DateTime? Dhrecbto { get; set; }
        public decimal? Ambiente { get; set; }
        public decimal? Contingencia { get; set; }
        public decimal? Numero { get; set; }
        public decimal? Tipodocumento { get; set; }
        public byte[] Xmlcancelamento { get; set; }
        public string Protocolo { get; set; }

        public virtual Nfe IdnfeNavigation { get; set; }
        public virtual ICollection<Contareceber> Contarecebers { get; set; }
        public virtual ICollection<Eventonfe> Eventonves { get; set; }
    }
}
