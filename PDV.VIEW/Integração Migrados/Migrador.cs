using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Integração_Migrados.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Integração_Migrados
{
    public partial class Migrador : DevExpress.XtraEditors.XtraForm
    {
        private Fornecedor _Fornecedor = null;

        private Cliente _Cliente = null;
        private Endereco _Endereco = null;
        private Contato _Contato = null;
        private Municipio _Municipio = null;
        private DAO.Entidades.Produto _Produto = null;
        private Usuario _Usuario = null;
        private List<TipoContribuinte> TiposContribuinte = null;
        public Migrador()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Model1 model1 = new Model1();
                _Cliente = new Cliente();
                _Contato = new Contato();
                _Endereco = new Endereco();
                _Municipio = new Municipio();

                var ObjetCliente = model1.v_PessoaDados.Where(x => x.bAtivo == 1 && x.bCliente == 1).ToList();
                var clientesInseridos = 0;
                foreach (var item in ObjetCliente)
                {                  
                    PDVControlador.BeginTransaction();
                    clientesInseridos++;
                    gridControl1.DataSource = clientesInseridos;
                    _Cliente.IDCliente = PDV.DAO.DB.Utils.Sequence.GetNextID("CLIENTE", "IDCLIENTE");

                    if (item.PessoaCNPJ_CPF.Length > 14)
                    {
                        _Cliente.TipoDocumento = 0;
                        _Cliente.CNPJ = ZeusUtil.SomenteNumeros(item.PessoaCNPJ_CPF);
                        _Cliente.RazaoSocial = item.PessoaNome;
                        _Cliente.CPF = string.Empty;
                        _Cliente.Nome = string.Empty;
                    }
                    else
                    {
                        _Cliente.TipoDocumento = 1;
                        _Cliente.CNPJ = string.Empty;
                        _Cliente.RazaoSocial = string.Empty;

                        _Cliente.CPF = ZeusUtil.SomenteNumeros(item.PessoaCNPJ_CPF);
                    }
                    _Cliente.InscricaoEstadual = null;
                    if (item.PessoaInscRG != null)
                    {
                        if (!item.PessoaInscRG.Contains("ISENTO"))
                            if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(item.PessoaInscRG)))
                                _Cliente.InscricaoEstadual = ZeusUtil.SomenteNumeros(item.PessoaInscRG);
                    }
                    _Cliente.Nome = item.PessoaNome;
                    _Cliente.InscricaoMunicipal = null;
                    _Cliente.InscricaoMunicipal = null;
                    _Cliente.NomeFantasia = item.PessoaNome;
                    _Cliente.Ativo = 1;//ovCMB_Ativo.Checked ? 1 : 0;
                    int ConsumidorFinal = 1;
                    decimal Contribuinte = 0;
                    if (item.PessoaInscRG != null)
                    {
                        if (!item.PessoaInscRG.Contains("ISENTO") && item.PessoaInscRG != string.Empty)
                        {
                            Contribuinte = 1;
                            ConsumidorFinal = 0;
                        }
                    }
                    string email = "";
                    string NumeroCasa = "";
                    string Complemento = "";
                    List<PessoaEmail> PessoaEmail = new List<PessoaEmail>();
                    List<PessoaEndereco> PessoaEndereco = new List<PessoaEndereco>();
                    PessoaEmail = model1.PessoaEmail.Where(x => x.IDPessoa == item.PessoaID).ToList();
                    if (PessoaEmail.Count > 0)
                    {
                        email = PessoaEmail[0].Email.ToString();
                    }
                    PessoaEndereco = model1.PessoaEndereco.Where(x => x.IDPessoa == item.PessoaID).ToList();
                    if (PessoaEndereco.Count > 0)
                    {
                        NumeroCasa = PessoaEndereco[0].Numero.ToString();
                        Complemento = PessoaEndereco[0].Complemento.ToString();
                    }
                    _Cliente.ConsumidorFinal = ConsumidorFinal;
                    _Cliente.Estrangeiro = 0;
                    _Cliente.DocEstrangeiro = null;
                    _Cliente.TipoContribuinte = Contribuinte;
                    _Cliente.IDVendedor = 1;
                    /* AbaContato */
                    _Contato.IDContato = PDV.DAO.DB.Utils.Sequence.GetNextID("CONTATO", "IDCONTATO");
                    _Contato.Email = email;
                    _Contato.EmailAlternativo = null;
                    _Contato.Telefone = ZeusUtil.SomenteNumeros(item.PessoaTelefone);
                    _Contato.Celular = null;
                    _Cliente.IDContato = _Contato.IDContato;
                    /* Aba Endereço */
                    _Endereco.IDEndereco = PDV.DAO.DB.Utils.Sequence.GetNextID("ENDERECO", "IDENDERECO");
                    _Cliente.IDEndereco = _Endereco.IDEndereco;
                    _Endereco.Logradouro = item.PessoaEndereco;
                    if (NumeroCasa != null)
                    {
                        try
                        {
                            _Endereco.Numero = NumeroCasa;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    _Endereco.Complemento = Complemento;
                    _Endereco.Bairro = item.PessoaBairro;
                    _Endereco.Cep = null;
                    if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(item.PessoaCEP)))
                        _Endereco.Cep = ZeusUtil.SomenteNumeros(item.PessoaCEP);

                    UnidadeFederativa uf  = FuncoesUF.GetUnidadeFederativaPorSigla(item.PessoaUF);

                    _Endereco.IDPais = 1058;
                    _Endereco.IDUnidadeFederativa = null;
                    _Endereco.IDUnidadeFederativa = uf.IDUnidadeFederativa;
                    _Endereco.IDMunicipio = null;
                    _Municipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(item.PessoaCidadeIBGE));
                    if (item.PessoaCidadeIBGE != null)
                        _Endereco.IDMunicipio = _Municipio.IDMunicipio;

                    if (_Contato.IDContato != 0)
                    {
                        if (!FuncoesContato.Salvar(_Contato, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Contato.");
                    }
                    if (!FuncoesEndereco.Salvar(_Endereco, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Endereço.");

                    if (!FuncoesCliente.Salvar(_Cliente, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Cliente.");
                    PDVControlador.Commit();
                }
                MessageBox.Show(this, "Cliente salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                //throw;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Model1 model1 = new Model1();
                _Fornecedor = new Fornecedor();
                _Contato = new Contato();
                _Endereco = new Endereco();
                _Municipio = new Municipio();

                var ObjetCliente = model1.v_PessoaDados.Where(x => x.bAtivo == 1 && x.bFornecedor == 1).ToList();

                foreach (var item in ObjetCliente)
                {
                    PDVControlador.BeginTransaction();
                    _Fornecedor.IDFornecedor = PDV.DAO.DB.Utils.Sequence.GetNextID("FORNECEDOR", "IDFORNECEDOR");


                    _Fornecedor.CNPJ = ZeusUtil.SomenteNumeros(item.PessoaCNPJ_CPF);
                    _Fornecedor.RazaoSocial = item.PessoaNome;

                    _Fornecedor.InscricaoEstadual = null;
                    if (item.PessoaInscRG != null)
                    {
                        try
                        {
                            _Fornecedor.InscricaoEstadual = Convert.ToDecimal(ZeusUtil.SomenteNumeros(item.PessoaInscRG));
                        }
                        catch (Exception)
                        {

                        }

                    }

                    string email = "";
                    string NumeroCasa = "";
                    string Complemento = "";
                    List<PessoaEmail> PessoaEmail = new List<PessoaEmail>();
                    List<PessoaEndereco> PessoaEndereco = new List<PessoaEndereco>();

                    PessoaEmail = model1.PessoaEmail.Where(x => x.IDPessoa == item.PessoaID).ToList();
                    if (PessoaEmail.Count > 0)
                    {
                        email = PessoaEmail[0].Email.ToString();
                    }

                    PessoaEndereco = model1.PessoaEndereco.Where(x => x.IDPessoa == item.PessoaID).ToList();
                    if (PessoaEndereco.Count > 0)
                    {
                        NumeroCasa = PessoaEndereco[0].Numero.ToString();
                        Complemento = PessoaEndereco[0].Complemento.ToString();
                    }

                    /* AbaContato */

                    _Contato.IDContato = PDV.DAO.DB.Utils.Sequence.GetNextID("CONTATO", "IDCONTATO");
                    _Contato.Email = email;
                    _Contato.EmailAlternativo = null;
                    _Contato.Telefone = ZeusUtil.SomenteNumeros(item.PessoaTelefone);
                    _Contato.Celular = null;

                    /* Aba Endereço */
                    _Endereco.IDEndereco = PDV.DAO.DB.Utils.Sequence.GetNextID("ENDERECO", "IDENDERECO");

                    _Fornecedor.IDEndereco = _Endereco.IDEndereco;
                    _Endereco.Logradouro = item.PessoaEndereco;
                    if (NumeroCasa != null)
                    {
                        try
                        {
                            _Endereco.Numero = NumeroCasa;
                        }
                        catch (Exception)
                        {

                        }
                    }

                    _Endereco.Complemento = Complemento;
                    _Endereco.Bairro = item.PessoaBairro;

                    _Endereco.Cep = null;
                    if (!string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(item.PessoaCEP)))
                        _Endereco.Cep = ZeusUtil.SomenteNumeros(item.PessoaCEP);
                    _Endereco.IDPais = 1058;

                    _Endereco.IDUnidadeFederativa = null;

                    _Endereco.IDUnidadeFederativa = 23;

                    _Endereco.IDMunicipio = null;


                    _Municipio = FuncoesMunicipio.GetMunicipioPorCodigo(Convert.ToDecimal(item.PessoaCidadeIBGE));


                    if (item.PessoaCidadeIBGE != null)
                        _Endereco.IDMunicipio = _Municipio.IDMunicipio;

                    if (!FuncoesEndereco.Salvar(_Endereco, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Endereço.");

                    if (!FuncoesFornecedor.Salvar(_Fornecedor, DAO.Enum.TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Cliente.");
                    PDVControlador.Commit();
                }

                MessageBox.Show(this, "Fornecedores salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message);
                PDVControlador.Rollback();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Model1 model1 = new Model1();
            _Produto = new DAO.Entidades.Produto();
            var objectProduto = model1.v_Produtos.ToList();
            try
            {
                foreach (var item in objectProduto)
                {
                    if (!FuncoesProduto.ExisteCodigoDeBarras(item.Barra))
                    {
                        PDVControlador.BeginTransaction();
                        _Produto.IDProduto = DAO.DB.Utils.Sequence.GetNextID("PRODUTO", "IDPRODUTO");
                        _Produto.Codigo = _Produto.IDProduto.ToString();
                        _Produto.Descricao = item.Nome;
                        _Produto.ValorCusto = item.PrecoFornecedor;
                        _Produto.ValorVenda = _Produto.ValorVenda = item.PrecoBase;
                        _Produto.EAN = item.Barra;
                        _Produto.IDNCM = FuncoesNcm.GetNCMPorCodigo(Convert.ToDecimal(item.NCM)).IDNCM;
                        _Produto.CEST = item.Cest;
                        _Produto.TipoDeProduto = 1;
                        _Produto.IDIntegracaoFiscalNFCe = 1;
                        _Produto.IDIntegracaoFiscalNFe = 1;

                        var almoxarifado = FuncoesAlmoxarifado.GetAlmoxarifado();
                        var origem = FuncoesOrigemProduto.GetOrigemProduto();
                        if (almoxarifado == null)
                            throw new Exception("Cadastre algum almoxarifado");
                        if (origem == null)
                            throw new Exception("Cadastre alguma origem de produto");

                        _Produto.IDAlmoxarifadoEntrada = almoxarifado.IDAlmoxarifado;
                        _Produto.IDAlmoxarifadoSaida = almoxarifado.IDAlmoxarifado;
                        _Produto.IDOrigemProduto = origem.IDOrigemProduto;

                        var unidade = FuncoesUnidadeMedida.GetUnidadeMedida(item.Unidade);
                        if (unidade != null)
                        {
                            _Produto.IDUnidadeDeMedida = unidade.IDUnidadeDeMedida;
                        }
                        else
                        {
                            var novaUnidade = new UnidadeMedida()
                            {
                                IDUnidadeDeMedida = DAO.DB.Utils.Sequence.GetNextID("UNIDADEDEMEDIDA", "IDUNIDADEDEMEDIDA"),
                                Descricao = item.Unidade,
                                Sigla = item.Unidade
                            };
                            if (!FuncoesUnidadeMedida.Salvar(novaUnidade, DAO.Enum.TipoOperacao.INSERT))
                                throw new Exception("Não foi possível salvar a Unidade de Medida");
                            _Produto.IDUnidadeDeMedida = _Produto.IDUnidadeDeMedida;
                        }
                        var categoria = FuncoesCategoria.GetCategoria(item.Grupo);
                        if (categoria != null)
                        {
                            _Produto.IDCategoria = categoria.IDCategoria;
                        }
                        else
                        {
                            var novaCategoria = new Categoria()
                            {
                                IDCategoria = DAO.DB.Utils.Sequence.GetNextID("CATEGORIA", "IDCATEGORIA"),
                                Descricao = item.Grupo
                            };
                            if (!FuncoesCategoria.Salvar(novaCategoria, DAO.Enum.TipoOperacao.INSERT))
                                throw new Exception("Não foi possível salvar a Categoria");
                            _Produto.IDCategoria = novaCategoria.IDCategoria;
                        }
                        if (!FuncoesProduto.SalvarProduto(_Produto, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Produto");
                        PDVControlador.Commit();
                    }
                }
                MessageBox.Show(this, "Produtos salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message);
                PDVControlador.Rollback();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Model1 model1 = new Model1();
            var objectVendedor = model1.v_PessoaDados.Where(v => v.bAtivo == 1 && v.bVendedor == 1).ToList();
            try
            {

                PDVControlador.BeginTransaction();
                foreach (var item in objectVendedor)
                {
                    try
                    {
                        _Usuario = new Usuario();
                        _Usuario.IDUsuario = DAO.DB.Utils.Sequence.GetNextID("USUARIO", "IDUSUARIO");
                        _Usuario.IDUsuarioSupervisor = FuncoesUsuario.GetUsuario("ROOT").IDUsuario;
                        var perfilAcesso = FuncoesPerfilAcesso.GetPerfil("VENDEDOR");
                        if (perfilAcesso != null)
                        {
                            _Usuario.IDPerfilAcesso = perfilAcesso.IDPerfilAcesso;
                            _Usuario.PerfilAcesso = perfilAcesso.Descricao;

                        }
                        else
                            throw new Exception("Não foi possível definir o atributo Perfil de Acesso");


                        _Usuario.IsVendedor = 1;
                        _Usuario.Nome = item.PessoaNome;
                        _Usuario.Senha = DAO.DB.Utils.Criptografia.CodificaSenha("123");
                        _Usuario.TipoDesconto = 1;
                        _Usuario.FormaDesconto = 1;
                        _Usuario.DescontoMaximo = 0;
                        _Usuario.Login = item.PessoaNome;

                        if (!FuncoesUsuario.Salvar(_Usuario, DAO.Enum.TipoOperacao.INSERT))
                            throw new Exception("Não foi possível salvar o Usuário");
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                    

                }
                MessageBox.Show(this, "Vendedores salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDVControlador.Commit();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message);
                PDVControlador.Rollback();
            }
        }
        public void IniciarConfiguracaoFinanceiro()
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Model1 model1 = new Model1();
                ContaReceber Conta = new ContaReceber();
                FormaDePagamento formaDePagamento = new FormaDePagamento();
                Cliente Cliente = new Cliente();
                var contasReceberOrigem = model1.VWContasReceber.ToList();

                string CodFormaPagamento = XtraInputBox.Show("Informe o ID da forma de pagamento da migração financeira", "Informações", "");
                if (string.IsNullOrEmpty(CodFormaPagamento))
                {
                    MessageBox.Show(this, "Operação não pode ser concluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    
                    foreach (var item in contasReceberOrigem)
                    {                       
                       
                        try
                        {
                            PDVControlador.BeginTransaction();
                            formaDePagamento = FuncoesFormaDePagamento.GetFormaDePagamento(Convert.ToDecimal(CodFormaPagamento));

                            Cliente = FuncoesCliente.GetClientePorNome(item.Nome);

                            Conta.IDContaReceber = PDV.DAO.DB.Utils.Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                            Conta.IDVenda = 0;
                            //Conta.IDContaBancaria = FuncoesContaBancaria.GetDefault().IDContaBancaria;
                            Conta.IDFormaDePagamento = decimal.Parse(CodFormaPagamento);
                            //Conta.IDHistoricoFinanceiro = FuncoesHistoricoFinanceiro.GetDefault().IDHistoricoFinanceiro;
                            Conta.IDCliente = Cliente.IDCliente;
                            Conta.Titulo = item.Parcela;
                            Conta.Parcela = 1;
                            Conta.Emissao = item.DataEmissao;
                            Conta.Vencimento = item.DataVencimento;
                            Conta.Situacao = 1;
                            Conta.Fluxo = DateTime.Now;
                            Conta.Origem = "Migração: " + item.NumeroPedido;
                            Conta.ComplmHisFin = item.NumeroPedido.ToString();
                            /* Valores */
                            Conta.Valor = item.Valor;
                            Conta.Multa = 0;
                            Conta.Juros = 0;
                            Conta.Desconto = 0;
                            Conta.Saldo = item.Valor;
                            Conta.ValorTotal = item.Valor;

                            if (!FuncoesContaReceber.Salvar(Conta, TipoOperacao.INSERT))
                                throw new Exception($"Não foi possível salvar o Lançamento do cliente {item.Nome}");
                            PDVControlador.Commit();
                        }
                        catch (Exception exception)
                        {
                            PDVControlador.Rollback();
                            throw exception;
                        }
                    }
                    MessageBox.Show(this, "Contas Receber Salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(this, ex.Message);
                    
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message);
            }
        }
        public class ClienteVen
        {
            public string Cliente { get; set; }
            public string Vendedor { get; set; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Model1 model1 = new Model1();

                List<ClienteVen> ClienteVen = model1.Database.SqlQuery<ClienteVen>("Select * From  clientevendedorerp Order by Cliente").ToList();

                foreach (var item in ClienteVen)
                {
                    Cliente cliente = FuncoesCliente.GetClientePorNome(item.Cliente);

                    Usuario usuario = FuncoesUsuario.GetUsuario(item.Vendedor);
                    if (usuario != null && cliente != null)
                    {
                        if (usuario.IDUsuario != null)
                        {
                            cliente.IDVendedor = int.Parse(usuario.IDUsuario.ToString());
                            FuncoesCliente.Salvar(cliente, TipoOperacao.UPDATE);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, ex.Message);
            }
        }
        public class BI
        {
            public string Cliente { get; set; }
            public string Vendedor { get; set; }
            public string Cidade { get; set; }
            public decimal Valor { get; set; }

            public string ValorFormatado { get { return "R$ " + Valor.ToString("#,##0.00"); } }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model1 = new Model1();
                List<BI> ClienteVen = model1.Database.SqlQuery<BI>(@"Select 
                                           Cliente = N.pessoanome,
                                           Vendedor = Pes.Nome,
                                           Cidade = N.PessoaCidade,
                                           Valor = convert(decimal(19, 2), Sum(N.TotalNota))

                                     From Nota N
                                    Join PessoaVendedor Ven on Ven.ID = N.IDVendedor
                                    Join Pessoa Pes on Pes.ID = Ven.IDPessoa
                                    Where N.Ent_Sai = 2
                                    And N.CancDt is null
                                    and N.dt between DATEADD(DAY, -180, GETDATE()) AND getdate()
                                    Group By  Pes.Nome, N.pessoanome, N.PessoaCidade
                                    Order by Valor desc").ToList();

                gridControl1.DataSource = ClienteVen;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
