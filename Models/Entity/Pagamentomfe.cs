using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Pagamentomfe
    {
        public int? Idpagamentomfe { get; set; }
        public int? Idvenda { get; set; }
        public string Adquirente { get; set; }
        public string Autorizacao { get; set; }
        public string Bandeira { get; set; }
        public string Bincartao { get; set; }
        public string Dataexpiracao { get; set; }
        public string Donocartao { get; set; }
        public string Nsu { get; set; }
        public string Qtdparcelas { get; set; }
        public string Ultimosquatrodigitos { get; set; }
        public string Valorcartao { get; set; }
        public string Mfeenviadodadoscartao { get; set; }
        public int? Idpagamento { get; set; }
        public int? Idlocal { get; set; }
        public DateTime? Datapagamento { get; set; }
    }
}
