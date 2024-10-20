using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;


namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCaixa
    {

        public static bool Existe(decimal IDCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CAIXA WHERE IDCAIXA = @IDCAIXA";
                oSQL.ParamByName["IDCAIXA"] = IDCaixa;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static Caixa GetCaixa(decimal CaixaID)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCAIXA,
                                NUMEROCAIXA,
                                SERIALPOS,
                                NOMEPOS,
                                ATIVO,
                                TIPODEVENDA,
                                TIPOPDV,
                                MOSTRAR_RELATORIO_CAIXA
                               FROM CAIXA 
                WHERE IDCAIXA = @IDCAIXA";
                oSQL.ParamByName["IDCAIXA"] = CaixaID;
                oSQL.Open();
                
                try
                {
                    return EntityUtil<Caixa>.ParseDataRow(oSQL.dtDados.Rows[0]);
                }
                catch (System.IndexOutOfRangeException)
                {
                    return null;
                }
            }
        }
        public static DataTable GetTodosCaixas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCAIXA,
NUMEROCAIXA,
SERIALPOS,
NOMEPOS,
ATIVO,
TIPODEVENDA,
TIPOPDV
                             FROM CAIXA ";
                oSQL.Open();

                return oSQL.dtDados;
            }
        }
        public static DataTable GetTodosCaixasAtivo()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCAIXA,
