using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Entidades.MDFe.Tipos;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    public partial class FCA_Proprietario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE PROPRIETÁRIO";
        private List<TipoPropriedade> Tipos;
        private List<UnidadeFederativa> Unidades;
        private ProprietarioVeiculoMDFe ProprietarioMDFe;

        public FCA_Proprietario(ProprietarioVeiculoMDFe Prop)
        {
            InitializeComponent();
            ProprietarioMDFe = Prop;

            Unidades = FuncoesUF.GetUnidadesFederativa(1058);
            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";
            ovCMB_UF.DataSource = Unidades;
            ovCMB_UF.SelectedItem = null;

            Tipos = TipoPropriedade.GetTipos();
            ovCMB_TipoProprietario.DataSource = Tipos;
            ovCMB_TipoProprietario.DisplayMember = "descricao";
            ovCMB_TipoProprietario.ValueMember = "idtipopropriedade";
            ovCMB_TipoProprietario.SelectedItem = null;

            ovTXT_CodigoPorto.AplicaAlteracoes();
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Nome.Text = ProprietarioMDFe.Nome;
            ovTXT_RNTRC.Text = ProprietarioMDFe.RNTRC;
            ovTXT_InscricaoEstadual.Text = ProprietarioMDFe.InscricaoEstadual?.ToString();
            ovCMB_UF.SelectedItem = Unidades.Where(o => o.IDUnidadeFederativa == ProprietarioMDFe.IDUnidadeFederativa).FirstOrDefault();
            ovTXT_CodigoPorto.Value = ProprietarioMDFe.CodigoAgenciaPorto ?? 0;
            ovCMB_TipoProprietario.SelectedItem = Tipos.Where(o => o.IDTipoPropriedade == ProprietarioMDFe.TipoProprietario).FirstOrDefault();
            if (!string.IsNullOrEmpty(ProprietarioMDFe.CPF))
            {
                ovCKB_Fisica.Checked = true;
                ovTXT_CPF.Text = ProprietarioMDFe.CPF;
            }
            else
            {
                ovCKB_Juridica.Checked = true;
                ovTXT_CPF.Text = ProprietarioMDFe.CNPJ;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Nome.Text))
                    throw new Exception("Informe o Nome.");

                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF.");

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CPF.Text)))
                    throw new Exception($"Informe o {ovLBL_CPF.Text}.");

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text)) && ovCKB_Juridica.Checked)
                    throw new Exception("Informe a Inscricao Estadual.");

                if (ovCMB_TipoProprietario == null)
                    throw new Exception("Selecione o Tipo do Proprietário.");

                ProprietarioMDFe.Nome = ovTXT_Nome.Text;
                ProprietarioMDFe.RNTRC = ovTXT_RNTRC.Text;

                ProprietarioMDFe.InscricaoEstadual = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text)))
                    ProprietarioMDFe.InscricaoEstadual = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text));

                ProprietarioMDFe.IDUnidadeFederativa = (ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa;
                ProprietarioMDFe.CodigoAgenciaPorto = ovTXT_CodigoPorto.Value;
                ProprietarioMDFe.TipoProprietario = (ovCMB_TipoProprietario.SelectedItem as TipoPropriedade).IDTipoPropriedade;
                if (ovCKB_Fisica.Checked)
                {
                    ProprietarioMDFe.CNPJ = null;
                    ProprietarioMDFe.CPF = ZeusUtil.SomenteNumeros(ovTXT_CPF.Text);
                }
                else
                {
                    ProprietarioMDFe.CPF = null;
                    ProprietarioMDFe.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CPF.Text);
                }

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesProprietario.Existe(ProprietarioMDFe.IDProprietarioVeiculoMDFe))
                {
                    ProprietarioMDFe.IDProprietarioVeiculoMDFe = Sequence.GetNextID("PROPRIETARIOVEICULOMDFE", "IDPROPRIETARIOVEICULOMDFE");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesProprietario.Salvar(ProprietarioMDFe, Op))
                    throw new Exception("Não foi possível salvar o Proprietário.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Proprietário salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ovCKB_Fisica_CheckedChanged(object sender, EventArgs e)
        {
            ovLBL_CPF.Text = "* CPF:";
            ovTXT_CPF.Mask = "###,###,###-##";
            ovTXT_InscricaoEstadual.Text = string.Empty;
            ovTXT_InscricaoEstadual.Enabled = false;
            ovTXT_InscricaoEstadual.ReadOnly = true;
        }

        private void ovCKB_Juridica_CheckedChanged(object sender, EventArgs e)
        {
            ovLBL_CPF.Text = "* CNPJ:";
            ovTXT_CPF.Mask = "##,###,###/####-##";
            ovTXT_InscricaoEstadual.Enabled = true;
            ovTXT_InscricaoEstadual.ReadOnly = false;
        }

        private void FCA_Proprietario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
