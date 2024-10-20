using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Seletores;
using PDV.VIEW.Forms.Vendas.NFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Suprimentos
{
    public partial class FCA_ConversaoUM : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CONVERSÃO DE UNIDADE DE MEDIDA";
        private Produto Produto = null;
        private Fornecedor Fornecedor = null;

        private ConversaoUnidadeDeMedida Conversao = null;
        private List<UnidadeMedida> UnidadesEntrada = null;
        private List<UnidadeMedida> UnidadesSaida = null;

        public FCA_ConversaoUM(ConversaoUnidadeDeMedida _Conversao)
        {
            InitializeComponent();
            Conversao = _Conversao;

            ovTXT_Fator.AplicaAlteracoes();
            UnidadesEntrada = FuncoesUnidadeMedida.GetUnidadesMedida();
            UnidadesSaida = FuncoesUnidadeMedida.GetUnidadesMedida();

            ovCMB_UnidadeEntrada.DataSource = UnidadesEntrada;
            ovCMB_UnidadeEntrada.DisplayMember = "sigla";
            ovCMB_UnidadeEntrada.ValueMember = "idunidadedemedida";

            ovCMB_UnidadeSaida.DataSource = UnidadesSaida;
            ovCMB_UnidadeSaida.DisplayMember = "sigla";
            ovCMB_UnidadeSaida.ValueMember = "idunidadedemedida";

            PreencherTela();



            //icones
            
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);
                                             
            metroButton3.ImageOptions.Image = bitmapSalvar;
            metroButton4.ImageOptions.Image = bitmapCancelar;
                       
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var SeletorProduto = new GVEN_SeletorProduto(false);
            SeletorProduto.ShowDialog(this);
            if (SeletorProduto.drProduto != null)
            {
                Produto = FuncoesProduto.GetProduto(Convert.ToDecimal(SeletorProduto.drProduto["IDPRODUTO"]));
                PreencherProduto();
            }
        }

        private void ovTXT_CodProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DataRow drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(ovTXT_CodProduto.Text.Trim());
                    if (drProduto == null)
                        return;
                    Produto = FuncoesProduto.GetProduto(Convert.ToDecimal(drProduto["IDPRODUTO"]));
                    PreencherProduto();
                    break;
            }
        }

        private void PreencherTela()
        {
            Produto = FuncoesProduto.GetProduto(Conversao.IDProduto);
            Fornecedor = FuncoesFornecedor.GetFornecedor(Conversao.IDFORNECEDOR);
            

            PreencherProduto();
            PreencherFornecedor();

            ovCMB_UnidadeEntrada.SelectedItem = UnidadesEntrada.Where(o => o.IDUnidadeDeMedida == Conversao.IDUnidadeDeMedidaEntrada).FirstOrDefault();
            ovCMB_UnidadeSaida.SelectedItem = UnidadesSaida.Where(o => o.IDUnidadeDeMedida == Conversao.IDUnidadeDeMedidaSaida).FirstOrDefault();


            ovTXT_Fator.Value = Conversao.Fator;
            ovCMB_Calculo.Text = Conversao.CALCULO;
        }

        private void PreencherProduto()
        {
            ovTXT_CodProduto.Text = string.Empty;
            ovTXT_Produto.Text = string.Empty;
            if (Produto != null)
            {
                ovTXT_CodProduto.Text = Produto.Codigo;
                ovTXT_Produto.Text = Produto.Descricao;
            }
        }



        private void PreencherFornecedor()
        {
            txtCodFornecedor.Text = string.Empty;
            txtFornecedor.Text = string.Empty;

            if (Fornecedor != null)
            {
                txtCodFornecedor.Text =Convert.ToString(Fornecedor.IDFornecedor);
                txtFornecedor.Text = Fornecedor.RazaoSocial;
                txtProdutoFornecedor.Text = Conversao.CODIGOPRODUTOFORNECEDOR;
            }
        }



        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();


                if (Fornecedor == null)
                    throw new Exception("Selecione o Fornecedor.");

                if (Produto == null)
                    throw new Exception("Selecione o Produto.");
                

                if (ovCMB_UnidadeEntrada.SelectedItem == null)
                    throw new Exception("Selecione a Unidade de Medida de Entrada.");

                if (ovCMB_UnidadeSaida.SelectedItem == null)
                    throw new Exception("Selecione a Unidade de Medida de Saida.");

                if (ovCMB_Calculo.SelectedItem == null)
                    throw new Exception("Selecione o Cálculo.");




                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesConversaoUnidadeMedida.Existe(Conversao.IDConversaoUnidadeDeMedida))
                {
                    Op = TipoOperacao.INSERT;
                    Conversao.IDConversaoUnidadeDeMedida = Sequence.GetNextID("CONVERSAOUNIDADEDEMEDIDA", "IDCONVERSAOUNIDADEDEMEDIDA");
                }

                if (Produto != null)
                    Conversao.IDProduto = Produto.IDProduto;

            
                Conversao.IDUnidadeDeMedidaEntrada = (ovCMB_UnidadeEntrada.SelectedItem as UnidadeMedida).IDUnidadeDeMedida;
                Conversao.IDUnidadeDeMedidaSaida = (ovCMB_UnidadeSaida.SelectedItem as UnidadeMedida).IDUnidadeDeMedida;
                Conversao.Fator = ovTXT_Fator.Value;
                Conversao.CALCULO = ovCMB_Calculo.Text;

                Conversao.IDFORNECEDOR = Convert.ToInt32(txtCodFornecedor.Text);
                Conversao.CODIGOPRODUTOFORNECEDOR = txtProdutoFornecedor.Text;




                if (!FuncoesConversaoUnidadeMedida.Salvar(Conversao, Op))
                    throw new Exception("Não foi possível salvar a Conversão.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Conversão salva com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                PDVControlador.Rollback();
            }
        }

        private void FCA_ConversaoUM_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btnSelecionarFornecedor_Click(object sender, EventArgs e)
        {
            var SeletorFornecedor = new SEL_Fornecedor();

            SeletorFornecedor.ShowDialog(this);
            if (SeletorFornecedor.drFornecedor != null)
            {

                Fornecedor = FuncoesFornecedor.GetFornecedor(Convert.ToDecimal(SeletorFornecedor.drFornecedor["IDFORNECEDOR"]));

                PreencherFornecedor();
            }
        }

        private void txtCodFornecedor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtFornecedor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ovTXT_CodProduto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ovTXT_Produto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtProdutoFornecedor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ovCMB_UnidadeEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ovCMB_Calculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ovTXT_Fator_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
