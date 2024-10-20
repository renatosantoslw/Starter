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
using System.Windows.Forms;
using static PDV.DAO.DB.Utils.DBUtils;

namespace PDV.VIEW.FRENTECAIXA.App_Context
{
    public class Contexto
    {
        public static string CODIGO_BRASIL = "1058";
        public static Version VERSAO;
        public static Login TELA_LOGIN;

        /* VARIAVEIS DO USUÁRIO */
        public static Usuario USUARIOLOGADO;
        public static List<ItemMenu> ITENSMENU;

        /* END VARIAVEIS USUARIO */

        public static TIPOAMBIENTE AMBIENTE { get { return TIPOAMBIENTE.FORMS; } }

        public static int IDCONEXAO_PRIMARIA { get { return -1111; } }

        public static CFG_PDV CONFIGURACAO_SERIE { get { return CONTROLADOR.GetConfiguracaoPDV(); } }

        public static string CaminhoSolution
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached ?
                    Path.GetFullPath(".").Substring(0, Path.GetFullPath(".").IndexOf("PDV.VIEW.FRENTECAIXA")) :
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static ConfiguracaoNfce CONFIG_NFCe
        {
            get { return new ConfiguracaoNfce(CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW.FRENTECAIXA\\App_Data\\Schemas" : "\\App_Data\\Schemas")); }
        }

        private static Controlador _Controller;
        public static Controlador CONTROLADOR
        {
            get
            {
                try
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
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
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
