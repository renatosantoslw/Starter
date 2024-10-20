using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Marca : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE MARCAS";
        private Marca Marca = null;
        internal static readonly decimal[] idsMenuItem = { 19 };

        public FCA_Marca(Marca _Marca)
        {
            InitializeComponent();
            Marca = _Marca;
            PreencherTela();

            //icones

            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

            metroButton4.ImageOptions.Image = bitmapSalvar;
            metroButton5.ImageOptions.Image = bitmapCancelar;
        }

        private void PreencherTela()
        {
            ovTXT_Codigo.Text = string.IsNullOrEmpty(Marca.Codigo) ? ZeusUtil.GetProximoCodigo("MARCA", "CODIGO").ToString() : Marca.Codigo;
            ovTXT_Descricao.Text = Marca.Descricao;
            checkBoxMarcaDeProduto.Checked = Marca.MarcaDeProduto;
            checkBoxMarcaDeVeiculo.Checked = Marca.MarcaDeVeiculo;
            if (Marca.IDMarca == -1)
                checkBoxMarcaDeProduto.Checked = true;
        }
        public void SetCheckedEnabledFalse(int item)
        {
            //deixa uma das checkboxes marcada e desabilitada
            switch (item)
            {
                case 0:
                    checkBoxMarcaDeProduto.Checked = true;
                    checkBoxMarcaDeProduto.Enabled = false;
                    break;
                case 1:
                    checkBoxMarcaDeVeiculo.Checked = true;
                    checkBoxMarcaDeVeiculo.Enabled = false;
                    checkBoxMarcaDeProduto.Checked = false;
                    break;
            }
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

                if (string.IsNullOrEmpty(ovTXT_Codigo.Text.Trim()))
                    throw new Exception("Informe o Código.");

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                if (!checkBoxMarcaDeProduto.Checked && !checkBoxMarcaDeVeiculo.Checked)
                    throw new Exception("Informe se a marca é de produto e/ou de veículo.");

                Marca.Codigo = ovTXT_Codigo.Text;
                Marca.Descricao = ovTXT_Descricao.Text;
                Marca.MarcaDeProduto = checkBoxMarcaDeProduto.Checked;
                Marca.MarcaDeVeiculo = checkBoxMarcaDeVeiculo.Checked;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesMarca.Existe(Marca.IDMarca))
                {
                    Marca.IDMarca = Sequence.GetNextID("MARCA", "IDMARCA");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesMarca.Salvar(Marca, Op))
                    throw new Exception("Não foi possível salvar a Marca.");

                PDVControlador.Commit();
               MessageBox.Show(this, "Marca salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Marca_KeyDown(object sender, KeyEventArgs e)
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
