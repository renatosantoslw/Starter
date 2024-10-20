namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_PessoaDados
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaCodigo { get; set; }

        [StringLength(80)]
        public string PessoaNome { get; set; }

        [StringLength(20)]
        public string PessoaCNPJ_CPF { get; set; }

        [StringLength(20)]
        public string PessoaInscRG { get; set; }

        [StringLength(100)]
        public string PessoaEndereco { get; set; }

        [StringLength(50)]
        public string PessoaBairro { get; set; }

        [StringLength(60)]
        public string PessoaCidade { get; set; }

        [StringLength(2)]
        public string PessoaUF { get; set; }

        [StringLength(20)]
        public string PessoaTelefone { get; set; }

        [StringLength(20)]
        public string PessoaCidadeIBGE { get; set; }

        [StringLength(15)]
        public string PessoaCEP { get; set; }

        [StringLength(200)]
        public string PessoaComplemento { get; set; }

        public byte bAtivo { get; set; }

        public byte bCliente { get; set; }

        public byte bFornecedor { get; set; }

        public byte bVendedor { get; set; }


    }
}
