using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Total;
using System.Collections.Generic;
using System.Linq;

namespace PDV.CONTROLLER.FISCAL.Base.NFCe
{
    public class Totais
    {
        public static total GetTotalNFCe(List<det> produtos)
        {
            var icmsTot = new ICMSTot
            {
                vProd = produtos.Sum(p => p.prod.vProd),
                vNF = produtos.Sum(p => p.prod.vProd) - produtos.Sum(p => p.prod.vDesc ?? 0),
                vDesc = produtos.Sum(p => p.prod.vDesc ?? 0),
                vTotTrib = produtos.Sum(p => p.imposto.vTotTrib ?? 0),
                vBC = 0,
                vICMSDeson = 0
            };

               
                icmsTot.vFCPUFDest = 0;
                icmsTot.vICMSUFDest = 0;
                icmsTot.vICMSUFRemet = 0;
                icmsTot.vFCP = 0;
                icmsTot.vFCPST = 0;
                icmsTot.vFCPSTRet = 0;
                icmsTot.vIPIDevol = 0;
           

            foreach (var produto in produtos)
            {
                //ICMS
                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS00))
                {
                    icmsTot.vBC += (produto.prod.vProd - produto.prod.vDesc ?? 0);
                    icmsTot.vICMS = icmsTot.vICMS + ((ICMS00)produto.imposto.ICMS.TipoICMS).vICMS;
                }

                if (produto.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS20))
                {
                    icmsTot.vBC += (produto.prod.vProd - produto.prod.vDesc ?? 0);
                    icmsTot.vICMS = icmsTot.vICMS + ((ICMS20)produto.imposto.ICMS.TipoICMS).vICMS;
                }

                //IPI
                if (produto.imposto.IPI != null && produto.imposto.IPI.TipoIPI.GetType() == typeof(IPITrib))
                    icmsTot.vIPI = icmsTot.vIPI + ((IPITrib)produto.imposto.IPI.TipoIPI).vIPI ?? 0;

                //COFINS                
                if (produto.imposto.COFINS != null && produto.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSAliq))
                    icmsTot.vCOFINS = icmsTot.vCOFINS + ((COFINSAliq)produto.imposto.COFINS.TipoCOFINS).vCOFINS;

                //PIS
                if (produto.imposto.PIS != null && produto.imposto.PIS.TipoPIS.GetType() == typeof(PISAliq))
                    icmsTot.vPIS = icmsTot.vPIS + ((PISAliq)produto.imposto.PIS.TipoPIS).vPIS;
            }

            var t = new total { ICMSTot = icmsTot };
            return t;
        }
    }
}
