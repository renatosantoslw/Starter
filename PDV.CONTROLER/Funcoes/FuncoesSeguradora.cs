using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesSeguradora
    {
        public static bool Salvar(Seguradora Seg, TipoOperacao Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Tipo)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO SEGURADORA 
                                       (IDSEGURADORA, DESCRICAO, CNPJ, ATIVO)
                                     VALUES 
                                       (@IDSEGURADORA, @DESCRICAO, @CNPJ, @ATIVO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE SEGURADORA
                                        SET DESCRICAO = @DESCRICAO,
                                            CNPJ = @CNPJ,
                                            ATIVO = @ATIVO
                                        WHERE IDSEGURADORA = @IDSEGURADORA";
                        break;
                }
                oSQL.ParamByName["IDSEGURADORA"] = Seg.IDSeguradora;
                oSQL.ParamByName["DESCRICAO"] = Seg.Descricao;
                oSQL.ParamByName["CNPJ"] = Seg.CNPJ;
                oSQL.ParamByName["ATIVO"] = Seg.Ativo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDSeguradora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM SEGURADORA WHERE IDSEGURADORA = @IDSEGURADORA";
                oSQL.ParamByName["IDSEGURADORA"] = IDSeguradora;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDSeguradora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM SEGURADORA WHERE IDSEGURADORA = @IDSEGURADORA";
                oSQL.ParamByName["IDSEGURADORA"] = IDSeguradora;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Seguradora GetSeguradora(decimal IDSeguradora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSEGURADORA,
DESCRICAO,
CNPJ,
ATIVO FROM SEGURADORA WHERE IDSEGURADORA = @IDSEGURADORA";
                oSQL.ParamByName["IDSEGURADORA"] = IDSeguradora;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Seguradora>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetSeguradoras(string CNPJ, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT IDSEGURADORA,
                                     CNPJ,
                                     DESCRICAO, 
                                     ATIVO
                             FROM SEGURADORA
                               WHERE UPPER(CNPJ) LIKE UPPER('%{CNPJ}%')
                                 AND UPPER(DESCRICAO) LIKE UPPER('%{Descricao}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Seguradora> GetSeguradorasAtivas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT IDSEGURADORA,
                                     CNPJ,
                                     DESCRICAO, 
                                     ATIVO
                             FROM SEGURADORA
                               WHERE COALESCE(ATIVO, 0) = 1";
                oSQL.Open();
                return new DataTableParser<Seguradora>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}