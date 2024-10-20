using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
//.
namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMovimentoFiscal
    {
        public static decimal AtualizarMovimentoPeloID(MovimentoFiscal Movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET SERIE = @SERIE,
                                   XMLENVIO = @XMLENVIO,
                                    XMLRETORNO,
                EMITIDA = @EMITIDA,
                DATAEMISSAO = @DATAEMISSAO,
                CANCELADA = @CANCELADA,
                IDVENDA = @IDVENDA,
                CHAVE = @CHAVE,
                CSTAT = @CSTAT,
                XMOTIVO = @XMOTIVO,
                DHRECBTO = @DHRECBTO,
                CONTINGENCIA = @CONTINGENCIA,
                NUMERO = @NUMERO,
                TIPODOCUMENTO = @TIPODOCUMENTO,
                AMBIENTE = @AMBIENTE,
                IDNFE = @IDNFE,
                PROTOCOLO = @PROTOCOLO,


                WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";



                oSQL.ParamByName["SERIE"] = Movimento.Serie;
                oSQL.ParamByName["XMLENVIO"] = Movimento.XMLEnvio;

                if (Movimento.XMLRetorno == null)
                {
                    Movimento.XMLRetorno = new byte[] { };
                }

                oSQL.ParamByName["XMLRETORNO"] = Movimento.XMLRetorno;
                oSQL.ParamByName["EMITIDA"] = Movimento.Emitida;
                oSQL.ParamByName["DATAEMISSAO"] = Movimento.DataEmissao;
                oSQL.ParamByName["CANCELADA"] = Movimento.Cancelada;
                oSQL.ParamByName["IDVENDA"] = Movimento.IDVenda;
                oSQL.ParamByName["CHAVE"] = Movimento.Chave;              
                oSQL.ParamByName["CSTAT"] = Movimento.cStat;
                oSQL.ParamByName["XMOTIVO"] = Movimento.xMotivo;
                oSQL.ParamByName["DHRECBTO"] = Movimento.DataRecebimento;
                oSQL.ParamByName["CONTINGENCIA"] = Movimento.Contingencia;
                oSQL.ParamByName["NUMERO"] = Movimento.Numero;
                oSQL.ParamByName["TIPODOCUMENTO"] = Movimento.TipoDocumento;
                oSQL.ParamByName["AMBIENTE"] = Movimento.Ambiente;
                oSQL.ParamByName["IDNFE"] = Movimento.IDNFe;
                oSQL.ParamByName["PROTOCOLO"] = Movimento.Protocolo;



                return oSQL.ExecSQL();
            }
        }

        public static MovimentoFiscal GetMovimento(decimal IDMovimentoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOFISCAL,
IDNFE,
IDVENDA,
SERIE,
XMLENVIO,
XMLRETORNO,
EMITIDA,
CANCELADA,
DATAEMISSAO,
CHAVE,
CSTAT,
XMOTIVO,
DHRECBTO,
AMBIENTE,
CONTINGENCIA,
NUMERO,
TIPODOCUMENTO,
XMLCANCELAMENTO,
PROTOCOLO FROM MOVIMENTOFISCAL WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.Open();
                return EntityUtil<MovimentoFiscal>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }





        public static bool  GetMovimentoBool(decimal? IDMovimentoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MOVIMENTOFISCAL WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.Open();
                return oSQL.dtDados.Rows.Count >= 1;
            }
        }







        public static DataTable GetMovimentoDataTable(decimal IDMovimentoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOFISCAL,
IDNFE,
IDVENDA,
SERIE,
XMLENVIO,
XMLRETORNO,
EMITIDA,
CANCELADA,
DATAEMISSAO,
CHAVE,
CSTAT,
XMOTIVO,
DHRECBTO,
AMBIENTE,
CONTINGENCIA,
NUMERO,
TIPODOCUMENTO,
XMLCANCELAMENTO,
PROTOCOLO FROM MOVIMENTOFISCAL WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool ExistePorNFe(decimal idNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MOVIMENTOFISCAL WHERE IDNFe = @IDNFe";
                oSQL.ParamByName["IDNFe"] = idNFe;
                oSQL.Open();
                return oSQL.dtDados.Rows.Count >= 1;
            }
        }

        public static decimal CancelarMovimentoMFe(decimal IDMovimentoFIscal, byte[] XmlCancelamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET CANCELADA = 1, XMLCANCELAMENTO = @XMLCANCELAMENTO
                             WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["XMLCANCELAMENTO"] = XmlCancelamento;
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFIscal;
                return oSQL.ExecSQL();
            }
        }

        public static string GetXMLRetorno(decimal IDMovimentoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT XMLRETORNO FROM MOVIMENTOFISCAL WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimentoFiscal;
                oSQL.Open();
                var xmlRetorno = Encoding.UTF8.GetString(oSQL.dtDados.Rows[0]["XMLRETORNO"] as byte[]);
                return xmlRetorno;
            }
        }

        public static bool AtualizarMovimento(MovimentoFiscal Movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET CANCELADA = @CANCELADA,
                                   CSTAT = @CSTAT, XMOTIVO = @XMLMOTIVO  
                             WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = Movimento.IDMovimentoFiscal;
                oSQL.ParamByName["CANCELADA"] = Movimento.Cancelada;
                oSQL.ParamByName["XMLMOTIVO"] = Movimento.xMotivo;
                oSQL.ParamByName["CSTAT"] = Movimento.cStat;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool ExcluirMovimentoFIscal(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM MOVIMENTOFISCAL
                             WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AtualizarStatusNFe(decimal idmovimentofiscal, string cstat,string xmotivo,string protocolo )
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                if (cstat == "101")
                {
                    oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET CANCELADA = 1
                             WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                    oSQL.ParamByName["XMOTIVO"] = xmotivo;
                    oSQL.ParamByName["PROTOCOLO"] = protocolo;
                    oSQL.ParamByName["CSTAT"] = decimal.Parse(cstat);
                    oSQL.ParamByName["IDMOVIMENTOFISCAL"] = idmovimentofiscal;
                    return oSQL.ExecSQL() == 1;
                }


                oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET XMOTIVO  = @XMOTIVO,
                                   CSTAT = @CSTAT,
                                   PROTOCOLO = @PROTOCOLO
                             WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["XMOTIVO"] = xmotivo;
                oSQL.ParamByName["PROTOCOLO"] = protocolo;
                oSQL.ParamByName["CSTAT"] = decimal.Parse(cstat);
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = idmovimentofiscal;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AtualizarMovimentoPorID(MovimentoFiscal Movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCAL
                               SET XMLENVIO = @XMLENVIO,
                                   XMLRETORNO = @XMLRETORNO,
                                   EMITIDA = @EMITIDA,
                                   DATAEMISSAO = @DATAEMISSAO,
                                   CANCELADA = @CANCELADA,
                                   CSTAT = @CSTAT,
                                   XMOTIVO = @XMOTIVO,
                                   DHRECBTO = @DHRECBTO,
                                   CHAVE = @CHAVE,
                                   CONTINGENCIA = @CONTINGENCIA, Protocolo =@Protocolo
                             WHERE IDMOVIMENTOFISCAL =@IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = Movimento.IDMovimentoFiscal;
                oSQL.ParamByName["XMLENVIO"] = Movimento.XMLEnvio;
                oSQL.ParamByName["XMLRETORNO"] = Movimento.XMLRetorno;
                oSQL.ParamByName["EMITIDA"] = Movimento.Emitida;
                oSQL.ParamByName["DATAEMISSAO"] = Movimento.DataEmissao;
                oSQL.ParamByName["CHAVE"] = Movimento.Chave;
                oSQL.ParamByName["CANCELADA"] = Movimento.Cancelada;
                oSQL.ParamByName["CSTAT"] = Movimento.cStat;
                oSQL.ParamByName["XMOTIVO"] = Movimento.xMotivo;
                oSQL.ParamByName["DHRECBTO"] = Movimento.DataRecebimento;
                oSQL.ParamByName["CONTINGENCIA"] = Movimento.Contingencia;
                oSQL.ParamByName["PROTOCOLO"] = Movimento.Protocolo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(MovimentoFiscal Movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO MOVIMENTOFISCAL(
                                         IDMOVIMENTOFISCAL, SERIE, XMLENVIO, XMLRETORNO, EMITIDA, DATAEMISSAO, 
                                         IDVENDA, CHAVE, CANCELADA, CSTAT, XMOTIVO, DHRECBTO, CONTINGENCIA, AMBIENTE, NUMERO, TIPODOCUMENTO, IDNFE,Protocolo)
                                 VALUES (@IDMOVIMENTOFISCAL, @SERIE, @XMLENVIO, @XMLRETORNO, @EMITIDA, @DATAEMISSAO, 
                                         @IDVENDA, @CHAVE, @CANCELADA, @CSTAT, @XMOTIVO, @DHRECBTO, @CONTINGENCIA, @AMBIENTE, @NUMERO, @TIPODOCUMENTO, @IDNFE,@PROTOCOLO)";
              
                
                
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = Movimento.IDMovimentoFiscal;
                oSQL.ParamByName["SERIE"] = Movimento.Serie;
                oSQL.ParamByName["XMLENVIO"] = Movimento.XMLEnvio;

                if (Movimento.XMLRetorno == null) 
                {
                    Movimento.XMLRetorno = new byte[] { };
                }

                oSQL.ParamByName["XMLRETORNO"] = Movimento.XMLRetorno;
                oSQL.ParamByName["EMITIDA"] = Movimento.Emitida;
                oSQL.ParamByName["DATAEMISSAO"] = Movimento.DataEmissao;
                oSQL.ParamByName["IDVENDA"] = Movimento.IDVenda;
                oSQL.ParamByName["CHAVE"] = Movimento.Chave;
                oSQL.ParamByName["CANCELADA"] = Movimento.Cancelada;
                oSQL.ParamByName["CSTAT"] = Movimento.cStat;
                oSQL.ParamByName["XMOTIVO"] = Movimento.xMotivo;
                oSQL.ParamByName["DHRECBTO"] = Movimento.DataRecebimento;
                oSQL.ParamByName["CONTINGENCIA"] = Movimento.Contingencia;
                oSQL.ParamByName["NUMERO"] = Movimento.Numero;
                oSQL.ParamByName["TIPODOCUMENTO"] = Movimento.TipoDocumento;
                oSQL.ParamByName["AMBIENTE"] = Movimento.Ambiente;
                oSQL.ParamByName["IDNFE"] = Movimento.IDNFe;
                oSQL.ParamByName["PROTOCOLO"] = Movimento.Protocolo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetMovimentos(DateTime DataInicio, DateTime DataTermino, bool Transmitida, bool Cancelada, bool VendaProcessada, bool Rejeitada, decimal Ambiente, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Combinacoes = new List<string>();

                if (!Transmitida && !Cancelada && !VendaProcessada && !Rejeitada)
                    Combinacoes.Add("TRUE");
                else
                {
                    if (Transmitida)
                        Combinacoes.Add("(MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT = 100)");

                    if (Cancelada)
                        Combinacoes.Add("(MOVIMENTOFISCAL.CANCELADA = 1)");

                    if (VendaProcessada)
                        Combinacoes.Add("(MOVIMENTOFISCAL.IDVENDA IS NULL)");

                    if (Rejeitada)
                        Combinacoes.Add("(MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT <> 100)");
                }

                oSQL.SQL = string.Format(@"SELECT DISTINCT 
                                                  MOVIMENTOSFISCAL.IDVENDA,
                                                  MOVIMENTOSFISCAL.IDMOVIMENTOFISCAL,
                                                  MOVIMENTOSFISCAL.NUMERO,
                                                  MOVIMENTOSFISCAL.SERIE,
                                                  MOVIMENTOSFISCAL.CHAVE,
                                                  MOVIMENTOSFISCAL.VENDEDOR,
                                                  MOVIMENTOSFISCAL.IDCLIENTE,
                                                  MOVIMENTOSFISCAL.CPFCNPJ,
                                                  MOVIMENTOSFISCAL.DATACADASTRO,
                                                  MOVIMENTOSFISCAL.DATAEMISSAO,
                                                  MOVIMENTOSFISCAL.VALORTOTAL AS VALOR,
                                                  MOVIMENTOSFISCAL.STATUS,
                                                  MOVIMENTOSFISCAL.CSTAT,
                                                  MOVIMENTOSFISCAL.MOTIVO,
                                                  MOVIMENTOSFISCAL.CANCELADA,
                                                  MOVIMENTOSFISCAL.TIPODOCUMENTO,
                                                  CASE 
                                                     WHEN dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) NOT LIKE '%CARTAO%'
                                                    AND  dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) LIKE '%DINHEIRO%' THEN 'DINHEIRO'
                                                    WHEN  dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) NOT LIKE '%DINHEIRO%'
                                                    AND dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) LIKE '%CARTAO%' THEN 'CARTAO'
                                                    WHEN  dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) LIKE '%CARTAO%'
                                                    AND dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) LIKE '%DINHEIRO%' THEN 'DINHEIRO e CARTAO'
                                                    WHEN  dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) NOT LIKE '%CARTAO%'
                                                    AND dbo.FN_FORMATAR_TEXTO(MOVIMENTOSFISCAL.PAGAMENTOSDESCRICAO) NOT LIKE '%DINHEIRO%' THEN 'OUTRO'
                                                     END AS 'FORMA DE PAGAMENTO'
                                                 

                                                  FROM (
                                             SELECT DISTINCT VENDA.IDVENDA,
                                                     VENDA.PAGAMENTOSDESCRICAO,  
                                                     MOVIMENTOFISCAL.IDMOVIMENTOFISCAL,
                                                     MOVIMENTOFISCAL.CHAVE,
                                                     USUARIO.NOME AS VENDEDOR,
                                                     CLIENTE.IDCLIENTE,
                                                     CASE WHEN CLIENTE.IDCLIENTE IS NULL THEN '<Não Identificado>' 
                                                         ELSE COALESCE(CLIENTE.CPF, CLIENTE.CNPJ)
                                                     END AS CPFCNPJ,
                                                     VENDA.DATACADASTRO,
                                                     MOVIMENTOFISCAL.DATAEMISSAO,
                                                     MOVIMENTOFISCAL.DHRECBTO,
                                                     CASE 
                                                      WHEN MOVIMENTOFISCAL.IDVENDA IS NULL
                                                       THEN '<VENDA PROCESSADA>'
                                                     WHEN MOVIMENTOFISCAL.CANCELADA = 1
                                                       THEN '<CANCELADA>'
                                                     WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT = 100
                                                      THEN '<AUTORIZADA>'
                                                     WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT <> 100
                                                      THEN '<REJEITADA>'
                                                     END AS STATUS,
                                                     MOVIMENTOFISCAL.CSTAT,
                                                     MOVIMENTOFISCAL.XMOTIVO AS MOTIVO,
                                                     COALESCE(MOVIMENTOFISCAL.CANCELADA, 0) AS CANCELADA,
                                                     MOVIMENTOFISCAL.AMBIENTE,
                                                     MOVIMENTOFISCAL.NUMERO,
                                                     MOVIMENTOFISCAL.TIPODOCUMENTO,
                                                     MOVIMENTOFISCAL.SERIE,
                                                     VENDA.VALORTOTAL
													  
                                               FROM VENDA
                                                INNER JOIN ITEMVENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                                                INNER JOIN DUPLICATANFCE ON (VENDA.IDVENDA = DUPLICATANFCE.IDVENDA)
                                                INNER JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                                LEFT JOIN MOVIMENTOFISCAL ON (VENDA.IDVENDA = MOVIMENTOFISCAL.IDVENDA)
                                                LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                              WHERE 
                                                   CAST(COALESCE(MOVIMENTOFISCAL.DATAEMISSAO, VENDA.DATACADASTRO) AS DATE) BETWEEN @DATAINICIO AND @DATAFIM
                                               AND COALESCE(MOVIMENTOFISCAL.CONTINGENCIA, 0) = 0
                                               AND (COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = 0 OR COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = @TIPODOCUMENTO)
                                               AND ({0})
                                           ) MOVIMENTOSFISCAL
                                            WHERE (MOVIMENTOSFISCAL.AMBIENTE IS NULL OR MOVIMENTOSFISCAL.AMBIENTE = @AMBIENTE)
                                           ORDER BY DATAEMISSAO DESC", string.Join(" OR ", Combinacoes));

                oSQL.ParamByName["DATAINICIO"] = DataInicio.Date;
                oSQL.ParamByName["DATAFIM"] = DataTermino.Date;
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static string GetXMLEnvio(decimal IDMovimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT XMLENVIO FROM MOVIMENTOFISCAL WHERE IDMOVIMENTOFISCAL = @IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDMOVIMENTOFISCAL"] = IDMovimento;
                oSQL.Open();
                return Encoding.UTF8.GetString(oSQL.dtDados.Rows[0]["XMLENVIO"] as byte[]);
            }
        }

        public static DataTable GetNotasEmContingencia(DateTime DataInicio, DateTime DataFim, decimal Ambiente, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT VENDA.IDVENDA,
                                    CLIENTE.IDCLIENTE,
                                    MOVIMENTOFISCAL.IDMOVIMENTOFISCAL,
                                    MOVIMENTOFISCAL.NUMERO,
                                    MOVIMENTOFISCAL.SERIE,
                                    MOVIMENTOFISCAL.CHAVE,
                                    USUARIO.NOME AS VENDEDOR,               
                                    CASE WHEN CLIENTE.IDCLIENTE IS NULL THEN '<Não Identificado>' 
                                        ELSE COALESCE(CLIENTE.CPF, CLIENTE.CNPJ)
                                    END AS CPFCNPJ,
                                    VENDA.DATACADASTRO,
                                    MOVIMENTOFISCAL.DATAEMISSAO,
                                    VENDA.VALORTOTAL AS VALORNFCE,
                                    CASE 
                                     WHEN MOVIMENTOFISCAL.IDVENDA IS NULL
                                      THEN '<VENDA PROCESSADA>'
                                    WHEN MOVIMENTOFISCAL.CANCELADA = 1
                                      THEN '<CANCELADA>'
                                    WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT = 100
                                     THEN '<AUTORIZADA>'
                                    WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT <> 100
                                     THEN '<REJEITADA>'
                                     WHEN MOVIMENTOFISCAL.CONTINGENCIA = 1
                                      THEN '<CONTINGÊNCIA>'
                                    END AS STATUS,
                                    MOVIMENTOFISCAL.XMOTIVO AS MOTIVO,
                                    MOVIMENTOFISCAL.CSTAT,
                                    MOVIMENTOFISCAL.CANCELADA,
                                    MOVIMENTOFISCAL.TIPODOCUMENTO
                                FROM MOVIMENTOFISCAL
                                   INNER JOIN VENDA ON (MOVIMENTOFISCAL.IDVENDA = VENDA.IDVENDA)
                                   INNER JOIN ITEMVENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                                   INNER JOIN DUPLICATANFCE ON (VENDA.IDVENDA = DUPLICATANFCE.IDVENDA)
                                   INNER JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                    LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                             WHERE MOVIMENTOFISCAL.CONTINGENCIA = 1
                              AND COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = @TIPODOCUMENTO
                             -- AND CAST(COALESCE(MOVIMENTOFISCAL.DATAEMISSAO, VENDA.DATACADASTRO) AS DATE) BETWEEN @DATAINICIO AND @DATAFIM
                              AND MOVIMENTOFISCAL.DATAEMISSAO BETWEEN @DATAINICIO AND  @DATAFIM
                              AND (MOVIMENTOFISCAL.AMBIENTE IS NULL OR MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE)
                            ORDER BY MOVIMENTOFISCAL.SERIE DESC, MOVIMENTOFISCAL.NUMERO DESC, USUARIO.NOME ASC";
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["DATAINICIO"] = DataInicio;
                oSQL.ParamByName["DATAFIM"] = DataFim;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetNFCEContingencia_MotorEnvio(decimal Ambiente, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT IDMOVIMENTOFISCAL, 
                                    XMLENVIO,
                                    SERIE, 
                                    NUMERO
                               FROM MOVIMENTOFISCAL
                             WHERE COALESCE(CONTINGENCIA, 0) = 1
                               AND COALESCE(CANCELADA, 0) = 0
                               AND COALESCE(EMITIDA, 0) = 0
                               AND (CSTAT IS NULL OR CSTAT <> 100)
                               AND MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE
                               AND TIPODOCUMENTO = @TIPODOCUMENTO";
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetNFCEsExportar(DateTime DataInicio, DateTime DataTermino, bool Transmitida, bool Cancelada, bool Rejeitada, bool Contingencia, decimal Ambiente, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Combinacoes = new List<string>();

                if (!Transmitida && !Cancelada && !Rejeitada)
                    Combinacoes.Add("TRUE");
                else
                {
                    if (Transmitida)
                        Combinacoes.Add("(MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT = 100)");

                    if (Cancelada)
                        Combinacoes.Add("(MOVIMENTOFISCAL.CANCELADA = 1)");

                    if (Rejeitada)
                        Combinacoes.Add("(MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT <> 100)");

                    if (Contingencia)
                        Combinacoes.Add("(MOVIMENTOFISCAL.CONTINGENCIA = 1 AND CSTAT = 100)");
                }

                oSQL.SQL = string.Format(@"SELECT IDMOVIMENTOFISCAL, 
                                                  CHAVE,
                                                  XMLENVIO, 
                                                  XMLRETORNO 
                                            FROM MOVIMENTOFISCAL
                                           WHERE (XMLENVIO IS NOT NULL AND XMLENVIO <> '')
                                             AND (XMLRETORNO IS NOT NULL AND XMLRETORNO <> '')
                                             AND CAST(MOVIMENTOFISCAL.DATAEMISSAO AS DATE) BETWEEN @DATAINICIO AND @DATAFIM
                                             AND MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE
                                             AND COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = @TIPODOCUMENTO
                                             AND ({0})", string.Join(" OR ", Combinacoes));
                oSQL.ParamByName["DATAINICIO"] = DataInicio.Date;
                oSQL.ParamByName["DATAFIM"] = DataTermino.Date;
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static void AtualizarStatusNFe(decimal iDMovimentoFiscal, object cStat, object text1, object text2)
        {
            throw new NotImplementedException();
        }

        public static DataTable GetNFe(decimal Ambiente, DateTime date1, DateTime date2)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Combinacoes = new List<string>();

                oSQL.SQL = string.Format(@"WITH VALORNFE AS (
                                              SELECT  SUM(VALORPRODUTOS) AS TOTALNFE,
                                                      IDNFE
                                                FROM (
                                              SELECT DISTINCT PRODUTONFE.IDNFE,
                                                     PRODUTONFE.IDPRODUTONFE,
                                                     (((VALORUNITARIO + OUTRASDESPESAS + FRETE + SEGURO) * QUANTIDADE) - DESCONTO) + VICMSST AS VALORPRODUTOS
                                                FROM PRODUTONFE
                                                 INNER JOIN PRODUTONFEICMS ON (PRODUTONFE.IDPRODUTONFE = PRODUTONFEICMS.IDPRODUTONFE)
                                              ) AS VALORPRODUTOS
                                                 GROUP BY IDNFE
                                           )
                                           SELECT DISTINCT  NFE.IDNFE, MOVIMENTOFISCAL.NUMERO,
                                                  NFE.SERIE,
                                                  MOVIMENTOFISCAL.CHAVE,
                                                  COALESCE(MOVIMENTOFISCAL.DATAEMISSAO, NFE.EMISSAO) AS DATAEMISSAO,
                                                  USUARIO.NOME AS VENDEDOR,
                                                  COALESCE(CLIENTE.NOME, CLIENTE.RAZAOSOCIAL) AS CLIENTE,
                                                  NFE.IDVENDA,
                                                  VALORNFE.TOTALNFE,
                                                  CASE 
                                                   WHEN MOVIMENTOFISCAL.IDNFE IS NULL
                                                    THEN 'NFE DIGITADA'
                                                  WHEN MOVIMENTOFISCAL.CANCELADA = 1
                                                    THEN 'CANCELADA'
                                                  WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT = 100
                                                   THEN 'AUTORIZADA'
                                                  WHEN MOVIMENTOFISCAL.EMITIDA = 1 AND CSTAT <> 100
                                                   THEN 'REJEITADA'
                                                  END AS STATUS,
                                                  MOVIMENTOFISCAL.XMOTIVO,
                                                 
                                                  MOVIMENTOFISCAL.CSTAT,
                                                  MOVIMENTOFISCAL.IDMOVIMENTOFISCAL,
                                                  COALESCE(MOVIMENTOFISCAL.CANCELADA, 0) AS CANCELADA
                                                
                                             FROM NFE
                                               INNER JOIN USUARIO ON (NFE.IDUSUARIO = USUARIO.IDUSUARIO)
                                               INNER JOIN CLIENTE ON (NFE.IDCLIENTE = CLIENTE.IDCLIENTE)
                                                LEFT JOIN VALORNFE ON (NFE.IDNFE = VALORNFE.IDNFE)
                                                LEFT JOIN MOVIMENTOFISCAL ON (NFE.IDNFE = MOVIMENTOFISCAL.IDNFE)
                                           WHERE (COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = 0 OR COALESCE(MOVIMENTOFISCAL.TIPODOCUMENTO, 0) = @TIPODOCUMENTO)
                                            AND (MOVIMENTOFISCAL.AMBIENTE IS NULL OR MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE)
                                            AND NFE.EMISSAO BETWEEN @DATE1 AND @DATE2
                                           ORDER BY NFE.IDNFE ");
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["TIPODOCUMENTO"] = 55;
                oSQL.ParamByName["DATE1"] = date1;
                oSQL.ParamByName["DATE2"] = date2;

                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetEventosNFe(DateTime DataInicio, DateTime DataTermino, decimal Ambiente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"WITH VALORNFE AS (
                                SELECT  SUM(((VALORUNITARIO * QUANTIDADE) + OUTRASDESPESAS + FRETE) - DESCONTO)  AS TOTALNFE,
                                       PRODUTONFE.IDNFE
                                  FROM PRODUTONFE
                                GROUP BY PRODUTONFE.IDNFE
                             )
                             -- SQLINES LICENSE FOR EVALUATION USE ONLY
                             SELECT  MOVIMENTOFISCAL.NUMERO,
                                    NFE.SERIE,
                                    CASE 
                                      WHEN MOVIMENTOFISCAL.TIPODOCUMENTO = 55 THEN 'NF-E'
                                      WHEN MOVIMENTOFISCAL.TIPODOCUMENTO = 65 THEN 'NFC-E'
                                    END AS TIPODOCUMENTO,
                                    COALESCE(MOVIMENTOFISCAL.DATAEMISSAO, NFE.EMISSAO) AS DATAEMISSAO,
                                    EVENTONFE.NSEQEVENTO,
                                    EVENTONFE.DESCEVENTO,       
                                    USUARIO.NOME,
                                    COALESCE(CLIENTE.NOME, CLIENTE.RAZAOSOCIAL) AS CLIENTE,
                                    VALORNFE.TOTALNFE,
                                    MOVIMENTOFISCAL.IDMOVIMENTOFISCAL,
                                    EVENTONFE.IDEVENTONFE
                               FROM EVENTONFE
                                 INNER JOIN MOVIMENTOFISCAL ON (EVENTONFE.IDMOVIMENTOFISCAL = MOVIMENTOFISCAL.IDMOVIMENTOFISCAL)
                                 INNER JOIN NFE ON (MOVIMENTOFISCAL.IDNFE = NFE.IDNFE)
                                 INNER JOIN USUARIO ON (NFE.IDUSUARIO = USUARIO.IDUSUARIO)
                                 INNER JOIN CLIENTE ON (NFE.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  LEFT JOIN VALORNFE ON (NFE.IDNFE = VALORNFE.IDNFE)
                               WHERE EVENTONFE.CSTAT = 135
                                 AND EVENTONFE.TIPOEVENTO IN (0,1)
                                 AND CAST(COALESCE(MOVIMENTOFISCAL.DATAEMISSAO, NFE.EMISSAO) AS DATE) BETWEEN @DATAINICIO AND @DATAFIM
                                 AND MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE
                             ORDER BY MOVIMENTOFISCAL.NUMERO DESC, DESCEVENTO, EVENTONFE.NSEQEVENTO DESC";
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["DATAINICIO"] = DataInicio;
                oSQL.ParamByName["DATAFIM"] = DataTermino;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static decimal GetUltimaNFCeEmitidaPorSerie(decimal Serie, int Ambiente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 NUMERO
                               FROM MOVIMENTOFISCAL 
                             WHERE CANCELADA = 0
                               AND AMBIENTE = @AMBIENTE
                               AND TIPODOCUMENTO = 65
                               AND SERIE = @SERIE
                             ORDER BY IDMOVIMENTOFISCAL DESC
                              /*LIMIT 1*/";
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.ParamByName["SERIE"] = Serie;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["NUMERO"]);
            }
        }

        public static DataTable GetNFeParaMovimentoFiscal(DateTime DataInicial, DateTime DataFinal, decimal Ambiente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MOVIMENTOFISCAL.DATAEMISSAO,
                                    MOVIMENTOFISCAL.CHAVE,
                                    CASE WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.CPF ELSE CLIENTE.CNPJ END AS CPFCNPJ,
                                    CASE WHEN CLIENTE.TIPODOCUMENTO = 1 THEN CLIENTE.NOME ELSE CLIENTE.NOMEFANTASIA END AS NOME,
                                    CLIENTE.IDCLIENTE                                    
                               FROM MOVIMENTOFISCAL
                                 INNER JOIN NFE ON (MOVIMENTOFISCAL.IDNFE = NFE.IDNFE)
                                 INNER JOIN CLIENTE ON (NFE.IDCLIENTE = CLIENTE.IDCLIENTE)
                             WHERE MOVIMENTOFISCAL.CSTAT = 100
                               AND MOVIMENTOFISCAL.AMBIENTE = @AMBIENTE
                               AND MOVIMENTOFISCAL.DATAEMISSAO BETWEEN @DATAINICIAL AND @DATAFINAL
                               AND MOVIMENTOFISCAL.TIPODOCUMENTO = 55";
                oSQL.ParamByName["DATAINICIAL"] = DataInicial;
                oSQL.ParamByName["DATAFINAL"] = DataFinal;
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}