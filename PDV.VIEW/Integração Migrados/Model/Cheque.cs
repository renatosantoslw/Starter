namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cheque")]
    public partial class Cheque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cheque()
        {
            ChequeHistorico = new HashSet<ChequeHistorico>();
        }

        public int ID { get; set; }

        [StringLength(5)]
        public string Banco { get; set; }

        [StringLength(15)]
        public string Agencia { get; set; }

        [StringLength(15)]
        public string ContaCorrente { get; set; }

        [StringLength(15)]
        public string Numero { get; set; }

        [StringLength(80)]
        public string Emitente { get; set; }

        [StringLength(20)]
        public string CNPJCPF_Emitente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Valor { get; set; }

        public bool? ChTerceiro { get; set; }

        public DateTime? Vencimento { get; set; }

        public int? IDPessoa { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? IDConta { get; set; }

        public DateTime? IncData { get; set; }

        [StringLength(20)]
        public string IncUsuario { get; set; }

        public DateTime? AltData { get; set; }

        [StringLength(20)]
        public string AltUsuario { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChequeHistorico> ChequeHistorico { get; set; }
    }
}
