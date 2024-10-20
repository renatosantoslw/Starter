using IntegradorZeusPDV.DB.DB.Controller;
using IntegradorZeusPDV.DB.DB.Utils;
using System;
using System.IO;
using System.Reflection;

namespace IntegradorZeusPDV.App_Context
{
    public class Contexto
    {
        public static int IDCONEXAO_PRIMARIA { get { return -1111; } }

        public static string CaminhoSolution
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached ?
                    Path.GetFullPath(".").Substring(0, Path.GetFullPath(".").IndexOf("IntegradorZeusPDV")) :
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
                    if (System.Diagnostics.Debugger.IsAttached)
                        controlador.Inicializa(CaminhoSolution + "IntegradorZeusPDV\\App_Data\\Start.ini");
                    else
                        controlador.Inicializa(CaminhoSolution + "\\App_Data\\Start.ini");

                    /* Conexao Primária */
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
                    _Controller = controlador;
                }
                return _Controller;
            }
        }

        public static void SetConfiguracaoPrimaria()
        {
            DBUtils.IDCONEXAO_PRIMARIA = IDCONEXAO_PRIMARIA;
            DBUtils.CONTROLADOR = CONTROLADOR;
        }
    }
}
