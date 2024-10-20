namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PessoaEndereco")]
    public partial class PessoaEndereco
    {
        public int ID { get; set; }

        public int IDPessoa { get; set; }

        public int Sequencia { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        public int? IDCidade { get; set; }

        [StringLength(15)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Contato { get; set; }

        public byte? bEntrega { get; set; }

        public byte? bCobranca { get; set; }

        public byte? bAtivo { get; set; }

        public byte? bPrincipal { get; set; }

        [StringLength(6)]
        public string Numero { get; set; }

        [StringLength(200)]
        public string Complemento { get; set; }

        public int? IDIntegracao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
