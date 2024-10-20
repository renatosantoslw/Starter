using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesIntegracaoFiscal
    {

        public static bool Remover(decimal IDIntegracaoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTO,
IDUNIDADEDEMEDIDA,
IDORIGEMPRODUTO,
IDINTEGRACAOFISCALNFE,
IDINTEGRACAOFISCALNFCE,
IDMARCA,
IDNCM,
IDSUBCATEGORIA,
IDCATEGORIA,
CODIGO,
DESCRICAO,
EXTIPI,
EAN,
CEST,
VALORVENDA,
VALORCUSTO,
TRIB_MVA,
TRIB_REDBCICMS,
TRIB_REDBCICMSST,
TRIB_ALIQIPI,
TRIB_ALIQPIS,
TRIB_ALIQCOFINS,
TRIB_ALIQICMSDIF,
ATIVO,
IDALMOXARIFADOENTRADA,
IDALMOXARIFADOSAIDA,
SALDOESTOQUE,
VENDERSEMSALDO,
CHAVEERP,
VALORVENDAPRAZO,
ALTERARDESCRICAO,
ESTOQUEMINIMO,
ESTOQUEMAXIMO,
IMAGEMPRODUTO,
IMAGEMPRODUTOLINK,
TIPODEPRODUTO,
PARAVENDER FROM PRODUTO WHERE IDINTEGRACAOFISCALNFE = @IDINTEGRACAOFISCAL OR IDINTEGRACAOFISCALNFCE = @IDINTEGRACAOFISCAL";
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IDIntegracaoFiscal;
                oSQL.Open();

                if (!oSQL.IsEmpty)
                    throw new Exception("Integração Fiscal possui vínculo com Produto e não pode ser removida.");

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM INTEGRACAOFISCAL WHERE IDINTEGRACAOFISCAL = @IDINTEGRACAOFISCAL";
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IDIntegracaoFiscal;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(IntegracaoFiscal Integ, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO INTEGRACAOFISCAL (IDINTEGRACAOFISCAL, IDCFOP, IDTIPOOPERACAO, IDPORTARIA, IDCSTICMS, IDCSTPIS, IDCSTCOFINS, IDCSTIPI, 
                                                                   DESCRICAO, SEQUENCIA, ICMS, ICMS_IPI, ICMS_ST, ICMS_RED, ICMS_REDST, ICMS_DIFERENCIADO, ICMS_CDIFERENCIADO,
                                                                   ICMS_ST_CDIFERENCIADO, ICMS_ST_DIFERENCIADO, ESTOQUE, FINANCEIRO, ICMS_DIF, IPI, IDCFOPFORA, IDCFOPDEVOLUCAO, IDCFOPDEVOLUCAOFORA)
                                       VALUES (@IDINTEGRACAOFISCAL, @IDCFOP, @IDTIPOOPERACAO, @IDPORTARIA, @IDCSTICMS, @IDCSTPIS, @IDCSTCOFINS, @IDCSTIPI, 
                                               @DESCRICAO, @SEQUENCIA, @ICMS, @ICMS_IPI, @ICMS_ST, @ICMS_RED, @ICMS_REDST, @ICMS_DIFERENCIADO, @ICMS_CDIFERENCIADO,
                                               @ICMS_ST_CDIFERENCIADO, @ICMS_ST_DIFERENCIADO, @ESTOQUE, @FINANCEIRO, @ICMS_DIF, @IPI, @IDCFOPFORA, @IDCFOPDEVOLUCAO, @IDCFOPDEVOLUCAOFORA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE INTEGRACAOFISCAL
                                        SET IDCFOP = @IDCFOP, 
                                            IDTIPOOPERACAO = @IDTIPOOPERACAO,
                                            IDPORTARIA = @IDPORTARIA, 
                                            IDCSTICMS = @IDCSTICMS, 
                                            IDCSTPIS = @IDCSTPIS,
                                            IDCSTCOFINS = @IDCSTCOFINS,
                                            IDCSTIPI = @IDCSTIPI,
                                            DESCRICAO = @DESCRICAO, 
                                            SEQUENCIA = @SEQUENCIA, 
                                            ICMS = @ICMS, 
                                            ICMS_IPI = @ICMS_IPI,
                                            ICMS_ST = @ICMS_ST, 
                                            ICMS_RED = @ICMS_RED, 
                                            ICMS_REDST = @ICMS_REDST, 
                                            ICMS_DIFERENCIADO = @ICMS_DIFERENCIADO,
                                            ICMS_CDIFERENCIADO = @ICMS_CDIFERENCIADO,
                                            ICMS_ST_CDIFERENCIADO = @ICMS_ST_CDIFERENCIADO, 
                                            ICMS_ST_DIFERENCIADO = @ICMS_ST_DIFERENCIADO, 
                                            ESTOQUE = @ESTOQUE,
                                            FINANCEIRO = @FINANCEIRO,
                                            ICMS_DIF = @ICMS_DIF,
                                            IPI = @IPI,
                                            IDCFOPFORA = @IDCFOPFORA,
                                            IDCFOPDEVOLUCAO = @IDCFOPDEVOLUCAO,
                                            IDCFOPDEVOLUCAOFORA = @IDCFOPDEVOLUCAOFORA
                                        WHERE IDINTEGRACAOFISCAL = @IDINTEGRACAOFISCAL";
                        break;
                }
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = Integ.IDIntegracaoFiscal;
                oSQL.ParamByName["IDCFOP"] = Integ.IDCFOP;
                oSQL.ParamByName["IDTIPOOPERACAO"] = Integ.IDTipoOperacao;
                oSQL.ParamByName["IDPORTARIA"] = Integ.IDPortaria;
                oSQL.ParamByName["IDCSTICMS"] = Integ.IDCSTIcms;
                oSQL.ParamByName["IDCSTPIS"] = Integ.IDCSTPis;
                oSQL.ParamByName["IDCSTCOFINS"] = Integ.IDCSTCofins;
                oSQL.ParamByName["IDCSTIPI"] = Integ.IDCSTIpi;
                oSQL.ParamByName["DESCRICAO"] = Integ.Descricao;
                oSQL.ParamByName["SEQUENCIA"] = Integ.Sequencia;
                oSQL.ParamByName["ICMS"] = Integ.ICMS;
                oSQL.ParamByName["ICMS_IPI"] = Integ.ICMS_IPI;
                oSQL.ParamByName["ICMS_ST"] = Integ.ICMS_ST;
                oSQL.ParamByName["ICMS_RED"] = Integ.ICMS_RED;
                oSQL.ParamByName["ICMS_REDST"] = Integ.ICMS_REDST;
                oSQL.ParamByName["ICMS_DIFERENCIADO"] = Integ.ICMS_DIFERENCIADO;
                oSQL.ParamByName["ICMS_CDIFERENCIADO"] = Integ.ICMS_CDIFERENCIADO;
                oSQL.ParamByName["ICMS_ST_CDIFERENCIADO"] = Integ.ICMS_ST_CDIFERENCIADO;
                oSQL.ParamByName["ICMS_ST_DIFERENCIADO"] = Integ.ICMS_ST_DIFERENCIADO;
                oSQL.ParamByName["ESTOQUE"] = Integ.Estoque;
                oSQL.ParamByName["FINANCEIRO"] = Integ.Financeiro;
                oSQL.ParamByName["ICMS_DIF"] = Integ.ICMS_DIF;
                oSQL.ParamByName["IPI"] = Integ.IPI;
                oSQL.ParamByName["IDCFOPFORA"] = Integ.IDCFOPFORA;
                oSQL.ParamByName["IDCFOPDEVOLUCAO"] = Integ.IDCFOPDEVOLUCAO;
                oSQL.ParamByName["IDCFOPDEVOLUCAOFORA"] = Integ.IDCFOPDEVOLUCAOFORA;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetIntegracoes(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format("SELECT IDINTEGRACAOFISCAL, DESCRICAO FROM INTEGRACAOFISCAL WHERE UPPER(DESCRICAO) LIKE '%{0}%'", Descricao.ToUpper());
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static IntegracaoFiscal GetIntegracao(decimal IDIntegracaoFiscal)
        {
            if (IDIntegracaoFiscal == 0)
                return null;

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDINTEGRACAOFISCAL,
IDCFOP,
IDTIPOOPERACAO,
IDPORTARIA,
IDCSTICMS,
IDCSTIPI,
IDCSTPIS,
IDCSTCOFINS,
DESCRICAO,
SEQUENCIA,
ICMS,
ICMS_IPI,
ICMS_ST,
ICMS_RED,
ICMS_REDST,
ICMS_DIFERENCIADO,
ICMS_CDIFERENCIADO,
ICMS_ST_CDIFERENCIADO,
ICMS_ST_DIFERENCIADO,
ICMS_DIF,
ESTOQUE,
FINANCEIRO,
IPI,
IDCFOPFORA,
IDCFOPDEVOLUCAO,
IDCFOPDEVOLUCAOFORA
FROM INTEGRACAOFISCAL WHERE IDINTEGRACAOFISCAL = @IDINTEGRACAOFISCAL";
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IDIntegracaoFiscal;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<IntegracaoFiscal>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDIntegracaoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM INTEGRACAOFISCAL WHERE IDINTEGRACAOFISCAL = @IDINTEGRACAOFISCAL";
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IDIntegracaoFiscal;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<IntegracaoFiscal> GetIntegracoes()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDINTEGRACAOFISCAL,
IDCFOP,
IDTIPOOPERACAO,
IDPORTARIA,
IDCSTICMS,
IDCSTIPI,
IDCSTPIS,
IDCSTCOFINS,
DESCRICAO,
SEQUENCIA,
ICMS,
ICMS_IPI,
ICMS_ST,
ICMS_RED,
ICMS_REDST,
ICMS_DIFERENCIADO,
ICMS_CDIFERENCIADO,
ICMS_ST_CDIFERENCIADO,
ICMS_ST_DIFERENCIADO,
ICMS_DIF,
ESTOQUE,
FINANCEIRO,
IPI,
IDCFOPFORA,
IDCFOPDEVOLUCAO,
IDCFOPDEVOLUCAOFORA FROM INTEGRACAOFISCAL";
                oSQL.Open();
                return new DataTableParser<IntegracaoFiscal>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetInteracoesPorCFOP(decimal IDCFOP)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT INTEGRACAOFISCAL.IDINTEGRACAOFISCAL,
                                    INTEGRACAOFISCAL.IDCFOP,
                                    CFOP.CODIGO,
                                    INTEGRACAOFISCAL.SEQUENCIA,
                                    INTEGRACAOFISCAL.DESCRICAO
                               FROM INTEGRACAOFISCAL
                                 INNER JOIN CFOP ON (INTEGRACAOFISCAL.IDCFOP = CFOP.IDCFOP)
                             WHERE INTEGRACAOFISCAL.IDCFOP = @IDCFOP";
                oSQL.ParamByName["IDCFOP"] = IDCFOP;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
