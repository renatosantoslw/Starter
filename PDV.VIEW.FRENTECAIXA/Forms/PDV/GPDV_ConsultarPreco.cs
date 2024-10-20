using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_ConsultarPreco : DevExpress.XtraEditors.XtraForm
    {
        public GPDV_ConsultarPreco()
        {
            InitializeComponent();
        }

        private void ovTXT_CodigoBarrasProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DataRow drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(ovTXT_CodigoBarrasProduto.Text.Trim());
                    if (drProduto != null)
                    {
                        if (!FuncoesProduto.ExisteTributoVigenteProduto(Convert.ToDecimal(drProduto["IDPRODUTO"])))
                        {
                            ovTXT_StatusConsulta.Text = string.Format("* O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", drProduto["PRODUTO"].ToString());
                            return;
                        }

                        ovTXT_DescricaoProduto.Text = drProduto["PRODUTO"].ToString();
                        ovTXT_Marca.Text = string.IsNullOrEmpty(drProduto["MARCA"].ToString()) ? "<Não Informado>" : drProduto["MARCA"].ToString();

                        ovTXT_ValorUnitarioPrazo.Text = string.IsNullOrEmpty(drProduto["PRECOVENDAPRAZO"].ToString()) ? "<Não Informado>" : Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");

                        ovTXT_ValorUnitario.Text = Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");


                       // if (!DBNull.Value.Equals(drProduto["PRECOVENDAPRAZO"]))
                         //   ovTXT_ValorUnitarioPrazo.Text = Convert.ToDecimal(drProduto["PRECOVENDAPRAZO"]).ToString("n2");


                       // ovTXT_ValorUnitarioPrazo.Text = Convert.ToDecimal(drProduto["PRECOVENDAPRAZO"]).ToString("n2");
                        


                        ovTXT_UnidadeMedida.Text = drProduto["UNIDADEDEMEDIDA"].ToString();
                        ovTXT_StatusConsulta.Text = string.Empty;
                    }
                    else
                    {
                        ovTXT_DescricaoProduto.Text = string.Empty;
                        ovTXT_Marca.Text = string.Empty;
                        ovTXT_ValorUnitario.Text = string.Empty;
                        ovTXT_ValorUnitarioPrazo.Text = string.Empty;
                        ovTXT_UnidadeMedida.Text = string.Empty;

                        ovTXT_StatusConsulta.Text = "* Produto não encontrado. Verifique e tente novamente!";
                    }
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
