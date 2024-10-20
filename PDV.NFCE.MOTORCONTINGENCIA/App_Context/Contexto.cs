using PDV.CONTROLLER.NFCE.Configuracao;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using System;
using System.IO;
using System.Reflection;

namespace PDV.NFCE.MOTORCONTINGENCIA.App_Context
{
    public class Contexto
    {
        public static string CODIGO_BRASIL = "1058";
        public static DBUtils.TIPOAMBIENTE AMBIENTE { get { return DBUtils.TIPOAMBIENTE.FORMS; } }

        public static int IDCONEXAO_PRIMARIA { get { return -1111; } }

        public static string CaminhoSolution
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached ?
                    Path.GetFullPath(".").Substring(0, Path.GetFullPath(".").IndexOf("PDV.NFCE.MOTORCONTINGENCIA")) :
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static ConfiguracaoNfce CONFIG_NFCe
        {
            get { return new ConfiguracaoNfce(CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\Schemas" : "\\App_Data\\Schemas")); }
        }

        private static Controlador _Controller;
        public static Controlador CONTROLADOR
        {
            get
            {
                if (_Controller == null)
                {
                    Controlador controlador = new Controlador(TipoConfiguracao.StartIni);
                    if (System.Diagnostics.Debugger.IsAttached)
                        controlador.Inicializa(CaminhoSolution + "\\PDV.NFCE.MOTORCONTINGENCIA\\App_Data\\Start.ini");
                    else
                        controlador.Inicializa(CaminhoSolution + "\\App_Data\\Start.ini");

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
