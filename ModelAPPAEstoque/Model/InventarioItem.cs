namespace ModelAPPAEstoque.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventarioItem")]
    public partial class InventarioItem
    {
        public int ID { get; set; }

        public DateTime Data { get; set; }

        public int ProdutoID { get; set; }

        public string ProdutoNome { get; set; }

        public decimal Quantidade { get; set; }

        public int UsuarioID { get; set; }

        public string UsuarioNome { get; set; }

        public int EmpresaID { get; set; }

        public string EmpresaNome { get; set; }

        public bool Status { get; set; }

        public string Codigo { get; set; }
    }
}
