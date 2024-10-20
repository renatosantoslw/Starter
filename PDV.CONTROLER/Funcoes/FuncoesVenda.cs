using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using PDV.DAO.QueryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesVenda
    {
        public static bool SalvarVenda(Venda _Venda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM VENDA WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = _Venda.IDVenda;
                oSQL.Open();
                bool ExisteVenda = !oSQL.IsEmpty;
                oSQL.ClearAll();

                if (!ExisteVenda)
                    oSQL.SQL = @"INSERT INTO VENDA(
                                         IDVENDA, QUANTIDADEITENS, VALORTOTAL, DATACADASTRO, IDUSUARIO, IDVENDEDOR, IDTIPODEOPERACAO, 
                                         IDCLIENTE, IDFLUXOCAIXA, IDCOMANDA, IDCOMANDAUTILIZADA, DINHEIRO, TROCO, STATUS,IDFORMAPAGAMENTO, OBSERVACAO, MOTIVODECANCELAMENTO, IDRESPOSTAFISCAL,
                                         TIPODEVENDA, DATAFATURAMENTO, PAGAMENTOSDESCRICAO, OBRA, VALORAVISTAPROPOSTO)
                                 VALUES (@IDVENDA, @QUANTIDADEITENS, @VALORTOTAL, CURRENT_TIMESTAMP, @IDUSUARIO, @IDVENDEDOR, @IDTIPODEOPERACAO,
                                         @IDCLIENTE, @IDFLUXOCAIXA, @IDCOMANDA, @IDCOMANDAUTILIZADA, @DINHEIRO, @TROCO, @STATUS,@IDFORMAPAGAMENTO,@OBSERVACAO, @MOTIVODECANCELAMENTO,@IDRESPOSTAFISCAL,
                                          @TIPODEVENDA, @DATAFATURAMENTO, @PAGAMENTOSDESCRICAO, @OBRA, @VALORAVISTAPROPOSTO)";
                else
                    oSQL.SQL = @"UPDATE VENDA
                                   SET QUANTIDADEITENS = @QUANTIDADEITENS, 
                                       VALORTOTAL = @VALORTOTAL,
                                       DATACADASTRO = @DATACADASTRO,
                                       IDUSUARIO = @IDUSUARIO, 
                                       IDVENDEDOR = @IDVENDEDOR ,       
                                       IDTIPODEOPERACAO = @IDTIPODEOPERACAO,
                                       IDCLIENTE = @IDCLIENTE,
                                       IDFLUXOCAIXA = @IDFLUXOCAIXA,
                                       IDCOMANDA = @IDCOMANDA,
                                       IDCOMANDAUTILIZADA = @IDCOMANDAUTILIZADA,
                                       DINHEIRO = @DINHEIRO,
                                       TROCO = @TROCO,
                                       STATUS = @STATUS, 
                                       IDFORMAPAGAMENTO = @IDFORMAPAGAMENTO, 
                                       OBSERVACAO = @OBSERVACAO,
                                       MOTIVODECANCELAMENTO = @MOTIVODECANCELAMENTO,
                                       IDRESPOSTAFISCAL = @IDRESPOSTAFISCAL ,
                                       TIPODEVENDA = @TIPODEVENDA,
                                       DATAFATURAMENTO = @DATAFATURAMENTO,
                                       PAGAMENTOSDESCRICAO = @PAGAMENTOSDESCRICAO,
                                       OBRA = @OBRA,
                                       VALORAVISTAPROPOSTO = @VALORAVISTAPROPOSTO
                                   WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = _Venda.IDVenda;
                oSQL.ParamByName["IDFLUXOCAIXA"] = _Venda.IDFluxoCaixa;
                oSQL.ParamByName["IDVENDEDOR"] = _Venda.IDVendedor;
                oSQL.ParamByName["IDTIPODEOPERACAO"] = _Venda.IDTipoDeOperacao;
                oSQL.ParamByName["QUANTIDADEITENS"] = _Venda.QuantidadeItens;
                oSQL.ParamByName["VALORTOTAL"] = _Venda.ValorTotal;
                oSQL.ParamByName["DATACADASTRO"] = _Venda.DataCadastro;
                oSQL.ParamByName["IDUSUARIO"] = _Venda.IDUsuario;
                oSQL.ParamByName["IDCOMANDA"] = _Venda.IDComanda;
                oSQL.ParamByName["IDCLIENTE"] = _Venda.IDCliente;
                oSQL.ParamByName["IDCOMANDAUTILIZADA"] = _Venda.IDComandaUtilizada;
                oSQL.ParamByName["DINHEIRO"] = _Venda.Dinheiro;
                oSQL.ParamByName["TROCO"] = _Venda.Troco;
                oSQL.ParamByName["STATUS"] = _Venda.Status;
                oSQL.ParamByName["IDFORMAPAGAMENTO"] = _Venda.IDFormaPagamento;
                oSQL.ParamByName["OBSERVACAO"] = _Venda.Observacao ?? string.Empty;
                oSQL.ParamByName["MOTIVODECANCELAMENTO"] = _Venda.MotivoDeCancelamento;
                oSQL.ParamByName["IDRESPOSTAFISCAL"] = _Venda.IdRespostaFiscal;
                oSQL.ParamByName["TIPODEVENDA"] = _Venda.TipoDeVenda;
                oSQL.ParamByName["DATAFATURAMENTO"] = _Venda.DataFaturamento;
                oSQL.ParamByName["PAGAMENTOSDESCRICAO"] = _Venda.PagamentosDescricao;
                oSQL.ParamByName["OBRA"] = _Venda.Obra;
                oSQL.ParamByName["VALORAVISTAPROPOSTO"] = _Venda.ValorAVistaProposto;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static object GetListaVendasPorFluxoDeCaixa(decimal idFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery()) {

                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    CAST(VENDA.DATACADASTRO AS TIME(0)) AS HORA,
                                    USUARIO.NOME AS VENDEDOR,
                                    CASE
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,

                                    TIPODEOPERACAO.NOME as TIPODEOPERACAO,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    COMANDA.IDCOMANDA,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO,
                                    CASE
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    WHEN VENDA.STATUS = 3 THEN 'DESFEITO'
                                    WHEN VENDA.STATUS = 4 THEN 'APP'
                                    END AS STATUS,
                                    CASE
                                        WHEN VENDA.TIPODEVENDA = 2 THEN 'ERP'
                                        WHEN VENDA.TIPODEVENDA = 1 THEN 'PDV'
                                    END AS TIPODEVENDA
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON(VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN COMANDA ON(VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 LEFT JOIN USUARIO ON(VENDA.IDVENDEDOR = USUARIO.IDUSUARIO)
                                 LEFT JOIN TIPODEOPERACAO ON(VENDA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                                 WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA AND VENDA.TIPODEVENDA = 1";

                oSQL.ParamByName["IDFLUXOCAIXA"] = idFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetVendasPorProduto(ResumoPorProdutoGenericoReportModel reportModel)
        {
            decimal status = 0;
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (reportModel.Status)
                {
                    case "ABERTO":
                        status = 0;
                        break;

                    case "FATURADO":
                        status = 1;
                        break;

                    case "CANCELADO":
                        status = 2;
                        break;

                    case "APP":
                        status = 4;
                        break;
                }
                oSQL.SQL = $@"SELECT 
                            P.CODIGO AS CODIGO,
                             P.DESCRICAO AS PRODUTO
                            ,M.DESCRICAO AS GRUPO
                            ,P.VALORCUSTO AS PRECOCUSTO
                            ,P.VALORVENDA AS PRECOVENDA
                            ,SUM(IV.DESCONTOVALOR) AS DESCONTO
                            ,SUM(IV.QUANTIDADE) AS QUANTIDADE
                            ,SUM((P.VALORVENDA*IV.QUANTIDADE) - IV.DESCONTOVALOR )AS TOTAL
                            FROM ITEMVENDA IV
                            LEFT JOIN PRODUTO P ON P.IDPRODUTO = IV.IDPRODUTO
                            LEFT JOIN MARCA M ON M.IDMARCA = P.IDMARCA
                            LEFT Join Venda V on V.IDVENDA = IV.IDVENDA
                            WHERE V.{reportModel.FiltrarPor} BETWEEN @DATE1 AND @DATE2
                            AND (V.IDTIPODEOPERACAO IN ({reportModel.IDsOperacaoString}))
                            AND (V.STATUS = @STATUS OR V.STATUS = @STATUS) 
                            GROUP BY 
                             P.DESCRICAO 
                            ,M.DESCRICAO 
                            ,P.VALORCUSTO 
                            ,P.VALORVENDA 
                            ,P.CODIGO
                                ";
                oSQL.ParamByName["DATE1"] = reportModel.DataDe.Date;
                oSQL.ParamByName["DATE2"] = reportModel.DataAte.Date;
                oSQL.ParamByName["STATUS"] = status;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetVendasPorFluxoDeCaixa(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVENDA,
IDCOMANDAUTILIZADA,
IDCOMANDA,
IDUSUARIO,
IDCLIENTE,
IDFLUXOCAIXA,
QUANTIDADEITENS,
VALORTOTAL,
DATACADASTRO,
CHAVEERP,
DINHEIRO,
TROCO,
STATUS,
IDFORMAPAGAMENTO,
OBSERVACAO,
IDVENDEDOR,
IDTIPODEOPERACAO,
MOTIVODECANCELAMENTO,
IDRESPOSTAFISCAL,
TIPODEVENDA,
IDCOMPRADOR,
DATAFATURAMENTO,
ROMANEIO,
IDROMANEIO,
PAGAMENTODESCRICAO,
PAGAMENTOSDESCRICAO,
OBRA,
VALORAVISTAPROPOSTO FROM VENDA WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Venda> GetVendasPDV(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVENDA,
IDCOMANDAUTILIZADA,
IDCOMANDA,
IDUSUARIO,
IDCLIENTE,
IDFLUXOCAIXA,
QUANTIDADEITENS,
VALORTOTAL,
DATACADASTRO,
CHAVEERP,
DINHEIRO,
TROCO,
STATUS,
IDFORMAPAGAMENTO,
OBSERVACAO,
IDVENDEDOR,
IDTIPODEOPERACAO,
MOTIVODECANCELAMENTO,
IDRESPOSTAFISCAL,
TIPODEVENDA,
IDCOMPRADOR,
DATAFATURAMENTO,
ROMANEIO,
IDROMANEIO,
PAGAMENTODESCRICAO,
PAGAMENTOSDESCRICAO,
OBRA,
VALORAVISTAPROPOSTO FROM VENDA    
                                WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA
                                AND VENDA.TIPODEVENDA = @TIPODEVENDA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.ParamByName["TIPODEVENDA"] = 1;
                oSQL.Open();
                return new DataTableParser<Venda>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static Venda GetVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVENDA,
IDCOMANDAUTILIZADA,
IDCOMANDA,
IDUSUARIO,
IDCLIENTE,
IDFLUXOCAIXA,
QUANTIDADEITENS,
VALORTOTAL,
DATACADASTRO,
CHAVEERP,
DINHEIRO,
TROCO,
STATUS,
IDFORMAPAGAMENTO,
OBSERVACAO,
IDVENDEDOR,
IDTIPODEOPERACAO,
MOTIVODECANCELAMENTO,
IDRESPOSTAFISCAL,
TIPODEVENDA,
IDCOMPRADOR,
DATAFATURAMENTO,
ROMANEIO,
IDROMANEIO,
PAGAMENTODESCRICAO,
PAGAMENTOSDESCRICAO,
OBRA,
VALORAVISTAPROPOSTO FROM VENDA WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Venda>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static DataTable GetTop10Vendas(DateTime dataDe, DateTime dataAte, decimal idOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 10 CASE WHEN CLI.NOME IS NULL THEN UPPER(SUBSTRING(CLI.RAZAOSOCIAL,1,10)) ELSE UPPER(SUBSTRING(CLI.NOME,1,10)) END AS DESCRICAO, SUM(V.VALORTOTAL) AS VALOR
                            FROM CLIENTE CLI 
                            JOIN VENDA V ON V.IDCLIENTE = CLI.IDCLIENTE
                            WHERE (V.DATACADASTRO BETWEEN @DATADE AND @DATAATE)
                                AND V.IDTIPODEOPERACAO = @IDTIPODEOPERACAO
                            GROUP BY CLI.NOME, CLI.RAZAOSOCIAL
                            ORDER BY SUM(V.VALORTOTAL) DESC
                            /*LIMIT 10*/
                            ";
                oSQL.ParamByName["DATADE"] = dataDe.Date;
                oSQL.ParamByName["DATAATE"] = dataAte.Date;
                oSQL.ParamByName["IDTIPODEOPERACAO"] = idOperacao;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendasPorVendedorGeral(DateTime dataDe, DateTime dataAte, decimal idOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = @"SELECT TOP 100 
                            USU.NOME AS DESCRICAO,
                            SUM(VEN.VALORTOTAL) AS VALOR
                            FROM VENDA VEN
                            JOIN USUARIO USU  ON USU.IDUSUARIO = VEN.IDVENDEDOR
                            WHERE (VEN.DATACADASTRO BETWEEN @DATADE AND @DATAATE)
                                AND VEN.IDTIPODEOPERACAO = @IDTIPODEOPERACAO
                            GROUP BY USU.NOME
                            ORDER BY SUM(VEN.VALORTOTAL) DESC
                            /*LIMIT 100*/
                                
                            ";
                oSQL.ParamByName["DATADE"] = dataDe.Date;
                oSQL.ParamByName["DATAATE"] = dataAte.Date;
                oSQL.ParamByName["IDTIPODEOPERACAO"] = idOperacao;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static Venda GetVendaComandaAberta(decimal IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVENDA,
IDCOMANDAUTILIZADA,
IDCOMANDA,
IDUSUARIO,
IDCLIENTE,
IDFLUXOCAIXA,
QUANTIDADEITENS,
VALORTOTAL,
DATACADASTRO,
CHAVEERP,
DINHEIRO,
TROCO,
STATUS,
IDFORMAPAGAMENTO,
OBSERVACAO,
IDVENDEDOR,
IDTIPODEOPERACAO,
MOTIVODECANCELAMENTO,
IDRESPOSTAFISCAL,
TIPODEVENDA,
IDCOMPRADOR,
DATAFATURAMENTO,
ROMANEIO,
IDROMANEIO,
PAGAMENTODESCRICAO,
PAGAMENTOSDESCRICAO,
OBRA,
VALORAVISTAPROPOSTO FROM VENDA
                             WHERE IDCOMANDA = @IDCOMANDA
                ";
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Venda>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static decimal GetUltimaVenda()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 NUMERO
                               FROM VENDA 
                             ORDER BY IDVENDA DESC
                              /*LIMIT 1*/";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;
                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["NUMERO"]);
            }
        }
        public static decimal GetFluxoCaixa()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 IDFLUXOCAIXA
                               FROM FLUXOCAIXA 
                            WHERE DATAFECHAMENTOCAIXA IS NULL
                             ORDER BY IDFLUXOCAIXA DESC
                              ";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;
                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDFLUXOCAIXA"]);
            }
        }
        public static DataTable GetVendasPDV()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    USUARIO.NOME AS USUARIO,
                                    CASE 
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    
                                    COMANDA.IDCOMANDA,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                             WHERE VENDA.IDVENDA NOT IN (SELECT COALESCE(IDVENDA, -1) FROM DUPLICATANFCE)
                               AND VENDA.IDVENDA NOT IN (SELECT COALESCE(IDVENDA, -1) FROM MOVIMENTOFISCAL)
                               AND VENDA.STATUS = 0
                             ORDER BY VENDA.DATACADASTRO";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendasPDVMFe()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    CASE 
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    END AS STATUS,
                                    USUARIO.NOME AS USUARIO,
                                    CASE 
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO,
									MOVIMENTOFISCAL.NUMERO,
									--MOVIMENTOFISCAL.XMLENVIO,
									MOVIMENTOFISCAL.CHAVE,
									MOVIMENTOFISCAL.XMOTIVO,
                                    MOVIMENTOFISCAL.IDMOVIMENTOFISCAL,
                                    VENDA.IDRESPOSTAFISCAL
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  JOIN MOVIMENTOFISCAL ON (VENDA.IDVENDA = MOVIMENTOFISCAL.IDVENDA)
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                             ORDER BY VENDA.DATACADASTRO
							 ";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool MudarStatus(decimal IDVenda, int status, string motivo = "")
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE VENDA 
                               SET STATUS = @STATUS,
                                   MOTIVODECANCELAMENTO = @MOTIVODECANCELAMENTO
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["MOTIVODECANCELAMENTO"] = motivo;
                oSQL.ParamByName["STATUS"] = status;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool Remover(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM VENDA 
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool RemoverItemVendaPorVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM ITEMVENDA 
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetExtratoVendaReport(ResumoVendasQueryModel queryModel)
        {
            decimal status = 0;
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (queryModel.Status)
                {
                    case "ABERTO":
                        status = 0;
                        break;

                    case "FATURADO":
                        status = 1;
                        break;

                    case "CANCELADO":
                        status = 2;
                        break;

                    case "APP":
                        status = 4;
                        break;
                }

                oSQL.SQL = $@"SELECT VENDA.IDVENDA,
                                      CAST(VENDA.DATACADASTRO AS DATE) AS DATA,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    CASE 
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    WHEN VENDA.STATUS = 4 THEN 'APP'
                                    END AS STATUS,
									 ITEMVENDA.DESCRICAO AS PRODUTO, 
									 ITEMVENDA.VALORUNITARIOITEM AS VALORPRODUTO,		
									 ITEMVENDA.QUANTIDADE AS QUANTIDADE ,
									 ITEMVENDA.DESCONTOVALOR AS DESCONTO ,
									 (ITEMVENDA.QUANTIDADE *   ITEMVENDA.VALORUNITARIOITEM) -  ITEMVENDA.DESCONTOVALOR AS SUBTOTAL,
								   VENDA.VALORTOTAL AS TOTALCLIENTE
                               FROM VENDA 
							     LEFT JOIN ITEMVENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                WHERE VENDA.DATACADASTRO BETWEEN @DATE1 AND @DATE2
                                AND (VENDA.IDTIPODEOPERACAO in ({queryModel.IDsOperacaoString}))
                                AND (VENDA.STATUS = @STATUS OR VENDA.STATUS = @STATUS) ORDER BY VENDA.DATACADASTRO";
                                
                oSQL.ParamByName["DATE1"] = queryModel.DataDe.Date;
                oSQL.ParamByName["DATE2"] = queryModel.DataAte.Date;
                oSQL.ParamByName["STATUS"] = status;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendas(DateTime date1, DateTime date2, int? tipo, decimal Fluxo = 0)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                string qryFluxo = "";
                if (tipo != null)
                {
                    if (Fluxo != 0)
                        qryFluxo = $@" WHERE VENDA.TIPODEVENDA = @TIPODEVENDA 
                                AND VENDA.IDFLUXOCAIXA = {Fluxo} 
                                AND DATACADASTRO BETWEEN @DATE1 AND @DATE2 
                                ORDER BY VENDA.DATACADASTRO DESC";
                    else
                        qryFluxo = @" WHERE VENDA.TIPODEVENDA = @TIPODEVENDA 
                                AND DATACADASTRO BETWEEN @DATE1 AND @DATE2
                                ORDER BY VENDA.DATACADASTRO DESC";
                }
                else
                {
                    if (Fluxo != 0)
                        qryFluxo = $@" WHERE VENDA.IDFLUXOCAIXA = {Fluxo} 
                                AND DATACADASTRO BETWEEN @DATE1 AND @DATE2 
                                ORDER BY VENDA.DATACADASTRO DESC";
                    else
                        qryFluxo = @" WHERE DATACADASTRO BETWEEN @DATE1 AND @DATE2 
                                ORDER BY VENDA.DATACADASTRO DESC";
                }


                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    CAST(VENDA.DATACADASTRO AS TIME(0)) AS HORA,
                                    VENDA.DATAFATURAMENTO,                                    
                                    USUARIO.NOME AS VENDEDOR,
                                    CASE 
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    MUNICIPIO.DESCRICAO AS MUNICIPIO,
                                    ENDERECO.BAIRRO,
                                    TIPODEOPERACAO.NOME as TIPODEOPERACAO,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    COMANDA.IDCOMANDA,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO,
                                    CASE 
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    WHEN VENDA.STATUS = 3 THEN 'DESFEITO'
                                    WHEN VENDA.STATUS = 4 THEN 'APP'
                                    END AS STATUS,
                                    CASE
                                        WHEN VENDA.TIPODEVENDA = 2 THEN 'ERP'
                                        WHEN VENDA.TIPODEVENDA = 1 THEN 'PDV'
                                    END AS TIPODEVENDA
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN ENDERECO ON (CLIENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                 LEFT JOIN MUNICIPIO ON (ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                                 LEFT JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 LEFT JOIN USUARIO ON (VENDA.IDVENDEDOR = USUARIO.IDUSUARIO)
                                 LEFT JOIN TIPODEOPERACAO ON (VENDA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO) "
                            + "  " + qryFluxo;

                oSQL.ParamByName["TIPODEVENDA"] = tipo;
                oSQL.ParamByName["DATE1"] = date1;
                oSQL.ParamByName["DATE2"] = date2;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendasFaturadas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    cast (cast(VENDA.DATACADASTRO as varchar(max)) as time(0)) as HORA,
                                    USUARIO.NOME AS USUARIO,
                                    CASE 
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    TIPODEOPERACAO.NOME,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    COMANDA.IDCOMANDA,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO,
                                    CASE 
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    END AS STATUS
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                 LEFT JOIN TIPODEOPERACAO ON (VENDA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                             WHERE VENDA.TIPODEVENDA in ( 1,2) AND VENDA.STATUS = 1 AND VENDA.IDVENDA NOT IN (SELECT IDVENDA FROM NFE)
                            ORDER BY VENDA.DATACADASTRO DESC";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendasNãoCarredasNoRomaneio()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
									VENDA.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO,
									VENDA.IDCLIENTE,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.NOMEFANTASIA
                                      WHEN CLI.TIPODOCUMENTO = 1 THEN CLI.NOME
                                    END AS CLIENTE,
									 CASE 
                                      WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.CNPJ
                                      WHEN CLI.TIPODOCUMENTO = 1 THEN CLI.CPF
                                    END AS DOCUMENTO,
									CONT.TELEFONE AS TELEFONE,
                                    CONT.CELULAR AS CELULAR,
                                    CONT.EMAIL AS EMAIL,
                                    ENDE.LOGRADOURO AS LOGRADOURO,
                                    ENDE.NUMERO AS NUMERO, 
                                    ENDE.CEP AS CEP,
                                    ENDE.BAIRRO AS BAIRRO, 
                                    MUN.DESCRICAO AS CIDADE,
                                    UF.SIGLA AS UF,
                                    TIPODEOPERACAO.NOME AS OPERACAO,
                                    VENDA.VALORTOTAL,
                                    CASE 
                                    WHEN VENDA.STATUS = 0 THEN 'ABERTO'
                                    WHEN VENDA.STATUS = 1 THEN 'FATURADO'
                                    WHEN VENDA.STATUS = 2 THEN 'CANCELADO'
                                    END AS STATUS
                               FROM VENDA
                                 LEFT JOIN CLIENTE CLI ON CLI.IDCLIENTE = VENDA.IDCLIENTE
								 LEFT JOIN ENDERECO ENDE ON ENDE.IDENDERECO = CLI.IDENDERECO 
                                 LEFT JOIN MUNICIPIO MUN ON MUN.IDMUNICIPIO = ENDE.IDMUNICIPIO
                                 LEFT JOIN UNIDADEFEDERATIVA UF ON UF.IDUNIDADEFEDERATIVA = ENDE.IDUNIDADEFEDERATIVA
                                 LEFT JOIN CONTATO CONT ON CONT.IDCONTATO = CLI.IDCONTATO
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                 LEFT JOIN TIPODEOPERACAO ON (VENDA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                             WHERE VENDA.TIPODEVENDA = 2 AND VENDA.STATUS = 1 AND VENDA.ROMANEIO is null
                            ORDER BY VENDA.DATACADASTRO DESC";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVendaGeral()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.DATACADASTRO,
                                    cast (cast(VENDA.DATACADASTRO as varchar(max)) as time(0)) as HORA ,
                                    USUARIO.NOME AS USUARIO,
                                    CASE 
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.CNPJ
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF
                                    END AS DOCUMENTO,
                                    CASE
                                      WHEN VENDA.IDCLIENTE IS NULL THEN '<Não Informado>'
                                      WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA
                                      WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME
                                    END AS CLIENTE,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    COMANDA.IDCOMANDA,
                                    VENDA.IDCLIENTE,
                                    VENDA.IDUSUARIO
                               FROM VENDA
                                 LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                 LEFT JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                             ORDER BY VENDA.DATACADASTRO DESC";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static bool AtualizarStatus(decimal IDVenda, int Status)
        {
            //0 ABERTO
            //1 FATURADO
            //2 CANCELADO
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE VENDA 
                               SET STATUS = @STATUS
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["STATUS"] = Status;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool AtualizarValorTotalEQuantidade(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<ItemVenda> Itens = FuncoesItemVenda.GetItens(IDVenda);

                oSQL.SQL = @"UPDATE VENDA 
                               SET VALORTOTAL = @VALORTOTAL,
                                   QUANTIDADEITENS = @QUANTIDADEITENS
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["VALORTOTAL"] = Itens.Sum(o => o.Subtotal);
                oSQL.ParamByName["QUANTIDADEITENS"] = Itens.Sum(o => Convert.ToInt32(o.Quantidade));
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static void AtualizarRespostaFiscal(decimal IDVenda, string idRespostaFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE VENDA 
                             SET IDRESPOSTAFISCAL = @IDRESPOSTAFISCAL
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["IDRESPOSTAFISCAL"] = idRespostaFiscal;
                oSQL.ExecSQL();
            }
        }
        public static void AtualizarRomaneio(decimal IDVenda, decimal IDRomaneio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE VENDA 
                               SET ROMANEIO = @ROMANEIO,
                                IDROMANEIO = @IDROMANEIO
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["IDROMANEIO"] = IDRomaneio;
                oSQL.ParamByName["ROMANEIO"] = true;
                oSQL.ExecSQL();
            }
        }
        public static DataTable GetVencimentosParaCarne(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATANFCE.IDDUPLICATANFCE,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.DESCRICAO AS FORMADEPAGAMENTO,
                                    DUPLICATANFCE.DATAVENCIMENTO,
                                    DUPLICATANFCE.DATAPAGAMENTO,
                                    DUPLICATANFCE.VALOR       
                               FROM DUPLICATANFCE
                             INNER JOIN FORMADEPAGAMENTO ON(DUPLICATANFCE.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                             WHERE DUPLICATANFCE.IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetVencimentosParaCrediario(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONTARECEBER.IDCONTARECEBER,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.DESCRICAO AS FORMADEPAGAMENTO,
                                    CONTARECEBER.VENCIMENTO,
                                    CONTARECEBER.FLUXO,
                                    CONTARECEBER.VALOR,
                                    CONTARECEBER.PAGAMENTO,
                                    CONTARECEBER.PARCELA
                               FROM CONTARECEBER
                             LEFT JOIN FORMADEPAGAMENTO ON(CONTARECEBER.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                             WHERE CONTARECEBER.IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }        
    }
}
