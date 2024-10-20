using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using System;

namespace PDV.CONTROLLER.FISCAL.Base.NFCe
{
    public class Imposto
    {
        /*
        <summary>
            <para>N02 (ICMS00) - Grupo Tributação do ICMS= 00</para>
            <para>N03 (ICMS10) - Grupo Tributação do ICMS = 10 </para>
            <para>N04 (ICMS20) - Grupo Tributação do ICMS = 20</para>
            <para>N05 (ICMS30) - Grupo Tributação do ICMS = 30</para>
            <para>N06 (ICMS40) - Grupo Tributação ICMS = 40, 41, 50</para>
            <para>N07 (ICMS51) - Grupo Tributação do ICMS = 51</para>
            <para>N08 (ICMS60) - Grupo Tributação do ICMS = 60</para>
            <para>N09 (ICMS70) - Grupo Tributação do ICMS = 70</para>
            <para>N10 (ICMS90) - Grupo Tributação do ICMS = 90</para>
            <para>
                N10a (ICMSPart) - Grupo de Partilha do ICMS entre a UF de origem e UF de destino ou a UF definida na
                legislação.
            </para>
            <para>
                N10b (ICMSST) - Grupo de Repasse de ICMS ST retido anteriormente em operações interestaduais com repasses
                através do Substituto Tributário
            </para>
            <para>N10c (ICMSSN101) - Grupo CRT=1 – Simples Nacional e CSOSN=101</para>
            <para>N10d (ICMSSN102) - Grupo CRT=1 – Simples Nacional e CSOSN=102, 103, 300 ou 400</para>
            <para>N10e (ICMSSN201) - Grupo CRT=1 – Simples Nacional e CSOSN=201</para>
            <para>N10f (ICMSSN202) - Grupo CRT=1 – Simples Nacional e CSOSN=202 ou 203</para>
            <para>N10g (ICMSSN500) - Grupo CRT=1 – Simples Nacional e CSOSN = 500</para>
            <para>N10h (ICMSSN900) - Grupo CRT=1 – Simples Nacional e CSOSN=900</para>
        </summary>

        <summary>
            <para>Q02 (PISAliq) - Grupo PIS tributado pela alíquota</para>
            <para>Q03 (PISQtde) - Grupo PIS tributado por Qtde</para>
            <para>Q04 (PISNT) - Grupo PIS não tributado</para>
            <para>Q05 (PISOutr) - Grupo PIS Outras Operações</para>
        </summary>

        <summary>
            <para>S02 (COFINSAliq) - Grupo COFINS tributado pela alíquota</para>
            <para>S03 (COFINSQtde) - Grupo COFINS tributado por Qtde</para>
            <para>S04 (COFINSNT) - Grupo COFINS não tributado</para>
            <para>S05 (COFINSOutr) - Grupo COFINS Outras Operações</para>
        </summary>
        <summary>
            O07 (IPITrib) - Grupo do CST 00, 49, 50 e 99
            O08 (IPINT) - Grupo CST 01, 02, 03, 04, 51, 52, 53, 54 e 55
        </summary>
        */

        public static ICMSBasico GetICMS(int CSTCSOSN,
                                         int Origem,
                                         decimal BaseDeCalculo,
                                         decimal AliquotaInterna,
                                         decimal PercentualReducaoBaseCalculo,
                                         decimal AliqDif)
        {
            switch (CSTCSOSN)
            {
                case 0:
                    return new ICMS00
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        vBC = BaseDeCalculo,
                        pICMS = AliquotaInterna,
                        vICMS = BaseDeCalculo * (AliquotaInterna / 100)
                    };
                case 20:
                    var vBC = BaseDeCalculo - (BaseDeCalculo * (PercentualReducaoBaseCalculo / 100));
                    return new ICMS20
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        pICMS = AliquotaInterna,
                        pRedBC = PercentualReducaoBaseCalculo,
                        vBC = vBC,
                        vICMS = vBC * (AliquotaInterna / 100)
                    };
                case 40:
                    return new ICMS40
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 51:
                    var vICMSOp = BaseDeCalculo * (AliquotaInterna / 100);
                    var vICMSDif = vICMSOp * (AliqDif / 100);
                    return new ICMS51
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        vBC = BaseDeCalculo,
                        pICMS = AliquotaInterna,
                        vICMSOp = vICMSOp,
                        pDif = AliqDif,
                        vICMSDif = vICMSDif,
                        vICMS = vICMSOp - vICMSDif,
                    };
                case 60:
                    return new ICMS60
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 90:
                    return new ICMS90
                    {
                        CST = (Csticms)Enum.Parse(typeof(Csticms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                    };
                case 101:
                    return new ICMSSN101
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 102:
                case 103:
                case 300:
                case 400:
                    return new ICMSSN102
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 500:
                    return new ICMSSN500
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 900:
                    return new ICMSSN900
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                default:
                    return null;
            }
        }

        public static PISBasico GetPis(int CST, decimal BaseDeCalculo, decimal Aliquota)
        {
            switch (CST)
            {
                case 01:
                case 02:
                case 03:
                    return new PISAliq
                    {
                        CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString()),
                        vBC = BaseDeCalculo,
                        pPIS = Aliquota,
                        vPIS = BaseDeCalculo * (Aliquota / 100)
                    };
                case 04:
                case 05:
                case 06:
                case 07:
                case 08:
                case 09:
                case 49:
                case 99:
                    return new PISOutr
                    {
                        CST = (CSTPIS)Enum.Parse(typeof(CSTPIS), CST.ToString()),
                        pPIS = 0,
                        vPIS = 0,
                        vBC = 0
                    };
                default:
                    return null;
            }
        }

        public static COFINSBasico GetCofins(int CST, decimal BaseDeCalculo, decimal Aliquota)
        {
            switch (CST)
            {
                case 01:
                case 02:
                case 03:
                    return new COFINSAliq
                    {
                        CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()),
                        vBC = BaseDeCalculo,
                        pCOFINS = Aliquota,
                        vCOFINS = BaseDeCalculo * (Aliquota / 100)
                    };
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 49:
                case 99:
                    return new COFINSOutr
                    {
                        CST = (CSTCOFINS)Enum.Parse(typeof(CSTCOFINS), CST.ToString()),
                        pCOFINS = 0,
                        vBC = 0,
                        vCOFINS = 0
                    };
                default:
                    return null;
            }
        }

        public static IPIBasico GetIpi(int CST, decimal BaseDeCalculo, decimal Aliquota)
        {
            switch (CST)
            {
                case 2: //50
                    return new IPITrib
                    {
                        CST = (CSTIPI)Enum.Parse(typeof(CSTIPI), CST.ToString()),
                        pIPI = Aliquota,
                        vBC = BaseDeCalculo,
                        vIPI = BaseDeCalculo * (Aliquota / 100)
                    };
                case 9:  //51
                case 10: //52
                case 11: //53
                case 12: //54
                case 13: //55
                case 3:  //99
                    return new IPINT
                    {
                        CST = (CSTIPI)Enum.Parse(typeof(CSTIPI), CST.ToString())
                    };
                default:
                    return null;
            }
        }
    }
}