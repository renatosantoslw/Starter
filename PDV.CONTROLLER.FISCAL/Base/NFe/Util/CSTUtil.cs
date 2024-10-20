using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using System;

namespace PDV.CONTROLLER.FISCAL.Base.NFe.Util
{
    public class CSTUtil
    {
        /* COFINS */
        public static COFINSBasico GetCofinsAliquota(int CST, decimal vBC, decimal pCOFINS, decimal vCOFINS)
        {
            return new COFINSAliq
            {
                CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()),
                vBC = vBC,
                pCOFINS = pCOFINS,
                vCOFINS = vCOFINS
            };
        }

        public static COFINSBasico GetCofinsQuantidade(int CST, decimal vBC, decimal pCOFINS, decimal vCOFINS)
        {
            return new COFINSQtde
            {
                CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()),
                qBCProd = vBC,
                vAliqProd = pCOFINS,
                vCOFINS = vCOFINS
            };
        }

        public static COFINSBasico GetCofinsNaoTributado(int CST)
        {
            return new COFINSNT { CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()) };
        }

        public static COFINSBasico GetCofinsOutros(int CST, decimal vBC, decimal pCOFINS, decimal vCOFINS)
        {
            return new COFINSOutr
            {
                CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()),
                vBC = vBC,
                pCOFINS = pCOFINS,
                vCOFINS = vCOFINS
            };
        }

        /* PIS */
        public static PISBasico GetPisQuantidade(int CST, decimal vBC, decimal pPIS, decimal vPIS)
        {
            return new PISQtde
            {
                CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString()),
                qBCProd = vBC,
                vAliqProd = pPIS,
                vPIS = vPIS
            };
        }

        public static PISBasico GetPisAliquota(int CST, decimal vBC, decimal pPIS, decimal vPIS)
        {
            return new PISAliq
            {
                CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString()),
                pPIS = pPIS,
                vBC = vBC,
                vPIS = vPIS
            };
        }

        public static PISBasico GetPisNaoTributado(int CST)
        {
            return new PISNT
            {
                CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString())
            };
        }

        public static PISBasico GetPisOutros(int CST, decimal vBC, decimal pPIS, decimal vPIS)
        {
            return new PISOutr
            {
                CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString()),
                vBC = vBC,
                vPIS = vPIS,
                pPIS = pPIS
            };
        }
    }
}
