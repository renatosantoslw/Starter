namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaTelefone")]
    public partial class PessoaTelefone
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        public int Sequencia { get; set; }

        [StringLength(15)]
        public string Tipo { get; set; }

        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(60)]
        public string Contato { get; set; }

        public byte? bPrincipal { get; set; }

        [StringLength(15)]
        public string Operadora { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
