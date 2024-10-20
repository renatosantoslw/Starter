using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPerfilAcesso
    {
        public static bool RemoverPerfilAcessoItemMenu(decimal IDPerfilAcesso, decimal IDItemMenu)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool SalvarPerfilAcessoItemMenu(decimal IDPerfilAcessoItemMenu, decimal IDPerfilAcesso, decimal IDItemMenu)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = @"INSERT INTO PERFILACESSOITEMMENU (IDPERFILACESSOITEMMENU, IDPERFILACESSO, IDITEMMENU)
                               VALUES (@IDPERFILACESSOITEMMENU, @IDPERFILACESSO, @IDITEMMENU)";
                oSQL.ParamByName["IDPERFILACESSOITEMMENU"] = IDPerfilAcessoItemMenu;
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = IDItemMenu;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetItensMenuPorPerfil(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMMENU.DESCRICAO,
                                    PERFILACESSOITEMMENU.IDPERFILACESSOITEMMENU, 
                                    ITEMMENU.IDITEMMENU,
                                    ITEMMENU.IDITEMMENUSUPERIOR
                               FROM ITEMMENU
                              INNER JOIN PERFILACESSOITEMMENU ON (ITEMMENU.IDITEMMENU = PERFILACESSOITEMMENU.IDITEMMENU)
                             WHERE PERFILACESSOITEMMENU.IDPERFILACESSO = @IDPERFILACESSO
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ItemMenu> GetItensMenuPorPerfilAcesso(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMMENU.IDITEMMENU,
                                    ITEMSUPERIOR.DESCRICAO AS ITEMSUPERIOR,
                                    ITEMMENU.DESCRICAO                                    
                               FROM ITEMMENU
                                 INNER JOIN PERFILACESSOITEMMENU ON (ITEMMENU.IDITEMMENU = PERFILACESSOITEMMENU.IDITEMMENU)
                                  LEFT JOIN ITEMMENU ITEMSUPERIOR ON (ITEMMENU.IDITEMMENUSUPERIOR = ITEMSUPERIOR.IDITEMMENU)
                               
                             WHERE PERFILACESSOITEMMENU.IDPERFILACESSO = @IDPERFILACESSO
                             ORDER BY ITEMSUPERIOR.DESCRICAO, ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return new DataTableParser<ItemMenu>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(PerfilAcesso Perfil, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO PERFILACESSO (IDPERFILACESSO, DESCRICAO, ATIVO, ISADMIN) VALUES (@IDPERFILACESSO, @DESCRICAO, @ATIVO, @ISADMIN)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PERFILACESSO
                                       SET DESCRICAO = @DESCRICAO,
                                           ATIVO = @ATIVO,
                                           ISADMIN = @ISADMIN
                                     WHERE IDPERFILACESSO = @IDPERFILACESSO";
                        break;
                }
                oSQL.ParamByName["IDPERFILACESSO"] = Perfil.IDPerfilAcesso;
                oSQL.ParamByName["DESCRICAO"] = Perfil.Descricao;
                oSQL.ParamByName["ATIVO"] = Perfil.Ativo;
                oSQL.ParamByName["ISADMIN"] = Perfil.IsAdmin;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM USUARIO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Perfil de Acesso tem vinculo com usuário e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.ExecSQL();

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM PERFILACESSO  WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERFILACESSO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<PerfilAcesso> GetPerfisAcesso_CadastroUsuario()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPERFILACESSO, DESCRICAO, ATIVO, ISADMIN FROM PERFILACESSO ORDER BY DESCRICAO";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return new DataTableParser<PerfilAcesso>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static PerfilAcesso GetPerfil(decimal IDPerfilAcesso)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPERFILACESSO, DESCRICAO, ATIVO, ISADMIN FROM PERFILACESSO WHERE IDPERFILACESSO = @IDPERFILACESSO";
                oSQL.ParamByName["IDPERFILACESSO"] = IDPerfilAcesso;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<PerfilAcesso>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static PerfilAcesso GetPerfil(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT TOP 1 IDPERFILACESSO, DESCRICAO, ATIVO, ISADMIN FROM PERFILACESSO WHERE DESCRICAO = @DESCRICAO /*LIMIT 1*/";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<PerfilAcesso>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetPerfisAcesso(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));


                oSQL.SQL = string.Format(@"SELECT IDPERFILACESSO, 
                                                  DESCRICAO,
                                                  ATIVO
                                             FROM PERFILACESSO {0}
                                           ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        
        public static DataTable GetModulos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT ITEMMENU.DESCRICAO,
                                    ITEMMENU.IDITEMMENU
                               FROM ITEMMENU
                                WHERE IDITEMMENUSUPERIOR IS NULL
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetItensPorItemMenuSuperior(decimal IDItemMenuSuperior)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT ITEMMENU.DESCRICAO,
                                    ITEMMENU.IDITEMMENU
                               FROM ITEMMENU
                                WHERE IDITEMMENUSUPERIOR = @IDITEMMENUSUPERIOR
                             ORDER BY ITEMMENU.DESCRICAO";
                oSQL.ParamByName["IDITEMMENUSUPERIOR"] = IDItemMenuSuperior;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool ISEstoqueLiberado()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ITEMMENU WHERE IDITEMMENU = 4";
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool PermitirAcesso(decimal idPerfilAcesso, decimal idItemMenu)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PERFILACESSOITEMMENU WHERE IDPERFILACESSO = @IDPERFILACESSO AND IDITEMMENU = @IDITEMMENU";
                oSQL.ParamByName["IDPERFILACESSO"] = idPerfilAcesso;
                oSQL.ParamByName["IDITEMMENU"] = idItemMenu;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}
