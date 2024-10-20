using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTransportadora
    {
        public static bool ExisteTransportadora(decimal IDTransportadora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM TRANSPORTADORA WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                oSQL.ParamByName["IDTRANSPORTADORA"] = IDTransportadora;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Transportadora GetTransportadora(decimal IDTransportadora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTRANSPORTADORA,
                                    RAZAOSOCIAL,
                                    CNPJ,
                                    CPF,
                                    NOME,
                                    INSCRICAOESTADUAL,
                                    ISENTO,
                                    IDENDERECO,
                                    TIPODOCUMENTO
                             FROM TRANSPORTADORA
                               WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                oSQL.ParamByName["IDTRANSPORTADORA"] = IDTransportadora;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Transportadora>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Transportadora GetTransportadoraPorCNPJ(string CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTRANSPORTADORA,
                                    RAZAOSOCIAL,
                                    CNPJ,
                                    CPF,
                                    NOME,
                                    INSCRICAOESTADUAL,
                                    ISENTO,
                                    IDENDERECO,
                                    TIPODOCUMENTO
                             FROM TRANSPORTADORA
                               WHERE CNPJ = @CNPJ";  // WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Transportadora>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetTransportadoras(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UPPER(RAZAOSOCIAL) LIKE UPPER('%{0}%') OR UPPER(NOME) LIKE UPPER('%{0}%'))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CNPJ LIKE UPPER('%{0}%') OR CPF LIKE UPPER('%{0}%'))", CPF_CNPJ));

                if (!string.IsNullOrEmpty(InscricaoEstadual))
                    Filtros.Add(string.Format("(INSCRICAOESTADUAL::VARCHAR LIKE '%{0}%')", InscricaoEstadual));

                oSQL.SQL = string.Format(@"SELECT TRANSPORTADORA.IDTRANSPORTADORA,
                                                  CASE WHEN TIPODOCUMENTO = 0 THEN RAZAOSOCIAL ELSE NOME END AS NOME,
                                                  CASE WHEN TIPODOCUMENTO = 0 THEN CNPJ ELSE CPF END AS NUMERODOCUMENTO
                                           FROM TRANSPORTADORA {0}
                                              ORDER BY RAZAOSOCIAL, NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetTransportadoras(string Nome_RazaoSocial)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UPPER(RAZAOSOCIAL) LIKE UPPER('%{0}%') OR UPPER(NOME) LIKE UPPER('%{0}%'))", Nome_RazaoSocial));

                oSQL.SQL = string.Format(@"SELECT TRANSPORTADORA.IDTRANSPORTADORA,
                                                  CASE WHEN TIPODOCUMENTO = 0 THEN RAZAOSOCIAL ELSE NOME END AS NOME,
                                                  CASE WHEN TIPODOCUMENTO = 0 THEN CNPJ ELSE CPF END AS NUMERODOCUMENTO,
                                                  TRANSPORTADORA.IDENDERECO
                                           FROM TRANSPORTADORA {0}
                                              ORDER BY RAZAOSOCIAL, NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Transportadora _Transportadora, TipoOperacao _Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (_Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO TRANSPORTADORA
                                       (IDTRANSPORTADORA, RAZAOSOCIAL, CNPJ, CPF, NOME, INSCRICAOESTADUAL, ISENTO, IDENDERECO, TIPODOCUMENTO)
                                     VALUES
                                       (@IDTRANSPORTADORA, @RAZAOSOCIAL, @CNPJ, @CPF, @NOME, @INSCRICAOESTADUAL, @ISENTO, @IDENDERECO, @TIPODOCUMENTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE TRANSPORTADORA
                                       SET RAZAOSOCIAL = @RAZAOSOCIAL, 
                                           CNPJ = @CNPJ,
                                           CPF = @CPF,
                                           NOME = @NOME,
                                           INSCRICAOESTADUAL = @INSCRICAOESTADUAL,
                                           ISENTO = @ISENTO,
                                           IDENDERECO = @IDENDERECO,
                                           TIPODOCUMENTO = @TIPODOCUMENTO
                                     WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                        break;
                }
                oSQL.ParamByName["IDTRANSPORTADORA"] = _Transportadora.IDTransportadora;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Transportadora.RazaoSocial;
                oSQL.ParamByName["CNPJ"] = _Transportadora.CNPJ;
                oSQL.ParamByName["CPF"] = _Transportadora.CPF;
                oSQL.ParamByName["NOME"] = _Transportadora.Nome;

                oSQL.ParamByName["INSCRICAOESTADUAL"] = DBNull.Value;
                if (_Transportadora.InscricaoEstadual.HasValue)
                    oSQL.ParamByName["INSCRICAOESTADUAL"] = _Transportadora.InscricaoEstadual;

                oSQL.ParamByName["ISENTO"] = _Transportadora.Isento;
                oSQL.ParamByName["IDENDERECO"] = _Transportadora.IDEndereco;
                oSQL.ParamByName["TIPODOCUMENTO"] = _Transportadora.TipoDocumento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDTransportadora)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDENDERECO FROM TRANSPORTADORA WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                oSQL.ParamByName["IDTRANSPORTADORA"] = IDTransportadora;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                {
                    decimal IDEndereco = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDENDERECO"]);
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                    oSQL.ParamByName["IDENDERECO"] = IDEndereco;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }
                oSQL.SQL = "DELETE FROM TRANSPORTADORA WHERE IDTRANSPORTADORA = @IDTRANSPORTADORA";
                oSQL.ParamByName["IDTRANSPORTADORA"] = IDTransportadora;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<Transportadora> GetTransportadoras()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTRANSPORTADORA,
                                    COALESCE(CPF, CNPJ) AS DOCUMENTO,
                                    COALESCE(NOME, RAZAOSOCIAL) AS NOME,
                                    COALESCE(CPF, CNPJ)+' - '+COALESCE(NOME, RAZAOSOCIAL) AS DESCRICAOTRANSPORTADORA
                               FROM TRANSPORTADORA";
                oSQL.Open();
                return new DataTableParser<Transportadora>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
