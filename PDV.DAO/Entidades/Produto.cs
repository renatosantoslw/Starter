using PDV.DAO.Atributos;
using System.Web.UI.WebControls.WebParts;

namespace PDV.DAO.Entidades
{
    public class Produto
    {
        [CampoTabela("IDPRODUTO")]
        [MaxLength(18)]
        public int IDProduto { get; set; } = -1;

        [CampoTabela("CODIGO")]
        [MaxLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [CampoTabela("DESCRICAO")]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [CampoTabela("REFERENCIA")]
        [MaxLength(50)]
        public string Referencia { get; set; }
        
        [CampoTabela("EXTIPI")]
        [MaxLength(2)]
        public string EXTipi { get; set; }

        [CampoTabela("EAN")]
        [MaxLength(14)]
        public string EAN { get; set; }

        [CampoTabela("CEST")]
        [MaxLength(150)]
        public string CEST { get; set; }

        [CampoTabela("VALORVENDA")]
        [MaxLength(15.2)]
        public decimal ValorVenda { get; set; }

        [CampoTabela("VALORCUSTO")]
        [MaxLength(15.2)]
        public decimal ValorCusto { get; set; }

        /* Chaves Estrangeiras */

        [CampoTabela("IDUNIDADEDEMEDIDA")]
        [MaxLength(18)]
        public decimal IDUnidadeDeMedida { get; set; }

        [CampoTabela("IDORIGEMPRODUTO")]
        [MaxLength(18)]
        public decimal IDOrigemProduto { get; set; } = -1;

        [CampoTabela("IDINTEGRACAOFISCALNFCE")]
        [MaxLength(18)]
        public decimal? IDIntegracaoFiscalNFCe { get; set; }

        [CampoTabela("IDINTEGRACAOFISCALNFE")]
        [MaxLength(18)]
        public decimal? IDIntegracaoFiscalNFe { get; set; }

        [CampoTabela("IDMARCA")]
        [MaxLength(18)]
        public decimal? IDMarca { get; set; }

        [CampoTabela("IDNCM")]
        [MaxLength(18)]
        public decimal IDNCM { get; set; } = -1;

        [CampoTabela("IDCATEGORIA")]
        [MaxLength(18)]
        public decimal? IDCategoria { get; set; }

        [CampoTabela("IDSUBCATEGORIA")]
        [MaxLength(18)]
        public decimal? IDSubCategoria { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("PARAVENDER")]
        public bool ParaVender { get; set; } = true;

        [CampoTabela("BALANCA")]
        public bool Balanca { get; set; } = false; 

        /* Tributações */
        [CampoTabela("TRIB_MVA")]
        public decimal Trib_MVA { get; set; }

        [CampoTabela("TRIB_REDBCICMS")]
        public decimal Trib_RedBCICMS { get; set; }

        [CampoTabela("TRIB_REDBCICMSST")]
        public decimal Trib_RedBCICMSST { get; set; }

        [CampoTabela("TRIB_ALIQIPI")]
        public decimal Trib_AliqIPI { get; set; }

        [CampoTabela("TRIB_ALIQPIS")]
        public decimal Trib_AliqPIS { get; set; }

        [CampoTabela("TRIB_ALIQCOFINS")]
        public decimal Trib_AliqCOFINS { get; set; }

        [CampoTabela("TRIB_ALIQICMSDIF")]
        public decimal Trib_AliqICMSDif { get; set; }

        [CampoTabela("IDALMOXARIFADOENTRADA")]
        public int IDAlmoxarifadoEntrada { get; set; } = 4;

        [CampoTabela("IDALMOXARIFADOSAIDA")]
        public decimal? IDAlmoxarifadoSaida { get; set; } = 4;

        [CampoTabela("SALDOESTOQUE")]
        public decimal SaldoEstoque { get; set; }

        [CampoTabela("VENDERSEMSALDO")]
        public decimal VenderSemSaldo { get; set;  } = 1;

        [CampoTabela("ALTERARDESCRICAO")]
        public decimal AlterarDescricao { get; set; } = 1;

        [CampoTabela("ESTOQUEMINIMO")]
        public decimal EstoqueMinimo { get; set; }

        [CampoTabela("ESTOQUEMAXIMO")]
        public decimal EstoqueMaximo { get; set; }

        [CampoTabela("VALORVENDAPRAZO")]
        [MaxLength(15.2)]
        public decimal ValorVendaPrazo { get; set; }

        [CampoTabela("TIPODEPRODUTO")]
        //1 = Matéria Prima
        //2 = Produto Acabado
        public int TipoDeProduto { get; set; } = 2;

        public static readonly int MateriaPrima = 1;
        public static readonly int ProdutoAcabado = 2;

        public byte[] ImagemProduto { get; set; }
        public string ImagemProdutoLink  { get; set; }
        public Produto()
        {
        }
    }

}