NUMEROCAIXA,
SERIALPOS,
NOMEPOS,
ATIVO,
TIPODEVENDA,
TIPOPDV
                            FROM CAIXA WHERE ATIVO = 1 and IDCAIXA NOT IN (SELECT CAIXAID FROM FLUXOCAIXA WHERE ABERTO =1)";
                oSQL.Open();

                return oSQL.dtDados;
            }
        }
        public static DataTable GetFluxoCaixa(string ANO, string MES, string CAMPO, bool[] SITUACAO = null)
        {
            string QUERYSITUACOES = "";
            if (SITUACAO != null)
                for (int i = 0; i < 4; i++)
                    if (SITUACAO[i])
                        QUERYSITUACOES += QUERYSITUACOES == "" ? $" and (SITUACAO = {i} " : $" or SITUACAO = {i} ";

            QUERYSITUACOES += QUERYSITUACOES == "" ? " and SITUACAO = -1 " : ")";

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                 IDCONTAPAGAR AS ID,
                                 EMISSAO AS DATA,
                                VENCIMENTO,
                                 FRN.RAZAOSOCIAL AS PESSOA,
                                 ORIGEM , 
                                 COMPLMHISFIN AS DESCRICAO,
                                 SALDO AS VALOR,
                                (VALOR - SALDO) AS PAGO,
                                CASE
                                    WHEN SITUACAO = 0 THEN 'CANCELADO'
                                    WHEN SITUACAO = 1 THEN 'ABERTO'
                                    WHEN SITUACAO = 2 THEN 'PARCIAL'
                                    WHEN SITUACAO = 3 THEN 'BAIXADO'
                                 END AS SITUACAO,
                                 'D' AS TIPO                                
                                FROM CONTAPAGAR CP
                                JOIN FORNECEDOR FRN ON FRN.IDFORNECEDOR = CP.IDFORNECEDOR
                                WHERE MONTH(" + CAMPO + ") =" + MES +
                                @"AND YEAR(" + CAMPO + ") = " + ANO + QUERYSITUACOES +
                                @"UNION 
                                SELECT 
                                IDCONTARECEBER AS ID,
                                 EMISSAO  AS DATA,
                                VENCIMENTO,
                                 CLI.NOME AS PESSOA,
                                 ORIGEM , 
                                 COMPLMHISFIN AS DESCRICAO,
                                 SALDO AS VALOR,
                                (VALOR - SALDO) AS PAGO,
                                 CASE
                                    WHEN SITUACAO = 0 THEN 'CANCELADO'
                                    WHEN SITUACAO = 1 THEN 'ABERTO'
                                    WHEN SITUACAO = 2 THEN 'PARCIAL'
                                    WHEN SITUACAO = 3 THEN 'BAIXADO'
                                 END AS SITUACAO,
                                 'C' AS TIPO
                                FROM CONTARECEBER REC
                                left JOIN CLIENTE CLI ON CLI.IDCLIENTE = REC.IDCLIENTE
                                WHERE MONTH(" + CAMPO + ") = " + MES +
                                @"AND YEAR(" + CAMPO + ") = " + ANO + QUERYSITUACOES +
                                "ORDER BY DATA DESC";

                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetFluxoCaixaAgrupado(string Ano, string Mes, string campo, bool[] situacao = null)
        {
            string querySituacoes = "";
            if (situacao != null)
                for (int i = 0; i < 4; i++)
                    if (situacao[i])
                        querySituacoes += querySituacoes == "" ? $" and (situacao = {i} " : $" or situacao = {i} ";

            querySituacoes += querySituacoes == "" ? " and situacao = -1 " : ")";

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"select 
                                Origem , 
                                sum(valor - saldo) as pago         
                                from contapagar cp
                                join fornecedor frn on frn.idfornecedor = cp.idfornecedor
                                where MONTH(" + campo + ") =" + Mes +
                                @"AND YEAR(" + campo + ") = " + Ano + querySituacoes +
                                "group by Origem " +
                                @"union  
                                -- SQLINES LICENSE FOR EVALUATION USE ONLY
                                select 
                                Origem , 
                                sum(valor - saldo) as pago
                                from contareceber rec
                                join cliente cli on cli.idcliente = rec.idcliente
                                where MONTH(" + campo + ") = " + Mes +
                                @"AND YEAR(" + campo + ") = " + Ano + querySituacoes +
                                 "group by Origem " +
                                "order by origem desc";

                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static bool Salvar(Caixa _Caixa, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                        CAIXA (IDCAIXA, NUMEROCAIXA, SERIALPOS, NOMEPOS, ATIVO,TIPODEVENDA,TIPOPDV,MOSTRAR_RELATORIO_CAIXA) 
                                            VALUES (@IDCAIXA, @NUMEROCAIXA, @SERIALPOS, @NOMEPOS, @ATIVO,@TIPODEVENDA,@TIPOPDV,@MOSTRAR_RELATORIO_CAIXA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CAIXA
                                      SET IDCAIXA = @IDCAIXA, 
                                          NUMEROCAIXA = @NUMEROCAIXA,
                                          SERIALPOS = @SERIALPOS,
                                          NOMEPOS = @NOMEPOS,
                                          ATIVO = @ATIVO, 
                                          TIPODEVENDA = @TIPODEVENDA, 
                                          TIPOPDV = @TIPOPDV,
                                          MOSTRAR_RELATORIO_CAIXA=@MOSTRAR_RELATORIO_CAIXA
                                     WHERE IDCAIXA = @IDCAIXA";
                        break;
                }

                oSQL.ParamByName["IDCAIXA"] = _Caixa.IDCaixa;
                oSQL.ParamByName["NUMEROCAIXA"] = _Caixa.NumeroCaixa;
                oSQL.ParamByName["SERIALPOS"] = _Caixa.SerialPOS;
                oSQL.ParamByName["NOMEPOS"] = _Caixa.NomePOS;
                oSQL.ParamByName["ATIVO"] = _Caixa.Ativo;
                oSQL.ParamByName["TIPODEVENDA"] = _Caixa.TipoDeVenda;
                oSQL.ParamByName["TIPOPDV"] = _Caixa.TipoPDV;
                oSQL.ParamByName["MOSTRAR_RELATORIO_CAIXA"] = _Caixa.Mostrar_Relatorio_Caixa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM CAIXA WHERE IDCAIXA = @IDCAIXA";
                oSQL.ParamByName["IDCAIXA"] = IDCaixa;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
