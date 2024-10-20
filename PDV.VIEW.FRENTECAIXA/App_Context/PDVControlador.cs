using PDV.DAO.DB.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA.App_Context
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
