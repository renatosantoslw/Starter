using PDV.CONTROLLER.NFCE.Configuracao;
using PDV.DAO.Custom.Configuracoes;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.UTIL.FORMS.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static PDV.DAO.DB.Utils.DBUtils;

namespace PDV.SERVICE.App_Context
{
    public class Contexto
    {
        public static string CODIGO_BRASIL = "1058";
        public static Version VERSAO;

        /* VARIAVEIS DO USUÁRIO */


        /* END VARIAVEIS USUARIO */

        public static int IDCONEXAO_PRIMARIA { get { return -1111; } }

        public static string CaminhoSolution
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached ?
                    Path.GetFullPath(".").Substring(0, Path.GetFullPath(".").IndexOf("PDV.VIEW.FRENTECAIXA")) :
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
                        controlador.Inicializa(CaminhoSolution + "\\PDV.VIEW.FRENTECAIXA\\App_Data\\Start.ini");
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
