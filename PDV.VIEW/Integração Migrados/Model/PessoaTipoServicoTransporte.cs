namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaTipoServicoTransporte")]
    public partial class PessoaTipoServicoTransporte
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        public int IDTipoServicoTransporte { get; set; }

        public int CodShl { get; set; }

        [StringLength(255)]
        public string CodContrato { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
