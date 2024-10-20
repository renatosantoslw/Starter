using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMovimentoFiscalMDFe
    {
        public static bool Salvar(MovimentoFiscalMDFe Movimento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MOVIMENTOFISCALMDFE(
                                              IDMOVIMENTOFISCALMDFE, IDMDFE, SERIE, XMLENVIO, EMITIDA, CANCELADA, 
                                              DATAEMISSAO, CHAVE, CSTAT, MOTIVO, RECEBIMENTO, AMBIENTE, NUMERO, 
                                              TIPODOCUMENTO, ENCERRADA, XMLRETORNO)
                                      VALUES (@IDMOVIMENTOFISCALMDFE, @IDMDFE, @SERIE, @XMLENVIO, @EMITIDA, @CANCELADA, 
                                              @DATAEMISSAO, @CHAVE, @CSTAT, @MOTIVO, @RECEBIMENTO, @AMBIENTE, @NUMERO, 
                                              @TIPODOCUMENTO, @ENCERRADA, @XMLRETORNO)";
                        oSQL.ParamByName["IDMDFE"] = Movimento.IDMDFe;
                        oSQL.ParamByName["SERIE"] = Movimento.Serie;
                        oSQL.ParamByName["EMITIDA"] = Movimento.Emitida;
                        oSQL.ParamByName["AMBIENTE"] = Movimento.Ambiente;
                        oSQL.ParamByName["TIPODOCUMENTO"] = Movimento.TipoDocumento;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MOVIMENTOFISCALMDFE
                                       SET XMLENVIO = @XMLENVIO,
                                           XMLRETORNO = @XMLRETORNO,
                                           CSTAT = @CSTAT,
                                           CHAVE = @CHAVE,
                                           MOTIVO = @MOTIVO,
                                           RECEBIMENTO = @RECEBIMENTO,
                                           NUMERO = @NUMERO,
                                           ENCERRADA = @ENCERRADA,
                                           CANCELADA = @CANCELADA,
                                           DATAEMISSAO = @DATAEMISSAO
                                      WHERE IDMOVIMENTOFISCALMDFE = @IDMOVIMENTOFISCALMDFE";
                        break;
                }
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = Movimento.IDMovimentoFiscalMDFe;
                oSQL.ParamByName["XMLENVIO"] = Movimento.XmlEnvio;
                oSQL.ParamByName["XMLRETORNO"] = Movimento.XmlRetorno;
                oSQL.ParamByName["CANCELADA"] = Movimento.Cancelada;
                oSQL.ParamByName["DATAEMISSAO"] = Movimento.Emissao;
                oSQL.ParamByName["CHAVE"] = Movimento.Chave;
                oSQL.ParamByName["CSTAT"] = Movimento.CSTAT;
                oSQL.ParamByName["MOTIVO"] = Movimento.Motivo;
                oSQL.ParamByName["RECEBIMENTO"] = Movimento.Recebimento;
                oSQL.ParamByName["NUMERO"] = Movimento.Numero;
                oSQL.ParamByName["ENCERRADA"] = Movimento.Encerrada;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static MovimentoFiscalMDFe GetMovimentoPorMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOFISCALMDFE,
IDMDFE,
SERIE,
XMLENVIO,
XMLRETORNO,
EMITIDA,
CANCELADA,
DATAEMISSAO,
CHAVE,
CSTAT,
MOTIVO,
RECEBIMENTO,
AMBIENTE,
NUMERO,
TIPODOCUMENTO,
ENCERRADA FROM MOVIMENTOFISCALMDFE WHERE IDMDFE = @IDMDFE";
                oSQL.ParamByName["IDMDFe"] = IDMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<MovimentoFiscalMDFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static MovimentoFiscalMDFe GetMovimento(decimal IDMovimentoFiscalMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMOVIMENTOFISCALMDFE,
IDMDFE,
SERIE,
XMLENVIO,
XMLRETORNO,
EMITIDA,
CANCELADA,
DATAEMISSAO,
CHAVE,
CSTAT,
MOTIVO,
RECEBIMENTO,
AMBIENTE,
NUMERO,
TIPODOCUMENTO,
ENCERRADA FROM MOVIMENTOFISCALMDFE WHERE IDMOVIMENTOFISCALMDFE = @IDMOVIMENTOFISCALMDFE";
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = IDMovimentoFiscalMDFe;
                oSQL.Open();
                return EntityUtil<MovimentoFiscalMDFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMovimentos(DateTime Inicio, DateTime Fim, decimal Autorizada, decimal Cancelada, decimal Encerrada, decimal Rejeitada, decimal EmDigitacao, decimal Ambiente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Condicoes = new List<string>();
                if (Autorizada == 1)
                    Condicoes.Add("(MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CSTAT = 100)");

                if (Cancelada == 1)
                    Condicoes.Add("(MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CANCELADA = 1)");

                if (Encerrada == 1)
                    Condicoes.Add("(MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.ENCERRADA = 1)");

                if (EmDigitacao == 1)
                    Condicoes.Add("(MOVIMENTOFISCALMDFE.IDMOVIMENTOFISCALMDFE IS NULL)");

                if (Rejeitada == 1)
                    Condicoes.Add("(MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CSTAT <> 100)");

                oSQL.SQL = $@"SELECT DISTINCT MDFE.NMDF,
                                     MDFE.SERIE,
                                     MDFE.DATACADASTRO,
                                     MOVIMENTOFISCALMDFE.CHAVE,
                                     MOVIMENTOFISCALMDFE.RECEBIMENTO,
                                     VEICULO.PLACA+' - '+VEICULO.MODELO AS VEICULO,                                     
                                     CASE 
                                       WHEN MOVIMENTOFISCALMDFE.IDMOVIMENTOFISCALMDFE IS NULL THEN '<Em Digitação>'
                                       WHEN MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.ENCERRADA = 1 THEN '<Encerrada>'
                                       WHEN MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CANCELADA = 1 THEN '<Cancelada>'
                                       WHEN MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CSTAT = 100 THEN '<Autorizada>'
                                       WHEN MOVIMENTOFISCALMDFE.EMITIDA = 1 AND MOVIMENTOFISCALMDFE.CSTAT <> 100 THEN '<Rejeitada>'
                                     END AS STATUS,
                                     MOVIMENTOFISCALMDFE.MOTIVO,
                                     MOVIMENTOFISCALMDFE.CSTAT,
                                     MOVIMENTOFISCALMDFE.EMITIDA,
                                     MOVIMENTOFISCALMDFE.CANCELADA,
                                     MOVIMENTOFISCALMDFE.ENCERRADA,
                                     MDFE.IDMDFE,
                                     MOVIMENTOFISCALMDFE.IDMOVIMENTOFISCALMDFE
                                FROM MDFE
                              INNER JOIN VEICULOTRACAOMDFE ON (MDFE.IDMDFE = VEICULOTRACAOMDFE.IDMDFE)
                              INNER JOIN VEICULO ON (VEICULOTRACAOMDFE.IDVEICULO = VEICULO.IDVEICULO)
                               LEFT JOIN MOVIMENTOFISCALMDFE ON (MDFE.IDMDFE = MOVIMENTOFISCALMDFE.IDMDFE)
                              WHERE MDFE.DATACADASTRO BETWEEN @INICIO AND @FIM 
                                AND MDFE.TIPOAMBIENTE = @AMBIENTE
                               AND ({string.Join(" OR ", Condicoes)})
                              ORDER BY MDFE.NMDF DESC";
                oSQL.ParamByName["INICIO"] = Inicio;
                oSQL.ParamByName["FIM"] = Fim;
                oSQL.ParamByName["AMBIENTE"] = Ambiente;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Encerrar(decimal IDMovimentoFiscalMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCALMDFE
                              SET ENCERRADA = 1,
                                  CANCELADA = 0
                             WHERE IDMOVIMENTOFISCALMDFE = @IDMOVIMENTOFISCALMDFE";
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = IDMovimentoFiscalMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Cancelar(decimal IDMovimentoFiscalMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE MOVIMENTOFISCALMDFE
                              SET ENCERRADA = 0,
                                  CANCELADA = 1
                             WHERE IDMOVIMENTOFISCALMDFE = @IDMOVIMENTOFISCALMDFE";
                oSQL.ParamByName["IDMOVIMENTOFISCALMDFE"] = IDMovimentoFiscalMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
