namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendedores
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        public int? IDVendedor { get; set; }

        public bool? Gestor { get; set; }
    }
}
