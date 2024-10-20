using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Total;
using System.Collections.Generic;
using System.Linq;

namespace PDV.CONTROLLER.FISCAL.Base.NFe
{
    public class Totais
    {
        public static total GetTotalNFe_SimplesNacional(List<det> produtos)
        {
            decimal vBCST = 0;
            decimal vST = 0;
            decimal vIPI = 0;
            decimal vPIS = 0;
            decimal vCOFINS = 0;


            foreach (var prodx in produtos)
            {
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN201))
                {
                    vBCST += (prodx.imposto.ICMS.TipoICMS as ICMSSN201).vBCST;
                    vST += (prodx.imposto.ICMS.TipoICMS as ICMSSN201).vICMSST;
                }

                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN202))
                {
                    vBCST += (prodx.imposto.ICMS.TipoICMS as ICMSSN202).vBCST;
                    vST += (prodx.imposto.ICMS.TipoICMS as ICMSSN202).vICMSST;
                }

                if (prodx.imposto.IPI != null && prodx.imposto.IPI.TipoIPI.GetType() == typeof(IPITrib))
                    vIPI = vIPI + (((IPITrib)prodx.imposto.IPI.TipoIPI).vIPI ?? 0);

                if (prodx.imposto.PIS != null && prodx.imposto.PIS.TipoPIS.GetType() == typeof(PISAliq))
                    vPIS = vPIS + ((PISAliq)prodx.imposto.PIS.TipoPIS).vPIS;

                if (prodx.imposto.COFINS != null && prodx.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSAliq))
                    vCOFINS = vCOFINS + ((COFINSAliq)prodx.imposto.COFINS.TipoCOFINS).vCOFINS;
            }

            return new total
            {
                ICMSTot = new ICMSTot
                {
                    vProd = produtos.Sum(p => p.prod.vProd),
                    vNF = (produtos.Sum(p => p.prod.vProd) + vST + produtos.Sum(p => p.prod.vFrete ?? 0) + produtos.Sum(p => p.prod.vOutro ?? 0) + produtos.Sum(p => p.prod.vSeg ?? 0)) - produtos.Sum(p => p.prod.vDesc ?? 0),
                    vBCST = vBCST,
                    vST = vST,
                    vDesc = produtos.Sum(p => p.prod.vDesc ?? 0),
                    vTotTrib = produtos.Sum(p => p.imposto.vTotTrib ?? 0),
                    vFrete = produtos.Sum(p => p.prod.vFrete ?? 0),
                    vOutro = produtos.Sum(p => p.prod.vOutro ?? 0),
                    vSeg = produtos.Sum(p => p.prod.vSeg ?? 0),
                    vBC = 0,
                    vICMSDeson = 0,
                    vICMS = 0,
                    vCOFINS = vCOFINS,
                    vPIS = vPIS,
                    vIPI = vIPI,
                    vFCPUFDest = 0,
                    vICMSUFDest = 0,
                    vICMSUFRemet = 0,
                    vFCP = 0,
                    vFCPST = 0,
                    vFCPSTRet = 0,
                    vIPIDevol = 0
        }
            };
        }

        public static total GetTotalNFe_RegimeNormall(List<det> produtos)
        {
            decimal vBC = 0;
            decimal vBCST = 0;
            decimal vICMS = 0;
            decimal vST = 0;
            decimal vIPI = 0;
            decimal vPIS = 0;
            decimal vCOFINS = 0;

            foreach (var prodx in produtos)
            {
                // ICMS
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS00))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vICMS += (prodx.imposto.ICMS.TipoICMS as ICMS00).vICMS;
                }
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS10)) // ICMS E ICMS ST
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vICMS += (prodx.imposto.ICMS.TipoICMS as ICMS10).vICMS;
                    vST += (prodx.imposto.ICMS.TipoICMS as ICMS10).vICMSST;
                    vBCST += (prodx.imposto.ICMS.TipoICMS as ICMS10).vBCST;
                }
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS20))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vICMS += (prodx.imposto.ICMS.TipoICMS as ICMS20).vICMS;
                }
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS51))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vICMS += (prodx.imposto.ICMS.TipoICMS as ICMS51).vICMS ?? 0;
                }
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS70))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vICMS += (prodx.imposto.ICMS.TipoICMS as ICMS70).vICMS;
                }

                //ICMS ST
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS30))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vST += (prodx.imposto.ICMS.TipoICMS as ICMS30).vICMSST;
                    vBCST += (prodx.imposto.ICMS.TipoICMS as ICMS30).vBCST;
                }
                if (prodx.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS70))
                {
                    vBC += (prodx.prod.vProd + (prodx.prod.vFrete ?? 0) + (prodx.prod.vOutro ?? 0) + (prodx.prod.vSeg ?? 0)) - (prodx.prod.vDesc ?? 0);
                    vST += (prodx.imposto.ICMS.TipoICMS as ICMS70).vICMSST;
                    vBCST += (prodx.imposto.ICMS.TipoICMS as ICMS70).vBCST;
                }

                if (prodx.imposto.IPI != null && prodx.imposto.IPI.TipoIPI.GetType() == typeof(IPITrib))
                    vIPI = vIPI + (((IPITrib)prodx.imposto.IPI.TipoIPI).vIPI ?? 0);

                //COFINS                
                if (prodx.imposto.COFINS != null && prodx.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSAliq))
                    vCOFINS = vCOFINS + ((COFINSAliq)prodx.imposto.COFINS.TipoCOFINS).vCOFINS;

                //PIS
                if (prodx.imposto.PIS != null && prodx.imposto.PIS.TipoPIS.GetType() == typeof(PISAliq))
                    vPIS = vPIS + ((PISAliq)prodx.imposto.PIS.TipoPIS).vPIS;
            }
            return new total
            {
                ICMSTot = new ICMSTot
                {
                    vProd = produtos.Sum(p => p.prod.vProd),
                    vNF = (produtos.Sum(p => p.prod.vProd) + vST + produtos.Sum(p => p.prod.vFrete ?? 0) + produtos.Sum(p => p.prod.vOutro ?? 0) + produtos.Sum(p => p.prod.vSeg ?? 0)) - produtos.Sum(p => p.prod.vDesc ?? 0),
                    vDesc = produtos.Sum(p => p.prod.vDesc ?? 0),
                    vTotTrib = produtos.Sum(p => p.imposto.vTotTrib ?? 0),
                    vBC = vBC,
                    vICMS = vICMS,
                    vST = vST,
                    vFrete = produtos.Sum(p => p.prod.vFrete ?? 0),
                    vOutro = produtos.Sum(p => p.prod.vOutro ?? 0),
                    vSeg = produtos.Sum(p => p.prod.vSeg ?? 0),
                    vICMSDeson = 0,
                    vBCST = vBCST,
                    vCOFINS = 0,
                    vIPI = 0,
                    vPIS = 0,
                    vFCPUFDest = produtos.Sum(p => p.imposto.ICMSUFDest == null ? 0 : p.imposto.ICMSUFDest.vFCPUFDest),
                    vICMSUFDest = produtos.Sum(p => p.imposto.ICMSUFDest == null ? 0 : p.imposto.ICMSUFDest.vICMSUFDest),
                    vICMSUFRemet = produtos.Sum(p => p.imposto.ICMSUFDest == null ? 0 : p.imposto.ICMSUFDest.vICMSUFRemet),
                }
            };
        }
    }
}