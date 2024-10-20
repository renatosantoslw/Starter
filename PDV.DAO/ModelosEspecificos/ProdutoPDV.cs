using PDV.DAO.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO
{
    public class ProdutoPDV
    {
        [CampoTabela(nameof(IDProduto))]
        public decimal IDProduto { get; set; }

        [CampoTabela(nameof(Codigo))]
        public string Codigo { get; set; }

        [CampoTabela(nameof(CodigoDeBarras))]
        public string CodigoDeBarras { get; set; }

        [CampoTabela(nameof(Produto))]
        public string Produto { get; set; }

        [CampoTabela(nameof(Referencia))]
        public string Referencia { get; set; }

        [CampoTabela(nameof(Marca))]
        public string Marca { get; set; }

        [CampoTabela(nameof(UnidadeDeMedida))]
        public string UnidadeDeMedida { get; set; }

        [CampoTabela(nameof(UnidadeDeMedidaSigla))]
        public string UnidadeDeMedidaSigla { get; set; }

        [CampoTabela(nameof(PrecoVendaPrazo))]
        public decimal PrecoVendaPrazo { get; set; }

        [CampoTabela(nameof(PrecoVenda))]
        public decimal PrecoVenda { get; set; }

        [CampoTabela(nameof(ValorCusto))]
        public decimal ValorCusto { get; set; }

        [CampoTabela(nameof(Ncm))]
        public string Ncm { get; set; }

        [CampoTabela(nameof(EXTIPI))]
        public string EXTIPI { get; set; }

        [CampoTabela(nameof(IDIntegracaoFiscalNFCe))]
        public decimal IDIntegracaoFiscalNFCe { get; set; }

        [CampoTabela(nameof(Balanca))]
        public bool Balanca { get; set; }

    }
}
