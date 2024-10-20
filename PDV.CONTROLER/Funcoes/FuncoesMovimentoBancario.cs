using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Data;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMovimentoBancario
    {

        public static bool Salvar(MovimentoBancario Movimento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MOVIMENTOBANCARIO
                                        (IDMOVIMENTOBANCARIO, IDCONTABANCARIA, IDNATUREZA, DATAMOVIMENTO, VALOR, DOCUMENTO, SEQUENCIA, HISTORICO, TIPO, CONCILIACAO)
                                     VALUES
                                        (@IDMOVIMENTOBANCARIO, @IDCONTABANCARIA, @IDNATUREZA, @DATAMOVIMENTO, @VALOR, @DOCUMENTO, @SEQUENCIA, @HISTORICO, @TIPO, @CONCILIACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MOVIMENTOBANCARIO
                                      SET IDCONTABANCARIA = @IDCONTABANCARIA, 
                                          IDNATUREZA = @IDNATUREZA,
                                    	  DATAMOVIMENTO = @DATAMOVIMENTO,
                                    	  VALOR = @VALOR,
                                    	  DOCUMENTO = @DOCUMENTO,
                                    	  SEQUENCIA = @SEQUENCIA,
                                    	  HISTORICO = @HISTORICO,
                                    	  TIPO = @TIPO,
                                    	  CONCILIACAO = @CONCILIACAO
                                    WHERE IDMOVIMENTOBANCARIO = @IDMOVIMENTOBANCARIO";
                        break;
                }
                oSQL.ParamByName["IDMOVIMENTOBANCARIO"] = Movimento.IDMovimentoBancario;
                oSQL.ParamByName["IDCONTABANCARIA"] = Movimento.IDContaBancaria;
                oSQL.ParamByName["IDNATUREZA"] = Movimento.IDNatureza;
                oSQL.ParamByName["DATAMOVIMENTO"] = Movimento.DataMovimento;
                oSQL.ParamByName["VALOR"] = Movimento.Valor;
                oSQL.ParamByName["DOCUMENTO"] = Movimento.Documento;
                oSQL.ParamByName["SEQUENCIA"] = Movimento.Sequencia;
                oSQL.ParamByName["HISTORICO"] = Movimento.Historico;
                oSQL.ParamByName["TIPO"] = Movimento.Tipo;
                oSQL.ParamByName["CONCILIACAO"] = Movimento.Conciliacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDMovimentoBancario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM MOVIMENTOBANCARIO WHERE IDMOVIMENTOBANCARIO = @IDMOVIMENTOBANCARIO";
                oSQL.ParamByName["IDMOVIMENTOBANCARIO"] = IDMovimentoBancario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static MovimentoBancario GetMovimento(decimal IDMovimentoBancario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOBANCARIO,
IDCONTABANCARIA,
IDNATUREZA,
DATAMOVIMENTO,
VALOR,
DOCUMENTO,
SEQUENCIA,
HISTORICO,
TIPO,
CONCILIACAO FROM MOVIMENTOBANCARIO WHERE IDMOVIMENTOBANCARIO = @IDMOVIMENTOBANCARIO";
                oSQL.ParamByName["IDMOVIMENTOBANCARIO"] = IDMovimentoBancario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<MovimentoBancario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMovimentos(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT MOVIMENTOBANCARIO.IDMOVIMENTOBANCARIO,
                                     MOVIMENTOBANCARIO.DATAMOVIMENTO,
                                     MOVIMENTOBANCARIO.DOCUMENTO,
                                     MOVIMENTOBANCARIO.SEQUENCIA,
                                     CONTABANCARIA.NOME AS CONTABANCARIA,
                                     MOVIMENTOBANCARIO.VALOR,
                                     CASE 
                                       WHEN MOVIMENTOBANCARIO.TIPO = 0 THEN 'Débito'
                                       WHEN MOVIMENTOBANCARIO.TIPO = 1 THEN 'Crédito'
                                     END AS TIPO       
                                FROM MOVIMENTOBANCARIO
                                  INNER JOIN CONTABANCARIA ON (MOVIMENTOBANCARIO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                              WHERE (UPPER(MOVIMENTOBANCARIO.DOCUMENTO) LIKE UPPER('%{Descricao}%') OR UPPER(CONTABANCARIA.NOME) LIKE UPPER('%{Descricao}%'))
                              ORDER BY MOVIMENTOBANCARIO.DATAMOVIMENTO DESC";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool RemoverPorDocumento(string Documento, decimal Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM MOVIMENTOBANCARIO WHERE DOCUMENTO = @DOCUMENTO AND TIPO = @TIPO";
                oSQL.ParamByName["DOCUMENTO"] = Documento;
                oSQL.ParamByName["TIPO"] = Tipo;
                return oSQL.ExecSQL() >= 0;
            }
        }

        public static bool Conciliar(decimal IDMovimentoBancario, DateTime? DataConciliacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE MOVIMENTOBANCARIO SET CONCILIACAO = @CONCILIACAO WHERE IDMOVIMENTOBANCARIO = @IDMOVIMENTOBANCARIO";
                oSQL.ParamByName["IDMOVIMENTOBANCARIO"] = IDMovimentoBancario;
                oSQL.ParamByName["CONCILIACAO"] = DataConciliacao;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}