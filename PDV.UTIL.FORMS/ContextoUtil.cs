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

namespace PDV.UTIL.FORMS
{
    public class ContextoUtil
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

        public static int IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE { get { return -2222; } }

        public static CFG_PDV CONFIGURACAO_SERIE { get { return CONTROLADOR.GetConfiguracaoPDV(); } }

        public static string CaminhoSolution
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached ?
                    Path.GetFullPath(".").Substring(0, Path.GetFullPath(".").IndexOf("PDV.VIEW")) :
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static string CaminhoSchemasMDFe
        {
            get { return CaminhoSolution + (System.Diagnostics.Debugger.IsAttached ? "\\PDV.VIEW\\App_Data\\SchemasMDFe" : "\\App_Data\\SchemasMDFe"); }
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
                        controlador.Inicializa(CaminhoSolution + "\\PDV.VIEW\\App_Data\\Start.ini");
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

                    /* Conexão das Threads */
                    controlador.AdicionaConexao_ArquivoConfiguracao(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE, "Conexao_PDV");
                    controlador.Conectar(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE);
                    if (!controlador.ConexaoEstaAtiva(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE))
                    {
                        System.Threading.Thread.Sleep(5000);
                        if (!controlador.ConexaoEstaAtiva(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE))
                        {
                            controlador.DesconectarConexao(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE);
                            throw new Exception("Não foi possível iniciar a conexão primária com o banco de dados.");
                        }
                    }
                    controlador.DesconectarConexao(IDCONEXAO_SECUNDARIA_THREAD_NFE_NFCE);

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
