namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaFuncionario")]
    public partial class PessoaFuncionario
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        [StringLength(20)]
        public string NumCarteiraTrab { get; set; }

        public int? IDCwUsuario { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
