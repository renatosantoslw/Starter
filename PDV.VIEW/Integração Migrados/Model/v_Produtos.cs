namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_Produtos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(5)]
        public string Unidade { get; set; }

        [StringLength(30)]
        public string DescReduzida { get; set; }

        [StringLength(60)]
        public string Grupo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string NomeTrocado { get; set; }

        [StringLength(20)]
        public string Barra { get; set; }

        [StringLength(20)]
        public string BarraFornecedor { get; set; }

        public int? IDGrupoEstoque { get; set; }

        public decimal PrecoFornecedor { get; set; }

        public decimal  PrecoBase { get; set; }

        public string  NCM { get; set; }

        public string Cest { get; set; }
    }
}
