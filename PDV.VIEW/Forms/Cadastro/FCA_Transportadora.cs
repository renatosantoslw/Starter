using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using PDV.DAO.Enum;
using PDV.DAO.DB.Utils;
using PDV.VIEW.App_Context;
using MetroFramework.Forms;
using MetroFramework;
using System.Net;
using PDV.DAO.Entidades.Cep;
using System.Web.Script.Serialization;
using PDV.UTIL;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Transportadora : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE TRANSPORTADORA";
        public Transportadora Transportadora { get; set; }
        private Endereco _Endereco = null;
        public static readonly decimal[] idsMenuItem = { 17 };

        public FCA_Transportadora(Transportadora transportadora)
        {
            InitializeComponent();

            Transportadora = transportadora;

            metroTabControl1.SelectedTab = metroTabPage1;

            ovCMB_TipoDocumento.SelectedIndex = 0;
            ovTXT_Telefone.Mask = "(##) #####-####";
            ovTXT_Cep.Mask = "#####-###";
            ovTXT_Numero.Mask = "######";
            ovTXT_InscricaoEstadual.Mask = "##############";

            ovCMB_Pais.DataSource = FuncoesPais.GetPaises();
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";

            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";

            ovCMB_Municipio.DisplayMember = "descricao";
            ovCMB_Municipio.ValueMember = "idunidadefederativa";

            PreencherTela();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ovCMB_TipoDocumento.SelectedIndex)
            {
                case 0:
                    ovLBL_CNPJCPF.Text = "* CNPJ:";
                    ovTXT_CNPJCPF.Mask = "##,###,###/####-##";
                    ovLBL_RazaoSocial.Text = "* Razão Social";
                    ovTXT_CNPJCPF.Text = string.Empty;
                    break;
                case 1:
                    ovLBL_CNPJCPF.Text = "* CPF:";
                    ovTXT_CNPJCPF.Mask = "###,###,###-##";
                    ovLBL_RazaoSocial.Text = "* Nome";
                    ovTXT_CNPJCPF.Text = string.Empty;
                    break;
            }
        }

        private void ovCMB_UF_DropDown(object sender, EventArgs e)
        {
            if (ovCMB_Pais.SelectedItem == null)
            {
               MessageBox.Show(this, "Informe o Pais.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ovCMB_UF.DataSource = FuncoesUF.GetUnidadesFederativa(((Pais)ovCMB_Pais.SelectedItem).IDPais);
        }

        private void ovCMB_Municipio_DropDown(object sender, EventArgs e)
        {
            if (ovCMB_UF.SelectedItem == null)
            {
               MessageBox.Show(this, "Informe a UF.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ovCMB_Municipio.DataSource = FuncoesMunicipio.GetMunicipios(((UnidadeFederativa)ovCMB_UF.SelectedItem).IDUnidadeFederativa);
        }

        private void LimparSelecaoCombosEndereco(int Modo)
        {
            switch (Modo)
            {
                case 0:
                    ovCMB_UF.SelectedItem = null;
                    ovCMB_Municipio.SelectedItem = null;
                    break;
                case 1:
                    ovCMB_Municipio.SelectedItem = null;
                    break;
            }
        }

        private void ovCMB_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(1);
        }

        private void ovCMB_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            LimparSelecaoCombosEndereco(0);
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void PreencherTela()
        {
            /* Aba Identificação */
            ovCMB_TipoDocumento.SelectedIndex = Convert.ToInt32(Transportadora.TipoDocumento);
            ovTXT_CNPJCPF.Text = Transportadora.TipoDocumento == 0 ? Transportadora.CNPJ : Transportadora.CPF;

            ovTXT_RazaoSocial.Text = Transportadora.TipoDocumento == 0 ? Transportadora.RazaoSocial : Transportadora.Nome;

            ovTXT_InscricaoEstadual.Text = Transportadora.InscricaoEstadual.HasValue ? Transportadora.InscricaoEstadual.ToString() : string.Empty;
            ovCKB_Isento.Checked = Transportadora.Isento == 1;

            /* Aba Endereço */
            _Endereco = FuncoesEndereco.GetEndereco(Transportadora.IDEndereco);
            if (_Endereco == null)
                _Endereco = new Endereco();

            ovTXT_Logradouro.Text = _Endereco.Logradouro;
            ovTXT_Numero.Text = _Endereco.Numero;
            ovTXT_Cep.Text = _Endereco.Cep;
            ovTXT_Complemento.Text = _Endereco.Complemento;
            ovTXT_Bairro.Text = _Endereco.Bairro;
            ovTXT_Telefone.Text = _Endereco.Telefone;

            if (_Endereco.IDPais.HasValue)
            {
                List<Pais> _Paises = FuncoesPais.GetPaises();
                ovCMB_Pais.DataSource = _Paises;
                ovCMB_Pais.SelectedItem = _Paises.Where(o => o.IDPais == _Endereco.IDPais.Value).FirstOrDefault();

                if (_Endereco.IDUnidadeFederativa.HasValue)
                {
                    List<UnidadeFederativa> _Unidades = FuncoesUF.GetUnidadesFederativa(_Endereco.IDPais.Value);
                    ovCMB_UF.DataSource = _Unidades;
                    ovCMB_UF.SelectedItem = _Unidades.Where(o => o.IDUnidadeFederativa == _Endereco.IDUnidadeFederativa.Value).FirstOrDefault();

                    if (_Endereco.IDMunicipio.HasValue)
                    {
                        List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios(_Endereco.IDUnidadeFederativa.Value);
                        ovCMB_Municipio.DataSource = _Municipios;
                        ovCMB_Municipio.SelectedItem = _Municipios.Where(o => o.IDMunicipio == _Endereco.IDMunicipio.Value).FirstOrDefault();
                    }
                }
            }
        }

        private void Salvar()
        {
            try
            {
                PDVControlador.BeginTransaction();
                TipoOperacao TOTransportadora = TipoOperacao.UPDATE;
                if (!FuncoesTransportadora.ExisteTransportadora(Transportadora.IDTransportadora))
                {
                    TOTransportadora = TipoOperacao.INSERT;
                    Transportadora.IDTransportadora = Sequence.GetNextID("TRANSPORTADORA", "IDTRANSPORTADORA");
                }

                TipoOperacao TOEndereco = TipoOperacao.UPDATE;
                if (!FuncoesEndereco.ExisteEndereco(Transportadora.IDEndereco))
                {
                    TOEndereco = DAO.Enum.TipoOperacao.INSERT;
                    Transportadora.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                }

                /* Aba Transportadora */

                if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text))
                {
                   MessageBox.Show(this, "Informe a Razão Social.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ovTXT_RazaoSocial.Focus();
                    PDVControlador.Rollback();
                    return;
                }

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text)))
                {
                   MessageBox.Show(this, string.Format("Informe o {0}.", ovCMB_TipoDocumento.SelectedIndex == 0 ? "CNPJ" : "CPF"),
                                    NOME_TELA,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ovTXT_CNPJCPF.Focus();
                    return;
                }

                Transportadora.TipoDocumento = ovCMB_TipoDocumento.SelectedIndex;
                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                {
                    Transportadora.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    Transportadora.CPF = string.Empty;
                    Transportadora.Nome = string.Empty;
                    Transportadora.RazaoSocial = ovTXT_RazaoSocial.Text;                    
                }
                else
                {
                    Transportadora.CNPJ = string.Empty;
                    Transportadora.RazaoSocial = string.Empty;
                    Transportadora.CPF = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    Transportadora.Nome = ovTXT_RazaoSocial.Text;
                }
                                
                Transportadora.InscricaoEstadual = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text)))
                    Transportadora.InscricaoEstadual = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text));

                Transportadora.Isento = ovCKB_Isento.Checked ? 1 : 0;

                /* Aba Endereço */
                _Endereco.IDEndereco = Transportadora.IDEndereco;
                _Endereco.Logradouro = ovTXT_Logradouro.Text;
                _Endereco.Numero = null;
                if (!string.IsNullOrEmpty(ovTXT_Numero.Text))
                    _Endereco.Numero = ovTXT_Numero.Text;

                _Endereco.Complemento = ovTXT_Complemento.Text;
                _Endereco.Bairro = ovTXT_Bairro.Text;

                _Endereco.Cep = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_Cep.Text)))
                    _Endereco.Cep = ZeusUtil.SomenteNumeros(ovTXT_Cep.Text);

                _Endereco.IDPais = null;
                if (ovCMB_Pais.SelectedItem != null)
                    _Endereco.IDPais = ((Pais)ovCMB_Pais.SelectedItem).IDPais;

                _Endereco.IDUnidadeFederativa = null;
                if (ovCMB_UF.SelectedItem != null)
                    _Endereco.IDUnidadeFederativa = ((UnidadeFederativa)ovCMB_UF.SelectedItem).IDUnidadeFederativa;

                _Endereco.IDMunicipio = null;
                if (ovCMB_Municipio.SelectedItem != null)
                    _Endereco.IDMunicipio = ((Municipio)ovCMB_Municipio.SelectedItem).IDMunicipio;

                _Endereco.Telefone = ZeusUtil.SomenteNumeros(ovTXT_Telefone.Text);

                if (!FuncoesEndereco.Salvar(_Endereco, TOEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesTransportadora.Salvar(Transportadora, TOTransportadora))
                    throw new Exception("Não foi possível salvar a Transportadora.");
                
                PDVControlador.Commit();
               MessageBox.Show(this, "Transportadora salva com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
               MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetJsonUrl(ovTXT_Cep.Text);
        }

        public void GetJsonUrl(string Cep)
        {
            WebClient web = new WebClient();
            web.Encoding = System.Text.Encoding.UTF8;
            web.DownloadStringCompleted += web_DownloadStringCompleted;
            web.DownloadStringAsync(new Uri(string.Format("https://viacep.com.br/ws/{0}/json/", ZeusUtil.SomenteNumeros(Cep)), UriKind.RelativeOrAbsolute));
        }

        void web_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    LocalizacaoCep CEPLocalizado = new JavaScriptSerializer().Deserialize<LocalizacaoCep>(e.Result.ToString());
                    ovTXT_Logradouro.Text = CEPLocalizado.logradouro;
                    ovTXT_Bairro.Text = CEPLocalizado.bairro;

                    List<UnidadeFederativa> Unidades = FuncoesUF.GetUnidadesFederativa(((Pais)ovCMB_Pais.SelectedItem).IDPais);

                    ovCMB_UF.DataSource = Unidades;
                    ovCMB_UF.SelectedItem = Unidades.Where(o => o.Sigla.ToUpper().Equals(CEPLocalizado.uf)).FirstOrDefault();

                    List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios((ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa);
                    ovCMB_Municipio.DataSource = _Municipios;
                    ovCMB_Municipio.SelectedItem = _Municipios.Where(o => o.CodigoIBGE != null && o.CodigoIBGE.Equals(CEPLocalizado.ibge)).FirstOrDefault();
                }
                catch
                {
                    MessageBox.Show(this, "Cep não encontrado.", NOME_TELA);
                }
            }
            else
            {
                ovTXT_Cep.Text = "";
                MessageBox.Show(this, "Cep não encontrado.", NOME_TELA);
            }
        }

        private void FCA_Transportadora_KeyDown(object sender, KeyEventArgs e)
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