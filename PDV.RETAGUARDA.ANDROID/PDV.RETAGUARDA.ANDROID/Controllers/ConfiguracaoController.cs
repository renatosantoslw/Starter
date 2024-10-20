using PDV.CONTROLER.FuncoesAndroid;
using PDV.DAO.Entidades;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/configuracaocontroller")]
    public class ConfiguracaoController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/getconfiguracao/{chave}")]
        public Configuracao GetConfiguracao(string Chave)
        {
            ContextoRetaguarda.SetConfiguracaoPrimaria();
            return FuncoesConfiguracao.GetConfiguracao(Chave);
        }
    }
}
