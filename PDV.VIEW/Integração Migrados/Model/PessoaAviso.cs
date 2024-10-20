namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaAviso")]
    public partial class PessoaAviso
    {
        public int ID { get; set; }

        public int? IDPessoa { get; set; }

        public int Sequencia { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime DtValidade { get; set; }

        [StringLength(5)]
        public string Ordem { get; set; }

        [StringLength(300)]
        public string Aviso { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
