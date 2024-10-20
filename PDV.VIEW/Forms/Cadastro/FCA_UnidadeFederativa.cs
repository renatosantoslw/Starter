using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MetroFramework.Forms;
using MetroFramework;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_UnidadeFederativa : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE UNIDADE FEDERATIVA";
        private UnidadeFederativa UF = null;
        private List<Pais> Paises = FuncoesPais.GetPaises();

        public FCA_UnidadeFederativa(UnidadeFederativa Unidade)
        {
            InitializeComponent();
            UF = Unidade;

            ovCMB_Pais.DataSource = Paises;
            ovCMB_Pais.ValueMember = "idpais";
            ovCMB_Pais.DisplayMember = "descricao";

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Sigla.Text = UF.Sigla;
            ovTXT_Descricao.Text = UF.Descricao;

            ovCMB_Pais.SelectedItem = Paises.Where(o => o.IDPais == UF.IDPais).FirstOrDefault();
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Sigla.Text.Trim()))
                    throw new Exception("Informe a Sigla.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                if (ovCMB_Pais.SelectedItem == null)
                    throw new Exception("Selecione o Pais.");

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesUF.Existe(UF.IDUnidadeFederativa))
                {
                    UF.IDUnidadeFederativa = Sequence.GetNextID("UNIDADEFEDERATIVA", "IDUNIDADEFEDERATIVA");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                UF.Sigla = ovTXT_Sigla.Text;
                UF.Descricao = ovTXT_Descricao.Text;
                UF.IDPais = (ovCMB_Pais.SelectedItem as Pais).IDPais;

                if (!FuncoesUF.Salvar(UF, Op))
                    throw new Exception("Não foi possível salvar a Unidade Federativa.");

                PDVControlador.Commit();
               MessageBox.Show(this, "Unidade Federativa salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_UnidadeFederativa_KeyDown(object sender, KeyEventArgs e)
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
