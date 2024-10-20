using Boleto2Net;
using DevExpress.CodeParser;
using DevExpress.CodeParser.Diagnostics;
using DevExpress.DataProcessing;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid.Views.Grid;
using DFe.Classes.Flags;
using MetroFramework;
using NFe.Classes.Informacoes.Emitente;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Transmissao;
using PDV.CONTROLLER.NFE.Util;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Movimento;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.UTIL.Components;
using PDV.VIEW.App_Context;
using PDV.VIEW.BOLETO.Classes;
using PDV.VIEW.Forms.Util;
using PDV.VIEW.Forms.Vendas.Manifesto;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.NFe
{
    public partial class GVEN_NFe : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Emissão de NF-e";
        /* Seletores */
        private List<Cfop> CFOPS = null;
        private List<Finalidade> FINALIDADES = null;
        private List<TipoAtendimento> TIPOSATENDIMENTO = null;
        private List<DocumentoReferenciado> TIPOS_DOC_REF = null;
        private List<UnidadeFederativa> UF_REF = null;
        private List<FormaDePagamento> FORMASPAGAMENTO = null;
        private int TOperacao;
        /* Cliente */
        private Cliente Cliente { get; set; } = null;
        private DAO.Entidades.Endereco EnderecoCliente { get; set; } = null;
        private Contato ContatoCliente { get; set; } = null;
        private UnidadeFederativa UFCliente { get; set; }  = null;
        private Municipio MunicipioCliente { get; set; } = null;

        /* Transportadora */
        private Transportadora Transportadora { get; set; } = null;
        private DAO.Entidades.Endereco EnderecoTransportadora { get; set; } = null;

        /* Grids */
        private DataTable DOCS_REFERENCIADOS = null;
        private DataTable PRODUTOS = null;
        private DataTable Duplicatas { get; set; } = null;

        /* Variaveis de Controle */
        private DAO.Entidades.NFe.NFe NFe = null;
        private VolumeNFe Volume = null;
        //private bool EDITANDO = false;

        public DataTable ProdutosNFeICMS = null;
        public DataTable ProdutosNFePIS = null;
        public DataTable ProdutosNFeCOFINS = null;
        public DataTable ProdutosNFePARTILHA = null;

        private decimal? IDMovimentoFiscal = null;

        string UfCliente, UfEmitente;

        public GVEN_NFe(DAO.Entidades.NFe.NFe _NFe, bool Editando = false, decimal? _IDMovimentoFiscal = null)
        {
            InitializeComponent();

            NFe = _NFe;
            IDMovimentoFiscal = _IDMovimentoFiscal;
            Preencher();

            if (NFe.IDNFe  != -1)   
                simpleButtonCarregarVenda.Enabled = false;
        }
        private void Preencher()
        {   
            ovTXT_PesoBruto.AplicaAlteracoes();
            ovTXT_PesoLiquido.AplicaAlteracoes();
            ovTXT_QuantidadeParcela.AplicaAlteracoes();

            ovTXT_Frete.AplicaAlteracoes();
            ovTXT_Despesas.AplicaAlteracoes();
            ovTXT_Desconto.AplicaAlteracoes();
            ovTXT_Seguro.AplicaAlteracoes();


            IniciaSeletores();

            ProdutosNFeICMS = FuncoesProdutoNFeICMS.GetProdutoICMS(NFe.IDNFe);
            ProdutosNFePIS = FuncoesProdutoNFePIS.GetProdutoPIS(NFe.IDNFe);
            ProdutosNFeCOFINS = FuncoesProdutoNFeCOFINS.GetProdutoCOFINS(NFe.IDNFe);
            ProdutosNFePARTILHA = FuncoesProdutoNFePartilhaICMS.GetPartilhas(NFe.IDNFe);
  
            GetDadosCliente();
            GetDadosTransportadora();   
            
        }
        private void IniciaSeletores()
        {

            CFOPS = FuncoesCFOP.GetCFOPSAtivos();
            cbbTipo.SelectedIndex = 1;

            ovCMB_NaturezaOperacao.DataSource = CFOPS;
            ovCMB_NaturezaOperacao.DisplayMember = "CODIGODESCRICAO";
            ovCMB_NaturezaOperacao.ValueMember = "IDCFOP";
            ovCMB_NaturezaOperacao.SelectedItem = null;

            FINALIDADES = FuncoesFinalidade.GetFinalidades();
            ovCMB_Finalidade.DisplayMember = "DESCRICAO";
            ovCMB_Finalidade.ValueMember = "IDFINALIDADE";
            ovCMB_Finalidade.DataSource = FINALIDADES;

            TIPOSATENDIMENTO = FuncoesTipoAtendimento.GetTiposAtendimento();
            ovCMB_TipoAtendimento.DisplayMember = "DESCRICAO";
            ovCMB_TipoAtendimento.ValueMember = "IDTIPOATENDIMENTO";
            ovCMB_TipoAtendimento.DataSource = TIPOSATENDIMENTO;

            ovTXT_Vendedor.Text = Contexto.USUARIOLOGADO.Nome;

            TIPOS_DOC_REF = FuncoesDocumentoReferenciadoNFe.GetTiposDocumentoReferenciado();
            ovCMB_ModeloDocRef.DataSource = TIPOS_DOC_REF;
            ovCMB_ModeloDocRef.DisplayMember = "DESCRICAO";
            ovCMB_ModeloDocRef.ValueMember = "CODIGO";

            UF_REF = FuncoesUF.GetUnidadesFederativaNFe();
            ovCMB_UFDocRef.DataSource = UF_REF;
            ovCMB_UFDocRef.DisplayMember = "SIGLA";
            ovCMB_UFDocRef.ValueMember = "IDUNIDADEFEDERATIVA";

            FORMASPAGAMENTO = FuncoesFormaDePagamento.GetFormasPagamento();
            ovCMB_FormaPagamento.DataSource = FORMASPAGAMENTO;
            ovCMB_FormaPagamento.ValueMember = "IDFORMADEPAGAMENTO";
            ovCMB_FormaPagamento.DisplayMember = "IDENTIFICACAODESCRICAOFORMABANDEIRA";
            ovCMB_FormaPagamento.SelectedItem = FORMASPAGAMENTO.AsEnumerable().Where(o => o.IDFormaDePagamento == NFe.IDFormaDePagamento).FirstOrDefault();
            ovCMB_FormaPagamento.Select();

            textBoxNoDaVenda.Text = NFe.IDVenda.ToString();

            metroTabControl2.SelectedTab = metroTabPage5;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AdicionarProduto();
        }
        private void AdicionarProduto(ItemVenda itemVenda = null)
        {
            if (Cliente == null)
            {
                MessageBox.Show(this, "Selecione o Cliente.", NOME_TELA);
                return;
            }

            Emitente Emit = FuncoesEmitente.GetEmitente();
            DAO.Entidades.Endereco Ender = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            decimal idUFEmitente = FuncoesUF.GetUnidadeFederativa(Ender.IDUnidadeFederativa.Value).IDUnidadeFederativa;
            using (GVEN_ItemNFe FormAdicionaItem = new GVEN_ItemNFe((CRT)Enum.Parse(typeof(CRT), Emit.CRT.ToString()), FuncoesUF.GetUnidadeFederativa(EnderecoCliente.IDUnidadeFederativa.Value), ProdutosNFeICMS.NewRow(), ProdutosNFePIS.NewRow(), ProdutosNFeCOFINS.NewRow(), ProdutosNFePARTILHA.NewRow()))
            {
                bool adcionadoManualmente = false;

                if (itemVenda != null)
                    FormAdicionaItem.EscolherProduto(itemVenda);
                else
                {
                    FormAdicionaItem.ShowDialog(this);
                    adcionadoManualmente = true;
                }

                if (FormAdicionaItem.Prod != null && FormAdicionaItem.ProdutoNFe != null && FormAdicionaItem.ProdutoNFe.IDProdutoNFe != -1)
                {         
                    var ValorTotalProduto = itemVenda != null ? 
                        ItemVendaUtil.GetTotalItem(itemVenda) : 
                        GetValorTotalProduto(FormAdicionaItem);

                    DataRow drProduto = PRODUTOS.NewRow();
                    drProduto["IDPRODUTO"] = FormAdicionaItem.Prod.IDProduto;
                    drProduto["IDUNIDADEDEMEDIDA"] = FormAdicionaItem.Prod.IDUnidadeDeMedida;
                    drProduto["PRODUTO"] = FormAdicionaItem.Prod.Descricao;
                    drProduto["CODIGO"] = FormAdicionaItem.Prod.Codigo;
                    drProduto["CSTCSOSN"] = FuncoesCst.GetCSTIcmsPorID(FormAdicionaItem.Integ.IDCSTIcms).CSTCSOSN;
                   
                    
                    
                    string SCfop = FuncoesCFOP.GetCFOP(FormAdicionaItem.ProdutoNFe.IDCFOP).Codigo;
                   
                    
                    
                    if (idUFEmitente != UFCliente.IDUnidadeFederativa)
                        drProduto["IDCFOP"] = drProduto["CFOP"] = ConverterCFOParaForaDoEstado(FormAdicionaItem.ProdutoNFe.IDCFOP, SCfop);                  
                    else
                        drProduto["IDCFOP"] = drProduto["CFOP"] = FuncoesCFOP.GetCFOP(FormAdicionaItem.ProdutoNFe.IDCFOP).Codigo;

                    SCfop = drProduto["CFOP"].ToString();

                    Cfop cfop = FuncoesCFOP.GetCFOPPorCodigo(SCfop);

                    drProduto["QUANTIDADE"] = FormAdicionaItem.ProdutoNFe.Quantidade;
                    drProduto["VALORUNITARIO"] = FormAdicionaItem.ProdutoNFe.ValorUnitario;
                    drProduto["DESCONTO"] = FormAdicionaItem.ProdutoNFe.Desconto;
                    drProduto["VALORTOTAL"] = ValorTotalProduto;
                    drProduto["TOTALFINANCEIRO"] = ValorTotalProduto;
                    drProduto["IDPRODUTONFE"] = FormAdicionaItem.ProdutoNFe.IDProdutoNFe;
                    drProduto["IDPRODUTO"] = FormAdicionaItem.ProdutoNFe.IDProduto;
                    drProduto["IDNFE"] = NFe.IDNFe;
                    drProduto["FRETE"] = FormAdicionaItem.ProdutoNFe.Frete;
                    drProduto["OUTRASDESPESAS"] = FormAdicionaItem.ProdutoNFe.OutrasDespesas;
                    drProduto["IDINTEGRACAOFISCAL"] = FormAdicionaItem.ProdutoNFe.IDIntegracaoFiscal;
                    drProduto["SEGURO"] = FormAdicionaItem.ProdutoNFe.Seguro;
                    drProduto["MANUALMENTE"] = adcionadoManualmente;
                    
                    PRODUTOS.Rows.Add(drProduto);
                    ProdutosNFeICMS.Rows.Add(FormAdicionaItem.DrProdutosNFeICMS);
                    ProdutosNFePIS.Rows.Add(FormAdicionaItem.DrProdutosNFePIS);
                    ProdutosNFeCOFINS.Rows.Add(FormAdicionaItem.DrProdutosNFeCOFINS);
                    ProdutosNFePARTILHA.Rows.Add(FormAdicionaItem.DrProdutosNFePARTILHA);

                    CarregarProdutos(false);
                    CalculaTotalNFe();

                    if (FormAdicionaItem.Integ.IDPortaria.HasValue && string.IsNullOrEmpty(ovTXT_InformacoesComplementares.Text))
                        ovTXT_InformacoesComplementares.Text = FuncoesPortaria.GetPortaria(FormAdicionaItem.Integ.IDPortaria.Value).Descricao;

                    LimparDuplicatas();
                }
            }
        }

        private static string ConverterCFOParaForaDoEstado(decimal defaultIdCfop, string SCfop)
        {
            switch (SCfop)
            {
                case "5101":
                    return "6101";
                case "5102":
                    return "6102";
                case "5103":
                    return "6103";
                case "5104":
                    return "6104";
                case "5105":
                    return "6105";
                case "5403":
                    return "6403";
                case "5405":
                    return "6405";
                default:
                    return FuncoesCFOP.GetCFOP(defaultIdCfop).Codigo;
            }
        }

        private static decimal GetValorTotalProduto(GVEN_ItemNFe FormAdicionaItem)
        {
            return (((FormAdicionaItem.ProdutoNFe.ValorUnitario +
                                          FormAdicionaItem.ProdutoNFe.Frete +
                                          FormAdicionaItem.ProdutoNFe.OutrasDespesas +
                                          FormAdicionaItem.ProdutoNFe.Seguro) *
                                          FormAdicionaItem.ProdutoNFe.Quantidade) +
                                          FormAdicionaItem.ovTXT_ValorIcmsST.Value) -
                                          FormAdicionaItem.ProdutoNFe.Desconto;
        }

        private void ovTXT_CodNatOp_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ovCMB_NaturezaOperacao.SelectedItem = CFOPS.Where(o => o.Codigo == ZeusUtil.SomenteNumeros(ovTXT_CodNatOp.Text)).FirstOrDefault();

                   // FuncoesCFOP.GetCFOPPorCodigo(ovTXT_CodNatOp.Text).Tipo.Equals("1") ? ovTXT_Tipo.Text = "ENTRADA" : ovTXT_Tipo.Text = "SAIDA"






                    if (ovCMB_NaturezaOperacao.SelectedItem == null)
                    {
                        MessageBox.Show(this, "CFOP não encontrado.");
                        ovCMB_NaturezaOperacao.Select();
                        ovCMB_NaturezaOperacao.SelectAll();
                    }
                    break;
            }
        }
                
        private void PreencheCliente()
        {
            ovTXT_CodCliente.Text = Cliente.IDCliente.ToString();
            ovTXT_Cliente.Text = Cliente.TipoDocumento == 0 ? Cliente.NomeFantasia : Cliente.Nome;
            ovTXT_ClienteCNPJCPF.Text = Cliente.TipoDocumento == 0 ? Cliente.CNPJ : Cliente.CPF;
            ovTXT_ClienteCep.Text = string.IsNullOrEmpty(EnderecoCliente.Cep.ToString()) ? "<Não Informado>" : EnderecoCliente.Cep.ToString();
            ovTXT_ClienteUF.Text = UFCliente == null ? "" : UFCliente.Sigla;
            ovTXT_ClienteBairro.Text = EnderecoCliente.Bairro;
            ovTXT_ClienteInscEstadual.Text = Cliente.InscricaoEstadual == null ? string.Empty : (string.IsNullOrEmpty(Cliente.InscricaoEstadual.ToString()) ? "<Não Informado>" : Cliente.InscricaoEstadual.ToString());
            ovTXT_ClienteLogradouro.Text = EnderecoCliente.Logradouro;
            ovTXT_ClienteNumero.Text = EnderecoCliente.Numero.ToString();
            ovTXT_ClienteComplemento.Text = string.IsNullOrEmpty(EnderecoCliente.Complemento) ? "<Não Informado>" : EnderecoCliente.Complemento;
            ovTXT_ClienteCidade.Text = MunicipioCliente == null ?"": MunicipioCliente.Descricao;
            ovTXT_ClienteEmail.Text = string.IsNullOrEmpty(ContatoCliente.Email) ? "<Não Informado>" : ContatoCliente.Email;
        }
        public void GetDadosCliente()
        {
            if (FuncoesCliente.GetCliente(NFe.IDCliente) != null)
            {
                ovBTN_SalvarETransmitir.Enabled = false;
                Cliente = FuncoesCliente.GetCliente(NFe.IDCliente);
                EnderecoCliente = FuncoesEndereco.GetEndereco(Cliente.IDEndereco.Value);
                if (Cliente.IDContato.HasValue)
                    ContatoCliente = FuncoesContato.GetContato(Cliente.IDContato.Value);

                decimal? idUf = EnderecoCliente.IDUnidadeFederativa, 
                    idMunicipio = EnderecoCliente.IDMunicipio;

                if (!idUf.HasValue || !idMunicipio.HasValue)
                    throw new Exception("Informe o endereço do cliente para emitir uma NF-e");

                UFCliente = FuncoesUF.GetUnidadeFederativa(idUf.Value);
                MunicipioCliente = FuncoesMunicipio.GetMunicipio(idMunicipio.Value);
                
                
            }
            
        }
        private void GetDadosTransportadora()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GVEN_SeletorTransportadora SeletorTransportadora = new GVEN_SeletorTransportadora();
            SeletorTransportadora.ShowDialog(this);

            if (SeletorTransportadora.DRTransportadora == null)
                return;

            DataRow DrSelecionada = DrSelecionada = SeletorTransportadora.DRTransportadora;
            Transportadora = FuncoesTransportadora.GetTransportadora(Convert.ToDecimal(DrSelecionada["IDTRANSPORTADORA"]));
            EnderecoTransportadora = FuncoesEndereco.GetEndereco(Convert.ToDecimal(DrSelecionada["IDENDERECO"]));

            // Verificar Aqui..
            ovTXT_UFTransportadora.Text = EnderecoTransportadora.IDUnidadeFederativa.HasValue ? FuncoesUF.GetUnidadeFederativa(EnderecoTransportadora.IDUnidadeFederativa.Value).Sigla : string.Empty;
            ovTXT_Codtransportadora.Text = Transportadora.IDTransportadora.ToString();
            ovTXT_Transportadora.Text = Transportadora.TipoDocumento == 0 ? Transportadora.RazaoSocial : Transportadora.Nome;
            ovTXT_TransportadoraCNPJCPF.Text = Transportadora.TipoDocumento == 0 ? Transportadora.CNPJ : Transportadora.CPF;
        }

        private void GVEN_NFe_Load(object sender, EventArgs e)
        {
            PreencherTela();           
        }

        private void CarregarNotasReferenciadas(bool BuscaBanco)
        {
            if (BuscaBanco)
                DOCS_REFERENCIADOS = FuncoesDocumentoReferenciadoNFe.GetDocumentosReferenciadosNFe(NFe.IDNFe);

            gridControlDocumentoRefenciados.DataSource = DOCS_REFERENCIADOS;
            AjustaHeaderNotasRef();
            gridViewDocumentosReferenciados.BestFitColumns();
        }
        private void AjustaHeaderNotasRef()
        {
            for (int i = 0; i < gridViewDocumentosReferenciados.Columns.Count; i++)
            {
                switch (gridViewDocumentosReferenciados.Columns[i].AbsoluteIndex)
                {
                    case 6:
                        gridViewDocumentosReferenciados.Columns[i].Caption = "TIPO";
                        break;
                    case 3:
                        gridViewDocumentosReferenciados.Columns[i].Caption = "UF";
                        break;
                    case 4:
                        gridViewDocumentosReferenciados.Columns[i].Caption = "CHAVE";
                        break;
                    default:
                        gridViewDocumentosReferenciados.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void AjustarCabecalhosProdutos()
        {
            Grids.FormatGrid(ref gridViewProdutos);
            Grids.FormatColumnType(ref gridViewProdutos, new List<string>
            {
                "manualmente",
                "idunidadedemedida",
                "idintegracaofiscal",
                "seguro",
                "sequencia",
                "outrasdespesas",
                "idnfe",
                "idprodutonfe1",
                "totalfinanceiro",
                "cstcsosn",
                "frete",
                "idproduto"
            }, GridFormats.VisibleFalse);

            Grids.FormatColumnType(ref gridViewProdutos, new List<string> 
            { 
                "valortotal", 
                "desconto", 
                "valorunitario"
            }, GridFormats.Finance);

            Grids.FormatColumnType(ref gridViewProdutos, new List<string>
            {
               "valortotal",
                "desconto",
                "valorunitario"
            }, GridFormats.SumFinance);
        }
        private void PreencherTela()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                /* Cabecalho */

                var venda = FuncoesVenda.GetVenda(NFe.IDVenda);
                

                ovTXT_Emissao.Text = NFe.Emissao.ToString();
                ovTXT_Saida.Text = NFe.Saida.ToString();
                ovCMB_Finalidade.SelectedItem = FINALIDADES.Where(o => o.IDFinalidade == NFe.IDFinalidade).FirstOrDefault();
                ovCMB_TipoAtendimento.SelectedItem = TIPOSATENDIMENTO.Where(o => o.IDTipoAtendimento == NFe.IDTipoAtendimento).FirstOrDefault();

                textBoxNoDaVenda.Text = NFe.IDVenda != -1 ? NFe.IDVenda.ToString() : "";

                if (venda != null)
                {
                    Usuario vendedor = FuncoesUsuario.GetUsuario(Convert.ToDecimal(venda.IDVendedor));
                    ovTXT_Vendedor.Text = vendedor != null ? vendedor.Nome : "";
                }

                ovTXT_Serie.Text = Contexto.CONFIGURACAO_SERIE.SerieNFe.ToString();

                switch (Convert.ToInt32(NFe.INDPagamento))
                {
                    case 0:
                        ovCKB_Avista.Checked = true;
                        break;
                    case 1:
                        ovCKB_Aprazo.Checked = true;
                        break;
                    case 2:
                        ovCKB_Outros.Checked = true;
                        break;
                }

                /* Cliente */
                GetDadosCliente();
                if (Cliente != null)
                    PreencheCliente();

                if (UFCliente != null)
                {
                    if (venda != null)
                    {
                        var tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(venda.IDTipoDeOperacao);
                        decimal idCfop = ProcessarCFOP(tipoDeOperacao.IDOperacaoFiscal);

                        ovCMB_NaturezaOperacao.SelectedItem = CFOPS.Where(o => o.IDCfop == idCfop).FirstOrDefault();
                    }
                    else
                    {
                        decimal idCfop = ProcessarCFOP(NFe.IDCFOP);
                        ovCMB_NaturezaOperacao.SelectedItem = CFOPS.Where(o => o.IDCfop == idCfop).FirstOrDefault();
                    }
                }

                /* Transportadora */
                if (NFe.IDTransportadora != 0 && NFe.IDTransportadora != null)
                {
                    
                    Transportadora = FuncoesTransportadora.GetTransportadora(NFe.IDTransportadora.Value);
                    if (Transportadora != null)
                    {
                       EnderecoTransportadora = FuncoesEndereco.GetEndereco(Transportadora.IDEndereco);

                        ovTXT_UFTransportadora.Text = EnderecoTransportadora.IDUnidadeFederativa.HasValue ? FuncoesUF.GetUnidadeFederativa(EnderecoTransportadora.IDUnidadeFederativa.Value).Sigla : string.Empty;
                        ovTXT_Codtransportadora.Text = Transportadora.IDTransportadora.ToString();
                        ovTXT_Transportadora.Text = Transportadora.TipoDocumento == 0 ? Transportadora.RazaoSocial : Transportadora.Nome;
                        ovTXT_TransportadoraCNPJCPF.Text = Transportadora.TipoDocumento == 0 ? Transportadora.CNPJ : Transportadora.CPF;
                        ovTXT_TransportadoraPlaca.Text = NFe.Placa;
                        ovTXT_TransportadoraVeiculo.Text = NFe.Veiculo;
                        ovTXT_TransportadoraANTT.Text = NFe.ANTT;
                    }                        
                   
                }             

                switch (Convert.ToInt32(NFe.FretePor))
                {
                    case 0:
                        ovCKB_FreteEmitente.Checked = true;
                        break;
                    case 1:
                        ovCKB_FreteDestinatario.Checked = true;
                        break;
                    case 2:
                        ovCKB_FreteTerceiros.Checked = true;
                        break;
                    case 9:
                        ovCKB_FreteSemFrete.Checked = true;
                        break;
                }

                /* Volumes e Informações Adicionais */
                ovTXT_InformacoesComplementares.Text = NFe.InformacoesComplementares;

                Volume = FuncoesVolume.GetVolume(NFe.IDNFe);
                if (Volume == null)
                    Volume = new VolumeNFe();

                ovTXT_Volume.Text = Volume.Volume;
                ovTXT_NumeroVolume.Text = Volume.Numero;
                ovTXT_PesoLiquido.Value = Volume.PesoLiquido;
                ovTXT_PesoBruto.Value = Volume.PesoBruto;
                ovTXT_Marca.Text = Volume.Marca;
                ovTXT_Especie.Text = Volume.Especie;

                CarregarNotasReferenciadas(true);
                CarregarProdutos(true);
                CarregarFinanceiro(true);

                ovTXT_Frete.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["FRETE"]));
                ovTXT_Despesas.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["OUTRASDESPESAS"]));
                ovTXT_Desconto.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["DESCONTO"]));
                ovTXT_Seguro.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["SEGURO"]));
                RateioDeValores(ovTXT_Frete.Value, ovTXT_Despesas.Value, ovTXT_Desconto.Value, ovTXT_Seguro.Value);
                CalculaTotalNFe();

                /*Lista de produtos*/
                if (NFe.IDNFe == -1)
                {
                    var listaProdutosNFe = new List<ProdutoNFe>();
                    var listaItensVenda = FuncoesItemVenda.GetItensVenda(NFe.IDVenda);
                    listaItensVenda.ForEach(i => AdicionarProduto(i));
                }

                /*Forma de Pagamento*/              
                GerarParcelas(duplicataNFCe);            

                Cursor.Current = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this,ex.Message,"Erro ao carregar NOTA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private decimal ProcessarCFOP(decimal _idCFOP)
        {
            var emitente = FuncoesEmitente.GetEmitente();
            var endereco = FuncoesEndereco.GetEndereco(emitente.IDEndereco);
            var idUFEmitente = FuncoesUF.GetUnidadeFederativa(endereco.IDUnidadeFederativa.Value).IDUnidadeFederativa;
            decimal idCFOP;
            if (idUFEmitente != UFCliente.IDUnidadeFederativa)
                idCFOP = Convert.ToDecimal(ConverterCFOParaForaDoEstado(
                    _idCFOP, _idCFOP.ToString()));
            else
                idCFOP = _idCFOP;
            return idCFOP;
        }

        private void CarregarProdutos(bool BuscarBanco)
        {
            if (BuscarBanco) 
            {
                PRODUTOS = FuncoesProdutoNFe.GetProdutos(NFe.IDNFe);
                PRODUTOS.Columns.Add("MANUALMENTE", typeof(bool));
            }              

            gridControl1.DataSource = PRODUTOS;
            AjustarCabecalhosProdutos();
            CalculaTotalNFe();
        }

        private void CarregarFinanceiro(bool BuscarBanco)
        {
            if (BuscarBanco)
                Duplicatas = FuncoesDuplicataNFe.GetDuplicatas(NFe.IDNFe);

            gridControlFinanceiro.DataSource = Duplicatas;
            AjustaHeaderFinanceiro();
            gridViewFinanceiro.BestFitColumns();

        }

        private void AjustaHeaderFinanceiro()
        {
            for (int i = 0; i < gridViewFinanceiro.Columns.Count; i++)
            {
                switch (gridViewFinanceiro.Columns[i].AbsoluteIndex)
                {

                    case 2:
                        gridViewFinanceiro.Columns[i].Caption = "NÚMERO DO DOCUMENTO";
                        break;
                    case 3:
                        gridViewFinanceiro.Columns[i].Caption = "VENCIMENTO";
                        break;
                    case 4:
                        gridViewFinanceiro.Columns[i].Caption = "VALOR";
                        gridViewFinanceiro.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gridViewFinanceiro.Columns[i].DisplayFormat.FormatString = "c2";
                        break;
                    default:
                        gridViewFinanceiro.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (ovCMB_ModeloDocRef.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione o Tipo de Documento.");
                return;
            }

            if (ovCMB_UFDocRef.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a UF.");
                return;
            }

            if (string.IsNullOrEmpty(ovTXT_ChaveDoc.Text))
            {
                MessageBox.Show(this, "Informe a Chave.");
                return;
            }

            DataRow drDoc = DOCS_REFERENCIADOS.NewRow();
            drDoc["IDDOCUMENTOREFERENCIADONFE"] = Sequence.GetNextID("DOCUMENTOREFERENCIADONFE", "IDDOCUMENTOREFERENCIADONFE");
            drDoc["IDNFE"] = NFe.IDNFe;
            drDoc["IDUNIDADEFEDERATIVA"] = (ovCMB_UFDocRef.SelectedItem as UnidadeFederativa).IDUnidadeFederativa;
            drDoc["UNIDADEFEDERATIVA"] = (ovCMB_UFDocRef.SelectedItem as UnidadeFederativa).Sigla;
            drDoc["CHAVE"] = ovTXT_ChaveDoc.Text;
            drDoc["CODIGODOCUMENTOREFERENCIADO"] = (ovCMB_ModeloDocRef.SelectedItem as DocumentoReferenciado).Codigo;
            drDoc["DOCUMENTOREFERENCIADO"] = (ovCMB_ModeloDocRef.SelectedItem as DocumentoReferenciado).Descricao;

            DOCS_REFERENCIADOS.Rows.Add(drDoc);
            CarregarNotasReferenciadas(false);
            CalculaTotalNFe();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            int rowHandle = gridViewDocumentosReferenciados.FocusedRowHandle;
            string fieldName = gridViewDocumentosReferenciados.Columns[0].FieldName;
            decimal id = Convert.ToDecimal(gridViewDocumentosReferenciados.GetRowCellValue(rowHandle, fieldName.ToUpper()));

            if (MessageBox.Show(this, "Deseja remover o registro selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DOCS_REFERENCIADOS.DefaultView.RowFilter = "[IDDOCUMENTOREFERENCIADONFE] = " + id.ToString();
                foreach (DataRowView drv in DOCS_REFERENCIADOS.DefaultView)
                    drv.Delete();

                DOCS_REFERENCIADOS.DefaultView.RowFilter = string.Empty;
                CarregarNotasReferenciadas(false);
            }
        }


        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (gridViewProdutos.GetSelectedRows().Length > 1 )
            {
                MessageBox.Show(this, "Selecione um registro para remover.");
                return;
            }
            int rowHanddle = gridViewProdutos.FocusedRowHandle;
            string fieldName = gridViewProdutos.Columns[0].FieldName ;
            decimal IDProdutoNFe = -1;
            if (rowHanddle > 1)
            {
                MessageBox.Show(this, "Selecione um registro para remover.");
                return;
            }
            else
            {
                IDProdutoNFe = Convert.ToDecimal(gridViewProdutos.GetRowCellValue(rowHanddle, fieldName));

            }

            if (MessageBox.Show(this, "Deseja remover o registro selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PRODUTOS.DefaultView.RowFilter = "[IDPRODUTONFE] = " + IDProdutoNFe;
                if (PRODUTOS.DefaultView.Count > 0)
                    PRODUTOS.DefaultView[0].Delete();

                ProdutosNFeICMS.DefaultView.RowFilter = "[IDPRODUTONFE] = " + IDProdutoNFe;
                if (ProdutosNFeICMS.DefaultView.Count > 0)
                    ProdutosNFeICMS.DefaultView[0].Delete();

                ProdutosNFePIS.DefaultView.RowFilter = "[IDPRODUTONFE] = " + IDProdutoNFe;
                if (ProdutosNFePIS.DefaultView.Count > 0)
                    ProdutosNFePIS.DefaultView[0].Delete();

                ProdutosNFeCOFINS.DefaultView.RowFilter = "[IDPRODUTONFE] = " + IDProdutoNFe;
                if (ProdutosNFeCOFINS.DefaultView.Count > 0)
                    ProdutosNFeCOFINS.DefaultView[0].Delete();

                ProdutosNFePARTILHA.DefaultView.RowFilter = "[IDPRODUTONFE] = " + IDProdutoNFe;
                if (ProdutosNFePARTILHA.DefaultView.Count > 0)
                    ProdutosNFePARTILHA.DefaultView[0].Delete();

                PRODUTOS.DefaultView.RowFilter = string.Empty;
                ProdutosNFeICMS.DefaultView.RowFilter = string.Empty;
                ProdutosNFePIS.DefaultView.RowFilter = string.Empty;
                ProdutosNFeCOFINS.DefaultView.RowFilter = string.Empty;
                ProdutosNFePARTILHA.DefaultView.RowFilter = string.Empty;

                CarregarProdutos(false);
            }

            CalculaTotalNFe();
            LimparDuplicatas();
        }

        private void CalculaTotalNFe()
        {

            ovTXT_Frete.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["FRETE"]));
            ovTXT_Despesas.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["OUTRASDESPESAS"]));
            ovTXT_Desconto.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["DESCONTO"]));
            ovTXT_Seguro.Value = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["SEGURO"]));
            ovTXT_TotalNFe.Text = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALORTOTAL"])).ToString("c2");
            ovTXT_TotalFinanceiro.Text = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["TOTALFINANCEIRO"])).ToString("c2");
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            LimparDuplicatas();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            GerarParcelas();
        }
        private void GerarParcelas(List<DuplicataNFCe> duplicataNFCes = null)
        {
            // Gerar Parcelas.
            if (duplicataNFCes != null)
            {
                LimparDuplicatas();
                double TotalNFe = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDouble(o["TOTALFINANCEIRO"]));
                InserirDuplicatas(duplicataNFCes);

                decimal ValorFalta = Convert.ToDecimal(TotalNFe) - Duplicatas.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["VALOR"]));
                foreach (DataRow dr in Duplicatas.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    dr["VALOR"] = Convert.ToDecimal(dr["VALOR"]) + ValorFalta;
                    break;
                }

                CarregarFinanceiro(false);
            }
        }

        private void InserirDuplicatas(List<DuplicataNFCe> duplicataNFCes)
        {
            var vencimento = ovTXT_PrimeiraParcela.Value;

            foreach (var item in duplicataNFCes)
            {
                var formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(item.IDFormaDePagamento);

                double valorParcela = ZeusUtil.Arredondar((double)item.Valor, 2);
                vencimento = item.DataVencimento;
                DataRow dr = Duplicatas.NewRow();
                dr["IDDUPLICATANFE"] = Sequence.GetNextID("DUPLICATANFE", "IDDUPLICATANFE");
                dr["IDNFE"] = NFe.IDNFe;
                dr["NUMERODOCUMENTO"] = formaDePagamento.Identificacao;
                dr["DATAVENCIMENTO"] = vencimento.Date;
                dr["VALOR"] = valorParcela;
                dr["IDFORMADEPAGAMENTO"] = item.IDFormaDePagamento;
                Duplicatas.Rows.Add(dr);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja cancelar o preenchimento da NF-e?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (!ValidarNFe())
                return;
            // salvarnfe
            SalvarNFe();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (!ValidarNFe())
                return;

            // salvarnfe
            SalvarNFe(true);
        }

        private void TransmitirNFe()
        {
            MovimentoFiscal Movimento = null;
            if (IDMovimentoFiscal.HasValue)
                Movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal.Value);

            EventosNFe Ev = new EventosNFe(NFe, Contexto.CONFIGURACAO_SERIE.SerieNFe, Movimento != null ? Convert.ToInt32(Movimento.Numero) : Sequence.GetNextID(Contexto.CONFIGURACAO_SERIE.NomeSequenceNFe));
            Ev.CaminhoSolution = Contexto.CaminhoSolution;
            RetornoTransmissaoNFe Retorno = Ev.TransmitirNFe();
            if (Retorno.isAutorizada)
            {
                ZeusUtil.GerarFinanceiro(Retorno.IDMovimentoFiscal, ModeloDocumento.NFe, Contexto.USUARIOLOGADO);

                if (Retorno.isVisualizar)
                    Retorno.danfe.Visualizar();
                else
                    Retorno.danfe.Imprimir(Retorno.isCaixaDialogo, Retorno.NomeImpressora);

                var lQueryPrimeiroProduto = PRODUTOS.AsEnumerable().FirstOrDefault();
                if (lQueryPrimeiroProduto != null)
                {
                    IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(FuncoesProduto.GetProduto(Convert.ToDecimal(lQueryPrimeiroProduto["IDPRODUTO"])).IDIntegracaoFiscalNFe.Value);
                    if (Integ.Financeiro == 1)
                        GerarDuplicatas(Retorno.IDMovimentoFiscal, (decimal)Movimento.IDVenda);
                }
            }
            else
                MessageBox.Show(this, Retorno.MotivoErro, NOME_TELA);
            Close();
        }

        private bool ValidarNFe()
        {
            /* Validação da Primeira Aba */
            if (ovCMB_NaturezaOperacao.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a Natureza da Operação.", NOME_TELA);
                return false;
            }

            if (ovCMB_Finalidade.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione a Finalidade.", NOME_TELA);
                return false;
            }

            if (ovCMB_TipoAtendimento.SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione o Tipo de Atendimento.", NOME_TELA);
                return false;
            }

            if (Cliente == null)
            {
                MessageBox.Show(this, "Selecione o Cliente.", NOME_TELA);
                return false;
            }

            if ((ovCKB_FreteDestinatario.Checked || ovCKB_FreteEmitente.Checked || ovCKB_FreteTerceiros.Checked) && Transportadora == null)
            {
                //MessageBox.Show(this, "Selecione a Transportadora.", NOME_TELA);
                //return false;
            }

            var lQueryProdutos = PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Count();
            if (lQueryProdutos == 0)
            {
                MessageBox.Show(this, "Informe os Produtos.", NOME_TELA);
                return false;
            }

            var CountDuplic = Duplicatas.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Count();
            if (CountDuplic == 0)
            {
                MessageBox.Show(this, "Informe as Duplciatas do Financeiro.", NOME_TELA);
                return false;
            }
            return true;
        }

        private void SalvarNFe(bool Transmitir = false)
        {
            try
            {
                PDVControlador.BeginTransaction();

                /* NF-e */
                TipoOperacao Op = TipoOperacao.UPDATE;
                if (NFe.IDNFe == -1)
                {
                    NFe.IDNFe = Sequence.GetNextID("NFE", "IDNFE");
                    Op = TipoOperacao.INSERT;
                }
                decimal IDVENDA = 0;
                if (!string.IsNullOrEmpty(textBoxNoDaVenda.Text))
                {
                    IDVENDA = decimal.Parse(textBoxNoDaVenda.Text);
                }
                NFe.IDVenda = IDVENDA;
                ValidarSaldoEstoqueProdutos();
                duplicataNFCe = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(IDVENDA);
                NFe.IDCFOP = (ovCMB_NaturezaOperacao.SelectedItem as Cfop).IDCfop;
                NFe.IDUsuario = Contexto.USUARIOLOGADO.IDUsuario;
                NFe.IDFinalidade = (ovCMB_Finalidade.SelectedItem as Finalidade).IDFinalidade;
                
                NFe.IDTipoAtendimento = (ovCMB_TipoAtendimento.SelectedItem as TipoAtendimento).IDTipoAtendimento;
                NFe.Modelo = Convert.ToInt32(ModeloDocumento.NFe);
                NFe.Serie = Contexto.CONFIGURACAO_SERIE.SerieNFe;
                NFe.IDCliente = Cliente.IDCliente;
                NFe.IDTransportadora = Transportadora == null ? null : (decimal?)Transportadora.IDTransportadora;
                NFe.Placa = (ovTXT_TransportadoraPlaca.Text.Trim().Equals("-") ? string.Empty : ovTXT_TransportadoraPlaca.Text.Replace("-", string.Empty)).ToUpper();
                NFe.ANTT = ovTXT_TransportadoraANTT.Text;
                NFe.Veiculo = ovTXT_TransportadoraVeiculo.Text;
                NFe.FretePor = GetFretePor();
                NFe.InformacoesComplementares = ovTXT_InformacoesComplementares.Text;
                NFe.INDPagamento = ovCKB_Avista.Checked ? 0 : (ovCKB_Aprazo.Checked ? 1 : 2);
                NFe.IDFormaDePagamento = duplicataNFCe[0].IDFormaDePagamento;//(ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento;
                if (!FuncoesNFe.Salvar(NFe, Op))
                    throw new Exception("Não foi possível salvar a NF-e.");

                /* Documentos Referenciados */
                DataTable dt = ZeusUtil.GetChanges(DOCS_REFERENCIADOS, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["IDNFE"] = NFe.IDNFe;
                        if (!FuncoesDocumentoReferenciadoNFe.Salvar(EntityUtil<DocumentoReferenciadoNFe>.ParseDataRow(dr)))
                            throw new Exception("Não foi possível salvar os Documentos Referenciados da NF-e.");
                    }
                dt = ZeusUtil.GetChanges(DOCS_REFERENCIADOS, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesDocumentoReferenciadoNFe.Remover(Convert.ToDecimal(dr["IDDOCUMENTOREFERENCIADONFE"])))
                            throw new Exception("Não foi possível salvar os Documentos Referenciados da NF-e.");

                /* Volumes */
                Volume.Volume = ovTXT_Volume.Text;
                Volume.Marca = ovTXT_Marca.Text;
                Volume.Especie = ovTXT_Especie.Text;
                Volume.PesoLiquido = ovTXT_PesoLiquido.Value;
                Volume.PesoBruto = ovTXT_PesoBruto.Value;
                Volume.Numero = ovTXT_NumeroVolume.Text;

                if (Volume.IDVolumeNFe == -1)
                {
                    Op = TipoOperacao.INSERT;
                    Volume.IDVolumeNFe = Sequence.GetNextID("VOLUMENFE", "IDVOLUMENFE");
                }
                Volume.IDNFe = NFe.IDNFe;
                if (!FuncoesVolume.Salvar(Volume, Op))
                    throw new Exception("Não foi possível salvar o Volume da NF-e.");

                /* Produtos */
                int SequenciaProduto = 0;
                dt = ZeusUtil.GetChanges(PRODUTOS, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["IDNFE"] = NFe.IDNFe;
                        dr["SEQUENCIA"] = SequenciaProduto++;
                        ProdutoNFe _ProdutoNFe = EntityUtil<ProdutoNFe>.ParseDataRow(dr);
                        if (!FuncoesProdutoNFe.Salvar(_ProdutoNFe, TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar os Produtos da NF-e.");

                        
                    }

                dt = ZeusUtil.GetChanges(PRODUTOS, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["IDNFE"] = NFe.IDNFe;
                        dr["SEQUENCIA"] = SequenciaProduto++;
                        if (!FuncoesProdutoNFe.Salvar(EntityUtil<ProdutoNFe>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar os Produtos da NF-e.");
                    }

                dt = ZeusUtil.GetChanges(PRODUTOS, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesProdutoNFe.Remover(Convert.ToDecimal(dr["IDPRODUTONFE"])))
                            throw new Exception("Não foi possível salvar os Produtos da NF-e.");

                /* Financeiro */
                dt = ZeusUtil.GetChanges(Duplicatas, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesDuplicataNFe.Excluir(Convert.ToDecimal(dr["IDDUPLICATANFE"])))
                            throw new Exception("Não foi possível salvar a Duplicada da NF-e");

                dt = ZeusUtil.GetChanges(Duplicatas, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["IDNFE"] = NFe.IDNFe;
                        if (!FuncoesDuplicataNFe.Salvar(EntityUtil<DuplicataNFe>.ParseDataRow(dr)))
                            throw new Exception("Não foi possível salvar a Duplicada da NF-e");
                    }

                /* Alíquotas */
                SalvarAliquotas();

                PDVControlador.Commit();
                MessageBox.Show(this, "NF-e Salva com Sucesso.", NOME_TELA);

                if (Transmitir)
                    TransmitirNFe();
                else
                    Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                if (PDVControlador.CONTROLADOR.InTransaction(Contexto.IDCONEXAO_PRIMARIA))
                    PDVControlador.Rollback();
            }
        }

        private void ValidarSaldoEstoqueProdutos()
        {
            //if (!FuncoesPerfilAcesso.ISEstoqueLiberado())
            //    return;

            //DataTable dt = ZeusUtil.GetChanges(PRODUTOS, TipoOperacao.INSERT);
            //if (dt == null)
            //    return;

            //foreach (decimal IDProduto in dt.AsEnumerable().Select(o => Convert.ToDecimal(o["IDPRODUTO"])))
            //{
            //    decimal QuantidadeVenda = dt.AsEnumerable().Where(o => Convert.ToDecimal(o["IDPRODUTO"]) == IDProduto).Sum(o => Convert.ToDecimal(o["QUANTIDADE"]));
            //    Produto _Produto = FuncoesProduto.GetProduto(IDProduto);
            //    if (_Produto.VenderSemSaldo == 0)
            //    {
            //        DataRow dr = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(_Produto.IDAlmoxarifadoSaida.Value, _Produto.IDProduto);
            //        if (dr == null)
            //            throw new Exception($"O Saldo do Item {_Produto.Descricao} não encontrado no almoxarifado de saida. Verifique!");
            //        var  teste = Convert.ToDecimal(dr["SALDO"]);
            //        if (QuantidadeVenda > Convert.ToDecimal(dr["SALDO"]))
            //            throw new Exception($"O Saldo do Item {_Produto.Descricao} é menor que a quantidade de venda. Saldo: {QuantidadeVenda.ToString("n4")}.");
            //    }
            //}
        }

        private void SalvarAliquotas()
        {
            /* ICMS */
            DataTable dt = ZeusUtil.GetChanges(ProdutosNFeICMS, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    if (!FuncoesProdutoNFeICMS.Salvar(EntityUtil<ProdutoNFeICMS>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possivel Produtos os itens da NFe.");

            /* PIS */
            dt = ZeusUtil.GetChanges(ProdutosNFePIS, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    if (!FuncoesProdutoNFePIS.Salvar(EntityUtil<ProdutoNFePIS>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possivel Produtos os itens da NFe.");

            /* COFINS */
            dt = ZeusUtil.GetChanges(ProdutosNFeCOFINS, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    if (!FuncoesProdutoNFeCOFINS.Salvar(EntityUtil<ProdutoNFeCOFINS>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possivel Produtos os itens da NFe.");

            /* Partilha */
            dt = ZeusUtil.GetChanges(ProdutosNFePARTILHA, TipoOperacao.INSERT);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    if (!FuncoesProdutoNFePartilhaICMS.Salvar(EntityUtil<ProdutoNFePartilhaICMS>.ParseDataRow(dr), TipoOperacao.INSERT))
                        throw new Exception("Não foi possivel Produtos os itens da NFe.");
        }

        private void ovCMB_NaturezaOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ovTXT_Tipo.Text = ovCMB_NaturezaOperacao.SelectedItem == null ? "SAIDA" : (ovCMB_NaturezaOperacao.SelectedItem as Cfop).Tipo.Equals("1") ? "ENTRADA" : "SAIDA";
            ovTXT_DataEntradaSaida.Text = ovCMB_NaturezaOperacao.SelectedItem == null ? "Saida:" : (ovCMB_NaturezaOperacao.SelectedItem as Cfop).Tipo.Equals("1") ? "Entrada:" : "Saida:";
        }

        private int GetFretePor()
        {
            if (ovCKB_FreteEmitente.Checked) return 0;
            if (ovCKB_FreteDestinatario.Checked) return 1;
            if (ovCKB_FreteTerceiros.Checked) return 2;
            if (ovCKB_FreteSemFrete.Checked) return 9;

            throw new Exception("Selecione o Frete Por Conta.");
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (PRODUTOS.DefaultView.Count == 0)
            {
                MessageBox.Show(this, "Adicione os Produtos para efetuar o Rateio.", NOME_TELA);
                return;
            }

            RateioDeValores(ovTXT_Frete.Value, ovTXT_Despesas.Value, ovTXT_Desconto.Value, ovTXT_Seguro.Value);
            CarregarProdutos(false);
            CalculaTotalNFe();
            LimparDuplicatas();
        }

        public void RateioDeValores(decimal ValorFrete, decimal ValorDespesas, decimal ValorDesconto, decimal ValorSeruro)        
        {
            double ValorRateioFrete = 0;
            double ValorRateioDespesas = 0;
            double ValorRateioDesconto = 0;
            double ValorRateioSeguro = 0;
            if (PRODUTOS.DefaultView.Count != 0)
            {
                 ValorRateioFrete    = ZeusUtil.Arredondar((double)(ValorFrete / PRODUTOS.DefaultView.Count), 2);
                 ValorRateioDespesas = ZeusUtil.Arredondar((double)(ValorDespesas / PRODUTOS.DefaultView.Count), 2);
                 ValorRateioDesconto = ZeusUtil.Arredondar((double)(ValorDesconto / PRODUTOS.DefaultView.Count), 2);
                 ValorRateioSeguro   = ZeusUtil.Arredondar((double)(ValorSeruro / PRODUTOS.DefaultView.Count), 2);
            }           

            foreach (DataRow dr in PRODUTOS.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                dr["DESCONTO"] = Convert.ToDecimal(ValorRateioDesconto);
                dr["FRETE"] = Convert.ToDecimal(ValorRateioFrete);
                dr["OUTRASDESPESAS"] = Convert.ToDecimal(ValorRateioDespesas);
                dr["SEGURO"] = Convert.ToDecimal(ValorRateioSeguro);
            }

            decimal ValorDescontoFaltando = ValorDesconto - PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["DESCONTO"]));
            decimal ValorFreteFaltando = ValorFrete - PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["FRETE"]));
            decimal ValorDespesaFaltando = ValorDespesas - PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["OUTRASDESPESAS"]));
            decimal ValorSeguroFaltando = ValorSeruro - PRODUTOS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted).Sum(o => Convert.ToDecimal(o["SEGURO"]));

            if (ValorDespesaFaltando > 0 || ValorFreteFaltando > 0)
            {
                foreach (DataRow dr in PRODUTOS.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(Convert.ToDecimal(dr["IDINTEGRACAOFISCAL"]));

                    if (ValorDespesaFaltando == 0 && ValorFreteFaltando == 0 && ValorSeguroFaltando == 0)
                        break;

                    if (ValorDespesaFaltando != 0)
                    {
                        dr["OUTRASDESPESAS"] = Convert.ToDecimal(dr["OUTRASDESPESAS"]) + ValorDespesaFaltando;
                        ValorDespesaFaltando = 0;
                    }

                    if (ValorFreteFaltando != 0)
                    {
                        dr["FRETE"] = Convert.ToDecimal(dr["FRETE"]) + ValorFreteFaltando;
                        ValorFreteFaltando = 0;
                    }

                    if (ValorSeguroFaltando != 0)
                    {
                        dr["SEGURO"] = Convert.ToDecimal(dr["SEGURO"]) + ValorSeguroFaltando;
                        ValorSeguroFaltando = 0;
                    }

                    decimal ValorST = ProdutosNFeICMS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted && Convert.ToDecimal(dr["IDPRODUTONFE"]) == Convert.ToDecimal(o["IDPRODUTONFE"])).Sum(o => Convert.ToDecimal(o["VICMSST"]));

                    dr["VALORTOTAL"] = (((Convert.ToDecimal(dr["OUTRASDESPESAS"]) +
                                        Convert.ToDecimal(dr["FRETE"]) +
                                        Convert.ToDecimal(dr["VALORUNITARIO"]) +
                                        Convert.ToDecimal(dr["SEGURO"])) *
                                        Convert.ToDecimal(dr["QUANTIDADE"])) +
                                        ValorST) - Convert.ToDecimal(dr["DESCONTO"]);

                    //if (Integ.Financeiro == 1)
                    dr["TOTALFINANCEIRO"] = dr["VALORTOTAL"];
                }
            }

            foreach (DataRow dr in PRODUTOS.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;

                IntegracaoFiscal Integ = FuncoesIntegracaoFiscal.GetIntegracao(Convert.ToDecimal(dr["IDINTEGRACAOFISCAL"]));

                if (ValorDescontoFaltando != 0 && Convert.ToDecimal(dr["VALORTOTAL"]) + ValorDescontoFaltando < Convert.ToDecimal(dr["VALORTOTAL"]) || (Convert.ToDecimal(dr["DESCONTO"]) - ValorDescontoFaltando >= 0))
                {
                    dr["DESCONTO"] = Convert.ToDecimal(dr["DESCONTO"]) + ValorDescontoFaltando;
                    ValorDescontoFaltando = 0;
                }

                decimal ValorST = ProdutosNFeICMS.AsEnumerable().Where(o => o.RowState != DataRowState.Deleted && Convert.ToDecimal(dr["IDPRODUTONFE"]) == Convert.ToDecimal(o["IDPRODUTONFE"])).Sum(o => Convert.ToDecimal(o["VICMSST"]));

                dr["VALORTOTAL"] = (((Convert.ToDecimal(dr["OUTRASDESPESAS"]) +
                                      Convert.ToDecimal(dr["FRETE"]) +
                                      Convert.ToDecimal(dr["VALORUNITARIO"]) +
                                      Convert.ToDecimal(dr["SEGURO"])) *
                                      Convert.ToDecimal(dr["QUANTIDADE"])) +
                                      ValorST) - Convert.ToDecimal(dr["DESCONTO"]);
                //if (Integ.Financeiro == 1)
                dr["TOTALFINANCEIRO"] = dr["VALORTOTAL"];
            }
        }

        private void LimparDuplicatas()
        {
            foreach (DataRowView dr in Duplicatas.DefaultView)
                dr.Delete();
            gridControlFinanceiro.DataSource = Duplicatas;
            AjustaHeaderFinanceiro();
        }

        private void ovCKB_FreteSemFrete_CheckedChanged(object sender, EventArgs e)
        {
            if (ovCKB_FreteSemFrete.Checked)
            {
                Transportadora = null;
                EnderecoTransportadora = null;
                NFe.IDTransportadora = null;

                ovTXT_UFTransportadora.Text = string.Empty;
                ovTXT_Codtransportadora.Text = string.Empty;
                ovTXT_Transportadora.Text = string.Empty;
                ovTXT_TransportadoraCNPJCPF.Text = string.Empty;

                ovTXT_TransportadoraPlaca.Text = string.Empty;
                ovTXT_TransportadoraVeiculo.Text = string.Empty;
                ovTXT_TransportadoraANTT.Text = string.Empty;
            }

            button1.Enabled = !ovCKB_FreteSemFrete.Checked;
            ovTXT_TransportadoraPlaca.Enabled = !ovCKB_FreteSemFrete.Checked;
            ovTXT_TransportadoraVeiculo.Enabled = !ovCKB_FreteSemFrete.Checked;
            ovTXT_TransportadoraANTT.Enabled = !ovCKB_FreteSemFrete.Checked;
        }


        private void GerarDuplicatas(decimal IDMovimentoFiscal, decimal idVenda)
        {
            Venda venda = FuncoesVenda.GetVenda(idVenda);
            TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(venda.IDTipoDeOperacao);

            ContaCobranca ContaCob = FuncoesContaCobranca.GetContaCobranca(tipoDeOperacao.IDContaBancaria);
            if (ContaCob != null & (ContaCob.IDFormaDePagamento == (ovCMB_FormaPagamento.SelectedItem as FormaDePagamento).IDFormaDePagamento))
                if (MessageBox.Show(this, "Deseja Gerar e Imprimir as Duplicatas?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    GerarDuplicatasNFe(IDMovimentoFiscal, ContaCob);
        }

        private void GerarDuplicatasNFe(decimal IDMovimentoFiscal, ContaCobranca ContaCob)
        {
            try
            {
                PDVControlador.BeginTransaction();

                /* Inicio da geração de duplicatas */
                List<ContaReceber> Titulos = FuncoesContaReceber.GetContasReceberPorMovimentoFiscal(IDMovimentoFiscal);

                List<BoletoBancario> Boletos = BoletoUtil.GerarBoleto(Titulos, ContaCob);
                byte[] ArrBoletos = BoletoUtil.GeraLayoutPDF(Boletos);

                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Filter = "PDF|*.pdf";
                SaveFile.Title = "Duplicatas";
                SaveFile.ShowDialog(this);
                SaveFile.ShowHelp = false;
                if (string.IsNullOrEmpty(SaveFile.FileName))
                    throw new Exception("Nome do arquivo não pode ser vazio.");

                File.WriteAllBytes(SaveFile.FileName, ArrBoletos);
                System.Diagnostics.Process.Start(SaveFile.FileName);
                PDVControlador.Commit();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GVEN_ListaDeDAVs gVEN_ListaDeDAVs = new GVEN_ListaDeDAVs();

            gVEN_ListaDeDAVs.TOperacao = this.TOperacao;

            if (TOperacao == 1)
            {
               
            }
            else if (TOperacao == 2)
            {
               
                gVEN_ListaDeDAVs.ShowDialog();

                if (gVEN_ListaDeDAVs.Venda != null)
                CarregarPedido(gVEN_ListaDeDAVs.Venda);
                
                PreencherTela();
            }



        }
        public List<DuplicataNFCe> duplicataNFCe;
        private List<DuplicataDAC> DuplicataDAC;

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (gridViewProdutos.FocusedRowHandle < 0)
                    throw new Exception("Nenhum produto foi selecionado");

                var idProdutoNFe = Grids.GetValorDec(gridViewProdutos, "IDPRODUTONFE");


                var seletorCFOP = new GVEN_SeletorCFOP();
                seletorCFOP.ShowDialog();

                var idCfop = UFCliente != null ? ProcessarCFOP(seletorCFOP.IdCFOP) : seletorCFOP.IdCFOP;

                var rowProduto = PRODUTOS
                    .AsEnumerable()
                    .Where(p => Convert.ToDecimal(p["IDPRODUTONFE"]) == idProdutoNFe)
                    .FirstOrDefault();

                rowProduto["IDCFOP"] = rowProduto["CFOP"] = idCfop;
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
            
        }

        private void Alert(string message)
        {
            MessageBox.Show(message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ovTXT_CodNatOp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipo.SelectedIndex == 0)
            {
                TOperacao = 1;
                CFOPS = FuncoesCFOP.GetCFOPSAtivoPorTIPO(1);
                ovCMB_NaturezaOperacao.DataSource = CFOPS;
                simpleButtonCarregarVenda.Text = "Carregar Compra";
                label45.Text = "Nº da Compra";
            }
            else if (cbbTipo.SelectedIndex == 1)
            {
                TOperacao = 2;
                CFOPS = FuncoesCFOP.GetCFOPSAtivoPorTIPO(2);
                ovCMB_NaturezaOperacao.DataSource = CFOPS;
                simpleButtonCarregarVenda.Text = "Carregar Venda";
                label45.Text = "Nº da Venda";
            }
      

        }

        public void CarregarPedido(Venda venda)
        {
            try
            {
                TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(venda.IDTipoDeOperacao);
                 duplicataNFCe = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(venda.IDVenda);
                NFe.IDCliente = decimal.Parse(venda.IDCliente.ToString());
                NFe.IDFormaDePagamento = venda.IDFormaPagamento;
                NFe.IDUsuario = venda.IDUsuario;
                NFe.INDPagamento = duplicataNFCe.Count == 1  ? 0 : 1;
                //NFe.IDFormaDePagamento = formaDePagamento.IDFormaDePagamento;
                NFe.IDTipoAtendimento = tipoDeOperacao.IDTipoAtendimento;
                NFe.IDFinalidade = tipoDeOperacao.IDFinalidade;
                NFe.FretePor = tipoDeOperacao.TipoDeFrete;
                NFe.IDCFOP = tipoDeOperacao.IDOperacaoFiscal;
                NFe.IDTransportadora = tipoDeOperacao.IDTransportadora;
                NFe.Serie = tipoDeOperacao.Serie;
                NFe.Modelo = tipoDeOperacao.ModeloDocumento;                
                NFe.InformacoesComplementares = tipoDeOperacao.InformacoesComplementares;
                ovTXT_Modelo.Text = tipoDeOperacao.ModeloDocumento.ToString();
                ovTXT_Serie.Text = tipoDeOperacao.Serie.ToString() ;
                NFe.IDVenda = venda.IDVenda;


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, NOME_TELA,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        public void CarregarPedidoCompra(PedidoCompra Compra)
        {
            try
            {
                TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(Compra.IDTipoDeOperacao);
              
                DuplicataDAC = FuncoesDuplicataDAC.GetPagamentosPorCompra(Compra.IDPedidoCompra);
                 

                NFe.IDCliente = decimal.Parse(Compra.IDFornecedor.ToString());
                NFe.IDFormaDePagamento = Compra.IDFormaDePagamento;
                NFe.IDUsuario = Compra.IDUsuarioCadastro;
                NFe.INDPagamento = DuplicataDAC.Count == 1 ? 0 : 1;
                //NFe.IDFormaDePagamento = formaDePagamento.IDFormaDePagamento;
                NFe.IDTipoAtendimento = tipoDeOperacao.IDTipoAtendimento;
                NFe.IDFinalidade = tipoDeOperacao.IDFinalidade;
                NFe.FretePor = tipoDeOperacao.TipoDeFrete;
                NFe.IDCFOP = tipoDeOperacao.IDOperacaoFiscal;
                NFe.IDTransportadora = tipoDeOperacao.IDTransportadora;
                NFe.Serie = tipoDeOperacao.Serie;
                NFe.Modelo = tipoDeOperacao.ModeloDocumento;
                NFe.InformacoesComplementares = tipoDeOperacao.InformacoesComplementares;
                ovTXT_Modelo.Text = tipoDeOperacao.ModeloDocumento.ToString();
                ovTXT_Serie.Text = tipoDeOperacao.Serie.ToString();
                NFe.IDVenda = Compra.IDPedidoCompra;


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
