using PDV.DAO.DB.Controller;

namespace PDV.VIEW.App_Context
{
    public class PDVControlador
    {
        public static Controlador CONTROLADOR
        {
            get
            {
                return Contexto.CONTROLADOR;
            }
        }

        public static void BeginTransaction()
        {
            CONTROLADOR.BeginTransaction(Contexto.IDCONEXAO_PRIMARIA);
        }

        public static void Commit()
        {
            CONTROLADOR.Commit(Contexto.IDCONEXAO_PRIMARIA);
        }

        public static void Rollback()
        {
            CONTROLADOR.Rollback(Contexto.IDCONEXAO_PRIMARIA);
        }
    }
}
