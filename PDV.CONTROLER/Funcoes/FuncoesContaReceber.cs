using IntegradorZeusPDV.App_Context;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContaReceber
    {
        public static bool Salvar(ContaReceber Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTARECEBER(
                                                 IDCONTARECEBER, IDCONTABANCARIA, IDCENTROCUSTO, IDCLIENTE, IDFORMADEPAGAMENTO, 
                                                 IDHISTORICOFINANCEIRO, TITULO, PARCELA, EMISSAO, 
                                                 VENCIMENTO, COMPLMHISFIN, FLUXO, VALOR, ORIGEM, MULTA, JUROS, 
                                                 DESCONTO, SITUACAO, VALORTOTAL, SALDO, IDMOVIMENTOFISCAL, IDVENDA,
                                                 ULTIMAMODIFICACAO, IDUSUARIO)
                                         VALUES (@IDCONTARECEBER, @IDCONTABANCARIA, @IDCENTROCUSTO, @IDCLIENTE, @IDFORMADEPAGAMENTO, 
                                                 @IDHISTORICOFINANCEIRO, @TITULO, @PARCELA, @EMISSAO, 
                                                 @VENCIMENTO, @COMPLMHISFIN, @FLUXO, @VALOR, @ORIGEM, @MULTA, @JUROS, 
                                                 @DESCONTO, @SITUACAO, @VALORTOTAL, @SALDO, @IDMOVIMENTOFISCAL, @IDVENDA,
                                                 @ULTIMAMODIFICACAO, @IDUSUARIO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTARECEBER
                                       SET IDCONTABANCARIA = @IDCONTABANCARIA,
                                           IDCENTROCUSTO = @IDCENTROCUSTO,
                                           IDCLIENTE = @IDCLIENTE, 
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO,
                                           IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO,
                                           TITULO = @TITULO, 
                                           PARCELA = @PARCELA, 
                                           EMISSAO = @EMISSAO, 
                                           VENCIMENTO = @VENCIMENTO, 
                                           COMPLMHISFIN = @COMPLMHISFIN, 
                                           FLUXO = @FLUXO, 
                                           VALOR = @VALOR, 
                                           ORIGEM = @ORIGEM, 
                                           MULTA = @MULTA, 
                                           JUROS = @JUROS, 
                                           DESCONTO = @DESCONTO, 
                                           SITUACAO = @SITUACAO, 
                                           VALORTOTAL = @VALORTOTAL, 
                                           SALDO = @SALDO,
                                           IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL,
                                           IDVENDA = @IDVENDA,
                                           PAGAMENTO = @PAGAMENTO,
                                           ULTIMAMODIFICACAO = @ULTIMAMODIFICACAO,
                                           IDUSUARIO = @IDUSUARIO
                                     WHERE IDCONTARECEBER = @IDCONTARECEBER";


                       // MessageBox.Show(Conta.Pagamento.Date.ToString());




                    

                        if (Conta.Pagamento.Date.ToString().Contains("0001"))
                        {
                            
                            oSQL.ParamByName["PAGAMENTO"] = DBNull.Value;
                        

                        }
                        else
                        {
                            oSQL.ParamByName["PAGAMENTO"] = Conta.Pagamento;
                         
                          
                        }

                       /* if (Conta.Pagamento != null)
                        {
                            oSQL.ParamByName["PAGAMENTO"] = Conta.Pagamento;
                        }
                        else
                        {
                            oSQL.ParamByName["PAGAMENTO"] = DBNull.Value;
                        }*/
                        break;
                }
                //MessageBox.Show(Conta.Vencimento.Date.ToString());
                //MessageBox.Show(Conta.Emissao.Date.ToString());
                //MessageBox.Show(Conta.Fluxo.Date.ToString());
                // Conta.Vencimento.Date.ToString;
                // Conta.Emissao;
                // Conta.Fluxo;

                //erro pag
               
    

                oSQL.ParamByName["IDCONTARECEBER"] = Conta.IDContaReceber;
                oSQL.ParamByName["IDCONTABANCARIA"] = Conta.IDContaBancaria;
                oSQL.ParamByName["IDCENTROCUSTO"] = Conta.IDCentroCusto;
                oSQL.ParamByName["IDCLIENTE"] = Conta.IDCliente;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Conta.IDFormaDePagamento;
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = Conta.IDHistoricoFinanceiro;
                oSQL.ParamByName["TITULO"] = Conta.Titulo;
                oSQL.ParamByName["PARCELA"] = Conta.Parcela;

                oSQL.ParamByName["COMPLMHISFIN"] = Conta.ComplmHisFin;

                oSQL.ParamByName["EMISSAO"] = Conta.Emissao;
                oSQL.ParamByName["VENCIMENTO"] = Conta.Vencimento;
                oSQL.ParamByName["FLUXO"] = Conta.Fluxo;
                
                         

                oSQL.ParamByName["VALOR"] = Conta.Valor;
                oSQL.ParamByName["ORIGEM"] = Conta.Origem;
                oSQL.ParamByName["MULTA"] = Conta.Multa;
                oSQL.ParamByName["JUROS"] = Conta.Juros;
                oSQL.ParamByName["DESCONTO"] = Conta.Desconto;
                oSQL.ParamByName["SITUACAO"] = Conta.Situacao;
                oSQL.ParamByName["VALORTOTAL"] = Conta.ValorTotal;
                oSQL.ParamByName["SALDO"] = Conta.Saldo;
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = Conta.IDMovimentoFiscal;
                oSQL.ParamByName["IDVENDA"] = Conta.IDVenda;
                
                oSQL.ParamByName["ULTIMAMODIFICACAO"] = DateTime.Now;
                oSQL.ParamByName["IDUSUARIO"] = Conta.IDUsuario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static object GetContasReceberAgrupadasPorSituacao(DateTime dataDe, DateTime dataAte, string filtrarPor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT
                        CASE
                            WHEN SITUACAO = {StatusConta.Aberto} THEN 'ABERTO'
                            WHEN SITUACAO = {StatusConta.Parcial} THEN 'PARCIAL'
                            WHEN SITUACAO = {StatusConta.Cancelado} THEN 'CANCELADO'
                            WHEN SITUACAO = {StatusConta.Baixado} THEN 'BAIXADO'
                        END AS STATUS,
                        SUM(VALORTOTAL) AS SOMA
                        FROM CONTARECEBER
                        WHERE ({filtrarPor} BETWEEN @DATADE AND @DATAATE)
                        GROUP BY SITUACAO
                        ORDER BY SOMA DESC";
                oSQL.ParamByName["DATADE"] = dataDe;
                oSQL.ParamByName["DATAATE"] = dataAte;
                oSQL.Open();
                return oSQL.dtDados;
            }

        }

        public static bool PossuiBoletoGerado(decimal idContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT TOP 1 FROM CONTARECCOBRANCA WHERE IDCONTARECEBER = @IDCONTARECEBER"; ;
                oSQL.ParamByName["IDCONTARECEBER"] = idContaReceber;
                oSQL.Open();
                return oSQL.dtDados.Rows.Count > 0;
            }
        }

        public static DataTable GetContaReceberAgrupadasPorFormaDePagamento(DateTime dateDe, DateTime dateAte, string filtrarPor)
        {
           using(SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT 
                                FP.DESCRICAO,
                                SUM(CR.VALORTOTAL) AS SOMA
                            FROM
                            CONTARECEBER CR
                            JOIN FORMADEPAGAMENTO FP ON (CR.IDFORMADEPAGAMENTO = FP.IDFORMADEPAGAMENTO)
                            WHERE ({filtrarPor} BETWEEN @DATADE AND @DATAATE)
                            GROUP BY FP.DESCRICAO
                            ORDER BY SOMA DESC

                        ";

                oSQL.ParamByName["DATADE"] = dateDe;
                oSQL.ParamByName["DATAATE"] = dateAte;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Remover(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetContas(DateTime date1, DateTime date2)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT  CONTARECEBER.IDCONTARECEBER,
                                     CONTARECEBER.IDVENDA,
                                     CONTARECEBER.IDCLIENTE,
                                     CASE 
                                        WHEN CONTARECEBER.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                        WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                     END AS CLIENTE,
                                     CONTARECEBER.PARCELA,
                                     CONTARECEBER.EMISSAO,
                                     CONTARECEBER.VENCIMENTO,
                                    FORMADEPAGAMENTO.IDENTIFICACAO AS FORMAPAGAMENTO,
                                    CONTARECEBER.ULTIMAMODIFICACAO AS DATAMODIFICACAO,
                                    CAST(CONTARECEBER.ULTIMAMODIFICACAO AS TIME(0)) HORAMODIFICACAO,
                                    USUARIO.NOME AS USUARIO,
                                     CASE 
                                       WHEN TITULO IS NULL THEN ORIGEM
                                       ELSE ISNULL(ORIGEM, '')+'-'+ISNULL(COALESCE(TITULO, ''), '') 
                                     END AS ORIGEM,
                                     CONTARECEBER.VALORTOTAL,
                                    CASE
                                     WHEN SITUACAO = 0 THEN 'CANCELADO'
                                     WHEN SITUACAO = 1 THEN 'ABERTO'
                                     WHEN SITUACAO = 2 THEN 'PARCIAL'
                                     WHEN SITUACAO = 3 THEN 'BAIXADO'
                                 END AS SITUACAO
                                FROM CONTARECEBER
                                  INNER JOIN FORMADEPAGAMENTO ON (CONTARECEBER.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                  LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  LEFT JOIN USUARIO ON (CONTARECEBER.IDUSUARIO = USUARIO.IDUSUARIO)
                                  WHERE CONTARECEBER.EMISSAO BETWEEN @DATE1 AND @DATE2
                              ORDER BY CONTARECEBER.EMISSAO DESC, 
                                       CONTARECEBER.IDCONTARECEBER DESC";
                oSQL.ParamByName["DATE1"] = date1;
                oSQL.ParamByName["DATE2"] = date2;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetContasComSaldoEmAberto(string Cliente, /*DateTime VencimentoInicio, DateTime VencimentoFim, DateTime EmissaoInicio, DateTime EmissaoFim, */string FormaPagamento, string Origem)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT FALSE AS SELECIONADO,
                                     CASE 
                                        WHEN CONTARECEBER.IDCLIENTE IS NULL THEN 'Cliente Não Informado'
                                        WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                     END AS CLIENTE,
                                     CONTARECEBER.PARCELA,
                                     CONTARECEBER.EMISSAO,
                                     CONTARECEBER.VENCIMENTO,
                                     CASE 
                                       WHEN COALESCE(FORMADEPAGAMENTO.IDENTIFICACAO, '') = '' THEN FORMADEPAGAMENTO.DESCRICAO
                                        ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ ISNULL(FORMADEPAGAMENTO.IDENTIFICACAO, '')
                                     END AS FORMAPAGAMENTO,
                                     CONTARECEBER.ULTIMAMODIFICACAO,
                                     CASE 
                                       WHEN TITULO IS NULL THEN ORIGEM
                                       ELSE ISNULL(ORIGEM, '')+'-'+ISNULL(COALESCE(TITULO, ''), '') 
                                     END AS ORIGEM,
                                     CONTARECEBER.SALDO,
                                     CASE
                                       WHEN CONTARECEBER.SITUACAO = 0 THEN 'CANCELADO'
                                       WHEN CONTARECEBER.SITUACAO = 1 THEN 'ABERTO'
                                       WHEN CONTARECEBER.SITUACAO = 2 THEN 'PARCIAL'
                                       WHEN CONTARECEBER.SITUACAO = 3 THEN 'BAIXADO'
                                     END AS SITUACAO,
                                     CONTARECEBER.IDCONTARECEBER,
                                     CONTARECEBER.IDCLIENTE
                                FROM CONTARECEBER
                                  INNER JOIN FORMADEPAGAMENTO ON (CONTARECEBER.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                  LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                             -- SQLINES DEMO *** R.VENCIMENTO BETWEEN @INICIOVENCIMENTO AND @FIMVENCIMENTO
                               -- SQLINES DEMO *** EMISSAO BETWEEN @INICIOEMISSAO AND @FIMEMISSAO
                                -- SQLINES DEMO *** CE(CLIENTE.NOME, '')) LIKE UPPER('%{Cliente}%') OR UPPER(COALESCE(CLIENTE.NOMEFANTASIA, '')) LIKE UPPER('%{Cliente}%'))
                                -- SQLINES DEMO *** ECEBER.ORIGEM) LIKE UPPER('%{Origem}%') OR UPPER(CONTARECEBER.TITULO) LIKE UPPER('%{Origem}%'))
                                -- SQLINES DEMO *** PAGAMENTO.DESCRICAO) LIKE UPPER('%{FormaPagamento}%')
                                -- SQLINES DEMO *** SALDO > 0
                                AND CONTARECEBER.SITUACAO IN (1,2)
                              ORDER BY CONTARECEBER.IDCONTARECEBER DESC, CASE 
                                                                    WHEN COALESCE(FORMADEPAGAMENTO.IDENTIFICACAO, '') = '' THEN FORMADEPAGAMENTO.DESCRICAO
                                                                     ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ ISNULL(FORMADEPAGAMENTO.IDENTIFICACAO, '')
                                                                  END, 
                                       CONTARECEBER.PARCELA";
                //oSQL.ParamByName["INICIOVENCIMENTO"] = VencimentoInicio;
                //oSQL.ParamByName["FIMVENCIMENTO"] = VencimentoFim;
                //oSQL.ParamByName["INICIOEMISSAO"] = EmissaoInicio;
                //oSQL.ParamByName["FIMEMISSAO"] = EmissaoFim;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool AtualizaContaBancaria(decimal IDContaReceber, decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE CONTARECEBER SET IDCONTABANCARIA = @IDCONTABANCARIA WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ContaReceber GetContaReceber(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return EntityUtil<ContaReceber>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static ContaReceber GetContaReceberPorVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDVenda = @IDVENDA";
                oSQL.ParamByName["IDVenda"] = IDVenda;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count > 0)
                    return EntityUtil<ContaReceber>.ParseDataRow(oSQL.dtDados.Rows[0]);
                else
                    return null;
            }
        }

        public static DataTable GetContaReceberDT(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ContaReceber GetIDVendaContaReceber(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return EntityUtil<ContaReceber>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDContaReceber)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool UpdateRenegociacao(decimal IDContaReceber, decimal IDContaReceberRenegociada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE CONTARECEBER 
                                SET IDCONTARECEBERRENEGOCIACAO = @IDCONTARECEBERRENEGOCIACAO,
                                    SITUACAO = 3,--Baixado
                                    SALDO = 0
                             WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBERRENEGOCIACAO"] = IDContaReceberRenegociada;
                oSQL.ParamByName["IDCONTARECEBER"] = IDContaReceber;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<ContaReceber> GetContasReceberPorMovimentoFiscal(decimal IDMovimentoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.Open();
                return new DataTableParser<ContaReceber>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool CancelarContaReceberDocumento(decimal IDVenda, Usuario usuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE CONTARECEBER 
                                SET SITUACAO = 0, --Cancelado
                                complmhisfin = 'CANCELAMENTO DE FATURAMENTO.',
                                IDUSUARIO = @IDUSUARIO
                                
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["IDUSUARIO"] = usuario.IDUsuario;
                return oSQL.ExecSQL() >= 1;
            }
        }

        public static List<ContaReceber> GetContasReceberPorLista(decimal IDCONTARECEBER)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE IDCONTARECEBER = @IDCONTARECEBER";
                oSQL.ParamByName["IDCONTARECEBER"] = IDCONTARECEBER;
                oSQL.Open();
                return new DataTableParser<ContaReceber>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ContaReceber> GetContasReceberPorListaEmAberto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER WHERE SALDO > 0";
                oSQL.Open();
                return new DataTableParser<ContaReceber>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ContaReceber> GetContasReceberNaoBaixadasPorCliente(decimal idCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL =
                    @"SELECT IDCONTARECEBER,
IDCONTABANCARIA,
IDCENTROCUSTO,
IDCLIENTE,
IDFORMADEPAGAMENTO,
IDHISTORICOFINANCEIRO,
TITULO,
PARCELA,
EMISSAO,
VENCIMENTO,
COMPLMHISFIN,
FLUXO,
VALOR,
ORIGEM,
MULTA,
JUROS,
DESCONTO,
SITUACAO,
VALORTOTAL,
SALDO,
IDCONTARECEBERRENEGOCIACAO,
IDMOVIMENTOFISCAL,
CHAVEERP,
IDVENDA,
PAGAMENTO,
ULTIMAMODIFICACAO,
IDUSUARIO,
IDORDEMDESERVICO FROM CONTARECEBER
                      WHERE IDCLIENTE = @IDCLIENTE AND 
                    (SITUACAO = @SITUACAOABERTO OR SITUACAO = @SITUACAOPARCIAL)";

                oSQL.ParamByName["IDCLIENTE"] = idCliente;
                oSQL.ParamByName["SITUACAOABERTO"] = StatusConta.Aberto;
                oSQL.ParamByName["SITUACAOPARCIAL"] = StatusConta.Parcial;
                oSQL.Open();
                return new DataTableParser<ContaReceber>().ParseDataTable(oSQL.dtDados);
            }
        }


        public static DataTable GetContasReceberPorFluxoCaixa(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = $@"SELECT COALESCE(CASE 
                                        WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                        WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                     END, '<Não informado>') AS CLIENTE,
                                     CONTARECEBER.EMISSAO AS EMISSAO,
                                     CONTARECEBER.VENCIMENTO AS VENCIMENTO,
                                     CASE 
                                       WHEN COALESCE(FORMADEPAGAMENTO.IDENTIFICACAO, '') = '' THEN FORMADEPAGAMENTO.DESCRICAO
                                        ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ ISNULL(FORMADEPAGAMENTO.IDENTIFICACAO, '')
                                     END AS FORMAPAGAMENTO,
                                     CASE 
                                       WHEN TITULO IS NULL THEN ORIGEM
                                       ELSE ISNULL(ORIGEM, '')+'-'+ISNULL(COALESCE(TITULO, ''), '') 
                                     END AS ORIGEM,
                                     CONTARECEBER.SALDO AS SALDO,
                                     CASE
                                       WHEN CONTARECEBER.SITUACAO = 0 THEN 'CANCELADO'
                                       WHEN CONTARECEBER.SITUACAO = 1 THEN 'ABERTO'
                                       WHEN CONTARECEBER.SITUACAO = 2 THEN 'PARCIAL'
                                       WHEN CONTARECEBER.SITUACAO = 3 THEN 'BAIXADO'
                                     END AS SITUACAO,
                                     CONTARECEBER.IDCONTARECEBER AS CRIDCONTARECEBER,
                                     BAIXARECEBIMENTO.IDFLUXOCAIXA AS IDFLUXOCAIXA,
                                     BAIXARECEBIMENTO.VALOR AS VALORPAGO,
                                     BAIXARECEBIMENTO.IDCONTARECEBER AS BRIDCONTARECBER,
                                     CONTARECEBER.IDCLIENTE AS IDCLIENTE
                                FROM CONTARECEBER
                                  INNER JOIN FORMADEPAGAMENTO ON (CONTARECEBER.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                  LEFT JOIN CLIENTE ON (CONTARECEBER.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  INNER JOIN BAIXARECEBIMENTO ON (CONTARECEBER.IDCONTARECEBER = BAIXARECEBIMENTO.IDCONTARECEBER)
                              WHERE BAIXARECEBIMENTO.IDFLUXOCAIXA = @IDFLUXOCAIXA
                              ORDER BY CONTARECEBER.EMISSAO DESC, CASE 
                                                                    WHEN COALESCE(FORMADEPAGAMENTO.IDENTIFICACAO, '') = '' THEN FORMADEPAGAMENTO.DESCRICAO
                                                                     ELSE ISNULL(FORMADEPAGAMENTO.DESCRICAO, '')+' - '+ ISNULL(FORMADEPAGAMENTO.IDENTIFICACAO, '')
                                                                  END, 
                                       CONTARECEBER.PARCELA";
                //oSQL.SQL = "SELECT * FROM BAIXARECEBIMENTO WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
       
    }
}
