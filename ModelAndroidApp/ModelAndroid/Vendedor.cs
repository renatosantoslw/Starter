namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendedor")]
    public partial class Vendedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendedor()
        {
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(500)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        public int? IDVendedor { get; set; }

        public bool? Gestor { get; set; }

        public int? IDErp { get; set; }

        [StringLength(15)]
        public string CodigoLojaERP { get; set; }

        [StringLength(1)]
        public string IntegracaoERP { get; set; }

        [StringLength(1)]
        public string FormaDesconto { get; set; }

        [StringLength(1)]
        public string TipoDesconto { get; set; }

        public int? SetorVendas { get; set; }

        public int? Rota { get; set; }

        public int? UltimoPedido { get; set; }

        [StringLength(400)]
        public string EnderecoServicosWeb { get; set; }

        [StringLength(200)]
        public string CampoLivre { get; set; }

        [StringLength(20)]
        public string NumeroMapa { get; set; }
       
    }
}
