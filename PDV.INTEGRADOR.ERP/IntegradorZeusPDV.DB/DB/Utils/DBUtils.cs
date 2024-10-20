using IntegradorZeusPDV.DB.DB.Controller;

namespace IntegradorZeusPDV.DB.DB.Utils
{
    public class DBUtils
    {
        public static int IDCONEXAO_PRIMARIA { get; set; }

        private static Controlador _CONTROLADOR;
        public static Controlador CONTROLADOR
        {
            get
            {
                return _CONTROLADOR;
            }
            set
            {

                if (_CONTROLADOR == null)
                    _CONTROLADOR = value;
            }
        }
    }
}
