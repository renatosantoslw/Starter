using PDV.RETAGUARDA.WEB.AppContext;
using System;
using System.Web;
using System.Web.SessionState;

namespace PDV
{
    public class Global : HttpApplication, IRequiresSessionState
    {
        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }
    }
}