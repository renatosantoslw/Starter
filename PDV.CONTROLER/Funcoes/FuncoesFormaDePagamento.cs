using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesFormaDePagamento
    {
        public static bool Existe(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORMADEPAGAMENTO WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool Existe(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM FORMADEPAGAMENTO WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static FormaDePagamento GetFormaDePagamentoPDV(decimal Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFORMADEPAGAMENTO,
                                    CODIGO,
                                    IDENTIFICACAO,
                                    IDBANDEIRACARTAO,
                                    DESCRICAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    FORMADEPAGAMENTO.TEF,*
                               FROM FORMADEPAGAMENTO 
                             WHERE Codigo = @IDFORMADEPAGAMENTO AND PDV = 1";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Codigo;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                {
                    return null;
                }
                var teste = EntityUtil<FormaDePagamento>.ParseDataRow(oSQL.dtDados.Rows[0]);
                return EntityUtil<FormaDePagamento>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static FormaDePagamento GetFormaDePagamento(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFORMADEPAGAMENTO,
                                    CODIGO,
                                    DESCRICAO,
                                    IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    FORMADEPAGAMENTO.TEF,*
                               FROM FORMADEPAGAMENTO 
                             WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                {
                    return null;
                }
                return EntityUtil<FormaDePagamento>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetFormasDePagamento(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                {
                    Filtros.Add(string.Format("UPPER(CAST(FORMADEPAGAMENTO.CODIGO AS VARCHAR)) LIKE UPPER('%{0}%'))", Codigo));
                }

                if (!string.IsNullOrEmpty(Descricao))
                {
                    Filtros.Add(string.Format("(UPPER(FORMADEPAGAMENTO.DESCRIiCAO) LIKE UPPER('%{0}%'))", Descricao));
                }

                oSQL.SQL = string.Format(
                           @"SELECT DISTINCT FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.CODIGO,
                                    FORMADEPAGAMENTO.DESCRICAO,
                                    BANDEIRACARTAO.DESCRICAO AS BANDEIRACARTAO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    BANDEIRACARTAO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.TEF,*
                               FROM FORMADEPAGAMENTO
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                             {0}
                             ORDER BY FORMADEPAGAMENTO.CODIGO, 
                                      FORMADEPAGAMENTO.IDENTIFICACAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static List<FormaDePagamento> GetFormasPagamentoPDV()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT FORMADEPAGAMENTO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.CODIGO,
                                    FORMADEPAGAMENTO.DESCRICAO,
                                    CASE WHEN FORMADEPAGAMENTO.IDBANDEIRACARTAO IS NULL
                                      THEN FORMADEPAGAMENTO.DESCRICAO ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ISNULL(BANDEIRACARTAO.DESCRICAO, '')
                                    END AS FORMADEPAGAMENTOBANDEIRA,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    FORMADEPAGAMENTO.FISCAL,
                                    FORMADEPAGAMENTO.Transacao,
                                    FORMADEPAGAMENTO.Usa_Calendario_Comercial,
                                    FORMADEPAGAMENTO.Qtd_Parcelas,
                                    FORMADEPAGAMENTO.Fator_Dup_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Dup_Sem_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Sem_Entrada
                               FROM FORMADEPAGAMENTO 
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                               WHERE FORMADEPAGAMENTO.ATIVO = 1 AND FORMADEPAGAMENTO.PDV = 1
                             ORDER BY FORMADEPAGAMENTO.CODIGO, FORMADEPAGAMENTO.IDENTIFICACAO";
                oSQL.Open();
                return new DataTableParser<FormaDePagamento>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static List<FormaDePagamento> GetFormasPagamentoForcaDeVenda()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT FORMADEPAGAMENTO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.CODIGO,
                                    FORMADEPAGAMENTO.DESCRICAO,
                                    CASE WHEN FORMADEPAGAMENTO.IDBANDEIRACARTAO IS NULL
                                      THEN FORMADEPAGAMENTO.DESCRICAO ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ISNULL(BANDEIRACARTAO.DESCRICAO, '')
                                    END AS FORMADEPAGAMENTOBANDEIRA,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    FORMADEPAGAMENTO.Transacao,
                                    FORMADEPAGAMENTO.Usa_Calendario_Comercial,
                                    FORMADEPAGAMENTO.Qtd_Parcelas,
                                    FORMADEPAGAMENTO.Fator_Dup_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Dup_Sem_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Sem_Entrada
                               FROM FORMADEPAGAMENTO 
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                               WHERE FORMADEPAGAMENTO.ATIVO = 1 -- SQLINES DEMO *** TO.PDV != 1
                             ORDER BY FORMADEPAGAMENTO.CODIGO, FORMADEPAGAMENTO.IDENTIFICACAO";
                oSQL.Open();
                return new DataTableParser<FormaDePagamento>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<FormaDePagamento> GetFormasPagamento()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT FORMADEPAGAMENTO.IDBANDEIRACARTAO,
                                    FORMADEPAGAMENTO.CODIGO,
                                    FORMADEPAGAMENTO.DESCRICAO,
                                    CASE WHEN FORMADEPAGAMENTO.IDBANDEIRACARTAO IS NULL
                                    THEN FORMADEPAGAMENTO.DESCRICAO ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ISNULL(BANDEIRACARTAO.DESCRICAO, '')
                                    END AS FORMADEPAGAMENTOBANDEIRA,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO,
                                    FORMADEPAGAMENTO.ATIVO,
                                    --FORMADEPAGAMENTO.FISCAL,
                                    FORMADEPAGAMENTO.Transacao,
                                    FORMADEPAGAMENTO.Usa_Calendario_Comercial,
                                    FORMADEPAGAMENTO.Qtd_Parcelas,
                                    FORMADEPAGAMENTO.Fator_Dup_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Dup_Sem_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Com_Entrada,
                                    FORMADEPAGAMENTO.Fator_Cheq_Sem_Entrada
                               FROM FORMADEPAGAMENTO 
                                 LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                               WHERE FORMADEPAGAMENTO.ATIVO = 1
                             ORDER BY FORMADEPAGAMENTO.CODIGO, FORMADEPAGAMENTO.IDENTIFICACAO";
                oSQL.Open();
                return new DataTableParser<FormaDePagamento>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(FormaDePagamento _FormaDePagamento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO FORMADEPAGAMENTO (IDFORMADEPAGAMENTO, CODIGO, DESCRICAO, IDBANDEIRACARTAO, IDENTIFICACAO, ATIVO, TEF,
                 Transacao,Usa_Calendario_Comercial,Qtd_Parcelas,dias_intervalo,Fator_Dup_Com_Entrada,Fator_Dup_Sem_Entrada,Fator_Cheq_Com_Entrada,Fator_Cheq_Sem_Entrada,Periodicidade,PDV,fiscal)

                                        VALUES (@IDFORMADEPAGAMENTO, @CODIGO, @DESCRICAO, @IDBANDEIRACARTAO, @IDENTIFICACAO, @ATIVO,@TEF,
                     @Transacao,@Usa_Calendario_Comercial,@Qtd_Parcelas,@dias_intervalo,@Fator_Dup_Com_Entrada,@Fator_Dup_Sem_Entrada,@Fator_Cheq_Com_Entrada,@Fator_Cheq_Sem_Entrada,@Periodicidade,@PDV,@FISCAL)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE FORMADEPAGAMENTO
                                      SET CODIGO = @CODIGO,
                                    DESCRICAO = @DESCRICAO,
                                    IDBANDEIRACARTAO = @IDBANDEIRACARTAO,
                                    IDENTIFICACAO = @IDENTIFICACAO,
                                    ATIVO = @ATIVO, TEF = @TEF, 
                                    Transacao = @Transacao,
                                    Usa_Calendario_Comercial = @Usa_Calendario_Comercial,
                                    Qtd_Parcelas = @Qtd_Parcelas,
                                    Fator_Dup_Com_Entrada = @Fator_Dup_Com_Entrada,
                                    Fator_Dup_Sem_Entrada =  @Fator_Dup_Sem_Entrada,
                                    Fator_Cheq_Com_Entrada = @Fator_Cheq_Com_Entrada,
                                    Fator_Cheq_Sem_Entrada = @Fator_Cheq_Sem_Entrada,
                                    dias_intervalo = @dias_intervalo, 
                                    Periodicidade = @Periodicidade, 
                                    PDV = @PDV,
                                    FISCAL=@FISCAL
                             WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                        break;
                }
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = _FormaDePagamento.IDFormaDePagamento;
                oSQL.ParamByName["CODIGO"] = _FormaDePagamento.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _FormaDePagamento.Descricao;
                oSQL.ParamByName["IDBANDEIRACARTAO"] = _FormaDePagamento.IDBandeiraCartao;
                oSQL.ParamByName["IDENTIFICACAO"] = _FormaDePagamento.Identificacao;
                oSQL.ParamByName["ATIVO"] = _FormaDePagamento.Ativo;
                oSQL.ParamByName["TEF"] = _FormaDePagamento.TEF;
                oSQL.ParamByName["PDV"] = _FormaDePagamento.PDV;
                oSQL.ParamByName["FISCAL"] = _FormaDePagamento.FISCAL;
                oSQL.ParamByName["Transacao"] = _FormaDePagamento.Transacao;
                oSQL.ParamByName["Usa_Calendario_Comercial"] = _FormaDePagamento.Usa_Calendario_Comercial;
                oSQL.ParamByName["Qtd_Parcelas"] = _FormaDePagamento.Qtd_Parcelas;
                oSQL.ParamByName["Fator_Dup_Com_Entrada"] = _FormaDePagamento.Fator_Dup_Com_Entrada;
                oSQL.ParamByName["Fator_Dup_Sem_Entrada"] = _FormaDePagamento.Fator_Dup_Sem_Entrada;
                oSQL.ParamByName["Fator_Cheq_Com_Entrada"] = _FormaDePagamento.Fator_Cheq_Com_Entrada;
                oSQL.ParamByName["Fator_Cheq_Sem_Entrada"] = _FormaDePagamento.Fator_Cheq_Sem_Entrada;
                oSQL.ParamByName["dias_intervalo"] = _FormaDePagamento.Dias_Intervalo;
                oSQL.ParamByName["Periodicidade"] = _FormaDePagamento.Periodicidade;

                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM FORMADEPAGAMENTO WHERE IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

    }
}
