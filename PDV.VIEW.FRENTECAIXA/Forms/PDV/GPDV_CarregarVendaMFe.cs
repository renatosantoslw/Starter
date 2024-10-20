using ACBr.Net.Sat;
using CFeImpressao;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic.Devices;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.FRENTECAIXA.App_Context;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.Comanda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cliente = PDV.DAO.Entidades.Cliente;
using Sequence = PDV.DAO.DB.Utils.Sequence;
using PDV.DAO.Entidades;
using PDV.DAO.Custom;
using PDV.VIEW.FRENTECAIXA.Forms.PDV.Classes;
using IntegracaoMFE;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_CarregarVendaMFe : DevExpress.XtraEditors.XtraForm
    {
        public string NOME_TELA = "CARREGAR VENDA MFE";

        private DataTable DADOS = null;
        public ACBrSat acbrSat;
        private readonly ACBrConfig config;
        public DataRow LinhaSelecionada = null;
        
        #region Dados do Pedido APP
        public DAO.Entidades.PDV.Venda Venda = null;
        public List<ItemVenda> lstItemDeVenda = null;
        public List<DuplicataNFCe> lstPagamentos = null;
        public CONTROLER.Funcoes.FuncoesComanda Comanda = null;
        public Cliente Cliente = null;
        public bool Alteracao = false;
        public decimal IDItemVenda { get; set; }
        #endregion

        public GPDV_CarregarVendaMFe()
        {
            InitializeComponent();
            //Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.70);
            //Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.60);
            //config = ACBrConfig.CreateOrLoad(Path.Combine(Application.StartupPath, "sat.config"));
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;

                if (LinhaSelecionada["STATUS"].ToString() == "CANCELADO")
                {
                    MessageBox.Show(this, "Venda já foi cancelada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string XML = FuncoesMovimentoFiscal.GetXMLEnvio(Convert.ToDecimal(LinhaSelecionada["IDMOVIMENTOFISCAL"]));

                CFe cFe = new CFe();
                cFe = CFe.Load(XML);
                IntegracaoMFE.MFE mfe = new IntegracaoMFE.MFE();
                mfe.XmlRetornoAutorizacaoMFE = cFe;
                #region Instanciando Classes       
                Emitente Emitente = new Emitente();
                //Obter Dados da Empresa
                Emitente = FuncoesEmitente.GetEmitente();
                #endregion
                mfe.CodigoAtivacao = Emitente.CodigoAtivacao; //Codigo de Ativação do Equipamento
                mfe.GravarXmlEmPasta = true; //Se Deseja gravar o XML em uma pasta
                mfe.LocalArquivoXML = @"C:\Temp"; //Se o campo acima for true deve informar o local
                mfe.PastaImput = Emitente.PastaInput; // Local da Pasta Input do Integrador (esta informado as configurações do  Integrador Fiscal)
                mfe.PastaOutput = Emitente.PastaOutPut; // Local da Pasta OutPut do Integrador (esta informado as configurações do  Integrador Fiscal)
                mfe.TipoEnvioDLL = true; //Se utiliza o Software da Sefaz Drive MFE de Comunicação Direta, deve informar como true
                Decimal versao = Convert.ToDecimal(Emitente.VersaoXML.Replace(".", ","));
                  
                IntegracaoMFE.RetornosMFE retornoMFE = new IntegracaoMFE.RetornosMFE(0,"");
              
                CFeCanc cancCfe = new CFeCanc(cFe);
                var xmlCancelamento = Encoding.Default.GetBytes(cancCfe.GetXml());

                string motivo = XtraInputBox.Show("Informe o motivo do cancelamento", "Cancelar Compra", "");

                retornoMFE = mfe.CancelamentoMFE(mfe.XmlRetornoAutorizacaoMFE.InfCFe.Id, cancCfe.GetXml());
                String Texto = "Codigo: " + retornoMFE.CodigoRetorno + Environment.NewLine +
                                                  "Descrição: " + retornoMFE.DescricaoRetorno + Environment.NewLine +
                                                  "Chave de Acesso do XML da Venda: " + (mfe.XmlRetornoCancelamentoMFE != null ? mfe.XmlRetornoCancelamentoMFE.InfCFe.Id : "");

                MessageBox.Show(Texto.ToString());

                if (retornoMFE.Cancelada())
                {
                    //Gravar no BD o XML da Venda Cancelada
                    var xmlCFe = mfe.XmlRetornoCancelamentoMFE.GetXml();
                    var xmlCancelado = Encoding.Default.GetBytes(xmlCFe);
                    
                    FuncoesMovimentoFiscal.CancelarMovimentoMFe(Convert.ToDecimal(LinhaSelecionada["IDMOVIMENTOFISCAL"]), xmlCancelado);
                   
                    if (string.IsNullOrEmpty(motivo))
                    {
                        MessageBox.Show(this, "Informe o motivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FuncoesVenda.MudarStatus(Convert.ToDecimal(LinhaSelecionada["IDVENDA"]),3, "Cancelado");
                    MessageBox.Show(this, "Cancelamento Homologado sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                carregarDados();
                ImpressaoCFe impressao = new ImpressaoCFe(cFe);
                    impressao.ImprimirCFeCancelado("TP-450");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Erro ao Cancelar CFe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F10:
                    CarregarVenda();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CarregarVenda()
        {
            LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;
            DAO.Entidades.PDV.Venda _Venda = FuncoesVenda.GetVenda(Convert.ToDecimal(LinhaSelecionada["IDVENDA"]));
        }

        private bool AutenticarUsuarioSuperior(DAO.Entidades.PDV.Venda _Venda)
        {
            if (FuncoesUsuario.GetUsuarioSupervisor(_Venda.IDUsuario).IDUsuario != Contexto.USUARIOLOGADO.IDUsuario)
            {
                if (!_Venda.IDComandaUtilizada.HasValue && _Venda.IDUsuario != Contexto.USUARIOLOGADO.IDUsuario)
                {
                    /* Solicita Pin do usuário superior do usuário logado. */
                    GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior AutenticacaoUser = new GVEN_PedidoVendaComanda_IdentificarUsuarioSuperior();
                    AutenticacaoUser.ShowDialog(this);
                    return AutenticacaoUser.Autenticou;
                }
                else
                    return true;
            }
            else
                return true;
        }


        private void GPDV_CarregarVenda_Load(object sender, EventArgs e)
        {
            Network net = new Network();
            if (net.IsAvailable)
            {
                // ImportarPedidoAPP();
            }
            carregarDados();
        }

        private void carregarDados()
        {
            DADOS = FuncoesVenda.GetVendasPDVMFe();
            ovGRD_Comandas.DataSource = DADOS;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Comandas.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Comandas.Width;
            foreach (DataGridViewColumn column in ovGRD_Comandas.Columns)
            {
                switch (column.Name)
                {
                    case "idvenda":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "CÓDIGO";
                        break;
                    case "datacadastro":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "DATA VENDA";
                        break;

                    case "status":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "STATUS";
                        break;

                    case "usuario":
                        column.DisplayIndex = 4;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "USUÁRIO";
                        break;

                    case "documento":
                        column.DisplayIndex = 5;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "CPF/CNPJ";
                        break;
                    
                    case "cliente":
                        column.DisplayIndex = 6;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "CLIENTE";
                        break;
                    case "quantidadeitens":
                        column.DisplayIndex = 7;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "QTD. ITENS";
                        break;
                    case "valortotal":
                        column.DisplayIndex = 8;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "VALOR TOTAL";
                        break;

                    case "numero":
                        column.DisplayIndex = 9;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "NUMERO";
                        break;

                    case "chave":
                        column.DisplayIndex = 10;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "CHAVE";
                        break;

                    case "xmotivo":
                        column.DisplayIndex = 11;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "XMOTIVO";
                        break;

                    case "idmovimentofiscal":
                        column.DisplayIndex = 12;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "IDMOVIMENTOFISCAL";
                        break;

                    case "idrespostafiscal":
                        column.DisplayIndex = 13;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
                        column.Width = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "RESPOSTA FISCAL";
                        break;

                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        public void IniciarVenda()
        {
            lstItemDeVenda = new List<ItemVenda>();
            Venda = new DAO.Entidades.PDV.Venda()
            {
                IDVenda = Sequence.GetNextID("VENDA", "IDVENDA"),
                IDUsuario = 1,
                DataCadastro = DateTime.Now,
                Status = 0,
                IDFluxoCaixa = 0//!string.IsNullOrEmpty(FLUXO.IDFluxoCaixa) ? FLUXO.IDFluxoCaixa : 0,
            };

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;
                string XML = FuncoesMovimentoFiscal.GetXMLEnvio(Convert.ToDecimal(LinhaSelecionada["IDMOVIMENTOFISCAL"]));
                CFe cFe = new CFe();
                cFe = CFe.Load(XML);

                DAO.Entidades.Configuracao configNomeImpressora = FuncoesConfiguracao.GetConfiguracao(ChavesConfiguracao.CHAVE_CONFIGUACAODANFE_NOMEIMPRESSORA);
                var impressora = configNomeImpressora != null ? Encoding.UTF8.GetString(configNomeImpressora.Valor) : string.Empty;
                if (impressora == null)
                {
                    MessageBox.Show("Impressora não configurada...");
                }
                else
                {
                    if (LinhaSelecionada["STATUS"].ToString() == "CANCELADO")
                    {
                        ImpressaoCFe impressao = new ImpressaoCFe(cFe);
                        impressao.ImprimirCFeCancelado(impressora);
                    }
                    else
                    {
                        ImpressaoCFe impressao = new ImpressaoCFe(cFe);
                        impressao.ImprimirCFe(impressora);
                    }
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Erro ao Cancelar CFe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToogleInitialize()
        {
            if (acbrSat.Ativo)
            {
                acbrSat.Desativar();
            }
            else
            {
                acbrSat.Ativar();
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            LinhaSelecionada = (ovGRD_Comandas.CurrentRow.DataBoundItem as DataRowView).Row;
            string XML = FuncoesMovimentoFiscal.GetXMLEnvio(Convert.ToDecimal(LinhaSelecionada["IDMOVIMENTOFISCAL"]));
            CFe cFe = new CFe();
            cFe = CFe.Load(XML);
            MFE mFe = new MFE();
            ACBrSat aCBrSat = new ACBrSat();
            //acbrSat.
            //aCBrSat.ImprimirExtrato(cFe);

            ImpressaoFiscal imprimeCFe = new ImpressaoFiscal();
            imprimeCFe.ImprimirCFe(cFe);

        }
    }
}
