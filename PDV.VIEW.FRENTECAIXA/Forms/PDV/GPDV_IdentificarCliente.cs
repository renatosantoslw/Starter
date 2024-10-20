using FontAwesome.Sharp;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.Forms.Consultas;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_IdentificarCliente : DevExpress.XtraEditors.XtraForm
    {
        private GPDV_PainelInicial PainelInicial = null;
        public DataRow DRCliente = null;
        public bool Identificar = false;
        private bool ClienteNovo = false;
        public string IDCliente = "";

        private string _TipoCliente = "1";


        public GPDV_IdentificarCliente(GPDV_PainelInicial _PainelInicial)
        {
            InitializeComponent();
            PainelInicial = _PainelInicial;
            ovTXT_ClienteEncontrado.Text = "";
            ovTXT_CPFCNPJ.LostFocus += OvTXT_CPFCNPJ_LostFocus;
            ovTXT_TipoPessoa.LostFocus += ovTXT_TipoPessoa_LostFocus;
            AplicarMascara();

            Bitmap bitmapConsultar = IconChar.Search.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.DarkGreen, 32);

            simpleButton1.ImageOptions.Image = bitmapConsultar;
            metroButton10.ImageOptions.Image = bitmapSalvar;


        }

        private void ovTXT_TipoPessoa_LostFocus(object sender, EventArgs e)
        {
            if (!_TipoCliente.Equals(ovTXT_TipoPessoa.Text))
            {
                AplicarMascara();
                ovTXT_ClienteEncontrado.Text = string.Empty;
                ovTXT_EmailCliente.Text = string.Empty;
            }
        }

        private void AplicarMascara()
        {
            switch (ovTXT_TipoPessoa.Text.Trim())
            {
                case "0":
                    ovTXT_TipoDocumento.Text = "* CNPJ:";
                    ovTXT_CPFCNPJ.Mask = "##,###,###/####-##";
                    ovTXT_CPFCNPJ.Text = string.Empty;
                    ovTXT_ClienteEncontrado.Text = string.Empty;
                    break;
                case "1":
                    ovTXT_TipoDocumento.Text = "* CPF:";
                    ovTXT_CPFCNPJ.Mask = "###,###,###-##";
                    ovTXT_CPFCNPJ.Text = string.Empty;
                    ovTXT_ClienteEncontrado.Text = string.Empty;
                    break;
            }
        }

        private void OvTXT_CPFCNPJ_LostFocus(object sender, EventArgs e)
        {
            if (!(ovTXT_TipoPessoa.Text.Trim().Equals("0") || ovTXT_TipoPessoa.Text.Trim().Equals("1")))
                ovTXT_TipoPessoa.Text = "1";

            DRCliente = FuncoesCliente.GetClientePorTipoEDocumento(Convert.ToDecimal(ovTXT_TipoPessoa.Text.Trim()), ZeusUtil.SomenteNumeros(ovTXT_CPFCNPJ.Text).ToString());
            if (DRCliente == null)
            {


               // MessageBox.Show("Cliente não encontrado! Acesse o botão pesquisa para cadastrá-lo");
                ovTXT_ClienteEncontrado.Text = "Cliente não localizado.";
                ovTXT_ClienteEncontrado.ForeColor = System.Drawing.Color.Red;
                /*
                ovTXT_EmailCliente.Text = string.Empty;
                ovTXT_ClienteEncontrado.Text = "Novo Cliente";
                ovTXT_ClienteEncontrado.ForeColor = System.Drawing.Color.Red;
                ovTXT_NomeCliente.Visible = true;
                ClienteNovo = true;
                ovTXT_NomeCliente.Focus();*/

            }
            else
            {
                ovTXT_EmailCliente.Text = DRCliente["EMAIL"].ToString();
                ovTXT_ClienteEncontrado.Text = DRCliente["NOME"].ToString(); ;
                ovTXT_ClienteEncontrado.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Identificar = false;
                    Close();
                    break;
                case Keys.F12: //IDENTIFICAR O CLIENTE
                    SalvarIdentificacao();
                    break;
                case Keys.F3:
                    Consultar();
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SalvarIdentificacao();
        }

        private void SalvarIdentificacao()
        {
            if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CPFCNPJ.Text)))
            {
                ovTXT_CPFCNPJ.Select();
                return;
            }
            if (ClienteNovo)
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Ativo = 1;
                    cliente.Nome = ovTXT_NomeCliente.Text;
                    cliente.TipoDocumento = decimal.Parse(ovTXT_TipoPessoa.Text);
                    cliente.IDEndereco = null;
                    cliente.IDContato = null;
                    if (ovTXT_TipoPessoa.Text == "1")
                        cliente.CPF = ovTXT_CPFCNPJ.Text.Replace(".", "").Replace("-", "");
                    else
                    {
                        cliente.RazaoSocial = ovTXT_NomeCliente.Text;
                        cliente.CNPJ = ovTXT_CPFCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "");
                    }
                    cliente.Email = ovTXT_EmailCliente.Text;
                    TipoOperacao Op = TipoOperacao.INSERT;
                    FuncoesCliente.Salvar(cliente, Op);
                }
                catch (Exception ex)
                {
                    string ss = ex.InnerException.ToString(); // throw new Exception("Não foi possível salvar o cliente");
                }
            }
            Identificar = true;
            Close();
        }
        private void metroButton10_Click(object sender, EventArgs e)
        {
            SalvarIdentificacao();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            FCO_Cliente cliente = new FCO_Cliente(true);
            cliente.ShowDialog();
            if (cliente.Cliente != null)
            {
                ovTXT_CPFCNPJ.Text = cliente.Cliente._CPF_CNPJ;
            }
            OvTXT_CPFCNPJ_LostFocus(ovTXT_CPFCNPJ, null);
        }
    }
}
