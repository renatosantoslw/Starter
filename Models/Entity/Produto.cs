using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Models.Entity
{
    [Table("produto")]
    public partial class Produto
    {
        public Produto()
        {
            Iteminventarios = new HashSet<Iteminventario>();
            Itemnfeentrada = new HashSet<Itemnfeentradum>();
            Itempedidocompras = new HashSet<Itempedidocompra>();
            Itemtransferenciaestoques = new HashSet<Itemtransferenciaestoque>();
            Itemvenda = new HashSet<Itemvendum>();
            Movimentoestoques = new HashSet<Movimentoestoque>();
            Produtofornecedors = new HashSet<Produtofornecedor>();
            Produtonves = new HashSet<Produtonfe>();
            Saldoestoqueinicials = new HashSet<Saldoestoqueinicial>();
        }


        [Key]
        [Required(ErrorMessage = "Campo: {0} obrigatorio.", AllowEmptyStrings = false)]
        [Column("idproduto", TypeName = "int")]
        public int Idproduto { get; set; }


        [Column("idunidadedemedida", TypeName = "int")]
        public int? Idunidadedemedida { get; set; }


        [Column("idorigemproduto", TypeName = "int")]
        public int? Idorigemproduto { get; set; }


        [Column("idintegracaofiscalnfe", TypeName = "int")]
        public int? Idintegracaofiscalnfe { get; set; }


        [Column("idintegracaofiscalnfce", TypeName = "int")]
        public int? Idintegracaofiscalnfce { get; set; }


        [Column("idmarca", TypeName = "int")]
        public int? Idmarca { get; set; }


        [Column("idncm", TypeName = "int")]
        public int? Idncm { get; set; }


        [Column("idsubcategoria", TypeName = "int")]
        public int? Idsubcategoria { get; set; }


        [Column("idcategoria", TypeName = "int")]
        public int? Idcategoria { get; set; }


        [Column("codigo", TypeName = "int")]
        public int? Codigo { get; set; }


        [DataType(DataType.Text)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage = "Caractere especial não permitido parar o Campo: {0}")]
        [Required(ErrorMessage = "Preenchimento do Campo: {0} obrigatorio.", AllowEmptyStrings = false)]
        [StringLength(120, MinimumLength = 1, ErrorMessage = "O Campo: {0} deve conter no máximo 120 caracteres.")]
        [Display(Name = "Descrição do Produto.")]
        [Column("descricao", TypeName = "nvarchar(200)")]
        string _descricao;
        public string Descricao { get => this._descricao; set => _descricao = value.Trim(); }



        public string Extipi { get; set; }


        public long? Ean { get; set; }


        public string Cest { get; set; }


        public decimal? Valorvenda { get; set; }


        public decimal? Valorcusto { get; set; }


        public decimal? TribMva { get; set; }


        public decimal? TribRedbcicms { get; set; }


        public decimal? TribRedbcicmsst { get; set; }


        public decimal? TribAliqipi { get; set; }


        public decimal? TribAliqpis { get; set; }


        public decimal? TribAliqcofins { get; set; }


        public decimal? TribAliqicmsdif { get; set; }


        public decimal? Ativo { get; set; }


        public int? Idalmoxarifadoentrada { get; set; }


        public int? Idalmoxarifadosaida { get; set; }


        public decimal? Saldoestoque { get; set; }


        public decimal? Vendersemsaldo { get; set; }


        public string Chaveerp { get; set; }


        public decimal? Valorvendaprazo { get; set; }


        public decimal? Alterardescricao { get; set; }


        public decimal? Estoqueminimo { get; set; }


        public decimal? Estoquemaximo { get; set; }


        public byte[] Imagemproduto { get; set; }


        public string Imagemprodutolink { get; set; }


        public int? Tipodeproduto { get; set; }


        public bool? Paravender { get; set; }

        public virtual Almoxarifado IdalmoxarifadoentradaNavigation { get; set; }
        public virtual Almoxarifado IdalmoxarifadosaidaNavigation { get; set; }
        public virtual Categorium IdcategoriaNavigation { get; set; }
        public virtual Integracaofiscal IdintegracaofiscalnfceNavigation { get; set; }
        public virtual Integracaofiscal IdintegracaofiscalnfeNavigation { get; set; }
        public virtual Marca IdmarcaNavigation { get; set; }
        public virtual Origemproduto IdorigemprodutoNavigation { get; set; }
        public virtual Categorium IdsubcategoriaNavigation { get; set; }
        public virtual Unidadedemedidum IdunidadedemedidaNavigation { get; set; }
        public virtual ICollection<Iteminventario> Iteminventarios { get; set; }
        public virtual ICollection<Itemnfeentradum> Itemnfeentrada { get; set; }
        public virtual ICollection<Itempedidocompra> Itempedidocompras { get; set; }
        public virtual ICollection<Itemtransferenciaestoque> Itemtransferenciaestoques { get; set; }
        public virtual ICollection<Itemvendum> Itemvenda { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
        public virtual ICollection<Produtofornecedor> Produtofornecedors { get; set; }
        public virtual ICollection<Produtonfe> Produtonves { get; set; }
        public virtual ICollection<Saldoestoqueinicial> Saldoestoqueinicials { get; set; }
    }
}
