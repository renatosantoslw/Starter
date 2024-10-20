namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
       
        public int ID { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public string Imagem { get; set; }

        [StringLength(3)]
        public string IDEmpresaERP { get; set; }
        public string Endereco { get;  set; }
        public string CNPJ { get;  set; }
    }
}
