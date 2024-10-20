namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class Produto
    {
        public decimal IDProduto { get; set; } = -1;

        public string Codigo { get; set; } = string.Empty;

        public string Descricao { get; set; }

        public string EXTipi { get; set; }
        public string EAN { get; set; }

        public string CEST { get; set; }
        public string ChaveERP { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorVendaPrazo { get; set; }
        public decimal ValorCusto { get; set; }

        public decimal ValorVista { get; set; }
        public decimal ValorPrazo { get; set; }
        public string NCM { get; set; }

        /* Chaves Estrangeiras */

        public decimal IDUnidadeDeMedida { get; set; }

        public decimal IDOrigemProduto { get; set; } = -1;

        public decimal? IDIntegracaoFiscalNFCe { get; set; }
        public decimal? IDIntegracaoFiscalNFe { get; set; }

        public decimal? IDFornecedor { get; set; }

        public decimal? IDMarca { get; set; }

        public decimal IDNCM { get; set; } = -1;

        public decimal? IDCategoria { get; set; }

        public decimal? IDSubCategoria { get; set; }

        public decimal Ativo { get; set; } = 1;

        /* Tributações */
        public decimal Trib_MVA { get; set; }

        public decimal Trib_RedBCICMS { get; set; }

        public decimal Trib_RedBCICMSST { get; set; }

        public decimal Trib_AliqIPI { get; set; }

        public decimal Trib_AliqPIS { get; set; }

        public decimal Trib_AliqCOFINS { get; set; }

        public decimal Trib_AliqICMSDif { get; set; }

        public Produto()
        {
        }
    }
}
