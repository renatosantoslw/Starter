namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaEmail")]
    public partial class PessoaEmail
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public byte? bFinanceiro { get; set; }

        public byte? bVenda { get; set; }

        public byte? bCompra { get; set; }

        public byte? bAdministrativo { get; set; }

        public byte? bContato { get; set; }

        public byte? bSugestao { get; set; }

        public byte? bMsn { get; set; }

        public int IDPessoa { get; set; }

        public bool bNFe { get; set; }

        public bool? bNFSe { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
