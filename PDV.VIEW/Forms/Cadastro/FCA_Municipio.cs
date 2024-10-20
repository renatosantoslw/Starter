using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Municipio : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE MUNICÍPIO";
        private Municipio _Municipio = null;
        private List<UnidadeFederativa> Unidades = FuncoesUF.GetUnidadesFederativa();

        public FCA_Municipio(Municipio _M)
        {
            InitializeComponent();
            _Municipio = _M;

            ovCMB_UF.DataSource = Unidades;
            ovCMB_UF.DisplayMember = "descricao";
            ovCMB_UF.ValueMember = "idunidadefederativa";

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = _Municipio.Descricao;
            ovCMB_UF.SelectedItem = Unidades.Where(o => o.IDUnidadeFederativa == _Municipio.IDUnidadeFederativa).FirstOrDefault();
            ovTXT_CodigoIBGE.Text = _Municipio.CodigoIBGE;
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_CodigoIBGE.Text.Trim()))
                    throw new Exception("Informe o Código do IBGE.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF.");

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesMunicipio.Existe(_Municipio.IDMunicipio))
                {
                    _Municipio.IDMunicipio = Sequence.GetNextID("MUNICIPIO", "IDMUNICIPIO");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }
                _Municipio.CodigoIBGE = ovTXT_CodigoIBGE.Text;
                _Municipio.Descricao = ovTXT_Descricao.Text;
                _Municipio.IDUnidadeFederativa = (ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa;

                if (!FuncoesMunicipio.Salvar(_Municipio, Op))
                    throw new Exception("Não foi possível salvar o Município.");

                PDVControlador.Commit();
               MessageBox.Show(this, "Município salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Municipio_KeyDown(object sender, KeyEventArgs e)
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
