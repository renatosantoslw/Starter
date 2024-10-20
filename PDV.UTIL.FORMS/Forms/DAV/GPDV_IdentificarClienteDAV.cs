using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.UTIL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_IdentificarClienteDAV : MetroForm
    {
        public DataRow DRCliente = null;
        public bool Identificar = false;
        private bool ClienteNovo = false;
        public string IDCliente = "";

        private string _TipoCliente = "1";


        public GPDV_IdentificarClienteDAV()
        {
            InitializeComponent();
            ovTXT_ClienteEncontrado.Text = "";
            ovTXT_CPFCNPJ.LostFocus += OvTXT_CPFCNPJ_LostFocus;
            ovTXT_TipoPessoa.LostFocus += ovTXT_TipoPessoa_LostFocus;

            AplicarMascara();
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
                ovTXT_EmailCliente.Text = string.Empty;
                ovTXT_ClienteEncontrado.Text = "Novo Cliente";
                ovTXT_ClienteEncontrado.ForeColor = System.Drawing.Color.Red;
                ovTXT_NomeCliente.Visible = true;
                ClienteNovo = true;
                ovTXT_NomeCliente.Focus();
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
                    metroButton2_Click(metroButton2, null);
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
        private void metroButton2_Click(object sender, EventArgs e)
        {
            //FCO_ClienteDAV cliente = new FCO_ClienteDAV();
            //cliente.Consulta(this);
            //cliente.ShowDialog();
            //ovTXT_CPFCNPJ.Text = IDCliente.ToString();
            //OvTXT_CPFCNPJ_LostFocus(ovTXT_CPFCNPJ, null);
        }
    }
}
