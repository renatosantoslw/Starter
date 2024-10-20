namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormaPagamento")]
    public partial class FormaPagamento
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public int? FormaPagamentoID { get; set; }
    }
}
