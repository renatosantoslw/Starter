using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using PDV.CONTROLLER.FISCAL.Base.NFe.Util;
using PDV.CONTROLLER.FISCAL.Util;
using System;

namespace PDV.CONTROLLER.FISCAL.Base.NFe
{
    public class Imposto
    {
        public static ICMSBasico GetICMS_NFe(int CSTCSOSN,
                                             int Origem,
                                             decimal BaseDeCalculo,
                                             decimal AliquotaICMSST, // interna
                                             decimal AliquotaICMS, // interestadual
                                             decimal PercentualReducaoBcICMS,
                                             decimal PercentualReducaoBcICMSST,
                                             decimal MVA,
                                             decimal ValorIPI,
                                             decimal AliqPCred,
                                             decimal AliqDif,
                                             bool ReducaoBcIcmsST,
                                             bool UFDiferenteDoEmitente)
        {
            decimal vBC = 0;
            decimal vBCICMS = 0;
            decimal vICMS = 0;
            decimal vBCIcmsST = 0;
            decimal ValorIcmsST = 0;

            switch (CSTCSOSN)
            {
                /* Regime Normal */
                case 0:
                    /* <ICMS00>
                         <orig>0</orig>
                         <CST>00</CST>
                         <modBC>3</modBC>
                         <vBC>100.00</vBC>
                         <pICMS>18.00</pICMS>
                         <vICMS>18.00</vICMS>
                       </ICMS00> */
                    return new ICMS00
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        vBC = BaseDeCalculo,
                        pICMS = UFDiferenteDoEmitente ? AliquotaICMS : AliquotaICMSST,
                        vICMS = BaseDeCalculo * ((UFDiferenteDoEmitente ? AliquotaICMS : AliquotaICMSST) / 100),
                    };
                case 10:
                    /* <ICMS10>
                          <orig>0</orig>
                          <CST>10</CST>
                          <modBC>3</modBC>
                          <vBC>100.00</vBC>
                          <pICMS>18.00</pICMS>
                          <vICMS>18.00</vICMS>
                          <modBCST>4</modBCST>
                          <pMVAST>50.00</pMVAST>
                          <vBCST>135.00</vBCST>
                          <pICMSST>18.00</pICMSST>
                          <vICMSST>6.30</vICMSST>
                       </ICMS10> */
                    vBC = BaseDeCalculo;
                    vICMS = BaseDeCalculo * (AliquotaICMS / 100);
                    vBCIcmsST = (BaseDeCalculo + ValorIPI) * ((100 + MVA) / 100);
                    return new ICMS10
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        vBC = vBC,
                        pICMS = AliquotaICMS,
                        vICMS = vICMS,
                        modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado,
                        pICMSST = AliquotaICMSST,
                        pMVAST = MVA,
                        vBCST = vBCIcmsST,
                        vICMSST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS
                    };
                case 20:
                    /* <ICMS20>
                          <orig>0</orig>
                          <CST>20</CST>
                          <modBC>3</modBC>
                          <pRedBC>10.00</pRedBC>
                          <vBC>90.00</vBC>
                          <pICMS>18.00</pICMS>
                          <vICMS>16.20</vICMS>
                       </ICMS20>*/
                    vBC = BaseDeCalculo - (BaseDeCalculo * (PercentualReducaoBcICMS / 100));
                    return new ICMS20
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        pRedBC = PercentualReducaoBcICMS,
                        vBC = vBC,
                        pICMS = UFDiferenteDoEmitente ? AliquotaICMS : AliquotaICMSST,
                        vICMS = vBC * ((UFDiferenteDoEmitente ? AliquotaICMS : AliquotaICMSST) / 100)
                    };
                case 30:
                    /* <ICMS30>
                           <orig>0</orig>
                           <CST>30</CST>
                           <modBCST>4</modBCST>
                           <pMVAST>50.00</pMVAST>
                           <pRedBCST>10.00</pRedBCST>
                           <vBCST>135.00</vBCST>
                           <pICMSST>18.00</pICMSST>
                           <vICMSST>24.30</vICMSST>
                       </ICMS30> */
                    vBCICMS = BaseDeCalculo;
                    vICMS = BaseDeCalculo * (AliquotaICMS / 100);
                    vBCIcmsST = (BaseDeCalculo + ValorIPI) * ((100 + MVA) / 100);
                    if (ReducaoBcIcmsST)
                        vBCIcmsST = vBCIcmsST - (vBCIcmsST * (PercentualReducaoBcICMSST / 100));

