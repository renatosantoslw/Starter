using IntegradorZeusPDV.App_Context;
using IntegradorZeusPDV.CONTROLLER.Funcoes;
using IntegradorZeusPDV.DB.DB.Utils;
using IntegradorZeusPDV.MODEL.ClassesPDV;
using IntegradorZeusPDV.MODEL.ClassesWS;
using IntegradorNextGestorPDV.WSFinanceiro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;

namespace IntegradorZeusPDV
{

    public class Program
    {
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        private static wsFinanceiroSoapClient _ClientWS = null;
        private static wsFinanceiroSoapClient ClientWS
        {
            get
            {
                if (_ClientWS == null)
                    _ClientWS = new wsFinanceiroSoapClient();
                return _ClientWS;
            }
        }

        static void Main(string[] args)
        {
            // Verificar Parametros.

            IniciarIntegracao();
        }

        private static void IniciarIntegracao()
        {
            try
            {
                Contexto.SetConfiguracaoPrimaria();

                Console.WriteLine("==========================================");
                Console.WriteLine("       [ INICIO DA INTEGRAÇÃO ]");
                Console.WriteLine("==========================================");

                PDVControlador.BeginTransaction();
                IntegradorDUEPDV.GerarChaveLicenca.CreateTrailfunctionality();
                /* Inicio das Integrações */
                // IntegrarEmitente();
                //  IntegrarUsuario();
                //   IntegrarCliente();
                //   IntegrarProduto();
                // IntegrarVendas();
                /* Fim das Integrações */

                PDVControlador.Commit();
                Console.WriteLine("Integração Realizada com Sucesso!");
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                Console.WriteLine(Ex.Message);
            }
            Console.ReadKey();
        }

        private static void GerarChave()
        {

        }
        private static void IniciarEnvio()
        {

        }

        private static void IntegrarEmitente()
        {
            Console.WriteLine("Carregando dados do Emitente...");
            try
            {
                Emitente Emit = JsonConvert.DeserializeObject<Emitente[]>(ClientWS.getEmitente("12069715000180")).FirstOrDefault();
                if (Emit != null)
                {
                    MODEL.ClassesPDV.Emitente EmitentePDV = FuncoesEmitente.GetEmitente();
                    TipoOperacao Op = EmitentePDV == null ? TipoOperacao.INSERT : TipoOperacao.UPDATE;
                    if (EmitentePDV == null)
                        EmitentePDV = new MODEL.ClassesPDV.Emitente() { IDEmitente = Sequence.GetNextID("EMITENTE", "IDEMITENTE") };

                    EmitentePDV.RazaoSocial = Emit.RazaoSocial;
                    EmitentePDV.NomeFantasia = Emit.NomeFantasia;
                    EmitentePDV.InscricaoEstadual = Emit.InscricaoEstadual;
                    EmitentePDV.IDEndereco = null;

                    if (!FuncoesEmitente.SalvarEmitente(EmitentePDV, Op))
                        throw new Exception("Não foi possível salvar o Emitente.");

                }
                Console.WriteLine("Emitente Integrado com Sucesso...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Importar: " + ex.Message);
            }
        }

        private static void IntegrarCliente()
        {
            Console.WriteLine("Carregando dados do Cliente...");
            try
            {
                List<Entidade> Entidades = JsonConvert.DeserializeObject<Entidade[]>(ClientWS.getEntidades("12069715000180")).ToList();
                if (Entidades == null)
                    return;

                foreach (Entidade Ent in Entidades)
                {
                    if (!FuncoesCliente.Salvar(new MODEL.ClassesPDV.Cliente
                    {
                        Ativo = 'S' == Ent.Ativo ? 1 : 0,
                        RazaoSocial = Ent.Nome,
                        NomeFantasia = Ent.Nome,
                        Nome = Ent.Nome,
                        TipoDocumento = Ent.Cnpj_Cpf.Length == 11 ? 1 : 0,
                        CNPJ = Ent.Cnpj_Cpf.Length == 14 ? Ent.Cnpj_Cpf : null,
                        CPF = Ent.Cnpj_Cpf.Length == 11 ? Ent.Cnpj_Cpf : null,
                        ChaveERP = Ent.Id.ToString()
                    }))
                        throw new Exception("Não foi possível salvar o Cliente.");
                }
                Console.WriteLine("Cliente Integrado com Sucesso...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Importar Cliente: " + ex.Message);
            }
        }

        private static void EnviaWEB()
        {
            int desc;
            bool hasConnection = InternetGetConnectedState(out desc, 0);
            if (hasConnection)
            {
                Console.WriteLine("Carregando dados...");


            }
            else
            {
                Console.WriteLine("Sem conectividade com a internet...");
            }
            
        }

        //private static void EnviaVendas()
        //{
        //    DataTable vendas = FuncoesVenda.GetVendasPDV();

