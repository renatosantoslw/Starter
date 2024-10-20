using NFe.Classes.Informacoes.Detalhe;

namespace PDV.CONTROLLER.FISCAL.Base.NFe
{
    public class Produtos
    {
        public static prod GetProduto(string Produto,
                                      decimal IDProduto, 
                                      string EAN, 
                                      string NCM, 
                                      int CFOP, 
                                      string UnidadeMedida, 
                                      decimal Quantidade, 
                                      decimal ValorUnitario, 
                                      decimal Desconto = 0, 
                                      decimal Frete = 0,
                                      decimal OutrasDespesas = 0,
                                      decimal Seguro = 0,
                                      string CEST = null, 
                                      string ExTipi = null)
        {
            prod prodRetorno = new prod
            {
                cProd = IDProduto.ToString(),
                cEAN = EAN,
                xProd = Produto,
                NCM = NCM,
                CFOP = CFOP,
                uCom = UnidadeMedida,
                qCom = Quantidade,
                vUnCom = ValorUnitario,
                vProd = Quantidade * ValorUnitario,
                vDesc = Desconto,
                cEANTrib = EAN,
                uTrib = UnidadeMedida,
                qTrib = Quantidade,
                vUnTrib = ValorUnitario,
                indTot = IndicadorTotal.ValorDoItemCompoeTotalNF,
                vFrete = Frete,
                vOutro = OutrasDespesas,
                vSeg = Seguro
            };

            if (!string.IsNullOrEmpty(CEST))
                prodRetorno.CEST = CEST;

            if (!string.IsNullOrEmpty(ExTipi))
                prodRetorno.EXTIPI = ExTipi;
            return prodRetorno;
        }
    }
}
