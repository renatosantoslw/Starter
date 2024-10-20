using AppFiscal.Model.APP;
using ModelAndroidApp.Controler;
using ModelAndroidApp.ModelAndroid;
using Newtonsoft.Json;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PDV.VIEW.Tarefas_do_Sistema
{
    public static class Tarefas
    {
        public class Log
        {
            public DateTime DataHora { get; set; }
            public string Mensagem { get; set; }
        }
        public static class WSMonitoramento
        {
            private static BindingList<Log> _Log { get; set; }
            public static BindingList<Log> Log
            {
                get
                {
                    if (_Log == null)
                    {
                        _Log = new BindingList<Log>();
                        _Log.AllowEdit = false;
                        _Log.AllowNew = true;
                        _Log.AllowRemove = true;
                    }

                    return _Log;
                }
                set
                {
                    _Log = value;
                }
            }

            public static void AddLog(string msg)
            {
                AddLog(new Log() { DataHora = DateTime.Now, Mensagem = msg });

            }
            public static void AddLog(Log log)
            {
                try
                {
                    Log.Add(log);

                    if (Log.Count > 220)
                    {
                        Log = new BindingList<Log>(Log.ToList());
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public static void RunMonitoramento()
        {
            
            try
            {
               
                WSMonitoramento.AddLog("Iniciando Atualização...");
                AtualizarAPP();
                Thread.Sleep(1000000);
                WSMonitoramento.AddLog("Atualização da base do aplicativo foi atualizada com sucesso!");
                System.Threading.Tasks.Task.Run((Action)(RunMonitoramento));
            }
            catch (Exception ex)
            {
                WSMonitoramento.AddLog($"Ocorreu um erro :{ex.Message}");
                //System.Threading.Tasks.Task.Run((Action)(RunMonitoramento));
            }
        }

        public static void AtualizarAPP()
        {
            try
            {
                #region Instanciando Classes
                List<DAO.Entidades.Cliente> lstClienteLocal = new List<DAO.Entidades.Cliente>();
                List<DAO.Entidades.Usuario> lstUsuarioLocal = new List<DAO.Entidades.Usuario>();
                List<DAO.Entidades.Produto> lstProduto = new List<DAO.Entidades.Produto>();
                List<FormaDePagamento> lstformaDePagamentos = new List<FormaDePagamento>();
                List<ModelAndroidApp.ModelAndroid.Cliente> ListagemclientesJson = new List<ModelAndroidApp.ModelAndroid.Cliente>();

                Endereco endereco = new Endereco();
                Contato contato = new Contato();


                   

                #endregion
               
                #region Enviando Vendedores / Usuarios 
                WSMonitoramento.AddLog("Sincronizando vendedores/usuarios...");
                lstUsuarioLocal = FuncoesUsuario.GetUsuarios();
                if (lstUsuarioLocal.Count > 0)
                {
                    VendedorUsuarioController.ExcluirVendedor();
                    foreach (var item in lstUsuarioLocal)
                    {
                        Vendedor vendedorNuvem = new Vendedor()
                        {
                            Nome = item.Nome,
                            Email = item.Login,
                            Telefone = "",
                            Senha = Criptografia.DecodificaSenha(item.Senha),
                            IDVendedor = int.Parse(item.IDUsuario.ToString()),
                            //Criar Campos 
                            Gestor = item.IsVendedor == 1 ? false : true,
                            IDErp = 1,
                            FormaDesconto = item.FormaDesconto.ToString(),
                            TipoDesconto = item.TipoDesconto.ToString()
                        };
                        VendedorUsuarioController.SalvarVendedor(vendedorNuvem);
                    }
                }
                #endregion

                #region Clientes
                WSMonitoramento.AddLog("Sincronizando clientes...");
                string UF = "";
                string Municipio = "";
                string Email = "";
                string Telefone = "";
                lstClienteLocal = FuncoesCliente.GetClienteObjeto();
                if (lstClienteLocal != null)
                {
                    var lstProcessada = lstClienteLocal.ToList();
                    ClienteControllerAPP.ExcluirCliente();
                    foreach (var item in lstProcessada)
                    {
                        //Setar Contato
                        if (item.IDContato != null)
                        {
                            contato = FuncoesContato.GetContato(item.IDContato.Value);
                            if (contato != null)
                            {
                                Email = contato.Email == null ? "" : contato.Email;
                                Telefone = contato.Telefone == null ? "" : contato.Telefone;
                            }
                        }

                        //Setando o Endereço
                        if (item.IDEndereco == null)
                        {
                            continue;
                        }
                        endereco = FuncoesEndereco.GetEndereco(decimal.Parse(item.IDEndereco.ToString()));
                        if (endereco.IDPais.HasValue)
                        {
                            List<Pais> _Paises = FuncoesPais.GetPaises();

                            if (endereco.IDUnidadeFederativa.HasValue)
                            {
                                List<UnidadeFederativa> _Unidades = FuncoesUF.GetUnidadesFederativa(endereco.IDPais.Value).Where(x => x.IDUnidadeFederativa == endereco.IDUnidadeFederativa).ToList();
                                UF = _Unidades[0].Sigla;

                                if (endereco.IDMunicipio.HasValue)
                                {
                                    List<Municipio> _Municipios = FuncoesMunicipio.GetMunicipios(endereco.IDUnidadeFederativa.Value);
                                    List<Municipio> municipioProcessado = _Municipios.Where(o => o.IDMunicipio == endereco.IDMunicipio.Value).ToList();
                                    if (municipioProcessado.Count > 0)
                                        Municipio = municipioProcessado[0].Descricao;
                                }
                            }

                            if (item.CNPJ == "07797053000124")
                            {

                            }

                            ModelAndroidApp.ModelAndroid.Cliente clienteWeb = new ModelAndroidApp.ModelAndroid.Cliente()
                            {
                                Nome = item.Nome ?? item.RazaoSocial ?? item.NomeFantasia,
                                CPFCNPJ = item._CPF_CNPJ,
                                Endereco = endereco.Logradouro + " Nº:" + endereco.Numero + " Compl:" + endereco.Complemento,
                                Bairro = endereco.Bairro,
                                Cidade = Municipio,
                                UF = UF,
                                Cep = endereco.Cep,
                                Email = Email,
                                Telefone = Telefone,
                                IDCliente = int.Parse(item.IDCliente.ToString()),
                                IDERP = int.Parse(item.IDCliente.ToString()),
                                IDVendedor = item.IDVendedor
                            };
                            ListagemclientesJson.Add(clienteWeb);
                            ClienteControllerAPP.SalvarClenteAPP(clienteWeb);
                        }
                    };
                    //var Texto = JsonConvert.SerializeObject(ListagemclientesJson);
                    //ClienteControllerAPP.AtualizarBaseCliente(Texto);
                }
                #endregion

                #region Forma de Pagamento
                WSMonitoramento.AddLog("Sincronizando formas de pagamento...");
                lstformaDePagamentos = FuncoesFormaDePagamento.GetFormasPagamentoForcaDeVenda();

                if (lstformaDePagamentos != null)
                {
                    CondicaoControllerAPP.ExcluirCondicao();
                    if (lstformaDePagamentos.Count > 0)
                    {
                        for (int i = 0; i < lstformaDePagamentos.Count; i++)
                        {
                            Condicao condicao = new Condicao()
                            {
                                Nome = lstformaDePagamentos[i].Identificacao,
                                IDCondicao = int.Parse(lstformaDePagamentos[i].IDFormaDePagamento.ToString()),
                                ID_Erp = long.Parse(lstformaDePagamentos[i].IDFormaDePagamento.ToString()),
                                Transacao = short.Parse(lstformaDePagamentos[i].Transacao.ToString()),
                                Usa_Calendario_Comercial = lstformaDePagamentos[i].Usa_Calendario_Comercial,
                                Qtd_Parcelas = short.Parse(lstformaDePagamentos[i].Qtd_Parcelas.ToString()),
                                Dias_Intervalo = short.Parse(lstformaDePagamentos[i].Dias_Intervalo.ToString()),
                                Fator_Dup_Com_Entrada = decimal.Parse(lstformaDePagamentos[i].Fator_Dup_Com_Entrada.ToString()),
                                Fator_Dup_Sem_Entrada = decimal.Parse(lstformaDePagamentos[i].Fator_Dup_Sem_Entrada.ToString()),
                                Fator_Cheq_Com_Entrada = decimal.Parse(lstformaDePagamentos[i].Fator_Cheq_Com_Entrada.ToString()),
                                Fator_Cheq_Sem_Entrada = decimal.Parse(lstformaDePagamentos[i].Fator_Cheq_Sem_Entrada.ToString())
                            };
                            CondicaoControllerAPP.SalvarCondicao(condicao);
                        }
                    }
                }
                #endregion

                #region Produtos

                WSMonitoramento.AddLog("Sincronizando produtos...");
                lstProduto = FuncoesProduto.GetProdutoLista();
                if (lstProduto.Count > 0)
                {
                    ProdutoControllerAPP.ExcluirProduto();
                    ProdutoControllerAPP.ExcluirEstoque();
                    for (int i = 0; i < lstProduto.Count; i++)
                    {
                        ModelAndroidApp.ModelAndroid.Produto produto = new ModelAndroidApp.ModelAndroid.Produto()
                        {
                            Nome = lstProduto[i].Descricao,
                            Codigo = lstProduto[i].EAN,
                            Preco = lstProduto[i].ValorVenda == null ? 0 :0, 
                            UnidadeNome = FuncoesUnidadeMedida.GetUnidadeMedida(lstProduto[i].IDUnidadeDeMedida).Descricao.ToString(),
                            UnidadeID = int.Parse(lstProduto[i].IDUnidadeDeMedida.ToString()),
                            ProdutoID = int.Parse(lstProduto[i].IDProduto.ToString()),
                            Imagem = lstProduto[i].ImagemProdutoLink,
                            Estoque = lstProduto[i].SaldoEstoque
                            
                        };
                        ProdutoControllerAPP.SalvarProdutoAPP(produto);

                        ModelAndroidApp.ModelAndroid.Estoque estoque = new ModelAndroidApp.ModelAndroid.Estoque()
                        {
                            IDEmpresaERP = "1",
                            CodigoERP = int.Parse(lstProduto[i].IDProduto.ToString()),
                            Preco = lstProduto[i].ValorVenda,
                            PrecoaPrazo = lstProduto[i].ValorVendaPrazo,
                            DataHoraUltimaCargaERP = DateTime.Now,
                            Quantidade = lstProduto[i].SaldoEstoque
                        };
                        ProdutoControllerAPP.SalvarEstoqueAPP(estoque);
                    }
                }
                #endregion

                #region Empresa
                WSMonitoramento.AddLog("Sincronizando emitente(s)...");
                Emitente emitente = FuncoesEmitente.GetEmitente();
                Endereco funcoesEndereco = FuncoesEndereco.GetEndereco(emitente.IDEndereco);
                if (emitente != null)
                {
                    EmitenteControllerAPP.ExcluirEmresa();
                    ModelAndroidApp.ModelAndroid.Empresa empresa = new ModelAndroidApp.ModelAndroid.Empresa()
                    {
                        Nome = emitente.RazaoSocial,
                        IDEmpresaERP = emitente.IDEmitente.ToString(),
                        Endereco = funcoesEndereco.Logradouro + " " + funcoesEndereco.Numero + " , " + funcoesEndereco.Bairro + "-" + funcoesEndereco.Municipio + "-" + funcoesEndereco.UnidadeFederativa,
                        CNPJ = emitente.CNPJ
                    };
                    EmitenteControllerAPP.SalvarEmpresaAPP(empresa);

                }

                WSMonitoramento.AddLog("Sincronizando usuario app estoque...");
                //Limpa e insere usuarios do app estoque
                lstUsuarioLocal = FuncoesUsuario.GetUsuarios();
                if (lstUsuarioLocal.Count > 0)
                {
                    VendedorUsuarioController.ExcluirUsuarioEstoque(int.Parse(emitente.IDEmitente.ToString()));
                    foreach (var item in lstUsuarioLocal)
                    {
                        ModelAndroidApp.Usuario usuario = new ModelAndroidApp.Usuario()
                        {
                            Nome = item.Nome,
                            Email = item.Login,
                            Senha = Criptografia.DecodificaSenha(item.Senha),
                            IDVendedor = int.Parse(item.IDUsuario.ToString()),
                            EmpresaID = int.Parse(emitente.IDEmitente.ToString())
                        };
                        VendedorUsuarioController.SalvarUsuarioAppEstoque(usuario);
                    }
                }


                #endregion

                #region Documentos
                //List<ContaReceber> contaReceber = new List<ContaReceber>();
                ClienteControllerAPP.ExcluirDocumento();

                //contaReceber = FuncoesContaReceber.GetContasReceberPorListaEmAberto();
                //foreach (var item in contaReceber)
                //{
                //    Documento documento = new Documento()
                //    {
                //        Emissao = item.Emissao,
                //        Vencimento = item.Vencimento,
                //        Titulo = item.Titulo,
                //        ValorEmAberto = item.Saldo,
                //        Valor = item.Valor,
                //        ValorTotal = item.ValorTotal,
                //        IDDocumento = int.Parse(item.IDContaReceber.ToString()),
                //        PessoaID = int.Parse(item.IDCliente.ToString()),
                //        NumeroPedido = item.IDVenda == null ? 0 : int.Parse(item.IDVenda.ToString()),
                //        Tipo = 2,
                //        Cobrado = false,
                //        Pessoa = FuncoesCliente.GetCliente(item.IDCliente).Nome,
                //        Detalhe = item.ComplmHisFin
                //    };
                //    ClienteControllerAPP.SalvarDocumentoAPP(documento);
                //}
                #endregion
              
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                throw;
            }
        }
    }
}