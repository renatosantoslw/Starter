using PDV.DAO.DB.Controller;
using System.Web;

namespace PDV.DAO.DB.Utils
{
    public class DBUtils
    {
        public enum TIPOAMBIENTE
        {
            FORMS = 0,
            WEB = 1,
            ANDROID = 2,
        }

        public static int IDCONEXAO_PRIMARIA { get; set; }

        public static TIPOAMBIENTE AMBIENTE { get; set; }

        private static Controlador _CONTROLADOR;
        public static Controlador CONTROLADOR
        {
            get
            {
                switch (AMBIENTE)
                {
                    case TIPOAMBIENTE.FORMS:
                        return _CONTROLADOR;
                    case TIPOAMBIENTE.WEB:
                    case TIPOAMBIENTE.ANDROID:
                        return HttpContext.Current.Session["PDV_CONTROLADOR"] as Controlador;
                    default:
                        return null;
                }
            }
            set
            {

                switch (AMBIENTE)
                {
                    case TIPOAMBIENTE.FORMS:
                        if (_CONTROLADOR == null)
                            _CONTROLADOR = value;
                        break;
                    case TIPOAMBIENTE.WEB:
                    case TIPOAMBIENTE.ANDROID:
                        HttpContext.Current.Session["PDV_CONTROLADOR"] = value;
                        break;
                }
            }
        }
    }
}
