namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanoConta")]
    public partial class PlanoConta
    {
        public int ID { get; set; }

        public int Codigo { get; set; }

        [StringLength(20)]
        public string Classificacao { get; set; }

        public byte? bTitulo { get; set; }

        public byte? DebCre { get; set; }

        public int? IDPlanoConta { get; set; }

        public int? IDPlanoContaReferencial { get; set; }

        [StringLength(1000)]
        public string Nome { get; set; }

        public int? IDAntigo { get; set; }

        [StringLength(5)]
        public string Cod_Nat_CC { get; set; }
    }
}
