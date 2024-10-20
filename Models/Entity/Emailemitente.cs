using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Emailemitente
    {
        public int Idemailemitente { get; set; }
        public int? Idemitente { get; set; }
        public decimal? Autorizarenviaremail { get; set; }
        public string Autorizarassunto { get; set; }
        public string Autorizarmensagem { get; set; }
        public decimal? Cancelarenviaremail { get; set; }
        public string Cancelarassunto { get; set; }
        public string Cancelarmensagem { get; set; }

        public virtual Emitente IdemitenteNavigation { get; set; }
    }
}
