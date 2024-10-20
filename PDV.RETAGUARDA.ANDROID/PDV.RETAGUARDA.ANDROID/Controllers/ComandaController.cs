using PDV.CONTROLER.FuncoesAndroid;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/comandacontroller")]
    public class ComandaController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/getcomandas")]
        public List<Comanda> GetComandas()
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            return FuncoesComanda.GetComandas();
        }

        [HttpGet]
        [Route("consulta/getprodutosporcomanda/{idcomanda}")]
        public List<ItemVenda> GetProdutosPorComanda(decimal idcomanda)
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            return FuncoesComanda.GetProdutosComandaPorComanda(idcomanda);
        }
    }
}
