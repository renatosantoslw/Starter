namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Condicoes
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public int? IDCondicao { get; set; }
    }
}
