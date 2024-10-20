namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChequeHistorico")]
    public partial class ChequeHistorico
    {
        public int ID { get; set; }

        public int? IDCheque { get; set; }

        public int? IDDocumento { get; set; }

        public int? IDMovCaixa { get; set; }

        public int? Status { get; set; }

        public DateTime? Data { get; set; }

        [StringLength(8000)]
        public string Observacao { get; set; }

        [StringLength(50)]
        public string Movimento { get; set; }

        [StringLength(50)]
        public string OrigemMovimento { get; set; }

        public int? IDHistorico { get; set; }

        public virtual Cheque Cheque { get; set; }

        public virtual Documento Documento { get; set; }
    }
}
