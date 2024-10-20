using DFe.Utils;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Servicos.ConsultaCadastro;
using NFe.Servicos;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Cep;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Emitente : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE EMITENTE";
        private Emitente _Emitente = null;
        private Endereco _Endereco = null;
        private EmailEmitente _EmailEmitente = null;
        private List<RegimeTributario> Regimes = FuncoesRegimeTributario.GetRegimesTributario();

        private string MENSAGEM_AUTORIZAR =
                        (@"[nomeDest], 

                        Uma Nota Fiscal de Consumidor Eletrônica foi emitida em seu nome pela empresa [nomeEmit], CNPJ: [cnpjEmit].
                        Para consultar a autorização da nota junto a SEFA PR, clique no link abaixo:

                        [Link]

                        Nº da NF-e: [nNFe]
                        Série da NF-e: [serieNFe]
                        Chave de Acesso: [chNFe]

                        Em caso de dúvida entre em contato com a empresa emitente desta Nota Fiscal de Consumidor Eletrônica.").Trim();

        private string MENSAGEM_CANCELAR =
(@"[nomeDest], 

                        Uma Nota Fiscal de Consumidor Eletrônica foi cancelada em seu nome pela empresa [nomeEmit], CNPJ: [cnpjEmit].
                        Para consultar o cancelamento da nota junto a SEFA PR, clique no link abaixo:

                        [Link]

                        Nº da NF-e: [nNFe]
                        Série da NF-e: [serieNFe]
                        Chave de Acesso: [chNFe]

                        Em caso de dúvida entre em contato com a empresa emitente desta Nota Fiscal de Consumidor Eletrônica.").Trim();

        private string ASSUNTO_AUTORIZAR = "NF-e de [nomeEmit]";
        private string ASSUNTO_CANCELAR = "Cancelamento de NF-e de [nomeEmit]";
        private Emitente emitente;

        public FCA_Emitente(Emitente emitente = null)
        {
            InitializeComponent();

            metroTabControl1.SelectedTab = metroTabPage1;
            metroTabControl2.SelectedTab = metroTabPage5;

            ovCMB_Pais.DataSource = FuncoesPais.GetPaises();
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";

            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";

            ovCMB_Municipio.DisplayMember = "descricao";
            ovCMB_Municipio.ValueMember = "idunidadefederativa";

            ovCMB_RegimeTributario.DataSource = Regimes;
            ovCMB_RegimeTributario.ValueMember = "codigo";
            ovCMB_RegimeTributario.DisplayMember = "descricao";

            ovTXT_CNPJ.Mask = "##,###,###/####-##";

            _Emitente = FuncoesEmitente.GetEmitente();
            if (_Emitente != null)
            {
                _Endereco = FuncoesEndereco.GetEndereco(_Emitente.IDEndereco);
                _EmailEmitente = FuncoesEmitente.GetEmailEmitente(_Emitente.IDEmitente);

            }
            else
            {
                _Emitente = new Emitente();
                _Endereco = new Endereco();
                _EmailEmitente = new EmailEmitente();
            }
            //if (emitente.IDEmitente > 0)
            PreencheTela();


        }


        private void ovBTN_AbrirCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = CertificadoDigitalUtils.ListareObterDoRepositorio(); ;//.ListareObterDoRepositorio();
                _Emitente.Certificado = cert.GetRawCertData();

                ovTXT_NomeCertificado.Text = cert.GetSerialNumberString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, NOME_TELA);
            }
        }

        private void ovBTN_LimparLogomarca_Click(object sender, EventArgs e)
        {
            ovTXT_NomeArquivoLogomarca.Text = string.Empty;
            ovPB_Logotipo.Image = null;
            _Emitente.Logomarca = null;
            _Emitente.NomeLogomarca = null;
        }

        private void ovBTN_ProcurarLogomarca_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*.png|*.png";
            openFileDialog1.Title = "Imagens (*.png)";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                ovTXT_NomeArquivoLogomarca.Text = openFileDialog1.SafeFileName;
                ovPB_Logotipo.Image = Bitmap.FromFile(openFileDialog1.FileName);

                _Emitente.NomeLogomarca = openFileDialog1.SafeFileName;
                _Emitente.Logomarca = File.ReadAllBytes(openFileDialog1.FileName);
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

        private void PreencheTela()
        {
            ovTXT_CNPJ.Text = _Emitente.CNPJ;
            ovTXT_NomeCertificado.Text = _Emitente.NomeCertificado;

            ovTXT_NomeFantasia.Text = _Emitente.NomeFantasia;
            ovTXT_IDCSC.Text = _Emitente.IDCSC;
            ovTXT_CNAE.Text = _Emitente.CNAE.ToString();
            ovTXT_Email.Text = _Emitente.Email;
            ovTXT_EmailContador.Text = _Emitente.emailContador;
            ovTXT_InscricaoMunicipal.Text = _Emitente.InscricaoMunicipal;
            ovTXT_InscricaoEstadual.Text = _Emitente.InscricaoEstadual;
            ovTXT_CSC.Text = _Emitente.CSC;
            ovTXT_RazaoSocial.Text = _Emitente.RazaoSocial;
            ovCMB_RegimeTributario.SelectedItem = Regimes.Where(o => o.Codigo == _Emitente.CRT).FirstOrDefault();

            /* Endereço */
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

            /* Aba Logomarca */
            if (_Emitente.Logomarca != null)
            {
                ovTXT_NomeArquivoLogomarca.Text = _Emitente.NomeLogomarca;
                using (var ms = new MemoryStream(_Emitente.Logomarca))
                    ovPB_Logotipo.Image = Image.FromStream(ms);
            }
            else
            {
                ovPB_Logotipo.Image = null;
                ovTXT_NomeArquivoLogomarca.Text = string.Empty;
            }


            /*Aba propagada*/
            if (_Emitente.logopropraganda != null)
            {
                textBox1.Text = _Emitente.nomelogopropraganda;
                using (var ms = new MemoryStream(_Emitente.logopropraganda))
                    pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                pictureBox1.Image = null;
                textBox1.Text = string.Empty;
            }


            /* Aba Email */
            ovCKB_EnvioAoAutorizar.Checked = _EmailEmitente.AutorizarEnviarEmail == 1;
            ovTXT_AssuntoEmienteAutorizar.Text = string.IsNullOrEmpty(_EmailEmitente.AutorizarAssunto) ? ASSUNTO_AUTORIZAR : _EmailEmitente.AutorizarAssunto;
            ovTXT_MensagemAutorizar.Text = string.IsNullOrEmpty(_EmailEmitente.AutorizarMensagem) ? MENSAGEM_AUTORIZAR : _EmailEmitente.AutorizarMensagem;

            ovCKB_EnviarAoCancelar.Checked = _EmailEmitente.CancelarEnviarEmail == 1;
            ovTXT_AsuntoEmailCancelar.Text = string.IsNullOrEmpty(_EmailEmitente.CancelarAssunto) ? ASSUNTO_CANCELAR : _EmailEmitente.CancelarAssunto;
            ovTXT_MensagemEmailCancelar.Text = string.IsNullOrEmpty(_EmailEmitente.CancelarMensagem) ? MENSAGEM_CANCELAR : _EmailEmitente.CancelarMensagem;

            ovTXT_SenhaCertificado.Text = Criptografia.DecodificaSenha(_Emitente.SenhaCertificado);

            ///MFE 
            VersaoXMLTextBox.Text = _Emitente.VersaoXML;
            CodigoAtivacaoTextBox.Text = _Emitente.CodigoAtivacao;
            PastaInputTextBox.Text = _Emitente.PastaInput;
            PastaOutPutTextBox.Text = _Emitente.PastaOutPut;
            CNPJSoftwareHousetexttBox.Text = _Emitente.CNPJSoftwareHouse;
            SignACTextBox.Text = _Emitente.SignAC;
            CRegTribISSQNtextBox.Text = _Emitente.CRegTribISSQN;
            IndRatISSQNtextBox.Text = _Emitente.IndRatISSQN;
            chaveAcessoValidadorTextBox.Text = _Emitente.chaveAcessoValidador;
            pastaxmlTextBox.Text = _Emitente.PastaXml;
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.Enum.TipoOperacao OpEmitente;
                DAO.Enum.TipoOperacao OpEmailEmitente;
                DAO.Enum.TipoOperacao OpEndereco;

                if (_Emitente.IDEmitente == -1)
                {
                    _Emitente = new Emitente();
                    _Endereco = new Endereco();
                    _EmailEmitente = new EmailEmitente();
                    _Emitente.IDEmitente = Sequence.GetNextID("EMITENTE", "IDEMITENTE");
                    OpEmitente = DAO.Enum.TipoOperacao.INSERT;
                    OpEmailEmitente = DAO.Enum.TipoOperacao.INSERT;
                    OpEndereco = DAO.Enum.TipoOperacao.INSERT;

                }
                else
                {
                    OpEmitente = DAO.Enum.TipoOperacao.UPDATE;
                    OpEmailEmitente = DAO.Enum.TipoOperacao.UPDATE;
                    OpEndereco = DAO.Enum.TipoOperacao.UPDATE;
                }

                PDVControlador.BeginTransaction();


                string folder = pastaxmlTextBox.Text; //nome do diretorio a ser criado
                //Se o diretório não existir...

                if (!Directory.Exists(folder))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(folder);
                }
                if (!ValidarCampos())
                    return;

                /* Endereço */
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

                if (_Endereco.IDEndereco == -1)
                {
                    _Endereco.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                    OpEndereco = DAO.Enum.TipoOperacao.INSERT;
                }

                /* Emitente */
                _Emitente.SenhaCertificado = Criptografia.CodificaSenha(ovTXT_SenhaCertificado.Text);
                _Emitente.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CNPJ.Text);
                _Emitente.NomeFantasia = ovTXT_NomeFantasia.Text;
                _Emitente.IDCSC = ovTXT_IDCSC.Text;
                _Emitente.NomeCertificado = ovTXT_NomeCertificado.Text;

                _Emitente.CNAE = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CNAE.Text)))
                    _Emitente.CNAE = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_CNAE.Text));

                _Emitente.Email = ovTXT_Email.Text;

                _Emitente.emailContador = ovTXT_EmailContador.Text;

                _Emitente.InscricaoMunicipal = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoMunicipal.Text)))
                    _Emitente.InscricaoMunicipal = ZeusUtil.SomenteNumeros(ovTXT_InscricaoMunicipal.Text);

                _Emitente.InscricaoEstadual = ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text);
                _Emitente.CSC = ovTXT_CSC.Text;
                _Emitente.RazaoSocial = ovTXT_RazaoSocial.Text;
                _Emitente.CRT = (ovCMB_RegimeTributario.SelectedItem as RegimeTributario).Codigo;
                _Emitente.IDEndereco = _Endereco.IDEndereco;

                /* Email Emitente */
                if (_EmailEmitente.IDEmailEmitente == -1)
                {
                    _EmailEmitente.IDEmailEmitente = Sequence.GetNextID("EMAILEMITENTE", "IDEMAILEMITENTE");
                    OpEmailEmitente = DAO.Enum.TipoOperacao.INSERT;
                }

                _EmailEmitente.IDEmitente = _Emitente.IDEmitente;
                _EmailEmitente.AutorizarEnviarEmail = ovCKB_EnvioAoAutorizar.Checked ? 1 : 0;
                _EmailEmitente.AutorizarAssunto = ovTXT_AssuntoEmienteAutorizar.Text;
                _EmailEmitente.AutorizarMensagem = ovTXT_MensagemAutorizar.Text;

                _EmailEmitente.CancelarEnviarEmail = ovCKB_EnviarAoCancelar.Checked ? 1 : 0;
                _EmailEmitente.CancelarAssunto = ovTXT_AsuntoEmailCancelar.Text;
                _EmailEmitente.CancelarMensagem = ovTXT_MensagemEmailCancelar.Text;

                //MFE
                _Emitente.VersaoXML = VersaoXMLTextBox.Text;
                _Emitente.CodigoAtivacao = CodigoAtivacaoTextBox.Text;
                _Emitente.PastaInput = PastaInputTextBox.Text;
                _Emitente.PastaOutPut = PastaOutPutTextBox.Text;
                _Emitente.CNPJSoftwareHouse = CNPJSoftwareHousetexttBox.Text;
                _Emitente.SignAC = SignACTextBox.Text;
                _Emitente.CRegTribISSQN = CRegTribISSQNtextBox.Text;
                _Emitente.IndRatISSQN = IndRatISSQNtextBox.Text;
                _Emitente.chaveAcessoValidador = chaveAcessoValidadorTextBox.Text;
                _Emitente.PastaXml = pastaxmlTextBox.Text;

                if (!FuncoesEndereco.Salvar(_Endereco, OpEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesEmitente.SalvarEmitente(_Emitente, OpEmitente))
                    throw new Exception("Não foi possível salvar o Emitente.");

                if (!FuncoesEmitente.SalvarEmailEmitente(_EmailEmitente, OpEmailEmitente))
                    throw new Exception("Não foi possível salvar as Configurações de E-mail");

                PDVControlador.Commit();
                MessageBox.Show(this, "Emitente salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(ovTXT_CNPJ.Text.Trim()))
                throw new Exception("Informe o CNPJ.");

            if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text.Trim()))
                throw new Exception("Informe a Razão Social.");

            if (string.IsNullOrEmpty(ovTXT_SenhaCertificado.Text.Trim()))
                throw new Exception("Informe a Senha do Certificado.");

            //if (string.IsNullOrEmpty(ovTXT_CSC.Text.Trim()))
            //    throw new Exception("Informe o CSC.");

            if (string.IsNullOrEmpty(ovTXT_InscricaoEstadual.Text.Trim()))
                throw new Exception("Informe a Inscrição Estadual.");

            if (string.IsNullOrEmpty(ovTXT_NomeCertificado.Text.Trim()))
                throw new Exception("Selecione o Certificado.");

            //if (string.IsNullOrEmpty(ovTXT_IDCSC.Text.Trim()))
            //    throw new Exception("Informe o ID CSC(Token).");

            if (ovCMB_RegimeTributario.SelectedItem == null)
                throw new Exception("Selecione o Regime Tributário.");

            if (string.IsNullOrEmpty(ovTXT_Logradouro.Text.Trim()))
                throw new Exception("Informe o Logradouro.");

            if (string.IsNullOrEmpty(ovTXT_Numero.Text.Trim()))
                throw new Exception("Informe o Número.");

            if (string.IsNullOrEmpty(ovTXT_Bairro.Text.Trim()))
                throw new Exception("Informe o Bairro.");

            if (ovCMB_Pais.SelectedItem == null)
                throw new Exception("Selecione o Pais.");

            if (ovCMB_UF.SelectedItem == null)
                throw new Exception("Selecione o UF.");

            if (ovCMB_Municipio.SelectedItem == null)
                throw new Exception("Selecione o Município.");

            return true;
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

        private void web_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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
                catch { MessageBox.Show(this, "Cep não encontrado.", NOME_TELA); }
            }
            else
            {
                ovTXT_Cep.Text = "";
                MessageBox.Show(this, "Cep não encontrado.", NOME_TELA);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF do Emitente.");

                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFe.CfgServico);
                var retornoConsulta = servicoNFe.NfeConsultaCadastro((ovCMB_UF.SelectedItem as UnidadeFederativa).Sigla, ConsultaCadastroTipoDocumento.Cnpj, ZeusUtil.SomenteNumeros(ovTXT_CNPJ.Text));
                ovTXT_CNPJ.Text = retornoConsulta.Retorno.infCons.infCad.CNPJ;
                ovTXT_InscricaoEstadual.Text = retornoConsulta.Retorno.infCons.infCad.IE;
                ovTXT_CNAE.Text = retornoConsulta.Retorno.infCons.infCad.CNAE;
                ovTXT_RazaoSocial.Text = retornoConsulta.Retorno.infCons.infCad.xNome;
                ovTXT_NomeFantasia.Text = retornoConsulta.Retorno.infCons.infCad.xFant;

                /* Endereço */
                ovTXT_Logradouro.Text = retornoConsulta.Retorno.infCons.infCad.ender.xLgr;
                ovTXT_Numero.Text = retornoConsulta.Retorno.infCons.infCad.ender.nro;
                ovTXT_Cep.Text = retornoConsulta.Retorno.infCons.infCad.ender.CEP;
                ovTXT_Bairro.Text = retornoConsulta.Retorno.infCons.infCad.ender.xBairro;
                ovTXT_Complemento.Text = retornoConsulta.Retorno.infCons.infCad.ender.xCpl;

                List<Pais> _Paises = FuncoesPais.GetPaises();
                ovCMB_Pais.DataSource = _Paises;
                ovCMB_Pais.SelectedItem = _Paises.Where(o => o.Codigo.Equals("1058")).FirstOrDefault();

                List<UnidadeFederativa> _Unidades = FuncoesUF.GetUnidadesFederativa(_Paises.FirstOrDefault().IDPais);
                ovCMB_UF.DataSource = _Unidades;
                ovCMB_UF.SelectedItem = _Unidades.Where(o => o.Sigla.ToUpper().Equals(retornoConsulta.Retorno.infCons.infCad.UF)).FirstOrDefault();

                List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios((ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa);
                ovCMB_Municipio.DataSource = _Municipios;
                ovCMB_Municipio.SelectedItem = _Municipios.Where(o => o.CodigoIBGE == retornoConsulta.Retorno.infCons.infCad.ender.cMun).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, NOME_TELA);
            }
        }

        private void FCA_Emitente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void metroTabPage7_Click(object sender, EventArgs e)
        {

        }

        private void ovPB_Logotipo_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*.png|*.png";
            openFileDialog1.Title = "Imagens (*.png)";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox1.Text = openFileDialog1.SafeFileName;
                pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName);
                _Emitente.nomelogopropraganda = openFileDialog1.SafeFileName;
                _Emitente.logopropraganda = File.ReadAllBytes(openFileDialog1.FileName);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            pictureBox1.Image = null;
            _Emitente.nomelogopropraganda = null;
            _Emitente.logopropraganda = null;
        }

        private void FCA_Emitente_Load(object sender, EventArgs e)
        {

        }
    }
}