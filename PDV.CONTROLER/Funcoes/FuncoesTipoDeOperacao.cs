using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTipoDeOperacao
    {
        public static TipoDeOperacao GetTipoDeOperacao( decimal IDTipoDeOperacao)//decimal
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT convert(int,IDTIPODEOPERACAO) IDTIPODEOPERACAO,
IDOPERACAOFISCAL,
IDFINALIDADE,
IDTIPOATENDIMENTO,
IDTRANSPORTADORA,
TIPODEFRETE,
MODELODOCUMENTO,
NOME,
CONTROLARESTOQUE,
PERMITEESTOQUENEGATIVO,
LIMITECREDITO,
INFORMACOESCOMPLEMENTARES,
SERIE,
TIPODEMOVIMENTO,
GERARFINANCEIRO,
IDCENTROCUSTO,
IDHISTORICOFINANCEIRO,
IDCONTABANCARIA,
TIPODEMOVIMENTO FROM TIPODEOPERACAO WHERE IDTIPODEOPERACAO = REPLACE('{0}', ',', '.')", IDTipoDeOperacao);
                oSQL.Open();

                

                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<TipoDeOperacao>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }    
        public static DataTable GetTiposDeOperacao()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTIPODEOPERACAO, NOME, 
                                       CASE
                                          WHEN TIPODEFRETE = 0 THEN 'EMITENTE'
                                          WHEN TIPODEFRETE = 1 THEN 'DESTINATÁRIO'
                                          WHEN TIPODEFRETE = 2 THEN 'TERCEIROS'
                                          WHEN TIPODEFRETE = 9 THEN 'SEM FRETE'
                                       END AS TIPODEFRETE,  
                                       CONTROLARESTOQUE, GERARFINANCEIRO,
                                       LIMITECREDITO, PERMITEESTOQUENEGATIVO, 
                                      CASE
                                          WHEN TIPODEMOVIMENTO = 0 THEN 'Entrada'
                                          WHEN TIPODEMOVIMENTO = 1 THEN 'Saida'
                                       END AS TIPODEMOVIMENTO,
                                       SERIE,
                                       IDTIPODEOPERACAO, IDOPERACAOFISCAL, IDFINALIDADE, 
                                       IDTIPOATENDIMENTO, MODELODOCUMENTO, 
                                       INFORMACOESCOMPLEMENTARES 
                                       FROM TIPODEOPERACAO";
                oSQL.Open();
                return oSQL.dtDados;
            }
        } 
        public static List<TipoDeOperacao>  GetListTiposDeOperacao()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTIPODEOPERACAO,
