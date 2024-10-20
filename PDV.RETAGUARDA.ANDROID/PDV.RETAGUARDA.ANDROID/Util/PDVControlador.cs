using PDV.RETAGUARDA.WEB.AppContext;
using System.Web;

namespace PDV.RETAGUARDA.WEB.Util
{
    public class PDVControlador
    {


        public static int IDCONEXAO_PRIMARIA
        {
            get
            {
                return -1111;
            }
        }

        public static void BeginTransaction()
        {
            ContextoRetaguarda.CONTROLADOR.BeginTransaction(IDCONEXAO_PRIMARIA);
        }

        public static void Commit()
        {
            ContextoRetaguarda.CONTROLADOR.Commit(IDCONEXAO_PRIMARIA);
        }

        public static void Rollback()
        {
            ContextoRetaguarda.CONTROLADOR.Rollback(IDCONEXAO_PRIMARIA);
        }

        public ContextoRetaguarda ContextoRetaguarda
        {
            get
            {
                if (HttpContext.Current.Session["PDV_RETAGUARDAANDROID_CONTEXTO"] == null)
                    HttpContext.Current.Session["PDV_RETAGUARDAANDROID_CONTEXTO"] = new ContextoRetaguarda();
                return (ContextoRetaguarda)HttpContext.Current.Session["PDV_RETAGUARDAANDROID_CONTEXTO"];
            }
            set
            {
                HttpContext.Current.Session["PDV_RETAGUARDAANDROID_CONTEXTO"] = value;
            }
        }
    }
}