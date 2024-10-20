using PDV.CONTROLER.FuncoesAndroid;
using PDV.DAO.Entidades;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/categoriacontroller")]
    public class CategoriaController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/getcategoriascomsubcategorias")]
        public List<Categoria> GetCategoriasComSubCategorias()
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();

            return FuncoesCategoria.GetCategoriasComSubCategorias();
        }
    }
}