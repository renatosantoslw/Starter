using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesFornecedor
    {
        public static bool ExisteFornecedor(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Fornecedor GetFornecedor(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFORNECEDOR,
RAZAOSOCIAL,
CNPJ,
INSCRICAOESTADUAL,
ISENTO,
EMAIL,
IDENDERECO FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Fornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Fornecedor GetFornecedorPorCNPJ(string CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFORNECEDOR,
RAZAOSOCIAL,
CNPJ,
INSCRICAOESTADUAL,
ISENTO,
EMAIL,
IDENDERECO FROM FORNECEDOR WHERE CNPJ = @CNPJ";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Fornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetFornecedores(string Nome_RazaoSocial, string CPF_CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UPPER(RAZAOSOCIAL) LIKE UPPER('%{0}%') OR UPPER(NOME) LIKE UPPER('%{0}%'))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CNPJ LIKE UPPER('%{0}%') OR CPF LIKE UPPER('%{0}%'))", CPF_CNPJ));

                oSQL.SQL = string.Format(@"SELECT FORNECEDOR.IDFORNECEDOR,
                                                  CNPJ,
                                                  RAZAOSOCIAL
                                           FROM FORNECEDOR {0}
                                              ORDER BY RAZAOSOCIAL, CNPJ", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Fornecedor> GetFornecedores()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT FORNECEDOR.IDFORNECEDOR,
                                    CNPJ,
                                    RAZAOSOCIAL,
                                    CNPJ+' - '+RAZAOSOCIAL AS DESCRICAO
                             FROM FORNECEDOR
                                ORDER BY RAZAOSOCIAL, CNPJ";
                oSQL.Open();
                return EntityUtil<Fornecedor>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(Fornecedor _Fornecedor, TipoOperacao _Operacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (_Operacao)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO FORNECEDOR
                                       (IDFORNECEDOR, RAZAOSOCIAL, CNPJ, INSCRICAOESTADUAL, ISENTO, EMAIL, IDENDERECO)
                                     VALUES
                                       (@IDFORNECEDOR, @RAZAOSOCIAL, @CNPJ, @INSCRICAOESTADUAL, @ISENTO, @EMAIL, @IDENDERECO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE FORNECEDOR
                                       SET RAZAOSOCIAL = @RAZAOSOCIAL, 
                                           CNPJ = @CNPJ,
                                           INSCRICAOESTADUAL = @INSCRICAOESTADUAL,
                                           ISENTO = @ISENTO,
                                           EMAIL = @EMAIL,
                                           IDENDERECO = @IDENDERECO
                                     WHERE IDFORNECEDOR = @IDFORNECEDOR";
                        break;
                }
                oSQL.ParamByName["IDFORNECEDOR"] = _Fornecedor.IDFornecedor;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Fornecedor.RazaoSocial;
                oSQL.ParamByName["CNPJ"] = _Fornecedor.CNPJ;
                oSQL.ParamByName["INSCRICAOESTADUAL"] = _Fornecedor.InscricaoEstadual;
                oSQL.ParamByName["ISENTO"] = _Fornecedor.Isento;
                oSQL.ParamByName["EMAIL"] = _Fornecedor.Email;
                oSQL.ParamByName["IDENDERECO"] = _Fornecedor.IDEndereco;
                var salvou = oSQL.ExecSQL() == 1;
                return salvou;
            }
        }

        public static bool Remover(decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE IDFORNECEDOR = @IDFORNECEDOR";
                //oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                //oSQL.Open();
                //if (!oSQL.IsEmpty)
                //    throw new Exception("Não é possível remover o Fornecedor, existe vinculo com Produto.");

                //oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                bool vbRemoveFornecedor = oSQL.ExecSQL() == 1;

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM ENDERECO WHERE IDENDERECO IN (SELECT COALESCE(IDENDERECO, -1) FROM FORNECEDOR WHERE IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.ExecSQL();

                return vbRemoveFornecedor;
            }
        }
    }
}
