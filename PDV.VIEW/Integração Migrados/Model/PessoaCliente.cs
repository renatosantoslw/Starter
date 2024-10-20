namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaCliente")]
    public partial class PessoaCliente
    {
        public int ID { get; set; }

        public int? IDPessoa { get; set; }

        public byte? bContribuinte { get; set; }

        public byte? bBloqueiaCondicao { get; set; }

        public int? IDCondicao { get; set; }

        public byte? bBloqueiaTabelaPreco { get; set; }

        public int? IDTabelaPreco { get; set; }

        public int? IDVendedor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LimiteCredito { get; set; }

        [StringLength(80)]
        public string NomeConjuge { get; set; }

        [StringLength(80)]
        public string NomePai { get; set; }

        [StringLength(80)]
        public string NomeMae { get; set; }

        public byte? bBloqueiaVendedor { get; set; }

        public virtual Condicao Condicao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Pessoa Pessoa1 { get; set; }
    }
}
