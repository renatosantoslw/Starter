namespace ModelAPPAEstoque.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [Key]
        public int ID { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public string Imagem { get; set; }

        [StringLength(3)]
        public string IDEmpresaERP { get; set; }

        [StringLength(50)]
        public string CNPJ { get; set; }

        [StringLength(250)]
        public string Endereco { get; set; }
    }
}
