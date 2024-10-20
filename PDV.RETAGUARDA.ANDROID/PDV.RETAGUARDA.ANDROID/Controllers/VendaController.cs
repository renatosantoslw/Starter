using Newtonsoft.Json;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.RETAGUARDA.WEB.AppContext;
using PDV.RETAGUARDA.WEB.Util;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/vendacontroller")]
    public class VendaController : ApiController, IRequiresSessionState
    {
        public class FiltroVenda
        {
            public decimal IDVenda { get; set; }
            public decimal IDUsuario { get; set; }
            public decimal IDComanda { get; set; }
            public string CPFComanda { get; set; }
            public FiltroItemVenda[] Itens { get; set; } = null;

            public FiltroVenda() { }
        }

        public class FiltroItemVenda
        {
            public decimal IDItemVenda { get; set; }
            public decimal IDProduto { get; set; }
            public decimal QuantidadeProduto { get; set; }
            public decimal ValorUnitarioItem { get; set; }
            public decimal IDUsuario { get; set; }

            public FiltroItemVenda() { }
        }

        [HttpPost]
        [Route("salvar")]
        public string Salvar(HttpRequestMessage request)
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            try
            {
                FiltroVenda Filtro = JsonConvert.DeserializeObject<FiltroVenda>(request.Content.ReadAsStringAsync().Result);

                PDVControlador.BeginTransaction();

                Venda VendaComanda = null;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (Filtro.IDVenda == -1)
                {
                    Op = TipoOperacao.INSERT;
                    /* Atualização do CPF da Venda - Android */

                    Cliente CliEncontrado = null;
                    if (!string.IsNullOrEmpty(Filtro.CPFComanda))
                    {
                        FuncoesCliente.GetClientePorCPF(Filtro.CPFComanda);
                        if (CliEncontrado == null)
                        {
                            CliEncontrado = new Cliente { IDCliente = Sequence.GetNextID("CLIENTE", "IDCLIENTE") };
                            if (!FuncoesCliente.SalvarAtualizarClienteNFCe("",CliEncontrado.IDCliente, null, Filtro.CPFComanda, 1))
                                throw new Exception("Não foi possível salvar o Cliente.");
                        }
                    }

                    VendaComanda = new Venda();
                    Filtro.IDVenda = Sequence.GetNextID("VENDA", "IDVENDA");
                    VendaComanda.IDVenda = Filtro.IDVenda;
                    VendaComanda.DataCadastro = DateTime.Now;
                    VendaComanda.IDFluxoCaixa = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Filtro.IDUsuario).IDFluxoCaixa;
                    VendaComanda.QuantidadeDeItens = Filtro.Itens.Length;
                    VendaComanda.ValorTotal = Filtro.Itens.AsEnumerable().Sum(o => o.QuantidadeProduto * o.ValorUnitarioItem);
                    VendaComanda.IDComanda = Filtro.IDComanda;
                    VendaComanda.IDUsuario = Filtro.IDUsuario;
                    VendaComanda.IDCliente = CliEncontrado == null ? null : (decimal?)CliEncontrado.IDCliente;

                    if (!FuncoesVenda.SalvarVenda(VendaComanda))
                        throw new Exception("Não foi possível salvar a VENDA.");
                }

                foreach (FiltroItemVenda FiltroItem in Filtro.Itens)
                {
                    ItemVenda Item = new ItemVenda()
                    {
                        IDItemVenda = Sequence.GetNextID("ITEMVENDA", "IDITEMVENDA"),
                        IDProduto = FiltroItem.IDProduto,
                        IDVenda = Filtro.IDVenda,
                        Quantidade = FiltroItem.QuantidadeProduto,
                        DescontoPorcentagem = 0,
                        DescontoValor = 0,
                        ValorUnitarioItem = FiltroItem.ValorUnitarioItem,
                        IDUsuario = Filtro.IDUsuario
                    };

                    if (!FuncoesItemVenda.SalvarItemVenda(Item))
                        throw new Exception("Não foi possível salvar os ITENS da VENDA.");
                }

                if (Op == TipoOperacao.UPDATE)
                    if (!FuncoesVenda.AtualizarValorTotalEQuantidade(Filtro.IDVenda))
                        throw new Exception("Não foi possível salvar a VENDA.");

                PDVControlador.Commit();
                return "OK";
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                return Ex.StackTrace;
            }
        }
    }
}
