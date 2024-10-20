
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCondutor
    {
        public static bool Salvar(Condutor Cond, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONDUTOR
                                        (IDCONDUTOR, CPF, NOME, ATIVO, IDUNIDADEFEDERATIVA)
                                     VALUES
                                        (@IDCONDUTOR, @CPF, @NOME, @ATIVO, @IDUNIDADEFEDERATIVA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONDUTOR
                                      SET CPF = @CPF,
                                          NOME = @NOME,
                                    	  ATIVO = @ATIVO,
                                    	  IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA
                                    WHERE IDCONDUTOR = @IDCONDUTOR";
                        break;
                }
                oSQL.ParamByName["IDCONDUTOR"] = Cond.IDCondutor;
                oSQL.ParamByName["CPF"] = Cond.CPF;
                oSQL.ParamByName["NOME"] = Cond.Nome;
                oSQL.ParamByName["ATIVO"] = Cond.Ativo;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = Cond.IDUnidadeFederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCondutor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONDUTOR WHERE IDCONDUTOR = @IDCONDUTOR";
                oSQL.ParamByName["IDCONDUTOR"] = IDCondutor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDCondutor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONDUTOR WHERE IDCONDUTOR = @IDCONDUTOR";
                oSQL.ParamByName["IDCONDUTOR"] = IDCondutor;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Condutor GetCondutor(decimal IDCondutor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONDUTOR,
CPF,
NOME,
ATIVO,
IDUNIDADEFEDERATIVA FROM CONDUTOR WHERE IDCONDUTOR = @IDCONDUTOR";
                oSQL.ParamByName["IDCONDUTOR"] = IDCondutor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Condutor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetCondutores(string CPF, string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONDUTOR.IDCONDUTOR,
                                     CONDUTOR.CPF,
                                     CONDUTOR.NOME,
                                     UNIDADEFEDERATIVA.SIGLA AS UNIDADEFEDERATIVA,
                                     CONDUTOR.ATIVO
                                FROM CONDUTOR
                                  INNER JOIN UNIDADEFEDERATIVA ON (CONDUTOR.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                              WHERE UPPER(CONDUTOR.CPF) LIKE UPPER('%{CPF}%')
                                AND UPPER(CONDUTOR.NOME) LIKE UPPER('%{Nome}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetCondutoresPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT CONDUTOR.CPF,
                                    CONDUTOR.NOME,                                    
                                    UNIDADEFEDERATIVA.SIGLA,

                                    VEICULOTRACAOMDFE.IDVEICULOTRACAOMDFE,
                                    VEICULOTRACAOMDFE.IDCONDUTOR,
                                    VEICULOTRACAOMDFE.IDVEICULO,
                                    VEICULOTRACAOMDFE.IDMDFE,
                                    VEICULOTRACAOMDFE.IDPROPRIETARIOVEICULOMDFE,
                                    CONDUTOR.IDUNIDADEFEDERATIVA
                               FROM CONDUTOR
                                 INNER JOIN UNIDADEFEDERATIVA ON (CONDUTOR.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                                 INNER JOIN VEICULOTRACAOMDFE ON (CONDUTOR.IDCONDUTOR = VEICULOTRACAOMDFE.IDCONDUTOR)
                             WHERE VEICULOTRACAOMDFE.IDMDFE = @IDMDFE
                             ORDER BY CONDUTOR.NOME";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Condutor> GetCondutoresAtivos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONDUTOR,
CPF,
NOME,
ATIVO,
IDUNIDADEFEDERATIVA FROM CONDUTOR WHERE COALESCE(ATIVO, 0) = 1";
                oSQL.Open();
                return new DataTableParser<Condutor>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
