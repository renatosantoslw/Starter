using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTabela
    {
        public static Tabela GetTabela(decimal ID)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ID,
                                    NOME,GRUPO
                              FROM TABELA
                                WHERE ID = @ID";
                oSQL.ParamByName["ID"] = ID;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Tabela>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static List<Tabela> GetTabelas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ID,
                                    NOME,GRUPO
                              FROM TABELA ORDER BY GRUPO";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return new DataTableParser<Tabela>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(Tabela _Tabela, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                      TABELA (ID,NOME,GRUPO)
                                      VALUES (@ID,@NOME,@GRUPO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE TABELA
                                       SET ID = @ID,
                                           NOME = @NOME, GRUPO = @GRUPO
                                       WHERE ID = @ID";
                        break;
                }
                oSQL.ParamByName["ID"] = _Tabela.ID;
                oSQL.ParamByName["NOME"] = _Tabela.Nome;
                oSQL.ParamByName["GRUPO"] = _Tabela.Grupo;

                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool Excluir(decimal ID)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM TABELA WHERE ID = @ID";
                oSQL.ParamByName["ID"] = ID;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
