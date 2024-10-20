namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaVendedor")]
    public partial class PessoaVendedor
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ComissaoVendedor { get; set; }

        [StringLength(10)]
        public string Senha { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ComissaoServicoVendedor { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
