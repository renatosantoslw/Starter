using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Cep;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Fornecedor : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE FORNECEDOR";

        public static readonly decimal[] idsMenuItem = { 23, 119 };

        private Fornecedor _Fornecedor = null;
        private Endereco _Endereco = null;

        private DataTable Contatos = null;
        private DataTable Historicos = null;        

        public FCA_Fornecedor(Fornecedor _F)
        {
            InitializeComponent();
            _Fornecedor = _F;
            ovTXT_CNPJCPF.Mask = "##,###,###/####-##";
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

            metroTabControl2.SelectedTab = metroTabPage5;
        }
        public decimal GetFornecedorID() { return _Fornecedor.IDFornecedor; }

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

        private void PreencherHistoricos(bool Banco)
        {
            if (Banco)
                Historicos = FuncoesHistoricoClienteFornecedor.GetHistorico(-1, _Fornecedor.IDFornecedor);

            gridControl2.DataSource = Historicos;
            gridViewHistorico.OptionsBehavior.Editable = false;
            gridViewHistorico.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewHistorico.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewHistorico.BestFitColumns();
            AjustaHeaderTextGridHistoricos();

        }

        private void AjustaHeaderTextGridHistoricos()
        {
            gridViewHistorico.Columns[0].Visible = false;
            gridViewHistorico.Columns[1].Visible = false;
            gridViewHistorico.Columns[2].Visible = false;
            gridViewHistorico.Columns[3].Caption = "DATA HISTÓRICO";
            gridViewHistorico.Columns[4].Caption = "ASSUNTO";
            gridViewHistorico.Columns[5].Visible = false;

        }

        private void PreencherContatos(bool Banco)
        {
            if (Banco)
                Contatos = FuncoesContatoClienteFornecedor.GetContatos(-1, _Fornecedor.IDFornecedor);

            gridControl1.DataSource = Contatos;
            gridViewContatos.OptionsBehavior.Editable = false;
            gridViewContatos.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewContatos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewContatos.BestFitColumns();
            AjustaHeaderTextGridContatos();
        }

        private void AjustaHeaderTextGridContatos()
        {
           
            gridViewContatos.Columns[0].Visible = false;
            gridViewContatos.Columns[1].Visible = false;
            gridViewContatos.Columns[2].Visible = false;
            gridViewContatos.Columns[3].Caption = "NOME";
            gridViewContatos.Columns[4].Caption = "CARGO";
            gridViewContatos.Columns[5].Visible = false;
            gridViewContatos.Columns[6].Visible = false;
            gridViewContatos.Columns[7].Visible = false;
            gridViewContatos.Columns[8].Visible = false;
        }

        private void PreencherTela()
        {
            /* Aba Identificação */
            ovTXT_CNPJCPF.Text = _Fornecedor.CNPJ;
            ovTXT_RazaoSocial.Text = _Fornecedor.RazaoSocial;

            ovCKB_Isento.Checked = _Fornecedor.Isento == 1;
            ovTXT_InscricaoEstadual.Text = _Fornecedor.InscricaoEstadual.HasValue ? _Fornecedor.InscricaoEstadual.ToString() : string.Empty;
            ovTXT_Email.Text = _Fornecedor.Email;

            /* Aba Endereço */
            _Endereco = FuncoesEndereco.GetEndereco(_Fornecedor.IDEndereco);
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

            PreencherContatos(true);
            PreencherHistoricos(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();
                TipoOperacao TOTransportadora = TipoOperacao.UPDATE;
                if (!FuncoesFornecedor.ExisteFornecedor(_Fornecedor.IDFornecedor))
                {
                    TOTransportadora = TipoOperacao.INSERT;
                    _Fornecedor.IDFornecedor = Sequence.GetNextID("FORNECEDOR", "IDFORNECEDOR");
                }

                TipoOperacao TOEndereco = TipoOperacao.UPDATE;
                if (!FuncoesEndereco.ExisteEndereco(_Fornecedor.IDEndereco))
                {
                    TOEndereco = TipoOperacao.INSERT;
                    _Fornecedor.IDEndereco = Sequence.GetNextID("ENDERECO", "IDENDERECO");
                }

                if (string.IsNullOrEmpty(ovTXT_RazaoSocial.Text))
                {
                    MessageBox.Show(this, "Informe a Razão Social.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ovTXT_RazaoSocial.Focus();
                    PDVControlador.Rollback();
                    return;
                }

                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text)))
                {
                    MessageBox.Show(this, string.Format("Informe o CNPJ"), NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ovTXT_CNPJCPF.Focus();
                    return;
                }

                _Fornecedor.CNPJ = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPF.Text);
                _Fornecedor.RazaoSocial = ovTXT_RazaoSocial.Text;
                _Fornecedor.Isento = ovCKB_Isento.Checked ?1 : 0;
                _Fornecedor.Email = ovTXT_Email.Text;

                _Fornecedor.InscricaoEstadual = null;
                if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text)))
                    _Fornecedor.InscricaoEstadual = Convert.ToDecimal(ZeusUtil.SomenteNumeros(ovTXT_InscricaoEstadual.Text));

                /* Aba Endereço */
                _Endereco.IDEndereco = _Fornecedor.IDEndereco;
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

                if (!FuncoesFornecedor.Salvar(_Fornecedor, TOTransportadora))
                    throw new Exception("Não foi possível salvar o Fornecedor.");

                /* Contatos */
                DataTable dt = ZeusUtil.GetChanges(Contatos, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        ContatoClienteFornecedor Contato = EntityUtil<ContatoClienteFornecedor>.ParseDataRow(dr);
                        Contato.IDFornecedor = _Fornecedor.IDFornecedor;
                        if (!FuncoesContatoClienteFornecedor.Salvar(Contato, TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Contato.");
                    }

                dt = ZeusUtil.GetChanges(Contatos, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesContatoClienteFornecedor.Salvar(EntityUtil<ContatoClienteFornecedor>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar o Contato.");

                dt = ZeusUtil.GetChanges(Contatos, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesContatoClienteFornecedor.Remover(Convert.ToDecimal(dr["IDCONTATOCLIENTEFORNECEDOR"])))
                            throw new Exception("Não foi possível salvar o Contato.");

                /* Histórico */
                dt = ZeusUtil.GetChanges(Historicos, TipoOperacao.INSERT);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                    {
                        HistoricoClienteFornecedor Historico = EntityUtil<HistoricoClienteFornecedor>.ParseDataRow(dr);
                        Historico.IDFornecedor = _Fornecedor.IDFornecedor;
                        if (!FuncoesHistoricoClienteFornecedor.Salvar(Historico, TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Histórico.");
                    }

                dt = ZeusUtil.GetChanges(Historicos, TipoOperacao.UPDATE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesHistoricoClienteFornecedor.Salvar(EntityUtil<HistoricoClienteFornecedor>.ParseDataRow(dr), TipoOperacao.UPDATE))
                            throw new Exception("Não foi possível salvar o Histórico.");

                dt = ZeusUtil.GetChanges(Historicos, TipoOperacao.DELETE);
                if (dt != null)
                    foreach (DataRow dr in dt.Rows)
                        if (!FuncoesHistoricoClienteFornecedor.Remover(Convert.ToDecimal(dr["IDHISTORICOCLIENTEFORNECEDOR"])))
                            throw new Exception("Não foi possível salvar o Histórico.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Fornecedor salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ContatoClienteFornecedor Contato = new ContatoClienteFornecedor() { IDContatoClienteFornecedor = Sequence.GetNextID("CONTATOCLIENTEFORNECEDOR", "IDCONTATOCLIENTEFORNECEDOR") };
            FCA_ContatoClienteFornecedor FormContato = new FCA_ContatoClienteFornecedor(Contato);
            FormContato.ShowDialog(this);
            if (FormContato.Salvou)
            {
                DataRow drContato = Contatos.NewRow();
                drContato["IDCLIENTE"] = DBNull.Value;
                drContato["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
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
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            EditarContato();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Contato selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDContato = decimal.Parse(gridViewContatos.GetRowCellValue(gridViewContatos.FocusedRowHandle, "idcontatoclientefornecedor").ToString()); ;
                Contatos.DefaultView.RowFilter = "[IDCONTATOCLIENTEFORNECEDOR] = " + IDContato;
                Contatos.DefaultView[0].Delete();
                Contatos.DefaultView.RowFilter = string.Empty;
                PreencherContatos(false);
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            HistoricoClienteFornecedor Historico = new HistoricoClienteFornecedor { IDHistoricoClienteFornecedor = Sequence.GetNextID("HISTORICOCLIENTEFORNECEDOR", "IDHISTORICOCLIENTEFORNECEDOR") };
            FCA_HistoricoClienteFornecedor FormHistorico = new FCA_HistoricoClienteFornecedor(Historico);
            FormHistorico.ShowDialog(this);
            if (FormHistorico.Salvou)
            {
                DataRow drHistorico = Historicos.NewRow();
                drHistorico["IDCLIENTE"] = DBNull.Value;
                drHistorico["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
                drHistorico["ASSUNTO"] = FormHistorico.Historico.Assunto;
                drHistorico["DATAHISTORICO"] = FormHistorico.Historico.DataHistorico;
                drHistorico["OBSERVACAO"] = FormHistorico.Historico.Observacao;
                drHistorico["IDHISTORICOCLIENTEFORNECEDOR"] = FormHistorico.Historico.IDHistoricoClienteFornecedor;
                Historicos.Rows.Add(drHistorico);
                PreencherHistoricos(false);
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            EditarHistorico();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Histórico selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Historicos.DefaultView.RowFilter = "[IDHISTORICOCLIENTEFORNECEDOR] = " + decimal.Parse(gridViewHistorico.GetRowCellValue(gridViewHistorico.FocusedRowHandle, "idhistoricoclientefornecedor").ToString());
                Historicos.DefaultView[0].Delete();
                Historicos.DefaultView.RowFilter = string.Empty;
                PreencherHistoricos(false);
            }
        }

        private void FCA_Fornecedor_Load(object sender, EventArgs e)
        {
            PreencherTela();
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

        private void FCA_Fornecedor_KeyDown(object sender, KeyEventArgs e)
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
        }


        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            EditarHistorico();
            
        }
        private void EditarContato()
        {
            try
            {
                Contatos.DefaultView.RowFilter = "[IDCONTATOCLIENTEFORNECEDOR] = " + decimal.Parse(gridViewContatos.GetRowCellValue(gridViewContatos.FocusedRowHandle, "idcontatoclientefornecedor").ToString());
                FCA_ContatoClienteFornecedor FormContato = new FCA_ContatoClienteFornecedor(EntityUtil<ContatoClienteFornecedor>.ParseDataRow(Contatos.DefaultView[0].Row));
                FormContato.ShowDialog(this);
                if (FormContato.Salvou)
                {
                    Contatos.DefaultView[0].BeginEdit();
                    Contatos.DefaultView[0]["IDCLIENTE"] = DBNull.Value;
                    Contatos.DefaultView[0]["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
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
                    Historicos.DefaultView[0]["IDCLIENTE"] = DBNull.Value;
                    Historicos.DefaultView[0]["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
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
    }
}
