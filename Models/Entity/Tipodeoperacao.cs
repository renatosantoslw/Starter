using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Tipodeoperacao
    {
        public int? Idtipodeoperacao { get; set; }
        public int? Idoperacaofiscal { get; set; }
        public int? Idfinalidade { get; set; }
        public int? Idtipoatendimento { get; set; }
        public int? Idtransportadora { get; set; }
        public int? Tipodefrete { get; set; }
        public int? Modelodocumento { get; set; }
        public string Nome { get; set; }
        public bool? Controlarestoque { get; set; }
        public bool? Permiteestoquenegativo { get; set; }
        public bool? Limitecredito { get; set; }
        public string Informacoescomplementares { get; set; }
        public int? Serie { get; set; }
        public int? Tipodemovimento { get; set; }
        public bool? Gerarfinanceiro { get; set; }
        public int? Idcentrocusto { get; set; }
        public int? Idhistoricofinanceiro { get; set; }
        public int? Idcontabancaria { get; set; }
        public int? Tipodemovimento123 { get; set; }
    }
}