        //    List<object> resultado = new List<object>();
        //    foreach (DataRow item in vendas)
        //    {
        //        resultado.Add(new
        //        {
        //            Id = item.IDVENDA,
        //            IdCliente = item.codcliente,
        //            Valor = item.VALORVENDA,
        //            Qtde = item.QTDE,
        //            Total = itemTOTAL
        //        });
        //    }

        //}

        private static void IntegrarVendas()
        {
            Console.WriteLine("Carregando dados das Vendas...");
            List<Venda> VendasDoDia = FuncoesVenda.GetVendasDoDia();
            foreach (Venda v in VendasDoDia)
            {
                List<ItemVenda> Itens = FuncoesItemVenda.GetItens(v.IDVenda);
                foreach (ItemVenda Item in Itens)
                    Item.Produto = FuncoesProduto.GetProduto(Item.IDProduto);
                v.Itens = Itens;

                v.Cliente = FuncoesCliente.GetCliente(v.IDCliente);
             //   v.MovimentoFiscal = FuncoesMovimentoFiscal.GetMovimentoFiscalPorVenda(v.IDVenda);
              //  v.Usuario = FuncoesUsuario.GetUsuario(v.IDUsuario);
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            var js = JsonConvert.SerializeObject(VendasDoDia);
            ClientWS.AtualizaVendas("12069715000180", "1GS7LPLBD752VJNPCKGWU9EU0X6C8PHW6A5L", JsonConvert.SerializeObject(VendasDoDia));

            Console.WriteLine("Vendas Integrado com Sucesso...");
        }

        private static void IntegrarUsuario()
        {
            Console.WriteLine("Carregando dados do Usuario...");
            List<Usuario> usuario = JsonConvert.DeserializeObject<Usuario[]>(ClientWS.getUsuario("12069715000180")).ToList();
            if (usuario == null)
                return;
            foreach (Usuario usu in usuario)
            {
                string sAux = "";
                DataTable user = FuncoesUsuario.GetUsuario(usu.IDUsuario);
                if (user != null)
                {
                    DataRow row = user.Rows[0];
                    sAux = row["IDNCM"].ToString();
                }
                else
                {
                    sAux = "1";
                }

                decimal dAux = Decimal.Parse(sAux);
                if (!FuncoesUsuario.Salvar(new MODEL.ClassesPDV.Usuario
                {
                    Nome = usu.Nome,
                    Login = usu.Nome,
                    Senha = usu.Senha,
                    Ativo = 1,
                    Root = 0,
                    Email = usu.Email,
                    IDPerfilAcesso = 2,
                    IDUsuario = usu.IDUsuario,
                    ChaveERP = usu.IDUsuario.ToString()
                }))
                    throw new Exception("Não foi possível salvar o Usuario.");
            }
            Console.WriteLine("Usuario Integrado com Sucesso...");

        }

        private static void IntegrarProduto()
        {
            Console.WriteLine("Carregando dados do Produto...");
            try
            {
                List<Produto> Produtos = JsonConvert.DeserializeObject<Produto[]>(ClientWS.getProdutos("12069715000180")).ToList();
                if (Produtos == null)
                    return;

                foreach (Produto PRO in Produtos)
                {
                    string sAux = "1";
                    Console.WriteLine("Produto: " + PRO.Descricao );
                    if (PRO.Descricao == "N LENCOL 4 PÇS POLAR")
                    {
                        string Aux = "teste";
                    }
                    if (PRO.NCM != "")
                    {
                        
                        DataTable prod = FuncoesProduto.NCM(PRO.NCM);
                        if (prod.Rows.Count > 0)
                        {
                            DataRow row = prod.Rows[0];
                            sAux = row["IDNCM"].ToString();
                        }
                        else
                        {
                            sAux = "1";
                        }
                    }

                    decimal dAux = Decimal.Parse(sAux);
                    if (!FuncoesProduto.Salvar(new MODEL.ClassesPDV.Produto
                    {
                        Descricao = PRO.Descricao,
                        ValorVenda = PRO.ValorVista,
                        ValorVendaPrazo = PRO.ValorPrazo,
                        EAN = PRO.EAN,
                        IDNCM = decimal.Parse(sAux),
                        Ativo = 1,
                        Codigo = PRO.EAN,
                        IDUnidadeDeMedida = 1,
                        IDOrigemProduto = 0,
                        IDIntegracaoFiscalNFCe = 1,
                        Trib_MVA = 0,
                        Trib_RedBCICMS = 0,
                        Trib_RedBCICMSST = 0,
                        Trib_AliqCOFINS = 0,
                        Trib_AliqICMSDif = 0,
                        Trib_AliqIPI = 0,
                        Trib_AliqPIS = 0,
                        ChaveERP = PRO.ChaveERP
                    }))
                        throw new Exception("Não foi possível salvar o Produto.");
                }
                Console.WriteLine("Produto Integrado com Sucesso...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Produto: " + ex.Message);
            }
        }
    }
}
