namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaContabilista")]
    public partial class PessoaContabilista
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        [Required]
        [StringLength(15)]
        public string CRC { get; set; }

        [Required]
        [StringLength(20)]
        public string CNPJEscritorio { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
