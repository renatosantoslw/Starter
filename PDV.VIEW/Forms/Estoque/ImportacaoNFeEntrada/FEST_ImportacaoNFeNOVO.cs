using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
//using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;
using DFe.Classes.Entidades;
using DFe.Utils;
using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.NFeImportacao;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL;
using PDV.VIEW.App_Context;
//using PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada.UControl;
using PDV.VIEW.Forms.Gerenciamento.DAC;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    public partial class FEST_ImportacaoNFeNOVO : DevExpress.XtraEditors.XtraForm
    {
        //UC_ItemNFeEntradaNOVO UCControl = new UC_ItemNFeEntradaNOVO();

        private NFeEntrada NFeEntrada = null;

        public static List<ItemNFeEntrada> Itens = null;

        private PedidoCompra PedidoCompra = null;

        private Fornecedor Fornecedor = null;

        private Transportadora Transportadora = null;

        private decimal somaTotalParcelas = 0;

        private string NOME_TELA = "IMPORTAÇÃO DA NF-E";

        NFe.Classes.NFe ArquivoNFe = null;
        public FEST_ImportacaoNFeNOVO(NFe.Classes.NFe _ArquivoNFe)
        {
            InitializeComponent();
            ArquivoNFe = _ArquivoNFe;

            //Deposito
            cboDeposito.DataSource = FuncoesAlmoxarifado.GetAlmoxarifados();
            cboDeposito.DisplayMember = "DESCRICAOAPRESENTACAO";
            cboDeposito.ValueMember = "IDALMOXARIFADO";
            cboDeposito.SelectedItem = null;

            //icones
            Bitmap bitmapIncluirTodos = IconChar.AngleDoubleDown.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

            Bitmap bitmapLimparTudo = IconChar.TrashAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapAdicionar  = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapCancelarParcela = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizarPreco = IconChar.FileInvoiceDollar.ToBitmap(Color.DarkGreen, 20);



            simpleButton1.ImageOptions.Image = bitmapAtualizarPreco;

            //simpleButton1.ImageOptions.Image = bitmapIncluirTodos;
            simpleButton2.ImageOptions.Image = bitmapCancelar;
            metroButton4.ImageOptions.Image  = bitmapSalvar;
            metroButton11.ImageOptions.Image = bitmapAdicionar;
            simpleButtonCancelarParcela.ImageOptions.Image = bitmapCancelarParcela;
            metroButton9.ImageOptions.Image = bitmapLimparTudo;

            FORMASPAGAMENTO = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = FORMASPAGAMENTO;
            ovCMB_FormaPagamento.ValueMember = "IDFORMADEPAGAMENTO";
            ovCMB_FormaPagamento.DisplayMember = "IDENTIFICACAODESCRICAOFORMABANDEIRA";
            ovCMB_FormaPagamento.SelectedItem = null;

            List<TipoDeOperacao> listTipoDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(TipoDeOperacao.Entrada);
            metroComboBoxTipoDeOperacao.DataSource = listTipoDeOperacao;
            metroComboBoxTipoDeOperacao.ValueMember = "IDTIPODEOPERACAO";
            metroComboBoxTipoDeOperacao.DisplayMember = "NOME";
            metroComboBoxTipoDeOperacao.SelectedItem = null;

            PreencherObjetoNFe();
            PreencherTela();

            labelFaltaValor.Text = ovTXT_TotalNFe.Text;
            labelTrocoValor.Text = "R$ 0,00";

            metroTabControl2.SelectedTab = metroTabPage5;
        }

        public FEST_ImportacaoNFeNOVO()
        {
            InitializeComponent();          
        }

        private void PreencherObjetoNFe()
        {
            try
            {
                Fornecedor = FuncoesFornecedor.GetFornecedorPorCNPJ(ArquivoNFe.infNFe.emit.CNPJ);
                if (Fornecedor == null)
                {
                    decimal idUF = FuncoesUF.GetUnidadeFederativa(ArquivoNFe.infNFe.emit.enderEmit.UF.ToString()).IDUnidadeFederativa;

                    var IDEndereco_endereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                    var cep_endereco = ArquivoNFe.infNFe.emit.enderEmit.CEP;
                    var uf_endereco = ArquivoNFe.infNFe.emit.enderEmit.UF.ToString();
                    var bairro_endereco = ArquivoNFe.infNFe.emit.enderEmit.xBairro;
                    var logradouro_endereco = ArquivoNFe.infNFe.emit.enderEmit.xLgr;
                    var numero_endereco = ArquivoNFe.infNFe.emit.enderEmit.nro;
                    var complemento_endereco = ArquivoNFe.infNFe.emit.enderEmit.xCpl;
                    var telefone_endereco = ArquivoNFe.infNFe.emit.enderEmit.fone.ToString();

                    Endereco endereco = new Endereco()
                    {
                        IDEndereco = IDEndereco_endereco,
                        Cep = cep_endereco,
                        UnidadeFederativa = uf_endereco,
                        Bairro = bairro_endereco,
                        Logradouro = logradouro_endereco,
                        Numero = numero_endereco,
                        Complemento = complemento_endereco,
                        Telefone = telefone_endereco,
                        IDUnidadeFederativa = idUF
                    };

                    Fornecedor = new Fornecedor()
                    {
                        IDFornecedor = Sequence.GetNextID("FORNECEDOR", "IDFORNECEDOR"),
                        IDEndereco = endereco.IDEndereco,
                        Descricao= ArquivoNFe.infNFe.emit.xFant == null ? ArquivoNFe.infNFe.emit.xNome : ArquivoNFe.infNFe.emit.xFant,
                        //Descricao = ArquivoNFe.infNFe.emit.xFant,
                        RazaoSocial = ArquivoNFe.infNFe.emit.xFant == null ? ArquivoNFe.infNFe.emit.xNome : ArquivoNFe.infNFe.emit.xFant,
                        CNPJ = ArquivoNFe.infNFe.emit.CNPJ,
                        InscricaoEstadual = Convert.ToDecimal(ArquivoNFe.infNFe.emit.IE)
                    };


                    FuncoesEndereco.Salvar(endereco, DAO.Enum.TipoOperacao.INSERT);
                    FuncoesFornecedor.Salvar(Fornecedor, DAO.Enum.TipoOperacao.INSERT);
                }

                if (ArquivoNFe.infNFe.transp.transporta != null && ArquivoNFe.infNFe.transp.transporta.CNPJ != null)
                    Transportadora = FuncoesTransportadora.GetTransportadoraPorCNPJ(ArquivoNFe.infNFe.transp.transporta.CNPJ);

                /* Regra: Para importar a NFe, precisa antes cadastrar o Fornecedor. */

                NFeEntrada = new NFeEntrada
                {
                    ESP = string.Empty,
                    MARCA = string.Empty,
                    VERPROC = null,
                    XMOTIVO = null,

                    IDNFeEntrada = Sequence.GetNextID("NFEENTRADA", "IDNFEENTRADA"),
                    IDFornecedor = Fornecedor == null ? -1 : Fornecedor.IDFornecedor,
                    IDTransportadora = Transportadora == null ? null : (decimal?)Transportadora.IDTransportadora,
                    IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                    DataImportacao = DateTime.Now,
                    AUTCNPJ = ArquivoNFe.infNFe.emit.CNPJ,
                    AUTCPF = ArquivoNFe.infNFe.emit.CPF == null ? "" : "",
                    CDV = ArquivoNFe.infNFe.ide.cDV,
                    CHNFE = ArquivoNFe.infNFe.Id.Replace("NFe", string.Empty),
                    CMUNFG = ArquivoNFe.infNFe.emit.enderEmit.cMun.ToString(),
                    CNF = Convert.ToInt32(ArquivoNFe.infNFe.ide.cNF),
                    CSTAT = 100,
                    CUF = FuncoesMunicipio.ConverterUF(ArquivoNFe.infNFe.emit.enderEmit.UF.ToString()).ToString(),//ArquivoNFe.infNFe.emit.enderEmit.UF,
                    UF = ArquivoNFe.infNFe.emit.enderEmit.UF.ToString(),
                    DHCONT = ArquivoNFe.infNFe.ide.dhCont.Year < 2000 ? null : (DateTime?)ArquivoNFe.infNFe.ide.dhCont.UtcDateTime,
                    DHEMI = ArquivoNFe.infNFe.ide.dhEmi.UtcDateTime,
                    DHSAIENT = ArquivoNFe.infNFe.ide.dhSaiEnt != null ? ArquivoNFe.infNFe.ide.dhSaiEnt.Value.UtcDateTime : new DateTime(0001, 01, 01),
                    FINNFE = (int)ArquivoNFe.infNFe.ide.finNFe,
                    IDDEST = ArquivoNFe.infNFe.ide.idDest.HasValue ? (int?)ArquivoNFe.infNFe.ide.idDest : null,
                    INDFINAL = ArquivoNFe.infNFe.ide.indFinal.HasValue ? (int?)ArquivoNFe.infNFe.ide.indFinal : null,
                    //INDPAG = ArquivoNFe.infNFe.ide.indPag == null ? (int)ArquivoNFe.infNFe.ide.indPag : ,
                    INDPRES = ArquivoNFe.infNFe.ide.indPres.HasValue ? (int?)ArquivoNFe.infNFe.ide.indPres : null,
                    INFADFISCO = ArquivoNFe.infNFe.infAdic == null ? null : ArquivoNFe.infNFe.infAdic.infAdFisco,
                    INFCPL = ArquivoNFe.infNFe.infAdic == null ? null : ArquivoNFe.infNFe.infAdic.infCpl,
                    MODDOC = (int)ArquivoNFe.infNFe.ide.mod,
                    MODFRETE = (int)ArquivoNFe.infNFe.transp.modFrete,
                    NATOPE = ArquivoNFe.infNFe.ide.natOp,
                    NNF = Convert.ToInt32(ArquivoNFe.infNFe.ide.nNF),
                    NVOL = ArquivoNFe.infNFe.transp != null ? (ArquivoNFe.infNFe.transp.vol?.FirstOrDefault()?.nVol) : null,
                    PESOB = ArquivoNFe.infNFe.transp != null ? (ArquivoNFe.infNFe.transp.vol?.FirstOrDefault()?.pesoB) : null,
                    PESOL = ArquivoNFe.infNFe.transp != null ? (ArquivoNFe.infNFe.transp.vol?.FirstOrDefault()?.pesoL) : null,
                    PLACA = ArquivoNFe.infNFe.transp.veicTransp != null ? ArquivoNFe.infNFe.transp.veicTransp.placa : null,
                    QVOL = ArquivoNFe.infNFe.transp != null ? (ArquivoNFe.infNFe.transp.vol?.FirstOrDefault()?.qVol) : null,
                    PROCEMI = (int)ArquivoNFe.infNFe.ide.procEmi,
                    SERIE = ArquivoNFe.infNFe.ide.serie,
                    TPAMB = (int)ArquivoNFe.infNFe.ide.tpAmb,
                    TPEMIS = (int)ArquivoNFe.infNFe.ide.tpEmis,
                    TPIMP = (int)ArquivoNFe.infNFe.ide.tpImp,
                    TPNF = (int)ArquivoNFe.infNFe.ide.tpNF,
                    VBC = ArquivoNFe.infNFe.total.ICMSTot.vBC,
                    VBCST = ArquivoNFe.infNFe.total.ICMSTot.vBCST,
                    VCOFINS = ArquivoNFe.infNFe.total.ICMSTot.vCOFINS,
                    VDESC = ArquivoNFe.infNFe.total.ICMSTot.vDesc,
                    VFCPUFDEST = ArquivoNFe.infNFe.total.ICMSTot.vFCPUFDest,
                    VFRETE = ArquivoNFe.infNFe.total.ICMSTot.vFrete,
                    VICMS = ArquivoNFe.infNFe.total.ICMSTot.vICMS,
                    VICMSUFDEST = ArquivoNFe.infNFe.total.ICMSTot.vICMSUFDest,
                    VICMSUFREMET = ArquivoNFe.infNFe.total.ICMSTot.vICMSUFRemet,
                    VIPI = ArquivoNFe.infNFe.total.ICMSTot.vIPI,
                    VNF = ArquivoNFe.infNFe.total.ICMSTot.vNF,
                    VOUTRO = ArquivoNFe.infNFe.total.ICMSTot.vOutro,
                    VPIS = ArquivoNFe.infNFe.total.ICMSTot.vPIS,
                    VPROD = ArquivoNFe.infNFe.total.ICMSTot.vProd,
                    VSEG = ArquivoNFe.infNFe.total.ICMSTot.vSeg,
                    VST = ArquivoNFe.infNFe.total.ICMSTot.vST,
                    VTOTTRIB = ArquivoNFe.infNFe.total.ICMSTot.vTotTrib,
                    XJUST = ArquivoNFe.infNFe.ide.xJust,

                    XCAMPO = ArquivoNFe.infNFe.infAdic?.obsFisco?.FirstOrDefault()?.xCampo,
                    XTEXTO = ArquivoNFe.infNFe.infAdic?.obsFisco?.FirstOrDefault()?.xTexto,
                    NPROT = ArquivoNFe.infNFe.infAdic?.procRef?.FirstOrDefault()?.nProc,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreencherTela()
        {
            /* Cabeçalho da NFe */
            ovTXT_CodNatOp.Text = ArquivoNFe.infNFe.ide.natOp;
            ovTXT_Chave.Text = ArquivoNFe.infNFe.Id != null ? ArquivoNFe.infNFe.Id.Replace("NFe", "") : "";
            ovTXT_Tipo.Text = "IMPORTAÇÃO";
            ovTXT_Finalidade.Text = ArquivoNFe.infNFe.ide.finNFe.ToString();
            ovTXT_TipoAtendimento.Text = ArquivoNFe.infNFe.ide.indPres.ToString();
            ovTXT_Numero.Text = ArquivoNFe.infNFe.ide.nNF.ToString();
            ovTXT_Emissao.Text = ArquivoNFe.infNFe.ide.dhEmi.ToString();
            ovTXT_Serie.Text = ArquivoNFe.infNFe.ide.serie.ToString();

            /* Fornecedor - Emitente da NFe */
            //ovTXT_Fornecedor.Text = ArquivoNFe.infNFe.emit.xFant;
            ovTXT_Fornecedor.Text = ArquivoNFe.infNFe.emit.xNome;
            ovTXT_FornecedorCNPJCPF.Text = ArquivoNFe.infNFe.emit.CNPJ;
            ovTXT_FornecedorCep.Text = ArquivoNFe.infNFe.emit.enderEmit.CEP;
            ovTXT_FornecedorUF.Text = ArquivoNFe.infNFe.emit.enderEmit.UF.ToString();
            ovTXT_FornecedorBairro.Text = ArquivoNFe.infNFe.emit.enderEmit.xBairro;
            ovTXT_FornecedorInscEstadual.Text = ArquivoNFe.infNFe.emit.IE;
            ovTXT_FornecedorLogradouro.Text = ArquivoNFe.infNFe.emit.enderEmit.xLgr;
            ovTXT_FornecedorNumero.Text = ArquivoNFe.infNFe.emit.enderEmit.nro;
            ovTXT_ClienteComplemento.Text = ArquivoNFe.infNFe.emit.enderEmit.xCpl;
            ovTXT_FornecedorCidade.Text = ArquivoNFe.infNFe.emit.enderEmit.xMun;
            ovTXT_FornecedorFone.Text = ArquivoNFe.infNFe.emit.enderEmit.fone.ToString();

            /* Transportadora */
            if (ArquivoNFe.infNFe.transp.transporta != null)
            {
                ovTXT_Transportadora.Text = ArquivoNFe.infNFe.transp.transporta != null ? ArquivoNFe.infNFe.transp.transporta.xNome : "<Não Informado>";
                ovTXT_TransportadoraCNPJCPF.Text = ArquivoNFe.infNFe.transp.transporta != null ? ArquivoNFe.infNFe.transp.transporta.CNPJ : "<Não Informado>";

                ovTXT_TransportadoraPlaca.Text = ArquivoNFe.infNFe.transp.veicTransp != null ? ArquivoNFe.infNFe.transp.veicTransp.placa : string.Empty;
                ovTXT_UFTransportadora.Text = ArquivoNFe.infNFe.transp.veicTransp != null ? ArquivoNFe.infNFe.transp.veicTransp.UF : string.Empty;
            }
            else
            {
                ovTXT_Transportadora.Text = "<Não Informado>";
                ovTXT_TransportadoraCNPJCPF.Text = "<Não Informado>";

                ovTXT_TransportadoraPlaca.Text = string.Empty;
                ovTXT_UFTransportadora.Text = string.Empty;

                ovCKB_FreteSemFrete.Checked = true;
            }

            /* Frete Por */
            switch (ArquivoNFe.infNFe.transp.modFrete)
            {
                case NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfSemFrete:
                    ovCKB_FreteSemFrete.Checked = true;
                    break;
                case NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfContaTerceiros:
                    ovCKB_FreteTerceiros.Checked = true;
                    break;
                case NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfProprioContaRemente:
                    ovCKB_FreteEmitente.Checked = true;
                    break;
                case NFe.Classes.Informacoes.Transporte.ModalidadeFrete.mfContaDestinatario:
                    ovCKB_FreteDestinatario.Checked = true;
                    break;
            }

            /* CondicaoPagamento */
            switch (ArquivoNFe.infNFe.ide.indPag)
            {
                case NFe.Classes.Informacoes.Identificacao.Tipos.IndicadorPagamento.ipOutras:
                    ovCKB_Outros.Checked = true;
                    break;
                case NFe.Classes.Informacoes.Identificacao.Tipos.IndicadorPagamento.ipPrazo:
                    ovCKB_Aprazo.Checked = true;
                    break;
                case NFe.Classes.Informacoes.Identificacao.Tipos.IndicadorPagamento.ipVista:
                    ovCKB_Avista.Checked = true;
                    break;
            }

            PreencherProdutos();
            PreencherTotaisFinanceiro();
            CarregarFinanceiro(true);
        }

        private void PreencherProdutos()
        {
            /*
				1. Consulta por CProd na tabela de ProdutoFornecedor.
				2. Se Não existir, Consulta pelo EAN.
				3. Se Não existir, Listar todos os produtos pelo NCM                 
			 */

            Itens = new List<ItemNFeEntrada>();

            foreach (det d in ArquivoNFe.infNFe.det)
            {                
                Produto Prod = FuncoesProduto.GetProdutoPorCodigoEFornecedorNOVO(d.prod.cProd, Fornecedor == null ? -1 : Fornecedor.IDFornecedor);

                if (Prod == null)
                {
                    string Ean = d.prod.cEAN;

                    if (Ean != "SEM GTIN")
                    {
                        if (string.IsNullOrEmpty(Ean))
                            Ean = d.prod.cEANTrib;

                        if (!string.IsNullOrEmpty(Ean))
                            Prod = FuncoesProduto.GetProdutoPorEAN(Ean);
                    }
                }

                ItemNFeEntrada _Prod = new ItemNFeEntrada();

                _Prod.CodSequencial = d.nItem;
                _Prod.IDItemNFeEntrada = Sequence.GetNextID("ITEMNFEENTRADA", "IDITEMNFEENTRADA");
                _Prod.IDNFeEntrada = NFeEntrada.IDNFeEntrada;       
                _Prod.IDProduto = Prod == null ? 0 : Prod.IDProduto;
                _Prod.DescricaoProduto = Prod == null ? "" : Prod.Descricao;
                _Prod.CEANTRIB = d.prod.cEANTrib;
                _Prod.CENQ = d.imposto.IPI != null ? d.imposto.IPI.cEnq.ToString() : null;
                _Prod.CEST = d.prod.CEST;
                _Prod.CFOP = d.prod.CFOP.ToString();

                //if (Prod == null)
                //    _Prod.DescricaoProduto = d.prod.xProd;
                //else
                //    _Prod.DescricaoProduto = Prod.Descricao;              
                
                _Prod.CEAN = d.prod.cEAN;
                _Prod.INDTOT = (int)d.prod.indTot;
                _Prod.NCM = d.prod.NCM;
                _Prod.QTRIB = d.prod.qTrib;
                _Prod.UCOM = d.prod.uCom;
                _Prod.VOUTRO = d.prod.vOutro ?? 0;
                _Prod.UTRIB = d.prod.uTrib;
                _Prod.VPROD = d.prod.vProd;
                _Prod.VUNTRIB = d.prod.vUnTrib;
                _Prod.VUNCOM = d.prod.vUnCom;
                _Prod.XPROD = d.prod.xProd;
                _Prod.VFRETE = d.prod.vFrete ?? 0;
                _Prod.VDESC = d.prod.vDesc ?? 0;
                _Prod.VSEG = d.prod.vSeg ?? 0;
                _Prod.QuantidadeEntrada = d.prod.qCom;
                _Prod.QCOM = d.prod.qCom;
                _Prod.UNEntrada = d.prod.uCom;
                _Prod.UNSaida = d.prod.uCom;
                _Prod.QuantidadeSaida = d.prod.qCom;
                _Prod.Valor = Math.Round(d.prod.vUnCom, 2);
                _Prod.CodProdutoFonecedor = d.prod.cProd;
                _Prod.ValorTotalItem = Math.Round(d.prod.vProd, 2);

                CalcularConversao(_Prod, d);

                if (d.imposto.ICMS != null) PreencherICMS(d.imposto.ICMS.TipoICMS, _Prod);
                if (d.imposto.PIS != null) PreencherPIS(d.imposto.PIS.TipoPIS, _Prod);
                if (d.imposto.COFINS != null) PreencherCOFINS(d.imposto.COFINS.TipoCOFINS, _Prod);
                if (d.imposto.ICMSUFDest != null) PreencherPartilhaICMS(d.imposto.ICMSUFDest, _Prod);

                decimal itemVenda;

                itemVenda = 0;
                if (Prod != null)
                {
                    itemVenda = Prod.ValorVenda;             
                }
                Itens.Add(_Prod);
            }
            
            gridControl1.DataSource = Itens;

            Color foreColor = Color.Red;

            //MontaGridProdutoEntradaNF();
        }

        private void CalcularConversao(ItemNFeEntrada _Prod, det d)
        {
            ConversaoUnidadeDeMedida conversao = FuncoesConversaoUnidadeMedida.GetConversoesPorProdutoFornecedor(_Prod.IDProduto, Convert.ToInt64(d.prod.cProd));

            if (conversao != null)
            {
                _Prod.QuantidadeEntrada = Math.Round(d.prod.qCom * conversao.Fator, 2);
                _Prod.Valor = Math.Round(_Prod.Valor / conversao.Fator, 2);
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            grdProdutosEntradaNF.Appearance.FocusedRow.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string priority = View.GetRowCellDisplayText(e.RowHandle, View.Columns["IDProduto"]);

                if (priority == "0")
                {
                    //e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
                    e.Appearance.ForeColor = Color.Red;

                    grdProdutosEntradaNF.Appearance.FocusedRow.ForeColor = Color.Red;
                    // e.Appearance.BackColor2 = Color.White;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Black;
                    grdProdutosEntradaNF.Appearance.FocusedRow.ForeColor = Color.Black;
                }
            }
        }

        private void PreencherTotaisFinanceiro()
        {
            ovTXT_ICMS.Text = ArquivoNFe.infNFe.total.ICMSTot.vICMS.ToString("c2");
            ovTXT_ICMSST.Text = ArquivoNFe.infNFe.total.ICMSTot.vST.ToString("c2");
            ovTXT_IPI.Text = ArquivoNFe.infNFe.total.ICMSTot.vIPI.ToString("c2");
            ovTXT_PIS.Text = ArquivoNFe.infNFe.total.ICMSTot.vPIS.ToString("c2");
            ovTXT_COFINS.Text = ArquivoNFe.infNFe.total.ICMSTot.vCOFINS.ToString("c2");
            ovTXT_Seguro.Text = ArquivoNFe.infNFe.total.ICMSTot.vSeg.ToString("c2");
            ovTXT_Frete.Text = ArquivoNFe.infNFe.total.ICMSTot.vFrete.ToString("c2");
            ovTXT_Outros.Text = ArquivoNFe.infNFe.total.ICMSTot.vOutro.ToString("c2");
            ovTXT_BaseCalculo.Text = ArquivoNFe.infNFe.total.ICMSTot.vBC.ToString("c2");
            ovTXT_TributosAproximados.Text = ArquivoNFe.infNFe.total.ICMSTot.vTotTrib.ToString("c2");
            ovTXT_Desconto.Text = ArquivoNFe.infNFe.total.ICMSTot.vDesc.ToString("c2");
            ovTXT_TotalNF.Text = ArquivoNFe.infNFe.total.ICMSTot.vNF.ToString("c2");
            ovTXT_TotalNFe.Text = ArquivoNFe.infNFe.total.ICMSTot.vNF.ToString("c2");
        }

        private void PreencherICMS(ICMSBasico ICMS, ItemNFeEntrada Prod)
        {
            /* Simples Nacional */
            if (ICMS.GetType() == typeof(ICMSSN101))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMSSN101).CSOSN).ToString();
                Prod.ORIG = ((int)(ICMS as ICMSSN101).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMSSN102))
            {
                Prod.CSTICMS = Csosnicms.Csosn102.ToString();
                Prod.ORIG = OrigemMercadoria.OmNacional.ToString();
            }

            if (ICMS.GetType() == typeof(ICMSSN500))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMSSN500).CSOSN).ToString();
                Prod.ORIG = ((int)(ICMS as ICMSSN500).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMSSN900))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMSSN101).CSOSN).ToString();
                Prod.ORIG = ((int)(ICMS as ICMSSN101).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMSSN201))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMSSN101).CSOSN).ToString();
                Prod.ORIG = ((int)(ICMS as ICMSSN101).orig).ToString();
                Prod.PMVAST = (ICMS as ICMSSN201).pMVAST ?? 0;
                Prod.PREDBCST = (ICMS as ICMSSN201).pRedBCST ?? 0;
                Prod.MODBCST = (int)(ICMS as ICMSSN201).modBCST;
                Prod.VBCST = (ICMS as ICMSSN201).vBCST;
                Prod.VICMSST = (ICMS as ICMSSN201).vICMSST;
                Prod.PICMSST = (ICMS as ICMSSN201).pICMSST;
            }

            if (ICMS.GetType() == typeof(ICMSSN202))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMSSN202).CSOSN).ToString();
                Prod.ORIG = ((int)(ICMS as ICMSSN202).orig).ToString();
                Prod.PMVAST = (ICMS as ICMSSN202).pMVAST ?? 0;
                Prod.PREDBCST = (ICMS as ICMSSN202).pRedBCST ?? 0;
                Prod.MODBCST = (int)(ICMS as ICMSSN202).modBCST;
                Prod.VBCST = (ICMS as ICMSSN202).vBCST;
                Prod.VICMSST = (ICMS as ICMSSN202).vICMSST;
                Prod.PICMSST = (ICMS as ICMSSN202).pICMSST;
            }

            /* Regime Normal */
            if (ICMS.GetType() == typeof(ICMS00))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS00).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS00).orig).ToString();
                Prod.MODBC = (int)(ICMS as ICMS00).modBC;
                Prod.VBCST = (ICMS as ICMS00).vBC;
                Prod.PICMS = (ICMS as ICMS00).pICMS;
                Prod.VICMS = (ICMS as ICMS00).vICMS;
            }

            if (ICMS.GetType() == typeof(ICMS10))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS10).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS10).orig).ToString();
                Prod.PICMS = (ICMS as ICMS10).pICMS;
                Prod.VICMS = (ICMS as ICMS10).vICMS;
                Prod.PICMSST = (ICMS as ICMS10).pICMSST;
                Prod.PMVAST = (ICMS as ICMS10).pMVAST ?? 0;
                Prod.VBCST = (ICMS as ICMS10).vBCST;
                Prod.VICMSST = (ICMS as ICMS10).vICMSST;
            }

            if (ICMS.GetType() == typeof(ICMS20))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS20).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS20).orig).ToString();
                Prod.MODBC = (int)(ICMS as ICMS20).modBC;
                Prod.PICMS = (ICMS as ICMS20).pICMS;
                Prod.PREDBC = (ICMS as ICMS20).pRedBC;
                Prod.VICMS = (ICMS as ICMS20).vICMS;
            }

            if (ICMS.GetType() == typeof(ICMS30))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS30).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS30).orig).ToString();
                Prod.MODBCST = (int)(ICMS as ICMS30).modBCST;
                Prod.PMVAST = (int)(ICMS as ICMS30).pMVAST;
                Prod.PREDBCST = (int)(ICMS as ICMS30).pRedBCST;
                Prod.VBCST = (int)(ICMS as ICMS30).vBCST;
                Prod.PICMSST = (int)(ICMS as ICMS30).pICMSST;
                Prod.VICMSST = (int)(ICMS as ICMS30).vICMSST;
            }

            if (ICMS.GetType() == typeof(ICMS40))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS40).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS40).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMS60))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS60).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS60).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMS90))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS90).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS90).orig).ToString();
            }

            if (ICMS.GetType() == typeof(ICMS51))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS51).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS51).orig).ToString();
                Prod.VICMS = (ICMS as ICMS51).vICMS ?? 0;
                Prod.MODBC = (int)(ICMS as ICMS51).modBC;
                Prod.PICMS = (ICMS as ICMS51).pICMS ?? 0;
            }

            if (ICMS.GetType() == typeof(ICMS70))
            {
                Prod.CSTICMS = ((int)(ICMS as ICMS51).CST).ToString();
                Prod.ORIG = ((int)(ICMS as ICMS51).orig).ToString();
                Prod.MODBC = (int)(ICMS as ICMS70).modBC;
                Prod.PREDBC = (ICMS as ICMS70).pRedBC;
                Prod.PICMS = (ICMS as ICMS70).pICMS;
                Prod.VICMS = (ICMS as ICMS70).vICMS;
                Prod.MODBCST = (int)(ICMS as ICMS70).modBCST;
                Prod.PMVAST = (ICMS as ICMS70).pMVAST ?? 0;
                Prod.PREDBCST = (ICMS as ICMS70).pRedBCST ?? 0;
                Prod.VBCST = (ICMS as ICMS70).vBCST;
                Prod.PICMSST = (ICMS as ICMS70).pICMSST;
                Prod.VICMSST = (ICMS as ICMS70).vICMSST;
            }
        }
        private void PreencherPIS(PISBasico PISBasico, ItemNFeEntrada Prod)
        {
            if (PISBasico.GetType() == typeof(PISAliq))
            {
                Prod.CSTPIS = ((int)(PISBasico as PISAliq).CST).ToString();
                Prod.PPIS = (PISBasico as PISAliq).pPIS;
                Prod.VBCPIS = (PISBasico as PISAliq).vBC;
                Prod.VPIS = (PISBasico as PISAliq).vPIS;
            }
            if (PISBasico.GetType() == typeof(PISQtde))
            {
                Prod.CSTPIS = ((int)(PISBasico as PISQtde).CST).ToString();
                Prod.PPIS = (PISBasico as PISQtde).vAliqProd;
                Prod.VBCPIS = (PISBasico as PISQtde).qBCProd;
                Prod.VPIS = (PISBasico as PISQtde).vPIS;
            }
            if (PISBasico.GetType() == typeof(PISNT))
            {
                Prod.CSTPIS = ((int)(PISBasico as PISNT).CST).ToString();
            }
            if (PISBasico.GetType() == typeof(PISOutr))
            {
                Prod.CSTPIS = ((int)(PISBasico as PISOutr).CST).ToString();
                Prod.PPIS = (PISBasico as PISOutr).pPIS ?? 0;
                Prod.VBCPIS = (PISBasico as PISOutr).vBC ?? 0;
                Prod.VPIS = (PISBasico as PISOutr).vPIS ?? 0;
            }
        }
        private void PreencherCOFINS(COFINSBasico COFINSBasico, ItemNFeEntrada Prod)
        {
            if (COFINSBasico.GetType() == typeof(COFINSAliq))
            {
                Prod.CSTCOFINS = ((int)(COFINSBasico as COFINSAliq).CST).ToString();
                Prod.PCOFINS = (COFINSBasico as COFINSAliq).pCOFINS;
                Prod.VBCOFINS = (COFINSBasico as COFINSAliq).vBC;
                Prod.VCOFINS = (COFINSBasico as COFINSAliq).vCOFINS;
            }
            if (COFINSBasico.GetType() == typeof(COFINSQtde))
            {
                Prod.CSTCOFINS = ((int)(COFINSBasico as COFINSQtde).CST).ToString();
                Prod.PCOFINS = (COFINSBasico as COFINSQtde).vAliqProd;
                Prod.VBCOFINS = (COFINSBasico as COFINSQtde).qBCProd;
                Prod.VCOFINS = (COFINSBasico as COFINSQtde).vCOFINS;
            }
            if (COFINSBasico.GetType() == typeof(COFINSNT))
            {
                Prod.CSTCOFINS = ((int)(COFINSBasico as COFINSNT).CST).ToString();
            }
            if (COFINSBasico.GetType() == typeof(COFINSOutr))
            {
                Prod.CSTCOFINS = ((int)(COFINSBasico as COFINSOutr).CST).ToString();
                Prod.PCOFINS = (COFINSBasico as COFINSOutr).pCOFINS ?? 0;
                Prod.VBCOFINS = (COFINSBasico as COFINSOutr).vBC ?? 0;
                Prod.VCOFINS = (COFINSBasico as COFINSOutr).vCOFINS ?? 0;
            }
        }
        private void PreencherPartilhaICMS(ICMSUFDest ICMSPartilha, ItemNFeEntrada Prod)
        {
            Prod.VBCUFDEST = ICMSPartilha.vBCUFDest;
            Prod.PFCPUFDEST = ICMSPartilha.pFCPUFDest.Value;
            Prod.PICMSINTER = ICMSPartilha.pICMSInter;
            Prod.PICMSUFDEST = ICMSPartilha.pICMSUFDest;
            Prod.PICMSINTERPART = ICMSPartilha.pICMSInterPart;
            Prod.VFCPUFDEST = ICMSPartilha.vFCPUFDest.Value;
            Prod.VICMSUFDEST = ICMSPartilha.vICMSUFDest;
            Prod.VICMSUFREMET = ICMSPartilha.vICMSUFRemet;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            // Salvar
            try
            {
                PDVControlador.BeginTransaction();                

                ValidaImportacao();

                Fornecedor = FuncoesFornecedor.GetFornecedorPorCNPJ(ArquivoNFe.infNFe.emit.CNPJ);

                decimal idPedidoDeCompra = PedidoCompra != null ? PedidoCompra.IDPedidoCompra : Sequence.GetNextID("PEDIDOCOMPRA", "IDPEDIDOCOMPRA");
                decimal idFornecedor = -1;
                decimal totalPedidoCompra = 0;
                decimal idTipoDeOperacao = Convert.ToDecimal(metroComboBoxTipoDeOperacao.SelectedValue);
                List<ItemPedidoCompra> itensPedidoCompra = new List<ItemPedidoCompra>();

                /* Salvar Fornecedor */
                if (Fornecedor == null)
                {
                    Endereco EndFornecedor = new Endereco
                    {
                        IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO"),
                        Bairro = ArquivoNFe.infNFe.emit.enderEmit.xBairro,
                        Cep = string.IsNullOrEmpty(ArquivoNFe.infNFe.emit.enderEmit.CEP) ? null : ArquivoNFe.infNFe.emit.enderEmit.CEP,
                        Complemento = ArquivoNFe.infNFe.emit.enderEmit.xCpl,
                        Logradouro = ArquivoNFe.infNFe.emit.enderEmit.xLgr,
                        Numero = ArquivoNFe.infNFe.emit.enderEmit.nro,
                        Telefone = ArquivoNFe.infNFe.emit.enderEmit.fone.ToString(),
                        IDMunicipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(ArquivoNFe.infNFe.emit.enderEmit.cMun)).IDMunicipio,
                        IDPais = 1058,
                        IDUnidadeFederativa = FuncoesUF.GetUnidadeFederativaPorSigla(ArquivoNFe.infNFe.emit.enderEmit.UF.ToString()).IDUnidadeFederativa,
                    };

                    Fornecedor fornecedor = new Fornecedor
                    {
                        IDFornecedor = Sequence.GetNextID("FORNECEDOR", "IDFORNECEDOR"),//tá ai?
                        CNPJ = ArquivoNFe.infNFe.emit.CNPJ,
                        Descricao = ArquivoNFe.infNFe.emit.xNome,
                        Email = null,
                        IDEndereco = EndFornecedor.IDEndereco,
                        InscricaoEstadual = string.IsNullOrEmpty(ArquivoNFe.infNFe.emit.IE) ? null : (decimal?)Convert.ToDecimal(ArquivoNFe.infNFe.emit.IE),
                        Isento = 0,
                        RazaoSocial = ArquivoNFe.infNFe.emit.xFant
                    };

                    if (!FuncoesEndereco.Salvar(EndFornecedor, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Endereço do Fornecedor.");

                    if (!FuncoesFornecedor.Salvar(fornecedor, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Fornecedor.");
                    else
                    {
                        try
                        {
                            Fornecedor = FuncoesFornecedor.GetFornecedor(fornecedor.IDFornecedor);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Não foi possível salvar o Fornecedor.");
                        }
                    }
                }

                PedidoCompra = new PedidoCompra()
                {
                    IDPedidoCompra = idPedidoDeCompra,
                    IDFornecedor = Fornecedor.IDFornecedor,
                    IDTipoDeOperacao = idTipoDeOperacao,
                    IDComprador = Contexto.USUARIOLOGADO.IDUsuario,
                    Status = 1
                };

                if (!FuncoesPedidoCompra.Salvar(PedidoCompra))
                    throw new Exception("Não foi possível salvar o Pedido Compra");

                /* Salvar NFe Entrada */
                NFeEntrada.IDFornecedor = idFornecedor = Fornecedor.IDFornecedor;
                NFeEntrada.IDPedidoCompra = PedidoCompra == null ? null : (decimal?)PedidoCompra.IDPedidoCompra;
               
                if (!FuncoesNFeEntrada.Salvar(NFeEntrada))
                    throw new Exception("Não foi possível salvar a NF-E de Entrada.");

                if (!FuncoesNFeEntrada.SalvarXML(Encoding.Default.GetBytes(FuncoesXml.ClasseParaXmlString(ArquivoNFe)), NFeEntrada.IDNFeEntrada))
                    throw new Exception("Não foi possível salvar o Xml da NF-E de Entrada.");

                if ((grdProdutosEntradaNF.DataSource as List<ItemNFeEntrada>).Exists(q => q.IDProduto == 0))
                    throw new Exception("Existe produtos não vinculados, realize o vinculo!");

                /* Salvar Produto e ProdutoFornecedor */
                for (int i = 0; i < grdProdutosEntradaNF.DataRowCount; i++)
                {                    
                    var _ItemNFeEntrada = ((ItemNFeEntrada)grdProdutosEntradaNF.GetRow(i));
                    var ValorProduto = _ItemNFeEntrada.VPROD;

                    Produto Prodx = new Produto();
                    Produto Prodx2 = new Produto();

                    Prodx = FuncoesProduto.GetProdutoPorCodigoEFornecedor(_ItemNFeEntrada.CodProdutoFonecedor, Fornecedor == null ? -1 : Fornecedor.IDFornecedor);
                    Prodx2 = FuncoesProduto.GetProduto(_ItemNFeEntrada.IDProduto);

                    if (Prodx != null || Prodx2 != null)
                    {
                        // Atualizar Código CProd
                        if (FuncoesProdutoFornecedor.GetProdutoPorCodigoEProduto(_ItemNFeEntrada.IDProduto, Fornecedor.IDFornecedor, _ItemNFeEntrada.CodProdutoFonecedor) == null)
                        {

                            if (!FuncoesProdutoFornecedor.Salvar(new ProdutoFornecedor()
                            {
                                IDProduto = _ItemNFeEntrada.IDProduto,
                                IDFornecedor = Fornecedor.IDFornecedor,
                                CProd = _ItemNFeEntrada.CodProdutoFonecedor,
                                IDProdutoFornecedor = Sequence.GetNextID("PRODUTOFORNECEDOR", "IDPRODUTOFORNECEDOR"),

                            }))
                                throw new Exception("Não foi possível salvar o Produto Fornecedor.");
                        }

                        /* Atualizar dados do Produto ? */
                        //if (_ItemNFeEntrada.IDProduto == 0)
                        //{
                        //    _ItemNFeEntrada.IDProduto = Prodx.IDProduto;

                        //    if (!FuncoesProduto.AtualizarValorCusto(Prodx.IDProduto, ValorProduto))
                        //        throw new Exception("Não foi possível atualizar o Valor de Custo do Produto");

                        //    if (!FuncoesProduto.AtualizarValorVenda(Prodx.IDProduto, _ItemNFeEntrada.ValorVenda))
                        //        throw new Exception("Não foi possível atualizar o Valor de Venda do Produto");
                        //}
                        //else
                        //{
                        //    if (!FuncoesProduto.AtualizarValorCusto(_ItemNFeEntrada.IDProduto, ValorProduto))
                        //        throw new Exception("Não foi possível atualizar o Valor de Custo do Produto");

                        //    if (!FuncoesProduto.AtualizarValorVenda(_ItemNFeEntrada.IDProduto, _ItemNFeEntrada.ValorVenda))
                        //        throw new Exception("Não foi possível atualizar o Valor de Venda do Produto");
                        //}
                    }

                    ItemPedidoCompra itemPedidoCompra = new ItemPedidoCompra()
                    {
                        IDItemPedidoCompra = Sequence.GetNextID("ITEMPEDIDOCOMPRA", "IDITEMPEDIDOCOMPRA"),
                        IDPedidoCompra = PedidoCompra.IDPedidoCompra,
                        IDProduto = _ItemNFeEntrada.IDProduto,
                        CodigoItem = _ItemNFeEntrada.CEAN.ToString(),
                        ValorUnitario = _ItemNFeEntrada.Valor,
                        DescricaoItem = _ItemNFeEntrada.DescricaoProduto,
                        Descricao = _ItemNFeEntrada.DescricaoProduto,
                        Quantidade = _ItemNFeEntrada.QuantidadeEntrada,
                        IDUsuario = Contexto.USUARIOLOGADO.IDUsuario,
                        Total = _ItemNFeEntrada.QuantidadeEntrada * _ItemNFeEntrada.Valor

                    };

                    totalPedidoCompra += itemPedidoCompra.Total;

                    if (!FuncoesItemPedidoCompra.Salvar(itemPedidoCompra, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception($"Não foi possível salvar o item pedido compra {itemPedidoCompra.Descricao} ({itemPedidoCompra.IDItemPedidoCompra})");

                    if (!FuncoesItemNFeEntrada.Salvar(_ItemNFeEntrada))
                        throw new Exception("Não foi possível salvar os Itens da NF-E.");

                    /* Movimento de Estoque */
                    if (!FuncoesMovimentoEstoque.Salvar(new DAO.Entidades.Estoque.Movimento.MovimentoEstoque
                    {
                        IDMovimentoEstoque = Sequence.GetNextID("MOVIMENTOESTOQUE", "IDMOVIMENTOESTOQUE"),
                        DataMovimento = DateTime.Now,
                        IDAlmoxarifado = Convert.ToInt64(cboDeposito.SelectedValue),
                        IDItemNFeEntrada = _ItemNFeEntrada.IDItemNFeEntrada,
                        IDProduto = _ItemNFeEntrada.IDProduto,
                        Quantidade = _ItemNFeEntrada.QuantidadeEntrada,
                        Tipo = 0,
                        SaldoAtual = 0,
                        IDItemVenda = null,
                        IDProdutoNFe = null,
                        IDItemTransferenciaEstoque = null,
                        IDItemInventario = null,
                        Descricao = "Faturamento de compra (via importação xml)",
                        IDItemPedidoCompra = itemPedidoCompra.IDItemPedidoCompra

                    }))
                        throw new Exception("Não foi possível salvar o Movimento de Estoque.");
                }

                PedidoCompra.Total = totalPedidoCompra;

                if (!FuncoesPedidoCompra.Salvar(PedidoCompra))
                    throw new Exception("Não foi possível salvar o Pedido Compra");

                /* Gerar Financeiro */
                if (DUPLICATAS != null && DUPLICATAS.Rows.Count > 0)
                    ZeusUtil.GerarFinanceiroNFeEntrada(PedidoCompra, DUPLICATAS, Fornecedor.IDFornecedor, NFeEntrada.IDNFeEntrada);

                //Inserie DAC - Faturado Status 

                //Inserir o Financeiro
                GerarContasAPagar();

                //Gerar Dupliatas DAC
                FuncoesDuplicataDAC.ExcluirPorPedidoCompra(idPedidoDeCompra);

                for (int i = 0; i < DUPLICATAS.Rows.Count; i++)
                {
                    DataRow dataRow = DUPLICATAS.Rows[i];

                    DuplicataDAC duplicataDAC = new DuplicataDAC()
                    {
                        IDDuplicataDAC = Sequence.GetNextID("DUPLICATADAC", "IDDUPLICATADAC"),
                        IDCompra = idPedidoDeCompra,
                        IDFormaDePagamento = Convert.ToDecimal(dataRow["IDFORMADEPAGAMENTO"]),
                        Valor = Convert.ToDecimal(dataRow["VALOR"]),
                        Pagamento = Convert.ToDecimal(dataRow["PAGAMENTO"]),
                        DataVencimento = Convert.ToDateTime(dataRow["DATAVENCIMENTO"])
                    };

                    FuncoesDuplicataDAC.SalvarDuplicataDAC(duplicataDAC);
                }

                AbrirAtualizacaoPrecos();

                PDVControlador.Commit();           

                MessageBox.Show(this, "NF-E Importada com Sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                PDVControlador.Rollback();
                Fornecedor = null;
            }
        }

        //private static ItemNFeEntrada RetornaObjetoNFEntrada(GridView itemGrid)
        //{
        //    ItemNFeEntrada itemRetorno = new ItemNFeEntrada;
        //}

        private void ValidaImportacao()
        {
            bool vinculoItem = Itens.Select(q => q.IDProduto == 0).FirstOrDefault();
            
            if (vinculoItem)
                throw new Exception("Existe produtos não vinculados na grade, por favor, realize o vinculo.");

            if (cboDeposito.SelectedValue == null)
                throw new Exception("Selecione o depósito da nota.");

            if (metroComboBoxTipoDeOperacao.SelectedItem == null)
                throw new Exception("Preencha o Campo Tipo de Operação");

            decimal totalNfe = Convert.ToDecimal(ovTXT_TotalNFe.Text.Replace("R$", "").Trim());
            if (totalNfe > somaTotalParcelas)
                throw new Exception("A soma total das parcelas não pode ser menor que o valor total NF-e");

            //foreach (Control c in ovTL_Produtos.Controls)
            //{
            //var Control = (c as UC_ItemNFeEntrada);
            //    if (Control._ItemNFeEntrada.IDProduto == 0 && !Control.ovCKB_IncluirItem.Checked)
            //        throw new Exception("Foram encontrados Itens Não identificados. Verifique!");
            //    else if (!Control.ovCKB_IncluirItem.Checked)
            //    {
            //        if (Control._ItemNFeEntrada.IDProduto == 0)
            //            throw new Exception("Foram encontrados Itens Não identificados. Verifique!");
            //    }

            //    if (Control.ovCMB_AlmoxarifadoEntrada.SelectedItem == null)
            //        throw new Exception("Foram encontrados Itens sem Almoxarifado de Entrada. Verifique!");
            //}
        }

        private void GerarContasAPagar()
        {
            TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(PedidoCompra.IDTipoDeOperacao);

            if (tipoDeOperacao == null)
                throw new Exception("Selecione o Tipo de Operação na aba Financeiro.");

            if (tipoDeOperacao.GerarFinanceiro) { 
                List<decimal> pagamentos = new List<decimal>();
            foreach (DataRow dataRow in DUPLICATAS.Rows)
            {
                if (!pagamentos.Contains(Convert.ToInt64(dataRow["PAGAMENTO"])))
                    pagamentos.Add(Convert.ToInt64(dataRow["PAGAMENTO"]));
            }
                foreach (var pagamento in pagamentos)
                {
                    int numParcela = 1;
                    foreach (DataRow dataRow in DUPLICATAS.Rows)
                    {
                        if (Convert.ToInt64(dataRow["PAGAMENTO"]) == pagamento)
                        {

                            FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(Convert.ToDecimal(dataRow["IDFORMADEPAGAMENTO"]));
                            int fatorPeriodicidade = FatorPeriodicidade(formaDePagamento);
                            ContaPagar contaPagar = new ContaPagar()
                            {
                                IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR"),
                                IDPedidoCompra = PedidoCompra.IDPedidoCompra,
                                IDFormaDePagamento = formaDePagamento.IDFormaDePagamento,
                                IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                                IDCentroCusto = tipoDeOperacao.IdCentroCusto,
                                IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                                IDFornecedor = PedidoCompra.IDFornecedor,
                                IDNFeEntrada = NFeEntrada.IDNFeEntrada,
                                Ord = numParcela.ToString(),
                                Parcela = formaDePagamento.Qtd_Parcelas,

                                Titulo = "",
                                Emissao = DateTime.Now,
                                Vencimento = DateTime.Now.AddDays(fatorPeriodicidade),
                                Situacao = formaDePagamento.Transacao == 1 ? 3 : 1,
                                Fluxo = DateTime.Now,
                                Origem = "Fatura de Compra",
                                ComplmHisFin = "Faturamento de compra de codigo :" + PedidoCompra.IDPedidoCompra + ".",

                                Valor = PedidoCompra.Total / formaDePagamento.Qtd_Parcelas,
                                Multa = 0,
                                Juros = 0,
                                Desconto = 0,
                                Saldo = formaDePagamento.Transacao == 1 ? 0 : PedidoCompra.Total / formaDePagamento.Qtd_Parcelas,
                                ValorTotal = PedidoCompra.Total / formaDePagamento.Qtd_Parcelas
                            };

                            if (!FuncoesContaPagar.Salvar(contaPagar, DAO.Enum.TipoOperacao.INSERT))
                                throw new Exception($"Não foi possível salvar o Lançamento da Compra {PedidoCompra.IDPedidoCompra}.");

                            if (formaDePagamento.Transacao == 1)
                            {
                                BaixaPagamento baixaPagamento = new BaixaPagamento()
                                {
                                    IDContaPagar = contaPagar.IDContaPagar,
                                    IDBaixaPagamento = Sequence.GetNextID("BAIXAPAGAMENTO", "IDBAIXAPAGAMENTO"),
                                    Valor = contaPagar.ValorTotal,
                                    IDFormaDePagamento = Convert.ToDecimal(contaPagar.IDFormaDePagamento),
                                    IDHistoricoFinanceiro = Convert.ToDecimal(contaPagar.IDHistoricoFinanceiro),
                                    IDContaBancaria = Convert.ToDecimal(contaPagar.IDContaBancaria),
                                    Baixa = DateTime.Now,

                                };
                                if (!FuncoesBaixaPagamento.Salvar(baixaPagamento, DAO.Enum.TipoOperacao.INSERT))
                                    throw new Exception($"Não foi possível salvar a Baixa da Compra {PedidoCompra.IDPedidoCompra}.");
                            }
                        }
                        numParcela++;
                    }
                }
            }
        }

        /* Financeiro */
        private List<FormaDePagamento> FORMASPAGAMENTO = null;
        private DataTable DUPLICATAS = null;

        private void CarregarFinanceiro(bool BuscarBanco)
        {
            if (BuscarBanco)
                DUPLICATAS = FuncoesDuplicataNFe.GetDuplicatas(-1);

            gridControlVencimentos.DataSource = DUPLICATAS;
            AjustaHeaderFinanceiro();
            ovTXT_TotalFinanceiro.Text = DUPLICATAS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALOR"])).ToString("c2");
            gridViewVencimentos.BestFitColumns();
        }


        private int FatorPeriodicidade(FormaDePagamento formaDePagamento)
        {
            int fatorPeriodicidade = 0;

            switch (formaDePagamento.Periodicidade)
            {
                case "Diário":
                    fatorPeriodicidade = 1;
                    break;
                case "Semanal":
                    fatorPeriodicidade = 7;
                    break;
                case "Quinzenal":
                    fatorPeriodicidade = 15;
                    break;
                case "Mensal":
                    fatorPeriodicidade = 30;
                    break;
                case "Trimestral":
                    fatorPeriodicidade = 90;
                    break;
                case "Semestral":
                    fatorPeriodicidade = 180;
                    break;
                case "Anual":
                    fatorPeriodicidade = 365;
                    break;
            }

            return fatorPeriodicidade;
        }
        private void AjustaHeaderFinanceiro()
        {
            for (int i = 0; i < gridViewVencimentos.Columns.Count; i++)
            {
                switch (i)
                {
                    case 2:
                        gridViewVencimentos.Columns[i].Caption = "NÚMERO DA PARCELA";
                        break;
                    case 3:
                        gridViewVencimentos.Columns[i].Caption = "VENCIMENTO";
                        break;
                    case 4:
                        gridViewVencimentos.Columns[i].Caption = "VALOR DO VENCIMENTO";
                        gridViewVencimentos.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridViewVencimentos.Columns[i].DisplayFormat.FormatString = "c2";
                        break;
                    default:
                        gridViewVencimentos.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void LimparDuplicatas()
        {
            foreach (DataRowView dr in DUPLICATAS.DefaultView)
                dr.Delete();
            gridControlVencimentos.DataSource = DUPLICATAS;
            AjustaHeaderFinanceiro();
            gridViewVencimentos.BestFitColumns();

            LabelsFinanceiro();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            LimparDuplicatas();

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            InserirParcelas();
        }

        private void InserirParcelas()
        {
            // Gerar Parcelas.
            if (ovCMB_FormaPagamento.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a Forma de Pagamento.", NOME_TELA);
                return;
            }

            decimal idFormaDePagamento = (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
            FormaDePagamento formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(idFormaDePagamento);

            int periodicidade = Periodicidade.Fator(formaDePagamento.Periodicidade);
            DateTime vencimento = DateTime.Today.AddDays(periodicidade);

            double valorParcela = Math.Round(Convert.ToDouble(textEditValorPagar.EditValue) / formaDePagamento.Qtd_Parcelas, 2);

            int pagamento = -1;
            foreach (DataRow dataRow in DUPLICATAS.Rows)
            {
                int rowPagamento = Convert.ToInt32(dataRow["PAGAMENTO"]);
                pagamento = pagamento < rowPagamento ? rowPagamento : pagamento;
            }
            pagamento++;
            for (int i = 0; i < formaDePagamento.Qtd_Parcelas; i++)
            {
                vencimento = vencimento.Date.AddMonths(i == 0 ? 0 : 1);
                DataRow dr = DUPLICATAS.NewRow();
                dr["IDDUPLICATANFE"] = Sequence.GetNextID("DUPLICATANFE", "IDDUPLICATANFE");
                dr["IDNFE"] = -1;
                dr["NUMERODOCUMENTO"] = i + 1;
                dr["DATAVENCIMENTO"] = vencimento.Date;
                dr["VALOR"] = valorParcela;
                dr["IDFORMADEPAGAMENTO"] = idFormaDePagamento;
                dr["PAGAMENTO"] = pagamento;

                DUPLICATAS.Rows.Add(dr);
            }

            CarregarFinanceiro(false);

            LabelsFinanceiro();

            textEditValorPagar.EditValue = 0;
            textEditValorPagar.Focus();
            ovCMB_FormaPagamento.SelectedIndex = -1;
        }

        private void FEST_ImportacaoNFe_Load(object sender, EventArgs e)
        {
            //UCControl.Margin = new Padding(5);
            //ovTL_Produtos.Controls.Add(UCControl);

            /* Verificar se a NFe já foi importada. */
            if (FuncoesNFeEntrada.IsNFeImportada(ArquivoNFe.infNFe.Id.Replace("NFe", string.Empty)))
                if (MessageBox.Show(this, $"A NF-E {ArquivoNFe.infNFe.Id.Replace("NFe", string.Empty)} Já foi importada.", NOME_TELA) == DialogResult.OK)
                    Close();
        }

        private void textEditValorPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (labelTrocoValor.Text == "R$ 0,00")
                    InserirParcelas();
            }
        }

        private void ovCMB_FormaPagamento_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textEditValorPagar.EditValue) == 0)
                textEditValorPagar.EditValue = Convert.ToDecimal(labelFaltaValor.Text.Replace("R$", ""));

            textEditValorPagar.Focus();
        }

        private void simpleButtonCancelarParcela_Click(object sender, EventArgs e)
        {
            //Essa lista irá receber os id's das duplicatas nfe que estão selecionadas
            List<decimal> ids = new List<decimal>();

            foreach (int i in gridViewVencimentos.GetSelectedRows())
            {
                ids.Add(Convert.ToDecimal(DUPLICATAS.Rows[i][0]));
            }

            for (int i = 0; i < DUPLICATAS.Rows.Count; i++)
            {
                //Se o id duplicata nfe da linha estiver condo na lista de ids a linha será deletada 
                if (ids.Contains(Convert.ToDecimal(DUPLICATAS.Rows[i][0])))
                    DUPLICATAS.Rows[i].Delete();
            }

            CarregarFinanceiro(false);
            LabelsFinanceiro();

        }
        private void LabelsFinanceiro()
        {
            somaTotalParcelas = 0;
            for (int i = 0; i < DUPLICATAS.Rows.Count; i++)
            {
                somaTotalParcelas += Convert.ToDecimal(DUPLICATAS.Rows[i]["VALOR"]);
            }

            decimal totalNfe = Convert.ToDecimal(ovTXT_TotalNFe.Text.Replace("R$", "").Trim());
            labelFaltaValor.Text = totalNfe > somaTotalParcelas ? "R$ " + (totalNfe - somaTotalParcelas).ToString() : "R$ 0,00";
            labelTrocoValor.Text = totalNfe < somaTotalParcelas ? "R$ " + Math.Round(somaTotalParcelas - totalNfe, 2).ToString() : "R$ 0,00";

            simpleButtonCancelarParcela.Enabled = DUPLICATAS.Rows.Count > 0;
        }

        private void editDecimalValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IDProduto")
            {
                int codProduto = Convert.ToInt32(e.Value);
                ItemNFeEntrada itemGrid = (ItemNFeEntrada)grdProdutosEntradaNF.GetRow(e.RowHandle);
                ConversaoUnidadeDeMedida conversao = FuncoesConversaoUnidadeMedida.GetConversoesPorProdutoFornecedor(codProduto, Convert.ToInt64(itemGrid.CodProdutoFonecedor));
                Produto produto = FuncoesProduto.GetProduto(codProduto);

                CalcularConversaoProduto(e.RowHandle, produto, conversao, itemGrid);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //var id = Convert.ToInt64(((ItemNFeEntrada)((GridView)gridControl1.MainView).GetFocusedRow()).CProd);

            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);

            if (info.InRow || info.InRowCell)
            {
                ItemNFeEntrada itemGrid = (ItemNFeEntrada)grdProdutosEntradaNF.GetRow(info.RowHandle);

                Produto produto = PreencherDadosCadastroProduto(itemGrid);

                FCA_Produtos t = new FCA_Produtos(produto);

                t = PreencherCamposConversaoProdutoCadastro(itemGrid, t);

                t.ShowDialog(this);

                if (produto.IDProduto > 0)
                {
                    ConversaoUnidadeDeMedida conversao = FuncoesConversaoUnidadeMedida.GetConversoesPorProdutoFornecedor(produto.IDProduto, Convert.ToInt64(itemGrid.CodProdutoFonecedor));

                    grdProdutosEntradaNF.SetRowCellValue(info.RowHandle, grdProdutosEntradaNF.Columns["IDProduto"], produto.IDProduto);

                    CalcularConversaoProduto(info.RowHandle, produto, conversao, itemGrid);
                }                
            }
        }       

        private Produto PreencherDadosCadastroProduto(ItemNFeEntrada item)
        {
            Produto Produto = FuncoesProduto.GetProduto(item.IDProduto);

            if (Produto == null)
            {
                Produto = new Produto();

                UnidadeMedida UNEntrada = FuncoesUnidadeMedida.GetUnidadeMedidaPorSigla(item.UNEntrada);

                Produto.Descricao = item.XPROD;
                Produto.EAN = item.CEAN;
                Produto.CEST = item.CEST;
                Produto.IDUnidadeDeMedida = UNEntrada == null ? 0 : UNEntrada.IDUnidadeDeMedida;
                Produto.IDNCM = Convert.ToDecimal(item.NCM);
                Produto.ValorVenda = item.ValorVenda;
                Produto.ValorCusto = item.Valor;
                Produto.Trib_MVA = item.PMVAST;
                Produto.Trib_RedBCICMSST = item.VICMS;
                Produto.Trib_RedBCICMS = item.VICMSST;
                Produto.Trib_AliqIPI = item.VIPI;
                Produto.Trib_AliqPIS = item.VBCPIS;
                Produto.Trib_AliqCOFINS = item.VBCOFINS;
            }

            return Produto;
        }        
        
        private FCA_Produtos PreencherCamposConversaoProdutoCadastro(ItemNFeEntrada item, FCA_Produtos t)
        {
            UnidadeMedida UnidadeMedida = FuncoesUnidadeMedida.GetUnidadeMedidaPorSigla(item.UNEntrada);
            //FuncoesUnidadeMedida.GetUnidadesMedida().Where(o => o.IDUnidadeDeMedida == UNEntrada.IDUnidadeDeMedida).FirstOrDefault();

            if (item.IDProduto > 0)
                t.ovTXT_Identificacao_CodigoProduto.Text = item.IDProduto.ToString();

            if (UnidadeMedida != null)
                t.ovCMB_UnidadeEntrada.SelectedValue = UnidadeMedida.IDUnidadeDeMedida;

            t.txtCodFornecedor.Text = Fornecedor.IDFornecedor.ToString();
            t.txtFornecedor.Text = Fornecedor.RazaoSocial.ToString();

            t.txtProdutoFornecedor.Text = item.CodProdutoFonecedor;

            return t;
        }

        public void CalcularConversaoProduto(int codRow, Produto produtoBanco, ConversaoUnidadeDeMedida conversao, ItemNFeEntrada produtoGrid) 
        {
            var produtoFornecedor = ArquivoNFe.infNFe.det.Find(q => q.prod.cProd == produtoGrid.CodProdutoFonecedor);
            
            grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["DescricaoProduto"], "");
            grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["QuantidadeEntrada"], produtoFornecedor.prod.qCom);
            grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["Valor"], Math.Round(produtoFornecedor.prod.vUnCom, 2));

            //Verificando se o produto existe
            if (produtoBanco != null)
            {
                grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["DescricaoProduto"], produtoBanco.Descricao);
               
                if (conversao != null)
                {
                    decimal qtde = produtoFornecedor.prod.qCom * conversao.Fator;

                    grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["QuantidadeEntrada"], Math.Round(qtde, 2));
                    //grdProdutosEntradaNF.SetRowCellValue(info.RowHandle, grdProdutosEntradaNF.Columns["ValorVenda"], Math.Round(produto.ValorVenda / qtde, 2));
                    grdProdutosEntradaNF.SetRowCellValue(codRow, grdProdutosEntradaNF.Columns["Valor"], Math.Round(produtoBanco.ValorCusto / conversao.Fator, 2));
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AbrirAtualizacaoPrecos();
        }

        public void AbrirAtualizacaoPrecos()
        {
            try
            { 
                if ((grdProdutosEntradaNF.DataSource as List<ItemNFeEntrada>).Exists(q => q.IDProduto == 0))
                    throw new Exception("Existe produtos não vinculados, realize o vinculo!");

                FEST_AltualizarPrecos t = new FEST_AltualizarPrecos();

                t.gridControl1.DataSource = FEST_AltualizarPrecos.PreencherGridPrecos(Itens);

                t.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }
    }
}