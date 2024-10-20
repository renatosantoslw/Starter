namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaEngenheiro")]
    public partial class PessoaEngenheiro
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        public string CREA { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
