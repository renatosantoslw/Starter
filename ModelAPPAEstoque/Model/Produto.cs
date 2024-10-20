namespace ModelAPPAEstoque.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produto")]
    public partial class Produto
    {
        public int ID { get; set; }

        [StringLength(300)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string UnidadeNome { get; set; }

        public int? UnidadeID { get; set; }

        public int? ProdutoID { get; set; }

        public string Imagem { get; set; }

        public int EmpresaID { get; set; }
    }
}
