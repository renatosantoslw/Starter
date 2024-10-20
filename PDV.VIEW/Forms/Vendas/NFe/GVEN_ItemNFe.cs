using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using NFe.Classes.Informacoes.Emitente;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.FISCAL.Base.NFe;
using PDV.CONTROLLER.FISCAL.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_ItemNFe : DevExpress.XtraEditors.XtraForm
    {
        private List<Cfop> CFOPS = null;
        public Produto Prod = null;
        public IntegracaoFiscal Integ = null;
        private UnidadeFederativa UFDestinatario = null;
        private CRT CRTEmitente;
        public ProdutoNFe ProdutoNFe = null;
        private string NOME_TELA = "PRODUTO NF-E";

        private ICMSBasico ICMSProduto = null;
        private IPIBasico IPIProduto = null;
        private COFINSBasico COFINSBasico = null;
        private PISBasico PISBasico = null;
        private ICMSUFDest ICMSPartilha = null;
        // Partilha

        public DataRow DrProdutosNFeICMS = null;
        public DataRow DrProdutosNFePIS = null;
        public DataRow DrProdutosNFeCOFINS = null;
        public DataRow DrProdutosNFePARTILHA = null;

        public DataRow DrSaldoAlmoxarifado = null;

        public GVEN_ItemNFe(CRT CRT, UnidadeFederativa _UFDestinatario, DataRow ICMS, DataRow PIS, DataRow COFINS, DataRow Partilha)
        {
            InitializeComponent();
            UFDestinatario = _UFDestinatario;
            CRTEmitente = CRT;
            ProdutoNFe = new ProdutoNFe();
            CFOPS = FuncoesCFOP.GetCFOPSAtivos();
            ovCMB_CFOP.DataSource = CFOPS;
            ovCMB_CFOP.DisplayMember = "CODIGODESCRICAO";
            ovCMB_CFOP.ValueMember = "IDCFOP";
            ovCMB_CFOP.SelectedItem = null;

            DrProdutosNFeICMS = ICMS;
            DrProdutosNFePIS = PIS;
            DrProdutosNFeCOFINS = COFINS;
            DrProdutosNFePARTILHA = Partilha;

            ovTXT_Quantidade.AplicaAlteracoes();
            ovTXT_ValorUnitario.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_BCIcms.AplicaAlteracoes();
            ovTXT_BCIcmsST.AplicaAlteracoes();
            ovTXT_Despesas.AplicaAlteracoes();
            ovTXT_Seguro.AplicaAlteracoes();
            ovTXT_ValorIcms.AplicaAlteracoes();
            ovTXT_ValorIcmsST.AplicaAlteracoes();
            ovTXT_Frete.AplicaAlteracoes();
            ovTXT_ValorCreditoICMS.AplicaAlteracoes();
            ovTXT_ValorIPI.AplicaAlteracoes();
            ovTXT_ICMSDif.AplicaAlteracoes();
        }

        private void ovTXT_CodProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DataRow drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(ovTXT_CodProduto.Text.Trim());
                    if (drProduto == null)
                    {
                        MessageBox.Show(this, "Produto não encontrado.", NOME_TELA);
                        return;
                    }
                    Prod = FuncoesProduto.GetProduto(Convert.ToDecimal(drProduto["IDPRODUTO"]));
                    if (!Prod.IDIntegracaoFiscalNFe.HasValue)
                    {
                        Prod = null;
                        MessageBox.Show(this, "Produto não possui Integração Fiscal NF-e vinculado. Verifique e tente novamente.", NOME_TELA);
                        return;
                    }
                    Integ = FuncoesIntegracaoFiscal.GetIntegracao(Prod.IDIntegracaoFiscalNFe.Value);
                    PreencherTela();
                    break;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ProdutoNFe = null;
            Close();
        }

        private void ovTXT_CFOP_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ovTXT_CFOP.Text.Equals(string.Empty))
                        return;

                    GVEN_SeletorIntegracaoFiscal SeletorInteg = new GVEN_SeletorIntegracaoFiscal(Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_CFOP.Text)));
                    SeletorInteg.ShowDialog(this);

                    if (SeletorInteg.drIntegracao != null)
                    {
                        Integ = FuncoesIntegracaoFiscal.GetIntegracao(Convert.ToDecimal(SeletorInteg.drIntegracao["IDINTEGRACAOFISCAL"]));
                        ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.IDCfop == Convert.ToDecimal(FuncoesCFOP.GetCFOP(Integ.IDCFOP).Codigo)).FirstOrDefault();
                        CalcularTributos();
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EscolherProduto();

        }
        public void EscolherProduto(ItemVenda itemVenda = null)
        {
            
            var SeletorProduto = new GVEN_SeletorProduto(true);
            if (itemVenda != null)
            {
                Prod = FuncoesProduto.GetProduto(itemVenda.IDProduto);
                if (!Prod.IDIntegracaoFiscalNFe.HasValue)
                {
                    Prod = null;
                    MessageBox.Show(this, $"O produto {itemVenda.DescricaoItem} não possui Integração Fiscal NF-e vinculado. Verifique e tente novamente.", NOME_TELA);
                    return;
                }

                Integ = FuncoesIntegracaoFiscal.GetIntegracao(Prod.IDIntegracaoFiscalNFe.Value);
                PreencherTela(itemVenda);
                ovTXT_Quantidade.Value = itemVenda.Quantidade;
                ovTXT_Desconto.Value = itemVenda.DescontoValor * itemVenda.Quantidade;
                Salvar();
            }
            else
            {
                SeletorProduto.ShowDialog(this);
                if (SeletorProduto.drProduto != null)
                {
                    Prod = FuncoesProduto.GetProduto(Convert.ToDecimal(SeletorProduto.drProduto["IDPRODUTO"]));
                    if (!Prod.IDIntegracaoFiscalNFe.HasValue)
                    {
                        Prod = null;
                        MessageBox.Show(this, "Produto não possui Integração Fiscal NF-e vinculado. Verifique e tente novamente.", NOME_TELA);
                        return;
                    }
                    Integ = FuncoesIntegracaoFiscal.GetIntegracao(Prod.IDIntegracaoFiscalNFe.Value);
                    PreencherTela();
                }
            }
        }

        private void PreencherTela(ItemVenda itemVenda = null)
        {
            ovTXT_CodProduto.Text = Prod.EAN;
            ovTXT_Produto.Text = Prod.Descricao;
            if (itemVenda == null)
            {
                ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.IDCfop == Convert.ToDecimal(FuncoesCFOP.GetCFOP(Integ.IDCFOP).Codigo)).FirstOrDefault();
                ovTXT_ValorUnitario.Value = Prod.ValorVenda;
            }
            else
            {
                var venda = FuncoesVenda.GetVenda(itemVenda.IDVenda);
                var tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(venda.IDTipoDeOperacao);

              // MessageBox.Show(Integ.IDCFOP.ToString());

              // ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.IDCfop == Convert.ToDecimal(FuncoesCFOP.GetCFOP(tipoDeOperacao.IDOperacaoFiscal).Codigo)).FirstOrDefault();//

               ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.IDCfop == Convert.ToDecimal(FuncoesCFOP.GetCFOP(Integ.IDCFOP).Codigo)).FirstOrDefault();//


                // ovCMB_CFOP.SelectedItem = Integ.IDCFOP;


                ovTXT_ValorUnitario.Value = itemVenda.ValorUnitarioItem;
            }            
            

            if (FuncoesPerfilAcesso.ISEstoqueLiberado())
            {
                DrSaldoAlmoxarifado = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(Prod.IDAlmoxarifadoSaida.Value, Prod.IDProduto);

                if (DrSaldoAlmoxarifado != null)
                {
                    ovTXT_AlmoxarifadoSaida.Text = DrSaldoAlmoxarifado["ALMOXARIFADOENTRADA"].ToString();
                    ovTXT_Saldo.Text = Convert.ToDecimal(DrSaldoAlmoxarifado["SALDO"]).ToString("n4");

                    if (Prod.VenderSemSaldo == 1 && Convert.ToDecimal(DrSaldoAlmoxarifado["SALDO"]) <= 0)
                    {
                        ovTXT_AlmoxarifadoSaida.Text = "<Permitido Vender Item Sem Saldo>";
                        ovTXT_Saldo.Text = "0,0000";
                    }
                }
                else
                {
                    if (Prod.VenderSemSaldo == 0)
                    {
                        ovTXT_AlmoxarifadoSaida.Text = "<Almoxarifado Não Encontrado>";
                        ovTXT_Saldo.Text = "0,0000";
                    }
                    else
                    {
                        ovTXT_AlmoxarifadoSaida.Text = "<Permitido Vender Item Sem Saldo>";
                        ovTXT_Saldo.Text = "0,0000";
                    }
                }
            }
            else
            {
                ovTXT_AlmoxarifadoSaida.Text = "<Permitido Vender Item Sem Saldo>";
                ovTXT_Saldo.Text = "0,0000";
            }

            CalcularTributos();

            // tratar onde tiver CalcularTributos();
            // if (devolucao)
            //{
            //    campos.value = 0;
            //    campos.enable;
            //}

            
        }
        private void TrataRetornoICMS_SimplesNacional(ICMSBasico ICMSCalculado)
        {
            if (ICMSCalculado.GetType() == typeof(ICMSSN101))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ValorIcmsST.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorCreditoICMS.Value = (ICMSCalculado as ICMSSN101).vCredICMSSN;
            }

            if (ICMSCalculado.GetType() == typeof(ICMSSN102) || ICMSCalculado.GetType() == typeof(ICMSSN500) || ICMSCalculado.GetType() == typeof(ICMSSN900))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ValorIcmsST.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorCreditoICMS.Value = 0;
            }

            if (ICMSCalculado.GetType() == typeof(ICMSSN201))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = (ICMSCalculado as ICMSSN201).vBCST;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcmsST.Value = (ICMSCalculado as ICMSSN201).vICMSST;
                ovTXT_ValorCreditoICMS.Value = (ICMSCalculado as ICMSSN201).vCredICMSSN;
            }

            if (ICMSCalculado.GetType() == typeof(ICMSSN202))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = (ICMSCalculado as ICMSSN202).vBCST;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcmsST.Value = (ICMSCalculado as ICMSSN202).vICMSST;
                ovTXT_ValorCreditoICMS.Value = 0;
            }
        }

        private void TrataRetornoICMS_RegimeNormal(ICMSBasico ICMSCalculado)
        {
            if (ICMSCalculado.GetType() == typeof(ICMS00))
            {
                ovTXT_BCIcms.Value = (ICMSCalculado as ICMS00).vBC;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcms.Value = (ICMSCalculado as ICMS00).vICMS;
                ovTXT_ValorIcmsST.Value = 0;

                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS10))
            {
                ovTXT_BCIcms.Value = (ICMSCalculado as ICMS10).vBC;
                ovTXT_BCIcmsST.Value = (ICMSCalculado as ICMS10).vBCST;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcms.Value = (ICMSCalculado as ICMS10).vICMS;
                ovTXT_ValorIcmsST.Value = (ICMSCalculado as ICMS10).vICMSST;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS20))
            {
                ovTXT_BCIcms.Value = (ICMSCalculado as ICMS20).vBC;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcms.Value = (ICMSCalculado as ICMS20).vICMS;
                ovTXT_ValorIcmsST.Value = 0;
                ovTXT_Seguro.Value = 0;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_Seguro.Enabled = false;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS30))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = (ICMSCalculado as ICMS30).vBCST;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcmsST.Value = (ICMSCalculado as ICMS30).vICMSST;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS40) || ICMSCalculado.GetType() == typeof(ICMS60) || ICMSCalculado.GetType() == typeof(ICMS90))
            {
                ovTXT_BCIcms.Value = 0;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ValorIcms.Value = 0;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcmsST.Value = 0;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS51))
            {
                ovTXT_BCIcms.Value = (ICMSCalculado as ICMS51).vBC ?? 0;
                ovTXT_BCIcmsST.Value = 0;
                ovTXT_ValorIcms.Value = (ICMSCalculado as ICMS51).vICMS ?? 0;
                ovTXT_ICMSDif.Value = (ICMSCalculado as ICMS51).vICMSDif ?? 0;
                ovTXT_ValorIcmsST.Value = 0;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }

            if (ICMSCalculado.GetType() == typeof(ICMS70))
            {
                ovTXT_BCIcms.Value = (ICMSCalculado as ICMS70).vBC;
                ovTXT_BCIcmsST.Value = (ICMSCalculado as ICMS70).vBCST;
                ovTXT_ICMSDif.Value = 0;
                ovTXT_ValorIcms.Value = (ICMSCalculado as ICMS70).vICMS;
                ovTXT_ValorIcmsST.Value = (ICMSCalculado as ICMS70).vICMSST;
                ovTXT_ValorCreditoICMS.Value = 0;
                ovTXT_ValorCreditoICMS.Enabled = false;
            }
        }

        private void TrataRetornoIPI(IPIBasico IPI)
        {
            if (IPI.GetType() == typeof(IPITrib))
                ovTXT_ValorIPI.Value = (IPI as IPITrib).vIPI ?? 0;
        }

        private void CalcularTributos()
        {
            UnidadeFederativa UFEmitente = FuncoesUF.GetUnidadesFederativaComAliquotasICMS(FuncoesEmitente.GetEmitente().IDEmitente);
            bool UFDiferenteEmitente = UFDestinatario.IDUnidadeFederativa != UFEmitente.IDUnidadeFederativa;

            decimal BaseCalculo = ((ovTXT_ValorUnitario.Value * ovTXT_Quantidade.Value) + ovTXT_Frete.Value + ovTXT_Despesas.Value + ovTXT_Seguro.Value) - ovTXT_Desconto.Value;

            OrigemProduto Origem = FuncoesOrigemProduto.GetOrigemProduto(Prod.IDOrigemProduto);
            CSTIcms Icms = FuncoesCst.GetCSTIcmsPorID(Integ.IDCSTIcms);
            CSTIpi Ipi = FuncoesCst.GetCSTIpi(Integ.IDCSTIpi);
            CSTPis Pis = FuncoesCst.GetCSTPis(Integ.IDCSTPis);
            CSTCofins Cofins = FuncoesCst.GetCSTCofins(Integ.IDCSTCofins);

            switch (CRTEmitente)
            {
                case CRT.SimplesNacional:
                    ICMSProduto = Imposto.GetICMS_NFe(Convert.ToInt32(Icms.CSTCSOSN),
                                                      Convert.ToInt32(Origem.Codigo),
                                                      BaseCalculo,
                                                      Integ.ICMS_ST == 1 ? (Integ.ICMS_ST_CDIFERENCIADO == 1 ? Integ.ICMS_ST_DIFERENCIADO : UFDestinatario.AliquotaIntra) : 0,
                                                      Integ.ICMS == 1 ? (Integ.ICMS_CDIFERENCIADO == 1 ? Integ.ICMS_DIFERENCIADO : UFDestinatario.AliquotaInter) : 0,
                                                      Integ.ICMS_RED == 1 ? Prod.Trib_RedBCICMS : 0,
                                                      Integ.ICMS_REDST == 1 ? Prod.Trib_RedBCICMSST : 0,
                                                      Prod.Trib_MVA,
                                                      Integ.IPI == 1 && Ipi.CST == 2 ? Prod.Trib_AliqIPI : 0,
                                                      (BaseCalculo == 0 ?0:ovTXT_ValorCreditoICMS.Value / BaseCalculo) * 100,
                                                      Integ.ICMS_DIF == 1 ? Prod.Trib_AliqICMSDif : 0,
                                                      Integ.ICMS_REDST == 1,
                                                      UFDiferenteEmitente);
                    IPIProduto = Imposto.GetIPI_NFe(Convert.ToInt32(Ipi.CST), BaseCalculo, Prod.Trib_AliqIPI);
                    COFINSBasico = Imposto.GetCOFINS_NFe(Convert.ToInt32(Cofins.CST), BaseCalculo, Prod.Trib_AliqCOFINS);
                    PISBasico = Imposto.GetPIS_NFe(Convert.ToInt32(Pis.CST), BaseCalculo, Prod.Trib_AliqPIS);
                    ICMSPartilha = Imposto.GetPartilha(BaseCalculo, UFDestinatario.AliquotaInter, UFDestinatario.AliquotaIntra, UFDestinatario.FCP);

                    TrataRetornoICMS_SimplesNacional(ICMSProduto);
                    TrataRetornoIPI(IPIProduto);
                    break;
                case CRT.RegimeNormal:
                case CRT.SimplesNacionalExcessoSublimite:
                    ICMSProduto = Imposto.GetICMS_NFe(Convert.ToInt32(Icms.CSTCSOSN),
                                                      Convert.ToInt32(Origem.Codigo),
                                                      BaseCalculo,
                                                      Integ.ICMS_ST == 1 ? (Integ.ICMS_ST_CDIFERENCIADO == 1 ? Integ.ICMS_ST_DIFERENCIADO : UFDestinatario.AliquotaIntra) : 0,
                                                      Integ.ICMS == 1 ? (Integ.ICMS_CDIFERENCIADO == 1 ? Integ.ICMS_DIFERENCIADO : UFDestinatario.AliquotaInter) : 0,
                                                      Integ.ICMS_RED == 1 ? Prod.Trib_RedBCICMS : 0,
                                                      Integ.ICMS_REDST == 1 ? Prod.Trib_RedBCICMSST : 0,
                                                      Prod.Trib_MVA,
                                                      Integ.IPI == 1 && Ipi.CST == 2 ? Prod.Trib_AliqIPI : 0,
                                                      0,
                                                      Integ.ICMS_DIF == 1 ? Prod.Trib_AliqICMSDif : 0,
                                                      Integ.ICMS_REDST == 1,
                                                      UFDiferenteEmitente);
                    IPIProduto = Imposto.GetIPI_NFe(Convert.ToInt32(Ipi.CST), BaseCalculo, Prod.Trib_AliqIPI);
                    COFINSBasico = Imposto.GetCOFINS_NFe(Convert.ToInt32(Cofins.CST), BaseCalculo, Prod.Trib_AliqCOFINS);
                    PISBasico = Imposto.GetPIS_NFe(Convert.ToInt32(Pis.CST), BaseCalculo, Prod.Trib_AliqPIS);
                    ICMSPartilha = Imposto.GetPartilha(BaseCalculo, UFDestinatario.AliquotaInter, UFDestinatario.AliquotaIntra, UFDestinatario.FCP);

                    TrataRetornoICMS_RegimeNormal(ICMSProduto);
                    TrataRetornoIPI(IPIProduto);
                    break;
            }

            ovTXT_ValorTotal.Text = (BaseCalculo + ovTXT_ValorIcmsST.Value).ToString("c2");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            CalcularTributos();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Salvar(true);
        }
        private void Salvar(bool manualmente = false)
        {
            if (Prod == null)
            {
                MessageBox.Show(this, "Selecione o Produto", NOME_TELA);
                return;
            }

            if (ovTXT_ValorUnitario.Value == 0)
            {
                MessageBox.Show(this, "O Valor Unitário não pode ser zero.", NOME_TELA);
                return;
            }

            //if (FuncoesPerfilAcesso.ISEstoqueLiberado())
            //{
            //    // Verificar Saldo...
            //    if (Prod.VenderSemSaldo == 0)
            //    {
            //        if (DrSaldoAlmoxarifado == null)
            //        {
            //           // MessageBox.Show(this, "Produto sem Saldo em Estoque. Verifique!", NOME_TELA);
            //            //return;
            //        }
            //        Produto produto = FuncoesProduto.GetProduto(Convert.ToDecimal(DrSaldoAlmoxarifado[7]));
            //        if (ovTXT_Quantidade.Value > produto.SaldoEstoque && manualmente)
            //        {
            //            //MessageBox.Show(this, "Saldo do Produto em Estoque é menor que a Quantidade solicitada.", NOME_TELA);
            //            //return;
            //        }
            //    }
            //}

            CalcularTributos();

            ProdutoNFe.IDProduto = Prod.IDProduto;
            ProdutoNFe.IDUnidadeDeMedida = Prod.IDUnidadeDeMedida;
            ProdutoNFe.IDProdutoNFe = Sequence.GetNextID("PRODUTONFE", "IDPRODUTONFE");
            ProdutoNFe.IDCFOP = (ovCMB_CFOP.SelectedItem as Cfop).IDCfop;
            ProdutoNFe.Desconto = ovTXT_Desconto.Value;
            ProdutoNFe.Frete = ovTXT_Frete.Value;
            ProdutoNFe.OutrasDespesas = ovTXT_Despesas.Value;
            ProdutoNFe.Quantidade = ovTXT_Quantidade.Value;
            ProdutoNFe.ValorUnitario = ovTXT_ValorUnitario.Value;
            ProdutoNFe.IDIntegracaoFiscal = Integ.IDIntegracaoFiscal;
            ProdutoNFe.Seguro = ovTXT_Seguro.Value;

            PreencherDrICMS();
            PreencherDrPIS();
            PreencherDrCOFINS();
            PreencherPartilhaICMS();

            Close();
        }
        public void PreencherDrICMS()
        {
            /* Simples Nacional */
            if (ICMSProduto.GetType() == typeof(ICMSSN101))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN101).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN101).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    PCredSN = (ICMSProduto as ICMSSN101).pCredSN,
                    VCredIcmsSN = (ICMSProduto as ICMSSN101).vCredICMSSN
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMSSN102))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN102).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN102).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMSSN500))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN500).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN500).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMSSN900))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN900).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN900).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMSSN201))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN201).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN201).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    PMVAST = (ICMSProduto as ICMSSN201).pMVAST ?? 0,
                    PRedBcST = (ICMSProduto as ICMSSN201).pRedBCST ?? 0,
                    ModBCST = (int)(ICMSProduto as ICMSSN201).modBCST,
                    VBcST = (ICMSProduto as ICMSSN201).vBCST,
                    VIcmsST = (ICMSProduto as ICMSSN201).vICMSST,
                    PIcmsST = (ICMSProduto as ICMSSN201).pICMSST,
                    VCredIcmsSN = (ICMSProduto as ICMSSN201).vCredICMSSN,
                    PCredSN = (ICMSProduto as ICMSSN201).pCredSN,
                    PIcms = Integ.ICMS == 1 ? (Integ.ICMS_CDIFERENCIADO == 1 ? Integ.ICMS_DIFERENCIADO : UFDestinatario.AliquotaInter) : 0
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMSSN202))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo((int)(ICMSProduto as ICMSSN202).CSOSN).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMSSN202).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    ModBCST = (int)(ICMSProduto as ICMSSN202).modBCST,
                    PMVAST = (ICMSProduto as ICMSSN202).pMVAST ?? 0,
                    PIcmsST = (ICMSProduto as ICMSSN202).pICMSST,
                    PRedBcST = (ICMSProduto as ICMSSN202).pRedBCST ?? 0,
                    VBcST = (ICMSProduto as ICMSSN202).vBCST,
                    VIcmsST = (ICMSProduto as ICMSSN202).vICMSST,
                    PIcms = Integ.ICMS == 1 ? (Integ.ICMS_CDIFERENCIADO == 1 ? Integ.ICMS_DIFERENCIADO : UFDestinatario.AliquotaInter) : 0
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            /* Regime Normal */
            if (ICMSProduto.GetType() == typeof(ICMS00))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS00).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS00).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    ModBC = (int)(ICMSProduto as ICMS00).modBC,
                    VBc = (ICMSProduto as ICMS00).vBC,
                    PIcms = (ICMSProduto as ICMS00).pICMS,
                    VIcms = (ICMSProduto as ICMS00).vICMS
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS10))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS10).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS10).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    PIcms = (ICMSProduto as ICMS10).pICMS,
                    VIcms = (ICMSProduto as ICMS10).vICMS,
                    PIcmsST = (ICMSProduto as ICMS10).pICMSST,
                    PMVAST = (ICMSProduto as ICMS10).pMVAST ?? 0,
                    VBcST = (ICMSProduto as ICMS10).vBCST,
                    VIcmsST = (ICMSProduto as ICMS10).vICMSST,
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS20))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS20).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS20).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    ModBC = (int)(ICMSProduto as ICMS20).modBC,
                    PIcms = (ICMSProduto as ICMS20).pICMS,
                    PRedBC = (ICMSProduto as ICMS20).pRedBC,
                    VBc = (ICMSProduto as ICMS20).vBC,
                    VIcms = (ICMSProduto as ICMS20).vICMS
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS30))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS30).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS30).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,

                    ModBCST = (int)(ICMSProduto as ICMS30).modBCST,
                    PMVAST = (int)(ICMSProduto as ICMS30).pMVAST,
                    PRedBcST = (int)(ICMSProduto as ICMS30).pRedBCST,
                    VBcST = (int)(ICMSProduto as ICMS30).vBCST,
                    PIcmsST = (int)(ICMSProduto as ICMS30).pICMSST,
                    VIcmsST = (int)(ICMSProduto as ICMS30).vICMSST,
                    PIcms = Integ.ICMS == 1 ? (Integ.ICMS_CDIFERENCIADO == 1 ? Integ.ICMS_DIFERENCIADO : UFDestinatario.AliquotaInter) : 0,
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS40) || ICMSProduto.GetType() == typeof(ICMS60) || ICMSProduto.GetType() == typeof(ICMS90))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS40).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS40).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS51))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS()
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS51).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS51).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    VBc = (ICMSProduto as ICMS51).vBC ?? 0,
                    VIcms = (ICMSProduto as ICMS51).vICMS ?? 0,
                    ModBC = (int)(ICMSProduto as ICMS51).modBC,
                    PDif = (ICMSProduto as ICMS51).pDif ?? 0,
                    PIcms = (ICMSProduto as ICMS51).pICMS ?? 0,
                    VIcmsDif = (ICMSProduto as ICMS51).vICMSDif ?? 0
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS60))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS()
                {
                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS60).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS60).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                }, DrProdutosNFeICMS, DateTime.Now);
            }

            if (ICMSProduto.GetType() == typeof(ICMS70))
            {
                EntityUtil<ProdutoNFeICMS>.ParseToDataRow(new ProdutoNFeICMS()
                {

                    IDCstICMS = FuncoesCst.GetCSTIcmsPorCodigo(Convert.ToInt32(ControllerFiscalUtil.CstICMSParaString((ICMSProduto as ICMS70).CST))).IDCSTIcms,
                    IDOrigemProduto = FuncoesOrigemProduto.GetOrigemProdutoPorCodigo((int)(ICMSProduto as ICMS70).orig).IDOrigemProduto,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDUnidadeFederativaST = UFDestinatario.IDUnidadeFederativa,
                    IDProdutoNFeICMS = Sequence.GetNextID("IDPRODUTONFEICMS"),
                    ModBC = (int)(ICMSProduto as ICMS70).modBC,
                    PRedBC = (ICMSProduto as ICMS70).pRedBC,
                    VBc = (ICMSProduto as ICMS70).vBC,
                    PIcms = (ICMSProduto as ICMS70).pICMS,
                    VIcms = (ICMSProduto as ICMS70).vICMS,
                    ModBCST = (int)(ICMSProduto as ICMS70).modBCST,
                    PMVAST = (ICMSProduto as ICMS70).pMVAST ?? 0,
                    PRedBcST = (ICMSProduto as ICMS70).pRedBCST ?? 0,
                    VBcST = (ICMSProduto as ICMS70).vBCST,
                    PIcmsST = (ICMSProduto as ICMS70).pICMSST,
                    VIcmsST = (ICMSProduto as ICMS70).vICMSST
                }, DrProdutosNFeICMS, DateTime.Now);
            }
        }
        private void PreencherDrPIS()
        {
            if (PISBasico.GetType() == typeof(PISAliq))
            {
                EntityUtil<ProdutoNFePIS>.ParseToDataRow(new ProdutoNFePIS
                {
                    IDCstPIS = FuncoesCst.GetCSTPisPorCST((int)(PISBasico as PISAliq).CST).IDCSTPis,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFePIS = Sequence.GetNextID("IDPRODUTONFEPIS"),
                    PPis = (PISBasico as PISAliq).pPIS,
                    VBc = (PISBasico as PISAliq).vBC,
                    VPis = (PISBasico as PISAliq).vPIS
                }, DrProdutosNFePIS, DateTime.Now);
            }
            if (PISBasico.GetType() == typeof(PISQtde))
            {
                EntityUtil<ProdutoNFePIS>.ParseToDataRow(new ProdutoNFePIS
                {
                    IDCstPIS = FuncoesCst.GetCSTPisPorCST((int)(PISBasico as PISQtde).CST).IDCSTPis,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFePIS = Sequence.GetNextID("IDPRODUTONFEPIS"),
                    PPis = (PISBasico as PISQtde).vAliqProd,
                    VBc = (PISBasico as PISQtde).qBCProd,
                    VPis = (PISBasico as PISQtde).vPIS
                }, DrProdutosNFePIS, DateTime.Now);
            }
            if (PISBasico.GetType() == typeof(PISNT))
            {
                EntityUtil<ProdutoNFePIS>.ParseToDataRow(new ProdutoNFePIS
                {
                    IDCstPIS = FuncoesCst.GetCSTPisPorCST((int)(PISBasico as PISNT).CST).IDCSTPis,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFePIS = Sequence.GetNextID("IDPRODUTONFEPIS"),
                }, DrProdutosNFePIS, DateTime.Now);
            }
            if (PISBasico.GetType() == typeof(PISOutr))
            {
                EntityUtil<ProdutoNFePIS>.ParseToDataRow(new ProdutoNFePIS
                {
                    IDCstPIS = FuncoesCst.GetCSTPisPorCST((int)(PISBasico as PISOutr).CST).IDCSTPis,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFePIS = Sequence.GetNextID("IDPRODUTONFEPIS"),
                    PPis = (PISBasico as PISOutr).pPIS ?? 0,
                    VBc = (PISBasico as PISOutr).vBC ?? 0,
                    VPis = (PISBasico as PISOutr).vPIS ?? 0
                }, DrProdutosNFePIS, DateTime.Now);
            }
        }
        private void PreencherDrCOFINS()
        {
            if (COFINSBasico.GetType() == typeof(COFINSAliq))
            {
                EntityUtil<ProdutoNFeCOFINS>.ParseToDataRow(new ProdutoNFeCOFINS
                {
                    IDCstCOFINS = FuncoesCst.GetCSTCofinsPorCST((int)(COFINSBasico as COFINSAliq).CST).IDCSTCofins,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeCOFINS = Sequence.GetNextID("IDPRODUTONFECOFINS"),
                    PCOFINS = (COFINSBasico as COFINSAliq).pCOFINS,
                    VBc = (COFINSBasico as COFINSAliq).vBC,
                    VCOFINS = (COFINSBasico as COFINSAliq).vCOFINS
                }, DrProdutosNFeCOFINS, DateTime.Now);
            }
            if (COFINSBasico.GetType() == typeof(COFINSQtde))
            {
                EntityUtil<ProdutoNFeCOFINS>.ParseToDataRow(new ProdutoNFeCOFINS
                {
                    IDCstCOFINS = FuncoesCst.GetCSTCofinsPorCST((int)(COFINSBasico as COFINSQtde).CST).IDCSTCofins,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeCOFINS = Sequence.GetNextID("IDPRODUTONFECOFINS"),
                    PCOFINS = (COFINSBasico as COFINSQtde).vAliqProd,
                    VBc = (COFINSBasico as COFINSQtde).qBCProd,
                    VCOFINS = (COFINSBasico as COFINSQtde).vCOFINS
                }, DrProdutosNFeCOFINS, DateTime.Now);
            }
            if (COFINSBasico.GetType() == typeof(COFINSNT))
            {
                EntityUtil<ProdutoNFeCOFINS>.ParseToDataRow(new ProdutoNFeCOFINS
                {
                    IDCstCOFINS = FuncoesCst.GetCSTCofinsPorCST((int)(COFINSBasico as COFINSNT).CST).IDCSTCofins,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeCOFINS = Sequence.GetNextID("IDPRODUTONFECOFINS"),
                }, DrProdutosNFeCOFINS, DateTime.Now);
            }
            if (COFINSBasico.GetType() == typeof(COFINSOutr))
            {
                EntityUtil<ProdutoNFeCOFINS>.ParseToDataRow(new ProdutoNFeCOFINS
                {
                    IDCstCOFINS = FuncoesCst.GetCSTCofinsPorCST((int)(COFINSBasico as COFINSOutr).CST).IDCSTCofins,
                    IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                    IDProdutoNFeCOFINS = Sequence.GetNextID("IDPRODUTONFECOFINS"),
                    PCOFINS = (COFINSBasico as COFINSOutr).pCOFINS ?? 0,
                    VBc = (COFINSBasico as COFINSOutr).vBC ?? 0,
                    VCOFINS = (COFINSBasico as COFINSOutr).vCOFINS ?? 0
                }, DrProdutosNFeCOFINS, DateTime.Now);
            }
        }
        private void PreencherPartilhaICMS()
        {
            EntityUtil<ProdutoNFePartilhaICMS>.ParseToDataRow(new ProdutoNFePartilhaICMS
            {
                VBcUFDest = ICMSPartilha.vBCUFDest,
                PFcpUFDest = ICMSPartilha.pFCPUFDest.Value,
                PIcmsInter = ICMSPartilha.pICMSInter,
                PIcmsUFDest = ICMSPartilha.pICMSUFDest,
                PIcmsInterPart = ICMSPartilha.pICMSInterPart,
                VFcpUFDest = ICMSPartilha.vFCPUFDest.Value,
                VIcmsUFDest = ICMSPartilha.vICMSUFDest,
                VIcmsUFRemet = ICMSPartilha.vICMSUFRemet,
                IDProdutoNFe = ProdutoNFe.IDProdutoNFe,
                IDProdutoNFePartilhaICMS = Sequence.GetNextID("IDPRODUTONFEPARTILHAICMS")
            }, DrProdutosNFePARTILHA, DateTime.Now);
        }

        private void ovTXT_Quantidade_Leave(object sender, EventArgs e)
        {
            CalcularTributos();
        }
    }
}