IDOPERACAOFISCAL,
IDFINALIDADE,
IDTIPOATENDIMENTO,
IDTRANSPORTADORA,
TIPODEFRETE,
MODELODOCUMENTO,
NOME,
CONTROLARESTOQUE,
PERMITEESTOQUENEGATIVO,
LIMITECREDITO,
INFORMACOESCOMPLEMENTARES,
SERIE,
TIPODEMOVIMENTO,
GERARFINANCEIRO,
IDCENTROCUSTO,
IDHISTORICOFINANCEIRO,
IDCONTABANCARIA,
TIPODEMOVIMENTO123 FROM TIPODEOPERACAO";
                oSQL.Open();
                return new DataTableParser<TipoDeOperacao>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static List<TipoDeOperacao> GetTiposDeOperacaoPorTipoDeMovimento(int movimento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTIPODEOPERACAO,
IDOPERACAOFISCAL,
IDFINALIDADE,
IDTIPOATENDIMENTO,
IDTRANSPORTADORA,
TIPODEFRETE,
MODELODOCUMENTO,
NOME,
CONTROLARESTOQUE,
PERMITEESTOQUENEGATIVO,
LIMITECREDITO,
INFORMACOESCOMPLEMENTARES,
SERIE,
TIPODEMOVIMENTO,
GERARFINANCEIRO,
IDCENTROCUSTO,
IDHISTORICOFINANCEIRO,
IDCONTABANCARIA,
TIPODEMOVIMENTO123 FROM TIPODEOPERACAO WHERE TIPODEMOVIMENTO = @TIPODEMOVIMENTO";

                oSQL.ParamByName["TIPODEMOVIMENTO"] = movimento;

                oSQL.Open();
                return new DataTableParser<TipoDeOperacao>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static bool Existe(decimal IDTipoOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM TIPODEOPERACAO WHERE IDTIPODEOPERACAO = @IDTIPODEOPERACAO";
                oSQL.ParamByName["IDTIPODEOPERACAO"] = IDTipoOperacao;
                oSQL.Open();

                return !oSQL.IsEmpty;
            }
        }

        public static bool Salvar(TipoDeOperacao tipoDeOperacao, TipoOperacao tipo)
        {
            using(SQLQuery oSQL = new SQLQuery())
            {
                switch (tipo)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                       TIPODEOPERACAO (IDTIPODEOPERACAO, IDOPERACAOFISCAL, IDFINALIDADE, IDTIPOATENDIMENTO, IDTRANSPORTADORA, TIPODEFRETE, GERARFINANCEIRO,
                                       MODELODOCUMENTO, NOME, CONTROLARESTOQUE, PERMITEESTOQUENEGATIVO, LIMITECREDITO, INFORMACOESCOMPLEMENTARES, SERIE, IDCENTROCUSTO,
                                       IDHISTORICOFINANCEIRO, IDCONTABANCARIA, TIPODEMOVIMENTO)
                                     VALUES (@IDTIPODEOPERACAO, @IDOPERACAOFISCAL, @IDFINALIDADE, @IDTIPOATENDIMENTO, @IDTRANSPORTADORA, @TIPODEFRETE, @GERARFINANCEIRO,
                                       @MODELODOCUMENTO, @NOME, @CONTROLARESTOQUE, @PERMITEESTOQUENEGATIVO, @LIMITECREDITO, @INFORMACOESCOMPLEMENTARES, @SERIE, @IDCENTROCUSTO,
                                       @IDHISTORICOFINANCEIRO, @IDCONTABANCARIA, @TIPODEMOVIMENTO)";
                        break;

                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE TIPODEOPERACAO
                                       SET IDTIPODEOPERACAO = @IDTIPODEOPERACAO,
                                           IDOPERACAOFISCAL = @IDOPERACAOFISCAL,
                                           IDFINALIDADE = @IDFINALIDADE,
                                           IDTIPOATENDIMENTO = @IDTIPOATENDIMENTO,
                                           IDTRANSPORTADORA = @IDTRANSPORTADORA,
                                           TIPODEFRETE = @TIPODEFRETE,
                                           GERARFINANCEIRO = @GERARFINANCEIRO,
                                           MODELODOCUMENTO = @MODELODOCUMENTO,
                                           NOME = @NOME,
                                           CONTROLARESTOQUE = @CONTROLARESTOQUE,
                                           PERMITEESTOQUENEGATIVO = @PERMITEESTOQUENEGATIVO,
                                           LIMITECREDITO = @LIMITECREDITO,
                                           INFORMACOESCOMPLEMENTARES = @INFORMACOESCOMPLEMENTARES,
                                           SERIE = @SERIE,
                                           IDCENTROCUSTO = @IDCENTROCUSTO,
                                           IDHISTORICOFINANCEIRO = @IDHISTORICOFINANCEIRO,
                                           IDCONTABANCARIA = @IDCONTABANCARIA,
                                           TIPODEMOVIMENTO = @TIPODEMOVIMENTO
                                       WHERE IDTIPODEOPERACAO = @IDTIPODEOPERACAO";
                        break;
                }
                oSQL.ParamByName["IDTIPODEOPERACAO"] = tipoDeOperacao.IDTipoDeOperacao;
                oSQL.ParamByName["IDOPERACAOFISCAL"] = tipoDeOperacao.IDOperacaoFiscal;
                oSQL.ParamByName["IDFINALIDADE"] = tipoDeOperacao.IDFinalidade;
                oSQL.ParamByName["IDTIPOATENDIMENTO"] = tipoDeOperacao.IDTipoAtendimento;
                oSQL.ParamByName["IDTRANSPORTADORA"] = tipoDeOperacao.IDTransportadora;
                oSQL.ParamByName["TIPODEFRETE"] = tipoDeOperacao.TipoDeFrete;
                oSQL.ParamByName["GERARFINANCEIRO"] = tipoDeOperacao.GerarFinanceiro;
                oSQL.ParamByName["MODELODOCUMENTO"] = tipoDeOperacao.ModeloDocumento;
                oSQL.ParamByName["NOME"] = tipoDeOperacao.Nome;
                oSQL.ParamByName["CONTROLARESTOQUE"] = tipoDeOperacao.ControlarEstoque;
                oSQL.ParamByName["PERMITEESTOQUENEGATIVO"] = tipoDeOperacao.PermiteEstoqueNegativo;
                oSQL.ParamByName["LIMITECREDITO"] = tipoDeOperacao.LimiteCredito;
                oSQL.ParamByName["INFORMACOESCOMPLEMENTARES"] = tipoDeOperacao.InformacoesComplementares;
                oSQL.ParamByName["SERIE"] = tipoDeOperacao.Serie;
                oSQL.ParamByName["IDCENTROCUSTO"] = tipoDeOperacao.IdCentroCusto;
                oSQL.ParamByName["IDHISTORICOFINANCEIRO"] = tipoDeOperacao.IDHistoricoFinanceiro;
                oSQL.ParamByName["IDCONTABANCARIA"] = tipoDeOperacao.IDContaBancaria;
                oSQL.ParamByName["TIPODEMOVIMENTO"] = tipoDeOperacao.TipoDeMovimento;
                return oSQL.ExecSQL() == 1;
            }

            
        }
        public static bool Remover(decimal IDTipoDeOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM TIPODEOPERACAO WHERE IDTIPODEOPERACAO = @IDTIPODEOPERACAO";
                oSQL.ParamByName["IDTIPODEOPERACAO"] = IDTipoDeOperacao;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
