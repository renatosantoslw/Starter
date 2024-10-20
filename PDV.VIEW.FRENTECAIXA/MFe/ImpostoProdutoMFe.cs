using DFe.Classes.Flags;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Emitente;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.FISCAL.Base.NFCe;
using PDV.CONTROLLER.NFCE.Util;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA.MFe
{
    public static class ImpostoProdutoMFe
    {
        public static  det GetDetalhe(DAO.Entidades.PDV.Venda VENDA , ItemVenda Item, int i, CRT crt, ModeloDocumento modelo, Emitente EMITENTE)
        {
            List<TributoNFCe> ListaDeTributos = new List<TributoNFCe>();
            Produto _Produto = FuncoesProduto.GetProduto(Item.IDProduto);
            _Produto.EAN = _Produto.EAN;
            Ncm NcmVigente = FuncoesNcm.GetItemTributoVigente(FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo, string.IsNullOrEmpty(_Produto.EXTipi) ? null : (decimal?)Convert.ToDecimal(_Produto.EXTipi), VENDA.DataCadastro);
            if (NcmVigente == null)
            {
                throw new Exception(string.Format("O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", _Produto.Descricao));
            }

            decimal ValorTributosNacional = (_Produto.ValorVenda * (NcmVigente.NacionalFederal / 100)) * Item.Quantidade;
            decimal ValorTributosEstadual = (_Produto.ValorVenda * (NcmVigente.Estadual / 100)) * Item.Quantidade;
            decimal ValorTributosMunicipal = (_Produto.ValorVenda * (NcmVigente.Municipal / 100)) * Item.Quantidade;

            ListaDeTributos.Add(new TributoNFCe()
            {
                IDProduto = _Produto.IDProduto,
                PercentualEstadual = ValorTributosEstadual,
                PercentualFederal = ValorTributosNacional,
                PercentualMunicipal = ValorTributosMunicipal,
                NCM = NcmVigente
            });

            if (!_Produto.IDIntegracaoFiscalNFCe.HasValue)
            {
                throw new Exception("Produto sem Integração Fiscal NFC-e configurada. Verifique e tente novamente.");
            }

            IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(_Produto.IDIntegracaoFiscalNFCe.Value);
            decimal BaseCalculo = (Item.Subtotal - Item.DescontoValor);

            prod Prod = Produtos.GetProduto(_Produto.Descricao, _Produto.IDProduto, _Produto.EAN, FuncoesNcm.GetNCM(_Produto.IDNCM).Codigo.ToString(), Convert.ToInt32(FuncoesCFOP.GetCFOP(FuncoesIntegracaoFiscal.GetIntegracao(_Produto.IDIntegracaoFiscalNFCe.Value).IDCFOP).Codigo), FuncoesUnidadeMedida.GetUnidadeMedida(_Produto.IDUnidadeDeMedida).Sigla, Item.Quantidade, Item.ValorUnitarioItem, Item.DescontoValor, _Produto.CEST, _Produto.EXTipi);
            det Det = Detalhe.GetDetalhe(Prod, new imposto
            {
                vTotTrib = ValorTributosNacional + ValorTributosEstadual + ValorTributosMunicipal,

                //ICMSUFDest = new ICMSUFDest()
                //{
                //    pFCPUFDest = 0,
                //    pICMSInter = 0,
                //    pICMSInterPart = 0,
                //    pICMSUFDest = 0,
                //    vBCUFDest = 0,
                //    vFCPUFDest = 0,
                //    vICMSUFDest = 0,
                //    vICMSUFRemet = 0
                //},
                ICMS = new ICMS
                {
                    TipoICMS = Imposto.GetICMS(Convert.ToInt32(FuncoesCst.GetCSTIcmsPorID(Integ.IDCSTIcms).CSTCSOSN),
                            Convert.ToInt32(FuncoesOrigemProduto.GetOrigemProduto(_Produto.IDOrigemProduto).Codigo),
                            BaseCalculo,
                            Integ.ICMS == 0 ? 0 : (Integ.ICMS_CDIFERENCIADO == 1 ? FuncoesUF.GetUnidadesFederativaComAliquotasICMS(EMITENTE.IDEmitente).AliquotaIntra : Integ.ICMS_DIFERENCIADO),
                            Integ.ICMS_RED == 1 ? _Produto.Trib_RedBCICMS : 0,
                            Integ.ICMS_DIF == 1 ? _Produto.Trib_AliqICMSDif : 0)
                }
            }, ValorTributosNacional, ValorTributosEstadual, ValorTributosMunicipal, NcmVigente.Chave, i + 1);
            //    Det.imposto.ICMSUFDest.pICMSInter = 0;
            //    Det.imposto.ICMSUFDest.pICMSInterPart = 0;



            switch (crt)
            {
                case CRT.RegimeNormal:
                case CRT.SimplesNacionalExcessoSublimite:
                    Det.imposto.COFINS = new COFINS { TipoCOFINS = Imposto.GetCofins(Convert.ToInt32(FuncoesCst.GetCSTCofins(Integ.IDCSTCofins).CST), BaseCalculo, _Produto.Trib_AliqCOFINS) };
                    Det.imposto.PIS = new PIS { TipoPIS = Imposto.GetPis(Convert.ToInt32(FuncoesCst.GetCSTCofins(Integ.IDCSTPis).CST), BaseCalculo, _Produto.Trib_AliqPIS) };
                    // IPI Não Envia na NFC-e

                    break;
            }
            return Det;
        }

    }
}