                    return new ICMS30()
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado,
                        pMVAST = MVA,
                        pRedBCST = PercentualReducaoBcICMSST,
                        vBCST = vBCIcmsST,
                        pICMSST = AliquotaICMSST,
                        vICMSST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS,
                    };
                case 40:
                case 41:
                case 50:
                    return new ICMS40
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 51:
                    var vICMSOp = BaseDeCalculo * (AliquotaICMS / 100);
                    var vICMSDif = vICMSOp * (AliqDif / 100);
                    /* <ICMS51>
                           <orig>0</orig>
                           <CST>51</CST>
                           <modBC>3</modBC>
                           <vBC>1000.00</vBC>
                           <pICMS>18.00</pICMS>
                           <vICMSOp>180.00</vICMSOp>
                           <pDif>33.33</pDif >
                           <vICMSDif>60.00</vICMSDif>
                           <vICMS>120.00</vICMS>
                       <ICMS51> */
                    return new ICMS51
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        vBC = BaseDeCalculo,
                        pICMS = AliquotaICMS,
                        vICMSOp = vICMSOp,
                        pDif = AliqDif,
                        vICMSDif = vICMSDif,
                        vICMS = vICMSOp - vICMSDif,
                    };
                case 60: // CSOSN 500
                    return new ICMS60
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };
                case 70:
                    /*
                     <ICMS70>
                         <orig>0</orig>
                         <CST>70</CST>
                         <modBC>3</modBC>
                         <pRedBC>10.00</pRedBC>
                         <vBC>90.00</vBC>
                         <pICMS>18.00</pICMS>
                         <vICMS>16.20</vICMS>
                         <modBCST>4</modBCST>
                         <pMVAST>100.00</pMVAST>
                         <pRedBCST>10.00</pRedBCST>
                         <vBCST>162.00</vBCST>
                         <pICMSST>18.00</pICMSST>
                         <vICMSST>12.96</vICMSST>
                     </ICMS70>
                     */
                    vBC = BaseDeCalculo - (BaseDeCalculo * (PercentualReducaoBcICMS / 100));
                    vICMS = vBC * ((UFDiferenteDoEmitente ? AliquotaICMS : AliquotaICMSST) / 100);
                    vBCIcmsST = (BaseDeCalculo + ValorIPI) * ((100 + MVA) / 100);
                    if (ReducaoBcIcmsST)
                        vBCIcmsST = vBCIcmsST - (vBCIcmsST * (PercentualReducaoBcICMSST / 100));

                    return new ICMS70
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        pRedBC = PercentualReducaoBcICMS,
                        vBC = BaseDeCalculo,
                        pICMS = AliquotaICMS,
                        vICMS = vICMS,
                        modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado,
                        pMVAST = MVA,
                        pRedBCST = PercentualReducaoBcICMSST,
                        vBCST = (BaseDeCalculo + ValorIPI) * (MVA / 100),
                        pICMSST = AliquotaICMSST,
                        vICMSST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS,
                    };
                case 90:
                    return new ICMS90
                    {
                        CST = ControllerFiscalUtil.CstICMSToZeus(CSTCSOSN),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString())
                    };

                /* Simples Nacional */
                case 101:
                    return new ICMSSN101
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        pCredSN = AliqPCred,
                        vCredICMSSN = BaseDeCalculo * (AliqPCred / 100)
                    };
                case 102:
                case 103:
                case 300:
                case 400:
                    return new ICMSSN102
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                    };
                case 201:
                    vICMS = BaseDeCalculo * (AliquotaICMS / 100);
                    vBCIcmsST = (BaseDeCalculo + ValorIPI) * ((100 + MVA) / 100);
                    if (ReducaoBcIcmsST)
                        vBCIcmsST = vBCIcmsST - (vBCIcmsST * (PercentualReducaoBcICMSST / 100));
                    ValorIcmsST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS;
                    return new ICMSSN201
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado,
                        vBCST = vBCIcmsST,
                        pCredSN = AliqPCred,
                        pMVAST = MVA,
                        pICMSST = AliquotaICMSST,
                        vICMSST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS,
                        vCredICMSSN = vBCIcmsST * (AliqPCred / 100),
                        pRedBCST = PercentualReducaoBcICMSST
                    };
                case 202:
                case 203:
                    vICMS = BaseDeCalculo * (AliquotaICMS / 100);
                    vBCIcmsST = (BaseDeCalculo + ValorIPI) * ((100 + MVA) / 100);
                    if (ReducaoBcIcmsST)
                        vBCIcmsST = vBCIcmsST - (vBCIcmsST * (PercentualReducaoBcICMSST / 100));
                    return new ICMSSN202
                    {
                        CSOSN = (Csosnicms)Enum.Parse(typeof(Csosnicms), CSTCSOSN.ToString()),
                        orig = (OrigemMercadoria)Enum.Parse(typeof(OrigemMercadoria), Origem.ToString()),
                        modBCST = DeterminacaoBaseIcmsSt.DbisMargemValorAgregado,
                        pMVAST = MVA,
                        pICMSST = AliquotaICMSST,
                        pRedBCST = PercentualReducaoBcICMSST,
                        vBCST = vBCIcmsST,
                        vICMSST = (vBCIcmsST * (AliquotaICMSST / 100)) - vICMS
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

        public static PISBasico GetPIS_NFe(int CST, decimal BaseDeCalculo, decimal Aliquota)
        {
            switch (CST)
            {
                case 01:
                case 02:
                    return CSTUtil.GetPisAliquota(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                case 03:
                    return CSTUtil.GetPisQuantidade(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                case 04:
                case 05:
                case 06:
                case 07:
                case 08:
                case 09:
                    return CSTUtil.GetPisNaoTributado(CST);
                case 49:
                case 99:
                    return CSTUtil.GetPisOutros(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                default:
                    return null;
            }
        }

        public static COFINSBasico GetCOFINS_NFe(int CST, decimal BaseDeCalculo, decimal Aliquota)
        {
            switch (CST)
            {
                case 01:
                case 02:
                    return CSTUtil.GetCofinsAliquota(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                case 03:
                    return CSTUtil.GetCofinsQuantidade(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                case 04:
                case 05:
                case 06:
                case 07:
                case 08:
                case 09:
                    return CSTUtil.GetCofinsNaoTributado(CST);
                case 49:
                case 99:
                    return CSTUtil.GetCofinsOutros(CST, BaseDeCalculo, Aliquota, BaseDeCalculo * (Aliquota / 100));
                default:
                    return null;
            }
        }

        public static IPIBasico GetIPI_NFe(int CST, decimal BaseDeCalculo, decimal Aliquota)
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
                case 3: //99                    
                case 9:  //51
                case 10: //52
                case 11: //53
                case 12: //54
                case 13: //55               
                    return new IPINT
                    {
                        CST = (CSTIPI)Enum.Parse(typeof(CSTIPI), CST.ToString())
                    };
                default:
                    return null;
            }
        }

        public static ICMSUFDest GetPartilha(decimal vBCPRod, decimal AliqInterEstadual, decimal AliqIntraEstadual, decimal AliqFCP)
        {
            //DIFAL = Base do ICMS * ((% Alíquota do ICMS Interno destino – % Alíquota do ICMS Interestadual) / 100)
            decimal pDifal = AliqIntraEstadual - AliqInterEstadual;
            decimal vDifal = vBCPRod * (pDifal / 100);
            decimal pICMSInterPart = DateTime.Now.Year >= 2019 ? 100 : 0;
            decimal vPartilha = 0;
            switch (DateTime.Now.Year)
            {
                case 2017:
                    pICMSInterPart = 60;
                    vPartilha = 100 - pICMSInterPart;
                    break;
                case 2018:
                    pICMSInterPart = 80;
                    vPartilha = 100 - pICMSInterPart;
                    break;
                case 2019:
                    vPartilha = 0;
                    break;
            }

            return new ICMSUFDest
            {
                vBCUFDest = vBCPRod,
                pFCPUFDest = AliqFCP,
                pICMSInter = AliqInterEstadual,
                pICMSUFDest = AliqIntraEstadual,
                pICMSInterPart = pICMSInterPart,
                vFCPUFDest = vBCPRod * (AliqFCP / 100),
                vICMSUFDest = vDifal * (pICMSInterPart / 100),
                vICMSUFRemet = vBCPRod * (vPartilha / 100)
            };
        }
    }
}