using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesHistoricoFinanceiro
    { 
        public static bool Existe(decimal IDHistoricoFinanceiro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM HISTORICOFINANCEIRO WHERE IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO";
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = IDHistoricoFinanceiro;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static HistoricoFinanceiro GetHistoricoFinanceiro(decimal IDHistoricoFinanceiro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT HISTORICOFINANCEIRO.*
                               FROM HISTORICOFINANCEIRO
                             WHERE IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO";
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = IDHistoricoFinanceiro;
                oSQL.Open();
                return EntityUtil<HistoricoFinanceiro>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetHistoricosFinanceiros(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT IDHISTORICOFINANCEIRO,
                                    DESCRICAO
                               FROM HISTORICOFINANCEIRO {0}
                             ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<HistoricoFinanceiro> GetHistoricosFinanceiros(int movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDHISTORICOFINANCEIRO,
DESCRICAO,
TIPODEMOVIMENTO FROM HISTORICOFINANCEIRO WHERE TIPODEMOVIMENTO = @TIPODEMOVIMENTO";
                oSQL.ParamByName["TIPODEMOVIMENTO"] = movimento;
                oSQL.Open();
                return new DataTableParser<HistoricoFinanceiro>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<HistoricoFinanceiro> GetHistoricosFinanceiros()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDHISTORICOFINANCEIRO,
                                    DESCRICAO
                               FROM HISTORICOFINANCEIRO
                             ORDER BY DESCRICAO";
                oSQL.Open();
                return new DataTableParser<HistoricoFinanceiro>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(HistoricoFinanceiro historico, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO HISTORICOFINANCEIRO (IDHISTORICOFINANCEIRO, DESCRICAO, TIPODEMOVIMENTO)
                                    VALUES (@IDHISTORICOFINANCEIRO, @DESCRICAO, @TIPODEMOVIMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE HISTORICOFINANCEIRO
                                      SET DESCRICAO = @DESCRICAO, TIPODEMOVIMENTO = @TIPODEMOVIMENTO
                                     WHERE IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO";
                        break;
                }
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = historico.IDHistoricoFinanceiro;
                oSQL.ParamByName["DESCRICAO"] = historico.Descricao;
                oSQL.ParamByName["TIPODEMOVIMENTO"] = historico.TipoDeMovimento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDHistoricoFinanceiro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //VERIFICAR EM CTASPAGAR E CTASRECEBER
                //oSQL.SQL = "SELECT 1 FROM HISTORICOFINANCEIRO WHERE IDMARCA = @IDMARCA";
                //oSQL.ParamByName["IDCFOP"] = IDHistoricoFinanceiro;
                //oSQL.Open();
                //if (!oSQL.IsEmpty)
                //    throw new Exception("A Marca tem vínculo com produto e não pode ser removido.");

                oSQL.SQL = @"DELETE FROM HISTORICOFINANCEIRO WHERE IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO";
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = IDHistoricoFinanceiro;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static HistoricoFinanceiro GetDefault()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDHISTORICOFINANCEIRO,
DESCRICAO,
TIPODEMOVIMENTO FROM HISTORICOFINANCEIRO WHERE IDHISTORICOFINANCEIRO = 7";
                oSQL.Open();
                return new DataTableParser<HistoricoFinanceiro>().ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
