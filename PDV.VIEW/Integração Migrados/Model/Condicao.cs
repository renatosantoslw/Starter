namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Condicao")]
    public partial class Condicao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Condicao()
        {
            CondicaoParcela = new HashSet<CondicaoParcela>();
            Documento = new HashSet<Documento>();
            PessoaCliente = new HashSet<PessoaCliente>();
        }

        public int ID { get; set; }

        public int Codigo { get; set; }

        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        public int? Divide { get; set; }

        public int QtParcela { get; set; }

        [StringLength(50)]
        public string TipoDt { get; set; }

        public int? DiaMes { get; set; }

        [StringLength(15)]
        public string TipoVlr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VlrPerc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Desconto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Variacao { get; set; }

        public byte VencimentoFeriado { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        public bool? TipoVariacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CondicaoParcela> CondicaoParcela { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaCliente> PessoaCliente { get; set; }
    }
}
