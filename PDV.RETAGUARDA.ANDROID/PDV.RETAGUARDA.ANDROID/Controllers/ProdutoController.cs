using PDV.CONTROLER.FuncoesAndroid;
using PDV.DAO.Entidades;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/produtocontroller")]
    public class ProdutoController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/getprodutosporcategoria/{idcategoria}")]
        public List<Produto> GetProdutosPorCategoria(decimal idcategoria)
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            return FuncoesProduto.GetProdutosPorCategoria(idcategoria);
        }

        [HttpGet]
        [Route("consulta/getprodutoscomtributacaovigente")]
        public List<Produto> GetProdutosComTributacaoVigente()
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            return FuncoesProduto.GetProdutosComTributacaoVigente();
        }        
    }
}