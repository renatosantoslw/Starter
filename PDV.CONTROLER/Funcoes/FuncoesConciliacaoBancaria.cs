using PDV.DAO.DB.Controller;
using PDV.DAO.Enum;
using System;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesConciliacaoBancaria
    {
        public static DataTable GetBaixasParaConciliar(string ClienteFornecedor, DateTime VencimentoInicio, DateTime VencimentoFim, string FormaPagamento, string Origem)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT * FROM (
                            	SELECT FALSE AS SELECIONADO,
                            	       CASE 
                            		      WHEN CONTARECEBER.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                            		      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                            		      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                            	       END AS CLIENTEFORNECEDOR,
                            	       CONTABANCARIA.NOME AS CONTABANCARIA,
                            	       FORMADEPAGAMENTO.DESCRICAO AS FORMAPAGAMENTO,
                            	       CONTARECEBER.ORIGEM+'-'+CONTARECEBER.TITULO AS ORIGEM,
                                       BAIXARECEBIMENTO.BAIXA,
                            	       CONTARECEBER.VENCIMENTO,
                                       CONTARECEBER.PARCELA,
                            	       BAIXARECEBIMENTO.VALOR,
                                       CONTARECEBER.VALORTOTAL,
                            	       BAIXARECEBIMENTO.DATACONCILIACAO,
                            	       'A RECEBER'::VARCHAR AS TIPO,
                            	       0 AS TIPOBAIXA,
                            	       BAIXARECEBIMENTO.IDBAIXARECEBIMENTO AS IDBAIXA,
                                       0 AS TITULO
                            	  FROM BAIXARECEBIMENTO
                            	    INNER JOIN FORMADEPAGAMENTO ON (BAIXARECEBIMENTO.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                            	    INNER JOIN CONTABANCARIA ON (BAIXARECEBIMENTO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                            	    INNER JOIN CONTARECEBER ON (BAIXARECEBIMENTO.IDCONTARECEBER = CONTARECEBER.IDCONTARECEBER)
                            	     LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                            
                            	UNION
                            
                            	SELECT FALSE AS SELECIONADO,
                            	       FORNECEDOR.RAZAOSOCIAL AS CLIENTEFORNECEDOR,
                            	       CONTABANCARIA.NOME AS CONTABANCARIA,
                            	       FORMADEPAGAMENTO.DESCRICAO AS FORMAPAGAMENTO,
                            	       CONTAPAGAR.ORIGEM+'-'+CONTAPAGAR.TITULO AS ORIGEM,
                                       BAIXAPAGAMENTO.BAIXA,
                            	       CONTAPAGAR.VENCIMENTO,
                                       CONTAPAGAR.PARCELA,
                            	       BAIXAPAGAMENTO.VALOR,
                                       CONTAPAGAR.VALORTOTAL,
                            	       BAIXAPAGAMENTO.DATACONCILIACAO,
                            	       'A PAGAR'::VARCHAR AS TIPO,
                            	       1 AS TIPOBAIXA,
                            	       BAIXAPAGAMENTO.IDBAIXAPAGAMENTO AS IDBAIXA,
                                       0 AS TITULO
                            	  FROM BAIXAPAGAMENTO
                            	    INNER JOIN FORMADEPAGAMENTO ON (BAIXAPAGAMENTO.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                            	    INNER JOIN CONTABANCARIA ON (BAIXAPAGAMENTO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                            	    INNER JOIN CONTAPAGAR ON (BAIXAPAGAMENTO.IDCONTAPAGAR = CONTAPAGAR.IDCONTAPAGAR)
                            	     LEFT JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)

                                UNION 
                                
                                SELECT DISTINCT FALSE AS SELECIONADO,
                                     COALESCE(COALESCE(CLIENTE.NOME, FORNECEDOR.RAZAOSOCIAL), '<Não Informado>') AS CLIENTEFORNECEDOR,
                                     CONTABANCARIA.NOME AS CONTABANCARIA,
                                     COALESCE(COALESCE(PAGREC.DESCRICAO, PAGPAG.DESCRICAO), '<Não Informado>') AS FORMAPAGAMENTO,
                                     MOVIMENTOBANCARIO.DOCUMENTO AS ORIGEM,
                                     MOVIMENTOBANCARIO.DATAMOVIMENTO AS BAIXA,
                                     NULL::DATE AS VENCIMENTO,
                                     MOVIMENTOBANCARIO.SEQUENCIA,
                                     MOVIMENTOBANCARIO.VALOR,
                                     MOVIMENTOBANCARIO.VALOR AS VALORTOTAL,
                                     MOVIMENTOBANCARIO.CONCILIACAO AS DATACONCILIACAO,
                                     CASE 
                                        WHEN MOVIMENTOBANCARIO.TIPO = 0 THEN 'CRÉDITO'
                                        WHEN MOVIMENTOBANCARIO.TIPO = 1 THEN 'DÉBITO'
                                     END AS TIPO,
                                     MOVIMENTOBANCARIO.TIPO AS TIPOBAIXA,
                                     MOVIMENTOBANCARIO.IDMOVIMENTOBANCARIO AS IDBAIXA,
                                     1 AS TITULO
                                FROM MOVIMENTOBANCARIO
                                  INNER JOIN CONTABANCARIA ON (MOVIMENTOBANCARIO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                                  
                                   LEFT JOIN BAIXAPAGAMENTO ON (MOVIMENTOBANCARIO.TIPO = 0
                                                            AND MOVIMENTOBANCARIO.DOCUMENTO = BAIXAPAGAMENTO.IDCONTAPAGAR+'_'+BAIXAPAGAMENTO.IDBAIXAPAGAMENTO+'T')
                                   LEFT JOIN CONTAPAGAR ON (BAIXAPAGAMENTO.IDCONTAPAGAR = CONTAPAGAR.IDCONTAPAGAR)
                                   LEFT JOIN FORNECEDOR ON (CONTAPAGAR.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                   LEFT JOIN FORMADEPAGAMENTO PAGREC ON (BAIXAPAGAMENTO.IDFORMADEPAGAMENTO = PAGREC.IDFORMADEPAGAMENTO)
                                   
                                   LEFT JOIN BAIXARECEBIMENTO ON (MOVIMENTOBANCARIO.TIPO = 1
                                                             AND MOVIMENTOBANCARIO.DOCUMENTO = BAIXARECEBIMENTO.IDCONTARECEBER+'_'+BAIXARECEBIMENTO.IDBAIXARECEBIMENTO+'T')
                                   LEFT JOIN CONTARECEBER ON (BAIXARECEBIMENTO.IDCONTARECEBER = CONTARECEBER.IDCONTARECEBER)
                                   LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                                   LEFT JOIN FORMADEPAGAMENTO PAGPAG ON (BAIXARECEBIMENTO.IDFORMADEPAGAMENTO = PAGPAG.IDFORMADEPAGAMENTO)
                                
                            ) AS BAIXASPARACONCILIAR
                              WHERE BAIXA BETWEEN @INICIO AND @FIM
                                AND UPPER(COALESCE(CLIENTEFORNECEDOR, '')) LIKE UPPER('%{ClienteFornecedor}%')
                                AND UPPER(ORIGEM) LIKE UPPER('%{Origem}%')
                                AND UPPER(FORMAPAGAMENTO) LIKE UPPER('%{FormaPagamento}%')
                            ORDER BY BAIXA DESC, FORMAPAGAMENTO, PARCELA";
                oSQL.ParamByName["INICIO"] = VencimentoInicio.Date;
                oSQL.ParamByName["FIM"] = VencimentoFim.Date;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool ConciliarBaixa(decimal IDBaixa, DateTime? DataBaixa, TipoBaixa Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Tipo)
                {
                    case TipoBaixa.RECEBER:
                        oSQL.SQL = "UPDATE BAIXARECEBIMENTO SET DATACONCILIACAO = @DATACONCILIACAO WHERE IDBAIXARECEBIMENTO = @IDBAIXARECEBIMENTO";
                        oSQL.ParamByName["IDBAIXARECEBIMENTO"] = IDBaixa;
                        break;
                    case TipoBaixa.PAGAR:
                        oSQL.SQL = "UPDATE BAIXAPAGAMENTO SET DATACONCILIACAO = @DATACONCILIACAO WHERE IDBAIXAPAGAMENTO = @IDBAIXAPAGAMENTO";
                        oSQL.ParamByName["IDBAIXAPAGAMENTO"] = IDBaixa;
                        break;
                }
                oSQL.ParamByName["DATACONCILIACAO"] = DataBaixa;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}