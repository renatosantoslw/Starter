namespace PDV.VIEW.Integração_Migrados.Model
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

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }

        [StringLength(20)]
        public string Barra { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(30)]
        public string DescReduzida { get; set; }

        public int? IDUnidade { get; set; }

        public int? IDGrupoEstoque { get; set; }

        public int? IDFornecedor { get; set; }

        [StringLength(20)]
        public string BarraFornecedor { get; set; }

        public string DescLonga1 { get; set; }

        [StringLength(100)]
        public string DescLonga2 { get; set; }

        [StringLength(100)]
        public string DescLonga3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PesoLiquido { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PesoBruto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PrecoFornecedor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DescontoFornecedor { get; set; }

        public DateTime? DtPrecoFornecedor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UltimoCusto { get; set; }

        public DateTime? DtUltimoCusto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PrecoBase { get; set; }

        public DateTime? DtPrecoBase { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqISS { get; set; }

        public int? IDPlanoConta_Est { get; set; }

        public int? IDPlanoConta_FinAV { get; set; }

        public int? IDPlanoConta_FinAP { get; set; }

        public byte? bServico { get; set; }

        public int? IDPlanoNegocio { get; set; }

        [StringLength(15)]
        public string ClassFiscal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustoFrete { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustoIPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustoExtra { get; set; }

        public int? Tributacao { get; set; }

        public int? OrigemProd { get; set; }

        public int? modBCICMS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqContrib { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqContribNormal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReducaoContrib { get; set; }

        [StringLength(100)]
        public string TextoLeiContrib { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqNContrib { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqNContribNormal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReducaoNContrib { get; set; }

        [StringLength(100)]
        public string TextoLeiNContrib { get; set; }

        public int? modBCST { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LucroST { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pRedBCST { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqSubstTributaria { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliqSimplesSubst { get; set; }

        public int? CST_Pis { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pPIS_Q08 { get; set; }

        public int? CST_Cofins { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pCOFINS_S08 { get; set; }

        public int? ENQ_IPI { get; set; }

        public int? CST_IPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AliquotaIPI { get; set; }

        [StringLength(8)]
        public string NCM { get; set; }

        public int? GENERO_NCM { get; set; }

        public int? IDCFOP { get; set; }

        public string InfAdicionais { get; set; }

        [StringLength(2)]
        public string AliqCupomContrib { get; set; }

        [StringLength(2)]
        public string AliqCupomNContrib { get; set; }

        public int? CSOSN { get; set; }

        [StringLength(1000)]
        public string CaminhoImagem { get; set; }

        public byte[] Imagem { get; set; }

        public int? IDGrupo1 { get; set; }

        public int? IDGrupo2 { get; set; }

        public int? IDGrupo3 { get; set; }

        public DateTime? IncData { get; set; }

        [StringLength(20)]
        public string IncUsuario { get; set; }

        public DateTime? AltData { get; set; }

        [StringLength(20)]
        public string AltUsuario { get; set; }

        public int? LEGADOCODIGO { get; set; }

        public int? IDIntegracao { get; set; }

        public bool CodigoBarrasRegistrado { get; set; }

        public bool? UtilizaIdentificadorEstoque { get; set; }

        public bool? Inativo { get; set; }

        public int? IDCFOPForaDoEstado { get; set; }

        public int? IDFornecedor2 { get; set; }

        public int? IDFornecedor3 { get; set; }

        public int? IDFornecedor4 { get; set; }

        public int? IDFornecedor5 { get; set; }

        public DateTime? DTFornec1 { get; set; }

        public DateTime? DTFornec2 { get; set; }

        public DateTime? DTFornec3 { get; set; }

        public DateTime? DTFornec4 { get; set; }

        public DateTime? DTFornec5 { get; set; }

        [StringLength(50)]
        public string BarraFornecedor2 { get; set; }

        [StringLength(50)]
        public string BarraFornecedor3 { get; set; }

        [StringLength(50)]
        public string BarraFornecedor4 { get; set; }

        [StringLength(50)]
        public string BarraFornecedor5 { get; set; }

        public decimal? UltimoCusto1 { get; set; }

        public decimal? UltimoCusto2 { get; set; }

        public decimal? UltimoCusto3 { get; set; }

        public decimal? UltimoCusto4 { get; set; }

        public decimal? UltimoCusto5 { get; set; }

        [StringLength(1000)]
        public string Observacao { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Largura { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Altura { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Comprimento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Peso { get; set; }

        public bool? BEnviadoSHL { get; set; }

        public int? IDUnidadeEntrada { get; set; }

        [StringLength(100)]
        public string Localizacao { get; set; }

        [StringLength(500)]
        public string DescricaoAnterior { get; set; }

        public bool? UtilizarIMEI { get; set; }

        public int? EscRelevante { get; set; }

        [StringLength(500)]
        public string RAZAO_Fab { get; set; }

        [StringLength(20)]
        public string CNPJ_Fab { get; set; }

        [StringLength(20)]
        public string CBenef { get; set; }

        public decimal? Tara { get; set; }

        public virtual Produto Produto1 { get; set; }

        public virtual Produto Produto2 { get; set; }
    }
}
