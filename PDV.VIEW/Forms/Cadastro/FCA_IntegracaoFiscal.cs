using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_IntegracaoFiscal : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE INTEGRAÇÃO FISCAL E OPERACIONAL";
        private IntegracaoFiscal INTEGRACAO = null;
        private Emitente EMITENTE = null;
        private List<Portaria> PORTARIAS = null;
        private List<TipoDeOperacao> TIPOS = null;
        private List<Cfop> CFOPS = null;
        private List<Cfop> CFOPSfora = null;
        private List<Cfop> CFOPSdev = null;
        private List<Cfop> CFOPSdevfora = null;
        private List<CSTIcms> ICMS = null;
        private List<CSTPis> PIS = null;
        private List<CSTCofins> COFINS = null;
        private List<CSTIpi> IPI = null;

        public FCA_IntegracaoFiscal(IntegracaoFiscal Integracao)
        {
            InitializeComponent();
            INTEGRACAO = Integracao;
            carreadarDadosCombo();

            PreencherTela();
        }

        private void carreadarDadosCombo()
        {
            try
            {
                EMITENTE = FuncoesEmitente.GetEmitente();

                PORTARIAS = FuncoesPortaria.GetPortarias();
                ovCMB_Portaria.DataSource = PORTARIAS;
                ovCMB_Portaria.DisplayMember = "titulo";
                ovCMB_Portaria.ValueMember = "idportaria";
                ovCMB_Portaria.SelectedItem = null;

                TIPOS = FuncoesTipoDeOperacao.GetListTiposDeOperacao();
                ovCMB_Tipo.DataSource = TIPOS;
                ovCMB_Tipo.DisplayMember = "Nome";
                ovCMB_Tipo.ValueMember = "IDTipoDeOperacao";
                ovCMB_Tipo.SelectedItem = null;

                CFOPS = FuncoesCFOP.GetCFOPSAtivos();
                ovCMB_CFOP.DataSource = CFOPS;
                ovCMB_CFOP.DisplayMember = "codigodescricao";
                ovCMB_CFOP.ValueMember = "idcfop";
                ovCMB_CFOP.SelectedItem = null;

                CFOPSfora = FuncoesCFOP.GetCFOPSAtivos();
                cbCFOPFora.DataSource = CFOPSfora;
                cbCFOPFora.DisplayMember = "codigodescricao";
                cbCFOPFora.ValueMember = "idcfop";
                cbCFOPFora.SelectedItem = null;

                CFOPSdev = FuncoesCFOP.GetCFOPSAtivos();
                cbCFOPDevolucao.DataSource = CFOPSdev;
                cbCFOPDevolucao.DisplayMember = "codigodescricao";
                cbCFOPDevolucao.ValueMember = "idcfop";
                cbCFOPDevolucao.SelectedItem = null;

                CFOPSdevfora = FuncoesCFOP.GetCFOPSAtivos();
                cbCFOPDevolucaoFora.DataSource = CFOPSdevfora;
                cbCFOPDevolucaoFora.DisplayMember = "codigodescricao";
                cbCFOPDevolucaoFora.ValueMember = "idcfop";
                cbCFOPDevolucaoFora.SelectedItem = null;

                ICMS = FuncoesCst.GetCSTIcms(EMITENTE.CRT);
                ovCMB_CSTIcms.DataSource = ICMS;
                ovCMB_CSTIcms.DisplayMember = "descricao";
                ovCMB_CSTIcms.ValueMember = "idcsticms";
                ovCMB_CSTIcms.SelectedItem = null;

                PIS = FuncoesCst.GetCSTPis();
                ovCMB_CSTPis.DataSource = PIS;
                ovCMB_CSTPis.DisplayMember = "descricao";
                ovCMB_CSTPis.ValueMember = "idcstpis";
                ovCMB_CSTPis.SelectedItem = null;

                COFINS = FuncoesCst.GetCSTCofins();
                ovCMB_CSTCofins.DataSource = COFINS;
                ovCMB_CSTCofins.DisplayMember = "descricao";
                ovCMB_CSTCofins.ValueMember = "idcstcofins";
                ovCMB_CSTCofins.SelectedItem = null;

                IPI = FuncoesCst.GetCSTIpi();
                ovCMB_CSTIpi.DataSource = IPI;
                ovCMB_CSTIpi.DisplayMember = "descricao";
                ovCMB_CSTIpi.ValueMember = "idcstipi";
                ovCMB_CSTIpi.SelectedItem = null;

                ovTXT_AliqICMS.AplicaAlteracoes();
                ovTXT_AliqICMSST.AplicaAlteracoes();
                ovTXT_Sequencia.AplicaAlteracoes();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = INTEGRACAO.Descricao;
            ovCMB_Portaria.SelectedItem = PORTARIAS.Where(o => o.IDPortaria == INTEGRACAO.IDPortaria).FirstOrDefault();
            ovCMB_Tipo.SelectedItem = TIPOS.Where(o => o.IDTipoDeOperacao == INTEGRACAO.IDTipoOperacao).FirstOrDefault();
            ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.IDCfop == INTEGRACAO.IDCFOP).FirstOrDefault();
            ovTXT_Sequencia.Value = INTEGRACAO.Sequencia;
            ovCKB_Financeiro.Checked = INTEGRACAO.Financeiro == 1;
            ovCKB_Estoque.Checked = INTEGRACAO.Estoque == 1;

            ovCKB_IncideICMS.Checked = INTEGRACAO.ICMS == 1;
            ovCKB_IncideICMSST.Checked = INTEGRACAO.ICMS_ST == 1;
            ovCKB_ICMSSIPI.Checked = INTEGRACAO.ICMS_IPI == 1;
            ovCKB_ReducaoBaseICMS.Checked = INTEGRACAO.ICMS_RED == 1;
            ovCKB_ReducaoBaseICMSST.Checked = INTEGRACAO.ICMS_REDST == 1;
            ovCKB_IcmsDef.Checked = INTEGRACAO.ICMS_DIF == 1;

            ovCMB_CSTIcms.SelectedItem = ICMS.Where(o => o.IDCSTIcms == INTEGRACAO.IDCSTIcms).FirstOrDefault();
            ovCMB_CSTPis.SelectedItem = PIS.Where(o => o.IDCSTPis == INTEGRACAO.IDCSTPis).FirstOrDefault();
            ovCMB_CSTCofins.SelectedItem = COFINS.Where(o => o.IDCSTCofins == INTEGRACAO.IDCSTCofins).FirstOrDefault();
            ovCMB_CSTIpi.SelectedItem = IPI.Where(o => o.IDCSTIpi == INTEGRACAO.IDCSTIpi).FirstOrDefault();

            ovCKB_AliquotaIcms.Checked = INTEGRACAO.ICMS_CDIFERENCIADO == 1;
            ovCKB_AliquotaICMSST.Checked = INTEGRACAO.ICMS_ST_CDIFERENCIADO == 1;

            ovTXT_AliqICMS.Value = INTEGRACAO.ICMS_DIFERENCIADO;
            ovTXT_AliqICMSST.Value = INTEGRACAO.ICMS_ST_DIFERENCIADO;

            ovCKB_IncideIPI.Checked = INTEGRACAO.IPI == 1;

            label5.Text = EMITENTE.CRT == 1 ? "* CSOSN:" : "* CST:";

            cbCFOPFora.SelectedItem = CFOPSfora.Where(o => o.IDCfop == INTEGRACAO.IDCFOPFORA).FirstOrDefault();
            cbCFOPDevolucao.SelectedItem = CFOPSdev.Where(o => o.IDCfop == INTEGRACAO.IDCFOPDEVOLUCAO).FirstOrDefault();
            cbCFOPDevolucaoFora.SelectedItem = CFOPSdevfora.Where(o => o.IDCfop == INTEGRACAO.IDCFOPDEVOLUCAOFORA).FirstOrDefault();


        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovCKB_AliquotaIcms_CheckedChanged(object sender, EventArgs e)
        {
            if (ovCKB_AliquotaIcms.Checked)
            {
                ovTXT_AliqICMS.Enabled = true;
            }
            else
            {
                ovTXT_AliqICMS.Enabled = false;
                ovTXT_AliqICMS.Value = 0;
            }
        }

        private void ovCKB_AliquotaICMSST_CheckedChanged(object sender, EventArgs e)
        {
            if (ovCKB_AliquotaICMSST.Checked)
            {
                ovTXT_AliqICMSST.Enabled = true;
            }
            else
            {
                ovTXT_AliqICMSST.Enabled = false;
                ovTXT_AliqICMSST.Value = 0;
            }
        }

        private bool ValidaDados()
        {
            if (string.IsNullOrEmpty(ovTXT_Descricao.Text))
                throw new Exception("Preencha a Descrição.");

            if (ovCMB_Tipo.SelectedItem == null)
                throw new Exception("Selecione o Tipo.");

            if (ovCMB_CFOP.SelectedItem == null)
                throw new Exception("Selecione o CFOP.");

            if (ovCMB_CSTIcms.SelectedItem == null)
                throw new Exception(string.Format("Selecione o {0}.", EMITENTE.CRT == 1 ? "CSOSN" : "CST"));

            if (ovCMB_CSTPis.SelectedItem == null)
                throw new Exception(string.Format("Selecione o CST PIS."));

            if (ovCMB_CSTCofins.SelectedItem == null)
                throw new Exception(string.Format("Selecione o CST COFINS."));

            if (ovCMB_CSTIpi.SelectedItem == null)
                throw new Exception(string.Format("Selecione o CST IPI."));

            return true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (ValidaDados())
                {
                    TipoOperacao Op = TipoOperacao.UPDATE;
                    if (!FuncoesIntegracaoFiscal.Existe(INTEGRACAO.IDIntegracaoFiscal))
                    {
                        Op = TipoOperacao.INSERT;
                        INTEGRACAO.IDIntegracaoFiscal = Sequence.GetNextID("INTEGRACAOFISCAL", "IDINTEGRACAOFISCAL");
                    }

                    INTEGRACAO.Descricao = ovTXT_Descricao.Text;

                    INTEGRACAO.IDPortaria = null;
                    if (ovCMB_Portaria.SelectedItem != null)
                        INTEGRACAO.IDPortaria = (ovCMB_Portaria.SelectedItem as Portaria).IDPortaria;

                    INTEGRACAO.IDTipoOperacao = (ovCMB_Tipo.SelectedItem as TipoDeOperacao).IDTipoDeOperacao;
                    INTEGRACAO.IDCFOP = (ovCMB_CFOP.SelectedItem as Cfop).IDCfop;
                    INTEGRACAO.Sequencia = ovTXT_Sequencia.Value;
                    INTEGRACAO.Financeiro = ovCKB_Financeiro.Checked ? 1 : 0;
                    INTEGRACAO.Estoque = ovCKB_Estoque.Checked ? 1 : 0;

                    INTEGRACAO.ICMS = ovCKB_IncideICMS.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_ST = ovCKB_IncideICMSST.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_IPI = ovCKB_ICMSSIPI.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_RED = ovCKB_ReducaoBaseICMS.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_REDST = ovCKB_ReducaoBaseICMSST.Checked ? 1 : 0;
                    INTEGRACAO.IDCSTIcms = (ovCMB_CSTIcms.SelectedItem as CSTIcms).IDCSTIcms;
                    INTEGRACAO.IDCSTPis = (ovCMB_CSTPis.SelectedItem as CSTPis).IDCSTPis;
                    INTEGRACAO.IDCSTCofins = (ovCMB_CSTCofins.SelectedItem as CSTCofins).IDCSTCofins;
                    INTEGRACAO.IDCSTIpi = (ovCMB_CSTIpi.SelectedItem as CSTIpi).IDCSTIpi;
                    INTEGRACAO.ICMS_CDIFERENCIADO = ovCKB_AliquotaIcms.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_ST_CDIFERENCIADO = ovCKB_AliquotaICMSST.Checked ? 1 : 0;
                    INTEGRACAO.ICMS_DIFERENCIADO = ovTXT_AliqICMS.Value;
                    INTEGRACAO.ICMS_ST_DIFERENCIADO = ovTXT_AliqICMSST.Value;
                    INTEGRACAO.ICMS_DIF = ovCKB_IcmsDef.Checked ? 1 : 0;
                    INTEGRACAO.IPI = ovCKB_IncideIPI.Checked ? 1 : 0;

                    if (cbCFOPFora.SelectedItem != null)
                    {
                        INTEGRACAO.IDCFOPFORA = (cbCFOPFora.SelectedItem as Cfop).IDCfop;
                    }
                    if (cbCFOPDevolucao.SelectedItem != null)
                    {
                        INTEGRACAO.IDCFOPDEVOLUCAO = (cbCFOPDevolucao.SelectedItem as Cfop).IDCfop;
                    }
                    if (cbCFOPDevolucaoFora.SelectedItem != null)
                    {
                        INTEGRACAO.IDCFOPDEVOLUCAOFORA = (cbCFOPDevolucaoFora.SelectedItem as Cfop).IDCfop;
                    }

                    if (!FuncoesIntegracaoFiscal.Salvar(INTEGRACAO, Op))
                        throw new Exception("Não foi possível salvar a Integração Fiscal.");
                }

                PDVControlador.Commit();
                MessageBox.Show(this, "Integração Fiscal salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ovTXT_CFOP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ovCMB_CFOP.SelectedItem = CFOPS.Where(o => o.Codigo == ZeusUtil.SomenteNumeros(ovTXT_CFOP.Text)).FirstOrDefault();

                if (ovCMB_CFOP.SelectedItem == null)
                {
                    MessageBox.Show(this, "CFOP não encontrado.");
                    ovTXT_CFOP.Select();
                    ovTXT_CFOP.SelectAll();
                }
            }
        }

        private void FCA_IntegracaoFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
