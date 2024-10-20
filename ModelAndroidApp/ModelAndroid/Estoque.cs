namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estoque")]
    public partial class Estoque
    {
        public int ID { get; set; }

        [Required]
        [StringLength(3)]
        public string IDEmpresaERP { get; set; }

        public int? CodigoERP { get; set; }

        public decimal Preco { get; set; }

        public decimal? PrecoaPrazo { get; set; }

        public DateTime? DataHoraUltimaCargaERP { get; set; }

        [StringLength(50)]
        public string UsuarioCargaERP { get; set; }

        public decimal Quantidade { get; set; }
    }
}
