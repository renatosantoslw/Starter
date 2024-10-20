using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesNatureza
    {
        public static bool Salvar(Natureza Nat, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO NATUREZA(IDNATUREZA, CONTA, DESCRICAO, APLICACAO, TIPO, IDNATUREZASUPERIOR)
                                      VALUES (@IDNATUREZA, @CONTA, @DESCRICAO, @APLICACAO, @TIPO, @IDNATUREZASUPERIOR)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE NATUREZA
                                       SET CONTA = @CONTA, 
                                           DESCRICAO = @DESCRICAO,
                                           APLICACAO = @APLICACAO,
                                           TIPO = @TIPO,
                                           IDNATUREZASUPERIOR = @IDNATUREZASUPERIOR
                                     WHERE IDNATUREZA=@IDNATUREZA";
                        break;
                }
                oSQL.ParamByName["IDNATUREZA"] = Nat.IDNatureza;
                oSQL.ParamByName["CONTA"] = Nat.Conta;
                oSQL.ParamByName["DESCRICAO"] = Nat.Descricao;
                oSQL.ParamByName["APLICACAO"] = Nat.Aplicacao;
                oSQL.ParamByName["TIPO"] = Nat.Tipo;
                oSQL.ParamByName["IDNATUREZASUPERIOR"] = Nat.IDNaturezaSuperior;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDNatureza)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM CLASSIFICACAOCONTARECEBER WHERE IDNATUREZA = @IDNATUREZA
                               UNION 
                             SELECT 1 FROM CLASSIFICACAOCONTAPAGAR WHERE IDNATUREZA = @IDNATUREZA";
                oSQL.ParamByName["IDNATUREZA"] = IDNatureza;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new System.Exception("A Natureza tem vínculo com Classificação e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = "SELECT 1 FROM NATUREZA WHERE IDNATUREZASUPERIOR = @IDNATUREZASUPERIOR";
                oSQL.ParamByName["IDNATUREZASUPERIOR"] = IDNatureza;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new System.Exception("A Natureza tem vínculo com Natureza Superior e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM NATUREZA WHERE IDNATUREZA = @IDNATUREZA";
                oSQL.ParamByName["IDNATUREZA"] = IDNatureza;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetNaturezas(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(NATUREZA.DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT NATUREZA.IDNATUREZA,
                                    NATUREZA.DESCRICAO,
                                    CASE 
                                       WHEN NATUREZA.TIPO = 0 THEN 'Receita'
                                       WHEN NATUREZA.TIPO = 1 THEN 'Despesa'
                                    END AS TIPODESC,
                                    NATUREZASUPERIOR.DESCRICAO AS NATUREZASUPERIOR
                               FROM NATUREZA
                                LEFT JOIN NATUREZA NATUREZASUPERIOR ON (NATUREZA.IDNATUREZASUPERIOR = NATUREZASUPERIOR.IDNATUREZA)
                               {0}
                             ORDER BY NATUREZA.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Natureza> GetNaturezas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNATUREZA,
CONTA,
DESCRICAO,
APLICACAO,
TIPO,
IDNATUREZASUPERIOR FROM NATUREZA ORDER BY DESCRICAO";
                oSQL.Open();
                return EntityUtil<Natureza>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Natureza> GetNaturezasPorTipo(decimal Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNATUREZA,
CONTA,
DESCRICAO,
APLICACAO,
TIPO,
IDNATUREZASUPERIOR FROM NATUREZA WHERE TIPO = @TIPO ORDER BY DESCRICAO";
                oSQL.ParamByName["TIPO"] = Tipo;
                oSQL.Open();
                return EntityUtil<Natureza>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Natureza> GetNaturezas(decimal IDNatureza)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNATUREZA,
CONTA,
DESCRICAO,
APLICACAO,
TIPO,
IDNATUREZASUPERIOR FROM NATUREZA WHERE IDNATUREZA <> @IDNATUREZA ORDER BY DESCRICAO";
                oSQL.ParamByName["IDNATUREZA "] = IDNatureza;
                oSQL.Open();
                return EntityUtil<Natureza>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static Natureza GetNatureza(decimal IDNatureza)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNATUREZA,
CONTA,
DESCRICAO,
APLICACAO,
TIPO,
IDNATUREZASUPERIOR FROM NATUREZA WHERE IDNATUREZA = @IDNATUREZA";
                oSQL.ParamByName["IDNATUREZA"] = IDNatureza;
                oSQL.Open();
                return EntityUtil<Natureza>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDNatureza)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNATUREZA,
CONTA,
DESCRICAO,
APLICACAO,
TIPO,
IDNATUREZASUPERIOR FROM NATUREZA WHERE IDNATUREZA = @IDNATUREZA";
                oSQL.ParamByName["IDNATUREZA"] = IDNatureza;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
    }
}
