using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using System;

namespace PDV.CONTROLLER.FISCAL.Base.NFe
{
    public class Detalhe
    {
        public static det GetDetalhe(prod Produto, imposto Imposto, decimal ValorTributosNacional, decimal ValorTributosEstadual, decimal ValorTributosMunicipais, string ChaveIBPT, int nItem)
        {
            return new det
            {
                nItem = nItem,
                prod = Produto,
                imposto = Imposto,
                //infAdProd = string.Format("Trib aprox R$: {0} Federal, {1} Estadual e {2} Municipal. Fonte: IBPT {3}.", ValorTributosNacional.ToString("n2"), ValorTributosEstadual.ToString("n2"), ValorTributosMunicipais.ToString(), ChaveIBPT)
                //infAdProd = ""
            };
        }

    }
}
