using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    public partial class FCA_Condutor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CONDUTOR";
        private Condutor CONDUTOR = null;
        private List<UnidadeFederativa> UnidadesFederativa = null;
        public static readonly decimal[] idsMenuItem = { 44 };

        public FCA_Condutor(Condutor Cond)
        {
            InitializeComponent();
            CONDUTOR = Cond;

            UnidadesFederativa = FuncoesUF.GetUnidadesFederativa(1058);
            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";
            ovCMB_UF.DataSource = UnidadesFederativa;
            ovCMB_UF.SelectedItem = null;

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_CPF.Text = CONDUTOR.CPF;
            ovTXT_Nome.Text = CONDUTOR.Nome;
            ovCKB_Ativo.Checked = CONDUTOR.Ativo == 1;
            ovCMB_UF.SelectedItem = UnidadesFederativa.Where(o => o.IDUnidadeFederativa == CONDUTOR.IDUnidadeFederativa).FirstOrDefault();
        }

        private void metroButton5_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CPF.Text)))
                    throw new Exception("Informe o CPF.");

                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF.");

                if (string.IsNullOrEmpty(ovTXT_Nome.Text))
                    throw new Exception("Informe o Nome.");

                CONDUTOR.CPF = ZeusUtil.SomenteNumeros(ovTXT_CPF.Text);
                CONDUTOR.IDUnidadeFederativa = (ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa;
                CONDUTOR.Nome = ovTXT_Nome.Text;
                CONDUTOR.Ativo = ovCKB_Ativo.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesCondutor.Existe(CONDUTOR.IDCondutor))
                {
                    CONDUTOR.IDCondutor = Sequence.GetNextID("CONDUTOR", "IDCONDUTOR");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesCondutor.Salvar(CONDUTOR, Op))
                    throw new Exception("Não foi possível salvar o Condutor.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Condutor salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Condutor_KeyDown(object sender, KeyEventArgs e)
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
