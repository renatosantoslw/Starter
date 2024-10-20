namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parcela")]
    public partial class Parcela
    {
        public int ID { get; set; }

        public int? NotaID { get; set; }

        public DateTime? DataVencimento { get; set; }

        public int? QtdParcela { get; set; }

        public decimal? Valor { get; set; }

        public int? VendedorID { get; set; }

        [StringLength(150)]
        public string VendedorNome { get; set; }

        [StringLength(150)]
        public string NomeParcela { get; set; }

        public int? ClienteID { get; set; }

        public bool Importado { get; set; }
    }
}
