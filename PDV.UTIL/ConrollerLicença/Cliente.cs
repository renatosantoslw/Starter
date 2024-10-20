namespace ConrollerLicença
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        public int ID { get; set; }

        [StringLength(450)]
        public string Nome { get; set; }

        [StringLength(450)]
        public string Documento { get; set; }

        [StringLength(450)]
        public string Observação { get; set; }

        public DateTime? DataVencimento { get; set; }

        public DateTime? DataAplicação { get; set; }

        public string Chave { get; set; }

        public bool Ativo { get; set; }
    }
}
