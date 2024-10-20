using PDV.CONTROLER.FuncoesAndroid;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/usuariocontroller")]
    public class UsuarioController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/getusuariopainellogin/{usuario}/{senha}")]
        public Usuario GetUsuarioPainelLogin(string usuario, string senha)
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();

            return FuncoesUsuario.GetUsuarioPorLoginESenha(usuario, Criptografia.CodificaSenha(senha));
        }
    }
}
