namespace ModelAndroidAppSimples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Endereco { get; set; }

        [StringLength(500)]
        public string Bairro { get; set; }

        [StringLength(500)]
        public string Cidade { get; set; }

        [StringLength(10)]
        public string UF { get; set; }

        [StringLength(15)]
        public string Cep { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        public int? IDCliente { get; set; }

        public int? IDVendedor { get; set; }
    }
}
