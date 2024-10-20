using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.UTIL.FORMS.Forms.Atualizador;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Cadastro.Financeiro.Modulo;
using PDV.VIEW.Forms.Configuracoes;
using PDV.VIEW.Forms.Consultas;
using PDV.VIEW.Forms.Consultas.Financeiro;
using PDV.VIEW.Forms.Consultas.Financeiro.Modulo;
using PDV.VIEW.Forms.Consultas.MDFe;
using PDV.VIEW.Forms.Consultas.Parametros;
using PDV.VIEW.Forms.Consultas.Suprimento;
using PDV.VIEW.Forms.Estoque.Gerenciamento;
using PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada;
using PDV.VIEW.Forms.Estoque.Inventario;
using PDV.VIEW.Forms.Estoque.PedidoDeCompra;
using PDV.VIEW.Forms.Estoque.Transferencia;
using PDV.VIEW.Forms.Financeiro;
using PDV.VIEW.Forms.Gerenciamento;
using PDV.VIEW.Forms.Relatorios;
using PDV.VIEW.Forms.Vendas.Manifesto;
using PDV.VIEW.Forms.Vendas.NFe;
using PDV.VIEW.SINTEGRA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PDV.VIEW
{
    public partial class Principal : MetroForm
    {
        private string NOME_TELA = "PAINEL INICIAL";

        public Principal()
        {
            InitializeComponent();
            Icon = Properties.Resources.Zeus1;
            Text = string.Format("Ebenezer Software - NextGestor ERP {0} - {1}", Contexto.VERSAO, NOME_TELA);
            CarregaInformacoesContexto();
            CarregarInformacoesIBPT();
            CarregarAtualizacaoDisponivel();
            CarergarInformacoesCertificado();
            VerificaPermissoes();
        }

        #region Carregamento das Informações

        private void CarregarInformacoesIBPT()
        {
            DAO.Entidades.Ncm Ncm = FuncoesNcm.GetVigenciaIBPT();
            if (Ncm == null)
            {
                ovTXT_ChaveIBPT.Text = "<Não Informado>";
                ovTXT_VigenciaIBPT.Text = "[Tabela não Importada]";
            }
            else
            {
                ovTXT_ChaveIBPT.Text = Ncm.Chave;
                ovTXT_VigenciaIBPT.Text = string.Format("{0} Até {1}", Ncm.VigenciaInicio.ToString("dd/MM/yyyy"), Ncm.VigenciaFim.ToString("dd/MM/yyyy"));
            }
        }

        private void CarregaInformacoesContexto()
        {
            ovTXT_LoginUsuario.Text = Contexto.USUARIOLOGADO.Login;
            ovTXT_NomeUsuario.Text = Contexto.USUARIOLOGADO.Nome;
            ovTXT_Footer.Text = "NextGestor ERP " + Contexto.VERSAO + string.Format(" Copyright ©  {0} - Todos os Direitos Reservados Ebenezer Software", DateTime.Now.Year);

            if (Contexto.USUARIOLOGADO.Root == 0)
            {
                //VerificaPermissaoItensMenu();
                ovTXT_PerfilUsuario.Text = Contexto.USUARIOLOGADO.PerfilAcesso;
            }
            else
            {
                Contexto.USUARIOLOGADO.PerfilAcesso = "ROOT";
                ovTXT_PerfilUsuario.Text = "ROOT";
            }
        }

        private void CarregarInformacoesNFCe()
        {
            ovTXT_NumeroNFCe.Text = Sequence.GetValorAtualSequence("ID" + Contexto.CONFIGURACAO_SERIE.NomeSequenceNFCe, Contexto.IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE).ToString();
            ovTXT_SerieNFCe.Text = Contexto.CONFIGURACAO_SERIE.SerieNFCe.ToString();
        }

        private void CarregarInformacoesNFe()
        {
            ovTXT_NumeroNFe.Text = Sequence.GetValorAtualSequence("ID" + Contexto.CONFIGURACAO_SERIE.NomeSequenceNFe, Contexto.IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE).ToString();
            ovTXT_SerieNFe.Text = Contexto.CONFIGURACAO_SERIE.SerieNFe.ToString();
        }

        private void CarergarInformacoesCertificado()
        {
            try
            {
                X509Certificate2 x509 = new X509Certificate2();
                Emitente EMIT = FuncoesEmitente.GetEmitente();
                x509.Import(EMIT.Certificado, Criptografia.DecodificaSenha(EMIT.SenhaCertificado), X509KeyStorageFlags.DefaultKeySet);

                ovTXT_DescricaoCertificado.Text = EMIT.NomeCertificado;
                ovTXT_ValidadeCertificado.Text = string.Format("Validade: {0} até {1}", x509.NotBefore.ToShortDateString(), x509.NotAfter.ToShortDateString());
            }
            catch (Exception)
            {
                ovTXT_DescricaoCertificado.Text = "<Não Informado>";
                ovTXT_ValidadeCertificado.Text = "<Não Informado>";
            }
        }

        private void ovTemp_Tick(object sender, EventArgs e)
        {
            int Hora = DateTime.Now.Hour;
            string Saudacao = string.Empty;
            if (Hora >= 0 && Hora <= 6)
                Saudacao = string.Format("Boa noite {0}, ", Contexto.USUARIOLOGADO.PerfilAcesso);

            if (Hora > 6 && Hora <= 13)
                Saudacao = string.Format("Bom dia {0}, ", Contexto.USUARIOLOGADO.PerfilAcesso);

            if (Hora > 13 && Hora <= 18)
                Saudacao = string.Format("Boa tarde {0}, ", Contexto.USUARIOLOGADO.PerfilAcesso);

            if (Hora > 18 && Hora <= 23)
                Saudacao = string.Format("Boa noite {0}, ", Contexto.USUARIOLOGADO.PerfilAcesso);

            ovTXT_BoasVindas.Text = Saudacao + DateTime.Now.ToString();
            CarregarInformacoesNFCe();
            CarregarInformacoesNFe();
        }

        private void CarregarAtualizacaoDisponivel()
        {
            try
            {
                ovBTN_VerificarAtualizacoes.Visible = true;
                ovTXT_VersaoAtual.Text = Contexto.VERSAO.ToString();
                ovTXT_VersaoDisponivel.Text = "Verificando Atualização...";

                VerificarAtualizacao();
            }
            catch
            {
                ovTXT_VersaoDisponivel.Text = "<NextGestor PDV Atualizado>";
            }
        }

        private void VerificarAtualizacao()
        {
            VersaoModulo Versao = ZeusUtil.VerificarVersaoDisponivel(DAO.Enum.Modulo.ERP, Contexto.VERSAO);
            ovTXT_VersaoAtual.Text = Versao.VersaoAtual.ToString();

            if (Versao.Disponivel)
                ovTXT_VersaoDisponivel.Text = Versao.VersaoDisponivel.ToString();
            else
                ovTXT_VersaoDisponivel.Text = "Nenhuma Versão Disponível...";

            ovBTN_VerificarAtualizacoes.Visible = Versao.Disponivel;
        }

        #endregion

        #region MouseHover/MouseLeaver
        private void ovBTN_Cadastros_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Cadastros.Image = Properties.Resources.hovericon_cadastros;
        }

        private void ovBNT_Fiscal_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Fiscal.Image = Properties.Resources.hovericon_fiscal;
        }

        private void ovBTN_Gerenciamento_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Gerenciamento.Image = Properties.Resources.hovericon_gerenciamento;
        }

        private void ovBTN_Estoque_MouseHover(object sender, EventArgs e)
        {

            ovBTN_Estoque.Image = Properties.Resources.hovericon_estoque;
        }

        private void ovBTN_Financeiro_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Financeiro.Image = Properties.Resources.hovericon_financeiro;
        }

        private void ovBTN_Relatorios_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Relatorios.Image = Properties.Resources.hovericon_relatorios;
        }

        private void ovBTN_Configuracoes_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Configuracoes.Image = Properties.Resources.hovericon_configuracoes;
        }

        private void ovBTN_Ajuda_MouseHover(object sender, EventArgs e)
        {
            ovBTN_Ajuda.Image = Properties.Resources.hovericon_ajuda;
        }

        private void ovBTN_Cadastros_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Cadastros.Image = Properties.Resources.icon_cadastros;
        }

        private void ovBNT_Fiscal_MouseLeave(object sender, EventArgs e)
        {

            ovBTN_Fiscal.Image = Properties.Resources.icon_fiscal;
        }

        private void ovBTN_Gerenciamento_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Gerenciamento.Image = Properties.Resources.icon_gerenciamento;

        }

        private void ovBTN_Estoque_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Estoque.Image = Properties.Resources.icon_estoque;

        }

        private void ovBTN_Financeiro_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Financeiro.Image = Properties.Resources.icon_financeiro;
        }

        private void ovBTN_Relatorios_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Relatorios.Image = Properties.Resources.icon_relatorios;
        }

        private void ovBTN_Configuracoes_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Configuracoes.Image = Properties.Resources.icon_configuracoes;

        }

        private void ovBTN_Ajuda_MouseLeave(object sender, EventArgs e)
        {
            ovBTN_Ajuda.Image = Properties.Resources.icon_ajuda;
        }

        #endregion

        #region ListarMenus
        private void ovBTN_VerificarAtualizacoes_Click(object sender, EventArgs e)
        {
            new FAT_AtualizarVersao(DAO.Enum.Modulo.ERP, new VersaoModulo()
            {
                VersaoAtual = Contexto.VERSAO,
                VersaoDisponivel = null
            }).ShowDialog(this);
        }

        private void ovBTN_Cadastros_Click_1(object sender, EventArgs e)
        {
            ovMenu_Cadastros.Show(ovBTN_Cadastros, new Point(0, ovBTN_Cadastros.Height));
        }

        private void ovBTN_Fiscal_Click(object sender, EventArgs e)
        {
            ovMenu_Fiscal.Show(ovBTN_Fiscal, new Point(0, ovBTN_Fiscal.Height));
        }

        private void ovBTN_Gerenciamento_Click(object sender, EventArgs e)
        {
            ovMenu_Gerenciamento.Show(ovBTN_Gerenciamento, new Point(0, ovBTN_Gerenciamento.Height));
        }

        private void ovBTN_Financeiro_Click(object sender, EventArgs e)
        {
            ovMenu_Financeiro.Show(ovBTN_Financeiro, new Point(0, ovBTN_Financeiro.Height));
        }

        private void ovBTN_Relatorios_Click(object sender, EventArgs e)
        {
            ovMenu_Relatorios.Show(ovBTN_Relatorios, new Point(0, ovBTN_Relatorios.Height));
        }

        private void ovBTN_Configuracoes_Click(object sender, EventArgs e)
        {
            ovMenu_Configuracoes.Show(ovBTN_Configuracoes, new Point(ovBTN_Configuracoes.Height));
        }

        private void ovBTN_Ajuda_Click(object sender, EventArgs e)
        {
            ovMenu_Ajuda.Show(ovBTN_Ajuda, new Point(ovBTN_Ajuda.Height));
        }

        private void ovBTN_Estoque_Click(object sender, EventArgs e)
        {
            ovMenu_Estoque.Show(ovBTN_Estoque, new Point(0, ovBTN_Estoque.Height));
        }

        #endregion

        #region Ações dos Menus

        private void transferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCA_Transferencia().ShowDialog(this);
        }

        private void ovBTN_EstoqueInventario_Click(object sender, EventArgs e)
        {
            new FESTCO_Inventario().ShowDialog(this);
        }
        private void gerenciarNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FEST_GerenciarNFeEntrada().ShowDialog(this);
        }

        private void importaçãoDaNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FEST_EscolhaFormatoImportacaoNFe().ShowDialog(this);
        }

        private void parâmetrosFinanceiroComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCONFIG_ParametrosFinanceiroNFeCompra().ShowDialog(this);
        }

        private void ovBTN_PedidoCompra_Click(object sender, EventArgs e)
        {
            new FCO_PedidoCompra().ShowDialog(this);
        }
        private void motivoDeCancelamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_MotivoCancelamento().ShowDialog(this);
        }
        private void movimentaçãoBancáriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCOFIN_MovimentacaoBancaria().ShowDialog(this);
        }

        private void conversãoDeUnidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_ConversaoUM().ShowDialog(this);
        }

        private void requisitanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Requisitante().ShowDialog(this);
        }

        private void almoxarifadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_Almoxarifado().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Categoria_Click(object sender, EventArgs e)
        {
            new FCO_Categorias().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Cliente_Click(object sender, EventArgs e)
        {
            new FCO_Cliente().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Emitente_Click(object sender, EventArgs e)
        {
            new FCA_Emitente().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Fornecedor_Click(object sender, EventArgs e)
        {
            new FCO_Fornecedor().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_FormaPagamento_Click(object sender, EventArgs e)
        {
            new FCO_FormaDePagamento().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_TipoTitulo_Click(object sender, EventArgs e)
        {
            new FCO_TipoTitulo().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_StatusTitulo_Click(object sender, EventArgs e)
        {
            new FCO_StatusTitulo().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_CentroCusto_Click(object sender, EventArgs e)
        {
            new FCO_CentoCusto().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_NaturezaFinanceira_Click(object sender, EventArgs e)
        {
            new FCO_NaturezaFinanceira().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_HistoricoFinanceiro_Click(object sender, EventArgs e)
        {
            new FCO_HistoricoFinanceiro().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_ContaBancaria_Click(object sender, EventArgs e)
        {
            new FCO_ContaBancaria().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_Talonario_Click(object sender, EventArgs e)
        {
            new FCO_Talonario().ShowDialog(this);
        }

        private void ovBTN_CadastroFinanceiro_CarteiraCobranca_Click(object sender, EventArgs e)
        {
            new FCO_ContaCobranca().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Marca_Click(object sender, EventArgs e)
        {
            new FCO_Marca().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Produto_Click(object sender, EventArgs e)
        {
            new FCO_Produto().ShowDialog(this);
        }

        private void ovBTN_Cadastro_Transportadora_Click(object sender, EventArgs e)
        {
            new FCO_Transportadora().ShowDialog(this);
        }

        private void ovBTN_Cadastro_UnidadeDeMedida_Click(object sender, EventArgs e)
        {
            new FCO_UnidadeMedida().ShowDialog(this);
        }

        private void ovBTN_CadastroFiscal_Portaria_Click(object sender, EventArgs e)
        {
            new FCO_Portaria().ShowDialog(this);
        }

        private void ovBTN_CadastroFiscal_IntegracaoFiscal_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new FCO_IntegracaoFiscal().ShowDialog(this);
            }
            
        }

        private void ovBTN_CadastroFiscal_AliquotaICMSPorEstado_Click(object sender, EventArgs e)
        {
            new FCA_AliquotaICMSPorEstado().ShowDialog(this);
        }

        private void ovBTN_CadastroManifesto_Condutor_Click(object sender, EventArgs e)
        {
            new FCO_Condutor().ShowDialog(this);
        }

        private void ovBTN_CadastroManifesto_Proprietario_Click(object sender, EventArgs e)
        {
            new FCO_Proprietario().ShowDialog(this);
        }

        private void ovBTN_CadastroManifesto_Veiculo_Click(object sender, EventArgs e)
        {
            new FCO_Veiculo().ShowDialog(this);
        }

        private void ovBTN_CadastroManifesto_Seguradora_Click(object sender, EventArgs e)
        {
            new FCO_Seguradora().ShowDialog(this);
        }

        private void ovBTN_Fiscal_EmissaoNFe_Click(object sender, EventArgs e)
        {
            new GVEN_NFe(new DAO.Entidades.NFe.NFe()).ShowDialog(this);
        }

        private void ovBTN_Fiscal_EmissaoMDFe_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new ManifestoDFE().ShowDialog(this);
            }

        }

        private void ovBTN_Gerenciamento_NFCeVendasContingencia_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new GER_NotasFiscaisConsumidor().ShowDialog(this);
            }
        }

        private void ovBTN_Gerenciamento_NFeVendas_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new GER_NFe().ShowDialog(this);
            }
        }

        private void ovBTN_Gerenciamento_ExportarNFCeNFe_Click(object sender, EventArgs e)
        {
            new GER_ExportarNFCe().ShowDialog(this);
        }

        private void ovBTN_Gerenciamento_EventosRegistradosNFCeNFe_Click(object sender, EventArgs e)
        {
            new GER_EventosRegistrados().ShowDialog(this);
        }

        private void ovBTN_Gerenciamento_ManifestoDocumentoFiscal_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new GER_Manifesto().ShowDialog(this);
            }
        }

        private void ovBTN_Configuracoes_Android_Click(object sender, EventArgs e)
        {
            new FCONFIG_Android().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_Atualizador_Click(object sender, EventArgs e)
        {
            new FCONFIG_Atualizador().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_Email_Click(object sender, EventArgs e)
        {
            new FCONFIG_Email().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFCe_Contingencia_Click(object sender, EventArgs e)
        {
            new FCONFIG_Contingencia().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFCe_Geral_Click(object sender, EventArgs e)
        {
            new FCONFIG_NFCeGeral().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFCe_ImpressaoDanfe_Click(object sender, EventArgs e)
        {
            new FCONFIG_ImpressaoDanfe().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFCe_ParametrosFinanceiro_Click(object sender, EventArgs e)
        {
            new FCONFIG_ParametrosFinanceiroNFCe().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFe_Geral_Click(object sender, EventArgs e)
        {
            new GERAL().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFe_ImpressaoDanfe_Click(object sender, EventArgs e)
        {
            new FCONFIG_DanfeNFe().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_NFe_ParametrosFinanceiro_Click(object sender, EventArgs e)
        {
            new FCONFIG_ParametrosFinanceiroNFe().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_MDFe_Geral_Click(object sender, EventArgs e)
        {
            new FCONFIG_MDFeGeral().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_MDFe_ImpressaoDamfe_Click(object sender, EventArgs e)
        {
            new FCONFIG_DamfeMDFe().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_IBPT_ImportarTabela_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new FCONFIG_ImportarTabelaIBPT().ShowDialog(this);
            }
        }

        private void ovBTN_Configuracoes_IBPT_ConsultarTabela_Click(object sender, EventArgs e)
        {
            new FCONFIG_ConsultarTabelaIBPT().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_Vendas_Geral_Click(object sender, EventArgs e)
        {
            new FCONFIG_Vendas_Geral().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_Vendas_Impressao_Click(object sender, EventArgs e)
        {
            new FCONFIG_ImpressaoPedidoVenda().ShowDialog(this);
        }

        private void ovBTN_Configuracoes_Geral_StatusSefaz_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();

            if (emitente == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (emitente.Certificado == null)
            {
                MetroMessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new FCONFIG_ConsultaStatusWS().ShowDialog(this);
            }
        }

        private void ovBTN_Configuracoes_Geral_WebServices_Click(object sender, EventArgs e)
        {
            new FCONFIG_WebServicesNFCE().ShowDialog(this);
        }

        private void ovBTN_Financeiro_ContasReceber_Click(object sender, EventArgs e)
        {
            new FCOFIN_ContaReceber().ShowDialog(this);
        }

        private void ovBTN_Financeiro_ContasPagar_Click(object sender, EventArgs e)
        {
            new FCOFIN_ContaPagar().ShowDialog(this);
        }

        private void ovBTN_Financeiro_ConciliacaoBancaria_Click(object sender, EventArgs e)
        {
            new FCAFIN_ConciliacaoBancaria().ShowDialog(this);
        }

        private void ovBTN_Financeiro_Duplicatas_Click(object sender, EventArgs e)
        {
            new GFIN_Duplicata().ShowDialog(this);
        }

        private void ovBTN_Financeiro_RenegociacaoDeContas_Click(object sender, EventArgs e)
        {
            new GFIN_RenegociacaoTitulo().ShowDialog(this);
        }

        private void ovBTN_Relatorios_ComandasAbertoUsuario_Click(object sender, EventArgs e)
        {
            new FREL_ComandasEmAberto().ShowDialog(this);
        }

        private void ovBTN_Relatorios_ImpressaoComandas_Click(object sender, EventArgs e)
        {
            new FREL_ImpressaoComandas().ShowDialog(this);
        }

        private void ovBTN_Relatorios_ProdutosFornecedor_Click(object sender, EventArgs e)
        {
            new FREL_ProdutosPorFornecedor().ShowDialog(this);
        }

        private void ovBTN_Ajuda_VerificarAtualizacoes_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                FAT_AtualizarVersao Form = new FAT_AtualizarVersao(DAO.Enum.Modulo.ERP, new VersaoModulo()
                {
                    VersaoAtual = Contexto.VERSAO,
                    VersaoDisponivel = null,
                });

                Form.ShowDialog(this);
                PDVControlador.Commit();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
            }
        }

        private void ovBTN_Ajuda_Sobre_Click(object sender, EventArgs e)
        {
            new Sobre().ShowDialog(this);
        }

        private void ovBTN_Ajuda_ConsultaCNPJ_Click(object sender, EventArgs e)
        {
            new FormConsultaSintegra(string.Empty).ShowDialog(this);
        }

        private void ovBTN_Ajuda_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_CadastroPermissoes_PerfilAcesso_Click(object sender, EventArgs e)
        {
            new FCO_PerfilAcesso().ShowDialog(this);
        }

        private void ovBTN_CadastroPermissoes_Usuario_Click(object sender, EventArgs e)
        {
            new FCO_Usuario().ShowDialog(this);
        }

        private void ovBTN_CadastroVendas_Click(object sender, EventArgs e)
        {
            new FCO_Comanda().ShowDialog(this);
        }

        private void fluxoDeCaixaPorUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FREL_FluxoDeCaixaDiarioPorUsuario().ShowDialog(this);
        }

        #endregion

        #region Permissões
        private void VerificaPermissoes()
        {
            if (Contexto.USUARIOLOGADO.Root == 1)
                return;

            ovBTN_VerificarAtualizacoes.Visible = Contexto.ITENSMENU.Where(o => o.IDItemMenu == (int)ItemMenuERP.AJUDA_VERIFICAR_ATUALIZACOES).Count() == 1;
            foreach (Component Comp in EnumerateComponents())
            {
                if (Comp.GetType() == typeof(UTIL.Components.Custom.ToolStripMenuItem))
                {
                    UTIL.Components.Custom.ToolStripMenuItem _Comp = ((UTIL.Components.Custom.ToolStripMenuItem)Comp);
                    _Comp.Visible = Contexto.ITENSMENU.Where(o => o.IDItemMenu == _Comp.IDItemMenu).Count() == 1 || _Comp.IDItemMenu == -1;
                }

                if (Comp.GetType() == typeof(UTIL.Components.Custom.PictureBox))
                {
                    UTIL.Components.Custom.PictureBox _Comp = ((UTIL.Components.Custom.PictureBox)Comp);
                    _Comp.Visible = Contexto.ITENSMENU.Where(o => o.IDItemMenu == _Comp.IDItemMenu).Count() == 1;
                }
            }
        }

        private IEnumerable<Component> EnumerateComponents()
        {
            var lQuery = from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         where typeof(Component).IsAssignableFrom(field.FieldType)
                         let component = (Component)field.GetValue(this)
                         where component != null
                         select component;

            return lQuery.Where(o => o.GetType().Equals(typeof(UTIL.Components.Custom.ToolStripMenuItem)) || o.GetType().Equals(typeof(UTIL.Components.Custom.PictureBox)));
        }
        #endregion

        private void Principal_Load(object sender, EventArgs e)
        {
//            Emitente emitente = FuncoesEmitente.GetEmitente();
//
//            if (emitente == null)
//            {
//                return;
//            }
//            else
//            {
//                try
//                {
//
//                    Sysadmin sysadmin = new Sysadmin();
//                    sysadmin.CheckLicense(emitente.CNPJ, 3);
//
//                }
//                catch (Exception ex)
//                {
//                    string cpuid = SysAdm.Sysadmin.GetCPUID();
//                    MessageBox.Show($@"{ex.Message}
//
//CNPJ: {emitente.CNPJ}
//Terminal: {cpuid}", "Licença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                    Clipboard.SetText(cpuid);
//                    Environment.Exit(1);
//                }
//            }
        }

        private void saldoEstoqueInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FCO_SaldoEstoqueInicial().ShowDialog(this);
        }
    }
}
