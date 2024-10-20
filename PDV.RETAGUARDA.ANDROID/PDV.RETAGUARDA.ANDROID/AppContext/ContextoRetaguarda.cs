using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using System;
using System.Web;
using static PDV.DAO.DB.Utils.DBUtils;

namespace PDV.RETAGUARDA.WEB.AppContext
{
    public class ContextoRetaguarda
    {
        public static TIPOAMBIENTE AMBIENTE
        {
            get
            {
                return TIPOAMBIENTE.ANDROID;
            }
        }

        public static int IDCONEXAO_PRIMARIA
        {
            get
            {
                return -1111;
            }
        }

        private static Controlador _Controller;
        public static Controlador CONTROLADOR
        {
            get
            {
                if (_Controller == null)
                {
                    Controlador controlador = new Controlador(TipoConfiguracao.StartIni);
                    controlador.Inicializa(HttpContext.Current.Server.MapPath("~/App_Data/Start.ini"));
                    controlador.IniciaConexaoPrimaria("Conexao_PDV");
                    if (!controlador.ConexaoPrimariaEstaAtiva())
                    {
                        System.Threading.Thread.Sleep(5000);
                        if (!controlador.ConexaoPrimariaEstaAtiva())
                        {
                            controlador.DesconectarConexaoPrimaria();
                            throw new Exception("Não foi possível iniciar a conexão primária com o banco de dados.");
                        }
                    }
                    controlador.DesconectarConexaoPrimaria();
                    _Controller = controlador;
                }
                return _Controller;
            }
        }

        public static void SetConfiguracaoPrimaria()
        {
            DBUtils.AMBIENTE = AMBIENTE;
            DBUtils.IDCONEXAO_PRIMARIA = IDCONEXAO_PRIMARIA;
            DBUtils.CONTROLADOR = CONTROLADOR;
        }
    }
}