using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;

namespace PDV.RETAGUARDA.ANDROID.Controllers
{
    [RoutePrefix("api/basedadosandroidcontroller")]
    public class BaseDadosAndroidController : ApiController, IRequiresSessionState
    {
        [HttpGet]
        [Route("consulta/verificaconexaowebapiandroid")]
        public int VerificaConexaoWebAPIAndroid()
        {
            return 1;
        }
    }
}
