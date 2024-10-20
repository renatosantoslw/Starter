using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using PDV.VIEW.App_Context;
using PDV.DAO.DB.Utils;
using System.Net;
using PDV.DAO.Entidades.Cep;
using System.Web.Script.Serialization;
using NFe.Classes.Servicos.ConsultaCadastro;
using NFe.Servicos;
using PDV.UTIL;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using System.Data;
using PDV.DAO.Custom;
using DevExpress.DataProcessing;
using System.Drawing;
using FontAwesome.Sharp;
using DevExpress.Utils.Extensions;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Cliente : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE CLIENTES";
        private Cliente _Cliente = null;
        private Endereco _Endereco = null;
        private Contato _Contato = null;
        private List<TipoContribuinte> TiposContribuinte = null;
        private DataTable Contatos = null;
        private DataTable Historicos = null;

        public static readonly decimal[] idsMenuItem = { 118, 16 };

        public FCA_Cliente(Cliente _C)
        {
            InitializeComponent();
            _Cliente = _C;

            ovCMB_TipoDocumento.SelectedIndex = 1;
            ovTXT_Cep.Mask = "#####-###";
            ovTXT_Numero.Mask = "######";
            ovTXT_InscricaoEstadual.Mask = "##############";
            ovTXT_InscricaoMunicipal.Mask = "##############";

            ovTXT_Contato_Celular.Mask = "(##) #####-####";
            ovTXT_Contato_Telefone.Mask = "(##) #####-####";

            ovCMB_Pais.DataSource = FuncoesPais.GetPaises();
            ovCMB_Pais.DisplayMember = "descricao";
            ovCMB_Pais.ValueMember = "idpais";

            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";

            ovCMB_Municipio.DisplayMember = "descricao";
            ovCMB_Municipio.ValueMember = "idunidadefederativa";

            TiposContribuinte = FuncoesTipoContribuinte.GetTiposContribuinte();
            ovCMB_TipoContribuinte.DataSource = TiposContribuinte;
            ovCMB_TipoContribuinte.DisplayMember = "descricao";
            ovCMB_TipoContribuinte.ValueMember = "codigo";

            ovCMB_VendedorAplicativo.DataSource = FuncoesUsuario.GetUsuariosVendedores();
            ovCMB_VendedorAplicativo.DisplayMember = "NOME";
            ovCMB_VendedorAplicativo.ValueMember = "IDUSUARIO";

            metroTabControl2.SelectedTab = metroTabPage5;

            PreencherTela();


            //icones
            Bitmap bitmapLocalizarCep = IconChar.Binoculars.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapConsultar = IconChar.Search.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);
            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);

            button1.ImageOptions.Image = bitmapLocalizarCep;
            simpleButton1.ImageOptions.Image = bitmapConsultar;
            simpleButton2.ImageOptions.Image = bitmapCancelar;
            metroButton5.ImageOptions.Image = bitmapSalvar; 

            metroButton1.ImageOptions.Image = bitmapNovo;
            metroButton2.ImageOptions.Image = bitmapEditar;
            metroButton3.ImageOptions.Image = bitmapRemover;

            metroButton8.ImageOptions.Image = bitmapNovo;
            metroButton7.ImageOptions.Image = bitmapEditar;
            metroButton6.ImageOptions.Image = bitmapRemover;
        }
        
        public decimal GetClienteID()
        {
            return _Cliente.IDCliente;
        }

        private void PreencherHistoricos(bool Banco)
        {
            if (Banco)
                Historicos = FuncoesHistoricoClienteFornecedor.GetHistorico(_Cliente.IDCliente, -1);

            gridControl2.DataSource = Historicos;
            gridViewHistorico.OptionsBehavior.Editable = false;
            gridViewHistorico.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewHistorico.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewHistorico.BestFitColumns();
            AjustaHeaderTextGridHistoricos();
        }

        private void AjustaHeaderTextGridHistoricos()
        {

            for (int i = 0; i < 6; i++)
            {
                if (i != 3 && i != 4)
                {
                    gridViewHistorico.Columns[i].Visible = false;
                }
            }
            gridViewHistorico.Columns[3].Caption = "DATA HISTÓRICO";
            gridViewHistorico.Columns[4].Caption = "ASSUNTO";
        }

        private void PreencherContatos(bool Banco)
        {
            if (Banco)
                Contatos = FuncoesContatoClienteFornecedor.GetContatos(_Cliente.IDCliente, -1);

            gridControl1.DataSource = Contatos;
            gridViewContatos.OptionsBehavior.Editable = false;
            gridViewContatos.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewContatos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewContatos.BestFitColumns();
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != 3 && i != 4)
                {
                    gridViewContatos.Columns[i].Visible = false;
                }
            }
                gridViewContatos.Columns[3].Caption = "NOME";
                gridViewContatos.Columns[4].Caption = "CARGO";
        }

        private void PreencherTela()
        {
            PreencherAbaIdentificacao();

            _Contato = new Contato();
            if (_Cliente.IDContato.HasValue && _Cliente.IDContato.Value != -1)
                _Contato = FuncoesContato.GetContato(_Cliente.IDContato.Value);

            _Endereco = new Endereco();
            if (_Cliente.IDEndereco.HasValue && _Cliente.IDEndereco.Value != -1)
                _Endereco = FuncoesEndereco.GetEndereco(_Cliente.IDEndereco.Value);

            PreencherAbaEndereco();
            PreencherAbaContato();
            PreencherContatos(true);
            PreencherHistoricos(true);
            var vendedor = FuncoesUsuario.GetUsuario(_Cliente.IDVendedor);

            if (vendedor != null)
                ovCMB_VendedorAplicativo.SelectedValue = vendedor.IDUsuario;
            else
                ovCMB_VendedorAplicativo.SelectedIndex = -1;
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

        private void ovCMB_TipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (ovCMB_TipoDocumento.SelectedIndex)
            {
                case 0:
                    ovLBL_CNPJCPF.Text = "CNPJ:";
                    ovTXT_CNPJCPF.Mask = "##,###,###/####-##";
                    ovLBL_RazaoSocial.Text = "* Razão Social:";
                    ovTXT_CNPJCPF.Text = string.Empty;

                    ovTXT_RazaoSocial.Width = 237;
                    ovTXT_NomeFantasia.Visible = true;
                    ovLBL_NomeFantasia.Visible = true;
                    break;
                case 1:
                    ovLBL_CNPJCPF.Text = "CPF:";
                    ovTXT_CNPJCPF.Mask = "###,###,###-##";
                    ovLBL_RazaoSocial.Text = "* Nome:";
                    ovTXT_CNPJCPF.Text = string.Empty;

                    ovTXT_RazaoSocial.Width = 598;
                    ovTXT_NomeFantasia.Visible = false;
                    ovLBL_NomeFantasia.Visible = false;
                    break;
            }
        }

        private void PreencherAbaEndereco()
        {
            ovTXT_Logradouro.Text = _Endereco.Logradouro;
            ovTXT_Numero.Text = _Endereco.Numero;
            ovTXT_Cep.Text = _Endereco.Cep;
            ovTXT_Complemento.Text = _Endereco.Complemento;
            ovTXT_Bairro.Text = _Endereco.Bairro;

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

        private void PreencherAbaContato()
        {
            ovTXT_Contato_Celular.Text = _Contato.Celular;
            ovTXT_Contato_Email.Text = _Contato.Email;
            ovTXT_Contato_EmailAlternativo.Text = _Contato.EmailAlternativo;
            ovTXT_Contato_Telefone.Text = _Contato.Telefone;
        }

        private void PreencherAbaIdentificacao()
        {          
            ovCMB_TipoDocumento.SelectedIndex = Convert.ToInt32(_Cliente.TipoDocumento);
            ovTXT_CNPJCPF.Text = _Cliente.TipoDocumento == 0 ? _Cliente.CNPJ : _Cliente.CPF;
            ovTXT_RazaoSocial.Text = _Cliente.TipoDocumento == 0 ? _Cliente.RazaoSocial : _Cliente.Nome;
            ovTXT_InscricaoEstadual.Text = !string.IsNullOrEmpty(_Cliente.InscricaoEstadual) ? _Cliente.InscricaoEstadual.ToString() : string.Empty;
            ovTXT_InscricaoMunicipal.Text = !string.IsNullOrEmpty(_Cliente.InscricaoMunicipal) ? _Cliente.InscricaoMunicipal.ToString() : string.Empty;
            ovTXT_NomeFantasia.Text = _Cliente.NomeFantasia;
            ovCMB_Ativo.Checked = _Cliente.Ativo == 1;
            ovTXT_CodigoCliente.Text = _Cliente.IDCliente.ToString();

            ovCKB_Consumidor.Checked = _Cliente.ConsumidorFinal == 1;
            ovCKB_Estrangeiro.Checked = _Cliente.Estrangeiro == 1;
            ovTXT_DocEstrangeiro.Text = _Cliente.DocEstrangeiro;

            ovCMB_TipoContribuinte.SelectedItem = TiposContribuinte.Where(o => o.Codigo == _Cliente.TipoContribuinte).FirstOrDefault();

             editDecimalLimiteDeCredito.Value = _Cliente.LimiteDeCredito;
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Salvar()
        {
            try
            {
                PDVControlador.BeginTransaction();

                /* Aba Cliente */
                if (!Validar())
                {
                    PDVControlador.Rollback();
                    return;
                }

                _Cliente.LimiteDeCredito = editDecimalLimiteDeCredito.Value;

                DAO.Enum.TipoOperacao TOCliente = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesCliente.ExisteCliente(_Cliente.IDCliente))
                {
                    TOCliente = DAO.Enum.TipoOperacao.INSERT;
                    _Cliente.IDCliente = Sequence.GetNextID("CLIENTE", "IDCLIENTE");
                }

                DAO.Enum.TipoOperacao TOEndereco = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesEndereco.ExisteEndereco(_Cliente.IDEndereco == null ? -1 : _Cliente.IDEndereco.Value))
                {
                    TOEndereco = DAO.Enum.TipoOperacao.INSERT;
                    _Cliente.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                }
                DAO.Enum.TipoOperacao TOContato = DAO.Enum.TipoOperacao.UPDATE;
                if (_Cliente.IDContato != null)
                {
                    
                    if (!FuncoesContato.ExisteContato(_Cliente.IDContato.Value))
                    {
                        TOContato = DAO.Enum.TipoOperacao.INSERT;
                        _Cliente.IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                    }
                }
                else
                {
                    TOContato = DAO.Enum.TipoOperacao.INSERT;
                    _Cliente.IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                }

                _Cliente.TipoDocumento = ovCMB_TipoDocumento.SelectedIndex;
                if (ovCMB_TipoDocumento.SelectedIndex == 0)
                {
                    _Cliente.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                    _Cliente.RazaoSocial = ovTXT_RazaoSocial.Text;
                    _Cliente.CPF = string.Empty;
                    _Cliente.Nome = string.Empty;
                }
                else
                {
                    _Cliente.CNPJ = string.Empty;
                    
                    //_Cliente.RazaoSocial = string.Empty;
                    ovTXT_NomeFantasia.Text = ovTXT_RazaoSocial.Text;
                    _Cliente.Nome = ovTXT_RazaoSocial.Text;
                    _Cliente.CPF = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                }
                _Cliente.InscricaoEstadual = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text)))
                    _Cliente.InscricaoEstadual = ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text);

                _Cliente.InscricaoMunicipal = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoMunicipal.Text)))
                    _Cliente.InscricaoMunicipal = ZeusUtil.SomenteNumeros(ovTXT_InscricaoMunicipal.Text);

                _Cliente.NomeFantasia = ovTXT_NomeFantasia.Text;

                _Cliente.Ativo = ovCMB_Ativo.Checked ? 1 : 0;

                _Cliente.ConsumidorFinal = ovCKB_Consumidor.Checked ? 1 : 0;
                _Cliente.Estrangeiro = ovCKB_Estrangeiro.Checked ? 1 : 0;
                _Cliente.DocEstrangeiro = ovTXT_DocEstrangeiro.Text;
                if(ovCMB_TipoContribuinte.SelectedItem!= null)
                _Cliente.TipoContribuinte = (ovCMB_TipoContribuinte.SelectedItem as TipoContribuinte).Codigo;
                if (_Cliente.IDVendedor == 0)
                {
                    _Cliente.IDVendedor = int.Parse(Contexto.USUARIOLOGADO.IDUsuario.ToString());
                }
                else
                {
                    _Cliente.IDVendedor = int.Parse(ovCMB_VendedorAplicativo.SelectedValue.ToString());
                }

                /* AbaContato */
                if (_Cliente.IDContato != null)
                {
                    _Contato.IDContato = _Cliente.IDContato.Value;
                    _Contato.Email = ovTXT_Contato_Email.Text;
                    _Contato.EmailAlternativo = ovTXT_Contato_EmailAlternativo.Text;
                    _Contato.Telefone = ZeusUtil.SomenteNumeros(ovTXT_Contato_Telefone.Text);
                    _Contato.Celular = ZeusUtil.SomenteNumeros(ovTXT_Contato_Celular.Text);
                }

                /* Aba Endereço */


                _Endereco.Telefone = ZeusUtil.SomenteNumeros(ovTXT_Contato_Telefone.Text);
                _Endereco.IDEndereco = _Cliente.IDEndereco.Value;
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

                if (_Contato.IDContato != 0)
                {
                    if (!FuncoesContato.Salvar(_Contato, TOContato))
                        throw new Exception("Não foi possível salvar o Contato.");
                }
                if (!FuncoesEndereco.Salvar(_Endereco, TOEndereco))
                    throw new Exception("Não foi possível salvar o Endereço.");

                if (!FuncoesCliente.Salvar(_Cliente, TOCliente))
                    throw new Exception("Não foi possível salvar o Cliente.");

                /* Contatos */
                DataTable dt = ZeusUtil.GetChanges(Contatos, DAO.Enum.TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        ContatoClienteFornecedor Contato = EntityUtil<ContatoClienteFornecedor>.ParseDataRow(dr);
                        Contato.IDCliente = _Cliente.IDCliente;
                        if (!FuncoesContatoClienteFornecedor.Salvar(Contato, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Contato.");
                    }

                dt = ZeusUtil.GetChanges(Contatos, DAO.Enum.TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesContatoClienteFornecedor.Salvar(EntityUtil<ContatoClienteFornecedor>.ParseDataRow(dr), DAO.Enum.TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar o Contato.");

                dt = ZeusUtil.GetChanges(Contatos, DAO.Enum.TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesContatoClienteFornecedor.Remover(Convert.ToDecimal(dr["IDCONTATOCLIENTEFORNECEDOR"])))
                            throw new Exception("Não foi possível salvar o Contato.");

                /* Históricos */
                dt = ZeusUtil.GetChanges(Historicos, DAO.Enum.TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        HistoricoClienteFornecedor Historico = EntityUtil<HistoricoClienteFornecedor>.ParseDataRow(dr);
                        Historico.IDCliente = _Cliente.IDCliente;
                        if (!FuncoesHistoricoClienteFornecedor.Salvar(Historico, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Histórico.");
                    }

                dt = ZeusUtil.GetChanges(Historicos, DAO.Enum.TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesHistoricoClienteFornecedor.Salvar(EntityUtil<HistoricoClienteFornecedor>.ParseDataRow(dr), DAO.Enum.TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar o Histórico.");

                dt = ZeusUtil.GetChanges(Historicos, DAO.Enum.TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesHistoricoClienteFornecedor.Remover(Convert.ToDecimal(dr["IDHISTORICOCLIENTEFORNECEDOR"])))
                            throw new Exception("Não foi possível salvar o Histórico.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Cliente salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            // Aba Cliente
            if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text))
            {
                Alert("Informe a Razão Social.");
                ovTXT_RazaoSocial.Focus();
                return false;
            }

            if (!ValidarCPFCNPJ())
            {
                Alert("Já existe um cliente cadastrado com este CPF/CNPJ");
                ovTXT_CNPJCPF.Focus();
                return false;
            }

            return true;
        }

        private void Alert(string msg)
        {
            MessageBox.Show(this, msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidarCPFCNPJ()
        {
            var CNPJCPF = RemoverPontosBarraEHifen(ovTXT_CNPJCPF.Text);
            var clienteCNPJ = FuncoesCliente.GetClientePorCNPJ(CNPJCPF);
            var clienteCPF = FuncoesCliente.GetClientePorCPF(CNPJCPF);
            var cliente = clienteCNPJ ?? clienteCPF;

            if (cliente == null)
                return true;

            return cliente.IDCliente == _Cliente.IDCliente;
        }

        private string RemoverPontosBarraEHifen(string text)
        {
            string[] chars = { ".", "/", "-" };
            chars.ForEach(c => text = text.Replace(c, ""));
            return text;
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
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

        private void ovBTN_ConsultarCNPJ_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF do Cliente.");

                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFe.CfgServico);
                var retornoConsulta = servicoNFe.NfeConsultaCadastro((ovCMB_UF.SelectedItem as UnidadeFederativa).Sigla, ConsultaCadastroTipoDocumento.Cnpj, ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text));

                if (retornoConsulta.Retorno.infCons.infCad == null)
                    throw new Exception(retornoConsulta.Retorno.infCons.xMotivo);

                ovTXT_CNPJCPF.Text = retornoConsulta.Retorno.infCons.infCad.CNPJ;
                ovTXT_InscricaoEstadual.Text = retornoConsulta.Retorno.infCons.infCad.IE;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Novo Contato
            ContatoClienteFornecedor Contato = new ContatoClienteFornecedor();
            Contato.IDContatoClienteFornecedor = Sequence.GetNextID("CONTATOCLIENTEFORNECEDOR", "IDCONTATOCLIENTEFORNECEDOR");
            FCA_ContatoClienteFornecedor FormContato = new FCA_ContatoClienteFornecedor(Contato);
            FormContato.ShowDialog(this);
            if (FormContato.Salvou)
            {
                DataRow drContato = Contatos.NewRow();
                drContato["IDFORNECEDOR"] = DBNull.Value;
                drContato["IDCLIENTE"] = _Cliente.IDCliente;
                drContato["NOME"] = FormContato.Contato.Nome;
                drContato["CARGO"] = FormContato.Contato.Cargo;
                drContato["EMAIL"] = FormContato.Contato.Email;
                drContato["TELEFONE1"] = FormContato.Contato.Telefone1;
                drContato["TELEFONE2"] = FormContato.Contato.Telefone2;
                drContato["SEXO"] = FormContato.Contato.Sexo;
                drContato["IDCONTATOCLIENTEFORNECEDOR"] = FormContato.Contato.IDContatoClienteFornecedor;
                Contatos.Rows.Add(drContato);
                PreencherContatos(false);
            }
            DesabilitarBotoes();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            EditarContato();
            DesabilitarBotoes();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Deseja remover o Contato selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    decimal IDContato = decimal.Parse(gridViewContatos.GetRowCellValue(gridViewContatos.FocusedRowHandle, "idcontatoclientefornecedor").ToString());
                    Contatos.DefaultView.RowFilter = "[IDCONTATOCLIENTEFORNECEDOR] = " + IDContato;
                    Contatos.DefaultView[0].Delete();
                    Contatos.DefaultView.RowFilter = string.Empty;
                    PreencherContatos(false);
                }
            }
            catch (Exception)
            {

            }
            DesabilitarBotoes();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            HistoricoClienteFornecedor Historico = new HistoricoClienteFornecedor { IDHistoricoClienteFornecedor = Sequence.GetNextID("HISTORICOCLIENTEFORNECEDOR", "IDHISTORICOCLIENTEFORNECEDOR") };
            FCA_HistoricoClienteFornecedor FormHistorico = new FCA_HistoricoClienteFornecedor(Historico);
            FormHistorico.ShowDialog(this);
            if (FormHistorico.Salvou)
            {
                DataRow drHistorico = Historicos.NewRow();
                drHistorico["IDCLIENTE"] = _Cliente.IDCliente;
                drHistorico["IDFORNECEDOR"] = DBNull.Value;
                drHistorico["ASSUNTO"] = FormHistorico.Historico.Assunto;
                drHistorico["DATAHISTORICO"] = FormHistorico.Historico.DataHistorico;
                drHistorico["OBSERVACAO"] = FormHistorico.Historico.Observacao;
                drHistorico["IDHISTORICOCLIENTEFORNECEDOR"] = FormHistorico.Historico.IDHistoricoClienteFornecedor;
                Historicos.Rows.Add(drHistorico);
                PreencherHistoricos(false);
            }
            DesabilitarBotoes();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {

            EditarHistorico();
            DesabilitarBotoes();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Deseja remover o Histórico selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Historicos.DefaultView.RowFilter = "[IDHISTORICOCLIENTEFORNECEDOR] = " + decimal.Parse(gridViewHistorico.GetRowCellValue(gridViewHistorico.FocusedRowHandle, "idhistoricoclientefornecedor").ToString());
                    Historicos.DefaultView[0].Delete();
                    Historicos.DefaultView.RowFilter = string.Empty;
                    PreencherHistoricos(false);

                }
            }
            catch (Exception)
            {

            }


            DesabilitarBotoes();
        }

        private void FCA_Cliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {   
            EditarContato();
            
            
            DesabilitarBotoes();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            EditarHistorico();            
            DesabilitarBotoes();
        }
        private void EditarContato()
        {
            
            try
            {
                decimal IDContato = decimal.Parse(gridViewContatos.GetRowCellValue(gridViewContatos.FocusedRowHandle, "idcontatoclientefornecedor").ToString());

                Contatos.DefaultView.RowFilter = "[IDCONTATOCLIENTEFORNECEDOR] = " + IDContato;
                FCA_ContatoClienteFornecedor FormContato = new FCA_ContatoClienteFornecedor(EntityUtil<ContatoClienteFornecedor>.ParseDataRow(Contatos.DefaultView[0].Row));
                FormContato.ShowDialog(this);
                if (FormContato.Salvou)
                {
                    Contatos.DefaultView[0].BeginEdit();
                    Contatos.DefaultView[0]["IDFORNECEDOR"] = DBNull.Value;
                    Contatos.DefaultView[0]["IDCLIENTE"] = _Cliente.IDCliente;
                    Contatos.DefaultView[0]["NOME"] = FormContato.Contato.Nome;
                    Contatos.DefaultView[0]["CARGO"] = FormContato.Contato.Cargo;
                    Contatos.DefaultView[0]["EMAIL"] = FormContato.Contato.Email;
                    Contatos.DefaultView[0]["TELEFONE1"] = FormContato.Contato.Telefone1;
                    Contatos.DefaultView[0]["TELEFONE2"] = FormContato.Contato.Telefone2;
                    Contatos.DefaultView[0]["SEXO"] = FormContato.Contato.Sexo;
                    Contatos.DefaultView[0].EndEdit();
                }
                Contatos.DefaultView.RowFilter = string.Empty;
                PreencherContatos(false);
            }
            catch (NullReferenceException)
            {
            }

        }

        private void EditarHistorico()
        {
            try
            {
                Historicos.DefaultView.RowFilter = "[IDHISTORICOCLIENTEFORNECEDOR] = " + decimal.Parse(gridViewHistorico.GetRowCellValue(gridViewHistorico.FocusedRowHandle, "idhistoricoclientefornecedor").ToString());
                FCA_HistoricoClienteFornecedor FormHistorico = new FCA_HistoricoClienteFornecedor(EntityUtil<HistoricoClienteFornecedor>.ParseDataRow(Historicos.DefaultView[0].Row));
                FormHistorico.ShowDialog(this);
                if (FormHistorico.Salvou)
                {
                    Historicos.DefaultView[0].BeginEdit();
                    Historicos.DefaultView[0]["IDCLIENTE"] = _Cliente.IDCliente;
                    Historicos.DefaultView[0]["IDFORNECEDOR"] = DBNull.Value;
                    Historicos.DefaultView[0]["ASSUNTO"] = FormHistorico.Historico.Assunto;
                    Historicos.DefaultView[0]["OBSERVACAO"] = FormHistorico.Historico.Observacao;
                    Historicos.DefaultView[0].EndEdit();
                }
                Historicos.DefaultView.RowFilter = string.Empty;
                PreencherHistoricos(false);
            }
            catch (NullReferenceException)
            {
            }
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            metroButton3.Enabled = true;
            metroButton2.Enabled = true;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            metroButton6.Enabled = true;
            metroButton7.Enabled = true;
        }
        private void DesabilitarBotoes()
        {
            metroButton3.Enabled = false;
            metroButton2.Enabled = false;
            metroButton6.Enabled = false;
            metroButton7.Enabled = false;
        }


    }
}
